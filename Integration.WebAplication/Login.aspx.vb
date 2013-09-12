Imports System.Data.SqlClient
Imports System.Data
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Integration.BL
Imports Integration.Conection
Imports Integration.BE.Login
Imports Integration.BE.PerUsuGruAcc
Imports Microsoft.VisualBasic

Partial Class Login
    Inherits System.Web.UI.Page
     

    Protected Sub lgInicio_Authenticate(sender As Object, e As System.Web.UI.WebControls.AuthenticateEventArgs) Handles lgInicio.Authenticate
        Try
            e.Authenticated = Get_User_Valido(lgInicio.UserName.ToUpper, lgInicio.Password)
        Catch ex As Exception
            lblError.Text = ex.Message
        End Try
    End Sub

    Public Function Get_User_Valido(ByVal cPerUsuCodigo As String, ByVal cPerUsuPassword As String) As Boolean

        Dim ObjEncrypt As clsCrypt = New clsCrypt()
        Dim Request As BE_Req_Login = New BE_Req_Login()
        Dim Respons As BE_Res_Login = New BE_Res_Login()
        Dim objBl As BL_Login = New BL_Login()

        Dim Pass = ObjEncrypt.EncryptByCode(cPerUsuCodigo, cPerUsuPassword)

        Request.cPerUsuCodigo = cPerUsuCodigo
        Request.cPerUsuClave = Pass
        Respons = objBl.ValidateUser(Request)

        If (IsNothing(Respons.cPerCodigo)) Then
            lblError.Text = "Usuario y/o Clave Incorrecto.!!"
            Get_User_Valido = False
        Else
            lblError.Text = "Bienvenido Sr." + Respons.cPerAlias
            Session("cPerCodigo") = Respons.cPerCodigo
            Session("cPerUsuCodigo") = Respons.cPerKey
            Session("Nombre") = Respons.cPerAlias
            '############  Permisos Mesa de Partes#################
            Session("PerMesaPartes") = False
            Session("RegPersona") = False
            Session("MesaPartesArea") = False
            Session("AcuRegistro") = False
            Session("AcuMonitor") = False
            Dim ObjPU As BL_PerUsuGruAcc = New BL_PerUsuGruAcc()
            Dim ReqPermisos As BE_Req_PerUsuGruAcc = New BE_Req_PerUsuGruAcc()
            Dim ListaPermisos As New List(Of BE_Res_PerUsuGruAcc)
            ReqPermisos.cPerCodigo = Respons.cPerCodigo
            ReqPermisos.nObjTipo = 1001
            ReqPermisos.nSisGruTipo = 1004
            ListaPermisos = ObjPU.obtenerPermisos(ReqPermisos)
            If ListaPermisos.Count > 0 Then
                For Each ResPermisos As BE_Res_PerUsuGruAcc In ListaPermisos
                    If ResPermisos.cIntNombre = "MNUMESAPARTES" Or ResPermisos.cIntNombre = "MNUMESA" Then Session("PerMesaPartes") = True
                    If ResPermisos.cIntNombre = "MNUREGPERSONA" Then Session("RegPersona") = True
                    If ResPermisos.cIntNombre = "MNUMESA" Then Session("MesaPartesArea") = True
                    If ResPermisos.cIntNombre = "MNUREGACUERDOS" Then Session("AcuRegistro") = True
                    If ResPermisos.cIntNombre = "MNUACUMONITOR" Then Session("AcuMonitor") = True
                Next
            End If
            If ReqPermisos.cPerCodigo = "0000000000" Then
                Session("PerMesaPartes") = False
                Session("RegPersona") = True
                Session("MesaPartesArea") = True
                Session("AcuRegistro") = True
                Session("AcuMonitor") = True
            End If

            Get_User_Valido = True
            If Session("PerMesaPartes") = False Then
                Response.Redirect("Forms/RegDocArea.aspx")
            Else
                Response.Redirect("Forms/RegDocumento.aspx")
            End If
        End If

    End Function

End Class
