Imports Integration.BE.UniOrgPerExt
Imports Integration.BL
Imports System.Data
Imports Integration.BE.Persona
Imports System.Data.SqlClient
Imports Integration.BE.Documento
Imports Integration.BE.Periodo
Imports Integration.BE.TraDoc

Partial Class Forms_RegDocArea
    Inherits System.Web.UI.Page
    Public Shared Midtb As DataTable
    Dim Midtr As DataRow

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'clsConsultasComunes.Ins_User_From_Login(Session("PerCodigo"))
        If Not Page.IsPostBack Then
            lblusuario.Text = Session("Nombre")
            lblCodPerRemite.Text = Session("PerCodigo")
            ' Combo UO ******
            Dim ReqUniOrg As BE_Req_UniOrgPerExt = New BE_Req_UniOrgPerExt()
            Dim BL_ReqUniOrg As BL_UniOrgPerExt = New BL_UniOrgPerExt()

            CboUniOrg(lblCodPerRemite.Text)
            'Dependencias(Val(cboUniOrgP.SelectedValue), MyTrans, cn)
            '****************
            '*****Acuerdos****
            If Session("AcuRegistro") = True Then
                pnlAcuerdo.Visible = True
                txtFecAcuerdo.Text = Date.Now.Date
            Else
                pnlAcuerdo.Visible = False
            End If
            '*****************
            cboTipDoc.DataValueField = "nConValor"
            cboTipDoc.DataTextField = "cConDescripcion"
            'cboTipDoc.DataSource = Clase.Get_Documentos_Habilitados(gPerEmpCodigo.gPerEmpUA, cn, MyTrans)
            cboTipDoc.DataBind()
            cboTipDoc.Items.Insert(0, "Seleccione")
            cboTipDoc.Items(0).Value = 0

            txtFecha.Text = Date.Now.Date
            'Get_PerMail(cn, MyTrans)

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
            cboUO.DataTextField = "cIntDescripcion"
            cboUO.DataValueField = "nUniOrgCodigo"
            cboUO.DataSource = ListaUniOrg
            cboUO.DataBind()
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
            Rs = objBL.ListaPeronas_BycPerApellido_cPerRelTipo(Request)
            If Rs.Rows.Count > 0 Then
                Ocultar2(False)
                dgNombre2.DataSource = Rs
                dgNombre2.DataBind()
            Else
                Response.Write("No Hay Registros")
                Ocultar2(True)
            End If

            Rs.Clear()

            Dim Rd As SqlDataReader

            Rd = objBL.DRListaPeronas_BycPerApellido_cPerRelTipo(Request)

            clase.ddl_Fill(cboNumero, Rd, "cPerCodigo-Nombre", "Numero")
            cboNumero.Items.Insert(0, "Seleccione")
            cboNumero.Items.Item(0).Value = 0

            Rd.Close()

        End If
    End Sub

    Sub LoadPersona(Optional ByVal cPerKey As String = "")
        Dim Key() As String = Split(cPerKey, "-")
        Dim Clase As New clsConfiguraciones
        If cPerKey = String.Empty Then
            Session("pcPerNombre") = dgNombre2.SelectedItem.Cells(2).Text
            Session("pcPerCodigo") = dgNombre2.SelectedItem.Cells(1).Text
        Else
            Session("pcPerCodigo") = Key(0)
            Session("pcPerNombre") = Key(1)
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
            txtNumDocumento.Text = GeneraNumero(cboUO.SelectedValue, cboTipDoc.SelectedValue)


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
            Dim dr As SqlDataReader = ObjPersona.DRListaDelegados_BycPerCodigo(Session("cPerCodigo"))
            If dr.HasRows Then
                cboDelegado.DataTextField = "Delegado"
                cboDelegado.DataValueField = "cPerCodigo"
                cboDelegado.DataSource = dr
                cboDelegado.DataBind()
                cboDelegado.Items.Insert(0, "Seleccione un Nombre")
                cboDelegado.Items(0).Value = 0

                dr.Close()
            Else
                chkDelegado.Checked = False
            End If
        Else
            lblusuario.Text = Session("Nombre")
            lblCodPerRemite.Text = Session("PerCodigo")
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
            'Dependencias(cboUniOrgP.SelectedValue)
            If cboTipDoc.SelectedValue <> 0 Then txtNumDocumento.Text = GeneraNumero(cboUO.SelectedValue, cboTipDoc.SelectedValue)
        End If
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
        If Reader(0) Is DBNull.Value Then
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
        Rs = objBL.ListaPeronas_BycPerApellido_cPerRelTipo(Request)
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
        LoadPersona(cboNumero.SelectedValue)
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
    'Sub Get_PerMail(ByVal Cn As SqlConnection, ByVal MyTrans As SqlTransaction)
    '    Dim clsTraDoc As New clsTraDoc
    '    Dim Reader As SqlDataReader = clsTraDoc.Get_PerMail(Session("PerCodigo"), Cn, MyTrans)
    '    While Reader.Read
    '        lblMail.Text = Reader("cPerMaiNombre")
    '        lblMail.ForeColor = Color.Black
    '    End While
    '    If lblMail.Text = String.Empty Then lblMail.Text = "No ha Registrado Su Mail" : lblMail.ForeColor = Color.Red
    '    Reader.Close()
    '    Reader = Nothing
    'End Sub
     
End Class
