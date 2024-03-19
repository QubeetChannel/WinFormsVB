<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        FileButton = New MenuStrip()
        ToolStripMenuItem1 = New ToolStripMenuItem()
        FileMenuStrip = New ToolStripMenuItem()
        OpenExcelFileStrip = New ToolStripMenuItem()
        SaveFileStrip = New ToolStripMenuItem()
        OpenFileDialog = New OpenFileDialog()
        TabPage1 = New TabPage()
        CustomDataGridView1 = New CustomDataGridView()
        TabControl = New TabControl()
        SaveFileDialog = New OpenFileDialog()
        FileButton.SuspendLayout()
        TabPage1.SuspendLayout()
        CType(CustomDataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        TabControl.SuspendLayout()
        SuspendLayout()
        ' 
        ' FileButton
        ' 
        FileButton.GripMargin = New Padding(0)
        FileButton.Items.AddRange(New ToolStripItem() {ToolStripMenuItem1, FileMenuStrip})
        FileButton.Location = New Point(0, 0)
        FileButton.Name = "FileButton"
        FileButton.Padding = New Padding(0)
        FileButton.Size = New Size(884, 27)
        FileButton.TabIndex = 3
        FileButton.Text = "FileMenuStrip"
        ' 
        ' ToolStripMenuItem1
        ' 
        ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        ToolStripMenuItem1.Size = New Size(12, 27)
        ' 
        ' FileMenuStrip
        ' 
        FileMenuStrip.DropDownItems.AddRange(New ToolStripItem() {OpenExcelFileStrip, SaveFileStrip})
        FileMenuStrip.Name = "FileMenuStrip"
        FileMenuStrip.Padding = New Padding(4)
        FileMenuStrip.Size = New Size(48, 27)
        FileMenuStrip.Text = "Файл"
        ' 
        ' OpenExcelFileStrip
        ' 
        OpenExcelFileStrip.Name = "OpenExcelFileStrip"
        OpenExcelFileStrip.Size = New Size(183, 22)
        OpenExcelFileStrip.Text = "Открыть файл Excel"
        ' 
        ' SaveFileStrip
        ' 
        SaveFileStrip.Name = "SaveFileStrip"
        SaveFileStrip.Size = New Size(183, 22)
        SaveFileStrip.Text = "Сохранить файл"
        ' 
        ' OpenFileDialog
        ' 
        OpenFileDialog.FileName = "OpenFileDialog"
        OpenFileDialog.Filter = "Excel|*xlsx;*.xls"
        OpenFileDialog.Title = "Выберите файл Excel"
        ' 
        ' TabPage1
        ' 
        TabPage1.Controls.Add(CustomDataGridView1)
        TabPage1.Location = New Point(4, 4)
        TabPage1.Name = "TabPage1"
        TabPage1.Padding = New Padding(3)
        TabPage1.Size = New Size(876, 406)
        TabPage1.TabIndex = 0
        TabPage1.Text = "TabPage1"
        TabPage1.UseVisualStyleBackColor = True
        ' 
        ' CustomDataGridView1
        ' 
        CustomDataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        CustomDataGridView1.Dock = DockStyle.Fill
        CustomDataGridView1.Location = New Point(3, 3)
        CustomDataGridView1.Name = "CustomDataGridView1"
        CustomDataGridView1.Size = New Size(870, 400)
        CustomDataGridView1.TabIndex = 0
        ' 
        ' TabControl
        ' 
        TabControl.Alignment = TabAlignment.Bottom
        TabControl.Controls.Add(TabPage1)
        TabControl.Dock = DockStyle.Fill
        TabControl.Location = New Point(0, 27)
        TabControl.Name = "TabControl"
        TabControl.SelectedIndex = 0
        TabControl.Size = New Size(884, 434)
        TabControl.TabIndex = 4
        ' 
        ' SaveFileDialog
        ' 
        SaveFileDialog.FileName = "SaveFileDialog"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(884, 461)
        Controls.Add(TabControl)
        Controls.Add(FileButton)
        MainMenuStrip = FileButton
        Name = "Form1"
        Text = "Form1"
        FileButton.ResumeLayout(False)
        FileButton.PerformLayout()
        TabPage1.ResumeLayout(False)
        CType(CustomDataGridView1, ComponentModel.ISupportInitialize).EndInit()
        TabControl.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents FileButton As MenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents FileMenuStrip As ToolStripMenuItem
    Friend WithEvents OpenExcelFileStrip As ToolStripMenuItem
    Friend WithEvents OpenFileDialog As OpenFileDialog
    Friend WithEvents SaveFileStrip As ToolStripMenuItem
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabControl As TabControl
    Friend WithEvents SaveFileDialog As OpenFileDialog
    Friend WithEvents CustomDataGridView1 As CustomDataGridView

End Class
