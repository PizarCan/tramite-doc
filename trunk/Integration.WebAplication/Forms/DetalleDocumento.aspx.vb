
Partial Class Forms_DetalleDocumento
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        clsConsultasComunes.Ins_User_From_Login(Session("PerCodigo"))
        If Not Page.IsPostBack Then

            Dim DocCodigo As String
            Dim TipDoc As String
            Dim TipDocumento As String
            Dim DocumentoEstado As Integer
            Dim CodDestino As String
            Dim DocEstado As String = "6318,6319,6325"
            Using cn As New SqlConnection(MiConexion)
                Dim Clase As New clsTraDoc
                Dim Rs As DataTable
                Dim i As Integer
                Dim MyTrans As SqlTransaction
                Dim PerCodigo As String = Session("PerCodigo")
                Dim cPerCopCodigo As String = (Request.QueryString("cPerCopCodigo"))
                Try
                    If cn.State = ConnectionState.Closed Then
                        cn.Open()
                    End If
                    MyTrans = cn.BeginTransaction
                    DocCodigo = (Request.QueryString("CodDocumento"))
                    Session("DocEstModificar") = DocCodigo
                    TipDoc = "1,2"
                    TipDocumento = (Request.QueryString("TipoDocumento"))
                    DocumentoEstado = (Request.QueryString("DocumentoEstado"))
                    CodDestino = (Request.QueryString("CodDestino"))
                    If Session("PerDelCodigo") <> System.String.Empty Then
                        PerCodigo += "','" & Session("PerDelCodigo")
                    End If
                    If DocumentoEstado = 1 Then
                        Rs = Clase.objDocPendientes(MyTrans, cn, PerCodigo, DocEstado, TipDoc, DocCodigo)
                    Else
                        DocEstado = "6318,6319, 6320, 6321, 6322, 6323, 6324, 6325,6326, 6328"
                        Rs = Clase.objDocInformacion(MyTrans, cn, cPerCopCodigo, 1040, DocEstado, TipDoc, DocCodigo, , CodDestino)
                    End If
                    lblremitente.Text = Rs.Rows.Item(0).Item(2)
                    lbldestino.Text = Rs.Rows.Item(0).Item(0)
                    lblfecha.Text = Rs.Rows.Item(0).Item(9)
                    lblasunto.Text = Rs.Rows.Item(0).Item(6)
                    lbldetalle.Text = Rs.Rows.Item(1).Item(6)
                    lblobservacion.Text = Rs.Rows.Item(0).Item(7)
                    lblDocNumero.Text = Rs.Rows.Item(0).Item(10)
                    lblUO.Text = Clase.objInterface(1006, Val(Rs.Rows.Item(0).Item(13)), MyTrans, cn).Rows.Item(0).Item(4)
                    lblTipoDocumento.Text = Clase.objCargarConstante(MyTrans, cn, 1063, Len(TipDocumento), Len(TipDocumento), TipDocumento, , , ).Rows.Item(0).Item(2)
                    Rs = Clase.objPerCopia(DocCodigo, MyTrans, cn)
                    If Rs.Rows.Count > 0 Then
                        For i = 0 To Rs.Rows.Count - 1
                            lblCopias.Text = lblCopias.Text & Rs.Rows.Item(i).Item(0) & ";"
                        Next
                    End If

                Catch x As Exception
                    Response.Write("<script language 'javascript'> alert ('Proceso No Válido') </script>")
                End Try
            End Using

        End If
    End Sub

    Protected Sub btncerrar_Click(sender As Object, e As System.EventArgs) Handles btncerrar.Click
        Dim script As String
        'Clase = New clsTraDoc
        'MyTrans = cn.BeginTransaction
        Try
            'Clase.objModEstDocumento(Session("DocEstModificar"), 6319)
            'Session("DocEstModificar") = ""
            'MyTrans.Commit()
            'Clase = Nothing
            script = "<script Language=JavaScript>window.close()</script>"
            Response.Write(script)
        Catch x As Exception
            'MyTrans.Rollback()
            Response.Write(x.Message)
        End Try
    End Sub

    Protected Sub lnkReferencia_Click(sender As Object, e As System.EventArgs) Handles lnkReferencia.Click
        mVewReferencia.ActiveViewIndex = 0
    End Sub
End Class
