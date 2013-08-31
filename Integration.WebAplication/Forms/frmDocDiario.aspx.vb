
Partial Class Forms_frmDocDiario
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        clsConsultasComunes.Ins_User_From_Login(Session("PerCodigo"))
        Dim Rs As SqlDataReader
        Dim dFecha As Date = Request.QueryString("dFecha")

        Using Cn As New SqlConnection(TramiteDocumentario.MiConexion)
            Cn.Open()
            Dim ReportRuta As String = String.Empty
            Dim MyTrans As SqlTransaction = Cn.BeginTransaction
            Dim i As Integer = 0
            Try
                Dim clsTraDoc As New TramiteDocumentario.clsTraDoc
                Rs = clsTraDoc.Get_MesPart_Doc_Diarios(Format(dFecha, "MM/dd/yyyy"), MyTrans, Cn, Session("PerCodigo"))
                Response.Write("<Table Border=1 class=Tabla cellspacing = 0><TR>")
                Response.Write("<TD class=SimTitulo colspan=5>Documentos Registrados el  " & dFecha & " - Mesa de Partes</TD></TR>")
                Response.Write("<TR><TD class=SimTitulo>Documento</TD>")
                Response.Write("<TD class=SimTitulo>Número</TD>")
                Response.Write("<TD class=SimTitulo>Remitente/Destino</TD>")
                Response.Write("<TD class=SimTitulo>Asunto</TD>")
                Response.Write("<TD class=SimTitulo>Firma________</TD>")
                Response.Write("</TR>")

                While Rs.Read
                    Response.Write("<TR><TD rowspan=2>" & Rs(12) & "</TD>")
                    Response.Write("<TD rowspan=2>" & Rs(10) & "</TD>")
                    Response.Write("<TD>" & Rs(2) & "</TD>")
                    Response.Write("<TD rowspan=2>" & Rs(6) & "</TD>")
                    'Response.Write("<TD>" & Rs(9) & "</TD>") Fecha
                    Response.Write("<TD rowspan=2>.</TD>")
                    Response.Write("</TR>")
                    Response.Write("<TR><TD>" & Rs(0) & "</TD></TR>")
                    i += 1
                End While
                Response.Write("<BR><BR>")
                Response.Write("<TR><TD colspan=5>Total de Documentos: " & i & "</TD><BR>")
                Response.Write("</Table>")
                Rs.Close()
                MyTrans.Commit()

            Catch ex As Exception
                lblError.Text = ex.Message
            End Try

        End Using
    End Sub
End Class
