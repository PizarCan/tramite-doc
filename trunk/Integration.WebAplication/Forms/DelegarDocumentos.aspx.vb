
Partial Class Forms_DelegarDocumentos
    Inherits System.Web.UI.Page

    Protected Sub txtBuscar_TextChanged(sender As Object, e As System.EventArgs) Handles txtBuscar.TextChanged
        Dim Clase As New TramiteDocumentario.clsTraDoc
        Dim Rs As DataTable
        Dim MyTrans As SqlTransaction

        Using cn As New SqlConnection(TramiteDocumentario.MiConexion)
            Try
                cn.Open()
                MyTrans = cn.BeginTransaction
                Rs = Clase.objBuscarPersona(MyTrans, cn, Clase.DBTilde(txtBuscar.Text), 1)
                If Rs.Rows.Count > 0 Then
                    gvPersona.DataSource = Rs.DefaultView
                    gvPersona.DataBind()
                    gvPersona.Visible = True
                Else
                    Response.Write("No Hay Registros")
                End If
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
        End Using
        Clase = Nothing
    End Sub

    Protected Sub btnGrabar_Click(sender As Object, e As System.EventArgs) Handles btnGrabar.Click
        'Grabar Delegado
        If lblPerCodigo.Text <> System.String.Empty And lblPerNombre.Text <> System.String.Empty Then
            Dim MiConexion As String = TramiteDocumentario.MiConexion
            Using cn As New SqlConnection(MiConexion)
                Dim MiClase As New TramiteDocumentario.clsTraDoc
                Dim MyTrans As SqlTransaction
                cn.Open()
                MyTrans = cn.BeginTransaction
                Try
                    TramiteDocumentario.clsTraDoc.objDelegar(Session("PerCodigo"), lblPerCodigo.Text, 1012, MyTrans, cn)
                    MiClase.objTransanccion(406301, Session("PerCodigo"), MyTrans, cn, lblPerCodigo.Text & "Persona ala que delegó")
                    MyTrans.Commit()
                    lblPerNombre.Text = System.String.Empty
                    lblPerCodigo.Text = System.String.Empty
                    LoaderData()
                Catch ex As Exception
                    MyTrans.Rollback()
                    Response.Write(ex.Message.ToString)
                End Try
            End Using
        End If
    End Sub

    Protected Sub gvPersona_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvPersona.SelectedIndexChanged
        lblPerCodigo.Text = gvPersona.SelectedItem.Cells(1).Text
        lblPerNombre.Text = gvPersona.SelectedItem.Cells(2).Text
        gvPersona.Visible = False
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        clsConsultasComunes.Ins_User_From_Login(Session("PerCodigo"))
        If Not Page.IsPostBack Then
            Try
                btnGrabar.Attributes.Add("onclick", "javascript:if(confirm('Está Seguro de Grabar')== false) return false;")
                LoaderData()
            Catch ex As Exception
                lblError.Text = ex.Message
            End Try
        End If
    End Sub
    Sub LoaderData()
        Dim MiConexion As String = TramiteDocumentario.MiConexion
        Using Cn As New SqlConnection(MiConexion)
            Cn.Open()
            Try
                Dim clsTraDoc As New TramiteDocumentario.clsTraDoc
                Dim MyTrans As SqlTransaction = Cn.BeginTransaction
                Dim Reader As SqlDataReader = clsTraDoc.Get_MisDelegados(Session("PerCodigo"), MyTrans, Cn)
                gvDelegado.DataSource = Reader
                gvDelegado.DataBind()
                Reader.Close()
                MyTrans.Commit()
            Catch ex As Exception
                Throw
            End Try
        End Using
    End Sub

    Protected Sub btnCerrar_Click(sender As Object, e As System.EventArgs) Handles btnCerrar.Click
        Response.Write("<script language = 'javascript'>window.close()</script>")
    End Sub

    Protected Sub btnEliminar_Click(sender As Object, e As System.EventArgs) Handles btnEliminar.Click
        Dim MiConexion As String = TramiteDocumentario.MiConexion
        Using Cn As New SqlConnection(MiConexion)
            Cn.Open()
            Try
                Dim clsInsert As New clsInserciones
                Dim MyTrans As SqlTransaction = Cn.BeginTransaction
                Dim Row As GridViewRow
                Dim chk As New CheckBox
                Dim cPerDelCodigo As String = String.Empty
                For Each Row In gvDelegado.Rows
                    chk = CType(Row.FindControl("chkEliminar"), CheckBox)
                    If chk.Checked = True Then
                        cPerDelCodigo = gvDelegado.DataKeys(Row.RowIndex).Values("cPerParCodigo")
                        clsInsert.DeletePerParentesco(Session("PerCodigo"), cPerDelCodigo, Cn, MyTrans)
                    End If
                Next
                MyTrans.Commit()

                LoaderData()
            Catch ex As Exception
                lblError.Text = ex.Message
            End Try
        End Using
    End Sub
    End Sub
End Class
