
Partial Class Forms_frmAcuAsociar
    Inherits System.Web.UI.Page

    Protected Sub txtBuscar_Click(sender As Object, e As System.EventArgs) Handles txtBuscar.Click
        clsConsultasComunes.Ins_User_From_Login(Session("PerCodigo"))
        Using Cn As New SqlConnection(TramiteDocumentario.MiConexion)
            Try
                Cn.Open()
                Dim MyTrans As SqlTransaction = Cn.BeginTransaction
                Dim clsTraDoc As New TramiteDocumentario.clsTraDoc
                Dim Reader As SqlDataReader = clsTraDoc.Get_Documentos_With_Acuerdos(txtNumDocumento.Text.Trim, MyTrans, Cn)
                gvAcuerdos.DataSource = Reader
                gvAcuerdos.DataBind()
                Reader.Close()
                MyTrans.Commit()
            Catch ex As Exception
                lblError.Text = ex.Message
            End Try
        End Using
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        txtFecAcuerdo.Text = Date.Now.Date
    End Sub

    Public Function With_Acuerdo(ByVal Acuerdo As String) As Boolean
        If Not Acuerdo Is String.Empty Then
            Return True
        Else
            Return False
        End If
    End Function

    Protected Sub txtAsociar_Click(sender As Object, e As System.EventArgs) Handles txtAsociar.Click
        If Not txtAcuerdo.Text Is String.Empty AndAlso gvAcuerdos.Rows.Count > 0 Then
            Using Cn As New SqlConnection(TramiteDocumentario.MiConexion)
                Try
                    Cn.Open()
                    Dim MyTrans As SqlTransaction = Cn.BeginTransaction
                    Dim Row As GridViewRow
                    Dim clsInsert As New clsInserciones
                    Dim cDocCodigo As String = String.Empty
                    Dim cPerCodigo As String = String.Empty

                    For Each Row In gvAcuerdos.Rows
                        Dim chk As New CheckBox
                        chk = CType(Row.FindControl("chkEstado"), CheckBox)
                        If chk.Enabled AndAlso chk.Checked Then
                            cDocCodigo = gvAcuerdos.DataKeys(Row.RowIndex).Values("cDocCodigo")
                            cPerCodigo = gvAcuerdos.DataKeys(Row.RowIndex).Values("cPerCodigo")

                            clsInsert.objInsertDocIdentifica(cDocCodigo, 2, txtAcuerdo.Text.Trim, MyTrans, Cn)
                            Dim FecTratamiento As Date = txtFecAcuerdo.Text
                            Dim Fecha As String = Format(FecTratamiento, "MM/dd/yyyy")

                            clsInsert.objInsertDocTratamiento(cDocCodigo, 1, 1, "", 0, cPerCodigo, Fecha, MyTrans, Cn)

                            MyTrans.Commit()

                            txtBuscar_Click(sender, e)

                        End If
                    Next

                Catch ex As Exception
                    lblError.Text = ex.Message
                End Try
            End Using
        Else
            lblError.Text = "Faltan Datos"
        End If
    End Sub
End Class
