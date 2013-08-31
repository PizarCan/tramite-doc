Imports Integration.BE.UniOrgPerExt
Imports Integration.BL
Imports System.Data

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
        'If txtDestino.Text.Length < 5 Then
        '    Exit Sub
        'End If
        'Using cn As New SqlConnection(MiConexion)
        '    Dim Clase As New clsTraDoc
        '    Dim Genera As New clsGenerarCodigos
        '    Dim MyTrans As SqlTransaction
        '    Dim PerRelacion As String = "1,2,14"
        '    Dim Rs As SqlDataReader
        '    Try
        '        If cn.State = ConnectionState.Closed Then
        '            cn.Open()
        '        End If
        '        MyTrans = cn.BeginTransaction
        '        Rs = Clase.GetBuscarPersona(MyTrans, cn, Clase.DBTilde(txtDestino.Text), PerRelacion)
        '        If Rs.HasRows Then
        '            Ocultar2(False)
        '            dgNombre2.DataSource = Rs
        '            dgNombre2.DataBind()
        '        Else
        '            Response.Write("No Hay Registros")
        '            Ocultar2(True)
        '        End If
        '        Rs.Close()

        '        Rs = Clase.GetBuscarPersona(MyTrans, cn, Clase.DBTilde(txtDestino.Text), PerRelacion)

        '        Genera.ddl_Fill(cboNumero, Rs, "cPerCodigo-Nombre", "Numero")
        '        cboNumero.Items.Insert(0, "Select")
        '        cboNumero.Items.Item(0).Value = 0

        '        Rs.Close()
        '        Rs = Nothing
        '    Catch ex As Exception
        '        Response.Write(ex.Message)
        '    End Try
        'End Using
    End Sub

    Sub LoadPersona(Optional ByVal cPerKey As String = "")
        Dim Campos As String ' los campos a mostrar
        Dim Key() As String = Split(cPerKey, "-")
        'Using cn As New SqlConnection(MiConexion)
        '    Dim Clase As New clsTraDoc
        '    Dim Rs As DataTable
        '    Dim MyTrans As SqlTransaction
        '    Try
        '        If cn.State = ConnectionState.Closed Then
        '            cn.Open()
        '        End If
        '        If cPerKey = String.Empty Then
        '            Session("pcPerNombre") = dgNombre2.SelectedItem.Cells(2).Text
        '            Session("pcPerCodigo") = dgNombre2.SelectedItem.Cells(1).Text
        '        Else
        '            Session("pcPerCodigo") = Key(0)
        '            Session("pcPerNombre") = Key(1)
        '        End If
        '        MyTrans = cn.BeginTransaction
        '        txtDestino.Text = Session("pcPerNombre")
        '        lblCodPerDestino.Text = Session("pcPerCodigo")
        '        cboInstDestino.DataValueField = "cPerCodigo"
        '        cboInstDestino.DataTextField = "cPerNombre"
        '        Campos = "p.cPerNombre,p.cPerCodigo"
        '        Rs = Clase.objPerJuridica(MyTrans, cn, Session("pcPerCodigo"), Campos)
        '        cboInstDestino.Items.Clear()
        '        cboAreaDestino.Items.Clear()
        '        cboInstDestino.DataSource = Rs.DefaultView
        '        cboInstDestino.DataBind()
        '        cboInstDestino.Items.Insert(0, "Seleccione Universidad")
        '        btnGrabar.Enabled = True
        '        Ocultar2(True)
        '    Catch ex As Exception
        '        Response.Write(ex.Message)
        '    End Try
        'End Using
    End Sub

    Protected Sub dgNombre2_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles dgNombre2.SelectedIndexChanged
        LoadPersona()
    End Sub

    Protected Sub cboInstDestino_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboInstDestino.SelectedIndexChanged
        'Using cn As New SqlConnection(MiConexion)
        '    Dim MyTrans As SqlTransaction
        '    Dim Rs As DataTable
        '    Dim Clase As New clsTraDoc
        '    Try
        '        If cn.State = ConnectionState.Closed Then
        '            cn.Open()
        '        End If
        '        MyTrans = cn.BeginTransaction
        '        If Val(cboInstDestino.SelectedValue) <> 0 Then
        '            Dim campos As String
        '            campos = "i.cIntDescripcion,uop.nUniOrgCodigo"
        '            Rs = Clase.objPerJuridica(MyTrans, cn, Session("pcPerCodigo"), campos, 1, cboInstDestino.SelectedValue)
        '            cboAreaDestino.DataValueField = "nUniOrgCodigo"
        '            cboAreaDestino.DataTextField = "cIntDescripcion"
        '            cboAreaDestino.DataSource = Rs.DefaultView
        '            cboAreaDestino.DataBind()
        '        Else
        '            cboAreaDestino.Items.Clear()
        '        End If
        '    Catch ex As Exception
        '        Response.Write(ex.Message)
        '    End Try
        'End Using
    End Sub

    Protected Sub cboTipDoc_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboTipDoc.SelectedIndexChanged
        'Using cn As New SqlConnection(MiConexion)

        '    If cn.State = ConnectionState.Closed Then
        '        cn.Open()
        '    End If

        '    Try
        '        If Val(cboTipDoc.SelectedValue) <> 0 Then

        '            txtNumDocumento.Text = GeneraNumero(cboUO.SelectedValue, cboTipDoc.SelectedValue)


        '            Select Case cboTipDoc.SelectedValue
        '                Case DocTipo.gnDocMultiple
        '                    MV.ActiveViewIndex = 0
        '                    CrearColunas()
        '                Case DocTipo.gnDocPerRRHH
        '                    MVRRHH.ActiveViewIndex = 0
        '                    LoadDatRRHH(cn)

        '                    MV.ActiveViewIndex = -1
        '                    ViewState("Tabla") = Nothing
        '                    gvDestino.DataBind()
        '                Case Else
        '                    MV.ActiveViewIndex = -1
        '                    ViewState("Tabla") = Nothing
        '                    gvDestino.DataBind()

        '                    MVRRHH.ActiveViewIndex = -1
        '            End Select


        '        Else
        '            txtNumDocumento.Text = ""
        '        End If
        '    Catch ex As Exception
        '        Response.Write(ex.Message)
        '    End Try
        '    cn.Close()
        'End Using
    End Sub

    Sub LoadDatRRHH(ByVal Cn As SqlConnection)
        Dim TraDoc As New clsTraDoc
        Dim Reader As SqlDataReader = TraDoc.Get_Dat_RRHH_Permisos(15, Cn)

        cboRRHHTipo.DataTextField = "cIntNombre"
        cboRRHHTipo.DataValueField = "nIntCodigo"
        cboRRHHTipo.DataSource = Reader
        cboRRHHTipo.DataBind()

        Reader.Close()

        Reader = TraDoc.Get_Dat_RRHH_Permisos(16, Cn)

        cboRRHHMotivo.DataTextField = "cConDescripcion"
        cboRRHHMotivo.DataValueField = "nConValor"
        cboRRHHMotivo.DataSource = Reader
        cboRRHHMotivo.DataBind()

        Reader.Close()

        txtRRHHFecIni.Text = Date.Today
        txtRRHHFecFin.Text = Date.Today

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

            'Buscar Existencia de Documento
            Using cn As New SqlConnection(MiConexion)
                Dim Clase As New clsTraDoc
                Dim clsInsert As New clsInserciones
                Dim clsComunes As New clsConsultasComunes
                Dim Rs As DataTable
                Dim MyTrans As SqlTransaction
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                MyTrans = cn.BeginTransaction
                Try
                    'If Clase.objBusNumDocumento(Trim(txtNumDocumento.Text), cboTipDoc.SelectedValue, MyTrans, cn).Rows.Count > 0 Then
                    '    'Response.Write("<P style=Color:Red>Ya Existe El Número de Documento</P>")
                    '    lblError.Text = "Ya Existe el Número de Documento"
                    '    Exit Sub
                    'End If
                    NewCodDoc = Clase.objGeneraCodDoc(MyTrans, cn)
                    Session("DocCodReg") = NewCodDoc
                    FechaActual = Clase.FecActual(MyTrans, cn)
                    Rs = Clase.objTipPersona(Session("PerCodigo"), MyTrans, cn)
                    If Rs.Rows.Count > 0 Then
                        If Val(Rs.Rows.Item(0).Item(1)) > 0 Then
                            PerRelSolicita = 1
                        ElseIf Val(Rs.Rows.Item(0).Item(2)) > 0 Then
                            PerRelSolicita = 2
                        ElseIf Val(Rs.Rows.Item(0).Item(3)) > 0 Then
                            PerRelSolicita = 3
                        Else : PerRelSolicita = 4
                        End If
                    Else : PerRelSolicita = 4
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
                    Dim PrdActual As Integer
                    Dim Reader2 As SqlDataReader
                    Reader2 = clsComunes.ObjPeriodoActual(1, MyTrans, cn)
                    If Reader2.HasRows Then
                        Reader2.Read()
                        PrdActual = Reader2("nPrdCodigo")
                    End If
                    Reader2.Close()

                    cFecIni = txtFecha.Text
                    cFecFin = txtFecha.Text

                    If cboTipDoc.SelectedValue = DocTipo.gnDocPerRRHH Then
                        cFecIni = txtRRHHFecIni.Text & " " & cboRRHHHorIni.SelectedValue & ":" & cboRRHHMinIni.SelectedValue
                        cFecFin = txtRRHHFecFin.Text & " " & cboRRHHHorFin.SelectedValue & ":" & cboRRHHMinFin.SelectedValue
                    End If

                    Clase.objRecibirDoc(MyTrans, cn, NewCodDoc, FechaActual, txtObservacion.Text, cboTipDoc.SelectedValue, 6318, _
                    lblCodPerRemite.Text, PerRelSolicita, lblCodPerDestino.Text, cboAreaDestino.SelectedValue, txtAsunto.Text, _
                    txtDetalle.Text, cFecIni, cFecFin, txtNumDocumento.Text, , cboUO.SelectedValue, Codigos, DocMulCantidad, , PrdActual)

                    If cboTipDoc.SelectedValue = DocTipo.gnDocPerRRHH Then clsInsert.objInsertDocMotivo(NewCodDoc, cboRRHHMotivo.SelectedValue, cboRRHHTipo.SelectedValue, MyTrans, cn)

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
                            SW = clsManejador.obj_UpFiles(fleDoc, RutDoc & lblCodPerDestino.Text, ArcName) ' Replace(fleDoc.FileName, " ", "")
                        End If

                        If SW = False Then
                            'Dim DocLinMax As Integer = clsTraDoc.Get_Max_DocLink(cDocCodigo, 2, MyTrans, cn)
                            clsInsert.objInsertDocLink(NewCodDoc, 1, ArcName, 1, MyTrans, cn, 1)
                        Else
                            lblError.Text = "El Nombre de Archivo #1 ya existe, inténtelo nuevamente"
                            MyTrans.Rollback()
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
                            'Dim DocLinMax As Integer = clsTraDoc.Get_Max_DocLink(cDocCodigo, 2, MyTrans, cn)
                            clsInsert.objInsertDocLink(NewCodDoc, 2, ArcName, 1, MyTrans, cn, 1)
                        Else
                            lblError.Text = "El Nombre de Archivo #2 ya existe, inténtelo nuevamente"
                            MyTrans.Rollback()
                            Exit Sub
                        End If

                    End If
                    '*********************************

                    'DocPeriodo

                    clsInsert.objInsertDocPeriodo(NewCodDoc, PrdActual, PrdActual, MyTrans, cn)

                    'DocRef
                    If Not lblDocRefCodigo.Text Is String.Empty Then clsInsert.objInsertDocRef(NewCodDoc, lblDocRefCodigo.Text.Trim, MyTrans, cn)

                    'Acuerdo
                    If pnlAcuerdo.Visible = True AndAlso chkAcuerdo.Checked AndAlso txtAcuerdo.Text IsNot String.Empty Then
                        clsInsert.objInsertDocIdentifica(NewCodDoc, 2, txtAcuerdo.Text.Trim, MyTrans, cn)
                        Dim FecTratamiento As Date = txtFecAcuerdo.Text
                        Dim Fecha As String = Format(FecTratamiento, "MM/dd/yyyy")


                        clsInsert.objInsertDocTratamiento(NewCodDoc, 1, 1, "ACUERDO", 0, lblCodPerDestino.Text, Fecha, MyTrans, cn)

                    ElseIf chkAcuerdo.Checked Then
                        'MyTrans.Rollback()
                        lblError.Text = "Faltan Datos para el Acuerdo"
                        'Exit Sub
                    End If


                    'Enviar Mail
                    Dim clsMail As New clsMails
                    Dim Reader As SqlDataReader = clsMail.objMosPerMails(lblCodPerDestino.Text, MyTrans, cn)

                    If Reader.HasRows Then
                        Reader.Read()

                        Dim Destino As String = Reader.GetString(0)
                        Dim Mensaje As String = cboTipDoc.SelectedItem.Text & " Nº:" & txtNumDocumento.Text & vbCrLf & _
                                "Fecha :" & Space(2) & txtFecha.Text & vbCrLf & _
                                "De : " & lblusuario.Text & vbCrLf & _
                                "Para : " & txtDestino.Text & vbCrLf & _
                                "Asunto : " & txtAsunto.Text & vbCrLf & vbCrLf & _
                                "Revise El Sistema de Trámite Documentario Para Obtener más detalles"

                        clsMail.objEnviarMail("seuss@uss.edu.pe", Destino, "Documento Pendiente", Mensaje, "jbarahona@uss.edu.pe", "123654")

                    End If
                    Reader.Close()


                    'Grabar Copias
                    If mvCopia.ActiveViewIndex = 0 Then
                        Dim cPerCodigo As String
                        For Each Row In gvConCopia.Rows
                            chk = CType(Row.FindControl("chk"), CheckBox)
                            cPerCodigo = gvConCopia.DataKeys.Item(Row.RowIndex).Values("cPerCodigo")
                            If chk.Checked Then
                                clsInsert.objInsertDocPersona(NewCodDoc, 5, cPerCodigo, 1, 1, MyTrans, cn)
                            End If
                        Next
                    End If


                    MyTrans.Commit()
                    Call EnabledFalse()
                    Session("Suma") = 0
                    btnAgregar.Visible = False
                    ViewState("Tabla") = Nothing
                    gvDestino.DataBind()

                    Limpiar()

                    Response.Write("<script language='javascript'>alert('Su documento fue enviado')</script>")
                Catch ex As Exception
                    MyTrans.Rollback()
                    Response.Write("<script language='javascript'>alert('Algunos Datos son Incorrectos')</script>")
                End Try
            End Using
        Else
            Response.Write("Faltan Algunos Datos")
        End If

    End Sub

    Sub Limpiar()
        lblCodPerDestino.Text = ""
        txtAsunto.Text = ""
        txtDetalle.Text = ""
        'txtreferencia.Text = ""
        'txtFecha.Text = ""
        txtObservacion.Text = ""
        cboInstDestino.Items.Clear()
        cboAreaDestino.Items.Clear()
        txtDestino.Text = ""
        'txtAcuerdo.Text = String.Empty
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
        'btnConCopia.Enabled = True
        btnNuevo.Enabled = True
    End Sub
    Sub EnabledTrue()
        cboTipDoc.Enabled = True
        txtAsunto.Enabled = True
        txtDetalle.Enabled = True
        txtDestino.Enabled = True
        txtObservacion.Enabled = True
        btnGrabar.Enabled = True
        'btnConCopia.Enabled = False
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
        Try
            Using cn As New SqlConnection(MiConexion)
                Dim Clase As New clsTraDoc
                Dim MyTrans As SqlTransaction
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                MyTrans = cn.BeginTransaction
                If chkDelegado.Checked = True Then
                    Dim PerDelCodigo As String = System.String.Empty
                    Dim dr As SqlDataReader = clsTraDoc.objEsDelegado(Session("PerCodigo"), MyTrans, cn)
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
                    CboUniOrg(lblCodPerRemite.Text, MyTrans, cn)
                    cboDelegado.DataSource = ""
                    cboDelegado.DataBind()
                End If
            End Using
        Catch ex As Exception
            chkDelegado.Checked = False
            Response.Write(ex.Message)
        End Try
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
        Try
            If cboDelegado.SelectedValue <> 0 Then
                Using cn As New SqlConnection(MiConexion)
                    Dim Clase As New clsTraDoc
                    Dim MyTrans As SqlTransaction
                    Dim PerDelCodigo As String
                    If cn.State = ConnectionState.Closed Then
                        cn.Open()
                    End If
                    MyTrans = cn.BeginTransaction
                    PerDelCodigo = cboDelegado.SelectedValue
                    Session("PerDelCodigo") = PerDelCodigo


                    Dim MiDtb As DataTable = Clase.DatUsuario(PerDelCodigo, MyTrans, cn)
                    lblusuario.Text = MiDtb.Rows.Item(0).Item(2) & " " & MiDtb.Rows.Item(0).Item(1)
                    Session("UOPerDelCodigo") = MiDtb.Rows.Item(0).Item(4)
                    lblCodPerRemite.Text = PerDelCodigo
                    CboUniOrg(lblCodPerRemite.Text, MyTrans, cn)
                    Dependencias(cboUniOrgP.SelectedValue)
                End Using
                If cboTipDoc.SelectedValue <> 0 Then txtNumDocumento.Text = GeneraNumero(cboUO.SelectedValue, cboTipDoc.SelectedValue)
            End If
        Catch ex As Exception
            chkDelegado.Checked = False
            Response.Write(ex.Message)
        End Try
    End Sub
    Private Function GeneraNumero(ByVal nUniOrgCodigo As Long, ByVal nDocTipo As Long) As String
        Dim cDocNDoc As String = String.Empty
        Using Cn As New SqlConnection(TramiteDocumentario.ModTraDoc.MiConexion)
            Cn.Open()
            Dim MyTrans As SqlTransaction = Cn.BeginTransaction
            Dim clsTraDoc As New clsTraDoc
            Try
                Dim Reader As SqlDataReader = clsTraDoc.Get_DocNum_By_Area(nUniOrgCodigo, nDocTipo, MyTrans, Cn)
                If Reader.HasRows Then
                    Reader.Read()
                    If Reader(0) Is DBNull.Value Then
                        cDocNDoc = String.Empty
                        Response.Write("<script language='javascript'>alert('No existe una nomenclatura para su área, comuníquese  con el DTI')</script>")
                    Else
                        cDocNDoc = Reader(0)
                    End If
                End If
                Reader.Close()
            Catch ex As Exception
                lblError.Text = ex.Message
            End Try
        End Using
        Return cDocNDoc
    End Function

    Protected Sub btnDocBuscar_Click(sender As Object, e As System.EventArgs) Handles btnDocBuscar.Click
        Try
            Using Cn As New SqlConnection(TramiteDocumentario.ModTraDoc.MiConexion)
                Cn.Open()
                Dim MyTrans As SqlTransaction = Cn.BeginTransaction
                Dim Reader As SqlDataReader
                Dim clsTraDoc As New clsTraDoc
                'lblDocReferencia.Text = "Documentos no Encontrado"
                lblDocRefCodigo.Text = String.Empty
                Reader = clsTraDoc.Get_Doc_By_Numero(txtDocReferencia.Text.Trim, MyTrans, Cn)
                'While Reader.Read
                '    lblDocReferencia.Text = Reader("Asunto")
                '    lblDocRefCodigo.Text = Reader("cDocCodigo")
                'End While

                chkDocRef.DataTextField = "Asunto"
                chkDocRef.DataValueField = "cDocCodigo"
                chkDocRef.DataSource = Reader
                chkDocRef.DataBind()

                Reader.Close()
            End Using
        Catch ex As Exception
            lblError.Text = ex.Message
        End Try
    End Sub

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
        Using cn As New SqlConnection(MiConexion)
            Dim Clase As New clsTraDoc
            Dim MyTrans As SqlTransaction
            Dim PerRelacion As String = "1,2,14"
            Dim Rs As DataTable
            Try
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                MyTrans = cn.BeginTransaction

                Rs = Clase.objBuscarPersona(MyTrans, cn, Clase.DBTilde(txtPerCopia.Text), PerRelacion)
                If Rs.Rows.Count > 0 Then
                    Ocultar2(False)
                    gvCopia.DataSource = Rs.DefaultView
                    gvCopia.DataBind()
                Else
                    Response.Write("No Hay Registros")
                    Ocultar2(True)
                End If
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
        End Using
    End Sub

    Protected Sub gvCopia_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvCopia.SelectedIndexChanged
        lblPerCopia.Text = gvCopia.SelectedDataKey.Values("Nombre")
        lblPerCopCodigo.Text = gvCopia.SelectedDataKey.Values("cPerCodigo")

        Dim MiConexion As String = TramiteDocumentario.MiConexion
        Using cn As New SqlConnection(MiConexion)
            Dim Clase As New clsTraDoc
            Dim Rs As DataTable
            Dim MyTrans As SqlTransaction
            Try
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                MyTrans = cn.BeginTransaction


                cboInsCopia.DataValueField = "cPerCodigo"
                cboInsCopia.DataTextField = "cPerNombre"
                Dim Campos As String = "p.cPerNombre,p.cPerCodigo"

                Rs = Clase.objPerJuridica(MyTrans, cn, lblPerCopCodigo.Text, Campos)
                cboAreCopia.Items.Clear()

                cboInsCopia.DataSource = Rs.DefaultView
                cboInsCopia.DataBind()
                cboInsCopia.Items.Insert(0, "Seleccione Universidad")

                gvCopia.DataSource = Nothing
                gvCopia.DataBind()

            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
        End Using
    End Sub

    Protected Sub cboInsCopia_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboInsCopia.SelectedIndexChanged
        Using cn As New SqlConnection(MiConexion)
            Dim MyTrans As SqlTransaction
            Dim Rs As DataTable
            Dim Clase As New clsTraDoc
            Try
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                MyTrans = cn.BeginTransaction
                If Val(cboInsCopia.SelectedValue) <> 0 Then
                    Dim campos As String
                    campos = "i.cIntDescripcion,uop.nUniOrgCodigo"
                    Rs = Clase.objPerJuridica(MyTrans, cn, lblPerCopCodigo.Text, campos, 1, cboInsCopia.SelectedValue)
                    cboAreCopia.DataValueField = "nUniOrgCodigo"
                    cboAreCopia.DataTextField = "cIntDescripcion"
                    cboAreCopia.DataSource = Rs.DefaultView
                    cboAreCopia.DataBind()
                Else
                    cboAreCopia.Items.Clear()
                End If
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
        End Using
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
    Sub Get_PerMail(ByVal Cn As SqlConnection, ByVal MyTrans As SqlTransaction)
        Dim clsTraDoc As New clsTraDoc
        Dim Reader As SqlDataReader = clsTraDoc.Get_PerMail(Session("PerCodigo"), Cn, MyTrans)
        While Reader.Read
            lblMail.Text = Reader("cPerMaiNombre")
            lblMail.ForeColor = Color.Black
        End While
        If lblMail.Text = String.Empty Then lblMail.Text = "No ha Registrado Su Mail" : lblMail.ForeColor = Color.Red
        Reader.Close()
        Reader = Nothing
    End Sub

    Protected Sub btnMaiGrabar_Click(sender As Object, e As System.EventArgs) Handles btnMaiGrabar.Click
        Dim clsInsert As New clsInserciones
        Dim cMaiDescripcion As String = txtPerMail.Text
        Dim cPerCodigo As String = Session("PerCodigo")
        Dim MyTrans As SqlTransaction

        If cPerCodigo = String.Empty AndAlso cMaiDescripcion = String.Empty Then lblError.Text = "Algunos Datos son Incorrectos" : Exit Sub
        If Not (txtPerMail.Text.ToUpper.Contains("@")) Or (txtPerMail.Text = String.Empty) Then lblError.Text = "Mail Incorrecto, debe de ser el institucional" : Exit Sub

        Try
            Using Cn As New SqlConnection(MiConexion)
                Cn.Open()
                MyTrans = Cn.BeginTransaction
                If lblMail.Text = "No ha Registrado Su Mail" Then
                    clsInsert.objInsertPerMail(cPerCodigo, cMaiDescripcion, MyTrans, Cn)
                Else
                    clsInsert.UpDatePerMail(cPerCodigo, lblMail.Text.Trim, txtPerMail.Text, MyTrans, Cn)
                End If
                Get_PerMail(Cn, MyTrans)
                MyTrans.Commit()
                Cn.Close()
            End Using
            lblError.Text = String.Empty
        Catch ex As Exception
            lblError.Text = ex.Message
        End Try
        mvMail.ActiveViewIndex = -1
    End Sub

    Protected Sub cboUniOrgP_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboUniOrgP.SelectedIndexChanged
        Try
            Dependencias(cboUniOrgP.SelectedValue)
            txtNumDocumento.Text = GeneraNumero(cboUO.SelectedValue, cboTipDoc.SelectedValue)
        Catch ex As Exception
            lblError.Text = ex.Message
        End Try
    End Sub

    Protected Sub cboUO_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboUO.SelectedIndexChanged
        Try
            txtNumDocumento.Text = GeneraNumero(cboUO.SelectedValue, cboTipDoc.SelectedValue)
        Catch ex As Exception
            lblError.Text = ex.Message
        End Try
    End Sub
End Class
