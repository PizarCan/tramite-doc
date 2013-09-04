Imports System.Data.SqlClient
Imports System.Data
Imports Integration.BL
Imports Integration.Conection
Imports Integration.DAConfiguration
Imports Integration.BE.Login
Imports Integration.BE.Persona
Imports Integration.BE.UniOrgPerExt
Imports Integration.BE.Documento

Partial Class Forms_ConCopia
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        btnConfirmar.Attributes.Add("onclick", "javascript:if(confirm('Está Seguro de Agregar Estas Copias')== false) return false;")
    End Sub

    Protected Sub txtDestino_TextChanged(sender As Object, e As System.EventArgs) Handles txtDestino.TextChanged
        If txtDestino.Text.Trim.Length > 3 Then

            Dim Clase As New clsConfiguraciones
            Dim Request As BE_Req_Persona = New BE_Req_Persona()
            Dim objBL As BL_Persona = New BL_Persona()
            Dim Rs As DataTable = New DataTable()
            Request.cPerApellido = Clase.DBTilde(txtDestino.Text)
            Request.cPerRelTipo = "1,2,14"
            Rs = objBL.ListaPeronas_BycPerApellido_cPerRelTipo(Request)
            If Rs.Rows.Count > 0 Then
                dgNombre2.DataSource = Rs
                dgNombre2.DataBind()
                dgNombre2.Visible = True
            Else
                Response.Write("No Hay Registros")
            End If
        End If
    End Sub

    Protected Sub dgNombre2_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles dgNombre2.SelectedIndexChanged
        cboInstDestino.Items.Clear()
        cboAreaDestino.Items.Clear()
        txtDestino.Text = dgNombre2.SelectedItem.Cells(2).Text
        Dim Request As BE_Req_UniOrgPerExt = New BE_Req_UniOrgPerExt()
        Dim objBL As BL_UniOrgPerExt = New BL_UniOrgPerExt()
        Dim ListaUniOrg As New DataTable
        Request.cPerCodigo = dgNombre2.SelectedItem.Cells(1).Text
        ListaUniOrg = objBL.ObtenerInstitucionesBycPerCodigo(Request)
        If ListaUniOrg.Rows.Count > 0 Then
            cboInstDestino.DataTextField = "cPernombre"
            cboInstDestino.DataValueField = "cPerCodigo"
            cboInstDestino.DataSource = ListaUniOrg
            cboInstDestino.DataBind()

            cboInstDestino.Items.Insert(0, "Seleccione Institucion")
            cboInstDestino.Items(0).Value = 0
        End If
    End Sub

    Protected Sub cboInstDestino_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboInstDestino.SelectedIndexChanged
        If Val(cboInstDestino.SelectedValue) <> 0 Then

            Dim Request As BE_Req_UniOrgPerExt = New BE_Req_UniOrgPerExt()
            Dim objBL As BL_UniOrgPerExt = New BL_UniOrgPerExt()
            Dim ListaUniOrg As New DataTable
            Request.cPerCodigo = dgNombre2.SelectedItem.Cells(1).Text
            Request.cUniCodigo = cboInstDestino.SelectedValue
            ListaUniOrg = objBL.ObtenerAreaByPersonaInstitucion(Request)
            If ListaUniOrg.Rows.Count > 0 Then
                cboAreaDestino.DataTextField = "cIntDescripcion"
                cboAreaDestino.DataValueField = "nUniOrgCodigo"
                cboAreaDestino.DataSource = ListaUniOrg
                cboAreaDestino.DataBind()
            End If
        Else
            cboAreaDestino.Items.Clear()
        End If
    End Sub

    Protected Sub btnAgregarCopia_Click(sender As Object, e As System.EventArgs) Handles btnAgregarCopia.Click
        If Val(cboAreaDestino.SelectedValue) <> 0 Then
            Session("Suma") = Session("Suma") + 1
            Arreglo(Session("Suma") - 1, 0) = dgNombre2.SelectedItem.Cells(1).Text
            Arreglo(Session("Suma") - 1, 1) = cboAreaDestino.SelectedValue
            lstCopias.Items.Add(txtDestino.Text & Space(2) & "(" & cboAreaDestino.SelectedItem.Text & ")")
        End If
    End Sub

    Protected Sub btnQuitarCopia_Click(sender As Object, e As System.EventArgs) Handles btnQuitarCopia.Click
        Dim j As Integer
        Dim i As Integer
        Try
            Arreglo(lstCopias.SelectedIndex, 0) = ""
            Arreglo(lstCopias.SelectedIndex, 1) = ""
            lstCopias.Items.Remove(lstCopias.SelectedItem.ToString)
            For i = 0 To gnCopCantidad - 1
                If Arreglo(i, 0) = "" Then
                    j = i
                    For j = j To gnCopCantidad - 1
                        Arreglo(j, 0) = Arreglo(j + 1, 0)
                        Arreglo(j, 1) = Arreglo(j + 1, 1)
                        Arreglo(j + 1, 0) = ""
                        Arreglo(j + 1, 1) = ""
                    Next
                End If
            Next
            Session("Suma") = Session("Suma") - 1
        Catch ex As Exception
            Response.Write("<script language 'javascript'>")
            Response.Write("alert ('Seleccione Un Item')")
            Response.Write("</script>")
        End Try
    End Sub

    Protected Sub btnCerrar_Click(sender As Object, e As System.EventArgs) Handles btnCerrar.Click
        ReDim Arreglo(gnCopCantidad, 1) 'Hold
        Session("Suma") = 0
        Response.Write("<script language = 'javascript'>window.close()</script>")
    End Sub

    Protected Sub btnConfirmar_Click(sender As Object, e As System.EventArgs) Handles btnConfirmar.Click
        If lstCopias.Items.Count > 0 Then
            Dim ReqCopia As BE_Req_Documento = New BE_Req_Documento()
            Dim ObjBLDoc As BL_Documento = New BL_Documento()
            ReqCopia.cDocCodigo = Request.QueryString("DocCodigo")
            Dim i As Integer
            For i = 0 To gnCopCantidad - 1
                If Arreglo(i, 0) <> "" Then
                    ReqCopia.cPerCodigo = Arreglo(i, 0)
                    If Not ObjBLDoc.setCopiaDocumento(ReqCopia) Then
                        Return
                    End If
                End If
            Next
            Session("Suma") = 0
            cboInstDestino.Items.Clear()
            cboAreaDestino.Items.Clear()
            lstCopias.Items.Clear()
            ReDim Arreglo(gnCopCantidad, 1)
            Response.Write("<script language = 'javascript'>window.close()</script>")
        End If
    End Sub
End Class
