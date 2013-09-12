Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports Integration.BE.TraDoc
Imports Integration.BL

Partial Class Reportes_frmPEaDReport
    Inherits System.Web.UI.Page
    Dim Report As New ReportDocument

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            LoaderData()
        Catch ex As Exception
            lblError.Text = ex.Message '& "---" & ex.InnerException.Message
        End Try
    End Sub

    Sub LoaderData(Optional ByVal Print As Integer = 0)
        Dim nRepTipo As Integer = Request.QueryString("nRepTipo")
        Dim cReportRuta As String = String.Empty
        Dim nPrdCodigo As String = Request.QueryString("nPrdCodigo")
        Dim nUniOrgCodigo As Long = Request.QueryString("nUniOrgCodigo")
        Dim cRepTitle As String = Request.QueryString("cRepTitle")
        Dim cRepComments As String = Request.QueryString("cRepComments")
        Dim cPerCodigo As String = Request.QueryString("cPerCodigo")
        Dim cPerJurCodigo As String = Request.QueryString("cPerJuridica")
        Dim OtherType As Long = Request.QueryString("OtherType")
        Dim cPrdDescripcion As String = Request.QueryString("cPrdDescripcion")
        Dim cFecIni As String = Request.QueryString("cFecIni")
        Dim cFecFin As String = Request.QueryString("cFecFin")
        Dim nPerRemFiltro As Integer = Request.QueryString("nPerRemFiltro")
        Dim nPerRecFiltro As Integer = Request.QueryString("nPerRecFiltro")

        Dim Comando As New DataTable


        Dim ReqTraDoc As BE_Req_TraDoc = New BE_Req_TraDoc()
        Dim BL_TraDoc As BL_TraDoc = New BL_TraDoc()


        Select Case nRepTipo
            Case 1
                ReqTraDoc.iOpcion = 2
                ReqTraDoc.cFecIni = cFecIni
                ReqTraDoc.cFecFin = cFecFin
                ReqTraDoc.cPerCodigo = Session("cPerCodigo")
                Comando = BL_TraDoc.get_TraDoc_Procesos(ReqTraDoc)

                cReportRuta = Server.MapPath("~/Report/rptTDAcuerdos.rpt")
                'Comando.Load(clsTraDoc.Get_Acuerdos_By_Persona_OR_Fecha(cPerCodigo, cFecIni, cFecFin, MyTrans, Cn))

            Case 2
                ReqTraDoc.iOpcion = 1
                ReqTraDoc.cPerCodigo = Session("cPerCodigo")
                ReqTraDoc.nPerRemFiltro = nPerRemFiltro
                ReqTraDoc.nPerRecFiltro = nPerRecFiltro
                ReqTraDoc.nDocNumFiltro = 0
                ReqTraDoc.nItemFiltro = 0
                ReqTraDoc.cDocNDoc = ""
                ReqTraDoc.nAsuFiltro = 0
                ReqTraDoc.cDocConContenido = ""
                ReqTraDoc.nPrdCodigo = nPrdCodigo
                ReqTraDoc.nDocTipo = 0
                ReqTraDoc.nFilMes = 0
                Comando = BL_TraDoc.get_TraDoc_Procesos(ReqTraDoc)

                cReportRuta = Server.MapPath("~/Report/rptTDDocBusca.rpt")
                'Comando.Load(clsTraDoc.Get_Busca_Doc_Whit_Filtro(cPerCodigo, nPerRemFiltro, nPerRecFiltro, 0, 0, "", 0, "", nPrdCodigo, 0, 0, MyTrans, Cn))
        End Select

        Report.Load(cReportRuta)
        Report.SummaryInfo.ReportAuthor = "Impreso por :" & Session("cPerCodigo")
        Report.SummaryInfo.ReportTitle = cRepTitle
        Report.SummaryInfo.ReportComments = cRepComments
        Report.SetDataSource(Comando)

        crptPEaDReport.ReportSource = Report

    End Sub


End Class
