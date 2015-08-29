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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.AutoWebcamjpg1 = New MultiWebPage.AutoWebcamjpg()
        Me.AutoWebcamjpg2 = New MultiWebPage.AutoWebcamjpg()
        Me.AutoWebcamjpg3 = New MultiWebPage.AutoWebcamjpg()
        Me.AutoWebcamjpg4 = New MultiWebPage.AutoWebcamjpg()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.btnLoadNext = New System.Windows.Forms.Button()
        Me.LbtnoadPre = New System.Windows.Forms.Button()
        Me.btnLoadXML = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.No = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PORT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.url = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TableLayoutPanel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(738, 498)
        Me.SplitContainer1.SplitterDistance = 555
        Me.SplitContainer1.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.AutoWebcamjpg1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.AutoWebcamjpg2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.AutoWebcamjpg3, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.AutoWebcamjpg4, 1, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(553, 496)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'AutoWebcamjpg1
        '
        Me.AutoWebcamjpg1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AutoWebcamjpg1.Location = New System.Drawing.Point(5, 5)
        Me.AutoWebcamjpg1.Name = "AutoWebcamjpg1"
        Me.AutoWebcamjpg1.Size = New System.Drawing.Size(267, 239)
        Me.AutoWebcamjpg1.TabIndex = 0
        '
        'AutoWebcamjpg2
        '
        Me.AutoWebcamjpg2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AutoWebcamjpg2.Location = New System.Drawing.Point(280, 5)
        Me.AutoWebcamjpg2.Name = "AutoWebcamjpg2"
        Me.AutoWebcamjpg2.Size = New System.Drawing.Size(268, 239)
        Me.AutoWebcamjpg2.TabIndex = 1
        '
        'AutoWebcamjpg3
        '
        Me.AutoWebcamjpg3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AutoWebcamjpg3.Location = New System.Drawing.Point(5, 252)
        Me.AutoWebcamjpg3.Name = "AutoWebcamjpg3"
        Me.AutoWebcamjpg3.Size = New System.Drawing.Size(267, 239)
        Me.AutoWebcamjpg3.TabIndex = 2
        '
        'AutoWebcamjpg4
        '
        Me.AutoWebcamjpg4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AutoWebcamjpg4.Location = New System.Drawing.Point(280, 252)
        Me.AutoWebcamjpg4.Name = "AutoWebcamjpg4"
        Me.AutoWebcamjpg4.Size = New System.Drawing.Size(268, 239)
        Me.AutoWebcamjpg4.TabIndex = 3
        '
        'SplitContainer2
        '
        Me.SplitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.btnLoadNext)
        Me.SplitContainer2.Panel1.Controls.Add(Me.LbtnoadPre)
        Me.SplitContainer2.Panel1.Controls.Add(Me.btnLoadXML)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.DataGridView1)
        Me.SplitContainer2.Size = New System.Drawing.Size(179, 498)
        Me.SplitContainer2.SplitterDistance = 96
        Me.SplitContainer2.TabIndex = 1
        '
        'btnLoadNext
        '
        Me.btnLoadNext.Location = New System.Drawing.Point(97, 53)
        Me.btnLoadNext.Name = "btnLoadNext"
        Me.btnLoadNext.Size = New System.Drawing.Size(56, 23)
        Me.btnLoadNext.TabIndex = 1
        Me.btnLoadNext.Text = "后四个"
        Me.btnLoadNext.UseVisualStyleBackColor = True
        '
        'LbtnoadPre
        '
        Me.LbtnoadPre.Location = New System.Drawing.Point(20, 53)
        Me.LbtnoadPre.Name = "LbtnoadPre"
        Me.LbtnoadPre.Size = New System.Drawing.Size(56, 23)
        Me.LbtnoadPre.TabIndex = 1
        Me.LbtnoadPre.Text = "前四个"
        Me.LbtnoadPre.UseVisualStyleBackColor = True
        '
        'btnLoadXML
        '
        Me.btnLoadXML.Location = New System.Drawing.Point(20, 12)
        Me.btnLoadXML.Name = "btnLoadXML"
        Me.btnLoadXML.Size = New System.Drawing.Size(133, 23)
        Me.btnLoadXML.TabIndex = 0
        Me.btnLoadXML.Text = "加载扫描结果xml"
        Me.btnLoadXML.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.No, Me.IP, Me.PORT, Me.url})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.GridColor = System.Drawing.SystemColors.AppWorkspace
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(177, 396)
        Me.DataGridView1.TabIndex = 0
        '
        'No
        '
        Me.No.HeaderText = "No"
        Me.No.Name = "No"
        Me.No.ReadOnly = True
        Me.No.Width = 30
        '
        'IP
        '
        Me.IP.HeaderText = "IP"
        Me.IP.Name = "IP"
        Me.IP.ReadOnly = True
        Me.IP.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.IP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'PORT
        '
        Me.PORT.HeaderText = "PORT"
        Me.PORT.Name = "PORT"
        Me.PORT.ReadOnly = True
        Me.PORT.Width = 50
        '
        'url
        '
        Me.url.HeaderText = "URL"
        Me.url.Name = "url"
        Me.url.ReadOnly = True
        Me.url.Visible = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(738, 498)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnLoadNext As System.Windows.Forms.Button
    Friend WithEvents LbtnoadPre As System.Windows.Forms.Button
    Friend WithEvents btnLoadXML As System.Windows.Forms.Button
    Friend WithEvents AutoWebcamjpg1 As MultiWebPage.AutoWebcamjpg
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents No As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PORT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents url As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents AutoWebcamjpg2 As MultiWebPage.AutoWebcamjpg
    Friend WithEvents AutoWebcamjpg3 As MultiWebPage.AutoWebcamjpg
    Friend WithEvents AutoWebcamjpg4 As MultiWebPage.AutoWebcamjpg

End Class
