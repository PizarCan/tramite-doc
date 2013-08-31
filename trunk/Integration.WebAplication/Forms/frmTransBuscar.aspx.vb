
Partial Class Forms_frmTransBuscar
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        clsConsultasComunes.Ins_User_From_Login(Session("PerCodigo"))
        If Not Page.IsPostBack Then

            If Session("PerMesaPartes") = True Then
                Using cn As New SqlConnection(MiConexion)
                    Dim MiClase As New clsTraDoc
                    Dim MyTrans As SqlTransaction
                    Dim MiDataTable As DataTable

                    If cn.State = ConnectionState.Closed Then
                        cn.Open()
                    End If
                    MyTrans = cn.BeginTransaction
                    Try
                        MiDataTable = MiClase.objUltDocReg(Session("PerCodigo"), MyTrans, cn)
                        lblUltimoDoc.Text = "Último Documento Registrado: " & MiDataTable.Rows.Item(0).Item(0) & Space(2) & MiDataTable.Rows.Item(0).Item(1)
                        MyTrans.Commit()
                    Catch ex As Exception
                        MyTrans.Rollback()
                        Me.lblUltimoDoc.Text = "No Se Puede Mostrar"
                    End Try
                End Using
            End If
            LoaderCombo()

        End If
    End Sub

    Sub LoaderCombo()
        Dim MiConexion As String = TramiteDocumentario.MiConexion
        Using Cn As New SqlConnection(MiConexion)
            Try
                Cn.Open()
                Dim clsTraDoc As New clsTraDoc
                Dim clsComunes As New clsConsultasComunes
                Dim MyTrans As SqlTransaction = Cn.BeginTransaction
                Dim Rs As SqlDataReader = clsTraDoc.Get_Periodo_Administrativo(MyTrans, Cn)
                cboPeriodo.DataTextField = "cPrdDescripcion"
                cboPeriodo.DataValueField = "nPrdCodigo"
                cboPeriodo.DataSource = Rs
                cboPeriodo.DataBind()
                Rs.Close()

                cboTipDoc.DataValueField = "nConValor"
                cboTipDoc.DataTextField = "cConDescripcion"
                Rs = clsTraDoc.objTipDocumentos(MyTrans, Cn) 'Clase.objCargarConstante(MyTrans, cn, 1063, 4, 1, 8, , , NoMuestra).DefaultView
                cboTipDoc.DataSource = Rs
                cboTipDoc.DataBind()
                Rs.Close()

                Rs = clsComunes.Get_Constante(1005, MyTrans, Cn)
                cboFilMes.DataTextField = "cConDescripcion"
                cboFilMes.DataValueField = "nConValor"
                cboFilMes.DataSource = Rs
                cboFilMes.DataBind()
                Rs.Close()

                cboTipDoc.Items.Insert(0, "Todos")
                cboTipDoc.Items(0).Value = 0

                MyTrans.Commit()
            Catch ex As Exception
                Throw
            End Try
        End Using
    End Sub



    Protected Sub txtPerRemite_TextChanged(sender As Object, e As System.EventArgs) Handles txtPerRemite.TextChanged
        If txtPerRemite.Text.Length > 5 Then
            Using cn As New SqlConnection(MiConexion)
                Dim Clase As New clsTraDoc
                Dim Rs As DataTable
                Dim MyTrans As SqlTransaction
                Try
                    If cn.State = ConnectionState.Closed Then
                        cn.Open()
                    End If
                    MyTrans = cn.BeginTransaction
                    Rs = Clase.objBuscarPersona(MyTrans, cn, Clase.DBTilde(txtPerRemite.Text))
                    If Rs.Rows.Count > 0 Then
                        dgNombre.Visible = True
                        dgNombre.DataSource = Rs.DefaultView
                        dgNombre.DataBind()
                    Else
                        dgNombre.Visible = False
                        Response.Write("No Hay Registros")
                    End If
                Catch x As Exception
                    Response.Write(x.Message)
                End Try
            End Using
        End If
    End Sub

    Protected Sub dgNombre_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles dgNombre.SelectedIndexChanged
        lblPerRemiteCodigo.Text = dgNombre.SelectedItem.Cells(1).Text
        txtPerRemite.Text = dgNombre.SelectedItem.Cells(2).Text
        dgNombre.Visible = False
    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As System.EventArgs) Handles btnBuscar.Click
        Using cn As New SqlConnection(MiConexion)
            Dim clsTraDoc As New clsTraDoc
            Dim MyTrans As SqlTransaction
            Dim Reader As SqlDataReader = Nothing 
            Dim AdmUser As Boolean = False
            Try
                lblError.Text = String.Empty
                lblMessage.Text = String.Empty

                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                MyTrans = cn.BeginTransaction 

                If rbtNumDocumneto.Checked = True And txtAsunto.Text <> "" Then
                    Reader = clsTraDoc.Get_Busca_Doc_Transferencia("", 0, 0, 1, 0, txtAsunto.Text.Trim, 0, "", cboPeriodo.SelectedValue, cboTipDoc.SelectedValue, cboFilMes.SelectedValue, MyTrans, cn, Get_User_AND_Delegado(Session("PerCodigo"), MyTrans, cn))
                ElseIf rbtPerRemite.Checked = True And lblPerRemiteCodigo.Text <> "" Then
                    Reader = clsTraDoc.Get_Busca_Doc_Transferencia(lblPerRemiteCodigo.Text.Trim, 1, 0, 0, 0, "", 0, "", cboPeriodo.SelectedValue, cboTipDoc.SelectedValue, cboFilMes.SelectedValue, MyTrans, cn, Get_User_AND_Delegado(Session("PerCodigo"), MyTrans, cn))
                ElseIf rbtPerDestino.Checked = True And lblPerRemiteCodigo.Text <> "" Then
                    Reader = clsTraDoc.Get_Busca_Doc_Transferencia(lblPerRemiteCodigo.Text.Trim, 0, 1, 0, 0, "", 0, "", cboPeriodo.SelectedValue, cboTipDoc.SelectedValue, cboFilMes.SelectedValue, MyTrans, cn, Get_User_AND_Delegado(Session("PerCodigo"), MyTrans, cn))
                ElseIf rbtAsunto.Checked = True And txtAsunto.Text <> "" Then
                    Reader = clsTraDoc.Get_Busca_Doc_Transferencia("", 0, 0, 0, 0, 0, 1, txtAsunto.Text.Trim, cboPeriodo.SelectedValue, cboTipDoc.SelectedValue, cboFilMes.SelectedValue, MyTrans, cn, Get_User_AND_Delegado(Session("PerCodigo"), MyTrans, cn))
                ElseIf rbtItem.Checked = True And txtAsunto.Text <> "" Then
                    Reader = clsTraDoc.Get_Busca_Doc_Transferencia("", 0, 0, 0, 1, txtAsunto.Text.Trim, 0, "", cboPeriodo.SelectedValue, cboTipDoc.SelectedValue, cboFilMes.SelectedValue, MyTrans, cn, Get_User_AND_Delegado(Session("PerCodigo"), MyTrans, cn))
                End If
                 
                gvConsultas.DataSource = Reader
                gvConsultas.DataBind()

                Reader.Close()

                gvAtriLoader()

                If gvConsultas.Rows.Count = 0 Then
                    lblMessage.Text = "EL N° DE DOCUMENTO BUSCADO NO LE CORRESPONDE A SU AREA"
                End If

            Catch x As Exception 
                Response.Write(x.Message)
            End Try
        End Using
    End Sub

    Sub gvAtriLoader()
        Dim ArcName As String
        Dim ArchName As String
        Dim Row As GridViewRow
        For Each Row In gvConsultas.Rows
            Dim lnkButon As New LinkButton
            Dim imgArchivo As New ImageButton
            Dim imgArch As New ImageButton

            Dim DocTipo As Integer = gvConsultas.DataKeys(Row.RowIndex).Item("nDocTipo")
            ArcName = gvConsultas.DataKeys(Row.RowIndex).Values("Archivo")
            ArchName = gvConsultas.DataKeys(Row.RowIndex).Values("Archiv")

            lnkButon = CType(Row.FindControl("lnkDoc"), LinkButton)
            lnkButon.OnClientClick = "javascript:(abre('ResultadoBusqueda.aspx?DocCodigo=" & gvConsultas.DataKeys(Row.RowIndex).Values("cDocCodigo") & "','Documentos'));"

            imgArchivo = CType(Row.FindControl("imgArchivo"), ImageButton)
            imgArch = CType(Row.FindControl("imgArch"), ImageButton)

            If Not ArcName Is String.Empty Then
                imgArchivo.OnClientClick = "javascript:(abre('frmDonwFile.aspx?ArcRuta=" & RutDescarga & "&ArcName=" & ArcName & "','Documentos'));"
            Else
                imgArchivo.ImageUrl = "~\Imagenes\Stop.gif"
            End If

            If Not ArchName Is String.Empty Then
                imgArch.OnClientClick = "javascript:(abre('frmDonwFile.aspx?ArcRuta=" & RutDescarga & "&ArcName=" & ArchName & "','Documentos'));"
            Else
                imgArch.ImageUrl = "~\Imagenes\Stop.gif"
            End If
        Next
    End Sub


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
End Class
