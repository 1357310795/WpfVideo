﻿Imports System.Runtime.InteropServices
Imports System.Windows.Interop

Class MainWindow2
    Dim t As New Timers.Timer
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)

    End Sub


    Public Sub startplay()
        If Command.Length = 0 Then
            'Application.Current.Shutdown()
            mediaUriElement.Source = New Uri(Replace("D:\【时光沙盒】高考倒计时：用漂亮的答卷，入场盛夏的远方！111.mp4", """", ""), UriKind.Absolute)
            mediaUriElement.Play()
        Else
            'MsgBox(Replace(Command(), """", ""))
            mediaUriElement.Source = New Uri(Replace(Command(), """", ""), UriKind.Absolute)
            mediaUriElement.Play()
        End If
    End Sub

    <DllImport("user32.dll")>
    Public Shared Function SendMessageTimeout(ByVal hWnd As IntPtr,
                                              ByVal wMsg As Integer,
                                              ByVal wParam As Integer,
                                              ByVal lParam As Integer,
                                              ByVal fuFlags As Int32,
                                              ByVal uTimeout As UInteger,
                                              <Out> ByRef lpdwResult As Integer) As Integer

    End Function
    Public Delegate Function EnumMonitorProc(ByVal hMonitor As IntPtr, ByVal hdcMonitor As IntPtr, ByRef rcMonitor As Rect, ByVal data As IntPtr) As Boolean
    Public Delegate Function EnumWindowsProc(ByVal hwnd As IntPtr, ByVal lParam As IntPtr) As Boolean

    <DllImport("user32")>
    Public Shared Function EnumWindows(ByVal lpEnumFunc As EnumWindowsProc, ByVal lParam As IntPtr) As Boolean

    End Function

    <DllImport("user32")>
    Public Shared Function FindWindowEx(ByVal hWndParent As IntPtr, ByVal hWndChildAfter As IntPtr, ByVal lpWindowClass As String, ByVal lpWindowName As String) As IntPtr

    End Function


    <DllImport("user32")>
    Public Shared Function SetParent(ByVal hWndChild As IntPtr, ByVal hWndNewParent As IntPtr) As IntPtr

    End Function

    <DllImport("user32.dll")>
    Public Shared Function MoveWindow(ByVal handle As IntPtr, ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal bRepaint As Boolean) As Boolean

    End Function
    Public Shared Function GetWorkerW() As IntPtr
        Dim progmanHandle = FindWindowEx(IntPtr.Zero, IntPtr.Zero, "Progman", Nothing)
        Dim result = Nothing
        SendMessageTimeout(progmanHandle, &H52C, 0, 0, 0, 1000, result)
        Threading.Thread.Sleep(100)
        Dim workerWHandle = IntPtr.Zero
        EnumWindows(New EnumWindowsProc(Function(topHandle, topParamHandle)
                                            Dim shellHandle = FindWindowEx(topHandle, IntPtr.Zero, "SHELLDLL_DefView", Nothing)

                                            If shellHandle <> IntPtr.Zero Then
                                                workerWHandle = FindWindowEx(IntPtr.Zero, topHandle, "WorkerW", Nothing)
                                            End If

                                            Return True
                                        End Function), IntPtr.Zero)
        Return workerWHandle
    End Function
End Class
