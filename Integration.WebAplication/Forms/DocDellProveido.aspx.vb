
Partial Class Forms_DocDellProveido
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        clsConsultasComunes.Ins_User_From_Login(Session("PerCodigo"))
        If Not Page.IsPostBack Then
            Dim MyTrans As SqlTransaction
            Using cn As New SqlConnection(TramiteDocumentario.MiConexion)
                Dim Reader As SqlDataReader
                Try
                    Dim Clase As New TramiteDocumentario.clsTraDoc
                    Dim Dt As New DataTable
                    Dim Visible As Integer
                    Dim DocCodigo As String
                    Dim nDocTipo As Long


                    Dim i As Integer
                    If cn.State = ConnectionState.Closed Then
                        cn.Open()
                    End If

                    MyTrans = cn.BeginTransaction
                    DocCodigo = (Request.QueryString("CodDocumento"))
                    Visible = Val(Request.QueryString("Visible"))
                    lblDocCodigo.Text = DocCodigo
                    Reader = Clase.Get_Prov_Detalle(DocCodigo, MyTrans, cn)
                    Dt.Load(Reader)
                    lblPerRecibe.Text = Dt.Rows.Item(0).Item(0)
                    lblremitente.Text = Dt.Rows.Item(2).Item(8)
                    If Not Dt.Rows.Item(2).Item(11) Is DBNull.Value Then lblProveido.Text = Dt.Rows.Item(2).Item(11)
                    lbldestino.Text = Dt.Rows.Item(0).Item(8)

                    lblfecha.Text = Dt.Rows.Item(0).Item(3)
                    lblasunto.Text = Dt.Rows.Item(0).Item(4)
                    lbldetalle.Text = Dt.Rows.Item(1).Item(4)
                    lblobservacion.Text = Dt.Rows.Item(2).Item(6)
                    lblUO.Text = Dt.Rows.Item(0).Item(10) 'Clase.objInterface(1006, Val(Rs.Rows.Item(2).Item(9)), MyTrans, cn).Rows.Item(0).Item(4)
                    lblnDocPerEdiTipo.Text = Dt.Rows.Item(0).Item(12)
                    lblNumero.Text = Dt.Rows.Item(0).Item(13)
                    lblItem.Text = Dt.Rows.Item(0).Item(14)
                    nDocTipo = Dt.Rows.Item(0).Item(7)
                    lblTipoDocumento.Text = Clase.objCargarConstante(MyTrans, cn, 1063, Len(nDocTipo.ToString.Trim), Len(nDocTipo.ToString.Trim), nDocTipo, , , ).Rows.Item(0).Item(2)
                    lblFecEmision.Text = Dt.Rows.Item(0).Item(15)
                    Dt = Clase.objPerCopia(DocCodigo, MyTrans, cn)
                    If Dt.Rows.Count > 0 Then
                        For i = 0 To Dt.Rows.Count - 1
                            lblCopias.Text = lblCopias.Text & Dt.Rows.Item(i).Item(0) & ";"
                        Next
                    End If
                    If Visible = 2 Then
                        txtDestino.Visible = False
                        dgNombre2.Visible = False
                        cboInstDestino.Visible = False
                        cboAreaDestino.Visible = False
                        btnGrabar.Visible = False
                    End If
                    Reader.Close()
                Catch ex As Exception
                    Response.Write("<script language 'javascript'> alert('Proceso Incorrecto')</script>")
                    Response.Write("<script Language=JavaScript>window.close()</script>")
                End Try
            End Using
        End If
        btnGrabar.Attributes.Add("onclick", "javascript:if(confirm('Está Seguro de Grabar')== false) return false;")
        btncerrar.Attributes.Add("OnClick", "javascritp:window.opener.location.replace('DocPendientes.aspx');window.close();")
    End Sub

    Protected Sub txtDestino_TextChanged(sender As Object, e As System.EventArgs) Handles txtDestino.TextChanged
        Dim Clase As New TramiteDocumentario.clsTraDoc
        Using cn As New SqlConnection(TramiteDocumentario.MiConexion)
            Dim MyTrans As SqlTransaction
            Dim Rs As New DataTable
            Try
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                Dim PerRelacion As String = "1,2,14"
                MyTrans = cn.BeginTransaction
                Rs = Clase.objBuscarPersona(MyTrans, cn, Clase.DBTilde(txtDestino.Text.Trim), PerRelacion)
                If Rs.Rows.Count > 0 Then
                    dgNombre2.Visible = True
                    dgNombre2.DataSource = Rs.DefaultView
                    dgNombre2.DataBind()
                Else
                    Response.Write("No Hay Registros")
                End If
            Catch x As Exception
                Response.Write(x.Message)
            End Try
        End Using
        Clase = Nothing
    End Sub

    Protected Sub dgNombre2_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles dgNombre2.SelectedIndexChanged
        Dim Campos As String ' los campos a mostrar
        Using cn As New SqlConnection(TramiteDocumentario.MiConexion)
            Dim Clase As New TramiteDocumentario.clsTraDoc
            Dim Rs As New DataTable
            Dim MyTrans As SqlTransaction
            Try
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                MyTrans = cn.BeginTransaction
                txtDestino.Text = dgNombre2.SelectedItem.Cells(2).Text
                lblCodPerDestino.Text = dgNombre2.SelectedItem.Cells(1).Text
                cboInstDestino.DataValueField = "cPerCodigo"
                cboInstDestino.DataTextField = "cPerNombre"
                Campos = "p.cPerNombre,p.cPerCodigo"
                Rs = Clase.objPerJuridica(MyTrans, cn, dgNombre2.SelectedItem.Cells(1).Text, Campos)
                cboInstDestino.Items.Clear()
                cboAreaDestino.Items.Clear()
                cboInstDestino.DataSource = Rs.DefaultView
                cboInstDestino.DataBind()
                cboInstDestino.Items.Insert(0, "Seleccione Universidad")
                btnGrabar.Enabled = True
                dgNombre2.Visible = False
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
        End Using
    End Sub

    Protected Sub cboInstDestino_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboInstDestino.SelectedIndexChanged
        If Val(cboInstDestino.SelectedValue) <> 0 Then
            Dim campos As String
            Using cn As New SqlConnection(TramiteDocumentario.MiConexion)
                Dim Clase As New TramiteDocumentario.clsTraDoc
                Dim Rs As New DataTable
                Dim MyTrans As SqlTransaction
                Try
                    If cn.State = ConnectionState.Closed Then
                        cn.Open()
                    End If
                    MyTrans = cn.BeginTransaction
                    campos = "i.cIntDescripcion,uop.nUniOrgCodigo"
                    Rs = Clase.objPerJuridica(MyTrans, cn, dgNombre2.SelectedItem.Cells(1).Text, campos, 1, cboInstDestino.SelectedValue)
                    cboAreaDestino.DataValueField = "nUniOrgCodigo"
                    cboAreaDestino.DataTextField = "cIntDescripcion"
                    cboAreaDestino.DataSource = Rs.DefaultView
                    cboAreaDestino.DataBind()
                Catch ex As Exception
                    Response.Write(ex.Message)
                End Try
            End Using
        End If
    End Sub

    Protected Sub btnGrabar_Click(sender As Object, e As System.EventArgs) Handles btnGrabar.Click
        If lblPerRecibe.Text <> System.String.Empty And lblCodPerDestino.Text <> System.String.Empty Then
            Using cn As New SqlConnection(TramiteDocumentario.MiConexion)
                Dim MyTrans As SqlTransaction
                Dim Clase As New TramiteDocumentario.clsTraDoc
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                MyTrans = cn.BeginTransaction
                Try
                    'lblPerRecibe.Text.Trim
                    If txtProveido.Text.Length > 250 Then lblError.Text = "Máximo de caracteres 250" : Exit Sub
                    Clase.objModEstDocumento(lblDocCodigo.Text, 6326, lblPerRecibe.Text.Trim, Session("UOCodigo"), Clase.FecActual(MyTrans, cn), MyTrans, cn, txtProveido.Text, lblnDocPerEdiTipo.Text.Trim)
                    Clase.objDocProProveido(lblDocCodigo.Text, lblPerRecibe.Text.Trim, lblCodPerDestino.Text, cboAreaDestino.SelectedValue, 6326, Clase.FecActual(MyTrans, cn), MyTrans, cn)
                    Clase.objTransanccion(406302, Session("PerCodigo"), MyTrans, cn, "Doc:" & lblDocCodigo.Text & " Origen:" & lblPerRecibe.Text.Trim & " Destino:" & lblCodPerDestino.Text & " Obs:" & Left(txtProveido.Text, 100))
                    MyTrans.Commit()
                    Session("Refresh") = True
                    'Response.Write("<SCRIPT>window.opener.document.forms(0).submit();self.close()</script>")
                    Response.Write("<script>window.opener.location.replace('DocPendientes.aspx');window.close();</script>")
                Catch ex As Exception
                    MyTrans.Rollback()
                    lblError.Text = "Proseso no contemplado (Enviar Proveído a la misma persona)"
                End Try
            End Using
        End If
    End Sub

    Protected Sub btnImprimir_Click(sender As Object, e As System.EventArgs) Handles btnImprimir.Click
        Response.Write("<script language = 'javascript'>window.print()</script>")
    End Sub
End Class
