Imports System.Xml
Imports System.IO

Public Class Form1

    Protected pagelist As List(Of AutoWebcamjpg) = New List(Of AutoWebcamjpg)()
    Protected authstr As String = "Authorization: Basic YWRtaW46YWRtaW4="
    Protected interval As Integer = 2
    Protected curnum As Integer = -1

    Public Sub frm_load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        pagelist.Add(Me.AutoWebcamjpg1)
        pagelist.Add(Me.AutoWebcamjpg2)
        pagelist.Add(Me.AutoWebcamjpg3)
        pagelist.Add(Me.AutoWebcamjpg4)
    End Sub

    Public Sub form1_closing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.stoppage()
    End Sub


    Private Sub LbtnoadPre_Click(sender As System.Object, e As System.EventArgs) Handles LbtnoadPre.Click
        'Me.AutoWebcamjpg1.Start("http://113.44.5.227:81/tmpfs/auto.jpg", Me.authstr, Me.interval)
        If Me.curnum = -1 Then
            Me.curnum = 0
            Me.loadpage(curnum)
        ElseIf Me.curnum - 4 < 0 Then
            Return
        Else
            Me.curnum -= 4
            Me.loadpage(curnum)
        End If
    End Sub

    Private Sub btnLoadNext_Click(sender As System.Object, e As System.EventArgs) Handles btnLoadNext.Click
        If Me.curnum + 4 > Me.DataGridView1.Rows.Count - 1 Then
            Return
        Else
            Me.curnum += 4
            Me.loadpage(curnum)
        End If
    End Sub

    Private Sub btnLoadXML_Click(sender As System.Object, e As System.EventArgs) Handles btnLoadXML.Click
        Me.OpenFileDialog1.Filter = "程序文件|*.xml"
        Me.OpenFileDialog1.Multiselect = False
        If Me.OpenFileDialog1.ShowDialog() <> DialogResult.Cancel Then
            Dim filename As String = Me.OpenFileDialog1.FileName
            Dim xmldoc As XmlDocument = New XmlDocument()
            Try
                Dim fs As FileStream = New FileStream(filename, FileMode.Open)
                xmldoc.Load(fs)
                fs.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Return
            End Try
            Dim hostlist As XmlNodeList = xmldoc.SelectNodes("/nmaprun/host")

            Me.DataGridView1.Rows.Clear()

            For Each node As XmlNode In hostlist
                Dim ip As String = node.SelectSingleNode("address").Attributes("addr").InnerText

                Dim portlist As XmlNodeList = node.SelectNodes("ports/port")
                For Each portnode As XmlNode In portlist
                    Dim port As String = portnode.Attributes("portid").InnerText

                    Dim script As XmlNode = portnode.SelectSingleNode("script")
                    If IsNothing(script) Then
                        Continue For
                    End If
                    If Not script.Attributes("output").InnerText.Contains("realm=index.html") Then
                        Continue For
                    End If

                    Dim num As Integer = Me.DataGridView1.Rows.Add()
                    Me.DataGridView1.Rows(num).Cells(0).Value = num.ToString()
                    Me.DataGridView1.Rows(num).Cells(1).Value = ip
                    Me.DataGridView1.Rows(num).Cells(2).Value = port
                    Me.DataGridView1.Rows(num).Cells(3).Value = "http://" & ip & port & "/"
                Next
                
            Next
            
        End If
        Me.stoppage()
        Me.curnum = -1
    End Sub

    Private Sub loadpage(ByVal start As Integer)
        Me.stoppage()
        Dim i As Integer = 0
        Me.DataGridView1.ClearSelection()
        Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(start + i).Cells(0)

        While (i < 4 AndAlso start + i < Me.DataGridView1.Rows.Count)
            Me.DataGridView1.Rows(start + i).Selected = True
            Dim ip As String = Me.DataGridView1.Rows(start + i).Cells(1).Value
            Dim port As String = Me.DataGridView1.Rows(start + i).Cells(2).Value
            Dim url As String = "http://" & ip & ":" & port & "/tmpfs/auto.jpg"

            CallByName(Me.pagelist(i), "Start", CallType.Method, url, Me.authstr, Me.interval)
            i += 1
        End While
    End Sub

    Private Sub stoppage()
        For Each autocam As AutoWebcamjpg In Me.pagelist
            autocam.StopR()

        Next
    End Sub
End Class
