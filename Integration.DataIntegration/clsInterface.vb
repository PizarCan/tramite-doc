Option Explicit On

Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Integration.Conection.clsConection

Public Class clsInterface

    Const Name As String = "ClsInterface"
    Dim mConexion As Integration.Conection.clsConection
    Dim NumError As Long
    Private _conectado As Boolean

    Public Sub New()
        NumError = 0
        'mConexion = Nothing
        Dim mConexion As New Integration.Conection.clsConection
    End Sub

    Private Property Conectado(mConexion As Conection.clsConection) As Boolean
        Get
            Return _conectado
        End Get
        Set(value As Boolean)
            _conectado = value
        End Set
    End Property

    Private Sub Finalize()
        mConexion = Nothing
    End Sub

    Public Property Conexion() As Integration.Conection.clsConection
        Get
            Return mConexion
        End Get
        Set(ByVal value As Integration.Conection.clsConection)
            mConexion = value
        End Set
    End Property


    Public Property Message() As String

        Get
            If Conectado(mConexion) Then
                Message = mConexion.Message
            Else
                Message = "No hay conexion con el Origen de datos."
            End If
            Return Message
        End Get
        Set(ByVal vMessage As String)
            Message = vMessage
        End Set
    End Property

    Public Sub TerminarTransaccion(NumError As Long)
        If Conectado(mConexion) Then mConexion.TerminarTransaccion(NumError)
    End Sub

    Public Function GetInterface(nIntClase As Long) As SqlDataReader
        Dim cn As Integration.Conection.clsConection = New Integration.Conection.clsConection
        Dim strsql As String
        Dim dr As SqlDataReader

        strsql = "Select * from Interface where nIntClase=1006"
        dr = cn.GetRecordset(strsql)
        Return dr
    End Function

    Public Function GetInterfaceByClase(nIntClase As Long) As DataTable
        Dim Resultado As Long = 0
        Try
            Using cn As New Integration.Conection.clsConection
                Using cmd As New SqlCommand
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = "sp_Interface_Get"
                    cmd.Parameters.AddWithValue("@nIntClase", nIntClase)
                    Using dt As New DataTable
                        Return cn.ExecuteCmdResultDt(cmd)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try


    End Function
    Public Function Upd_InterfaceByClase(nIntCodigo As Long, nIntClase As Long, cIntNombre As String, Optional ByRef Resultado As Long = 0) As Long

        Try
            Using cn As New Integration.Conection.clsConection
                Using cmd As New SqlCommand
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = "updInterface"
                    cmd.Parameters.AddWithValue("@nIntClase1", nIntClase)
                    cmd.Parameters.AddWithValue("@nIntCodigo", nIntCodigo)
                    cmd.Parameters.AddWithValue("@cIntNombre", cIntNombre)
                    Return cn.ExecuteCmdResultLong(cmd)
                End Using
            End Using
        Catch ex As Exception
            Resultado = Err.Number
            Return Resultado
        End Try


    End Function


End Class
