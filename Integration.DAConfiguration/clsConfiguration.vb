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
End Class
