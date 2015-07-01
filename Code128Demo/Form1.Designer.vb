<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.btnCode128A = New System.Windows.Forms.Button()
        Me.btnCode128B = New System.Windows.Forms.Button()
        Me.btnCode128C = New System.Windows.Forms.Button()
        Me.btnEna128 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(80, 34)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(440, 21)
        Me.TextBox1.TabIndex = 0
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("黑体", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(80, 104)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(440, 27)
        Me.TextBox2.TabIndex = 0
        '
        'btnCode128A
        '
        Me.btnCode128A.Location = New System.Drawing.Point(160, 173)
        Me.btnCode128A.Name = "btnCode128A"
        Me.btnCode128A.Size = New System.Drawing.Size(75, 23)
        Me.btnCode128A.TabIndex = 1
        Me.btnCode128A.Text = "128A"
        Me.btnCode128A.UseVisualStyleBackColor = True
        '
        'btnCode128B
        '
        Me.btnCode128B.Location = New System.Drawing.Point(322, 173)
        Me.btnCode128B.Name = "btnCode128B"
        Me.btnCode128B.Size = New System.Drawing.Size(75, 23)
        Me.btnCode128B.TabIndex = 1
        Me.btnCode128B.Text = "128B"
        Me.btnCode128B.UseVisualStyleBackColor = True
        '
        'btnCode128C
        '
        Me.btnCode128C.Location = New System.Drawing.Point(160, 202)
        Me.btnCode128C.Name = "btnCode128C"
        Me.btnCode128C.Size = New System.Drawing.Size(75, 23)
        Me.btnCode128C.TabIndex = 1
        Me.btnCode128C.Text = "128C"
        Me.btnCode128C.UseVisualStyleBackColor = True
        '
        'btnEna128
        '
        Me.btnEna128.Location = New System.Drawing.Point(322, 204)
        Me.btnEna128.Name = "btnEna128"
        Me.btnEna128.Size = New System.Drawing.Size(75, 23)
        Me.btnEna128.TabIndex = 1
        Me.btnEna128.Text = "ENA"
        Me.btnEna128.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "From:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "To:"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(616, 261)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnEna128)
        Me.Controls.Add(Me.btnCode128C)
        Me.Controls.Add(Me.btnCode128B)
        Me.Controls.Add(Me.btnCode128A)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents btnCode128A As System.Windows.Forms.Button
    Friend WithEvents btnCode128B As System.Windows.Forms.Button
    Friend WithEvents btnCode128C As System.Windows.Forms.Button
    Friend WithEvents btnEna128 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
