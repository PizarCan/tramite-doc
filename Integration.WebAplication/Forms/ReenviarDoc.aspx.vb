Imports System.Data
Imports Integration.BE.Documento
Imports Integration.BL
Imports Integration.BE.Interface
Imports Integration.BE.Constante
Imports Integration.BE.Persona
Imports Integration.BE.UniOrgPerExt

Partial Class Forms_ReenviarDoc
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim Rs As DataTable
        Dim i As Integer
        Dim DocCodigo As String
        Dim TipDoc As String
        Dim TipDocumento As String
        Dim DocumentoEstado As Integer
        Dim PerDesCodigo As Integer
        Dim PerRemCodigo As String = Session("cPerDelCodigo")
        Dim DocEstado As String = "6324"

        DocCodigo = (Request.QueryString("CodDocumento"))
        lblDocCodigo.Text = DocCodigo
        Session("DocEstModificar") = DocCodigo
        TipDoc = "1,2"
        TipDocumento = (Request.QueryString("TipoDocumento"))
        DocumentoEstado = (Request.QueryString("DocumentoEstado"))
        PerDesCodigo = Val((Request.QueryString("PerDesCodigo")))

        Dim ReqDoc As BE_Req_Documento = New BE_Req_Documento()
        Dim Bl_Doc As BL_Documento = New BL_Documento()

        ReqDoc.cDocCodigo = DocCodigo
        ReqDoc.cDocEstado = DocEstado
        ReqDoc.cTipoDoc = TipDoc
        ReqDoc.nDestEstado = 1
        ReqDoc.cPerCodigo = Session("cPerCodigo")

        If DocumentoEstado = 1 Then
            Rs = Bl_Doc.getDocPendientes(ReqDoc)
        Else
            If Session("PerMesaPartes") = True Then
                PerRemCodigo = PerRemCodigo & "," & (Request.QueryString("PerRemCodigo"))
            End If
            ReqDoc.cPerCodigo = PerRemCodigo
            ReqDoc.cDocPerTipo = 1
            ReqDoc.cPerDestCodigo = PerDesCodigo
        End If

        lblremitente.Text = Rs.Rows.Item(0).Item(2)
        lbldestino.Text = Rs.Rows.Item(0).Item(0)
        lblfecha.Text = Rs.Rows.Item(0).Item(9)
        lblasunto.Text = Rs.Rows.Item(0).Item(6)
        lbldetalle.Text = Rs.Rows.Item(1).Item(6)
        lblobservacion.Text = Rs.Rows.Item(0).Item(7)
        Rs = Bl_Doc.getDocInformacion(ReqDoc)

        Dim ReqInt As BE_Req_Interface = New BE_Req_Interface()
        Dim BL_Int As BL_Interface = New BL_Interface()
        Dim ResInt As BE_Res_Interface = New BE_Res_Interface()
        ReqInt.nIntClase = 1006
        ReqInt.nIntCodigo = Val(Rs.Rows.Item(0).Item(13))
        ResInt = BL_Int.getInterface(ReqInt)

        lblUO.Text = ResInt.cIntDescripcion


        Dim ReqConst As BE_Req_Constante = New BE_Req_Constante()
        Dim ObjConst As BL_Constante = New BL_Constante()

        Rs.Clear()
        ReqConst.nConCodigo = 1063
        ReqConst.nConValor = Len(TipDocumento)
        ReqConst.ConLeft = Len(TipDocumento)
        ReqConst.ConValLeft = TipDocumento
        ReqConst.nConValor = 4
        Rs = ObjConst.ListarConstantes(ReqConst)
        lblTipoDocumento.Text = Rs.Rows(0).Item(1)


        ReqDoc.cDocCodigo = DocCodigo
        Rs = Bl_Doc.getPerCopias(ReqDoc)
        If Rs.Rows.Count > 0 Then
            For i = 0 To Rs.Rows.Count - 1
                lblCopias.Text = lblCopias.Text & Rs.Rows.Item(i).Item(0) & ";"
            Next
        End If
        btnGrabar.Attributes.Add("onclick", "javascript:if(confirm('Está Seguro de Grabar')== false) return false;")
    End Sub

    Protected Sub txtDestino_TextChanged(sender As Object, e As System.EventArgs) Handles txtDestino.TextChanged
        If txtDestino.Text.Trim.Length > 3 Then
            Dim clase As New clsConfiguraciones
            Dim Request As BE_Req_Persona = New BE_Req_Persona()
            Dim objBL As BL_Persona = New BL_Persona()
            Dim Rs As DataTable = New DataTable()
            Request.cPerApellido = clase.DBTilde(txtDestino.Text)
            Request.cPerRelTipo = "1,2,14"
            Rs = objBL.ListaPersonas_BycPerApellido_cPerRelTipo(Request)
            If Rs.Rows.Count > 0 Then
                dgNombre2.DataSource = Rs
                dgNombre2.DataBind()
            Else
                Response.Write("No Hay Registros")
            End If
        End If
    End Sub

    Protected Sub cboInstDestino_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboInstDestino.SelectedIndexChanged
        If Val(cboInstDestino.SelectedValue) <> 0 Then

            Dim Request As BE_Req_UniOrgPerExt = New BE_Req_UniOrgPerExt()
            Dim objBL As BL_UniOrgPerExt = New BL_UniOrgPerExt()
            Dim ListaUniOrg As New DataTable
            Request.cPerCodigo = dgNombre2.SelectedItem.Cells(1).Text
            Request.cUniCodigo = cboInstDestino.SelectedValue
            ListaUniOrg = objBL.ObtenerAreaByPersonaInstitucion(Request)
            If ListaUniOrg.Rows.Count > 0 Then
                cboAreaDestino.DataValueField = "nUniOrgCodigo"
                cboAreaDestino.DataTextField = "cIntDescripcion"
                cboAreaDestino.DataSource = ListaUniOrg
                cboAreaDestino.DataBind()
            End If

        End If
    End Sub

    Protected Sub btncerrar_Click(sender As Object, e As System.EventArgs) Handles btncerrar.Click
        Dim script As String
        script = "<script Language=JavaScript>window.close()</script>"
        Response.Write(script)
    End Sub
End Class
