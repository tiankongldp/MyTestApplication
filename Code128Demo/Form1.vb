Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles Me.Load
        TextBox1.Text = "000040000000000000000008"
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnCode128A.Click
        TextBox2.Text = ToCode128A(TextBox1.Text)
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles btnCode128B.Click
        TextBox2.Text = ToCode128B(TextBox1.Text)
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles btnCode128C.Click
        Try
            TextBox2.Text = ToCode128C(TextBox1.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            TextBox2.Text = ""
        End Try
    End Sub

    Function ToCode128A(ByVal s As String) As String
        Dim ns As String
        Dim total As Long
        ns = ""
        If Len(s) > 0 Then
            total = 103 ' Start Code
            Dim i As Integer, l As Integer
            l = Len(s)
            For i = 0 To l - 1
                Dim v = Mid(s, i + 1, 1)
                ns = ns + v
                total = total + (i + 1) * (Asc(v) - 32)
            Next
            Dim checkCode As String '生成验证码
            checkCode = "" & (total Mod 103)
            ns = getChar(103) + ns + getChar(checkCode) + getChar(106)
            ToCode128A = ns
        Else
            ToCode128A = ""
        End If
    End Function

    Function ToCode128B(ByVal s As String) As String
        Dim ns As String
        Dim total As Long
        ns = ""
        If Len(s) > 0 Then
            total = 104 ' Start Code
            Dim i As Integer, l As Integer
            l = Len(s)
            For i = 0 To l - 1
                Dim v = Mid(s, i + 1, 1)
                ns = ns + v
                total = total + (i + 1) * (Asc(v) - 32)
            Next
            Dim checkCode As String '生成验证码
            checkCode = "" & (total Mod 103)
            ns = getChar(104) + ns + getChar(checkCode) + getChar(106)
            ToCode128B = ns
        Else
            ToCode128B = ""
        End If
    End Function

    Public Function ToCode128C(ByVal s As String) As String
        ' 使用code128.ttf字体生成Code128C条码
        Dim ns As String
        Dim total As Long
        ns = ""
        If Len(s) > 0 And IsNumeric(s) Then
            total = 105 ' Start Code

            If Len(s) Mod 2 > 0 Then
                s = s + "0" ' 不足偶数位补0
            End If

            Dim i, l As Integer
            l = Len(s) \ 2

            For i = 0 To l - 1
                ns = ns + getChar(Mid(s, i * 2 + 1, 2))
                total = total + (i + 1) * Val(Mid(s, i * 2 + 1, 2))
            Next

            Dim checkCode As String '生成验证码
            checkCode = "" & (total Mod 103)
            ns = getChar(105) + ns + getChar(checkCode) + getChar(106)
            ToCode128C = ns
        Else
            Throw New Exception("code128c码只能是数字！")
            ToCode128C = ""
        End If
    End Function

    Function getChar(ByVal s As String) As String
        Dim c As Integer
        c = Val(s)
        If c = 0 Then
            getChar = " "
        ElseIf c < 95 Then
            REM Asc("!") = 33
            getChar = ChrW(32 + c)
        Else
            getChar = ChrW(100 + c)
        End If
    End Function

End Class







