Imports System.Data
Imports Integration.BE.Documento
Imports Integration.BL
Imports Integration.BE.Interface
Imports Integration.BE.Constante

Partial Class Forms_DetalleDocumento
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            Dim DocCodigo As String
            Dim TipDoc As String
            Dim TipDocumento As String
            Dim DocumentoEstado As Integer
            Dim CodDestino As String
            Dim DocEstado As String = "6318,6319,6325"

            Dim Rs As DataTable
            Dim i As Integer
            Dim PerCodigo As String = Session("cPerCodigo")
            Dim cPerCopCodigo As String = (Request.QueryString("cPerCopCodigo"))
            DocCodigo = (Request.QueryString("CodDocumento"))
            Session("DocEstModificar") = DocCodigo
            TipDoc = "1,2"
            TipDocumento = (Request.QueryString("TipoDocumento"))
            DocumentoEstado = (Request.QueryString("DocumentoEstado"))
            CodDestino = (Request.QueryString("CodDestino"))
            If Session("PerDelCodigo") <> System.String.Empty Then
                PerCodigo += "','" & Session("PerDelCodigo")
            End If
            Dim ReqDoc As BE_Req_Documento = New BE_Req_Documento()
            ReqDoc.cPerCodigo = PerCodigo
            Dim ObjDoc As BL_Documento = New BL_Documento()

            If DocumentoEstado = 1 Then
                ReqDoc.cPerCodigo = PerCodigo
                ReqDoc.cDocConTipo = TipDoc
                ReqDoc.cDocEstado = DocEstado
                ReqDoc.nDestEstado = 1
                ReqDoc.cDocCodigo = DocCodigo
                Rs = ObjDoc.getDocPendientes(ReqDoc)
            Else
                DocEstado = "6318,6319, 6320, 6321, 6322, 6323, 6324, 6325,6326, 6328"
                ReqDoc.cPerCodigo = cPerCopCodigo
                ReqDoc.cDocEstado = DocEstado
                ReqDoc.cDocConTipo = TipDoc
                ReqDoc.cDocCodigo = DocCodigo
                ReqDoc.cDocPerTipo = "5"
                ReqDoc.cPerDestCodigo = CodDestino
                Rs = ObjDoc.getDocInformacion(ReqDoc)
            End If
            If Rs.Rows.Count > 0 Then



                lblremitente.Text = Rs.Rows.Item(0).Item(2)
                lbldestino.Text = Rs.Rows.Item(0).Item(0)
                lblfecha.Text = Rs.Rows.Item(0).Item(9)
                lblasunto.Text = Rs.Rows.Item(0).Item(6)
                lbldetalle.Text = Rs.Rows.Item(1).Item(6)
                lblobservacion.Text = Rs.Rows.Item(0).Item(7)
                lblDocNumero.Text = Rs.Rows.Item(0).Item(10)
                Dim ReqInt As BE_Req_Interface = New BE_Req_Interface()
                Dim ObjInt As BL_Interface = New BL_Interface
                ReqInt.nIntClase = 1006
                ReqInt.nIntCodigo = Val(Rs.Rows.Item(0).Item(13))
                Dim ResInt As BE_Res_Interface = New BE_Res_Interface()
                ResInt = ObjInt.getInterface(ReqInt)
                lblUO.Text = ResInt.cIntDescripcion

                Dim ReqConst As BE_Req_Constante = New BE_Req_Constante()
                Dim ObjConst As BL_Constante = New BL_Constante()

                Rs.Clear()
                ReqConst.nConCodigo = 1063
                ReqConst.nConValor = Len(TipDocumento)
                ReqConst.ConLeft = Len(TipDocumento)
                ReqConst.ConValLeft = TipDocumento
                Rs = ObjConst.ListarConstantes(ReqConst)
                lblTipoDocumento.Text = Rs.Rows(0).Item(1)

                ReqDoc.cDocCodigo = DocCodigo
                Rs = ObjDoc.getPerCopias(ReqDoc)
                If Rs.Rows.Count > 0 Then
                    For i = 0 To Rs.Rows.Count - 1
                        lblCopias.Text = lblCopias.Text & Rs.Rows.Item(i).Item(0) & ";"
                    Next
                End If

            End If
        End If
    End Sub

    Protected Sub btncerrar_Click(sender As Object, e As System.EventArgs) Handles btncerrar.Click
        Dim script As String 
        Try 
            script = "<script Language=JavaScript>window.close()</script>"
            Response.Write(script)
        Catch x As Exception 
            Response.Write(x.Message)
        End Try
    End Sub

    Protected Sub lnkReferencia_Click(sender As Object, e As System.EventArgs) Handles lnkReferencia.Click
        mVewReferencia.ActiveViewIndex = 0
    End Sub
End Class
