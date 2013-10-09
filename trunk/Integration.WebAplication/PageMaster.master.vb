
Partial Class PageMaster
    Inherits System.Web.UI.MasterPage

    Private Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("cPerCodigo") = "" Then
                If Session("Login") <> True Then
                    Session("Login") = True
                    Response.Redirect("~/Login.aspx")
                End If
            Else
                Session("Login") = False
            End If
        End If

    End Sub
End Class

