Imports System.Data
Imports System.Data.SqlClient

Partial Class Forms_Adm_Papeletas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Papeletas_RRhh()
        End If
    End Sub

    Sub Papeletas_RRhh()
      
    End Sub
    Sub cargarCheck()
      
    End Sub

    Protected Sub CmdAprobarRRhh_Click(sender As Object, e As System.EventArgs) Handles CmdAprobarRRhh.Click
        Estado_PapeletasRRHH(1)
    End Sub

    Sub Estado_PapeletasRRHH(ByVal Estado As Integer)
      
    End Sub

    Protected Sub CmdRechazar_Click(sender As Object, e As System.EventArgs) Handles CmdRechazar.Click
        Estado_PapeletasRRHH(2)
    End Sub
End Class
