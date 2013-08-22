
Imports Integration.Conection
Imports Integration.DataIntegration.clsInterface
Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class Form1
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim user As String = Me.TextBox1.Text
        Dim Pass As String = Me.TextBox2.Text
        Dim encriptado As String = ""
        Dim cn As New Integration.Conection.clsConection
        Dim objInterface As DataIntegration.clsInterface
        Dim dr As SqlDataReader
        dr = objInterface.GetInterface(1006)
        MsgBox(cn.DataBase())
    End Sub
End Class
