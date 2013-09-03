Imports System.Data.SqlClient
Imports System.Data
Imports Integration.BL
Imports Integration.Conection
Imports Integration.DAConfiguration
Imports Integration.BE.Login
Imports Integration.BE.UniOrgPerExt
Imports Integration.BE.Constante
Imports Integration.BE.Persona
Imports Integration.BE.Periodo
Imports Integration.BE.Documento

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
        btnGrabar.Attributes.Add("onclick", "javascript:if(confirm('Está Seguro de Grabar')== false) return false;")
    End Sub

    Private Function cboTipDocumentos(ByVal nConCodigo As Integer, ByVal nConValor As Integer, Optional ByVal ConLeft As Integer = 0, Optional ByVal ConValLeft As Integer = 0, Optional ByVal ConRight As Integer = 0, Optional ByVal ConValRight As Integer = 0, Optional ByVal NotIn As String = "") As Integer
        Dim Request As BE_Req_Constante = New BE_Req_Constante()
        Dim objBL As BL_Constante = New BL_Constante()
        Dim ListaDocumentos As New DataTable
        Request.nConCodigo = nConCodigo
        Request.nConValor = nConValor
        Request.ConLeft = ConLeft
        Request.ConValLeft = ConValLeft
        Request.ConRight = ConRight
        Request.ConValRight = ConValRight
        Request.NotIn = NotIn
        ListaDocumentos = objBL.ListarConstantes(Request)
        If ListaDocumentos.Rows.Count > 0 Then
            cboTipDoc.DataTextField = "cConDescripcion"
            cboTipDoc.DataValueField = "nConValor"
            cboTipDoc.DataSource = ListaDocumentos

            cboTipDoc.Items.Insert(0, "<Seleccione>")
            cboTipDoc.Items(0).Value = 0
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
        Dim ListaUniOrg As New DataTable()
        Request.cPerCodigo = PerCodigo
        ListaUniOrg = objBL.ObtenerUniOrgBycPerCodigo(Request)
        If ListaUniOrg.Rows.Count > 0 Then
            cboUO.DataTextField = "cIntDescripcion"
            cboUO.DataValueField = "nUniOrgCodigo"
            cboUO.DataSource = ListaUniOrg
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

    Protected Sub txtNombre_TextChanged(sender As Object, e As System.EventArgs) Handles txtNombre.TextChanged
        If txtNombre.Text.Trim.Length > 3 Then
            Dim Clase As New clsConfiguration
            Dim Request As BE_Req_Persona = New BE_Req_Persona()
            Dim objBL As BL_Persona = New BL_Persona()
            Dim Rs As DataTable = New DataTable()
            Request.cPerApellido = Clase.DBTilde(txtNombre.Text)
            Rs = objBL.ListaPeronas_BycPerApellido(Request)
            If Rs.Rows.Count > 0 Then
                Ocultar(False)
                dgNombre.DataSource = Rs
                dgNombre.DataBind()
            Else
                Response.Write("No Hay Registros")
                Ocultar(True)
            End If
        End If
    End Sub

    Protected Sub dgNombre_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles dgNombre.SelectedIndexChanged
        txtPerRemite.Text = dgNombre.SelectedItem.Cells(2).Text
        lblCodPerRemite.Text = dgNombre.SelectedItem.Cells(1).Text
        Ocultar(True)
    End Sub

    Protected Sub txtDestino_TextChanged(sender As Object, e As System.EventArgs) Handles txtDestino.TextChanged
        If txtDestino.Text.Trim.Length > 3 Then
            Dim Clase As New clsConfiguration
            Dim Request As BE_Req_Persona = New BE_Req_Persona()
            Dim objBL As BL_Persona = New BL_Persona()
            Dim Rs As DataTable = New DataTable()
            Request.cPerApellido = Clase.DBTilde(txtNombre.Text)
            Request.cPerRelTipo = "1,2,14"
            Rs = objBL.ListaPeronas_BycPerApellido_cPerRelTipo(Request)
            If Rs.Rows.Count > 0 Then
                Ocultar2(False)
                dgNombre2.DataSource = Rs
                dgNombre2.DataBind()
            Else
                Response.Write("No Hay Registros")
                Ocultar2(True)
            End If 
        End If
    End Sub

    Protected Sub dgNombre2_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles dgNombre2.SelectedIndexChanged
        txtDestino.Text = dgNombre2.SelectedItem.Cells(2).Text
        lblCodPerDestino.Text = dgNombre2.SelectedItem.Cells(1).Text

        cboInstDestino.Items.Clear()
        cboAreaDestino.Items.Clear()

        Dim Request As BE_Req_UniOrgPerExt = New BE_Req_UniOrgPerExt()
        Dim objBL As BL_UniOrgPerExt = New BL_UniOrgPerExt()
        Dim ListaUniOrg As New List(Of BE_Res_UniOrgPerExt)
        Request.cPerCodigo = dgNombre2.SelectedItem.Cells(1).Text
        ListaUniOrg = objBL.ObtenerInstitucionesBycPerCodigo(Request)
        If ListaUniOrg.Count > 0 Then
            cboInstDestino.Items.Insert(0, "Seleccione Institucion")
            cboInstDestino.Items(0).Value = 0
            Dim i As Integer = 1
            For Each ResUniOrg As BE_Res_UniOrgPerExt In ListaUniOrg
                cboInstDestino.Items.Add(i)
                cboInstDestino.Items(i).Text = ResUniOrg.cPernombre
                cboInstDestino.Items(i).Value = ResUniOrg.cPerCodigo
                i = i + 1
            Next
        End If
        btnGrabar.Enabled = True
        Ocultar2(True)

    End Sub

    Protected Sub cboInstDestino_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboInstDestino.SelectedIndexChanged
        If Val(cboInstDestino.SelectedValue) <> 0 Then

            Dim Request As BE_Req_UniOrgPerExt = New BE_Req_UniOrgPerExt()
            Dim objBL As BL_UniOrgPerExt = New BL_UniOrgPerExt()
            Dim ListaUniOrg As New List(Of BE_Res_UniOrgPerExt)
            Request.cPerCodigo = dgNombre2.SelectedItem.Cells(1).Text
            Request.cUniCodigo = cboInstDestino.SelectedValue
            ListaUniOrg = objBL.ObtenerAreaByPersonaInstitucion(Request)
            If ListaUniOrg.Count > 0 Then
                Dim i As Integer = 0
                For Each ResUniOrg As BE_Res_UniOrgPerExt In ListaUniOrg
                    cboAreaDestino.Items.Add(i)
                    cboAreaDestino.Items(i).Text = ResUniOrg.cIntDescripcion
                    cboAreaDestino.Items(i).Value = ResUniOrg.nUniOrgCodigo
                    i = i + 1
                Next
            End If

        End If
    End Sub

    Protected Sub btnGrabar_Click(sender As Object, e As System.EventArgs) Handles btnGrabar.Click
        If Val(cboTipDoc.SelectedValue) <> 0 AndAlso txtPerRemite.Text <> "" AndAlso Val(cboAreaDestino.SelectedValue) <> 0 AndAlso txtAsunto.Text <> "" AndAlso txtDetalle.Text <> "" AndAlso txtNumDocumento.Text <> "" AndAlso txtFecha.Text <> "" AndAlso lblCodPerDestino.Text.Trim <> "" AndAlso lblCodPerRemite.Text.Trim <> "" AndAlso lblCodPerRegistra.Text.Trim <> "" Then
            Dim NewCodDoc As String
            Dim FechaActual As DateTime
            Dim PerRelSolicita As Integer

            Dim UORemCodigo As Integer = 1

            'BUSCAR SI EXISTE EL NUM DE DOCUMENTO
            Dim ReqDocumento As BE_Req_Documento = New BE_Req_Documento()
            Dim objBLDoc As BL_Documento = New BL_Documento()
            Dim ResDocumento As BE_Res_Documento = New BE_Res_Documento()
            ReqDocumento.nDocTipo = cboTipDoc.SelectedValue
            ReqDocumento.cDocNDoc = Trim(txtNumDocumento.Text)
            ResDocumento = objBLDoc.getDocumentoBycDocNDoc_nDocTipo(ReqDocumento)

            If ResDocumento.cDocCodigo <> "" Then
                Response.Write("<P style=Color:Red>Ya Existe El Número de Documento</P>")
                Exit Sub
            End If

            'GENERAR NUEVO NUMERO
            Dim Clase As New clsConfiguration
            NewCodDoc = Clase.objGeneraCodDoc(objBLDoc.getFechaActual)
            Session("DocCodReg") = NewCodDoc
            'FechaActual = Format(objBLDoc.getFechaActual, "MM/dd/yyyy HH:mm:ss")
            FechaActual = objBLDoc.getFechaActual

            ReqDocumento.cPerCodigo = lblCodPerRemite.Text
            ResDocumento = objBLDoc.getTipoPersona(ReqDocumento)

            If ResDocumento.cPerCodigo <> "" Then
                If Val(ResDocumento.nAdministrativo) > 0 Then
                    PerRelSolicita = 1
                    'ElseIf Val(Rs.Rows.Item(0).Item(2)) > 0 Then
                    '    PerRelSolicita = 2
                ElseIf Val(ResDocumento.nAlumno) > 0 Then
                    PerRelSolicita = 3
                Else
                    PerRelSolicita = 4
                End If
            End If

            Dim ReqUniOrgPerExt As BE_Req_UniOrgPerExt = New BE_Req_UniOrgPerExt()
            Dim BLUniOrg As BL_UniOrgPerExt = New BL_UniOrgPerExt()
            Dim ListaUniOrg As New DataTable()
            ReqUniOrgPerExt.cPerCodigo = lblCodPerRemite.Text
            ListaUniOrg = BLUniOrg.ObtenerUniOrgBycPerCodigo(ReqUniOrgPerExt)
            If ListaUniOrg.Rows.Count > 0 Then
                UORemCodigo = ListaUniOrg.Rows(0).Item(0)
            End If
            Dim DocPerTipo As Integer
            DocPerTipo = 8
            If Session("MesaPartesArea") = True Then DocPerTipo = 4
            Dim nPrdCodigo As Integer = 0
            Dim ReqPeriodo As BE_Req_Periodo = New BE_Req_Periodo()
            Dim objBL As BL_Periodo = New BL_Periodo()
            Dim ResPeriodo As BE_Res_Periodo = New BE_Res_Periodo()
            ReqPeriodo.nPrdActividad = 1
            ResPeriodo = objBL.get_PeriodoActual_ByActividad(ReqPeriodo)
            Dim PrdActual As Integer
            PrdActual = ResPeriodo.nPrdCodigo

            'Registrar Documento
            ReqDocumento.cDocCodigo = NewCodDoc
            ReqDocumento.dDocFecha = FechaActual
            ReqDocumento.cDocObserv = txtObservacion.Text
            ReqDocumento.nDocTipo = cboTipDoc.SelectedValue
            ReqDocumento.nDocEstado = 6318
            ReqDocumento.CodPerSolicita = lblCodPerRemite.Text
            ReqDocumento.PerRelSolicita = PerRelSolicita
            ReqDocumento.CodPerRecibe = lblCodPerDestino.Text
            ReqDocumento.CodUODestino = cboAreaDestino.SelectedValue
            ReqDocumento.Asunto = txtAsunto.Text
            ReqDocumento.Detalle = txtDetalle.Text
            ReqDocumento.dFechaIni = txtFecha.Text
            ReqDocumento.dFechaFin = txtFecha.Text
            ReqDocumento.cDocNDoc = txtNumDocumento.Text
            ReqDocumento.CodPerRegistra = lblCodPerRegistra.Text
            ReqDocumento.CodUORemite = UORemCodigo
            ReqDocumento.nDocPerTipo = DocPerTipo
            ReqDocumento.nPrdCodigo = PrdActual
            Dim registra As Boolean = False

            If (objBLDoc.setDocumento(ReqDocumento)) Then
                registra = True
            End If

            'Clase.objTransanccion(406304, Session("PerCodigo"), MyTrans, cn, "Doc:" & NewCodDoc & "Destino:" & lblCodPerDestino.Text)


            If registra Then
                Response.Write("<script language='javascript'>")
                Response.Write("alert ('Documento Enviado')")
                Response.Write("</script>")
            Else
                Response.Write("<script language='javascript'>")
                Response.Write("alert ('No Se Completo La Tranzacción')")
                Response.Write("</script>")
            End If

        Else
            Response.Write("Faltan Algunos Datos")
        End If
    End Sub

    Protected Sub cboTipDoc_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboTipDoc.SelectedIndexChanged
        If Val(cboTipDoc.SelectedValue) <> 0 Then
            Dim nPrdCodigo As Integer = 0
            Dim ReqPeriodo As BE_Req_Periodo = New BE_Req_Periodo()
            Dim objBL As BL_Periodo = New BL_Periodo()
            Dim ResPeriodo As BE_Res_Periodo = New BE_Res_Periodo()
            ReqPeriodo.nPrdActividad = 1
            ResPeriodo = objBL.get_PeriodoActual_ByActividad(ReqPeriodo)

            Dim ReqCorrelativo As BE_Req_Documento = New BE_Req_Documento()
            Dim objBLDoc As BL_Documento = New BL_Documento()
            Dim ResCorrelativo As BE_Res_Documento = New BE_Res_Documento()
            ReqCorrelativo.cPerCodigo = Session("cPerCodigo")
            ReqCorrelativo.nPrdCodigo = ResPeriodo.nPrdCodigo
            ReqCorrelativo.nDocTipo = cboTipDoc.SelectedValue
            ResCorrelativo = objBLDoc.getCorrelativoBynDocTipo_nPrdCodigo(ReqCorrelativo)
            Dim numDoc As Integer
            If ResCorrelativo.cNumero <> "" Then
                numDoc = Convert.ToInt16(ResCorrelativo.cNumero)
            Else
                numDoc = 1
            End If
            txtNumDocumento.Text = Format(numDoc, "0000") & "-" & Date.Now.Year.ToString & "/UA"
        Else
            txtNumDocumento.Text = ""
        End If
    End Sub

    Protected Sub btnCrearPersona_Click(sender As Object, e As System.EventArgs) Handles btnCrearPersona.Click
        Dim script As String
        script = "<script Language=JavaScript>window.open('RegPersona.aspx','RegPersona','scrollbars=yes,status=yes,height=350,width=600')</script>"
        Response.Write(script)
    End Sub

    Protected Sub btnConCopia_Click(sender As Object, e As System.EventArgs) Handles btnConCopia.Click
        Dim script As String
        script = "<script Language=JavaScript>window.open('ConCopia.aspx?DocCodigo=" + Session("DocCodReg") + "','Copia','scrollbars=yes,status=yes,height=350,width=550')</script>"
        Response.Write(script)
    End Sub
End Class
