<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHook
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.picBoxMouse = New System.Windows.Forms.PictureBox()
        Me.picBoxKeyBoard = New System.Windows.Forms.PictureBox()
        Me.btnMouseUnReg = New System.Windows.Forms.Button()
        Me.btnMouseReg = New System.Windows.Forms.Button()
        Me.btnKeyBoardUnReg = New System.Windows.Forms.Button()
        Me.btnKeyBoardReg = New System.Windows.Forms.Button()
        Me.listboxHookedContent = New System.Windows.Forms.ListBox()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.picBoxMouse, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picBoxKeyBoard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.picBoxMouse)
        Me.SplitContainer1.Panel1.Controls.Add(Me.picBoxKeyBoard)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnMouseUnReg)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnMouseReg)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnKeyBoardUnReg)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnKeyBoardReg)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.listboxHookedContent)
        Me.SplitContainer1.Size = New System.Drawing.Size(596, 417)
        Me.SplitContainer1.SplitterDistance = 150
        Me.SplitContainer1.TabIndex = 0
        '
        'picBoxMouse
        '
        Me.picBoxMouse.Image = Global.DotNetHookDemo.My.Resources.Resources.ImgOff
        Me.picBoxMouse.Location = New System.Drawing.Point(100, 251)
        Me.picBoxMouse.Name = "picBoxMouse"
        Me.picBoxMouse.Size = New System.Drawing.Size(37, 33)
        Me.picBoxMouse.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picBoxMouse.TabIndex = 1
        Me.picBoxMouse.TabStop = False
        '
        'picBoxKeyBoard
        '
        Me.picBoxKeyBoard.Image = Global.DotNetHookDemo.My.Resources.Resources.ImgOff
        Me.picBoxKeyBoard.Location = New System.Drawing.Point(100, 115)
        Me.picBoxKeyBoard.Name = "picBoxKeyBoard"
        Me.picBoxKeyBoard.Size = New System.Drawing.Size(37, 33)
        Me.picBoxKeyBoard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picBoxKeyBoard.TabIndex = 1
        Me.picBoxKeyBoard.TabStop = False
        '
        'btnMouseUnReg
        '
        Me.btnMouseUnReg.Location = New System.Drawing.Point(20, 275)
        Me.btnMouseUnReg.Name = "btnMouseUnReg"
        Me.btnMouseUnReg.Size = New System.Drawing.Size(51, 23)
        Me.btnMouseUnReg.TabIndex = 0
        Me.btnMouseUnReg.Text = "卸载"
        Me.btnMouseUnReg.UseVisualStyleBackColor = True
        '
        'btnMouseReg
        '
        Me.btnMouseReg.Location = New System.Drawing.Point(21, 234)
        Me.btnMouseReg.Name = "btnMouseReg"
        Me.btnMouseReg.Size = New System.Drawing.Size(51, 23)
        Me.btnMouseReg.TabIndex = 0
        Me.btnMouseReg.Text = "安装"
        Me.btnMouseReg.UseVisualStyleBackColor = True
        '
        'btnKeyBoardUnReg
        '
        Me.btnKeyBoardUnReg.Location = New System.Drawing.Point(19, 142)
        Me.btnKeyBoardUnReg.Name = "btnKeyBoardUnReg"
        Me.btnKeyBoardUnReg.Size = New System.Drawing.Size(51, 23)
        Me.btnKeyBoardUnReg.TabIndex = 0
        Me.btnKeyBoardUnReg.Text = "卸载"
        Me.btnKeyBoardUnReg.UseVisualStyleBackColor = True
        '
        'btnKeyBoardReg
        '
        Me.btnKeyBoardReg.Location = New System.Drawing.Point(19, 96)
        Me.btnKeyBoardReg.Name = "btnKeyBoardReg"
        Me.btnKeyBoardReg.Size = New System.Drawing.Size(51, 23)
        Me.btnKeyBoardReg.TabIndex = 0
        Me.btnKeyBoardReg.Text = "安装"
        Me.btnKeyBoardReg.UseVisualStyleBackColor = True
        '
        'listboxHookedContent
        '
        Me.listboxHookedContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listboxHookedContent.FormattingEnabled = True
        Me.listboxHookedContent.ItemHeight = 12
        Me.listboxHookedContent.Location = New System.Drawing.Point(0, 0)
        Me.listboxHookedContent.Name = "listboxHookedContent"
        Me.listboxHookedContent.Size = New System.Drawing.Size(442, 417)
        Me.listboxHookedContent.TabIndex = 0
        '
        'frmHook
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(596, 417)
        Me.Controls.Add(Me.SplitContainer1)
        Me.KeyPreview = True
        Me.Name = "frmHook"
        Me.Text = "键盘记录"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.picBoxMouse, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picBoxKeyBoard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents listboxHookedContent As System.Windows.Forms.ListBox
    Friend WithEvents picBoxMouse As System.Windows.Forms.PictureBox
    Friend WithEvents picBoxKeyBoard As System.Windows.Forms.PictureBox
    Friend WithEvents btnMouseUnReg As System.Windows.Forms.Button
    Friend WithEvents btnMouseReg As System.Windows.Forms.Button
    Friend WithEvents btnKeyBoardUnReg As System.Windows.Forms.Button
    Friend WithEvents btnKeyBoardReg As System.Windows.Forms.Button

End Class
