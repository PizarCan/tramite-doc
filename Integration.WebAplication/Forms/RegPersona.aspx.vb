Imports System.Data.SqlClient
Imports System.Data
Imports Integration.BL
Imports Integration.Conection
Imports Integration.DAConfiguration
Imports Integration.BE.Login
Imports Integration.BE.Persona
Imports Integration.BE.Ubigeo


Partial Class Forms_RegPersona
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim UserReq As BE_Req_Login = New BE_Req_Login()
        UserReq.cPerUsuCodigo = Session("cPerUsuCodigo")
        Dim UserBL As BL_Login = New BL_Login()
        If UserBL.ValidaInicioSesion(UserReq) Then
            If Not Page.IsPostBack Then
                CargarRegion()
                If Session("RegPersona") = False Then btnGrabar.Visible = False
            End If
        End If
        btnGrabar.Attributes.Add("onclick", "javascript:if(confirm('Está Seguro de Grabar')== false) return false;")
        
    End Sub

    Private Sub CargarRegion()
        Dim ReqUbigeo As BE_Req_Ubigeo = New BE_Req_Ubigeo()
        Dim BLUbigeo As BL_Ubigeo = New BL_Ubigeo()
        Dim Rs As DataTable = New DataTable
        
        ReqUbigeo.cUbiGeoCodigo = "1"
        Rs = BLUbigeo.getUbigeoBycUbiGeoCodigo(ReqUbigeo)
        If Rs.Rows.Count > 0 Then
            cboRegion.DataTextField = "cUbiGeoDescripcion"
            cboRegion.DataValueField = "cUbiGeoCodigo"
            cboRegion.DataSource = Rs
            cboRegion.DataBind()
        End If
        cboRegion.Items.Insert(0, "Seleccione Region")
        cboRegion.Items(0).Value = 0
    End Sub

    Protected Sub cboRegion_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboRegion.SelectedIndexChanged
        If cboRegion.SelectedValue <> 0 Then
            Dim CodRegion As String
            CodRegion = "2" & Left(Mid(cboRegion.SelectedValue, 2), 2)
            Dim ReqUbigeo As BE_Req_Ubigeo = New BE_Req_Ubigeo()
            Dim BLUbigeo As BL_Ubigeo = New BL_Ubigeo()
            Dim Rs As DataTable = New DataTable

            ReqUbigeo.cUbiGeoCodigo = CodRegion
            Rs = BLUbigeo.getUbigeoBycUbiGeoCodigo(ReqUbigeo)
            If Rs.Rows.Count > 0 Then
                cboProvincia.DataTextField = "cUbiGeoDescripcion"
                cboProvincia.DataValueField = "cUbiGeoCodigo"
                cboProvincia.DataSource = Rs
                cboProvincia.DataBind()
            Else
                cboProvincia.Items.Clear()
            End If
        End If
    End Sub

    Protected Sub txtApellido_TextChanged(sender As Object, e As System.EventArgs) Handles txtApellido.TextChanged
        txtApellido.Text = UCase(txtApellido.Text)
    End Sub

    Protected Sub txtNombre_TextChanged(sender As Object, e As System.EventArgs) Handles txtNombre.TextChanged
        txtNombre.Text = UCase(txtNombre.Text)
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As System.EventArgs) Handles btnCancelar.Click
        Response.Write("<script language = 'javascript'>window.close()</script>")
    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As System.EventArgs) Handles btnBuscar.Click
        If txtBuscar.Text.Trim.Length > 3 Then
            Dim Clase As New clsConfiguration
            Dim Request As BE_Req_Persona = New BE_Req_Persona()
            Dim objBL As BL_Persona = New BL_Persona()
            Dim Rs As DataTable = New DataTable()
            Request.cPerApellido = Clase.DBTilde(txtBuscar.Text)
            Rs = objBL.ListaPeronas_BycPerApellido(Request)
            If Rs.Rows.Count > 0 Then
                gvPersona.DataSource = Rs
                gvPersona.DataBind()
            Else
                Response.Write("No Hay Registros")
            End If
        End If
    End Sub

    Protected Sub btnGrabar_Click(sender As Object, e As System.EventArgs) Handles btnGrabar.Click
        lblError.Text = String.Empty
        If txtApellido.Text.Trim.Length > 6 And txtNombre.Text.Trim.Length > 2 And cboProvincia.SelectedValue <> "" Then
            'Dim TransCodigo As String
            Dim Clase As New clsConfiguration
            Dim Request As BE_Req_Persona = New BE_Req_Persona()
            Dim objBL As BL_Persona = New BL_Persona()
            Dim Rs As DataTable = New DataTable()
            'Dim ObjBLDoc As BL_Documento = New BL_Documento()
            Request.cPerApellido = Clase.DBTilde(txtApellido.Text)
            Request.cPerNombre = Clase.DBTilde(txtNombre.Text)
            Rs = objBL.ListaPeronas_BycPerApellido(Request)
            If Rs.Rows.Count = 0 Then
                'TransCodigo = Clase.objGeneraCodDoc(ObjBLDoc.getFechaActual)
                Request.cPerApellido = txtApellido.Text
                Request.cPerNombre = txtNombre.Text
                Request.nPerTipo = cboPerTipo.SelectedValue
                Request.cPerCodigo = objBL.getcPerCodigoNew().cPerCodigo
                Request.cUbiGeoCodigo = cboProvincia.SelectedValue
                If objBL.setPersona(Request) Then
                    lblError.Text = "Se Registró Exitosamente"
                Else
                    lblError.Text = "Error al registrar"
                End If

            Else
                lblError.Text = "Ya existe una persona con estos datos"
            End If

        Else
            lblError.Text = "Datos incorrectos"
        End If
    End Sub
End Class
