Imports Integration.DAConfiguration
Imports Integration.BE.Persona
Imports Integration.BL
Imports System.Data
Imports Integration.BE.Documento
Imports Integration.BE.TraDoc

Partial Class Forms_DelegarDocumentos
    Inherits System.Web.UI.Page

    Protected Sub txtBuscar_TextChanged(sender As Object, e As System.EventArgs) Handles txtBuscar.TextChanged
        If txtBuscar.Text.Trim.Length > 3 Then
            Dim Clase As New clsConfiguraciones
            Dim Request As BE_Req_Persona = New BE_Req_Persona()
            Dim objBL As BL_Persona = New BL_Persona()
            Dim Rs As DataTable = New DataTable()
            Request.cPerApellido = Clase.DBTilde(txtBuscar.Text)
            Request.cPerRelTipo = "1"
            Rs = objBL.ListaPersonas_BycPerApellido_cPerRelTipo(Request)
            If Rs.Rows.Count > 0 Then
                gvPersona.DataSource = Rs.DefaultView
                gvPersona.DataBind()
                gvPersona.Visible = True
            Else
                Response.Write("No Hay Registros")
            End If
        End If
    End Sub

    Protected Sub btnGrabar_Click(sender As Object, e As System.EventArgs) Handles btnGrabar.Click
        'Grabar Delegado
        If lblPerCodigo.Text <> System.String.Empty And lblPerNombre.Text <> System.String.Empty Then
            Dim ReqPer As BE_Req_Persona = New BE_Req_Persona()
            Dim BL_Per As BL_Persona = New BL_Persona()
            ReqPer.cPerCodigo = Session("cPerCodigo")
            ReqPer.cPerParCodigo = lblPerCodigo.Text
            ReqPer.nPerParTipo = 1012
            If BL_Per.setDelegado(ReqPer) Then
                'MiClase.objTransanccion(406301, Session("cPerCodigo"), MyTrans, cn, lblPerCodigo.Text & "Persona ala que delegó")
            End If
            lblPerNombre.Text = System.String.Empty
            lblPerCodigo.Text = System.String.Empty
            LoaderData()
        End If
    End Sub

    Protected Sub gvPersona_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvPersona.SelectedIndexChanged
        lblPerCodigo.Text = gvPersona.SelectedItem.Cells(1).Text
        lblPerNombre.Text = gvPersona.SelectedItem.Cells(2).Text
        gvPersona.Visible = False
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Try
                btnGrabar.Attributes.Add("onclick", "javascript:if(confirm('Está Seguro de Grabar')== false) return false;")
                LoaderData()
            Catch ex As Exception
                lblError.Text = ex.Message
            End Try
        End If
    End Sub
    Sub LoaderData()
        Dim ReqTraDoc As BE_Req_TraDoc = New BE_Req_TraDoc()
        Dim BLTraDoc As BL_TraDoc = New BL_TraDoc()
        Dim Rs As DataTable
        ReqTraDoc.iOpcion = 12
        ReqTraDoc.cPerCodigo = Session("cPerCodigo")
        Rs = BLTraDoc.get_TraDoc_Procesos(ReqTraDoc)
        gvDelegado.DataSource = Rs
        gvDelegado.DataBind()
    End Sub

    Protected Sub btnCerrar_Click(sender As Object, e As System.EventArgs) Handles btnCerrar.Click
        Response.Write("<script language = 'javascript'>window.close()</script>")
    End Sub

    Protected Sub btnEliminar_Click(sender As Object, e As System.EventArgs) Handles btnEliminar.Click

        Dim Row As GridViewRow
        Dim chk As New CheckBox
        Dim cPerDelCodigo As String = String.Empty
        For Each Row In gvDelegado.Rows
            chk = CType(Row.FindControl("chkEliminar"), CheckBox)
            If chk.Checked = True Then
                cPerDelCodigo = gvDelegado.DataKeys(Row.RowIndex).Values("cPerParCodigo")
                Dim ReqPer As BE_Req_Persona = New BE_Req_Persona()
                Dim BL_Per As BL_Persona = New BL_Persona()
                ReqPer.cPerParCodigo = cPerDelCodigo
                ReqPer.cPerCodigo = Session("cPerCodigo")
                ReqPer.nPerParTipo = 1012
                If BL_Per.delDelegado(ReqPer) Then

                End If
            End If
        Next
        LoaderData()
    End Sub
End Class
