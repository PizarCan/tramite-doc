Imports Integration.BE.TraDoc
Imports Integration.BL
Imports Integration.BE.Constante
Imports Integration.BE.Documento
Imports System.Data
Imports Integration.BE.Persona
Imports Integration.BE.UniOrgPerExt

Partial Class Forms_DocDellProveido
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim Visible As Integer
            Dim DocCodigo As String
            Dim nDocTipo As Long
            Dim i As Integer
            Dim Dt As DataTable
            DocCodigo = (Request.QueryString("CodDocumento"))
            Visible = Val(Request.QueryString("Visible"))
            lblDocCodigo.Text = DocCodigo

            Dim ReqTraDoc As BE_Req_TraDoc = New BE_Req_TraDoc()
            Dim ObjTraDoc As BL_TraDoc = New BL_TraDoc()
            ReqTraDoc.iOpcion = 13
            ReqTraDoc.cDocCodigo = DocCodigo
            Dt = ObjTraDoc.get_TraDoc_Procesos(ReqTraDoc)

            lblPerRecibe.Text = Dt.Rows.Item(0).Item(0)
            lblremitente.Text = Dt.Rows.Item(2).Item(8)
            If Not Dt.Rows.Item(2).Item(11) Is DBNull.Value Then lblProveido.Text = Dt.Rows.Item(2).Item(11)
            lbldestino.Text = Dt.Rows.Item(0).Item(8)

            lblfecha.Text = Dt.Rows.Item(0).Item(3)
            lblasunto.Text = Dt.Rows.Item(0).Item(4)
            lbldetalle.Text = Dt.Rows.Item(1).Item(4)
            lblobservacion.Text = Dt.Rows.Item(2).Item(6)
            lblUO.Text = Dt.Rows.Item(0).Item(10)
            lblnDocPerEdiTipo.Text = Dt.Rows.Item(0).Item(12)
            lblNumero.Text = Dt.Rows.Item(0).Item(13)
            lblItem.Text = Dt.Rows.Item(0).Item(14)
            nDocTipo = Dt.Rows.Item(0).Item(7)

            Dim ReqConst As BE_Req_Constante = New BE_Req_Constante()
            Dim ObjConst As BL_Constante = New BL_Constante()
            Dim Rs As New DataTable
            ReqConst.nConValor = Len(nDocTipo.ToString.Trim)
            ReqConst.ConLeft = Len(nDocTipo.ToString.Trim)
            ReqConst.ConValLeft = nDocTipo
            Rs = ObjConst.ListarConstantes(ReqConst)
            lblTipoDocumento.Text = Rs.Rows(0).Item(1)

            Rs.Clear()

            lblFecEmision.Text = Dt.Rows.Item(0).Item(15)
            Dim ReqDoc As BE_Req_Documento = New BE_Req_Documento()
            Dim ObjDoc As BL_Documento = New BL_Documento()
            ReqDoc.cDocCodigo = DocCodigo
            Rs = ObjDoc.getPerCopias(ReqDoc)
            If Rs.Rows.Count > 0 Then
                For i = 0 To Rs.Rows.Count - 1
                    lblCopias.Text = lblCopias.Text & Rs.Rows.Item(i).Item(0) & ";"
                Next
            End If

            If Visible = 2 Then
                txtDestino.Visible = False
                dgNombre2.Visible = False
                cboInstDestino.Visible = False
                cboAreaDestino.Visible = False
                btnGrabar.Visible = False
            End If
        End If
        btnGrabar.Attributes.Add("onclick", "javascript:if(confirm('Está Seguro de Grabar')== false) return false;")
        btncerrar.Attributes.Add("OnClick", "javascritp:window.opener.location.replace('DocPendientes.aspx');window.close();")
    End Sub

    Protected Sub txtDestino_TextChanged(sender As Object, e As System.EventArgs) Handles txtDestino.TextChanged
        Dim Rs As New DataTable
        Dim PerRelacion As String = "1,2,14"
        Dim ReqPersona As BE_Req_Persona = New BE_Req_Persona()
        Dim ObjPersona As BL_Persona = New BL_Persona()
        ReqPersona.cPerApellido = txtDestino.Text.Trim
        ReqPersona.cPerRelTipo = PerRelacion
        Rs = ObjPersona.ListaPeronas_BycPerApellido_cPerRelTipo(ReqPersona)

        If Rs.Rows.Count > 0 Then
            dgNombre2.Visible = True
            dgNombre2.DataSource = Rs.DefaultView
            dgNombre2.DataBind()
        Else
            Response.Write("No Hay Registros")
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
            cboInstDestino.Items.Insert(0, "Seleccione Institucion")
            cboInstDestino.Items(0).Value = 0
            Dim i As Integer = 1
            For Each ResUniOrg As BE_Res_UniOrgPerExt In ListaUniOrg
                cboInstDestino.Items.Add(i)
                cboInstDestino.Items(i).Text = ResUniOrg.cPernombre
                cboInstDestino.Items(i).Value = ResUniOrg.cPerCodigo
                i = i + 1
            Next
        End If
        btnGrabar.Enabled = True
        dgNombre2.Visible = False
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
        If lblPerRecibe.Text <> System.String.Empty And lblCodPerDestino.Text <> System.String.Empty Then

            If txtProveido.Text.Length > 250 Then lblError.Text = "Máximo de caracteres 250" : Exit Sub
            Dim rpta As Boolean = True

            Dim ReqDoc As BE_Req_Documento = New BE_Req_Documento()
            Dim ObjDoc As BL_Documento = New BL_Documento()

            ReqDoc.cDocCodigo = lblDocCodigo.Text
            ReqDoc.nDocEstado = 6326
            ReqDoc.cPerCodigo = lblPerRecibe.Text.Trim
            ReqDoc.cDocObserv = txtProveido.Text
            ReqDoc.nDocPerTipo = lblnDocPerEdiTipo.Text.Trim
            If ObjDoc.updEstadoDocumento(ReqDoc) Then
                ReqDoc.cPerDestCodigo = lblCodPerDestino.Text
                ReqDoc.nUniOrgCodigo = cboAreaDestino.SelectedValue
                ReqDoc.cDocEstado = "6326"
                If ObjDoc.setDocProProveido(ReqDoc) Then
                    Session("Refresh") = True
                    Response.Write("<script>window.opener.location.replace('DocPendientes.aspx');window.close();</script>")
                Else
                    rpta = False
                End If
            Else
                rpta = False
            End If

            'Clase.objTransanccion(406302, Session("PerCodigo"), MyTrans, cn, "Doc:" & lblDocCodigo.Text & " Origen:" & lblPerRecibe.Text.Trim & " Destino:" & lblCodPerDestino.Text & " Obs:" & Left(txtProveido.Text, 100))
            If rpta = False Then
                lblError.Text = "Proseso no contemplado (Enviar Proveído a la misma persona)"
            End If
        End If
    End Sub

    Protected Sub btnImprimir_Click(sender As Object, e As System.EventArgs) Handles btnImprimir.Click
        Response.Write("<script language = 'javascript'>window.print()</script>")
    End Sub
End Class
