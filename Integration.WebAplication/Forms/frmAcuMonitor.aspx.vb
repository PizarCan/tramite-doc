Imports Integration.BE.Persona
Imports Integration.BL
Imports System.Data
Imports Integration.DAConfiguration
Imports Integration.BE.Documento

Partial Class Forms_frmAcuMonitor
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack = True Then
            If Session("AcuMonitor") = True Then
                txtFecIni.Text = Date.Now.Date
                txtFecFin.Text = Date.Now.Date.AddDays(1)
                btnMostrar.Visible = True
            Else
                '<a href="javascript:history.go(-1)" class="Titulo1">Volver</a>
                btnMostrar.Visible = False
                btnImprimir.Visible = False
                lblError.Text = "Ud. No tiene Permisos"
            End If
        End If
    End Sub

    Public Function AvaGrafico(ByVal AvaPorcentaje As Integer, Optional ByVal Tiempo As Integer = 0) As String
        Dim RutaGrafico As String = ""
        If Tiempo < 0 AndAlso AvaPorcentaje = 0 Then
            RutaGrafico = "~\Imagenes\Infraccion.png"
        Else
            Select Case AvaPorcentaje
                Case 0
                    RutaGrafico = "~\Imagenes\FolderCloseB.gif"
                Case Is < 100
                    RutaGrafico = "~\Imagenes\Avance.gif"
                Case 100
                    RutaGrafico = "~\Imagenes\Completo.png"
            End Select
        End If
        Return RutaGrafico
    End Function

    Public Function BtnVisible(ByVal TipDocumento As Integer) As Boolean
        If TipDocumento = 8102 Then
            Return False
        Else
            Return True
        End If
    End Function


    Protected Sub btnBuscar_Click(sender As Object, e As System.EventArgs) Handles btnBuscar.Click
        Limpiar()
        If txtBuscar.Text.Trim.Length < 4 Then
            lblError.Text = "Criterio de Búsqueda no Válido"
            Exit Sub
        End If
        Dim Clase As New clsConfiguraciones
        Dim PerRelacion As String = "1,2,14"
        Dim ReqPer As BE_Req_Persona = New BE_Req_Persona()
        Dim ObjPer As BL_Persona = New BL_Persona()

        Dim Rs As DataTable
        ReqPer.cPerApellido = Clase.DBTilde(txtBuscar.Text)
        ReqPer.cPerRelTipo = PerRelacion
        Rs = ObjPer.ListaPersonas_BycPerApellido_cPerRelTipo(ReqPer)
        If Rs.Rows.Count > 0 Then
            gvPersona.Visible = True
            gvPersona.DataSource = Rs.DefaultView
            gvPersona.DataBind()
        Else
            lblError.Text = "No Hay Regsitros"
        End If
    End Sub

    Sub Limpiar()
        lblcPerCodigo.Text = String.Empty
        lblPersona.Text = String.Empty
        lblArea.Text = String.Empty
    End Sub

    Protected Sub gvPersona_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvPersona.SelectedIndexChanged
        lblcPerCodigo.Text = gvPersona.SelectedValue
        lblPersona.Text = gvPersona.Rows(gvPersona.SelectedIndex).Cells(1).Text
        lblArea.Text = gvPersona.Rows(gvPersona.SelectedIndex).Cells(2).Text
        gvPersona.Visible = False
    End Sub


    Protected Sub btnMostrar_Click(sender As Object, e As System.EventArgs) Handles btnMostrar.Click
        Dim DocEstado As String = "6318,6319,6325"
        Dim Ini As Date = txtFecIni.Text.Trim
        Dim Fin As Date = txtFecFin.Text.Trim
        Dim FecIni As String = Format(Ini, "MM/dd/yyyy")
        Dim FecFin As String = Format(Fin, "MM/dd/yyyy")
        Dim Rs As New DataTable
        Dim ReqPer As BE_Req_Documento = New BE_Req_Documento()
        Dim ObjDoc As BL_Documento = New BL_Documento()


        If rbnUsuario.Checked Then
            ReqPer.cPerCodigo = lblcPerCodigo.Text.Trim
            ReqPer.FiltroPersona = 1
            ReqPer.dFechaIni = Ini
            ReqPer.dFechaFin = Fin
            ReqPer.FiltroFecha = 0

            Rs = ObjDoc.getDocPendientesConAcuerdo(ReqPer)
        Else
            ReqPer.cPerCodigo = lblcPerCodigo.Text.Trim
            ReqPer.FiltroPersona = 0
            ReqPer.FiltroFecha = 1
            ReqPer.dFechaIni = FecIni
            ReqPer.dFechaFin = FecFin
            Rs = ObjDoc.getDocPendientesConAcuerdo(ReqPer)
        End If

        gvAcuerdos.DataSource = Rs
        gvAcuerdos.DataBind()

        Rs.Clear()

        MostrarGrafico(rbnUsuario.Checked, lblcPerCodigo.Text, rbnFecha.Checked, FecIni, FecFin)

        Dim Row As GridViewRow
        For Each Row In gvAcuerdos.Rows
            Dim lnkButon As New LinkButton

            lnkButon = CType(Row.FindControl("lbnNumDocumento"), LinkButton)
            lnkButon.OnClientClick = "javascript:(abre('frmAcuerdos.aspx?cDocCodigo=" & gvAcuerdos.DataKeys(Row.RowIndex).Values("cDocCodigo") & "&cPerCodigo=" & lblcPerCodigo.Text.Trim & "&Tipo=1" & "','Silabo'));"

        Next

    End Sub

    Sub MostrarGrafico(Optional ByVal PerFiltro As Integer = 0, Optional ByVal cPerCodigo As String = "", _
                            Optional ByVal FecFiltro As Integer = 0, Optional ByVal FecIni As String = "", _
                            Optional ByVal FecFin As String = "")

        Dim Comando As New DataTable

        Dim ReportRuta As String = String.Empty


        'Dim Reader As SqlDataReader = clsTraDoc.Get_Suma_Estado_From_Acuerdos(PerFiltro, lblcPerCodigo.Text, _
        '                                FecFiltro, FecIni, FecFin, MyTrans, Cn)

        ReportRuta = Server.MapPath("~/ReportES/crptAcuEstadistica.rpt")
         
    End Sub


    Protected Sub btnImprimir_Click(sender As Object, e As System.EventArgs) Handles btnImprimir.Click
        Dim cPerCodigo As String = lblcPerCodigo.Text.Trim
        Dim nRepTipo As Integer = 1
        Dim cRepComments As String = lblArea.Text
        Response.Write("<script language='javascript'>")
        Response.Write("window.open('Report/frmPEaDReport.aspx?nRepTipo=" & nRepTipo & "&cPerCodigo=" & cPerCodigo & "&cRepTitle=" & lblPersona.Text.Trim & "&cRepComments=" & cRepComments & "','Documentos_Diarios')")
        Response.Write("</script>")
    End Sub
End Class
