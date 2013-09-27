Imports System.Data
Imports Integration.BE.TraDoc
Imports Integration.BL
Imports CrystalDecisions.CrystalReports.Engine

Partial Class Forms_frmDocDiarios
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            If Not Page.IsPostBack Then
                cldFecha.SelectedDate = Date.Now.Date
                txtFecha.Text = Date.Now.Date
                lnkCerrar.Attributes.Add("onclick", "javascript:window.close()")
            End If
            lblError.Text = String.Empty
            'LoaderData(txtFecha.Text)
        Catch ex As Exception
            lblError.Text = ex.Message
        End Try
    End Sub

    Protected Sub cldFecha_SelectionChanged(sender As Object, e As System.EventArgs) Handles cldFecha.SelectionChanged
        txtFecha.Text = cldFecha.SelectedDate
    End Sub
    'Sub LoaderData(ByVal dFecha As Date, Optional ByVal Print As Integer = 0)

    '    Dim Report As New ReportDocument()
    '    Dim DocDiario As DataTable = New DataTable()

    '    Dim ReqTraDoc As BE_Req_TraDoc = New BE_Req_TraDoc()
    '    Dim BL_TraDoc As BL_TraDoc = New BL_TraDoc()
    '    ReqTraDoc.iOpcion = 14
    '    ReqTraDoc.cFecIni = Format(dFecha, "MM/dd/yyyy")
    '    ReqTraDoc.cPerCodigo = Session("cPerCodigo")
    '    DocDiario = BL_TraDoc.get_TraDoc_Procesos(ReqTraDoc)

    '    If DocDiario.Rows.Count > 0 Then
    '        Try
    '            Dim ReportRuta As String = String.Empty
    '            ReportRuta = Server.MapPath("~/Reportes/crpDocDiarios.rpt")
    '            'Report.Close()
    '            Report.Load(ReportRuta)
    '            'Report.SetDataSource(DocDiario)
    '            Dim ds As New dsReportes
    '            ds.Tables("DocDiario").Load(DocDiario.CreateDataReader)
    '            Report.SetDataSource(ds)

    '            Dim dtable As DataTable = ds.Tables("DocDiario")

    '            dtable = BL_TraDoc.get_TraDoc_Procesos(ReqTraDoc)

    '            CrystalReportViewer1.Visible = True
    '            'Report.SetDataSource(dtable)
    '            'CrystalReportViewer1.ReportSource = Report
    '            CrystalReportSource1.Report.FileName = Server.MapPath("~/Reportes/crpDocDiarios.rpt")
    '            CrystalReportViewer1.ReportSource = CrystalReportSource1
    '        Catch ex As Exception
    '            CrystalReportViewer1.Visible = False
    '            lblError.Text = ex.Message
    '        End Try


    '    Else
    '        CrystalReportViewer1.Visible = False
    '        lblError.Text = "No hay documentos en esta fecha"
    '    End If




    'End Sub


    Protected Sub btnBuscar_Click(sender As Object, e As System.EventArgs) Handles btnBuscar.Click
        Try
            Dim Fecha As Date = txtFecha.Text
            'LoaderData(Fecha)
        Catch ex As Exception
            lblError.Text = ex.Message
        End Try

    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As System.EventArgs) Handles LinkButton1.Click
        Response.Redirect("frmDocDiario.aspx?dFecha=" & txtFecha.Text)
    End Sub
End Class
