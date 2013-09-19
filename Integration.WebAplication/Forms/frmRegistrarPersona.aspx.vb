Imports System.Data.SqlClient
Imports System.Data
Imports Integration.Conection
Imports Integration.BL
Imports Integration.DAConfiguration
Imports Integration.BE.Login
Imports Integration.BE.Persona
Imports Integration.BE.Ubigeo
Imports Integration.BE.Constante
Imports Integration.BE.UniOrgPerExt

Partial Class Forms_frmRegistrarPersona
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CargarRegion()
            CargarTipoPersona()
            CargarDocumento()
            CargarInstituciones()
            If Session("RegPersona") = False Then btnGrabar.Visible = False
        End If
    End Sub

    Private Sub CargarInstituciones()
        Dim objBL As BL_UniOrgPerExt = New BL_UniOrgPerExt()
        Dim ListaInstituciones As New DataTable
        ListaInstituciones = objBL.GetInstituciones()
        If ListaInstituciones.Rows.Count > 0 Then
            ddlInst.DataTextField = "cPerNombre"
            ddlInst.DataValueField = "cPerCodigo"
            ddlInst.DataSource = ListaInstituciones
            ddlInst.DataBind()
            ddlInst.Items.Insert(0, "<Seleccione>")
            ddlInst.Items(0).Value = 0
        End If
    End Sub
    Private Sub CargarDocumento()
        Dim Request As BE_Req_Constante = New BE_Req_Constante()
        Dim objBL As BL_Constante = New BL_Constante()
        Dim ListaDocumentos As New DataTable
        If cboTipoPersona.SelectedValue = 1 Then
            Request.nConCodigo = 1013
        ElseIf cboTipoPersona.SelectedValue = 2 Then
            Request.nConCodigo = 1012
        End If
        Request.nConValor = 0
        Request.NotIn = "0"
        ListaDocumentos = objBL.ListarConstantes(Request)
        If ListaDocumentos.Rows.Count > 0 Then
            cboDocumento.DataTextField = "cConDescripcion"
            cboDocumento.DataValueField = "nConValor"
            cboDocumento.DataSource = ListaDocumentos
            cboDocumento.DataBind()
            cboDocumento.Items.Insert(0, "<Seleccione>")
            cboDocumento.Items(0).Value = 0
        Else
            cboDocumento.Items.Insert(0, "<Seleccione Primero Tipo de Persona>")
            cboDocumento.Items(0).Value = 0
        End If
    End Sub
    Private Sub CargarTipoPersona()
        Dim Request As BE_Req_Constante = New BE_Req_Constante()
        Dim objBL As BL_Constante = New BL_Constante()
        Dim ListaTipoPersona As New DataTable
        Request.nConCodigo = 1010
        Request.nConValor = 0
        Request.NotIn = "0"
        ListaTipoPersona = objBL.ListarConstantes(Request)
        If ListaTipoPersona.Rows.Count > 0 Then
            cboTipoPersona.DataTextField = "cConDescripcion"
            cboTipoPersona.DataValueField = "nConValor"
            cboTipoPersona.DataSource = ListaTipoPersona
            cboTipoPersona.DataBind()
            cboTipoPersona.Items.Insert(0, "<Seleccione>")
            cboTipoPersona.Items(0).Value = 0
        End If
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
        cboRegion.Items.Insert(0, "Seleccione Departamento")
        cboRegion.Items(0).Value = 0
    End Sub


    Protected Sub cboRegion_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboRegion.SelectedIndexChanged
        If cboRegion.SelectedValue <> 0 Then
            CargarProvincia()
        End If
    End Sub

    Sub CargarProvincia()
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
    End Sub

    Protected Sub ddlInst_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlInst.SelectedIndexChanged
        If ddlInst.SelectedValue <> 0 Then
            CargarArea()
        End If
    End Sub

    Sub CargarArea()
        Dim CodInst As String
        CodInst = ddlInst.SelectedValue
        Dim ReqUniOrg As BE_Req_UniOrgPerExt = New BE_Req_UniOrgPerExt()
        Dim Obj_BL As BL_UniOrgPerExt = New BL_UniOrgPerExt()
        Dim Rs As DataTable = New DataTable

        ReqUniOrg.cPerCodigo = CodInst
        Rs = Obj_BL.GetAreaByInstitucion(ReqUniOrg)
        If Rs.Rows.Count > 0 Then
            ddlArea.DataTextField = "cIntDescripcion"
            ddlArea.DataValueField = "nintcodigo"
            ddlArea.DataSource = Rs
            ddlArea.DataBind()
        Else
            ddlArea.Items.Clear()
        End If
    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As System.EventArgs) Handles btnBuscar.Click
        If txtBuscar.Text.Trim.Length > 3 Then
            Dim Clase As New clsConfiguraciones
            Dim Request As BE_Req_Persona = New BE_Req_Persona()
            Dim objBL As BL_Persona = New BL_Persona()
            Dim Rs As DataTable = New DataTable()
            Request.cPerApellido = Clase.DBTilde(txtBuscar.Text)
            Rs = objBL.ListaPeronas_BycPerApellido(Request)
            If Rs.Rows.Count > 0 Then
                dgNombre.DataSource = Rs
                dgNombre.DataBind()
            Else
                Response.Write("No Hay Registros")
            End If
        End If
    End Sub

    Protected Sub btnGrabar_Click(sender As Object, e As System.EventArgs) Handles btnGrabar.Click

        If ValidarDatos() Then
            lblError.Text = String.Empty
            Dim Clase As New clsConfiguraciones
            Dim Request As BE_Req_Persona = New BE_Req_Persona()
            Dim objBL As BL_Persona = New BL_Persona()
            Dim Rs As DataTable = New DataTable()
            Request.cPerApellido = Clase.DBTilde(txtApellido.Text)
            Request.cPerNombre = Clase.DBTilde(txtNombre.Text)
            Rs = objBL.ListaPeronas_BycPerApellido(Request)
            If Rs.Rows.Count = 0 Or btnGrabar.Text = "Actualizar" Then
                Request.cPerApellido = txtApellido.Text
                Request.cPerNombre = txtNombre.Text
                Request.nPerTipo = cboTipoPersona.SelectedValue
                Request.cPerCodigo = objBL.getcPerCodigoNew().cPerCodigo
                Request.cUbiGeoCodigo = cboProvincia.SelectedValue
                Request.nPerIdeTipo = cboDocumento.SelectedValue
                Request.cPerIdeNumero = txtNroDoc.Text
                Request.cPerDomDireccion = txtDireccion.Text
                Request.nUniOrgCodigo = ddlArea.SelectedValue

                If btnGrabar.Text = "Grabar" Then
                    If objBL.InsPersonaArea(Request) Then
                        lblError.Text = "Se Registró Exitosamente"
                    Else
                        lblError.Text = "Error al registrar"
                    End If
                ElseIf btnGrabar.Text = "Actualizar" Then
                    Request.cPerCodigo = lblCodSeleccionado.Text
                    Request.nPerDirCodigo = lblnPerDirCodigo.Text
                    If objBL.UpdPersonaArea(Request) Then
                        lblError.Text = "Se Actualizo Exitosamente"
                    Else
                        lblError.Text = "Error al Actualizar"
                    End If
                End If

            Else
                lblError.Text = "Ya existe una persona con estos datos"
            End If

        End If



    End Sub

    Function ValidarDatos() As Boolean

        If cboTipoPersona.SelectedValue = 0 Then
            lblError.Text = "Seleccione el tipo de persona"
            Return False
        End If
        If txtApellido.Text.Trim.Length < 3 And cboTipoPersona.SelectedValue <> 2 Then
            lblError.Text = "Ingrese un apellido correcto"
            Return False
        End If
        If txtNombre.Text.Trim.Length < 3 Then
            lblError.Text = "Ingrese un nombre correcto"
            Return False
        End If
        If cboDocumento.SelectedValue = 0 Then
            lblError.Text = "Seleccione el tipo de documento"
            Return False
        End If
        If txtNroDoc.Text.Trim.Length < 3 Then
            lblError.Text = "Ingrese un número de documento correcto"
            Return False
        ElseIf cboDocumento.SelectedValue = 25 And txtNroDoc.Text.Trim.Length <> 8 Then
            lblError.Text = "Ingrese un número de DNI documento correcto"
            Return False
        ElseIf cboDocumento.SelectedValue = 11 And txtNroDoc.Text.Trim.Length <> 11 Then
            lblError.Text = "Ingrese un número de RUC documento correcto"
            Return False
        End If
        If txtDireccion.Text.Trim.Length < 3 Then
            lblError.Text = "Ingrese una dirección correcta"
            Return False
        End If
        If cboRegion.SelectedValue = 0 Then
            lblError.Text = "Seleccione el Departamento"
            Return False
        End If
        If cboProvincia.SelectedValue = 0 Then
            lblError.Text = "Seleccione la provincia"
            Return False
        End If
        If ddlInst.SelectedValue = 0 Then
            lblError.Text = "Seleccione la Institución"
            Return False
        End If
        If ddlArea.SelectedValue = 0 Then
            lblError.Text = "Seleccione el Área"
            Return False
        End If

        Return True
    End Function

    Protected Sub cboTipoPersona_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboTipoPersona.SelectedIndexChanged
        CargarDocumento()
    End Sub

    Protected Sub dgNombre_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles dgNombre.SelectedIndexChanged
        limpiar()
        MostrarInformacion(dgNombre.SelectedItem.Cells(1).Text)
    End Sub

    Sub MostrarInformacion(ByVal codigo As String)
        Dim ReqPersona As BE_Req_Persona = New BE_Req_Persona()
        Dim ObjPersona As BL_Persona = New BL_Persona()
        Dim Dt As New DataTable()
        ReqPersona.cPerCodigo = codigo
        Dt = ObjPersona.GetDatosPersona_BycPerCodigo(ReqPersona)
        If Dt.Rows.Count = 1 Then
            btnGrabar.Text = "Actualizar"
            lblCodSeleccionado.Text = Dt.Rows(0).Item(0)
            cboTipoPersona.SelectedValue = Dt.Rows(0).Item(1)
            CargarDocumento()
            txtApellido.Text = Dt.Rows(0).Item(2).ToString
            txtNombre.Text = Dt.Rows(0).Item(3).ToString
            cboDocumento.SelectedValue = Dt.Rows(0).Item(4)
            txtNroDoc.Text = Dt.Rows(0).Item(5)
            txtDireccion.Text = Dt.Rows(0).Item(6)
            lblnPerDirCodigo.Text = Dt.Rows(0).Item(7)
            cboRegion.SelectedValue = Dt.Rows(0).Item(9)
            If cboRegion.SelectedValue <> 0 Then
                CargarProvincia()
                cboProvincia.SelectedValue = Dt.Rows(0).Item(8)
            End If
            ddlInst.SelectedValue = Dt.Rows(0).Item(11)
            If ddlInst.SelectedValue <> 0 Then
                CargarArea()
                ddlArea.SelectedValue = Dt.Rows(0).Item(10)
            End If

        End If
    End Sub

    Sub limpiar()
        lblCodSeleccionado.Text = ""
        lblnPerDirCodigo.Text = ""
        lblError.Text = ""
        cboProvincia.Items.Clear()
        ddlArea.Items.Clear()
        txtApellido.Text = ""
        txtNombre.Text = ""
        txtDireccion.Text = ""
        txtNroDoc.Text = ""
        cboRegion.Items.Clear()
        CargarRegion()
        ddlInst.Items.Clear()
        CargarInstituciones()
        cboTipoPersona.Items.Clear()
        CargarTipoPersona()
        cboDocumento.Items.Clear()
        CargarDocumento()
    End Sub
    Protected Sub btnLimpiar_Click(sender As Object, e As System.EventArgs) Handles btnLimpiar.Click
        limpiar()
    End Sub
End Class
