
Partial Class LogOut
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Session("cPerCodigo") = ""
        Session("cPerUsuCodigo") = ""
        Session("Nombre") = ""
        Response.Redirect("login.aspx")
    End Sub
End Class
