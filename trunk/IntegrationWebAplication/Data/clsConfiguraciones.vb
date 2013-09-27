Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class clsConfiguraciones

    Public Function GetTextValue(ByVal dr As IDataReader, ByVal Expresion As String) As String

        Dim strOut As String = String.Empty
        Dim FieldIndex As Long = 0

        Dim Tokens() As String = Expresion.Split("-")

        For I As Integer = 0 To Tokens.Length - 1

            Dim FieldValue As String = String.Empty

            Try
                FieldIndex = dr.GetOrdinal(Tokens(I))
            Catch ex As Exception
                FieldIndex = -1
            End Try

            If FieldIndex >= 0 Then
                Try
                    FieldValue = dr.GetString(FieldIndex)
                Catch ex As Exception
                    FieldValue = dr.GetValue(FieldIndex).ToString
                End Try
            Else
                FieldValue = Tokens(I)
            End If

            strOut &= FieldValue

        Next

        Return strOut
    End Function
    Public Function GetKeyValue(ByVal dr As IDataReader, ByVal Expresion As String) As String
        Dim StrOut As String = String.Empty
        Dim FieldIndex As Long = 0

        Dim Tokens() As String = Expresion.Split("-")

        For I As Integer = 0 To Tokens.Length - 1

            Dim FieldValue As String = String.Empty

            Try
                FieldIndex = dr.GetOrdinal(Tokens(I))
            Catch ex As Exception
                FieldIndex = -1
            End Try

            If FieldIndex >= 0 Then
                Try
                    FieldValue = dr.GetString(FieldIndex)
                Catch ex As Exception
                    FieldValue = dr.GetValue(FieldIndex).ToString
                End Try
            Else
                FieldValue = Tokens(I)
            End If

            StrOut &= FieldValue & "-"

        Next

        Return StrOut
    End Function
    Public Sub ddl_Fill(ByVal ddl As DropDownList, _
                        ByVal dr As SqlDataReader, _
                        ByVal DataValueField As String, _
                        ByVal DataTextField As String)
        If Not ddl.AppendDataBoundItems Then
            ddl.Items.Clear()
        End If
        Do While dr.Read
            ddl.Items.Add(New ListItem(GetTextValue(dr, DataTextField), GetKeyValue(dr, DataValueField)))
        Loop
    End Sub


    Public Function DBTilde(ByVal Expresion As String) As String
        Dim nCount As Long
        Dim strOut As String = String.Empty
        Dim Letra As String = String.Empty
        Dim Comodin As String = String.Empty
        Dim Filtro As String = String.Empty
        Static letras(7) As String

        letras(1) = "AÁÀÂÄ"
        letras(2) = "EÉÈÊË"
        letras(3) = "IÍÌÎÏYÝŸ"
        letras(4) = "OÓÒÔÖ0"
        letras(5) = "UÚÙÛÜ"
        letras(6) = "SCZ"
        letras(7) = "JG"

        For nCount = 1 To Expresion.Length
            Letra = Expresion.Chars(nCount - 1)
            Filtro = vbNullString
            For Each Comodin In letras
                If InStr(Comodin, Letra, CompareMethod.Text) > 0 Then
                    Filtro = "[" & Comodin & "]"
                    Exit For
                End If
            Next
            If String.IsNullOrEmpty(Filtro) Then Filtro = Letra
            strOut = strOut & Filtro
        Next
        Return strOut.ToUpper
    End Function

    Public Function objGeneraCodDoc(ByVal FechaActual As Date) As String ' Genera el Código de Documento
        Dim sql As String
        Dim Time As String
        Dim pcDocCodigo As String = ""

        sql = " SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED " & _
            " BEGIN TRAN " & _
            " select getdate()" & _
            " COMMIT TRAN "
        Time = Format(Date.Now, "HHmmss")
        Randomize()
        If pcDocCodigo = vbNullString Then pcDocCodigo = Left(Format(FechaActual, "MMddyyyyHHmmss") & Chr(Rnd(Time) * 50 + 60) & Chr(Rnd(Time) * 50 + 60) & Chr(Rnd(Time) * 50 + 60) & Chr(Rnd(Time) * 50 + 60), 18)
        pcDocCodigo = Replace(pcDocCodigo, "=", "i")
        pcDocCodigo = Replace(pcDocCodigo, ";", "i")
        pcDocCodigo = Replace(pcDocCodigo, "\", "i")
        pcDocCodigo = Replace(pcDocCodigo, "/", "i")
        pcDocCodigo = Replace(pcDocCodigo, ":", "i")
        Return pcDocCodigo
    End Function

End Class
