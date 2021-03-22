Class MainWindow
    Dim t As New Timers.Timer
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        'AddHandler mediaUriElement.MediaFailed, AddressOf MediaUriElement_MediaFailed
        Me.WindowStyle = WindowStyle.None
        Me.WindowState = WindowState.Maximized
        mediaUriElement.LoadedBehavior = MediaState.Manual
        t.Interval = 1000
        AddHandler t.Elapsed, AddressOf prepare
        t.Start()
    End Sub

    Private Sub prepare()
        If Now.CompareTo(New Date(2021, 2, 21, 21, 24, 57)) > 0 Then
            t.Stop()
            Me.Dispatcher.Invoke(Sub()
                                     Dim da As New Animation.DoubleAnimation(1, 0, TimeSpan.FromSeconds(1))
                                     mask2.BeginAnimation(UIElement.OpacityProperty, da)
                                 End Sub)
            Threading.Thread.Sleep(2000)
            Me.Dispatcher.Invoke(AddressOf startplay)
            Threading.Thread.Sleep(1000)
            Me.Dispatcher.Invoke(Sub()
                                     Dim da1 As New Animation.DoubleAnimation(1, 0, TimeSpan.FromSeconds(1))
                                     mask1.BeginAnimation(UIElement.OpacityProperty, da1)
                                 End Sub)
        End If
    End Sub

    Private Sub startplay()
        If Command.Length = 0 Then
            'Application.Current.Shutdown()
            mediaUriElement.Source = New Uri(Replace("D:\时光盲盒.mp4", """", ""), UriKind.Absolute)
            mediaUriElement.Play()
        Else
            'MsgBox(Replace(Command(), """", ""))
            mediaUriElement.Source = New Uri(Replace(Command(), """", ""), UriKind.Absolute)
            mediaUriElement.Play()
        End If
    End Sub

    Private Sub Window_PreviewKeyDown(sender As Object, e As KeyEventArgs)
        If e.Key = Key.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub MediaUriElement_MediaFailed(sender As Object, e As WPFMediaKit.DirectShow.MediaPlayers.MediaFailedEventArgs)
        Me.Dispatcher.BeginInvoke(New Action(Sub()
                                                 errorText.Text = e.Message
                                             End Sub))
    End Sub
End Class
