Imports System.Net
Imports System.Management
Imports System.IO
Imports System.IO.FileStream

Public Class frmCmdConsole

    '命令执行进程
    Public Declare Function Init Lib "229900\SiInterface.dll" Alias "INIT" (ByVal pErrMsg As String) As Integer
    Public Declare Function Init1 Lib "220100\SiInterface.dll" Alias "INIT" (ByVal pErrMsg As String) As Integer
    Public Declare Function InitDLL Lib "dblib.dll" Alias "InitDLL" () As Integer

    '委托定义
    Private Delegate Sub AppendTestHandler(ByVal Str As String)
    Private WithEvents p As Process

    ''' <summary>
    ''' 初始化进程信息
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmCmdConsole_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        p = New Process()
        p.StartInfo.FileName = "cmd.exe"

        p.StartInfo.UseShellExecute = False
        p.StartInfo.RedirectStandardInput = True
        p.StartInfo.RedirectStandardOutput = True
        p.StartInfo.RedirectStandardError = True
        p.StartInfo.CreateNoWindow = True

        p.Start()

        p.BeginOutputReadLine()
        p.BeginErrorReadLine()
    End Sub

    ''' <summary>
    ''' 结束时关闭进程
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmCmdConsole_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        p.Close()
    End Sub

    ''' <summary>
    ''' 回车键按下
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtOutput_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbInput.KeyDown
        If e.KeyValue = 13 Then
            p.StandardInput.WriteLine(txbInput.Text)
            txbInput.Text = ""
        End If
    End Sub

    ''' <summary>
    ''' 产生正常输出信息
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub p_OutputDataReceived(ByVal sender As System.Object, ByVal e As System.Diagnostics.DataReceivedEventArgs) Handles p.OutputDataReceived
        Me.Invoke(New AppendTestHandler(AddressOf AppendTestToTxt), e.Data)
    End Sub

    ''' <summary>
    ''' 产生错误输出信息
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub p_ErrorDataReceived(ByVal sender As System.Object, ByVal e As System.Diagnostics.DataReceivedEventArgs) Handles p.ErrorDataReceived
        Me.Invoke(New AppendTestHandler(AddressOf AppendTestToTxt), e.Data)
    End Sub

    ''' <summary>
    ''' 委托方法
    ''' </summary>
    ''' <param name="Str"></param>
    ''' <remarks></remarks>
    Private Sub AppendTestToTxt(ByVal Str As String)
        txbOutput.AppendText(Str & vbCrLf)
    End Sub

    Private Sub btnCaclPassword_Click(sender As System.Object, e As System.EventArgs) Handles btnCaclPassword.Click
        Dim sw As StreamWriter = File.CreateText(Application.StartupPath & "\passwords6.lst")
        Dim CurDate As Date = Convert.ToDateTime("1982-01-01")
        Dim EndDate As Date = Convert.ToDateTime("1989-12-31")

        While CurDate <= EndDate
            sw.WriteLine(CurDate.ToString("yyMMdd"))
            CurDate = CurDate.AddDays(1)
        End While

        CurDate = Convert.ToDateTime("2007-01-01")
        EndDate = Convert.ToDateTime("2012-12-31")

        While CurDate <= EndDate
            sw.WriteLine(CurDate.ToString("yyMMdd"))
            CurDate = CurDate.AddDays(1)
        End While

        sw.Flush()
        sw.Close()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'Try
        '    Dim pErr As String = "".PadLeft(1024, " ")
        '    Dim res As Integer = Init1(pErr)
        '    If res = 0 Then
        '        MessageBox.Show("成功")
        '    Else
        '        MessageBox.Show(pErr)
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try

        Dim strDate As String
        Dim strRet As String
        Dim strRet1 As String
        Dim strEmpId As String = "4004"
        MessageBox.Show("名字、".Replace("、", "/"))

        Try

            strDate = "2014-01-01 23:59:59"

            strRet = Val(CDate(strDate).Year.ToString) & Val(CDate(strDate).Month.ToString) & Val(CDate(strDate).Day.ToString) & Val(CDate(strDate).Hour.ToString) & Val(CDate(strDate).Minute.ToString) & Val(CDate(strDate).Second.ToString)

            strRet1 = strRet & strEmpId & CInt(Int((10000 * Rnd()) + 1)).ToString()

            If strRet1.Length > 30 Then
                strRet1 = strRet1.Substring(0, 30)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        MessageBox.Show(Format(CDate("2011-01-01 23:59:59"), "yyyyMMddHHmmss"))

        Try
            Dim pErr As String = "".PadLeft(1024, " ")
            Dim res As Integer = InitDLL()
            If res = 0 Then
                MessageBox.Show("成功")
            Else
                MessageBox.Show("失败：" & res)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class