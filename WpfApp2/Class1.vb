
Imports System.Runtime.InteropServices
Imports System.Windows.Interop
Imports AudioSwitcher.AudioApi.CoreAudio

Public Module rrrr
    Public Sub Main1()
        VideoPlayerController.AudioManager.SetMasterVolume(40)
        VideoPlayerController.AudioManager.SetMasterVolumeMute(False)
        Dim m As New MainWindow2
        Application.Current.MainWindow = m
        m.WindowStyle = WindowStyle.None
        m.Width = 0
        m.Height = 0
        m.mediaUriElement.LoadedBehavior = MediaState.Manual
        m.mediaUriElement.Volume = 60
        m.Top = 0
        m.Left = 0
        m.Opacity = 0
        m.Show()
        m.startplay()
        System.Threading.Thread.Sleep(100)
        Dim workw = GetWorkerW()
        Console.WriteLine(workw)
        SetParent((New WindowInteropHelper(m)).Handle, workw)
        MoveWindow((New WindowInteropHelper(m)).Handle, 0, 0, 1920, 1080, True)

        m.Opacity = 1
    End Sub


    <DllImport("user32.dll")>
    Public Function SendMessageTimeout(ByVal hWnd As IntPtr,
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
    Public Function EnumWindows(ByVal lpEnumFunc As EnumWindowsProc, ByVal lParam As IntPtr) As Boolean

    End Function

    <DllImport("user32")>
    Public Function FindWindowEx(ByVal hWndParent As IntPtr, ByVal hWndChildAfter As IntPtr, ByVal lpWindowClass As String, ByVal lpWindowName As String) As IntPtr

    End Function


    <DllImport("user32")>
    Public Function SetParent(ByVal hWndChild As IntPtr, ByVal hWndNewParent As IntPtr) As IntPtr

    End Function

    <DllImport("user32.dll")>
    Public Function MoveWindow(ByVal handle As IntPtr, ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal bRepaint As Boolean) As Boolean

    End Function
    Public Function GetWorkerW() As IntPtr
        Dim progmanHandle = FindWindowEx(IntPtr.Zero, IntPtr.Zero, "Progman", Nothing)
        Dim result = Nothing
        SendMessageTimeout(progmanHandle, &H52C, 0, 0, 0, 1000, result)
        System.Threading.Thread.Sleep(100)
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
End Module