Imports Integration.BE.Login
Imports Integration.BL
Imports Integration.BE.Persona
Imports Integration.BE.Documento
Imports System.Data

Partial Class Forms_frmAcuDirectorio
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim UserReq As BE_Req_Login = New BE_Req_Login()
        UserReq.cPerUsuCodigo = Session("cPerUsuCodigo")
        Dim UserBL As BL_Login = New BL_Login()

        If UserBL.ValidaInicioSesion(UserReq) Then
            If Not Page.IsPostBack = True Then

                If Not Page.IsPostBack Or Session("Refresh") = True Then
                    Session("Refresh") = False
                    Dim PerCodigo As String
                    Dim PerDelCodigo As String = System.String.Empty
                    Dim ReqPersona As BE_Req_Persona = New BE_Req_Persona()
                    ReqPersona.cPerCodigo = Session("cPerCodigo")
                    Dim BL_Per As BL_Persona = New BL_Persona()
                    PerDelCodigo = BL_Per.getDelegadoAnduser(ReqPersona)
                    If PerDelCodigo <> System.String.Empty Then
                        PerDelCodigo = Left(PerDelCodigo, Len(PerDelCodigo) - 1)
                        Session("PerDelCodigo") = PerDelCodigo
                        PerCodigo = Session("cPerCodigo") & "','" & PerDelCodigo
                    Else
                        PerCodigo = Session("cPerCodigo")
                    End If
                    Dim ReqDocumentos As BE_Req_Documento = New BE_Req_Documento()
                    Dim BL_Doc As BL_Documento = New BL_Documento()
                    Dim Rs As DataTable
                    ReqDocumentos.cPerCodigo = PerCodigo
                    ReqDocumentos.FiltroPersona = 1
                    ReqDocumentos.FiltroFecha = 0
                    ReqDocumentos.dFechaIni = "01/01/1900"
                    ReqDocumentos.dFechaFin = "01/01/1900"
                    Rs = BL_Doc.getDocPendientesConAcuerdo(ReqDocumentos)

                    gvAcuerdos.DataSource = Rs
                    gvAcuerdos.DataBind()
                    Dim Row As GridViewRow
                    For Each Row In gvAcuerdos.Rows
                        Dim lnkButon As New LinkButton
                        lnkButon = CType(Row.FindControl("lbnNumDocumento"), LinkButton)
                        lnkButon.OnClientClick = "javascript:(abre('frmAcuerdos.aspx?cDocCodigo=" & gvAcuerdos.DataKeys(Row.RowIndex).Values("cDocCodigo") & "','Silabo'));"

                    Next
                End If
            End If

        End If
    End Sub

    Public Function AvaGrafico(ByVal AvaPorcentaje As Integer, Optional ByVal Tiempo As Integer = 0) As String
        Dim RutaGrafico As String = ""
        If Tiempo < 0 AndAlso AvaPorcentaje = 0 Then
            RutaGrafico = "~\Imagenes\Infraccion.png"
        Else
            Select Case AvaPorcentaje
                Case 0
                    RutaGrafico = "~\Imagenes\FolderCloseB.gif"
                Case Is < 100
                    RutaGrafico = "~\Imagenes\Avance.gif"
                Case 100
                    RutaGrafico = "~\Imagenes\Completo.png"
            End Select
        End If
        Return RutaGrafico
    End Function

    Public Function BtnVisible(ByVal TipDocumento As Integer) As Boolean
        If TipDocumento = 8102 Then
            Return False
        Else
            Return True
        End If
    End Function


End Class
