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

    Private Sub DataGridView1_CellContentClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
        If e.ColumnIndex = 2 Then
            If e.RowIndex >= 0 Then
                System.Diagnostics.Process.Start(Me.DataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString())
            End If
        End If
    End Sub
    
    Private Sub btnLoadXML_Click(sender As System.Object, e As System.EventArgs) Handles btnLoadXML.Click
        Me.OpenFileDialog1.Filter = "程序文件|*.xml"
        Me.OpenFileDialog1.Multiselect = False
        If Me.OpenFileDialog1.ShowDialog() <> DialogResult.Cancel Then
            Dim filename As String = Me.OpenFileDialog1.FileName
            Dim xmldoc As XmlDocument = New XmlDocument()
            Try
                Dim fs As FileStream = New FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
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
                    Me.DataGridView1.Rows(num).Cells(3).Value = "http://" & ip & ":" & port & "/"
                Next
                
            Next
            
        End If
        Me.stoppage()
        Me.curnum = -1
    End Sub

    Private Sub btnCombineIP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCombineIP.Click
        Me.OpenFileDialog1.Filter = "地址文件|*.txt"
        Me.OpenFileDialog1.Multiselect = False
        If Me.OpenFileDialog1.ShowDialog() <> DialogResult.Cancel Then
            Dim reader As StreamReader = Nothing
            Dim writer As StreamWriter = Nothing

            Try
                reader = New StreamReader(Me.OpenFileDialog1.FileName)
                writer = New StreamWriter(Me.OpenFileDialog1.FileName & ".resole.txt", False)
                Dim ips As String = reader.ReadLine()
                Dim nets As String() = New String() {"8", "16", "24", "32"}

                While Not IsNothing(ips)
                    Dim ipstart As String = ips.Split()(0)
                    Dim ipend As String = ips.Split()(1)
                    Dim ip As String = ""

                    For i As Integer = 0 To ipstart.Split(".").Length - 1
                        If ipstart.Split(".")(i) <> ipend.Split(".")(i) Then
                            ip &= ipstart.Split(".")(i) & "-" & ipend.Split(".")(i)
                            If i <> 3 Then
                                ip &= "."
                            End If

                            For j As Integer = i + 1 To ipstart.Split(".").Length - 1
                                ip &= ipstart.Split(".")(j)
                                If j <> 3 Then
                                    ip &= "."
                                End If
                            Next
                            ip.TrimEnd(New Char() {"."})
                            ip &= "/" & nets(i)

                            Exit For
                        Else
                            ip &= ipstart.Split(".")(i)
                            If i <> 3 Then
                                ip &= "."
                            End If
                        End If
                    Next
                    ips = reader.ReadLine()
                    writer.WriteLine(ip)
                End While
                reader.Close()
                writer.Flush()
                writer.Close()
            Catch ex As Exception
                If Not IsNothing(reader) Then
                    reader.Close()
                End If
                If Not IsNothing(writer) Then
                    writer.Close()
                End If
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnClearHost_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClearHost.Click
        Me.OpenFileDialog1.Filter = "程序文件|*.xml"
        Me.OpenFileDialog1.Multiselect = False
        If Me.OpenFileDialog1.ShowDialog() <> DialogResult.Cancel Then
            Dim filename As String = Me.OpenFileDialog1.FileName
            Dim xmldoc As XmlDocument = New XmlDocument()
            Try
                Dim fs As FileStream = New FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
                xmldoc.Load(fs)
                fs.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Return
            End Try
            Dim hostlist As XmlNodeList = xmldoc.SelectNodes("/nmaprun/host")
            Dim found As Boolean = False

            For Each node As XmlNode In hostlist
                found = False
                Dim portlist As XmlNodeList = node.SelectNodes("ports/port")
                For Each portnode As XmlNode In portlist
                    Dim port As String = portnode.Attributes("portid").InnerText

                    Dim script As XmlNode = portnode.SelectSingleNode("script")
                    If Not IsNothing(script) Then
                        found = True
                        If script.InnerText.Contains("index.html") Then
                            found = False
                        Else
                            Exit For
                        End If
                    End If
                Next

                If Not found Then
                    xmldoc.SelectSingleNode("/nmaprun").RemoveChild(node)
                End If
            Next

            xmldoc.Save(Me.OpenFileDialog1.FileName & ".clear.xml")
        End If
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
