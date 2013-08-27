Imports System.Data.SqlClient
Imports System.Data
Imports Integration.BL
Imports Integration.Conection
Imports Integration.DAConfiguration
Imports Integration.BE.Documento
Imports Integration.BE.Periodo
Imports Integration.BE.Constante
Imports Integration.BE.Persona


Partial Class Forms_Consultas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("PerMesaPartes") = True Then
                Dim ReqDocumento As BE_Req_Documento = New BE_Req_Documento()
                Dim ObjBL_Doc As BL_Documento = New BL_Documento()
                Dim ResDocumento As BE_Res_Documento = New BE_Res_Documento()
                ReqDocumento.cPerCodigo = Session("cPerCodigo")
                ResDocumento = ObjBL_Doc.getUltimoDocumentoBycPerCodigo(ReqDocumento)
                If ResDocumento.cDocNDoc <> "" Then
                    Me.lblUltimoDoc.Text = "Último Documento Registrado: " & ResDocumento.cDocNDoc & Space(2) & ResDocumento.dDocFecha
                Else
                    Me.lblUltimoDoc.Text = "No Se Puede Mostrar"
                End If
            End If
            LoaderCombo()
        End If
    End Sub

    Sub LoaderCombo()
        Dim ReqPeriodo As BE_Req_Periodo = New BE_Req_Periodo()
        Dim BLPeriodo As BL_Periodo = New BL_Periodo()
        Dim Rs As DataTable = New DataTable

        ReqPeriodo.nPrdActividad = 1
        Rs = BLPeriodo.GetPeriodosByActividad(ReqPeriodo)
        If Rs.Rows.Count > 0 Then
            cboPeriodo.DataTextField = "cPrdDescripcion"
            cboPeriodo.DataValueField = "cPrdDescripcion"
            cboPeriodo.DataSource = Rs
            cboPeriodo.DataBind()
        End If
        Rs.Clear()


        Dim Request As BE_Req_Constante = New BE_Req_Constante()
        Dim objBL As BL_Constante = New BL_Constante()
        Dim ListaDocumentos As New List(Of BE_Res_Constante)
        Request.nConCodigo = 1063
        Request.cConValor = "8100,8600,8700,8800,8102, 8803, 8804, 8805, 8004"
        ListaDocumentos = objBL.Get_ConstantesBynConValor(Request)
        If ListaDocumentos.Count > 0 Then
            cboTipDoc.Items.Insert(0, "Todos")
            cboTipDoc.Items(0).Value = 0
            Dim i As Integer = 1
            For Each ResDocumentos As BE_Res_Constante In ListaDocumentos
                cboTipDoc.Items.Add(i)
                cboTipDoc.Items(i).Text = ResDocumentos.cConDescripcion
                cboTipDoc.Items(i).Value = ResDocumentos.nConValor
                i = i + 1
            Next
        End If

        Request.nConCodigo = 1005
        Request.cConValor = "ALL"
        Dim ListaConstante As New List(Of BE_Res_Constante)
        ListaConstante = objBL.Get_ConstantesBynConValor(Request)
        If ListaConstante.Count > 0 Then
            Dim i As Integer = 0
            For Each ResDocumentos As BE_Res_Constante In ListaConstante
                cboFilMes.Items.Add(i)
                cboFilMes.Items(i).Text = ResDocumentos.cConDescripcion
                cboFilMes.Items(i).Value = ResDocumentos.nConValor
                i = i + 1
            Next
        End If

    End Sub

    Protected Sub txtPerRemite_TextChanged(sender As Object, e As System.EventArgs) Handles txtPerRemite.TextChanged
        If txtPerRemite.Text.Length > 5 Then
            Dim Clase As New clsConfiguration
            Dim Request As BE_Req_Persona = New BE_Req_Persona()
            Dim objBL As BL_Persona = New BL_Persona()
            Dim Rs As DataTable = New DataTable()
            Request.cPerApellido = Clase.DBTilde(txtPerRemite.Text)
            Rs = objBL.ListaPeronas_BycPerApellido(Request)
            If Rs.Rows.Count > 0 Then
                dgNombre.Visible = True
                dgNombre.DataSource = Rs
                dgNombre.DataBind()
            Else
                Response.Write("No Hay Registros")
            End If
        End If
    End Sub

    Protected Sub dgNombre_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles dgNombre.SelectedIndexChanged
        lblPerRemiteCodigo.Text = dgNombre.SelectedItem.Cells(1).Text
        txtPerRemite.Text = dgNombre.SelectedItem.Cells(2).Text
        dgNombre.Visible = False
    End Sub

    'Sub gvAtriLoader()
    '    Dim ArcName As String
    '    Dim ArchName As String
    '    Dim Row As GridViewRow
    '    For Each Row In gvConsultas.Rows
    '        Dim lnkButon As New LinkButton
    '        Dim imgArchivo As New ImageButton
    '        Dim imgArch As New ImageButton

    '        Dim DocTipo As Integer = gvConsultas.DataKeys(Row.RowIndex).Item("nDocTipo")
    '        ArcName = gvConsultas.DataKeys(Row.RowIndex).Values("Archivo")
    '        ArchName = gvConsultas.DataKeys(Row.RowIndex).Values("Archiv")

    '        lnkButon = CType(Row.FindControl("lnkDoc"), LinkButton)
    '        lnkButon.OnClientClick = "javascript:(abre('ResultadoBusqueda.aspx?DocCodigo=" & gvConsultas.DataKeys(Row.RowIndex).Values("cDocCodigo") & "','Documentos'));"

    '        imgArchivo = CType(Row.FindControl("imgArchivo"), ImageButton)
    '        imgArch = CType(Row.FindControl("imgArch"), ImageButton)

    '        If Not ArcName Is String.Empty Then
    '            imgArchivo.OnClientClick = "javascript:(abre('frmDonwFile.aspx?ArcRuta=" & RutDescarga & "&ArcName=" & ArcName & "','Documentos'));"
    '        Else
    '            imgArchivo.ImageUrl = "~\Imagenes\Stop.gif"
    '        End If

    '        If Not ArchName Is String.Empty Then
    '            imgArch.OnClientClick = "javascript:(abre('frmDonwFile.aspx?ArcRuta=" & RutDescarga & "&ArcName=" & ArchName & "','Documentos'));"
    '        Else
    '            imgArch.ImageUrl = "~\Imagenes\Stop.gif"
    '        End If
    '    Next
    'End Sub
    Protected Sub dgBuscar_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles dgBuscar.SelectedIndexChanged
        Dim script As String
        Dim DocCodigo As String
        DocCodigo = dgBuscar.SelectedItem.Cells(6).Text
        script = "<script Language=JavaScript>window.open('ResultadoBusqueda.aspx?DocCodigo=" + DocCodigo + "','Detalle','scrollbars=yes,status=yes,height=550,width=660')</script>"
        Response.Write(script)
    End Sub

    Protected Sub btnImprimir_Click(sender As Object, e As System.EventArgs) Handles btnImprimir.Click
        Dim cPerCodigo As String = lblPerRemiteCodigo.Text.Trim
        Dim nRepTipo As Integer = 2
        Dim nPrdCodigo As Long = cboPeriodo.SelectedValue
        Dim nFilTipo As Integer = 0
        If rbtPerRemite.Checked Then nFilTipo = 1

        'Dim cRepComments As String = lblArea.Text
        Response.Write("<script language='javascript'>")
        Response.Write("window.open('Report/frmPEaDReport.aspx?nRepTipo=" & nRepTipo & "&cPerCodigo=" & cPerCodigo & "&nPerRemFiltro=" & nFilTipo & "&nPerRecFiltro=" & IIf(nFilTipo = 0, 1, 0) & "&nPrdCodigo=" & nPrdCodigo & "','Documentos_Diarios')")
        Response.Write("</script>")
    End Sub


    'Public Function Get_User_AND_Delegado(ByVal cPerCodigo As String, ByVal MyTrans As SqlTransaction, ByVal Cn As SqlConnection)
    '    Dim cPerDelCodigo As String = String.Empty
    '    Try
    '        Dim dr As SqlDataReader = clsTraDoc.objEsDelegado(cPerCodigo, MyTrans, Cn)

    '        While dr.Read
    '            cPerDelCodigo &= dr.GetString(0) & ","
    '        End While

    '        dr.Close()

    '        If cPerDelCodigo <> System.String.Empty Then
    '            cPerDelCodigo &= cPerCodigo
    '        Else
    '            cPerDelCodigo = Session("PerCodigo")
    '        End If
    '        Session("cPerDelCodigo") = cPerDelCodigo
    '    Catch ex As Exception
    '        Throw
    '    End Try

    '    Return cPerDelCodigo
    'End Function

    Protected Sub btnBuscar_Click(sender As Object, e As System.EventArgs) Handles btnBuscar.Click
        'Using cn As New SqlConnection(MiConexion)
        '    Dim clsTraDoc As New clsTraDoc
        '    Dim MyTrans As SqlTransaction
        '    Dim Reader As SqlDataReader = Nothing
        '    'Dim Dt As New DataTable
        '    Dim AdmUser As Boolean = False
        '    Try
        '        lblError.Text = String.Empty
        '        lblMessage.Text = String.Empty

        '        If cn.State = ConnectionState.Closed Then
        '            cn.Open()
        '        End If
        '        MyTrans = cn.BeginTransaction

        '        If rbtNumDocumneto.Checked = True And txtAsunto.Text <> "" Then
        '            Reader = clsTraDoc.Get_Busca_Doc_Whit_Filtro("", 0, 0, 1, 0, txtAsunto.Text.Trim, 0, "", cboPeriodo.SelectedValue, cboTipDoc.SelectedValue, cboFilMes.SelectedValue, MyTrans, cn, Get_User_AND_Delegado(Session("PerCodigo"), MyTrans, cn))
        '        ElseIf rbtPerRemite.Checked = True And lblPerRemiteCodigo.Text <> "" Then
        '            Reader = clsTraDoc.Get_Busca_Doc_Whit_Filtro(lblPerRemiteCodigo.Text.Trim, 1, 0, 0, 0, "", 0, "", cboPeriodo.SelectedValue, cboTipDoc.SelectedValue, cboFilMes.SelectedValue, MyTrans, cn, Get_User_AND_Delegado(Session("PerCodigo"), MyTrans, cn))
        '        ElseIf rbtPerDestino.Checked = True And lblPerRemiteCodigo.Text <> "" Then
        '            Reader = clsTraDoc.Get_Busca_Doc_Whit_Filtro(lblPerRemiteCodigo.Text.Trim, 0, 1, 0, 0, "", 0, "", cboPeriodo.SelectedValue, cboTipDoc.SelectedValue, cboFilMes.SelectedValue, MyTrans, cn, Get_User_AND_Delegado(Session("PerCodigo"), MyTrans, cn))
        '        ElseIf rbtAsunto.Checked = True And txtAsunto.Text <> "" Then
        '            Reader = clsTraDoc.Get_Busca_Doc_Whit_Filtro("", 0, 0, 0, 0, 0, 1, txtAsunto.Text.Trim, cboPeriodo.SelectedValue, cboTipDoc.SelectedValue, cboFilMes.SelectedValue, MyTrans, cn, Get_User_AND_Delegado(Session("PerCodigo"), MyTrans, cn))
        '        ElseIf rbtItem.Checked = True And txtAsunto.Text <> "" Then
        '            Reader = clsTraDoc.Get_Busca_Doc_Whit_Filtro("", 0, 0, 0, 1, txtAsunto.Text.Trim, 0, "", cboPeriodo.SelectedValue, cboTipDoc.SelectedValue, cboFilMes.SelectedValue, MyTrans, cn, Get_User_AND_Delegado(Session("PerCodigo"), MyTrans, cn))
        '        End If

        '        gvConsultas.DataSource = Reader
        '        gvConsultas.DataBind()

        '        Reader.Close()

        '        gvAtriLoader()

        '        If gvConsultas.Rows.Count = 0 Then
        '            lblMessage.Text = "EL N° DE DOCUMENTO BUSCADO NO LE CORRESPONDE A SU AREA"
        '        End If

        '    Catch x As Exception
        '        'Response.Write("<script language 'javascript'> alert ('" + x + "')</script>")
        '        Response.Write(x.Message)
        '    End Try
        'End Using
    End Sub
End Class
