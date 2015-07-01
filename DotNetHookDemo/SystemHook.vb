﻿
Imports System.Reflection, System.Threading, System.ComponentModel, System.Runtime.InteropServices

''' <summary>本类可以在.NET环境下使用系统键盘与鼠标钩子</summary>
Public Class SystemHook

#Region "定义结构"

    Private Structure MouseHookStructStructure
        Dim PT As Point
        Dim Hwnd As Integer
        Dim WHitTestCode As Integer
        Dim DwExtraInfo As Integer
    End Structure

    Private Structure MouseLLHookStructStructure
        Dim PT As Point
        Dim MouseData As Integer
        Dim Flags As Integer
        Dim Time As Integer
        Dim DwExtraInfo As Integer
    End Structure

    Private Structure KeyboardHookStructStructure
        Dim vkCode As Integer
        Dim ScanCode As Integer
        Dim Flags As Integer
        Dim Time As Integer
        Dim DwExtraInfo As Integer
    End Structure

#End Region

#Region "API声明导入"

    Private Declare Function SetWindowsHookEx Lib "user32" Alias "SetWindowsHookExA" (ByVal idHook As Integer, ByVal lpfn As HookProc, ByVal hMod As IntPtr, ByVal dwThreadId As Integer) As Integer
    Private Declare Function UnhookWindowsHookEx Lib "user32" (ByVal idHook As Integer) As Integer
    Private Declare Function CallNextHookEx Lib "user32" (ByVal idHook As Integer, ByVal nCode As Integer, ByVal wParam As Integer, ByVal lParam As IntPtr) As Integer
    Private Declare Function ToAscii Lib "user32" (ByVal uVirtKey As Integer, ByVal uScancode As Integer, ByVal lpdKeyState As Byte(), ByVal lpwTransKey As Byte(), ByVal fuState As Integer) As Integer
    Private Declare Function GetKeyboardState Lib "user32" (ByVal pbKeyState As Byte()) As Integer
    Private Declare Function GetKeyState Lib "user32" (ByVal vKey As Integer) As Short

    Private Delegate Function HookProc(ByVal nCode As Integer, ByVal wParam As Integer, ByVal lParam As IntPtr) As Integer

#End Region

#Region "常量声明"

    Private Const WH_KEYBOARD_LL = 13
    Private Const WH_MOUSE_LL = 14

    Private Const WH_KEYBOARD = 2
    Private Const WH_MOUSE = 7

    Private Const WM_MOUSEMOVE = &H200

    Private Const WM_LBUTTONDOWN = &H201
    Private Const WM_LBUTTONUP = &H202
    Private Const WM_LBUTTONDBLCLK = &H203

    Private Const WM_RBUTTONDOWN = &H204
    Private Const WM_RBUTTONUP = &H205
    Private Const WM_RBUTTONDBLCLK = &H206

    Private Const WM_MBUTTONDOWN = &H207
    Private Const WM_MBUTTONUP = &H208
    Private Const WM_MBUTTONDBLCLK = &H209

    Private Const WM_MOUSEWHEEL = &H20A

    Private Const WM_KEYDOWN = &H100
    Private Const WM_KEYUP = &H101

    Private Const WM_SYSKEYDOWN = &H104
    Private Const WM_SYSKEYUP = &H105

    Private Const VK_SHIFT As Byte = &H10
    Private Const VK_CAPITAL As Byte = &H14
    Private Const VK_NUMLOCK As Byte = &H90

#End Region

#Region "事件委托处理"

    Private events As New System.ComponentModel.EventHandlerList

    ''' <summary>鼠标激活事件</summary>
    Public Custom Event MouseActivity As MouseEventHandler
        AddHandler(ByVal value As MouseEventHandler)
            events.AddHandler("MouseActivity", value)
        End AddHandler
        RemoveHandler(ByVal value As MouseEventHandler)
            events.RemoveHandler("MouseActivity", value)
        End RemoveHandler
        RaiseEvent(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
            Dim eh As MouseEventHandler = TryCast(events("MouseActivity"), MouseEventHandler)
            If eh IsNot Nothing Then
                eh.Invoke(sender, e)
            End If
        End RaiseEvent
    End Event

    ''' <summary>键盘按下事件</summary>
    Public Custom Event KeyDown As KeyEventHandler
        AddHandler(ByVal value As KeyEventHandler)
            events.AddHandler("KeyDown", value)
        End AddHandler
        RemoveHandler(ByVal value As KeyEventHandler)
            events.RemoveHandler("KeyDown", value)
        End RemoveHandler
        RaiseEvent(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            Dim eh As KeyEventHandler = TryCast(events("KeyDown"), KeyEventHandler)
            If eh IsNot Nothing Then eh.Invoke(sender, e)
        End RaiseEvent
    End Event

    ''' <summary>键盘输入事件</summary>
    Public Custom Event KeyPress As KeyPressEventHandler
        AddHandler(ByVal value As KeyPressEventHandler)
            events.AddHandler("KeyPress", value)
        End AddHandler
        RemoveHandler(ByVal value As KeyPressEventHandler)
            events.RemoveHandler("KeyPress", value)
        End RemoveHandler
        RaiseEvent(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
            Dim eh As KeyPressEventHandler = TryCast(events("KeyPress"), KeyPressEventHandler)
            If eh IsNot Nothing Then eh.Invoke(sender, e)
        End RaiseEvent
    End Event

    ''' <summary>键盘松开事件</summary>
    Public Custom Event KeyUp As KeyEventHandler
        AddHandler(ByVal value As KeyEventHandler)
            events.AddHandler("KeyUp", value)
        End AddHandler
        RemoveHandler(ByVal value As KeyEventHandler)
            events.RemoveHandler("KeyUp", value)
        End RemoveHandler
        RaiseEvent(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            Dim eh As KeyEventHandler = TryCast(events("KeyUp"), KeyEventHandler)
            If eh IsNot Nothing Then eh.Invoke(sender, e)
        End RaiseEvent
    End Event

#End Region

    Private hMouseHook As Integer
    Private hKeyboardHook As Integer

    Private Shared MouseHookProcedure As HookProc
    Private Shared KeyboardHookProcedure As HookProc

#Region "创建与析构类型"

    ''' <summary>创建一个全局鼠标键盘钩子 (请使用Start方法开始监视) </summary>
    Sub New()
        '留空即可
    End Sub

    ''' <summary>创建一个全局鼠标键盘钩子，决定是否安装钩子</summary>
    ''' <param name="InstallAll">是否立刻挂钩系统消息</param>
    Sub New(ByVal InstallAll As Boolean)
        If InstallAll Then StartHook(True, True)
    End Sub

    ''' <summary>创建一个全局鼠标键盘钩子，并决定安装钩子的类型 </summary>
    ''' <param name="InstallKeyboard">挂钩键盘消息</param>
    ''' <param name="InstallMouse">挂钩鼠标消息</param>
    Sub New(ByVal InstallKeyboard As Boolean, ByVal InstallMouse As Boolean)
        StartHook(InstallKeyboard, InstallMouse)
    End Sub

    ''' <summary>析构函数</summary>
    Protected Overrides Sub Finalize()
        UnHook() '卸载对象时反注册系统钩子
        MyBase.Finalize()
    End Sub

#End Region

    ''' <summary>开始安装系统钩子</summary>
    ''' <param name="InstallKeyboardHook">挂钩键盘消息</param>
    ''' <param name="InstallMouseHook">挂钩鼠标消息</param>
    Sub StartHook(Optional ByVal InstallKeyboardHook As Boolean = True, Optional ByVal InstallMouseHook As Boolean = False)
        '注册键盘钩子
        If InstallKeyboardHook AndAlso hKeyboardHook = 0 Then
            KeyboardHookProcedure = New HookProc(AddressOf KeyboardHookProc)
            hKeyboardHook = SetWindowsHookEx(WH_KEYBOARD_LL, KeyboardHookProcedure, Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly.GetModules()(0)), 0)
            If hKeyboardHook = 0 Then '检测是否注册完成
                UnHook(True, False) '在这里反注册
                Throw New Win32Exception(Marshal.GetLastWin32Error) '报告错 误
            End If
        End If
        '注册鼠标钩子
        If InstallMouseHook AndAlso hMouseHook = 0 Then
            MouseHookProcedure = New HookProc(AddressOf MouseHookProc)
            hMouseHook = SetWindowsHookEx(WH_MOUSE_LL, MouseHookProcedure, Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly.GetModules()(0)), 0)
            If hMouseHook = 0 Then
                UnHook(False, True)
                Throw New Win32Exception(Marshal.GetLastWin32Error)
            End If
        End If
    End Sub

    ''' <summary>立刻卸载系统钩子</summary>
    ''' <param name="UninstallKeyboardHook">卸载键盘钩子 </param>
    ''' <param name="UninstallMouseHook">卸载鼠标钩子</param>
    ''' <param name="ThrowExceptions">是否报告错误</param>
    Sub UnHook(Optional ByVal UninstallKeyboardHook As Boolean = True, Optional ByVal UninstallMouseHook As Boolean = True, Optional ByVal ThrowExceptions As Boolean = False)
        '卸载键盘钩子
        If hKeyboardHook <> 0 AndAlso UninstallKeyboardHook Then
            Dim retKeyboard As Integer = UnhookWindowsHookEx(hKeyboardHook)
            hKeyboardHook = 0
            If ThrowExceptions AndAlso retKeyboard = 0 Then '如果出现错误，是否 报告错误
                Throw New Win32Exception(Marshal.GetLastWin32Error) '报告错 误
            End If
        End If
        '卸载鼠标钩子
        If hMouseHook <> 0 AndAlso UninstallMouseHook Then
            Dim retMouse As Integer = UnhookWindowsHookEx(hMouseHook)
            hMouseHook = 0
            If ThrowExceptions AndAlso retMouse = 0 Then
                Throw New Win32Exception(Marshal.GetLastWin32Error)
            End If
        End If
    End Sub

    '键盘消息的委托处理代码
    Function KeyboardHookProc(ByVal nCode As Integer, ByVal wParam As Integer, ByVal lParam As IntPtr) As Integer
        Static handled As Boolean : handled = False
        If nCode >= 0 AndAlso (events("KeyDown") IsNot Nothing OrElse events("KeyPress") IsNot Nothing OrElse events("KeyUp") IsNot Nothing) Then
            Static MyKeyboardHookStruct As KeyboardHookStructStructure
            MyKeyboardHookStruct = DirectCast(Marshal.PtrToStructure(lParam, GetType(KeyboardHookStructStructure)), KeyboardHookStructStructure)
            '激活KeyDown
            If wParam = WM_KEYDOWN OrElse wParam = WM_SYSKEYDOWN Then '如果消息 为按下普通键或系统键
                Dim e As New KeyEventArgs(MyKeyboardHookStruct.vkCode)
                RaiseEvent KeyDown(Me, e) '激活事件
                handled = handled Or e.Handled '是否取消下一个钩子
            End If
            '激活KeyUp
            If wParam = WM_KEYUP OrElse wParam = WM_SYSKEYUP Then
                Dim e As New KeyEventArgs(MyKeyboardHookStruct.vkCode)
                RaiseEvent KeyUp(Me, e)
                handled = handled Or e.Handled
            End If
            '激活KeyPress (TODO:此段代码还有BUG！)
            If wParam = WM_KEYDOWN Then
                Dim isDownShift As Boolean = (GetKeyState(VK_SHIFT) & &H80 = &H80)
                Dim isDownCapslock As Boolean = (GetKeyState(VK_CAPITAL) <> 0)
                Dim keyState(256) As Byte
                GetKeyboardState(keyState)
                Dim inBuffer(2) As Byte
                If ToAscii(MyKeyboardHookStruct.vkCode, MyKeyboardHookStruct.ScanCode, keyState, inBuffer, MyKeyboardHookStruct.Flags) = 1 Then
                    Static key As Char : key = Chr(inBuffer(0))
                    ' BUG所在
                    'If isDownCapslock Xor isDownShift And Char.IsLetter(key) Then
                    '　　　 key = Char.ToUpper(key)
                    'End If
                    Dim e As New KeyPressEventArgs(key)
                    RaiseEvent KeyPress(Me, e)
                    handled = handled Or e.Handled
                End If
            End If
        End If

        '取消或者激活下一个钩子
        If handled Then
            Return 1
        Else
            Return CallNextHookEx(hKeyboardHook, nCode, wParam, lParam)
        End If
    End Function

    '鼠标消息的委托处理代码
    Private Function MouseHookProc(ByVal nCode As Integer, ByVal wParam As Integer, ByVal lParam As IntPtr) As Integer
        If nCode >= 0 AndAlso events("MouseActivity") IsNot Nothing Then
            Static mouseHookStruct As MouseLLHookStructStructure
            mouseHookStruct = DirectCast(Marshal.PtrToStructure(lParam, GetType(MouseLLHookStructStructure)), MouseLLHookStructStructure)
            Static moubut As MouseButtons : moubut = MouseButtons.None '鼠标按键 
            Static mouseDelta As Integer : mouseDelta = 0 '滚轮值
            Static clickCount As Integer : clickCount = 0 '单击次数
            Select Case wParam
                Case WM_LBUTTONDBLCLK
                    moubut = MouseButtons.Left
                    clickCount = 2
                Case WM_LBUTTONUP
                    moubut = MouseButtons.Left
                    clickCount = 1
                Case WM_LBUTTONDOWN
                    moubut = MouseButtons.Left
                    clickCount = 1
                Case WM_RBUTTONDOWN
                    moubut = MouseButtons.Right
                Case WM_MBUTTONDOWN
                    moubut = MouseButtons.Middle
                Case WM_MOUSEWHEEL
                    Static int As Integer : int = (mouseHookStruct.MouseData >> 16) And &HFFFF
                    '本段代码CLE添加，模仿C#的Short从Int弃位转换
                    If int > Short.MaxValue Then mouseDelta = int - 65536 Else mouseDelta = int
            End Select
            'If moubut = MouseButtons.None Then
            '    If wParam = WM_LBUTTONDBLCLK OrElse wParam = WM_RBUTTONDBLCLK OrElse wParam = WM_MBUTTONDBLCLK Then
            '        clickCount = 2
            '    Else
            '        clickCount = 1
            '    End If
            'End If
            Dim e As New MouseEventArgs(moubut, clickCount, mouseHookStruct.PT.X, mouseHookStruct.PT.Y, mouseDelta)
            RaiseEvent MouseActivity(Me, e)
        End If
        Return CallNextHookEx(hMouseHook, nCode, wParam, lParam) '激活下一个钩子
    End Function

    ''' <summary>
    ''' 键盘钩子是否有效
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property KeyHookEnabled() As Boolean
        Get
            Return hKeyboardHook <> 0
        End Get
        Set(ByVal value As Boolean)
            If value Then StartHook(True, False) Else UnHook(True, False)
        End Set
    End Property

    ''' <summary>
    ''' 鼠标钩子是否有效
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MouseHookEnabled() As Boolean
        Get
            Return hMouseHook <> 0
        End Get
        Set(ByVal value As Boolean)
            If value Then StartHook(False, True) Else UnHook(False, True)
        End Set
    End Property


End Class