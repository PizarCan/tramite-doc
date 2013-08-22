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
Imports Microsoft.VisualBasic

Partial Class Login
    Inherits System.Web.UI.Page

    Protected Sub LoginButton_Click(sender As Object, e As System.EventArgs)

    End Sub

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
        Dim Response As BE_Res_Login = New BE_Res_Login()
        Dim objBl As BL_Login = New BL_Login()

        Dim Pass = ObjEncrypt.EncryptByCode(cPerUsuCodigo, cPerUsuPassword)

        Request.cPerUsuCodigo = cPerUsuCodigo
        Request.cPerUsuClave = cPerUsuPassword
        Response = objBl.ValidateUser(Request)

        If (IsNothing(Response.cPerCodigo)) Then
            lblError.Text = "Usuario y/o Clave Incorrecto.!!"
        Else
            lblError.Text = "Bienvenido Sr." + Response.cPerAlias




        End If



        Using cn As New SqlConnection(TramiteDocumentario.MiConexion)
            Dim Clase As New TramiteDocumentario.clsTraDoc
            Dim Rs As DataTable
            Try
                If cPerUsuCodigo <> String.Empty And cPerUsuPassword <> String.Empty Then
                    Dim Cript As New Cnseuss.ClsCrypt
                    Dim Rows As Integer
                    Dim i As Integer
                    Dim Clave As String

                    cPerUsuCodigo = cPerUsuCodigo.Replace("'", "''")
                    cPerUsuPassword = cPerUsuPassword.Replace("'", "''")
                    Clave = Cript.EncryptByCode(cPerUsuCodigo, cPerUsuPassword)

                    If cn.State = ConnectionState.Closed Then
                        cn.Open()
                    End If
                    Dim MyTrans As SqlTransaction
                    MyTrans = cn.BeginTransaction
                    Rs = Clase.CodUsuario(cPerUsuCodigo, Clave.Replace("'", "''"), MyTrans, cn)
                    If Rs.Rows.Count > 0 Then
                        Session("PerCodigo") = Rs.Rows.Item(0).Item(0)
                        Rs = Clase.DatUsuario(Session("PerCodigo"), MyTrans, cn)
                        Rows = Rs.Rows.Count
                        If Rows > 0 Then
                            '############  Permisos Mesa de Partes#################
                            Session("PerMesaPartes") = False
                            Session("RegPersona") = False
                            Session("MesaPartesArea") = False
                            Session("AcuRegistro") = False
                            Session("AcuMonitor") = False
                            Dim rs2 As DataTable
                            Clase = New TramiteDocumentario.clsTraDoc
                            rs2 = Clase.ObjPerPermios(Session("PerCodigo"), MyTrans, cn)
                            If rs2.Rows.Count > 0 Then
                                For i = 0 To rs2.Rows.Count - 1
                                    If rs2.Rows.Item(i).Item(0) = "MNUMESAPARTES" Or rs2.Rows.Item(i).Item(0) = "MNUMESA" Then Session("PerMesaPartes") = True
                                    If rs2.Rows.Item(i).Item(0) = "MNUREGPERSONA" Then Session("RegPersona") = True
                                    If rs2.Rows.Item(i).Item(0) = "MNUMESA" Then Session("MesaPartesArea") = True
                                    If rs2.Rows.Item(i).Item(0) = "MNUREGACUERDOS" Then Session("AcuRegistro") = True
                                    If rs2.Rows.Item(i).Item(0) = "MNUACUMONITOR" Then Session("AcuMonitor") = True
                                Next
                            End If
                            '########################################

                            Session("Nombre") = Rs.Rows.Item(0).Item(2) & Space(2) & Rs.Rows.Item(0).Item(1)
                            Session("CodUO") = Rs.Rows.Item(0).Item(4)
                            Session("UOCodigo") = Val(Rs.Rows.Item(0).Item(4))
                            Session("Login") = "Ingresar"
                            clsConsultasComunes.UserCode = Session("PerCodigo")
                            Get_User_Valido = True
                            'HttpContext.Current.Application.Add("cPerCodigo", Session("PerCodigo"))
                            If Session("PerMesaPartes") = False Then
                                'Response.Write("<script Language=JavaScript>window.open('RegDocArea.aspx','NuevaVentana2','scrollbars=yes,status=yes,height=700,width=780,resizable=yes')</script>")
                                Response.Redirect("www.google.com.pe")
                                clsConsultasComunes.PageRetunr = "Forms/RegDocArea.aspx"
                            Else
                                Response.Redirect("Forms/RegDocumento.aspx")
                                'Response.Write("<script Language=JavaScript>window.open('RegDocumento.aspx','NuevaVentana2','scrollbars=yes,status=yes,height=700,width=780,resizable=yes')</script>")
                                clsConsultasComunes.PageRetunr = "Forms/RegDocumento.aspx"
                            End If
                        End If

                        MyTrans.Commit()
                    Else
                        MyTrans.Rollback()
                        'Response.Write("<script language='javascript'>")
                        'Response.Write("alert ('Usuario y/o Clave Incorrecta')")
                        'Response.Write("</script>")
                    End If
                End If
            Catch ex As Exception
                Throw
            End Try
            Clase = Nothing
        End Using
    End Function

End Class
