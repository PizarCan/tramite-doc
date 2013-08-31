
Partial Class Forms_frmAcuMonitor
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        clsConsultasComunes.Ins_User_From_Login(Session("PerCodigo"))
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
        Try
            Limpiar()
            If txtBuscar.Text.Trim.Length < 4 Then
                lblError.Text = "Criterio de Búsqueda no Válido"
                Exit Sub
            End If
            Using cn As New SqlConnection(MiConexion)
                Dim Clase As New clsTraDoc
                Dim MyTrans As SqlTransaction
                Dim PerRelacion As String = "1,2,14"
                Dim Rs As DataTable

                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                MyTrans = cn.BeginTransaction
                Rs = Clase.objBuscarPersona(MyTrans, cn, Clase.DBTilde(txtBuscar.Text), PerRelacion)
                If Rs.Rows.Count > 0 Then
                    gvPersona.Visible = True
                    gvPersona.DataSource = Rs.DefaultView
                    gvPersona.DataBind()
                Else
                    lblError.Text = "No Hay Regsitros"
                End If

            End Using
        Catch ex As Exception
            lblError.Text = ex.Message
        End Try
    End Sub

    Sub Limpiar()
        lblcPerCodigo.Text = String.Empty
        lblPersona.Text = String.Empty
        lblArea.Text = String.Empty
    End Sub



    Protected Sub gvPersona_SelectedIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gvPersona.SelectedIndexChanging
        lblcPerCodigo.Text = gvPersona.SelectedValue
        lblPersona.Text = gvPersona.Rows(gvPersona.SelectedIndex).Cells(1).Text
        lblArea.Text = gvPersona.Rows(gvPersona.SelectedIndex).Cells(2).Text
        'gvPersona.DataSource = Nothing
        'gvPersona.DataBind()
        gvPersona.Visible = False
    End Sub

    Protected Sub btnMostrar_Click(sender As Object, e As System.EventArgs) Handles btnMostrar.Click
        Using cn As New SqlConnection(MiConexion)
            Dim MyTrans As SqlTransaction
            Dim Clase As New clsTraDoc
            Dim Rs As SqlDataReader
            Try

                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If

                MyTrans = cn.BeginTransaction

                Dim DocEstado As String = "6318,6319,6325"
                Dim Ini As Date = txtFecIni.Text.Trim
                Dim Fin As Date = txtFecFin.Text.Trim
                Dim FecIni As String = Format(Ini, "MM/dd/yyyy")
                Dim FecFin As String = Format(Fin, "MM/dd/yyyy")

                If rbnUsuario.Checked Then
                    Rs = Clase.Get_DocPendientes_With_Acuerdo(lblcPerCodigo.Text.Trim, 1, 0, cn, MyTrans)
                Else
                    Rs = Clase.Get_DocPendientes_With_Acuerdo(lblcPerCodigo.Text.Trim, 0, 1, cn, MyTrans, FecIni, FecFin)
                End If

                gvAcuerdos.DataSource = Rs
                gvAcuerdos.DataBind()

                Rs.Close()

                MostrarGrafico(rbnUsuario.Checked, lblcPerCodigo.Text, rbnFecha.Checked, FecIni, FecFin)

                Dim Row As GridViewRow
                For Each Row In gvAcuerdos.Rows
                    Dim lnkButon As New LinkButton

                    lnkButon = CType(Row.FindControl("lbnNumDocumento"), LinkButton)
                    lnkButon.OnClientClick = "javascript:(abre('frmAcuerdos.aspx?cDocCodigo=" & gvAcuerdos.DataKeys(Row.RowIndex).Values("cDocCodigo") & "&Tipo=1" & "','Silabo'));"

                Next

            Catch x As Exception
                Response.Write(x.Message)
            End Try
        End Using
    End Sub

    Sub MostrarGrafico(Optional ByVal PerFiltro As Integer = 0, Optional ByVal cPerCodigo As String = "", _
                            Optional ByVal FecFiltro As Integer = 0, Optional ByVal FecIni As String = "", _
                            Optional ByVal FecFin As String = "")


        'Dim Report As New ReportDocument
        Dim Comando As New DataTable

        Using Cn As New SqlConnection(TramiteDocumentario.MiConexion)
            Cn.Open()
            Dim ReportRuta As String = String.Empty
            Dim MyTrans As SqlTransaction = Cn.BeginTransaction

            Try
                Dim clsTraDoc As New clsTraDoc
                Dim Reader As SqlDataReader = clsTraDoc.Get_Suma_Estado_From_Acuerdos(PerFiltro, lblcPerCodigo.Text, _
                                                FecFiltro, FecIni, FecFin, MyTrans, Cn)

                ReportRuta = Server.MapPath("~/Report/crptAcuEstadistica.rpt")

                Comando.Load(Reader)
                'Report.Close()

                'Report.Load(ReportRuta)
                'Report.SetDataSource(Comando)

                MyTrans.Commit()
                Cn.Close()
                'Me.crvAcuerdos.ReportSource = Report
            Catch ex As Exception
                Throw ex
            End Try

        End Using

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
