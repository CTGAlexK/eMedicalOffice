Imports System.Reflection
Imports log4net

Module GUIModule
    Private ReadOnly log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

    Public Enum AutosizeListviewColumnType
        ByLongestColumnHeader = -2
        ByLongestColumnContent = -1
    End Enum

    Public Sub gListViewRestoreDefaultColumnWidth(LV As ListView)
        Dim C As Windows.Forms.ColumnHeader
        Dim tColumn As Windows.Forms.ColumnHeader
        'Dim g As Graphics = LV.CreateGraphics
        LV.BeginUpdate()
        LV.SuspendLayout()
        Try
            tColumn = LV.Columns.Add("")
            For Each C In LV.Columns
                C.Width = -2
            Next
            LV.Columns.Remove(tColumn)
        Catch ex As Exception
            log.Error(ex)
        End Try

        ' Add dummy column to fix problem - the last column with becomes to the end of the listview width.

        LV.EndUpdate()
        LV.ResumeLayout(True)
        'g.Dispose()
        'g = Nothing
    End Sub

    Public Enum eAttachDetach
        None = 0
        Attach = 1
        Detach = 2
    End Enum

    Public Function gDetachAttachWindow(childForm As Form, parentForm As Form, Optional Attach As eAttachDetach = eAttachDetach.None) As Image
        If (childForm.MdiParent Is Nothing And Attach <> eAttachDetach.Detach) Or Attach = eAttachDetach.Attach Then
            childForm.Hide()
            Application.DoEvents()
            childForm.MdiParent = parentForm
            childForm.WindowState = FormWindowState.Minimized
            Application.DoEvents()
            childForm.Show()
            childForm.WindowState = FormWindowState.Maximized
            Application.DoEvents()
            SaveSetting(My.Application.Info.ProductName, "GUI\USER-" & gCurrentEmployee.EmpID & "\" & UCase(childForm.Name), "DETACHED", 0)
            childForm.BringToFront()
            Return My.Resources.Detach
        Else
            childForm.Hide()
            childForm.StartPosition = FormStartPosition.Manual
            childForm.WindowState = FormWindowState.Normal
            childForm.MdiParent = Nothing
            Application.DoEvents()
            If Screen.AllScreens.Count > 0 Then
                Dim MainScrn As Screen = Screen.FromControl(parentForm)
                If MainScrn.DeviceName = Screen.AllScreens(0).DeviceName Then
                    childForm.Bounds = Screen.AllScreens(1).Bounds
                End If
                If MainScrn.DeviceName = Screen.AllScreens(1).DeviceName Then
                    childForm.Bounds = Screen.AllScreens(0).Bounds
                End If
            End If
            childForm.WindowState = FormWindowState.Maximized
            childForm.Show()
            childForm.BringToFront()
            SaveSetting(My.Application.Info.ProductName, "GUI\USER-" & gCurrentEmployee.EmpID & "\" & UCase(childForm.Name), "DETACHED", 1)
            Return My.Resources.Atach
        End If

    End Function

End Module