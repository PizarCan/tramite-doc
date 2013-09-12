Imports Integration.BE.TraDoc
Imports Integration.BL
Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine

Partial Class Forms_frmDocDiario
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim dFecha As Date = Request.QueryString("dFecha")

        Dim ReportRuta As String = String.Empty
        Dim i As Integer = 0
        Dim Rs As New DataTable

        Dim ReqTraDoc As BE_Req_TraDoc = New BE_Req_TraDoc()
        Dim ObjTraDoc As BL_TraDoc = New BL_TraDoc()

        ReqTraDoc.iOpcion = 14
        ReqTraDoc.cFecIni = Format(dFecha, "MM/dd/yyyy")
        ReqTraDoc.cPerCodigo = Session("cPerCodigo")

        Rs = ObjTraDoc.get_TraDoc_Procesos(ReqTraDoc)

        Response.Write("<Table Border=1 class=Tabla cellspacing = 0><TR>")
        Response.Write("<TD class=SimTitulo colspan=5>Documentos Registrados el  " & dFecha & " - Mesa de Partes</TD></TR>")
        Response.Write("<TR><TD class=SimTitulo>Documento</TD>")
        Response.Write("<TD class=SimTitulo>Número</TD>")
        Response.Write("<TD class=SimTitulo>Remitente/Destino</TD>")
        Response.Write("<TD class=SimTitulo>Asunto</TD>")
        Response.Write("<TD class=SimTitulo>Firma________</TD>")
        Response.Write("</TR>")

        For x As Integer = 0 To Rs.Rows.Count - 1
            Response.Write("<TR><TD rowspan=2>" & Rs.Rows(x).Item(12) & "</TD>")
            Response.Write("<TD rowspan=2>" & Rs.Rows(x).Item(10) & "</TD>")
            Response.Write("<TD>" & Rs.Rows(x).Item(2) & "</TD>")
            Response.Write("<TD rowspan=2>" & Rs.Rows(x).Item(6) & "</TD>")
            Response.Write("<TD rowspan=2>.</TD>")
            Response.Write("</TR>")
            Response.Write("<TR><TD>" & Rs.Rows(x).Item(0) & "</TD></TR>")
            i += 1
        Next
        Response.Write("<BR><BR>")
        Response.Write("<TR><TD colspan=5>Total de Documentos: " & i & "</TD><BR>")
        Response.Write("</Table>")
        Rs.Clear()

    End Sub
End Class
