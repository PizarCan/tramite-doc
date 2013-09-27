Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO
Imports System.Globalization

Public Class reportes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim var As String
        If Request.Form("lblReporte") <> "" Then
            var = Request.Form("lblReporte")
            Dim a As String() = var.Split(New Char() {"|"c})
            'hf_tiporeporte.Value = a(0)
            'hf_valores.Value = a(1)
        End If
        var = "0"
        'Select Case (hf_tiporeporte.Value)
        '    Case "IdLlave"
        reporteprueba(var)
        'End Select
    End Sub
    Private Sub reportear(ByVal objReporte As ReportDocument)
        Dim Fname As String
        Dim crExportOptions As ExportOptions
        Dim crDiskFileDestinationOptions As New DiskFileDestinationOptions
        objReporte.SummaryInfo.ReportAuthor = "Usuario" 'IdentityUser.UserName
        'objReporte.PrintOptions.PaperSize = PaperSize.PaperA4
        'objReporte.PrintOptions.PaperOrientation = PaperOrientation.DefaultPaperOrientation
        Fname = Server.MapPath(".") & "\" & Session.SessionID.ToString & ".pdf"
        crDiskFileDestinationOptions.DiskFileName = Fname
        crExportOptions = objReporte.ExportOptions
        With crExportOptions
            .DestinationOptions = crDiskFileDestinationOptions
            .ExportDestinationType = ExportDestinationType.DiskFile
            .ExportFormatType = ExportFormatType.PortableDocFormat
        End With
        objReporte.Export()
        Response.ClearContent()
        Response.ClearHeaders()
        Response.ContentType = "application/pdf"
        Response.WriteFile(Fname)
        Response.Flush()
        'Response.Close()
        objReporte.Close()
        objReporte.Dispose()
        System.IO.File.Delete(Fname)
    End Sub

    Private Sub reporteprueba(ByVal vars As String)
        Dim a As String() = vars.Split(New Char() {"-"c})
        Dim variable1 As String = a(0)
        Dim variable2 As String = a(1)
        If vars <> "0" Then


            'Try
            '    Dim TblTmp As DataTable = New DataTable()
            '    'TblTmp = Dal_SieSa_Ra_Reportes.Ins.USP_TRILCE_CP_IngresantesMatriculados_nUniOrgCodigo(cPerJurCodigo, nPrdCodigo, nUniOrgCodigo)

            '    'OBTENEMOS LOS VALORES SEGUN LA TABLA
            '    Dim objsp As New DAL_Persona
            '    Dim objdataset As DataSet = New DataSet()
            '    objdataset = objsp.Get_Campus_Persona_cPerApellido(variable1)

            '    TblTmp = objdataset.Tables(0)

            '    If TblTmp.Rows.Count > 0 Then
            'Dim objReporte As New CrystalReport1
            'objReporte.SetDataSource(TblTmp)
            'objReporte.SetParameterValue("Empresa", variable1)
            'reportear(objReporte)
            '    Else
            '        Response.Write("No hay datos para mostrar.")
            '    End If

            'Catch ex As Exception
            '    Throw ex
            'End Try
        End If
    End Sub

End Class