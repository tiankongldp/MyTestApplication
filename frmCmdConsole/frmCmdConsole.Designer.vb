<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCmdConsole
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
        Me.btnCaclPassword = New System.Windows.Forms.Button()
        Me.txbOutput = New System.Windows.Forms.TextBox()
        Me.txbInput = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnCaclPassword)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.txbOutput)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txbInput)
        Me.SplitContainer1.Size = New System.Drawing.Size(740, 387)
        Me.SplitContainer1.SplitterDistance = 139
        Me.SplitContainer1.TabIndex = 2
        '
        'btnCaclPassword
        '
        Me.btnCaclPassword.Location = New System.Drawing.Point(32, 114)
        Me.btnCaclPassword.Name = "btnCaclPassword"
        Me.btnCaclPassword.Size = New System.Drawing.Size(75, 23)
        Me.btnCaclPassword.TabIndex = 0
        Me.btnCaclPassword.Text = "生成密码"
        Me.btnCaclPassword.UseVisualStyleBackColor = True
        '
        'txbOutput
        '
        Me.txbOutput.BackColor = System.Drawing.Color.White
        Me.txbOutput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txbOutput.Location = New System.Drawing.Point(0, 21)
        Me.txbOutput.Multiline = True
        Me.txbOutput.Name = "txbOutput"
        Me.txbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txbOutput.Size = New System.Drawing.Size(597, 366)
        Me.txbOutput.TabIndex = 0
        '
        'txbInput
        '
        Me.txbInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txbInput.Dock = System.Windows.Forms.DockStyle.Top
        Me.txbInput.Location = New System.Drawing.Point(0, 0)
        Me.txbInput.Name = "txbInput"
        Me.txbInput.Size = New System.Drawing.Size(597, 21)
        Me.txbInput.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(64, 221)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmCmdConsole
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(740, 387)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmCmdConsole"
        Me.Text = "Form1"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents txbOutput As System.Windows.Forms.TextBox
    Friend WithEvents txbInput As System.Windows.Forms.TextBox
    Friend WithEvents btnCaclPassword As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
