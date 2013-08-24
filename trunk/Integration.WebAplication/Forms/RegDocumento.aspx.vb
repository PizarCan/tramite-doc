Imports System.Data.SqlClient
Imports System.Data
Imports Integration.BL
Imports Integration.Conection
Imports Integration.BE.Login
Imports Integration.BE.UniOrgPerExt
Imports Integration.BE.Constante

Partial Class Forms_RegDocumento
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim UserReq As BE_Req_Login = New BE_Req_Login()
        UserReq.cPerUsuCodigo = Session("cPerUsuCodigo")
        Dim UserBL As BL_Login = New BL_Login()

        If UserBL.ValidaInicioSesion(UserReq) Then
            If Not Page.IsPostBack Then
                Dim noMuestra As String
                noMuestra = "8000,8200,8300,8400"
                lblusuario.Text = Session("Nombre")
                lblCodPerRegistra.Text = Session("cPerCodigo")
                CboUniOrg(lblCodPerRegistra.Text)
                cboTipDocumentos(1063, 4, , , 2, 0, noMuestra)
                txtFecha.Text = Date.Now.Date
                If Session("RegPersona") = True Then btnCrearPersona.Visible = True Else btnCrearPersona.Visible = False
            End If
        End If
    End Sub

    Private Function cboTipDocumentos(ByVal nConCodigo As Integer, ByVal nConValor As Integer, Optional ByVal ConLeft As Integer = 0, Optional ByVal ConValLeft As Integer = 0, Optional ByVal ConRight As Integer = 0, Optional ByVal ConValRight As Integer = 0, Optional ByVal NotIn As String = "") As Integer
        Dim Request As BE_Req_Constante = New BE_Req_Constante()
        Dim objBL As BL_Constante = New BL_Constante()
        Dim ListaDocumentos As New List(Of BE_Res_Constante)
        Request.nConCodigo = nConCodigo
        Request.nConValor = nConValor
        Request.ConLeft = ConLeft
        Request.ConValLeft = ConValLeft
        Request.ConRight = ConRight
        Request.ConValRight = ConValRight
        Request.NotIn = NotIn
        ListaDocumentos = objBL.ListarConstantes(Request)
        If ListaDocumentos.Count > 0 Then
            Dim i As Integer = 0
            For Each ResDocumentos As BE_Res_Constante In ListaDocumentos
                cboTipDoc.Items.Add(i)
                cboTipDoc.Items(i).Text = ResDocumentos.cConDescripcion
                cboTipDoc.Items(i).Value = ResDocumentos.nConValor
                i = i + 1
            Next
            cboTipDoc.Items.Add(i)
            cboTipDoc.Items(i).Text = "<Seleccione>"
            cboTipDoc.Items(i).Value = 0
            cboTipDoc.SelectedItem.Value = 0
        End If
        Return 1
    End Function


    Sub Ocultar(ByVal Valor As Boolean)
        If Valor = True Then
            cboInstDestino.Visible = True
            dgNombre.Visible = False
        Else
            cboInstDestino.Visible = False
            dgNombre.Visible = True
        End If
    End Sub
    Sub Ocultar2(ByVal Valor As Boolean)
        If Valor = True Then
            cboInstDestino.Visible = True
            dgNombre2.Visible = False
        Else
            cboInstDestino.Visible = False
            dgNombre2.Visible = True
        End If
    End Sub

    Private Function CboUniOrg(ByVal PerCodigo As String) As Integer

        Dim Request As BE_Req_UniOrgPerExt = New BE_Req_UniOrgPerExt()
        Dim objBL As BL_UniOrgPerExt = New BL_UniOrgPerExt()
        Dim ListaUniOrg As New List(Of BE_Res_UniOrgPerExt)
        Request.cPerCodigo = PerCodigo
        ListaUniOrg = objBl.obtenerPermisos(Request)
        If ListaUniOrg.Count > 0 Then
            Dim i As Integer = 0
            For Each ResUniOrg As BE_Res_UniOrgPerExt In ListaUniOrg
                cboUO.Items.Add(i)
                cboUO.Items(i).Text = ResUniOrg.cIntDescripcion
                cboUO.Items(i).Value = ResUniOrg.nUniOrgCodigo
                i = i + 1
            Next
        End If
        Return 1
    End Function

    Protected Sub btnCancelar_Click(sender As Object, e As System.EventArgs) Handles btnCancelar.Click
        btnGrabar.Enabled = False
        Call Limpiar()
    End Sub
    Sub Limpiar()
        lblCodPerRemite.Text = ""
        lblCodPerDestino.Text = ""
        txtPerRemite.Text = ""
        txtAsunto.Text = ""
        txtDetalle.Text = ""
        'txtFecha.Text = ""
        txtObservacion.Text = ""
        cboInstDestino.Items.Clear()
        cboAreaDestino.Items.Clear()
        txtDestino.Text = ""
        txtNombre.Text = ""
        btnGrabar.Enabled = False
        btnConCopia.Enabled = False
    End Sub

    Sub EnabledFalse()
        cboTipDoc.Enabled = False
        txtPerRemite.Enabled = False
        txtAsunto.Enabled = False
        txtDetalle.Enabled = False
        txtDestino.Enabled = False
        txtNombre.Enabled = False
        txtObservacion.Enabled = False
        btnGrabar.Enabled = False
        btnConCopia.Enabled = True
        btnNuevo.Enabled = True
    End Sub

    Sub EnabledTrue()
        cboTipDoc.Enabled = True
        txtPerRemite.Enabled = True
        txtAsunto.Enabled = True
        txtDetalle.Enabled = True
        txtDestino.Enabled = True
        txtNombre.Enabled = True
        txtObservacion.Enabled = True
        btnGrabar.Enabled = True
        btnConCopia.Enabled = False
    End Sub



    Protected Sub btnNuevo_Click(sender As Object, e As System.EventArgs) Handles btnNuevo.Click
        Call EnabledTrue()
        Call Limpiar()
        Session("NumCopias") = 0
    End Sub
End Class
