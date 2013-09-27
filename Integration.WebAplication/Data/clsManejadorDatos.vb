Imports Microsoft.VisualBasic
Imports System.IO

Public Class clsManejadorDatos

    Public Function obj_UpFiles(ByVal FleArchivo As FileUpload, ByVal ImgRuta As String, Optional ByVal NewFileName As String = "") As Boolean

        Try
            Dim Exist As Boolean
            Dim RutNewFileName As String = ImgRuta
            System.IO.Directory.CreateDirectory(ImgRuta)

            If NewFileName <> String.Empty Then
                'ImgRuta += "\" & Replace(Path.GetFileName(FleArchivo.FileName), " ", "")
                ImgRuta += "\" & NewFileName
            Else
                ImgRuta += "\" & Path.GetFileName(FleArchivo.FileName)
            End If

            If FleArchivo.HasFile Then

                If System.IO.File.Exists(ImgRuta) = False Then

                    If NewFileName = String.Empty Then
                        FleArchivo.PostedFile.SaveAs(ImgRuta)
                    Else
                        FleArchivo.PostedFile.SaveAs(RutNewFileName & "\" & NewFileName)
                    End If

                    Exist = False
                Else
                    Exist = True
                End If
            End If
            Return Exist
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
