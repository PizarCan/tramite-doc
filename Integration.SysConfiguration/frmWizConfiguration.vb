Public Class frmWizConfiguration 
    Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
    Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height

    Private Sub frmWizConfiguration_Click(sender As Object, e As System.EventArgs) Handles Me.Click

    End Sub
   

    Private Sub frmWizConfiguration_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick

    End Sub

    Private Sub frmWizConfiguration_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        'NavBarTask.Height=
        Me.Height = screenWidth - 890
        Me.Top = 5
        Me.Left = 1
        If Me.WindowState = FormWindowState.Minimized Then Exit Sub
        NavBarTask.Height = Me.Height - picBoton.Height
        picBoton.Top = NavBarTask.Height
    End Sub


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs)
        Me.Width = IIf(Me.Width = 247, 5, 247)
    End Sub

    Private Sub frmWizConfiguration_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub NavBarTask_Click(sender As System.Object, e As System.EventArgs) Handles NavBarTask.Click

    End Sub
End Class