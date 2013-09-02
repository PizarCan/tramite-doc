
Partial Class Forms_frmDonwFile
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim ArcName As String = Request.QueryString("ArcName")
            Dim ArcRuta As String = Request.QueryString("ArcRuta")

            Response.Redirect("http://" & ArcRuta & "/" & ArcName)
        End If
    End Sub
End Class
