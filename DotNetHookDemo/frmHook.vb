Public Class frmHook

    Private WithEvents objHook As SystemHook = New SystemHook()

    Private Const DateFormatStr As String = "yyyy-MM-dd hh:mm:ss"

#Region "属性"

    ''' <summary>
    ''' 键盘钩子状态
    ''' </summary>
    ''' <remarks></remarks>
    Private mKeyBoardHookState As Boolean
    Public Property KeyBoardHookState() As Boolean
        Get
            Return mKeyBoardHookState
        End Get
        Set(ByVal value As Boolean)
            picBoxKeyBoard.Image = IIf(value, Global.DotNetHookDemo.My.Resources.Resources.ImageOn, Global.DotNetHookDemo.My.Resources.Resources.ImgOff)
            mKeyBoardHookState = value
        End Set
    End Property

    ''' <summary>
    ''' 鼠标钩子状态
    ''' </summary>
    ''' <remarks></remarks>
    Private mMouseHookState As Boolean
    Public Property MouseHookState() As Boolean
        Get
            Return mMouseHookState
        End Get
        Set(ByVal value As Boolean)
            picBoxMouse.Image = IIf(value, Global.DotNetHookDemo.My.Resources.Resources.ImageOn, Global.DotNetHookDemo.My.Resources.Resources.ImgOff)
            mMouseHookState = value
        End Set
    End Property

#End Region

#Region "事件"

    ''' <summary>
    ''' 键盘事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub objHook_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles objHook.KeyPress
        listboxHookedContent.Items.Add(String.Format("{0} {1} : {2}", DateTime.Now.ToString(DateFormatStr), e.KeyChar, e.ToString))
        listboxHookedContent.SelectedIndex = listboxHookedContent.Items.Count - 1
    End Sub

    ''' <summary>
    ''' 鼠标事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub objHook_MouseActivity(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles objHook.MouseActivity
        If e.Button <> MouseButtons.None Then
            listboxHookedContent.Items.Add(String.Format("{0} {1}键 ：{2}次 : {3}", DateTime.Now.ToString(DateFormatStr), e.Button, e.Clicks, e.ToString))
            listboxHookedContent.SelectedIndex = listboxHookedContent.Items.Count - 1
        End If
    End Sub

    ''' <summary>
    ''' 安装键盘钩子
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnKeyBoardReg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKeyBoardReg.Click
        If Hook("K", True) Then
            KeyBoardHookState = True
        End If
    End Sub

    ''' <summary>
    ''' 卸载键盘钩子
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnKeyBoardUnReg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKeyBoardUnReg.Click
        If Hook("K", False) Then
            KeyBoardHookState = False
        End If
    End Sub

    ''' <summary>
    ''' 安装鼠标钩子
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnMouseReg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMouseReg.Click
        If Hook("M", True) Then
            MouseHookState = True
        End If
    End Sub

    ''' <summary>
    ''' 卸载鼠标钩子
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnMouseUnReg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMouseUnReg.Click
        If Hook("M", True) Then
            MouseHookState = False
        End If
    End Sub

#End Region

#Region "自定义方法"

    ''' <summary>
    ''' 安装卸载钩子
    ''' </summary>
    ''' <param name="type"></param>
    ''' <param name="op"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Hook(ByVal type As String, ByVal op As Boolean) As Boolean
        Try
            If type = "M" Then
                If op Then
                    objHook.StartHook(True, False)
                Else
                    objHook.UnHook(True, False)
                End If
            ElseIf type = "K" Then
                If op Then
                    objHook.StartHook(False, True)
                Else
                    objHook.UnHook(False, True)
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            listboxHookedContent.Items.Add(String.Format("{0} {1}{2}钩子失败：{3}", DateTime.Now.ToString(DateFormatStr), IIf(op, "注册", "卸载"), IIf(type = "M", "键盘", "鼠标"), ex.Message))
            listboxHookedContent.SelectedIndex = listboxHookedContent.Items.Count - 1
            Return False
        End Try

        listboxHookedContent.Items.Add(String.Format("{0} {1}{2}钩子成功！", DateTime.Now.ToString(DateFormatStr), IIf(op, "注册", "卸载"), IIf(type = "M", "键盘", "鼠标")))
        listboxHookedContent.SelectedIndex = listboxHookedContent.Items.Count - 1

        Return True
    End Function

#End Region

    Private Sub frmHook_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub frmHook_OnClose(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Hook("M", False)
        Hook("K", False)
    End Sub

End Class
