<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWizConfiguration
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWizConfiguration))
        Me.NavBarTask = New DevExpress.XtraNavBar.NavBarControl()
        Me.cfgServer = New DevExpress.XtraNavBar.NavBarGroup()
        Me.itecfgRegServer = New DevExpress.XtraNavBar.NavBarItem()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.PicBoton = New DevExpress.XtraEditors.GroupControl()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.NavBarTask, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicBoton, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PicBoton.SuspendLayout()
        Me.SuspendLayout()
        '
        'NavBarTask
        '
        Me.NavBarTask.ActiveGroup = Me.cfgServer
        Me.NavBarTask.Groups.AddRange(New DevExpress.XtraNavBar.NavBarGroup() {Me.cfgServer})
        Me.NavBarTask.Items.AddRange(New DevExpress.XtraNavBar.NavBarItem() {Me.itecfgRegServer})
        Me.NavBarTask.Location = New System.Drawing.Point(12, 155)
        Me.NavBarTask.Name = "NavBarTask"
        Me.NavBarTask.OptionsNavPane.ExpandedWidth = 217
        Me.NavBarTask.Size = New System.Drawing.Size(217, 498)
        Me.NavBarTask.StoreDefaultPaintStyleName = True
        Me.NavBarTask.TabIndex = 0
        Me.NavBarTask.Text = "NavBar"
        '
        'cfgServer
        '
        Me.cfgServer.Caption = "Configuration Server"
        Me.cfgServer.Expanded = True
        Me.cfgServer.ItemLinks.AddRange(New DevExpress.XtraNavBar.NavBarItemLink() {New DevExpress.XtraNavBar.NavBarItemLink(Me.itecfgRegServer)})
        Me.cfgServer.Name = "cfgServer"
        '
        'itecfgRegServer
        '
        Me.itecfgRegServer.Caption = "Register Server"
        Me.itecfgRegServer.Name = "itecfgRegServer"
        Me.itecfgRegServer.Tag = "FrmWizRegServer"
        '
        'PanelControl1
        '
        Me.PanelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PanelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PanelControl1.Appearance.Image = CType(resources.GetObject("PanelControl1.Appearance.Image"), System.Drawing.Image)
        Me.PanelControl1.Appearance.Options.UseBackColor = True
        Me.PanelControl1.Appearance.Options.UseForeColor = True
        Me.PanelControl1.Appearance.Options.UseImage = True
        Me.PanelControl1.ContentImage = CType(resources.GetObject("PanelControl1.ContentImage"), System.Drawing.Image)
        Me.PanelControl1.Location = New System.Drawing.Point(13, 4)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(216, 145)
        Me.PanelControl1.TabIndex = 1
        '
        'PicBoton
        '
        Me.PicBoton.Controls.Add(Me.Button1)
        Me.PicBoton.Location = New System.Drawing.Point(0, 688)
        Me.PicBoton.Name = "PicBoton"
        Me.PicBoton.Size = New System.Drawing.Size(229, 75)
        Me.PicBoton.TabIndex = 5
        Me.PicBoton.Text = "Acciones"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(83, 35)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Salir"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmWizConfiguration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(259, 763)
        Me.ControlBox = False
        Me.Controls.Add(Me.PicBoton)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.NavBarTask)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmWizConfiguration"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Task Bar Integration"
        CType(Me.NavBarTask, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicBoton, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PicBoton.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NavBarTask As DevExpress.XtraNavBar.NavBarControl
    Friend WithEvents cfgServer As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents itecfgRegServer As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PicBoton As DevExpress.XtraEditors.GroupControl
    Friend WithEvents Button1 As System.Windows.Forms.Button

    

End Class
