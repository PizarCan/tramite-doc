Imports System.Data.SqlClient
Imports System.Data
Imports Integration.BL
Imports Integration.Conection
Imports Integration.DAConfiguration
Imports Integration.BE.Login
Imports Integration.BE.UniOrgPerExt
Imports Integration.BE.Constante
Imports Integration.BE.Persona

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
            cboTipDoc.Items.Insert(0, "<Seleccione>")
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
        ListaUniOrg = objBL.ObtenerUniOrgBycPerCodigo(Request)
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
            Dim i As Integer = 0
            For Each ResUniOrg As BE_Res_UniOrgPerExt In ListaUniOrg
                cboInstDestino.Items.Add(i)
                cboInstDestino.Items(i).Text = ResUniOrg.cPernombre
                cboInstDestino.Items(i).Value = ResUniOrg.cPerCodigo
                i = i + 1
            Next
        End If
        cboInstDestino.Items.Insert(0, "Seleccione Institucion")
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
        'If Val(cboTipDoc.SelectedValue) <> 0 AndAlso txtPerRemite.Text <> "" AndAlso Val(cboAreaDestino.SelectedValue) <> 0 AndAlso txtAsunto.Text <> "" AndAlso txtDetalle.Text <> "" AndAlso txtNumDocumento.Text <> "" AndAlso txtFecha.Text <> "" AndAlso lblCodPerDestino.Text.Trim <> "" AndAlso lblCodPerRemite.Text.Trim <> "" AndAlso lblCodPerRegistra.Text.Trim Then
        '    Dim NewCodDoc As String
        '    Dim FechaActual As String
        '    Dim PerRelSolicita As Integer

        '    Using cn As New SqlConnection(MiConexion)
        '        Dim Clase As New clsTraDoc
        '        Dim clsComunes As New clsConsultasComunes
        '        Dim clsInsert As New clsInserciones
        '        Dim MyTrans As SqlTransaction
        '        Dim Rs As DataTable
        '        Dim UORemCodigo As Integer = 1
        '        Dim Reader As SqlDataReader
        '        If cn.State = ConnectionState.Closed Then
        '            cn.Open()
        '        End If
        '        MyTrans = cn.BeginTransaction
        '        Try
        '            'Buscar Existencia del Documento
        '            If Clase.objBusNumDocumento(Trim(txtNumDocumento.Text), cboTipDoc.SelectedValue, MyTrans, cn).Rows.Count > 0 Then
        '                Response.Write("<P style=Color:Red>Ya Existe El Número de Documento</P>")
        '                Exit Sub
        '            End If
        '            NewCodDoc = Clase.objGeneraCodDoc(MyTrans, cn)
        '            Session("DocCodReg") = NewCodDoc
        '            FechaActual = Clase.FecActual(MyTrans, cn)
        '            Rs = Clase.objTipPersona(lblCodPerRemite.Text, MyTrans, cn)
        '            If Rs.Rows.Count > 0 Then
        '                If Val(Rs.Rows.Item(0).Item(1)) > 0 Then
        '                    PerRelSolicita = 1
        '                ElseIf Val(Rs.Rows.Item(0).Item(2)) > 0 Then
        '                    PerRelSolicita = 2
        '                ElseIf Val(Rs.Rows.Item(0).Item(3)) > 0 Then
        '                    PerRelSolicita = 3
        '                Else : PerRelSolicita = 4
        '                End If
        '            Else : PerRelSolicita = 4
        '            End If

        '            Rs = Clase.objMostAdminist(lblCodPerRemite.Text, MyTrans, cn)
        '            If Rs.Rows.Count > 0 Then
        '                UORemCodigo = Rs.Rows.Item(0).Item(4)
        '            Else
        '                Reader = Clase.objMostDocentes(lblCodPerRemite.Text, MyTrans, cn)
        '                If Reader.HasRows Then
        '                    Reader.Read()
        '                    UORemCodigo = Reader.GetInt32(1)
        '                End If
        '                Reader.Close()
        '            End If
        '            Dim DocPerTipo As Integer

        '            DocPerTipo = 8
        '            If Session("MesaPartesArea") = True Then DocPerTipo = 4

        '            'Periodo Actual
        '            Dim PrdActual As Integer
        '            Dim Reader2 As SqlDataReader
        '            Reader2 = clsComunes.ObjPeriodoActual(1, MyTrans, cn)
        '            If Reader2.HasRows Then
        '                Reader2.Read()
        '                PrdActual = Reader2("nPrdCodigo")
        '            End If
        '            Reader2.Close()


        '            Clase.objRecibirDoc(MyTrans, cn, NewCodDoc, FechaActual, txtObservacion.Text, cboTipDoc.SelectedValue, 6318, _
        '            lblCodPerRemite.Text, PerRelSolicita, lblCodPerDestino.Text, cboAreaDestino.SelectedValue, txtAsunto.Text, _
        '            txtDetalle.Text, txtFecha.Text, txtFecha.Text, txtNumDocumento.Text, lblCodPerRegistra.Text, UORemCodigo, , , DocPerTipo, PrdActual)

        '            'DocPeriodo

        '            clsInsert.objInsertDocPeriodo(NewCodDoc, PrdActual, PrdActual, MyTrans, cn)

        '            Clase.objTransanccion(406304, Session("PerCodigo"), MyTrans, cn, "Doc:" & NewCodDoc & "Destino:" & lblCodPerDestino.Text)

        '            'Enviar Mail
        '            Dim clsMail As New clsMails
        '            Reader = clsMail.objMosPerMails(lblCodPerDestino.Text, MyTrans, cn)
        '            If Reader.HasRows Then
        '                Reader.Read()
        '                Dim Destino As String = Reader.GetString(0)
        '                Dim Mensaje As String = ""

        '                Mensaje = cboTipDoc.SelectedItem.Text & " Nº:" & txtNumDocumento.Text & vbCrLf & _
        '                        "Fecha :" & Space(2) & txtFecha.Text & vbCrLf & _
        '                        "De : " & txtPerRemite.Text & vbCrLf & _
        '                        "Para : " & txtDestino.Text & vbCrLf & _
        '                        "Asunto : " & txtAsunto.Text & vbCrLf & vbCrLf & _
        '                        "Revise El Sistema de Trámite Documentario Para Obtener más detalles"

        '                clsMail.objEnviarMail("seuss@uss.edu.pe", Destino, "Documento Pendiente", Mensaje, "jbarahona@uss.edu.pe", "123654")

        '            End If
        '            Reader.Close()
        '            MyTrans.Commit()
        '            Call EnabledFalse()
        '            Session("Suma") = 0

        '            Response.Write("<script language='javascript'>")
        '            Response.Write("alert ('Documento Enviado')")
        '            Response.Write("</script>")
        '        Catch ex As Exception
        '            MyTrans.Rollback()
        '            Response.Write("<script language='javascript'>")
        '            Response.Write("alert ('No Se Completo La Tranzacción')")
        '            Response.Write("</script>")
        '        End Try
        '    End Using
        'Else
        '    Response.Write("Faltan Algunos Datos")
        'End If
    End Sub

    Protected Sub btnImprimir_Click(sender As Object, e As System.EventArgs) Handles btnImprimir.Click

    End Sub

    Protected Sub btnConCopia_Click(sender As Object, e As System.EventArgs) Handles btnConCopia.Click

    End Sub

    Protected Sub cboTipDoc_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboTipDoc.SelectedIndexChanged
        If Val(cboTipDoc.SelectedValue) <> 0 Then
            'Using cn As New SqlConnection(MiConexion)
            '    Dim Clase As New clsTraDoc

            '    Try
            '        If cn.State = ConnectionState.Closed Then
            '            cn.Open()
            '        End If

            '        Dim nPrdCodigo As Integer
            '        Dim Reader As SqlDataReader
            '        Dim clsComunes As New clsConsultasComunes
            '        Dim MyTrans As SqlTransaction = cn.BeginTransaction
            '        Reader = clsComunes.ObjPeriodoActual(1, MyTrans, cn)

            '        If Reader.HasRows Then
            '            Reader.Read()
            '            nPrdCodigo = Reader("nPrdCodigo")
            '        End If
            '        Reader.Close()


            '        txtNumDocumento.Text = Clase.objDocIdentifica(cboTipDoc.SelectedValue, Session("PerCodigo"), nPrdCodigo, MyTrans, cn)

            '        MyTrans.Commit()
            '        Clase = Nothing
            '    Catch ex As SqlException
            '        Response.Write(ex.Message)
            '    End Try
            'End Using
        Else
            txtNumDocumento.Text = ""
        End If
    End Sub
End Class
