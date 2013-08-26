Public Class clsConfiguration
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
        'Dim da As New SqlDataAdapter(sql, cn)
        'da.SelectCommand.Transaction = MyTrans
        'Dim ds As New DataSet
        'da.Fill(ds, "Fecha")
        Randomize()
        'FechaActual = ds.Tables("Fecha").Rows.Item(0).Item(0)
        If pcDocCodigo = vbNullString Then pcDocCodigo = Left(Format(FechaActual, "MMddyyyyHHmmss") & Chr(Rnd(Time) * 50 + 60) & Chr(Rnd(Time) * 50 + 60) & Chr(Rnd(Time) * 50 + 60) & Chr(Rnd(Time) * 50 + 60), 18)
        pcDocCodigo = Replace(pcDocCodigo, "=", "i")
        pcDocCodigo = Replace(pcDocCodigo, ";", "i")
        pcDocCodigo = Replace(pcDocCodigo, "\", "i")
        pcDocCodigo = Replace(pcDocCodigo, "/", "i")
        pcDocCodigo = Replace(pcDocCodigo, ":", "i")
        Return pcDocCodigo
    End Function
End Class
