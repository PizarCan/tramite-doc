
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
            LoaderData(txtFecha.Text)
        Catch ex As Exception
            lblError.Text = ex.Message
        End Try
    End Sub

    Protected Sub cldFecha_SelectionChanged(sender As Object, e As System.EventArgs) Handles cldFecha.SelectionChanged
        txtFecha.Text = cldFecha.SelectedDate
    End Sub
    Sub LoaderData(ByVal dFecha As Date, Optional ByVal Print As Integer = 0)

        'Dim Report As New ReportDocument
        'Dim Comando As New DataTable

        'Using Cn As New SqlConnection(TramiteDocumentario.MiConexion)
        '    Cn.Open()
        '    Dim ReportRuta As String = String.Empty
        '    Dim MyTrans As SqlTransaction = Cn.BeginTransaction

        '    Try
        '        Dim clsTraDoc As New TramiteDocumentario.clsTraDoc


        '        ReportRuta = Server.MapPath("~/Report/crpDocDiarios.rpt")

        '        Comando.Load(clsTraDoc.Get_MesPart_Doc_Diarios(Format(dFecha, "MM/dd/yyyy"), MyTrans, Cn, Session("PerCodigo")))
        '        Report.Close()

        '        Report.Load(ReportRuta)
        '        Report.SetDataSource(Comando)

        '        MyTrans.Commit()
        '        Cn.Close()
        '        Me.crptPEaDReport.ReportSource = Report
        '    Catch ex As Exception
        '        Throw ex
        '    End Try

        'End Using
    End Sub


    Protected Sub btnBuscar_Click(sender As Object, e As System.EventArgs) Handles btnBuscar.Click
        Try
            Dim Fecha As Date = txtFecha.Text
            LoaderData(Fecha)
        Catch ex As Exception
            lblError.Text = ex.Message
        End Try

    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As System.EventArgs) Handles LinkButton1.Click
        Response.Redirect("frmDocDiario.aspx?dFecha=" & txtFecha.Text)
    End Sub
End Class
