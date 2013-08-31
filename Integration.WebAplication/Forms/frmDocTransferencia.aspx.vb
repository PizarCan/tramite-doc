
Partial Class Forms_frmDocTransferencia
    Inherits System.Web.UI.Page

    Protected Sub txtPerOrigen_TextChanged(sender As Object, e As System.EventArgs) Handles txtPerOrigen.TextChanged
        Using cn As New SqlConnection(TramiteDocumentario.MiConexion)
            Dim Clase As New TramiteDocumentario.clsTraDoc
            Dim MyTrans As SqlTransaction
            Dim PerRelacion As String = "1,2,14"
            Dim Rs As DataTable
            Try
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                MyTrans = cn.BeginTransaction

                Rs = Clase.objBuscarPersona(MyTrans, cn, Clase.DBTilde(txtPerOrigen.Text), PerRelacion)
                If Rs.Rows.Count > 0 Then
                    gvPerOrigen.DataSource = Rs.DefaultView
                    gvPerOrigen.DataBind()
                Else
                    Response.Write("No se encontraron coincidencias")
                End If
                gvPerOrigen.Visible = True

                cn.Close()
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
        End Using
        lblPerOriCodigo.Text = String.Empty
    End Sub

    Protected Sub gvPerOrigen_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvPerOrigen.SelectedIndexChanged
        txtPerOrigen.Text = gvPerOrigen.SelectedDataKey.Values("Nombre")
        lblPerOriCodigo.Text = gvPerOrigen.SelectedDataKey.Values("cPerCodigo")

        Dim Rs As DataTable
        Dim clsTraDoc As New TramiteDocumentario.clsTraDoc
        Try

            Rs = clsTraDoc.Get_UniOrgHst_By_cPerCodigo(lblPerOriCodigo.Text.Trim)
            cboOrigen.DataValueField = "nUniOrgCodigo"
            cboOrigen.DataTextField = "cIntDescripcion"
            cboOrigen.DataSource = Rs.DefaultView
            cboOrigen.DataBind()

            gvPerOrigen.DataSource = Nothing
            gvPerOrigen.DataBind()
            gvPerOrigen.Visible = False

        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
     
    Protected Sub txtPerDestino_TextChanged(sender As Object, e As System.EventArgs) Handles txtPerDestino.TextChanged
        Using cn As New SqlConnection(TramiteDocumentario.MiConexion)
            Dim Clase As New TramiteDocumentario.clsTraDoc
            Dim MyTrans As SqlTransaction
            Dim PerRelacion As String = "1,2,14"
            Dim Rs As DataTable
            Try
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                MyTrans = cn.BeginTransaction

                Rs = Clase.objBuscarPersona(MyTrans, cn, Clase.DBTilde(txtPerDestino.Text), PerRelacion)
                If Rs.Rows.Count > 0 Then
                    gvPerDestino.DataSource = Rs.DefaultView
                    gvPerDestino.DataBind()
                Else
                    Response.Write("No se encontraron coincidencias")
                End If
                gvPerDestino.Visible = True

                cn.Close()
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
        End Using
        lblPerDesCodigo.Text = String.Empty
    End Sub
     
    Protected Sub gvPerDestino_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvPerDestino.SelectedIndexChanged
        txtPerDestino.Text = gvPerDestino.SelectedDataKey.Values("Nombre")
        lblPerDesCodigo.Text = gvPerDestino.SelectedDataKey.Values("cPerCodigo")

        Dim Rs As DataTable
        Dim clsTraDoc As New TramiteDocumentario.clsTraDoc
        Try

            Dim campos As String
            campos = "i.cIntDescripcion,uop.nUniOrgCodigo"
            Rs = clsTraDoc.Get_UniOrgHst_By_cPerCodigo(lblPerDesCodigo.Text.Trim)
            cboDestino.DataValueField = "nUniOrgCodigo"
            cboDestino.DataTextField = "cIntDescripcion"
            cboDestino.DataSource = Rs.DefaultView
            cboDestino.DataBind()

        Catch ex As Exception
            Response.Write(ex.Message)
        End Try

        gvPerDestino.DataSource = Nothing
        gvPerDestino.DataBind()
        gvPerDestino.Visible = False
    End Sub

    Protected Sub btnGrabar_Click(sender As Object, e As System.EventArgs) Handles btnGrabar.Click
        Using Cn As New SqlConnection(TramiteDocumentario.MiConexion)
            Cn.Open()
            Dim MyTrans As SqlTransaction = Cn.BeginTransaction
            Dim clsInsert As New clsInserciones
            Dim clsCodigos As New clsGenerarCodigos
            Try
                Dim cDocCodigo = clsCodigos.objGeneraCodDoc(MyTrans, Cn)
                Dim dDocFecha As String = Format(Date.Now, "MM/dd/yyyy HH:mm:ss")
                Dim cDocObs As String = "Transferencia de Documentos TD"
                clsInsert.objInsertDocumento(cDocCodigo, dDocFecha, cDocObs, TramiteDocumentario.DocTipo.gnDocTransferencia, 1, MyTrans, Cn)
                clsInsert.objInsertDocPersona(cDocCodigo, TramiteDocumentario.DocPerTipo.gDocPerTipTransOrigen, lblPerOriCodigo.Text.Trim, 1, 1, MyTrans, Cn)
                clsInsert.objInsertDocPersona(cDocCodigo, TramiteDocumentario.DocPerTipo.gDocPerTipTransDestino, lblPerDesCodigo.Text.Trim, 1, 1, MyTrans, Cn)
                clsInsert.objInsertDocPersona(cDocCodigo, TramiteDocumentario.DocPerTipo.gDocPerTipTransUsuario, Session("PerCodigo"), 1, 1, MyTrans, Cn)

                clsInsert.objInsertDocUniOrg(cDocCodigo, cboOrigen.SelectedValue, TramiteDocumentario.DocPerTipo.gDocPerTipTransOrigen, 1, MyTrans, Cn)
                clsInsert.objInsertDocUniOrg(cDocCodigo, cboDestino.SelectedValue, TramiteDocumentario.DocPerTipo.gDocPerTipTransDestino, 1, MyTrans, Cn)


                MyTrans.Commit()
                Cn.Close()
                btnCargar_Click(sender, e)
            Catch ex As Exception
                MyTrans.Rollback()
                Cn.Close()
                lblError.Text = ex.Message
            End Try
        End Using
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        clsConsultasComunes.Ins_User_From_Login(Session("PerCodigo"))
    End Sub

    Protected Sub btnCargar_Click(sender As Object, e As System.EventArgs) Handles btnCargar.Click
        Try
            Dim clsTraDoc As New TramiteDocumentario.clsTraDoc
            Dim dt As DataTable = clsTraDoc.Get_Per_Tranferencia(lblPerDesCodigo.Text.Trim)
            gvDetalle.DataSource = dt
            gvDetalle.DataBind()
        Catch ex As Exception
            lblError.Text = ex.Message
        End Try
    End Sub
End Class
