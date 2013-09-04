Imports Integration.BE.Persona
Imports System.Data
Imports Integration.BL
Imports Integration.DAConfiguration
Imports Integration.BE.TraDoc
Imports Integration.BE.Documento

Partial Class Forms_frmDocTransferencia
    Inherits System.Web.UI.Page

    Protected Sub txtPerOrigen_TextChanged(sender As Object, e As System.EventArgs) Handles txtPerOrigen.TextChanged

        Dim PerRelacion As String = "1,2,14"
        Dim Clase As New clsConfiguraciones
        Dim ReqPer As BE_Req_Persona = New BE_Req_Persona()
        Dim ObjPer As BL_Persona = New BL_Persona()

        Dim Rs As DataTable
        ReqPer.cPerApellido = Clase.DBTilde(txtPerOrigen.Text)
        ReqPer.cPerRelTipo = PerRelacion
        Rs = ObjPer.ListaPeronas_BycPerApellido_cPerRelTipo(ReqPer)
        If Rs.Rows.Count > 0 Then
            gvPerOrigen.DataSource = Rs.DefaultView
            gvPerOrigen.DataBind()
        Else
            Response.Write("No se encontraron coincidencias")
        End If
        gvPerOrigen.Visible = True

        lblPerOriCodigo.Text = String.Empty
    End Sub

    Protected Sub gvPerOrigen_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvPerOrigen.SelectedIndexChanged
        txtPerOrigen.Text = gvPerOrigen.SelectedDataKey.Values("Nombre")
        lblPerOriCodigo.Text = gvPerOrigen.SelectedDataKey.Values("cPerCodigo")

        Dim Rs As New DataTable

        Dim ReqTraDoc As BE_Req_TraDoc = New BE_Req_TraDoc()
        Dim ObjTraDoc As BL_TraDoc = New BL_TraDoc()

        ReqTraDoc.iOpcion = 21
        ReqTraDoc.cPerCodigo = Session(lblPerOriCodigo.Text.Trim)
        Rs = ObjTraDoc.get_TraDoc_Procesos(ReqTraDoc)

        cboOrigen.DataValueField = "nUniOrgCodigo"
        cboOrigen.DataTextField = "cIntDescripcion"
        cboOrigen.DataSource = Rs.DefaultView
        cboOrigen.DataBind()

        gvPerOrigen.DataSource = Nothing
        gvPerOrigen.DataBind()
        gvPerOrigen.Visible = False

    End Sub

    Protected Sub txtPerDestino_TextChanged(sender As Object, e As System.EventArgs) Handles txtPerDestino.TextChanged
        Dim PerRelacion As String = "1,2,14"
        Dim Clase As New clsConfiguraciones
        Dim ReqPer As BE_Req_Persona = New BE_Req_Persona()
        Dim ObjPer As BL_Persona = New BL_Persona()

        Dim Rs As DataTable
        ReqPer.cPerApellido = Clase.DBTilde(txtPerDestino.Text)
        ReqPer.cPerRelTipo = PerRelacion
        Rs = ObjPer.ListaPeronas_BycPerApellido_cPerRelTipo(ReqPer)
        If Rs.Rows.Count > 0 Then
            gvPerDestino.DataSource = Rs.DefaultView
            gvPerDestino.DataBind()
        Else
            Response.Write("No se encontraron coincidencias")
        End If
        gvPerDestino.Visible = True

        lblPerDesCodigo.Text = String.Empty
    End Sub

    Protected Sub gvPerDestino_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvPerDestino.SelectedIndexChanged
        txtPerDestino.Text = gvPerDestino.SelectedDataKey.Values("Nombre")
        lblPerDesCodigo.Text = gvPerDestino.SelectedDataKey.Values("cPerCodigo")


        Dim Rs As New DataTable

        Dim ReqTraDoc As BE_Req_TraDoc = New BE_Req_TraDoc()
        Dim ObjTraDoc As BL_TraDoc = New BL_TraDoc()

        ReqTraDoc.iOpcion = 21
        ReqTraDoc.cPerCodigo = Session(lblPerDesCodigo.Text.Trim)
        Rs = ObjTraDoc.get_TraDoc_Procesos(ReqTraDoc)

        cboDestino.DataValueField = "nUniOrgCodigo"
        cboDestino.DataTextField = "cIntDescripcion"
        cboDestino.DataSource = Rs.DefaultView
        cboDestino.DataBind()


        gvPerDestino.DataSource = Nothing
        gvPerDestino.DataBind()
        gvPerDestino.Visible = False
    End Sub

    Protected Sub btnGrabar_Click(sender As Object, e As System.EventArgs) Handles btnGrabar.Click
        Dim Clase As New clsConfiguraciones
        Dim objBLDoc As BL_Documento = New BL_Documento()
        Dim ReqDoc As BE_Req_Documento = New BE_Req_Documento()
        Dim rpta As Boolean = False

        Dim cDocCodigo = Clase.objGeneraCodDoc(objBLDoc.getFechaActual)
        Dim dDocFecha As String = Format(Date.Now, "MM/dd/yyyy HH:mm:ss")
        Dim cDocObs As String = "Transferencia de Documentos TD"
        ReqDoc.cDocCodigo = cDocCodigo
        ReqDoc.dDocFecha = dDocFecha
        ReqDoc.cDocObserv = cDocObs
        ReqDoc.nDocTipo = DocTipo.gnDocTransferencia
        ReqDoc.nDocEstado = 1
        If Not objBLDoc.setDocumentoTransf(ReqDoc) Then
            ReqDoc.nDocPerTipo = DocPerTipo.gDocPerTipTransOrigen
            ReqDoc.cPerCodigo = lblPerOriCodigo.Text.Trim
            ReqDoc.nPerRelacion = 1
            ReqDoc.nDocTipo = 1
            'clsInsert.objInsertDocPersona(cDocCodigo, TramiteDocumentario.DocPerTipo.gDocPerTipTransOrigen, lblPerOriCodigo.Text.Trim, 1, 1, MyTrans, Cn)
            If Not objBLDoc.setDocPersona(ReqDoc) Then
                ReqDoc.nDocPerTipo = DocPerTipo.gDocPerTipTransDestino
                ReqDoc.cPerCodigo = lblPerDesCodigo.Text.Trim
                ReqDoc.nPerRelacion = 1
                ReqDoc.nDocTipo = 1
                'clsInsert.objInsertDocPersona(cDocCodigo, TramiteDocumentario.DocPerTipo.gDocPerTipTransDestino, lblPerDesCodigo.Text.Trim, 1, 1, MyTrans, Cn)
                If Not objBLDoc.setDocPersona(ReqDoc) Then
                    ReqDoc.nDocPerTipo = DocPerTipo.gDocPerTipTransUsuario
                    ReqDoc.cPerCodigo = Session("cPerCodigo")
                    ReqDoc.nPerRelacion = 1
                    ReqDoc.nDocTipo = 1
                    'clsInsert.objInsertDocPersona(cDocCodigo, TramiteDocumentario.DocPerTipo.gDocPerTipTransUsuario, Session("PerCodigo"), 1, 1, MyTrans, Cn)
                    If Not objBLDoc.setDocPersona(ReqDoc) Then
                        ReqDoc.nUniOrgCodigo = cboOrigen.SelectedValue
                        ReqDoc.nDocUniOrgTipo = DocPerTipo.gDocPerTipTransOrigen
                        ReqDoc.nDocUniOrgEstado = 1
                        'clsInsert.objInsertDocUniOrg(cDocCodigo, cboOrigen.SelectedValue, TramiteDocumentario.DocPerTipo.gDocPerTipTransOrigen, 1, MyTrans, Cn)
                        If Not objBLDoc.setDocUniOrg(ReqDoc) Then
                            ReqDoc.nUniOrgCodigo = cboDestino.SelectedValue
                            ReqDoc.nDocUniOrgTipo = DocPerTipo.gDocPerTipTransDestino
                            ReqDoc.nDocUniOrgEstado = 1
                            'clsInsert.objInsertDocUniOrg(cDocCodigo, cboDestino.SelectedValue, TramiteDocumentario.DocPerTipo.gDocPerTipTransDestino, 1, MyTrans, Cn)
                            If Not objBLDoc.setDocUniOrg(ReqDoc) Then
                                rpta = True
                            End If
                        End If
                    End If
                End If
            End If
        End If

        If Not rpta Then
            lblError.Text = "No se guardo"
        End If

        btnCargar_Click(sender, e)

    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnCargar_Click(sender As Object, e As System.EventArgs) Handles btnCargar.Click

        Dim Rs As New DataTable

        Dim ReqTraDoc As BE_Req_TraDoc = New BE_Req_TraDoc()
        Dim ObjTraDoc As BL_TraDoc = New BL_TraDoc()

        ReqTraDoc.iOpcion = 23
        ReqTraDoc.cPerCodigo = Session(lblPerDesCodigo.Text.Trim)
        Rs = ObjTraDoc.get_TraDoc_Procesos(ReqTraDoc)
         
        gvDetalle.DataSource = Rs
        gvDetalle.DataBind()
    End Sub
End Class
