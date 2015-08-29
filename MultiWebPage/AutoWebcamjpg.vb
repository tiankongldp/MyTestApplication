Imports System.Timers

Public Class AutoWebcamjpg
    Protected WithEvents timer As Timer = New Timer()

    Protected url As String = ""
    Protected addHeader As String = ""

    Public Sub Start(ByVal url As String, ByVal addheader As String, Optional ByVal interval As Integer = 1)
        Me.url = url
        Me.addHeader = addheader
        timer.Interval = interval * 1000
        timer.Enabled = True

    End Sub

    Public Sub StopR()
        Me.timer.Enabled = False
    End Sub

    Public Sub timer_tick() Handles timer.Elapsed
        Me.WebBrowser1.Navigate(Me.url, "", Nothing, Me.addHeader)
    End Sub
End Class
