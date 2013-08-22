

Imports Integration.DataIntegration
Imports Integration.DAService
Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class Form1
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim user As String = Me.TextBox1.Text
        Dim Pass As String = Me.TextBox2.Text
        Dim dr As SqlDataReader
        Dim dt As New DataTable
        Dim objInterface As New Integration.DataIntegration.clsInterface


        Dim ObjEncrypt As New Integration.Conection.clsCrypt
        Dim vUser As String = ""
        Dim vPass As String = ""

        Dim Resultado As Long
        vUser = UCase(Me.TextBox1.Text)
        vPass = ObjEncrypt.EncryptByCode(vUser, Me.TextBox2.Text)


        Resultado = objInterface.Upd_InterfaceByClase(90000, 1006, "UNIVERSIDAD AUTONOMA DEL PERU")
        If Resultado = 0 Then
            dt = objInterface.GetInterfaceByClase(1006)

            ' dt.Load(dr)
            DataGridView1.DataSource = dt
        Else
            MsgBox("Existio un Error:" & Resultado)
        End If

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim Registro As New Integration.Conection.clsReadRegEdit
        Dim ObjEncrypt As New Integration.Conection.clsCrypt


        Dim vPass As String = ObjEncrypt.EncryptReg(Me.TextBox5.Text)
        Dim vUser As String = ObjEncrypt.EncryptReg(Me.TextBox4.Text)
        Dim Server As String = ObjEncrypt.EncryptReg(Me.TextBox3.Text)
        Dim vBase As String = ObjEncrypt.EncryptReg("BDIntegration")
        Registro.SetValueRegEdit("Conexiones\Naylamp", "PWD", vPass)
        Registro.SetValueRegEdit("Conexiones\Naylamp", "UID", vUser)
        Registro.SetValueRegEdit("Conexiones\Naylamp", "SERVER", Server)
        Registro.SetValueRegEdit("Conexiones\Naylamp", "DATABASE", vBase)
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click

        Dim ObjEncrypt As New Integration.Conection.clsCrypt
        Dim user As String = Me.txtuser.Text
        Dim Pass As String = Me.txtclave.Text
        Dim vUser As String = user
        Dim vPass As String = ""
        Dim Request As New BE.Login.BE_Req_Login
        Dim Response As New BE.Login.BE_Res_Login
        Dim da As New DAService.DALogin

        Request.cPerUsuCodigo = vUser
        vPass = ObjEncrypt.EncryptByCode(vUser, Pass)
        Request.cPerUsuClave = vPass
        Response = da.ValidaterUser(Request)

        If Response.cPerCodigo = "" Then
            MsgBox("USuario y/o COntraseña Incorrecta")
        Else
            MsgBox(Response.cPerAlias)
        End If

    End Sub
End Class
