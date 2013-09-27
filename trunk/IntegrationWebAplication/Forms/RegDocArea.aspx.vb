Imports System.Data
Imports System.Data.SqlClient
Imports Integration.BL
Imports Integration.BE.UniOrgPerExt
Imports Integration.BE.Persona
Imports Integration.BE.Documento
Imports Integration.BE.Periodo
Imports Integration.BE.TraDoc

Partial Class Forms_RegDocArea
    Inherits System.Web.UI.Page
    Public Shared Midtb As DataTable
    Dim Midtr As DataRow

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'clsConsultasComunes.Ins_User_From_Login(Session("cPerCodigo"))
        If Not Page.IsPostBack Then
            lblusuario.Text = Session("Nombre")
            lblCodPerRemite.Text = Session("cPerCodigo")
            ' Combo UO ******
            Dim ReqUniOrg As BE_Req_UniOrgPerExt = New BE_Req_UniOrgPerExt()
            Dim BL_ReqUniOrg As BL_UniOrgPerExt = New BL_UniOrgPerExt()

            CboUniOrg(lblCodPerRemite.Text)
            Dependencias(Val(cboUniOrgP.SelectedValue))
            '****************
            '*****Acuerdos****
            If Session("AcuRegistro") = True Then
                pnlAcuerdo.Visible = True
                txtFecAcuerdo.Text = Date.Now.Date
            Else
                pnlAcuerdo.Visible = False
            End If
            '*****************
            Dim ReqTraDoc As BE_Req_TraDoc = New BE_Req_TraDoc()
            Dim ObjTraDoc As BL_TraDoc = New BL_TraDoc()
            Dim RS As DataTable

            ReqTraDoc.iOpcion = 17
            ReqTraDoc.cPerJurCodigo = gPerEmpCodigo.gPerEmpUA
            RS = ObjTraDoc.get_TraDoc_Procesos(ReqTraDoc)

            cboTipDoc.DataValueField = "nConValor"
            cboTipDoc.DataTextField = "cConDescripcion"
            cboTipDoc.DataSource = RS
            cboTipDoc.DataBind()
            cboTipDoc.Items.Insert(0, "Seleccione")
            cboTipDoc.Items(0).Value = 0

            txtFecha.Text = Date.Now.Date
            Get_PerMail()

        End If
        btnGrabar.Attributes.Add("onclick", "javascript:if(confirm('Está Seguro de Grabar')== false) return false;")
        btnDelegar.Attributes.Add("onclick", "javascript:if(confirm('Está Seguro de Delegar a Otra Persona para que revise sus Documentos')== false) return false;")


    End Sub

    Private Function CboUniOrg(ByVal PerCodigo As String) As Integer

        Dim Request As BE_Req_UniOrgPerExt = New BE_Req_UniOrgPerExt()
        Dim objBL As BL_UniOrgPerExt = New BL_UniOrgPerExt()
        Dim ListaUniOrg As New DataTable()
        Request.cPerCodigo = PerCodigo
        ListaUniOrg = objBL.ObtenerUniOrgBycPerCodigo(Request)
        If ListaUniOrg.Rows.Count > 0 Then
            cboUniOrgP.DataTextField = "cIntDescripcion"
            cboUniOrgP.DataValueField = "nUniOrgCodigo"
            cboUniOrgP.DataSource = ListaUniOrg
            cboUniOrgP.DataBind()
        End If
        Return 1
    End Function

    Sub Ocultar(ByVal Valor As Boolean)
        If Valor = True Then
            cboInstDestino.Visible = True
        Else
            cboInstDestino.Visible = False
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

    Protected Sub txtDestino_TextChanged(sender As Object, e As System.EventArgs) Handles txtDestino.TextChanged
        If txtDestino.Text.Trim.Length > 3 Then
            Dim Request As BE_Req_Persona = New BE_Req_Persona()
            Dim objBL As BL_Persona = New BL_Persona()
            Dim Rs As DataTable = New DataTable()
            Dim clase As New clsConfiguraciones
            Request.cPerApellido = clase.DBTilde(txtDestino.Text)
            Request.cPerRelTipo = "1,2,14"
            Rs = objBL.ListaPersonas_BycPerApellido_cPerRelTipo(Request)
            If Rs.Rows.Count > 0 Then
                Ocultar2(False)
                dgNombre2.DataSource = Rs
                dgNombre2.DataBind()
            Else
                Response.Write("No Hay Registros")
                Ocultar2(True)
            End If

            Rs.Clear()

            'Dim Rd As SqlDataReader

            Dim dt As DataTable

            dt = objBL.ListaPersonas_BycPerApellido_cPerRelTipo(Request)
            cboNumero.DataTextField = "Nombre"
            cboNumero.DataValueField = "cPerCodigo"
            cboNumero.DataSource = dt
            cboNumero.DataBind()

            '            Rd = objBL.DRListaPersonas_BycPerCodigo_cPerRelTipo(Request)

            'clase.ddl_Fill(cboNumero, Rd, "cPerCodigo-Nombre", "Numero")

            cboNumero.Items.Insert(0, "Seleccione")
            cboNumero.Items.Item(0).Value = 0

            'Rd.Close()

        End If
    End Sub

    Sub LoadPersona(Optional ByVal cPerCodigo As String = "", Optional ByVal cPerNombre As String = "")
        Dim Clase As New clsConfiguraciones
        If cPerCodigo = String.Empty Then
            Session("pcPerNombre") = dgNombre2.SelectedItem.Cells(2).Text
            Session("pcPerCodigo") = dgNombre2.SelectedItem.Cells(1).Text
        Else
            Session("pcPerCodigo") = cPerCodigo
            Session("pcPerNombre") = cPerNombre
        End If
        txtDestino.Text = Session("pcPerNombre")
        lblCodPerDestino.Text = Session("pcPerCodigo")

        cboInstDestino.DataValueField = "cPerCodigo"
        cboInstDestino.DataTextField = "cPerNombre"

        Dim Request As BE_Req_UniOrgPerExt = New BE_Req_UniOrgPerExt()
        Dim objBL As BL_UniOrgPerExt = New BL_UniOrgPerExt()
        Dim ListaUniOrg As New DataTable
        Request.cPerCodigo = dgNombre2.SelectedItem.Cells(1).Text

        ListaUniOrg = objBL.ObtenerInstitucionesBycPerCodigo(Request)
        If ListaUniOrg.Rows.Count > 0 Then
            cboInstDestino.DataSource = ListaUniOrg
            cboInstDestino.DataBind()

            cboInstDestino.Items.Insert(0, "Seleccione Institucion")
            cboInstDestino.Items(0).Value = 0
            btnGrabar.Enabled = True
            Ocultar2(True)
        End If
    End Sub

    Protected Sub dgNombre2_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles dgNombre2.SelectedIndexChanged
        LoadPersona()
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
                cboAreaDestino.DataValueField = "nUniOrgCodigo"
                cboAreaDestino.DataTextField = "cIntDescripcion"
                cboAreaDestino.DataSource = ListaUniOrg
                cboAreaDestino.DataBind()
            Else
                cboAreaDestino.Items.Clear()
            End If

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
            If cboUO.SelectedValue.Trim.Length > 0 Then
                txtNumDocumento.Text = GeneraNumero(cboUO.SelectedValue, cboTipDoc.SelectedValue)
            Else
                txtNumDocumento.Text = GeneraNumero(cboUniOrgP.SelectedValue, cboTipDoc.SelectedValue)
            End If




            Select Case cboTipDoc.SelectedValue
                Case DocTipo.gnDocMultiple
                    MV.ActiveViewIndex = 0
                    CrearColunas()
                Case DocTipo.gnDocPerRRHH
                    MVRRHH.ActiveViewIndex = 0
                    LoadDatRRHH()

                    MV.ActiveViewIndex = -1
                    ViewState("Tabla") = Nothing
                    gvDestino.DataBind()
                Case Else
                    MV.ActiveViewIndex = -1
                    ViewState("Tabla") = Nothing
                    gvDestino.DataBind()

                    MVRRHH.ActiveViewIndex = -1
            End Select

        Else
            txtNumDocumento.Text = ""
        End If

    End Sub

    Sub LoadDatRRHH()
        Dim ReqTraDoc As BE_Req_TraDoc = New BE_Req_TraDoc()
        Dim ObjTraDoc As BL_TraDoc = New BL_TraDoc()
        Dim RS As DataTable

        ReqTraDoc.iOpcion = 15
        RS = ObjTraDoc.get_TraDoc_Procesos(ReqTraDoc)

        cboRRHHTipo.DataTextField = "cIntNombre"
        cboRRHHTipo.DataValueField = "nIntCodigo"
        cboRRHHTipo.DataSource = RS
        cboRRHHTipo.DataBind()

        RS.Clear()

        ReqTraDoc.iOpcion = 16
        RS = ObjTraDoc.get_TraDoc_Procesos(ReqTraDoc)

        cboRRHHMotivo.DataTextField = "cConDescripcion"
        cboRRHHMotivo.DataValueField = "nConValor"
        cboRRHHMotivo.DataSource = RS
        cboRRHHMotivo.DataBind()

        RS.Clear()

        txtRRHHFecIni.Text = Date.Today
        txtRRHHFecFin.Text = Date.Today

    End Sub

    Sub Limpiar()
        lblCodPerDestino.Text = ""
        txtAsunto.Text = ""
        txtDetalle.Text = ""
        txtObservacion.Text = ""
        cboInstDestino.Items.Clear()
        cboAreaDestino.Items.Clear()
        txtDestino.Text = ""
        btnGrabar.Enabled = False
        btnConCopia.Enabled = False

        gvConCopia.DataSource = Nothing
        gvConCopia.DataBind()
        cboInsCopia.Items.Clear()
        cboAreCopia.Items.Clear()
        lblPerCopia.Text = String.Empty
        lblPerCopCodigo.Text = String.Empty
        mvCopia.ActiveViewIndex = -1
        MVRRHH.ActiveViewIndex = -1

        lblError.Text = String.Empty

        Session("pcPerNombre") = ""
        Session("pcPerCodigo") = ""

        cboTipDoc.SelectedIndex = 0
    End Sub
    Sub EnabledFalse()
        cboTipDoc.Enabled = False
        txtAsunto.Enabled = False
        txtDetalle.Enabled = False
        txtDestino.Enabled = False
        txtObservacion.Enabled = False
        btnGrabar.Enabled = False
        btnNuevo.Enabled = True
    End Sub
    Sub EnabledTrue()
        cboTipDoc.Enabled = True
        txtAsunto.Enabled = True
        txtDetalle.Enabled = True
        txtDestino.Enabled = True
        txtObservacion.Enabled = True
        btnGrabar.Enabled = True
    End Sub

    Protected Sub btnConCopia_Click(sender As Object, e As System.EventArgs) Handles btnConCopia.Click
        Dim script As String
        script = "<script Language=JavaScript>window.open('ConCopia.aspx?DocCodigo=" + Session("DocCodReg") + "','Copia','scrollbars=yes,status=yes,height=350,width=550')</script>"
        Response.Write(script)
    End Sub

    Protected Sub btnNuevo_Click(sender As Object, e As System.EventArgs) Handles btnNuevo.Click
        Call EnabledTrue()
        Call Limpiar()
        Session("NumCopias") = 0
        btnAgregar.Visible = False
        ViewState("Tabla") = Nothing

        gvDestino.DataBind()
    End Sub

    Protected Sub btnDelegar_Click(sender As Object, e As System.EventArgs) Handles btnDelegar.Click
        Dim script As String
        script = "<script Language=JavaScript>window.open('DelegarDocumentos.aspx','Delegar','scrollbars=yes,status=yes,height=350,width=550')</script>"
        Response.Write(script)
    End Sub

    Protected Sub chkDelegado_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkDelegado.CheckedChanged
        If chkDelegado.Checked = True Then
            Dim PerDelCodigo As String = System.String.Empty
            Dim ReqPersona As BE_Req_Persona = New BE_Req_Persona()
            Dim ObjPersona As BL_Persona = New BL_Persona()
            ReqPersona.cPerCodigo = Session("cPerCodigo")
            Dim dt As DataTable = ObjPersona.GetDelegados_BycPerCodigo(ReqPersona)
            If dt.Rows.Count > 1 Then
                cboDelegado.DataTextField = "Delegado"
                cboDelegado.DataValueField = "cPerCodigo"
                cboDelegado.DataSource = dt
                cboDelegado.DataBind()
                cboDelegado.Items.Insert(0, "Seleccione un Nombre")
                cboDelegado.Items(0).Value = 0

                dt.Clear()
            Else
                chkDelegado.Checked = False
            End If
        Else
            lblusuario.Text = Session("Nombre")
            lblCodPerRemite.Text = Session("cPerCodigo")
            CboUniOrg(lblCodPerRemite.Text)
            cboDelegado.DataSource = ""
            cboDelegado.DataBind()
        End If

    End Sub

    Protected Sub btnAgregar_Click(sender As Object, e As System.EventArgs) Handles btnAgregar.Click
        Try
            If Val(cboAreaDestino.SelectedValue) <> 0 Then
                Midtb = CType(ViewState("Tabla"), DataTable)
                Midtr = Midtb.NewRow()
                Midtr("PerApellido") = txtDestino.Text
                Midtr("PerCodigo") = lblCodPerDestino.Text
                Midtr("Area") = cboAreaDestino.SelectedItem.Text
                Midtr("AreCodigo") = cboAreaDestino.SelectedValue
                Midtb.Rows.Add(Midtr)
                gvDestino.DataSource = Midtb
                gvDestino.DataBind()
                txtDestino.Text = String.Empty
                txtDestino.Focus()
            End If
        Catch ex As Exception
            lblError.Text = ex.Message
        End Try
    End Sub

    Sub CrearColunas()
        Midtb = New DataTable
        Midtb.Columns.Add(New DataColumn("PerApellido", GetType(String)))
        Midtb.Columns.Add(New DataColumn("PerCodigo", GetType(String)))
        Midtb.Columns.Add(New DataColumn("Area", GetType(String)))
        Midtb.Columns.Add(New DataColumn("AreCodigo", GetType(String)))
        ViewState("Tabla") = Midtb
    End Sub
    Sub CrearColCopias()
        Midtb = New DataTable
        Midtb.Columns.Add(New DataColumn("cPerApellido", GetType(String)))
        Midtb.Columns.Add(New DataColumn("cPerCodigo", GetType(String)))
        Midtb.Columns.Add(New DataColumn("Area", GetType(String)))
        Midtb.Columns.Add(New DataColumn("AreCodigo", GetType(String)))
        ViewState("Copia") = Midtb
    End Sub

    Protected Sub cboDelegado_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboDelegado.SelectedIndexChanged
        If cboDelegado.SelectedValue <> 0 Then
            Dim Clase As New clsConfiguraciones
            Dim PerDelCodigo As String
            PerDelCodigo = cboDelegado.SelectedValue
            Session("PerDelCodigo") = PerDelCodigo
            Dim ReqPersona As BE_Req_Persona = New BE_Req_Persona()
            Dim ObjPersona As BL_Persona = New BL_Persona

            ReqPersona.cPerCodigo = PerDelCodigo
            Dim MiDtb As DataTable = ObjPersona.ListaPersona_BycPerCodigo(ReqPersona)
            lblusuario.Text = MiDtb.Rows.Item(0).Item(2) & " " & MiDtb.Rows.Item(0).Item(1)
            Session("UOPerDelCodigo") = MiDtb.Rows.Item(0).Item(4)
            lblCodPerRemite.Text = PerDelCodigo
            CboUniOrg(lblCodPerRemite.Text)
            Dependencias(cboUniOrgP.SelectedValue)
            If cboTipDoc.SelectedValue <> 0 Then txtNumDocumento.Text = GeneraNumero(cboUO.SelectedValue, cboTipDoc.SelectedValue)
        End If
    End Sub

    Sub Dependencias(ByVal pnUniOrgCodigo As Long)
        Dim Reader As DataTable

        Dim ReqTraDoc As BE_Req_TraDoc = New BE_Req_TraDoc()
        Dim ObjTraDoc As BL_TraDoc = New BL_TraDoc
        ReqTraDoc.iOpcion = 20
        ReqTraDoc.nUniOrgCodigo = pnUniOrgCodigo

        Reader = ObjTraDoc.get_TraDoc_Procesos(ReqTraDoc)

        cboUO.DataTextField = "cUniOrgNombre"
        cboUO.DataValueField = "nUniOrgCodigo"
        cboUO.DataSource = Reader
        cboUO.DataBind()

    End Sub

    Private Function GeneraNumero(ByVal nUniOrgCodigo As Long, ByVal nDocTipo As Long) As String
        Dim cDocNDoc As String = String.Empty
        Dim Reader As DataTable

        Dim ReqTraDoc As BE_Req_TraDoc = New BE_Req_TraDoc()
        Dim ObjTraDoc As BL_TraDoc = New BL_TraDoc
        ReqTraDoc.iOpcion = 3
        ReqTraDoc.nUniOrgCodigo = nUniOrgCodigo
        ReqTraDoc.nDocTipo = nDocTipo
        Reader = ObjTraDoc.get_TraDoc_Procesos(ReqTraDoc)
        If Reader.Rows(0).Item(0) = "0" Then
            cDocNDoc = String.Empty
            Response.Write("<script language='javascript'>alert('No existe una nomenclatura para su área, comuníquese  con el DTI')</script>")
        Else
            cDocNDoc = Reader.Rows(0).Item(0)
        End If
            Return cDocNDoc
    End Function

    Protected Sub lnkCopia_Click(sender As Object, e As System.EventArgs) Handles lnkCopia.Click
        If mvCopia.ActiveViewIndex = -1 Then
            mvCopia.ActiveViewIndex = 0
            lnkCopia.Text = "Cerrar"

            CrearColCopias()
            txtPerCopia.Focus()
        Else
            mvCopia.ActiveViewIndex = -1
            lnkCopia.Text = "Agregar Copia"
            ViewState("Copia") = Nothing

            gvCopia.DataSource = Nothing
            gvCopia.DataBind()

            lblPerCopia.Text = String.Empty
            lblPerCopCodigo.Text = String.Empty
        End If
    End Sub

    Protected Sub txtPerCopia_TextChanged(sender As Object, e As System.EventArgs) Handles txtPerCopia.TextChanged
        Dim Request As BE_Req_Persona = New BE_Req_Persona()
        Dim objBL As BL_Persona = New BL_Persona()
        Dim Rs As DataTable = New DataTable()
        Dim clase As New clsConfiguraciones
        Request.cPerApellido = clase.DBTilde(txtDestino.Text)
        Request.cPerRelTipo = "1,2,14"
        Rs = objBL.ListaPersonas_BycPerApellido_cPerRelTipo(Request)
        If Rs.Rows.Count > 0 Then
            Ocultar2(False)
            gvCopia.DataSource = Rs.DefaultView
            gvCopia.DataBind()
        Else
            Response.Write("No Hay Registros")
            Ocultar2(True)
        End If

    End Sub


    Protected Sub btnCopAgregar_Click(sender As Object, e As System.EventArgs) Handles btnCopAgregar.Click
        Try
            If Val(cboAreCopia.SelectedValue) <> 0 Then
                Midtb = CType(ViewState("Copia"), DataTable)
                Midtr = Midtb.NewRow()
                Midtr("cPerApellido") = lblPerCopia.Text
                Midtr("cPerCodigo") = lblPerCopCodigo.Text
                Midtr("Area") = cboAreCopia.SelectedItem.Text
                Midtr("AreCodigo") = cboAreCopia.SelectedValue
                Midtb.Rows.Add(Midtr)
                gvConCopia.DataSource = Midtb
                gvConCopia.DataBind()
                lblPerCopia.Text = String.Empty
                lblPerCopCodigo.Text = String.Empty


                gvCopia.DataSource = Nothing
                gvCopia.DataBind()

                cboInsCopia.Items.Clear()
                cboAreCopia.Items.Clear()

                txtPerCopia.Text = String.Empty
                txtPerCopia.Focus()

            End If
        Catch ex As Exception
            lblError.Text = ex.Message
        End Try
    End Sub

    Protected Sub cboNumero_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboNumero.SelectedIndexChanged
        LoadPersona(cboNumero.SelectedValue, cboNumero.SelectedItem.Text)
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As System.EventArgs) Handles btnCancelar.Click
        Session("pcPerNombre") = ""
        Session("pcPerCodigo") = ""
    End Sub

    Protected Sub chkDocRef_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles chkDocRef.SelectedIndexChanged
        Dim chk As New ListItem
        Dim SW As Boolean = False
        For Each chk In chkDocRef.Items
            If SW = True Then chk.Selected = False
            If chk.Selected = True Then
                lblDocRefCodigo.Text = chk.Value
                SW = True
            End If
            If SW = False Then lblDocRefCodigo.Text = String.Empty
        Next
    End Sub

    Protected Sub btnRegMail_Click(sender As Object, e As System.EventArgs) Handles btnRegMail.Click
        mvMail.ActiveViewIndex = 0
        If lblMail.Text <> "No ha Registrado Su Mail" Then txtPerMail.Text = lblMail.Text

    End Sub
    Sub Get_PerMail()
        Dim ReqTraDoc As BE_Req_TraDoc = New BE_Req_TraDoc
        Dim BL_TraDoc As BL_TraDoc = New BL_TraDoc
        Dim dt As New DataTable
        ReqTraDoc.iOpcion = 18
        ReqTraDoc.cPerCodigo = Session("cPerCodigo")
        dt = BL_TraDoc.get_TraDoc_Procesos(ReqTraDoc)

        If dt.Rows.Count > 1 Then
            lblMail.Text = dt.Rows(0).Item("cPerMaiNombre").ToString
            lblMail.ForeColor = Drawing.Color.Black
        End If

        If lblMail.Text = String.Empty Then lblMail.Text = "No ha Registrado Su Mail" : lblMail.ForeColor = Drawing.Color.Red
    End Sub
     
    Protected Sub cboUO_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboUO.SelectedIndexChanged

        txtNumDocumento.Text = GeneraNumero(cboUO.SelectedValue, cboTipDoc.SelectedValue)
    End Sub

    Protected Sub cboUniOrgP_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboUniOrgP.SelectedIndexChanged
        Dependencias(cboUniOrgP.SelectedValue)
        txtNumDocumento.Text = GeneraNumero(cboUniOrgP.SelectedValue, cboTipDoc.SelectedValue)
    End Sub

    Protected Sub btnDocBuscar_Click(sender As Object, e As System.EventArgs) Handles btnDocBuscar.Click
        lblDocRefCodigo.Text = String.Empty
        Dim Reader As DataTable
        Dim ReqTraDoc As BE_Req_TraDoc = New BE_Req_TraDoc()
        Dim ObjTraDoc As BL_TraDoc = New BL_TraDoc
        ReqTraDoc.iOpcion = 5
        ReqTraDoc.cDocNDoc = txtDocReferencia.Text.Trim
        Reader = ObjTraDoc.get_TraDoc_Procesos(ReqTraDoc)

        chkDocRef.DataTextField = "Asunto"
        chkDocRef.DataValueField = "cDocCodigo"
        chkDocRef.DataSource = Reader
        chkDocRef.DataBind()

    End Sub
     
    Protected Sub btnMaiGrabar_Click(sender As Object, e As System.EventArgs) Handles btnMaiGrabar.Click

    End Sub

    Protected Sub btnGrabar_Click(sender As Object, e As System.EventArgs) Handles btnGrabar.Click
        If Val(cboTipDoc.SelectedValue) <> 0 And Val(cboAreaDestino.SelectedValue) <> 0 And txtAsunto.Text <> "" And txtDetalle.Text <> "" And txtNumDocumento.Text <> "" And txtFecha.Text <> "" And lblCodPerRemite.Text <> "" And lblCodPerDestino.Text <> "" Then
            If chkDelegado.Checked = True AndAlso Val(cboDelegado.SelectedValue) = 0 Then lblError.Text = "Seleccione un Delegado" : Exit Sub
            If fleDoc.HasFile Then
                If fleDoc.PostedFile.ContentLength > 4148576 Then lblError.Text = "Archivo debe de ser menor de 4 Megas" : Exit Sub
            End If

            Dim NewCodDoc As String
            Dim FechaActual As String
            Dim PerRelSolicita As Integer
            Dim rs2 As New DataTable
            Dim ArcName As String = String.Empty
            Dim Extension As String = String.Empty
            Dim cFecIni As String
            Dim cFecFin As String

            Dim objBLDoc As New BL_Documento
            Dim Clase As New clsConfiguraciones
            NewCodDoc = Clase.objGeneraCodDoc(objBLDoc.getFechaActual)
            Session("DocCodReg") = NewCodDoc
            FechaActual = objBLDoc.getFechaActual

            Dim ReqDocumento As BE_Req_Documento = New BE_Req_Documento()
            Dim ResDocumento As BE_Res_Documento = New BE_Res_Documento()

            ReqDocumento.cPerCodigo = lblCodPerRemite.Text
            ResDocumento = objBLDoc.getTipoPersona(ReqDocumento)


            If ResDocumento.cPerCodigo <> "" Then
                If Val(ResDocumento.nAdministrativo) > 0 Then
                    PerRelSolicita = 1
                    'ElseIf Val(Rs.Rows.Item(0).Item(2)) > 0 Then
                    'PerRelSolicita = 2
                ElseIf Val(ResDocumento.nAlumno) > 0 Then
                    PerRelSolicita = 3
                Else
                    PerRelSolicita = 4
                End If
            End If


            ' Documentos Multiples
            Dim DocMulCantidad As Integer = 0
            Dim i As Integer = 0
            Dim Codigos(gvDestino.Rows.Count - 1, 1) As String

            Dim Row As GridViewRow
            Dim chk As New CheckBox
            Dim Etiqueta As Object

            If cboTipDoc.SelectedValue = DocTipo.gnDocMultiple Then
                For Each Row In gvDestino.Rows
                    chk = CType(Row.FindControl("chk"), CheckBox)
                    If chk.Checked Then
                        Etiqueta = Row.Cells(1).FindControl("Label1")
                        If Etiqueta IsNot Nothing Then Codigos(i, 0) = CType(Etiqueta, Label).Text
                        Etiqueta = Row.Cells(3).FindControl("Label2")
                        If Etiqueta IsNot Nothing Then Codigos(i, 1) = CType(Etiqueta, Label).Text
                        DocMulCantidad += 1
                        i += 1
                    End If
                Next
            End If


            'Periodo Actual
            Dim ReqPeriodo As BE_Req_Periodo = New BE_Req_Periodo()
            Dim objBL As BL_Periodo = New BL_Periodo()
            Dim ResPeriodo As BE_Res_Periodo = New BE_Res_Periodo()
            ReqPeriodo.nPrdActividad = 1
            ResPeriodo = objBL.get_PeriodoActual_ByActividad(ReqPeriodo)
            Dim PrdActual As Integer
            PrdActual = ResPeriodo.nPrdCodigo

            cFecIni = txtFecha.Text
            cFecFin = txtFecha.Text

            If cboTipDoc.SelectedValue = DocTipo.gnDocPerRRHH Then
                cFecIni = txtRRHHFecIni.Text & " " & cboRRHHHorIni.SelectedValue & ":" & cboRRHHMinIni.SelectedValue
                cFecFin = txtRRHHFecFin.Text & " " & cboRRHHHorFin.SelectedValue & ":" & cboRRHHMinFin.SelectedValue
            End If

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
            ReqDocumento.dFechaIni = cFecIni
            ReqDocumento.dFechaFin = cFecFin
            ReqDocumento.cDocNDoc = txtNumDocumento.Text 
            ReqDocumento.CodUORemite = cboUO.SelectedValue
            ReqDocumento.nDocPerTipo = 4
            ReqDocumento.CodPerRegistra = lblCodPerRemite.Text
            ReqDocumento.nPrdCodigo = PrdActual
            Dim registra As Boolean = False

            If (objBLDoc.setDocumento(ReqDocumento)) Then
                registra = True
            End If


            If cboTipDoc.SelectedValue = DocTipo.gnDocPerRRHH Then
                ReqDocumento.nDocMotivo = cboRRHHMotivo.SelectedValue
                ReqDocumento.nDocMotTipo = cboRRHHTipo.SelectedValue
                registra = objBLDoc.setDocMotivo(ReqDocumento)
            End If

            '*********Guardar Archivo**********
            Dim clsManejador As New clsManejadorDatos

            Dim SW As Boolean = False
            If fleDoc.HasFile Then 'Archivo 1

                Extension = System.IO.Path.GetExtension(fleDoc.FileName)
                ArcName = Replace(Replace(Format(Date.Now, "yyyyMMdd HH:MM:ss"), ":", ""), " ", "") & Extension
                If DocMulCantidad > 0 Then
                    For i = 0 To DocMulCantidad - 1
                        SW = clsManejador.obj_UpFiles(fleDoc, RutDoc & Codigos(i, 0), ArcName)
                    Next
                Else
                    SW = clsManejador.obj_UpFiles(fleDoc, RutDoc & lblCodPerDestino.Text, ArcName)
                End If

                If SW = False Then
                    ReqDocumento.nDocLinNum = 1
                    ReqDocumento.cDocLinUrl = ArcName
                    ReqDocumento.nDocLinTipo = 1
                    ReqDocumento.nDocLinGrupo = 1
                    registra = objBLDoc.setDocLink(ReqDocumento)

                Else
                    lblError.Text = "El Nombre de Archivo #1 ya existe, inténtelo nuevamente"
                    Exit Sub
                End If
            End If

            If fleDocu.HasFile Then 'Archivo 2
                SW = False
                Extension = System.IO.Path.GetExtension(fleDocu.FileName)
                ArcName = Replace(Replace(Format(Date.Now, "yyyyMMdd HH:MM:ss"), ":", ""), " ", "") & "2" & Extension
                If DocMulCantidad > 0 Then
                    For i = 0 To DocMulCantidad - 1
                        SW = clsManejador.obj_UpFiles(fleDocu, RutDoc & Codigos(i, 0), ArcName)
                    Next
                Else
                    SW = clsManejador.obj_UpFiles(fleDocu, RutDoc & lblCodPerDestino.Text, ArcName) ' Replace(fleDoc.FileName, " ", "")
                End If

                If SW = False Then
                    ReqDocumento.nDocLinNum = 2
                    ReqDocumento.cDocLinUrl = ArcName
                    ReqDocumento.nDocLinTipo = 1
                    ReqDocumento.nDocLinGrupo = 1
                    registra = objBLDoc.setDocLink(ReqDocumento)
                Else
                    lblError.Text = "El Nombre de Archivo #2 ya existe, inténtelo nuevamente"
                    Exit Sub
                End If

            End If 
            'DocRef
            If Not lblDocRefCodigo.Text Is String.Empty Then
                ReqDocumento.cDocRefCodigo = lblDocRefCodigo.Text.Trim
                registra = objBLDoc.setDocRef(ReqDocumento)
            End If

            'Acuerdo
            If pnlAcuerdo.Visible = True AndAlso chkAcuerdo.Checked AndAlso txtAcuerdo.Text IsNot String.Empty Then
                ReqDocumento.nDocTipoNum = 2
                ReqDocumento.cDocNDoc = txtAcuerdo.Text.Trim
                registra = objBLDoc.setDocIdentifica(ReqDocumento)

                Dim FecTratamiento As Date = txtFecAcuerdo.Text
                Dim Fecha As String = Format(FecTratamiento, "MM/dd/yyyy")

                ReqDocumento.nEleCodigo = 1
                ReqDocumento.nCarCodigo = 1
                ReqDocumento.cCarObs = "ACUERDO"
                ReqDocumento.nPercent = 0
                ReqDocumento.cPerCodigo = lblCodPerDestino.Text
                ReqDocumento.dDocTraFec = FecTratamiento
                registra = objBLDoc.setDocTratamiento(ReqDocumento)

            ElseIf chkAcuerdo.Checked Then
                lblError.Text = "Faltan Datos para el Acuerdo"
            End If


            'Enviar Mail
            'Dim clsMail As New clsMails
            'Dim Reader As SqlDataReader = clsMail.objMosPerMails(lblCodPerDestino.Text, MyTrans, cn)

            'If Reader.HasRows Then
            '    Reader.Read()

            '    Dim Destino As String = Reader.GetString(0)
            '    Dim Mensaje As String = cboTipDoc.SelectedItem.Text & " Nº:" & txtNumDocumento.Text & vbCrLf & _
            '            "Fecha :" & Space(2) & txtFecha.Text & vbCrLf & _
            '            "De : " & lblusuario.Text & vbCrLf & _
            '            "Para : " & txtDestino.Text & vbCrLf & _
            '            "Asunto : " & txtAsunto.Text & vbCrLf & vbCrLf & _
            '            "Revise El Sistema de Trámite Documentario Para Obtener más detalles"

            '    clsMail.objEnviarMail("seuss@uss.edu.pe", Destino, "Documento Pendiente", Mensaje, "jbarahona@uss.edu.pe", "123654")

            'End If
            'Reader.Close()


            'Grabar Copias
            If mvCopia.ActiveViewIndex = 0 Then
                Dim cPerCodigo As String
                For Each Row In gvConCopia.Rows
                    chk = CType(Row.FindControl("chk"), CheckBox)
                    cPerCodigo = gvConCopia.DataKeys.Item(Row.RowIndex).Values("cPerCodigo")
                    If chk.Checked Then
                        ReqDocumento.nDocPerTipo = 5
                        ReqDocumento.cPerCodigo = cPerCodigo
                        ReqDocumento.nPerRelacion = 1
                        ReqDocumento.nDocTipo = 1

                        registra = objBLDoc.setDocPersona(ReqDocumento)
                    End If
                Next
            End If

            Call EnabledFalse()
            Session("Suma") = 0
            btnAgregar.Visible = False
            ViewState("Tabla") = Nothing
            gvDestino.DataBind()

            Limpiar()
            If registra = True Then
                Response.Write("<script language='javascript'>alert('Su documento fue enviado')</script>")
            Else
                Response.Write("<script language='javascript'>alert('Algunos Datos son Incorrectos')</script>")
            End If

        Else
            Response.Write("Faltan Algunos Datos")
        End If
    End Sub
End Class
