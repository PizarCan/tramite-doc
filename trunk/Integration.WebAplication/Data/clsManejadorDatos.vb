Imports Microsoft.VisualBasic
Imports System.IO

Public Class clsManejadorDatos

    Dim i As Integer = 0

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



    Public Sub FillTV_B(ByVal TreeViewControl As TreeView, _
                        ByRef TreeViewItemPreviousValue As String, _
                        ByRef TreeViewItemUp As TreeNode,
                        ByVal dt As DataTable)

        'If Not DataTreeView.HasRows Then Exit Sub

        Dim TreeViewItemPrevious As TreeNode = Nothing
        Dim TreeViewItemCurrentValue As String = String.Empty
        Dim TreeViewItemUpValue As String = String.Empty
        Dim TreeViewItemCurrent As TreeNode = Nothing
        Dim TreeViewItemTemp As TreeNode = Nothing

        Dim Lx, lProx, lSup As Integer

        While i <= dt.Rows.Count - 1

            TreeViewItemCurrentValue = dt(i).Item("cIntJerarquia").ToString

            If TreeViewItemPrevious Is Nothing Then TreeViewItemPrevious = TreeViewItemCurrent
            If TreeViewItemPreviousValue = String.Empty Then TreeViewItemPreviousValue = TreeViewItemCurrentValue
            If TreeViewItemUp IsNot Nothing Then TreeViewItemUpValue = Split(TreeViewItemUp.Value, "/")(0)

            Lx = TreeViewItemPreviousValue.Length
            lProx = TreeViewItemCurrentValue.Length

            lSup = ((lProx \ 2) - 1) * 2
            If lSup < 0 Then lSup = 0

            If Left(TreeViewItemCurrentValue, lSup) = Left(TreeViewItemPreviousValue, lSup) And InStr(1, TreeViewItemCurrentValue, TreeViewItemUpValue) > 0 Then
                If Lx < lProx Then      'AUMENTAR NIVEL
                    TreeViewItemTemp = TreeViewItemPrevious
                    TreeViewItemPreviousValue = String.Empty
                    FillTV_B(TreeViewControl, TreeViewItemPreviousValue, TreeViewItemTemp, dt)
                    TreeViewItemCurrent = AgregarTreeViewNodo_B(TreeViewControl, TreeViewItemUp, dt)
                Else                    'DISMINUIR O MANTENER NIVEL
                    TreeViewItemCurrent = AgregarTreeViewNodo_B(TreeViewControl, TreeViewItemUp, dt)
                End If
                If TreeViewItemCurrent IsNot Nothing Then TreeViewItemPreviousValue = Split(TreeViewItemCurrent.Value, "/")(0)
                TreeViewItemPrevious = TreeViewItemCurrent
            Else
                If Lx >= lProx Then Exit Sub
            End If
            i = i + 1
        End While
    End Sub
     

    Private Function AgregarTreeViewNodo_B(ByVal TreeViewControl As TreeView, ByRef TreeViewItemParent As TreeNode, ByVal dt As DataTable) As TreeNode
        Dim TreeViewItemCurrent As New TreeNode
        Dim cIntNombre As String = String.Empty
        Try
            If dt(i).Item("cIntNombre").ToString = "" Then
                cIntNombre = String.Empty
            Else
                cIntNombre = "    |    " + dt(i).Item("cIntNombre").ToString
            End If

            TreeViewItemCurrent = New TreeNode(dt(i).Item("cIntDescripcion").ToString + cIntNombre, _
                                           dt(i).Item("cIntJerarquia").ToString + "/" + dt(i).Item("nIntCodigo").ToString)
 
            If TreeViewItemParent Is Nothing Then
                TreeViewControl.Nodes(0).ChildNodes.Add(TreeViewItemCurrent)
            Else
                TreeViewItemParent.ChildNodes.Add(TreeViewItemCurrent)
            End If
        Catch
        End Try

        Return TreeViewItemCurrent
    End Function


End Class
