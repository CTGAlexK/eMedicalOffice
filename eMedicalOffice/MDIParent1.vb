Imports System.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class MDIForm1
    Private SaveRequests As Long
    Private SaveNF2 As Long
    Private SaveBills As Long
    Private SaveRequestID As Long
    'Private WithEvents mobjSubclassedSystemMenu As SubclassedSystemMenu
    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub MDIForm1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.Cancel Then Exit Sub
        gSQLDeleteRecord("UPDATE Patients Set LockDT=Null, LockByID=0, LockedByIP = '', LockedByHostName='', LockedByName='' Where LockByID=" & gCurrentEmployee.EmpID.ToString)
        gSQLDeleteRecord("Delete From EmailerPrinting Where EmpID=" & gCurrentEmployee.EmpID)
        gSQLDeleteRecord("DELETE  FROM  ToBeScheduled    Where empid = " & gCurrentEmployee.EmpID)
        If Not FormsCollection.FindForm("frmPatientAttendancy") Is Nothing Then
            frmPatientAttendancy.Close()
            frmPatientAttendancy.Dispose()
        End If
        ToolStripManager.SaveSettings(Me, "Custom" & gCurrentEmployee.UID)
        SaveSetting(My.Application.Info.ProductName, "Settings", "WorkSpaceBackColor" & gCurrentEmployee.UID, Me.BackColor.ToArgb)
        If Not FormsCollection.FindForm("frmPatientNF2") Is Nothing Then
            frmPatientNF2.Close()
            frmPatientNF2.Dispose()
        End If
        If Not FormsCollection.FindForm("frmPatient") Is Nothing Then
            frmPatient.Close()
            frmPatient.Dispose()
        End If
        If Not FormsCollection.FindForm("frmBillingPT") Is Nothing Then
            frmBillingPT.Close()
            frmBillingPT.Dispose()
        End If
        If Not FormsCollection.FindForm("frmBillingPT") Is Nothing Then
            frmBilling.Close()
            frmBilling.Dispose()
        End If
        If gfrmSearchLoaded = True Then
            frmSearch.Close()
            frmSearch.Dispose()
        End If
        If gfrmScheduleLoaded = True Then
            frmSchedule.Close()
            frmSchedule.Dispose()
        End If
        gSettings(ReadWrite.sWrite)
        Reset()



        Application.DoEvents()
        If EZTwain.State = EZTwain.TWAIN_SOURCE_OPEN Then EZTwain.CloseSource()
        If EZTwain.State = EZTwain.TWAIN_SM_OPEN Then EZTwain.UnloadSourceManager()
        GC.Collect()
        gDeleteAllFiles(System.IO.Path.GetTempPath, "PDF*.PDF")
        gDeleteAllFiles(System.IO.Path.GetTempPath, "JPG*.JPG")
        gDeleteAllFiles(System.IO.Path.GetTempPath, "*.XLS")
        SaveSetting(My.Application.Info.ProductName, "Settings", "PanelReminder", PanelRequests.Width)
        gListview_Settings(Me, ListViewRequests, ReadWrite.sWrite)
        MDILoaded = False
        SaveSetting(My.Application.Info.ProductName, "Settings", Me.Name & "SplitterDistanceNF2", SplitContainer1.SplitterDistance)
    End Sub
    Private Sub SetMdiClientBorder(ByVal showBorder As Boolean)
        For Each c As Control In Me.Controls
            If TypeOf c Is MdiClient Then
                'Dim windowLong As Long = GetWindowLong(c.Handle, GWL_EXSTYLE)
                'If showBorder Then
                '    windowLong = windowLong Or WS_EX_CLIENTEDGE
                'Else
                '    windowLong = windowLong And (Not WS_EX_CLIENTEDGE)
                'End If
                'SetWindowLong(c.Handle, GWL_EXSTYLE, windowLong)
                'c.Width = c.Width + 1
                Dim MDIStyle As Integer = GetWindowLong(c.Handle, GWL_STYLE)
                Dim MDIExStyle As Integer = GetWindowLong(c.Handle, GWL_EXSTYLE)
                'Update the controls styles
                SetWindowLong(c.Handle, GWL_STYLE, MDIStyle And Not (WS_BORDER))
                SetWindowLong(c.Handle, GWL_EXSTYLE, MDIExStyle And Not (WS_EX_CLIENTEDGE))
                Exit For
            End If
        Next
    End Sub
    Private Sub MDIForm1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            'Me.BackColor = Color.FromArgb(GetSetting(My.Application.Info.ProductName, "Settings", "WorkSpaceBackColor" & gCurrentEmployee.UID, Color.Gainsboro.ToArgb))
            Me.BackColor = Color.FromArgb(69, 69, 69)

            ResetSearchComboTimer.Interval = 500
            AddHandler ResetSearchComboTimer.Tick, AddressOf ResetComboSearchObjject
            Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)

            SetFormBackcolor()
            LoadSettings()
            gLoadSystemFunctions()
            gSQLUpdateData("InitialiseDummyProcedures")
            SetMdiClientBorder(False)
            If gCurrentEmployee.SC Then
                ToolStripStatusDBServer.Text = gSQLServerName
            End If
            If gCurrentEmployee.PositionID < 2 Then
                Dim ServerIP = gSQLGetSingleValueString("select local_net_address FROM sys.dm_exec_connections WHERE Session_id = @@SPID")
                If gSQLServerName <> ServerIP Then
                    lblServer.Text = " " & gSQLServerName & " / " & ServerIP & "    "
                Else
                    lblServer.Text = " " & gSQLServerName & "    "
                End If
            Else
                lblServer.Text = ""
            End If
            MDILoaded = True
            Load_Data()

            lblOffice.Text = " " & gOfficeName & "    "
            lblOfficeType.Text = " " & gOfficeTypeIDName & "    "
            lblDate.Text = Now.ToString("dddd, MMMM dd, yyyy")
            lblTime.Text = Now.ToLongTimeString
            lblUserName.Text = gCurrentEmployee.FName & " " & gCurrentEmployee.LName
            lblPosition.Text = " " & gCurrentEmployee.Position & "    "
            Setup_Security()
            gSQLUpdateData("update PatientProcedures set ProcedureInformationID = 0 WHERE (ProcedureInformationID IS NULL)")
            'PanelRequests.Width = GetSetting(My.Application.Info.ProductName, "Settings", "PanelReminder", PanelRequests.Width)
            gListview_Settings(Me, ListViewRequests, ReadWrite.sRead)
            SplitContainer1.SplitterDistance = GetSetting(My.Application.Info.ProductName, "Settings", Me.Name & "SplitterDistanceNF2", SplitContainer1.SplitterDistance)
            TimerRefresh.Enabled = True
            DatabaseProcesses()
            CheckBoxDoNotShowBills.Visible = gCurrentEmployee.PositionID < 3
            CheckBoxDoNotShowRequests.Visible = gCurrentEmployee.PositionID < 3
            ToolStripSeparatorNotifications.Visible = gCurrentEmployee.PositionID < 3
            ShowToBeScheduled.Visible = gCurrentEmployee.PositionID < 3
            ShowNotificationsToolStripMenuItem.Visible = gCurrentEmployee.PositionID < 3
            ShowRequestsToolStripMenuItem.Visible = gCurrentEmployee.PositionID < 3
            ToolStripMenuItemToBeScheduled.Visible = gCurrentEmployee.PositionID < 3
            AdminMessagingToolStripMenuItem.Visible = gCurrentEmployee.PositionID < 3
            mnuBankDepositsAdmin.Visible = gCurrentEmployee.PositionID < 3
            FindDuplicatePatientsToolStripMenuItem.Visible = gCurrentEmployee.PositionID < 4


            '        TimerRefresh_Tick(Nothing, Nothing)
            If gOfficeTypeID = 1 Then
                ShowNotificationsToolStripMenuItem.Text = "Show Bills Notifications"
                ShowPrintIntakeFormButtonToolStripMenuItem.Visible = True
                ShowPrintIntakeFormButtonToolStripMenuItem.Checked = gShowIntakeFormButton
                ToolStripButtonIntakeForm.Visible = gShowIntakeFormButton
            Else
                PrintPatientIntakeToolStripMenuItem.Visible = False
                ShowNotificationsToolStripMenuItem.Text = "Show Bills / NF2 Notifications"
                ToolStripButtonIntakeForm.Visible = False
                ShowPrintIntakeFormButtonToolStripMenuItem.Visible = False
                ShowPrintIntakeFormButtonToolStripMenuItem.Checked = False
            End If



            For Each mnu In MenuStrip.Items
                If TypeOf mnu Is ToolStripMenuItem Then
                    Setup_Menus(mnu)
                End If
            Next
            Setup_Security()
            Dim T As New Threading.Thread(AddressOf Track_Noshows)
            T.Start()
            ToolStripManager.SaveSettings(Me, "Restore")
            ToolStripManager.LoadSettings(Me, "Custom" & gCurrentEmployee.UID)
            If MenuStrip.Visible = False Then
                ToolStripManager.LoadSettings(Me, "Restore")
            End If
            ToolStripMenuItem1.Visible = True


            'SetSysFunctions
            If SystemFunctions.Schedule = False Then
                ToolStripButtonSchedule.Visible = False
                SchedToolStripMenuItem.Visible = False
                ScheduleMaintenanceToolStripMenuItem.Visible = False
            End If
            If SystemFunctions.PatientMaintenance = False Then
                ToolStripButtonPatientProfile.Visible = False
                NewPatientToolStripMenuItem.Visible = False
            End If
            If SystemFunctions.Billing = False Then
                ToolStripButtonBilling.Visible = False
                BillingToolStripMenuItem1.Visible = False
                ToolStripButtonInsuranceMainenance.Visible = False
            End If

            If SystemFunctions.BillingManagement = False Then
                ToolStripButtonBillMaintenance.Visible = False
                CollectionToolStripMenuItem.Visible = False
            End If

            TechScheduleToolStripMenuItem.Visible = False
            ToolStripMenuItemProceduresSchedule.Visible = False
            Dim ST As ToolStripItemDisplayStyle
            ST = GetSetting(My.Application.Info.ProductName, "Settings", "ToolBarStyle", 2)
            SetToolBar(ST)
            gInstall_BarCode_Font()
            Check_Version_Functions()
            Load_Bookmarks()
            'mobjSubclassedSystemMenu = New SubclassedSystemMenu(Me.Handle.ToInt32, "Restore Environment")
        Catch ex As Exception
            gProcess_Log(ex.Message, ex.StackTrace, True)
        End Try
    End Sub
    Public Sub Load_Bookmarks()
        Dim SQL As String
        Dim Ret As Integer
        Dim Reader As SqlClient.SqlDataReader
        Dim MnuCount As Integer
ReLoop:
        For Each mnu In ToolStripMenuItemWeb.DropDownItems
            If mnu.Name <> "ToolStripMenuItemBookMarkManager" Then
                ToolStripMenuItemWeb.DropDownItems.Remove(mnu)
                GoTo ReLoop
            End If
        Next
        ' Check if the Collection Function is available
        SQL = "select count(OBJECT_ID('WebBookmarks', 'U'))"
        Ret = gSQLGetSingleValue(SQL)
        If Val(Ret) = 0 Then
            ToolStripMenuItemWeb.Visible = False
        Else
            ToolStripMenuItemWeb.Visible = True
            Reader = gSQLGetDataReader("SELECT ID, BKName, BKURL FROM WebBookmarks Where UID=0 or UID = " & gCurrentEmployee.EmpID & " Order by BKName desc")
            If Reader.HasRows Then
                Dim mnu As New ToolStripSeparator
                ToolStripMenuItemWeb.DropDownItems.Insert(0, mnu)
            End If
            Do Until Reader.Read = False
                MnuCount = MnuCount + 1
                Dim mnu As New ToolStripMenuItem()
                mnu.Text = Reader("BKName").ToString
                mnu.Name = "Mnu" & MnuCount
                mnu.Tag = Reader("BKURL").ToString
                mnu.Image = PictureBoxGlobe.Image
                ToolStripMenuItemWeb.DropDownItems.Insert(0, mnu)
                AddHandler mnu.Click, AddressOf WebBookmarks_Click
            Loop
        End If
    End Sub
    Private Sub WebBookmarks_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim FRM As New frmWebNavigator
        FRM.frmWebNavigator_Load(Nothing, Nothing)
        FRM.LoadUrl(sender.tag, sender.text)
        Application.DoEvents()
        FRM.MdiParent = Me
        FRM.WindowState = FormWindowState.Maximized
        Application.DoEvents()
        FRM.Show()
        FRM.BringToFront()
    End Sub
    Private Sub Check_Version_Functions()
        ' Check if the table / field exists then function available.
        Dim SQL As String
        Dim Reader As SqlClient.SqlDataReader
        ' Check if the Collection Function is available
        SQL = "select count(*) from sys.columns where Name = N'ReminderDT' and Object_ID = Object_ID(N'BillComments')"
        If ToolStripButtonCollection.Visible Then ToolStripButtonCollection.Visible = gSQLGetSingleValue(SQL)
        gCollectionFunction = ToolStripButtonCollection.Visible

    End Sub
    Private Sub Setup_Security()
        'admin options
        mnuEmployeeMaintenance.Visible = gCurrentEmployee.PositionID < 3
        mnuOfficesCompaniesMaintenance.Visible = gCurrentEmployee.PositionID < 3
        mnuAdminStripSeparator1.Visible = gCurrentEmployee.PositionID < 3
        mnuUnlockPatientProfiles.Visible = gCurrentEmployee.PositionID < 3
        mnuAdminStripSeparator2.Visible = gCurrentEmployee.PositionID < 3
        mnuDiagnosticsProceduresMaintenance.Visible = gCurrentEmployee.PositionID < 3
        mnuAdminStripSeparator3.Visible = gCurrentEmployee.PositionID < 3
        ToolStripMenuItemRequestsMaintenance.Visible = gCurrentEmployee.PositionID < 3
        ToolStripBillingPaymentManagementReport.Visible = gCurrentEmployee.PositionID < 3
        mnuAdminStripSeparator4.Visible = gCurrentEmployee.PositionID < 3
        ScannerDocumentMaintenanceToolStripMenuItem.Visible = gCurrentEmployee.PositionID < 3
        ToolStripSeparator4.Visible = gCurrentEmployee.PositionID < 3
        ToolStripSeparator17.Visible = gCurrentEmployee.PositionID < 3
        ToolStripMenuItem2.Visible = gCurrentEmployee.PositionID < 3
        'ChangeRefferingDoctorToolStripMenuItem.Visible = gCurrentEmployee.PositionID < 4
        'ChangeTreatingProviderToolStripMenuItem.Visible = gCurrentEmployee.PositionID < 4
        'ChangeBillingProviderToolStripMenuItem.Visible = gCurrentEmployee.PositionID < 4
        'ToolStripMenuItemChangePatientInformation.Visible = gCurrentEmployee.PositionID < 4
        PatientProcedureInformationToolStripMenuItem.Visible = gCurrentEmployee.PositionID < 2
        ResetPatientInformationToolStripMenuItem.Visible = gCurrentEmployee.PositionID < 2





        ToolStripSeparator1.Visible = gCurrentEmployee.PositionID < 4
        TechScheduleToolStripMenuItem.Visible = gCurrentEmployee.PositionID < 3
        InsuranceStatisticsReportToolStripMenuItem.Visible = gCurrentEmployee.PositionID < 3
        'ToolStripBillingPaymentManagementReport.Visible = gCurrentEmployee.PositionID = 1
        If gCurrentEmployee.SC = False Then
            'lblPosition.Image = Nothing
        End If
        If gCurrentEmployee.PositionID < 3 Then
            PatientsScheduleReportToolStripMenuItem.ForeColor = Color.SteelBlue
            PatientsScheduleReportToolStripMenuItem.Font = New Font(PatientsScheduleReportToolStripMenuItem.Font, FontStyle.Bold)
        End If
        'ToolStripButtonInsuranceMainenance.Visible = False
        If gCurrentEmployee.PositionID < 3 Then
            ToolStripButtonInsuranceMainenance.Visible = True
            BillingTemplatesMaintenanceToolStripMenuItem.Visible = True
            'ShowBillingRemindersToolStripMenuItem.Visible = True
            'Check_Billing_Reminders()
        End If
        If gCurrentEmployee.PositionID = 4 Or gCurrentEmployee.PositionID = 10 Then ' FronDesk / Technician
            ToolStripButtonInsuranceMainenance.Visible = False
            ToolStripButtonBilling.Visible = False
            ToolStripButtonBillMaintenance.Visible = False
            InsuranceStatisticsReportToolStripMenuItem.Visible = False
            TreatmentStatisticReport.Visible = False
            BillingToolStripMenuItem1.Visible = False
            CollectionToolStripMenuItem.Visible = False
            ToolStripButtonCollection.Visible = False
            AdminMessagingToolStripMenuItem.Visible = False
            ToolStripSeparator10.Visible = False
            ToolStripSeparator1.Visible = False
            ToolStripSeparator7.Visible = False
            AdministrativeToolsToolStripMenuItem.Visible = False
        End If

        TodaysScheduledProceduresToolStripMenuItem.Visible = False ' Not In USe - Until Tech Touch Screen
        SearchToolStripMenuItem.Visible = False
    End Sub
    Private Sub LoadSettings()
        FullScreenToolStripMenuItem.Checked = Not gFullScreen
        FullScreenToolStripMenuItem_Click(Nothing, Nothing)
    End Sub
    Private Sub Setup_Menus(ByVal mnu As ToolStripMenuItem)
        Dim m
        Dim mnuVisible As Boolean
        For Each m In mnu.DropDownItems
            mnuVisible = True
            If Val(m.Tag) > 0 Then
                m.Visible = Val(m.Tag) = gOfficeTypeID
                mnuVisible = Val(m.Tag) = gOfficeTypeID
            End If
            If TypeOf m Is ToolStripMenuItem Then
                If mnuVisible Then
                    If m.DropDownItems.Count > 0 Then
                        Setup_Menus(m)
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub SetFormBackcolor()
        Dim ctl As Control
        Dim mdi As MdiClient
        For Each ctl In Controls
            If TypeOf ctl Is MdiClient Then
                mdi = DirectCast(ctl, MdiClient) '/// cast mdi as the Control.            
                'mdi.BackColor = Me.BackColor

                Exit For
            End If

        Next
    End Sub
    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        frmAboutBox.ShowDialog()
    End Sub

    Private Sub UserMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Timer30Sec_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer5Sec.Tick
        ' Check IdleTime
        gIdleTimeCurrent = GetIdleTime() / 1000
        lblTime.Text = Now.ToString("hh:mm tt")
        If gCurrentEmployee.PositionID = 6 Then

        End If
    End Sub
    Private Sub Check_Billing_Reminders()
        ' Dim Reader As SqlClient.SqlDataReader


    End Sub

    Private Sub FullScreenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FullScreenToolStripMenuItem.Click
        FullScreenToolStripMenuItem.Checked = Not FullScreenToolStripMenuItem.Checked

        If FullScreenToolStripMenuItem.Checked Then
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Me.WindowState = FormWindowState.Normal
            Application.DoEvents()
            Me.WindowState = FormWindowState.Maximized
        Else
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        End If
        gFullScreen = FullScreenToolStripMenuItem.Checked
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Ret As DialogResult
        Ret = frmProperties.ShowDialog()
        frmProperties.Dispose()
        If Ret = Windows.Forms.DialogResult.OK Then
            ' Reload System

        End If
    End Sub

    Private Sub SchedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ToolStripButton4_Click(sender, e)
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonSchedule.Click
        gfrmScheduleLoaded = True
        SchedToolStripMenuItem.Enabled = False
        ToolStripButtonSchedule.Enabled = False
        If gOfficeTypeID = 1 Then
            frmSchedule.MdiParent = Me
            'frmSchedule.Size = New Size(Me.Width, Me.Height)
            frmSchedule.WindowState = FormWindowState.Maximized
            Application.DoEvents()
            frmSchedule.Show()
            frmSchedule.BringToFront()
            frmSchedule.WindowState = FormWindowState.Maximized
        Else

            frmSchedulePTFrontDesk.MdiParent = Me
            'frmSchedulePTFrontDesk.Size = New Size(Me.Width, Me.Height)
            frmSchedulePTFrontDesk.WindowState = FormWindowState.Maximized
            Application.DoEvents()
            frmSchedulePTFrontDesk.Show()
            frmSchedulePTFrontDesk.BringToFront()
            frmSchedulePTFrontDesk.WindowState = FormWindowState.Maximized

            'frmSchedulePT.MdiParent = Me
            ''frmSchedulePT.Size = New Size(Me.Width, Me.Height)
            'frmSchedulePT.WindowState = FormWindowState.Maximized
            'Application.DoEvents()
            'frmSchedulePT.Show()
            'frmSchedulePT.BringToFront()
            'frmSchedulePT.WindowState = FormWindowState.Maximized
        End If
        SchedToolStripMenuItem.Enabled = True
        ToolStripButtonSchedule.Enabled = True
    End Sub

    Private Sub ToolStripMenuItem2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        frmProperties.ShowDialog()
        frmProperties.Dispose()
        lblServer.Text = gSQLServerName
        If gRestart = True Then
            MsgBox("In order to apply the new system settings, eMedical Office should be restarted.", MsgBoxStyle.Exclamation)
            Me.Close()
            If FormsCollection.Forms.Count = 0 Then
                Application.Restart()
            Else
                MsgBox("Unable to restart eMedical Office automatially." & vbCrLf & vbCrLf & "Please save all unsaved data and restart  eMedical Office manually.", MsgBoxStyle.Critical)
            End If
        End If
    End Sub

    Private Sub ProcedureMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProcedureMaintenanceToolStripMenuItem.Click
        frmProcedureMaintenance.ShowDialog()
        frmProcedureMaintenance.Dispose()
    End Sub

    Private Sub InsurancesMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InsurancesMaintenanceToolStripMenuItem.Click

        Dim frm As Form = FormsCollection.FindForm("frmInsuranceMaintenance")
        If Not frm Is Nothing Then
            frm.WindowState = FormWindowState.Normal
            frm.BringToFront()
            Exit Sub
        Else
            'frmInsuranceMaintenance.Width = 1000

            frmInsuranceMaintenance.WindowState = FormWindowState.Normal
            frmInsuranceMaintenance.Location = New Point(Me.Left + ((Width - frmInsuranceMaintenance.Size.Width) \ 2), Me.Top + ((Height - frmInsuranceMaintenance.Size.Height) \ 2))
            frmInsuranceMaintenance.Show(Me)
            frmInsuranceMaintenance.BringToFront()
        End If
    End Sub
    Private Sub AttorneyMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AttorneyMaintenanceToolStripMenuItem.Click
        frmAttorneyMaintenance.ShowDialog()
        frmAttorneyMaintenance.Dispose()
    End Sub

    Private Sub TransportationMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransportationMaintenanceToolStripMenuItem.Click
        frmTransportationCompaniesMaintenance.ShowDialog()
        frmTransportationCompaniesMaintenance.Dispose()
    End Sub

    Private Sub InjuryTypesMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InjuryTypesMaintenanceToolStripMenuItem.Click
        frmInjuryTypesMaintenance.ShowDialog()
        frmInjuryTypesMaintenance.Dispose()
    End Sub

    Private Sub lblPosition_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblPosition.DoubleClick
        If Not lblPosition.Image Is Nothing Then
            gCurrentEmployee.SC = False
            Setup_Security()
        End If
    End Sub

    Private Sub ScannerDocumentMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScannerDocumentMaintenanceToolStripMenuItem.Click
        frmDocumentsMaintenance.ShowDialog()
        frmDocumentsMaintenance.Dispose()
    End Sub

    Public Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonPatientProfile.Click

        Dim frm As Form = FormsCollection.FindForm("frmPatient")
        If Not frm Is Nothing Then
            frm.WindowState = FormWindowState.Normal
            frm.BringToFront()
            Exit Sub
        Else
            'frmPatient.Width = 1225
            'frmPatient.WindowState = FormWindowState.Normal
            'frmPatient.Location = New Point(Me.Left + ((Width - frmPatient.Size.Width) \ 2), Me.Top + ((Height - frmPatient.Size.Height) \ 2))
            gWindow_Settings(frmPatient, ReadWrite.sRead)
            frmPatient.MdiParent = Me
            frmPatient.Show()
            frmPatient.BringToFront()
        End If

    End Sub
    Public gfrmSearchLoaded As Boolean
    Private Sub ToolStripButtonSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonSearch.Click
        frmQuickSearch.MinimizeBox = False
        frmQuickSearch.MaximizeBox = False

        frmQuickSearch.ShowDialog(Me)
        frmQuickSearch.Dispose()
    End Sub
    Private Sub StopTimers(Optional ByVal pStop As Boolean = True)
        If pStop Then
            TimerRefresh.Stop()
            Timer5Sec.Stop()
        Else
            TimerRefresh.Start()
            Timer5Sec.Start()
        End If
    End Sub
    Private Sub NewPatientToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewPatientToolStripMenuItem.Click
        ToolStripButton1_Click(Nothing, Nothing)
    End Sub

    Private Sub SchedToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SchedToolStripMenuItem.Click
        ToolStripButton4_Click(Nothing, Nothing)
    End Sub

    Private Sub UnlockPatientProfilesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuUnlockPatientProfiles.Click
        frmUnlockProfiles.ShowDialog()
        frmUnlockProfiles.Dispose()
    End Sub

    Private Sub SearchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchToolStripMenuItem.Click
        If gfrmSearchLoaded = False Then
            gfrmSearchLoaded = True
            frmSearch.StartPosition = FormStartPosition.CenterParent
            frmSearch.Show(Me)
        Else
            frmSearch.StartPosition = FormStartPosition.Manual
            frmSearch.Location = New Point(Me.Left + ((Width - frmSearch.Size.Width) \ 2), Me.Top + ((Height - frmSearch.Size.Height) \ 2))
            frmSearch.Show(Me)
        End If

    End Sub
    Private Sub TransportationRequestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemTransportationRequest.Click
        Application.DoEvents()
        frmTransportationRequest.MinimizeBox = False
        frmTransportationRequest.MaximizeBox = False

        frmTransportationRequest.ShowDialog(Me)
        frmTransportationRequest.Dispose()
    End Sub

    Private Sub PatientsScheduleReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PatientsScheduleReportToolStripMenuItem.Click
        Application.DoEvents()
        Application.DoEvents()
        frmReportPatientVisits.MdiParent = Me
        frmReportPatientVisits.WindowState = FormWindowState.Normal
        Application.DoEvents()
        frmReportPatientVisits.Show()
        frmReportPatientVisits.BringToFront()
        frmReportPatientVisits.WindowState = FormWindowState.Normal


        'frmReportPatientVisits.ShowDialog(Me)
        'frmReportPatientVisits.Dispose()

    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Application.DoEvents()
        TransportationRequestToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub PatientInformationReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PatientInformationReportToolStripMenuItem.Click
        Application.DoEvents()
        frmReportPatientInfo.MinimizeBox = False
        frmReportPatientInfo.MaximizeBox = False

        frmReportPatientInfo.ShowDialog(Me)
        frmReportPatientInfo.Dispose()
    End Sub

    Private Sub TodaysScheduledProceduresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TodaysScheduledProceduresToolStripMenuItem.Click

    End Sub
    Dim gfrmBillingLoaded As Boolean
    Private Sub Load_Data()

    End Sub

    Private Sub DiagnosisMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DiagnosisMaintenanceToolStripMenuItem.Click
        frmDiagnosisMaintenance.ShowDialog()
        frmDiagnosisMaintenance.Dispose()
    End Sub

    Private Sub TechScheduleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TechScheduleToolStripMenuItem.Click
        frmScheduleTechnician.ShowDialog()
        frmScheduleTechnician.Dispose()
    End Sub

    Private Sub QuickSearchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuickSearchToolStripMenuItem.Click
        ToolStripButtonSearch_Click(Nothing, Nothing)
    End Sub

    Private Sub BillingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BillingToolStripMenuItem.Click
        ToolStripButtonBilling_Click(Nothing, Nothing)
    End Sub
    Private Sub BillMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BillMaintenanceToolStripMenuItem.Click
        ToolStripButtonBillMaintenance_Click(Nothing, Nothing)
    End Sub

    Private Sub RequestImageDiskToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RequestImageDiskToolStripMenuItem.Click
        frmImageDiskRequest.MinimizeBox = False
        frmImageDiskRequest.MaximizeBox = False

        frmImageDiskRequest.ShowDialog(Me)
        frmImageDiskRequest.Dispose()
    End Sub

    Private Sub ProduceDiskToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProduceDiskToolStripMenuItem.Click
        frmImageDiskProcessing.MinimizeBox = False
        frmImageDiskProcessing.MaximizeBox = False

        frmImageDiskProcessing.ShowDialog(Me)
        frmImageDiskProcessing.Dispose()
    End Sub

    Private Sub ToolStripButtonBillMaintenance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonBillMaintenance.Click
        frmBillingManagement.MdiParent = Me
        'frmBillingManagement.Size = New Size(Me.Width, Me.Height)
        frmBillingManagement.WindowState = FormWindowState.Maximized
        Application.DoEvents()
        frmBillingManagement.Show()
        frmBillingManagement.BringToFront()
        frmBillingManagement.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ToolStripButtonBilling_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonBilling.Click
        gfrmBillingLoaded = True
        ' tEMP
        If gOfficeTypeID = 1 Then
            frmBilling.MdiParent = Me
            frmBilling.Size = New Size(Me.Width, Me.Height)
            frmBilling.WindowState = FormWindowState.Maximized
            Application.DoEvents()
            frmBilling.Show()
            frmBilling.BringToFront()
            frmBilling.WindowState = FormWindowState.Maximized
        Else
            frmBillingPT.MdiParent = Me
            frmBillingPT.Size = New Size(Me.Width, Me.Height)
            frmBillingPT.WindowState = FormWindowState.Maximized
            Application.DoEvents()
            frmBillingPT.Show()
            frmBillingPT.BringToFront()
            frmBillingPT.WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub ImageDiskReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImageDiskReportToolStripMenuItem.Click
        frmImageDiskReport.MinimizeBox = False
        frmImageDiskReport.MaximizeBox = False

        frmImageDiskReport.ShowDialog(Me)
        frmImageDiskReport.Dispose()
    End Sub

    Private Sub CollectionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ToolStripMenuItemCDReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemCDReport.Click
        frmImageDiskReport.MinimizeBox = False
        frmImageDiskReport.MaximizeBox = False

        frmImageDiskReport.ShowDialog(Me)
        frmImageDiskReport.Dispose()
    End Sub
    Private Function ScanDocumentFromScanner(ByVal DocProfileID As Integer) As Boolean
        Dim PatientID As Long
        frmDocumentScannerPDF.IniDocProfile = DocProfileID
        frmDocumentScannerPDF.PatientID = 0
        frmDocumentScannerPDF.MinimizeBox = False
        frmDocumentScannerPDF.MaximizeBox = False

        If frmDocumentScannerPDF.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            ScanDocumentFromScanner = True
        End If
        frmDocumentScannerPDF.Dispose()
    End Function
    Private Function ScanDocumentFromScannerApplication(ByVal DocProfileID As Integer) As Boolean
        Dim PatientID As Long
        If gScannerFolder = "" Then
            MsgBox("Unable to scan. The Scanner Folder has not been specified." & vbCrLf & "Please call your system administrator.", MsgBoxStyle.Exclamation)
            Exit Function
        End If
        If IO.Directory.Exists(gScannerFolder) = False Then
            MsgBox("Unable to scan. Invalid Scanner Folder specified." & vbCrLf & "Please call your system administrator.", MsgBoxStyle.Exclamation)
            Exit Function
        End If
        frmDocumentScannerExternalProgram.IniDocProfile = DocProfileID
        frmDocumentScannerExternalProgram.PatientID = 0
        frmDocumentScannerExternalProgram.MinimizeBox = False
        frmDocumentScannerExternalProgram.MaximizeBox = False

        If frmDocumentScannerExternalProgram.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            ScanDocumentFromScannerApplication = True
        End If
        frmDocumentScannerExternalProgram.Dispose()
    End Function
    Private Sub POMToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POMToolStripMenuItem.Click
        Dim Ret As Boolean
        If gScannerMode = 1 Then
            Ret = ScanDocumentFromScannerApplication(3)
        Else
            Ret = ScanDocumentFromScanner(3)
        End If
    End Sub

    Private Sub FindPOMToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindPOMToolStripMenuItem.Click
        frmFindPOM.MinimizeBox = False
        frmFindPOM.MaximizeBox = False

        frmFindPOM.ShowDialog(Me)
        frmFindPOM.Dispose()
    End Sub

    Private Sub MessagePoolToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MessagePoolToolStripMenuItem.Click
        frmMessagePool.MinimizeBox = False
        frmMessagePool.MaximizeBox = False

        frmMessagePool.ShowDialog(Me)
        frmMessagePool.Dispose()
    End Sub

    Private Sub PhoneBookToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PhoneBookToolStripMenuItem.Click
        frmPhoneBook.MinimizeBox = False
        frmPhoneBook.MaximizeBox = False

        frmPhoneBook.ShowDialog(Me)
        frmPhoneBook.Dispose()
    End Sub

    Private Sub BillingCompaniesMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BillingCompaniesMaintenanceToolStripMenuItem.Click
        frmBillingCompanyMaintenance.MinimizeBox = False
        frmBillingCompanyMaintenance.MaximizeBox = False

        frmBillingCompanyMaintenance.ShowDialog(Me)
        frmBillingCompanyMaintenance.Dispose()
    End Sub

    Private Sub SignInSheetByDateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SignInSheetByDateToolStripMenuItem.Click
        frmReportPatientVisitsTodayProcedures.MinimizeBox = False
        frmReportPatientVisitsTodayProcedures.MaximizeBox = False

        frmReportPatientVisitsTodayProcedures.ShowDialog(Me)
        frmReportPatientVisitsTodayProcedures.Dispose()
    End Sub

    Private Sub SignInSheetByPatientToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SignInSheetByPatientToolStripMenuItem.Click
        frmReportPatientVisitsProceduresByPatient.MinimizeBox = False
        frmReportPatientVisitsProceduresByPatient.MaximizeBox = False

        frmReportPatientVisitsProceduresByPatient.ShowDialog(Me)
        frmReportPatientVisitsProceduresByPatient.Dispose()
    End Sub

    Private Sub OutBillingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OutBillingToolStripMenuItem.Click
        gfrmBillingLoaded = True
        frmOutBillingMaintenance.MdiParent = Me
        'frmOutBillingMaintenance.Size = New Size(Me.Width, Me.Height)
        frmOutBillingMaintenance.WindowState = FormWindowState.Maximized
        Application.DoEvents()
        frmOutBillingMaintenance.Show()
        frmOutBillingMaintenance.BringToFront()
        frmOutBillingMaintenance.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub PatientsProcedureReadingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PatientsProcedureReadingsToolStripMenuItem.Click, PatientsProcedureReadingsToolStripMenuItem1.Click
        Application.DoEvents()
        frmReadings.MinimizeBox = False
        frmReadings.MaximizeBox = False

        frmReadings.ShowDialog(Me)
        frmReadings.Dispose()
    End Sub

    Private Sub MRIDataExportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MRIDataExportToolStripMenuItem.Click
        Application.DoEvents()
        frmMRIExport.MinimizeBox = False
        frmMRIExport.MaximizeBox = False

        frmMRIExport.ShowDialog(Me)
        frmMRIExport.Dispose()
    End Sub

    Private Sub NoFaultMissingClaimNumberReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NoFaultMissingClaimNumberReportToolStripMenuItem.Click
        Application.DoEvents()
        frmMissingInsuranceInformation.MinimizeBox = False
        frmMissingInsuranceInformation.MaximizeBox = False

        frmMissingInsuranceInformation.ShowDialog(Me)
        frmMissingInsuranceInformation.Dispose()
    End Sub

    Private Sub ChangeTreatingProviderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PatientProcedureInformationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub InsuranceStatisticsReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InsuranceStatisticsReportToolStripMenuItem.Click
        Application.DoEvents()
        frmInsuranceCompanyStatistics.MinimizeBox = False
        frmInsuranceCompanyStatistics.MaximizeBox = False

        frmInsuranceCompanyStatistics.ShowDialog(Me)
        frmInsuranceCompanyStatistics.Dispose()
    End Sub

    Private Sub NoFaultMissingInformationReceivedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NoFaultMissingInformationReceivedToolStripMenuItem.Click
        Application.DoEvents()
        frmIncompletePatientInformation.MinimizeBox = False
        frmIncompletePatientInformation.MaximizeBox = False

        frmIncompletePatientInformation.ShowDialog(Me)
        frmIncompletePatientInformation.Dispose()
    End Sub

    Private Sub BillingTemplatesMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BillingTemplatesMaintenanceToolStripMenuItem.Click
        Application.DoEvents()
        frmBillingTemplates.MinimizeBox = False
        frmBillingTemplates.MaximizeBox = False

        frmBillingTemplates.ShowDialog(Me)
        frmBillingTemplates.Dispose()
    End Sub

    Private Sub ReferringBillingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub QuickScheduleReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuickScheduleReportToolStripMenuItem.Click
        Application.DoEvents()
        frmQuickScheduleReport.MdiParent = Me
        gWindow_Settings(frmQuickScheduleReport, ReadWrite.sRead)
        Application.DoEvents()
        frmQuickScheduleReport.Show()
        frmQuickScheduleReport.BringToFront()
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        QuickScheduleReportToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub ReferringOfficesStatisticReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReferringOfficesStatisticReportToolStripMenuItem.Click
        Application.DoEvents()
        frmOfficeStatistics.MinimizeBox = False
        frmOfficeStatistics.MaximizeBox = False

        frmOfficeStatistics.ShowDialog(Me)
        frmOfficeStatistics.Dispose()
    End Sub

    Private Sub ChangeRefferingDoctorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        If frmAttorneyAssignCaseNumber.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim frm As Form = FormsCollection.FindForm("frmBillingManagement")
            If Not frm Is Nothing Then
                CType(frm, frmBillingManagement).ButtonFind_Click(Nothing, Nothing)
            End If
        End If
        frmAttorneyAssignCaseNumber.Dispose()
    End Sub

    Private Sub MDIForm1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

    End Sub

    Private Sub MDIForm1_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd

    End Sub
    Private SkeepChecked As Boolean
    Public Sub TimerRefresh_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerRefresh.Tick
        Dim Saverequests As Integer = ListViewRequests.Items.Count
        Dim SaveBills As Integer = ListViewBills.Items.Count
        Dim SaveNF2 As Integer = ListViewNF2.Items.Count
        Dim SaveReDone As Integer = ListViewSchedule.Items.Count
        Dim SaveEUO As Integer = ListViewEUOIME.Items.Count
        If gIdleTimeCurrent > 1200 Then Exit Sub


        TimerRefresh.Interval = 60000
        TimerRefresh.Stop()

        If PanelMessage.Visible = False Then
            lblMessage.Text = ""
            CheckMessages()
        End If
        If CheckBoxDoNotShowRequests.Checked And CheckBoxDoNotShowBills.Checked And ShowToBeScheduled.Checked Then
            ListViewSchedule.Items.Clear()
            ListViewBills.Items.Clear()
            ListViewRequests.Items.Clear()
            Exit Sub
        End If

        'If gCurrentEmployee.PositionID <> 6 And gCurrentEmployee.PositionID <> 4 And gCurrentEmployee.PositionID <> 1 And gCurrentEmployee.PositionID <> 2 And gCurrentEmployee.PositionID <> 3 Then Exit Sub

        If ShowToBeScheduled.Checked = False Then
            If gCurrentEmployee.PositionID = 4 Or gCurrentEmployee.PositionID = 1 Or gCurrentEmployee.PositionID = 2 Or gCurrentEmployee.PositionID = 3 Then Load_ReDoneProcedures()
            Application.DoEvents()
        Else
            ListViewSchedule.Items.Clear()
        End If
        If ShowToBeScheduled.Checked = False Then
            Load_EUOIME() ' Admin, Billing
        Else
            ListViewEUOIME.Items.Clear()
        End If
        Application.DoEvents()




        If CheckBoxDoNotShowRequests.Checked = False Then
            Load_Requests()
        Else
            ListViewRequests.Items.Clear()
        End If

        If CheckBoxDoNotShowBills.Checked = False Then
            If gCurrentEmployee.PositionID = 6 Or gCurrentEmployee.PositionID = 1 Then Load_Bills() ' Admin, Billing
            Application.DoEvents()
            If gCurrentEmployee.PositionID = 6 Or gCurrentEmployee.PositionID = 1 Then Load_NF2() ' Admin, Billing
            Application.DoEvents()
        Else
            ListViewBills.Items.Clear()
            ListViewNF2.Items.Clear()
        End If
        If ListViewRequests.Items.Count > 0 Then
            PanelRequests.Left = Width
            Application.DoEvents()
            PanelRequests.Visible = True
        Else
            PanelRequests.Visible = False
        End If
        SkeepChecked = True
        If ListViewSchedule.Items.Count > 0 Or ListViewEUOIME.Items.Count > 0 Then
            If ListViewSchedule.Items.Count = 0 Then
                SplitContainerEUOIME.Panel1Collapsed = True
            Else
                SplitContainerEUOIME.Panel1Collapsed = False
                If LastSelectedListView Is ListViewSchedule Then LastSelectedListView = Nothing
            End If
            If ListViewEUOIME.Items.Count = 0 Then
                SplitContainerEUOIME.Panel2Collapsed = True
            Else
                SplitContainerEUOIME.Panel2Collapsed = False
                If LastSelectedListView Is ListViewEUOIME Then LastSelectedListView = Nothing
            End If
            PanelSchedule.Left = Width
            Application.DoEvents()
            PanelSchedule.Visible = True
        Else
            PanelSchedule.Visible = False
            LastSelectedListView = Nothing
        End If
        SplitContainer1.Panel1Collapsed = ListViewBills.Items.Count = 0
        SplitContainer1.Panel2Collapsed = ListViewNF2.Items.Count = 0
        If ListViewBills.Items.Count > 0 Or ListViewNF2.Items.Count > 0 Then
            PanelBills.Left = Width
            Application.DoEvents()
            PanelBills.Visible = True
        Else
            PanelBills.Visible = False
        End If

        SkeepChecked = False
        'Application.DoEvents()
        On Error Resume Next
        LockWindowUpdate(Me.Handle)
        If Saverequests < ListViewRequests.Items.Count Or SaveBills < ListViewBills.Items.Count Or SaveNF2 < ListViewNF2.Items.Count Or SaveEUO < ListViewEUOIME.Items.Count Or SaveReDone < ListViewSchedule.Items.Count Then
            PictureBoxPanelBills.Visible = True
            PictureBoxPanelReminders.Visible = True
            PictureBoxSchedule.Visible = True
            TimerFlashRedBall.Enabled = True
            My.Computer.Audio.Play(My.Resources.Notify, AudioPlayMode.Background)
            Me.Refresh()

        Else

            If lblMessage.Text <> "" And PanelMessage.Visible = False Then
                My.Computer.Audio.Play(My.Resources.Notify, AudioPlayMode.Background)
                Me.Refresh()
            End If
        End If
        If lblMessage.Text <> "" And PanelMessage.Visible = False Then
            PanelMessage.Visible = True
            PanelMessage.BringToFront()
        End If
        LockWindowUpdate(0)

        TimerRefresh.Start()
    End Sub
    Private Sub CheckMessages()
        Dim SQL As String
        Dim Reader As SqlClient.SqlDataReader
        Dim gr As Graphics = Me.CreateGraphics()
        Dim TextHeight As Single
        lblMessage.Text = ""
        ToolTip1.SetToolTip(lblMessage, "")
        SQL = "SELECT     TOP (1) MessagesRecipients.ID, Messages.MessageTitle, Messages.MessageBody, MessagesRecipients.ConfirmedDT"
        SQL &= " FROM MessagesRecipients INNER JOIN Messages ON MessagesRecipients.MessageID = Messages.MessageID "
        SQL &= " WHERE MessagesRecipients.ConfirmedDT IS NULL and MessagesRecipients.ToID = " & gCurrentEmployee.EmpID
        Reader = gSQLGetDataReader(SQL)
        If Reader.HasRows Then
            Reader.Read()
            lblMessageTitle.Text = Reader("MessageTitle").ToString.Trim
            lblMessage.Text = Reader("MessageBody").ToString.Trim
            PanelMessage.Tag = Reader("ID").ToString.Trim
            'TextHeight = gr.MeasureString(lblMessage.Text, lblMessage.Font).Height
            PanelMessage.Height = lblMessage.Height + 20
            ToolTip1.SetToolTip(lblMessage, Reader("MessageBody").ToString.Trim)
        End If
    End Sub
    Private Sub Load_EUOIME()
        Dim SQL As String
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        ListViewEUOIME.Items.Clear()
        SQL = "SELECT  InsuranceExaminations.ID,   Patients.FName + ' ' + Patients.MI + ' ' + Patients.LName + ' ' + Patients.Suffix AS PatName, Patients.PatientID, Patients.DOA, InsuranceExaminations.ScheduleDate AS SDate, InsuranceExaminationStatuses.Description AS Status, InsuranceExaminations.StatusID, InsuranceExaminationsTypes.Description AS SType "
        SQL &= " FROM         InsuranceExaminations INNER JOIN Patients ON InsuranceExaminations.PatientID = Patients.PatientID INNER JOIN InsuranceExaminationStatuses ON InsuranceExaminations.StatusID = InsuranceExaminationStatuses.StatusID INNER JOIN InsuranceExaminationsTypes ON InsuranceExaminations.TypeID = InsuranceExaminationsTypes.TypeID "
        SQL &= " WHERE     (Patients.OfficeID=" & gOfficeID & ") AND (Patients.CaseTypeID = 1) AND (Patients.CaseStatusID = 1) AND (InsuranceExaminations.StatusID = 1) AND (DATEDIFF(d, GETDATE(), InsuranceExaminations.ScheduleDate) < 7) and (InsuranceExaminations.ScheduleDate >= '" & Now.ToShortDateString & " 00:00" & "') "
        SQL &= " ORDER BY SDate, SType "
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            LI = ListViewEUOIME.Items.Add(Reader("PatientID").ToString, 0)
            LI.UseItemStyleForSubItems = True
            LI.SubItems.Add(Reader("PatName").ToString)
            LI.SubItems.Add(Reader("SType").ToString)
            LI.Tag = Val(Reader("PatientID").ToString)
            LI.ToolTipText = "Scheduled: " & CDate(Reader("SDate").ToString).ToShortDateString & " Status: Not Confirmed"
            LI.SubItems(2).Tag = Val(Reader("ID").ToString)
        Loop

    End Sub
    Private Sub Load_ReDoneProcedures()
        Dim LI As ListViewItem
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim R As Integer
        Dim PatientID As Long
        Dim tMSG As String
        If gOfficeTypeID > 1 Then
            ListViewSchedule.Items.Clear()
            Exit Sub
        End If

        If ListViewSchedule.SelectedItems.Count > 0 Then
            PatientID = ListViewSchedule.SelectedItems(0).Tag
        End If
        ListViewSchedule.BeginUpdate()
        ListViewSchedule.Items.Clear()
        SQL = "SELECT  DISTINCT  Patients.InsertedDT, Patients.PatientID, isnull(Patients.FName,'') + ' ' + isnull(Patients.MI,'') + ' ' + isnull(Patients.LName,'') AS PatName, PatientProcedures.DoNotBillInd, PatientProcedures.DoNotBillAction"
        SQL &= " FROM         Patients INNER JOIN PatientProcedures ON Patients.PatientID = PatientProcedures.PatientID "
        SQL &= " WHERE     Patients.OfficeID = " & gOfficeID
        SQL &= " AND (Patients.CaseStatusID = 1 or (Patients.CaseStatusID = 4 and PatientProcedures.DoNotBillAction=1)) "
        SQL &= " AND (Patients.NoMoreAppointmentsInd = 0 or PatientProcedures.DoNotBillAction=1)"
        SQL &= " AND PatientProcedures.ProcedureStatusID = 0 "
        SQL &= " ORDER BY PatientProcedures.DoNotBillAction DESC, PatName "
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            LI = ListViewSchedule.Items.Add(Reader("PatientID").ToString)
            LI.SubItems.Add(Reader("PatName"))
            LI.UseItemStyleForSubItems = True
            LI.Tag = Reader("PatientID").ToString
            If Val(Reader("DoNotBillAction").ToString) = 1 Then
                LI.ForeColor = Color.Blue
                LI.ToolTipText = "Procedure should be ReDone"
            Else
                If IsDate(Reader("InsertedDT").ToString) Then
                    If DateDiff(DateInterval.Day, CDate(Reader("InsertedDT").ToString), Now) > 30 Then
                        LI.ForeColor = Color.Red
                        LI.ToolTipText = "ReDone! Patient's profile more then 30 days old."
                    End If
                Else
                    LI.ForeColor = Color.White
                End If

            End If
        Loop

        SQL = " SELECT DISTINCT Patients.InsertedDT, Patients.PatientID, isnull(Patients.FName,'') + ' ' + isnull(Patients.MI,'') + ' ' + isnull(Patients.LName,'') AS PatName, PatientProcedures.PatientID "
        SQL = SQL & " FROM         PatientProcedures INNER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID INNER JOIN Patients ON PatientProcedures.PatientID = Patients.PatientID "
        SQL = SQL & " WHERE Patients.OfficeID = " & gOfficeID & " AND Patients.CaseStatusID = 1 and (DATEDIFF(hh, Schedule.ScheduleDateTime, GETDATE()) >  " & gNoShowHours & ") AND (PatientProcedures.ProcedureStatusID = 1) "
        SQL = SQL & " ORDER BY PatName "

        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            LI = ListViewSchedule.Items.Add("NS-" & Reader("PatientID").ToString)
            LI.SubItems.Add(Reader("PatName"))
            LI.UseItemStyleForSubItems = True
            LI.Tag = Reader("PatientID").ToString
            LI.ToolTipText = "NoShow! Procedure should be rescheduled"
            If IsDate(Reader("InsertedDT").ToString) Then
                If DateDiff(DateInterval.Day, CDate(Reader("InsertedDT").ToString), Now) > 30 Then
                    LI.ForeColor = Color.Red
                    LI.BackColor = Color.LightGoldenrodYellow
                    LI.ToolTipText = "NoShow! Reschedule! Patient's profile more then 30 days old."
                End If
            End If
        Loop



        ListViewSchedule.EndUpdate()
    End Sub
    Private Sub Load_NF2()
        Dim LI As ListViewItem
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim R As Integer
        Dim PatientID As Long
        Dim tMSG As String
        If gOfficeTypeID = 1 Then
            ListViewNF2.Items.Clear()
            Exit Sub
        End If

        If ListViewNF2.SelectedItems.Count > 0 Then
            PatientID = ListViewNF2.SelectedItems(0).Tag
        End If
        ListViewNF2.BeginUpdate()
        ListViewNF2.Items.Clear()
        SQL = "SELECT     PatientID,  FName + ' ' + LName AS PName, DOA, InsuranceCompanyID, ClaimAddressID, PolicyNumber FROM  Patients "

        SQL &= " WHERE    OfficeID = " & gOfficeID & " AND NF2Date IS NULL "
        SQL &= " AND DOA <= '" & DateAdd(DateInterval.Day, -gNF2MinAge, Now.Date).ToString("MM/dd/yyyy 23:59") & "' "
        'SQL &= " AND DOA >= '" & DateAdd(DateInterval.Day, -gNF2MaxAge, Now.Date).ToString("MM/dd/yyyy 00:00") & "') "
        SQL &= " ORDER BY DOA"
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub


        Do Until Reader.Read = False

            If Val(Reader("InsuranceCompanyID").ToString) = 0 Or Val(Reader("ClaimAddressID").ToString) = 0 Or Reader("DOA").ToString = "" Or Reader("PolicyNumber").ToString = "" Then
                tMSG = Reader("PName").ToString & vbCrLf & vbCrLf & "Incomplete Profile. " & vbCrLf & vbCrLf
                If Val(Reader("InsuranceCompanyID").ToString) = 0 Then
                    tMSG &= "Insurance company is missing." & vbCrLf
                End If
                If Val(Reader("ClaimAddressID").ToString) = 0 Then
                    tMSG &= "Claim Address is missing." & vbCrLf
                End If
                If Val(Reader("DOA").ToString) = 0 Then
                    tMSG &= "DOA is missing." & vbCrLf
                End If
                If Reader("PolicyNumber").ToString = "" Then
                    tMSG &= "PolicyNumber is missing." & vbCrLf
                End If
                tMSG &= vbCrLf
                LI = ListViewNF2.Items.Add(Reader("PatientID").ToString, 2)
                LI.ToolTipText = tMSG
            Else
                LI = ListViewNF2.Items.Add(Reader("PatientID").ToString, 1)
                LI.ToolTipText = Reader("PName").ToString
            End If


            LI.Tag = Reader("PatientID").ToString

            LI.SubItems.Add(FormatDateTime(Reader("DOA").ToString, DateFormat.ShortDate))

            If CDate(Reader("DOA").ToString) < DateAdd(DateInterval.Day, -gNF2MaxAge, Now.Date).ToString("MM/dd/yyyy 00:00") Then
                LI.ForeColor = Color.Red
            Else
                LI.ForeColor = Color.Black
            End If
            If Val(Reader("PatientID").ToString) = PatientID Then
                LI.Selected = True
            End If
        Loop





        If ListViewNF2.Items.Count > 0 Then
            If SplitContainer1.Panel2Collapsed Then SplitContainer1.Panel2Collapsed = False
            If PatientID = 0 Then
                ListViewNF2.Items(0).Selected = True
                ListViewNF2.Items(0).EnsureVisible()
            Else
                ListViewNF2.SelectedItems(0).EnsureVisible()
            End If
        Else
            If SplitContainer1.Panel2Collapsed = False Then SplitContainer1.Panel2Collapsed = True
        End If
        ListViewNF2.EndUpdate()
    End Sub

    Private Sub Load_Requests()
        Dim LI As ListViewItem
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim R As Integer
        Dim SaverequestID As Long
        If ListViewRequests.SelectedItems.Count > 0 Then
            SaverequestID = ListViewRequests.SelectedItems(0).Tag
        End If
        ListViewRequests.BeginUpdate()
        ListViewRequests.Items.Clear()
        SQL = "SELECT Priority, RequestID, RequestDescription, RequestDate FROM BillingRequests inner join Patients on BillingRequests.PatientID = Patients.PatientID  Where RequestStatusID < 3 and ResponsibleEmpID = " & gCurrentEmployee.EmpID
        SQL &= " AND  Patients.OfficeID = " & gOfficeID & " "
        SQL &= " AND  Patients.CaseStatusID <> 3 and CaseStatusID<>5 "
        SQL &= " order by Priority, RequestDate desc"
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub


        Do Until Reader.Read = False
            LI = ListViewRequests.Items.Add(FormatDateTime(Reader("RequestDate").ToString, DateFormat.ShortDate))
            LI.Tag = Reader("RequestID").ToString
            LI.SubItems.Add(Reader("RequestDescription").ToString)
            LI.ToolTipText = Reader("RequestDescription").ToString
            If Val(Reader("Priority").ToString) = 1 Then
                LI.Font = New Font(LI.Font, FontStyle.Bold)
            End If
            If Val(Reader("RequestID").ToString) = SaverequestID Then
                LI.Selected = True
            End If
        Loop
        If ListViewRequests.Items.Count > 0 Then
            If SaverequestID = 0 Then
                ListViewRequests.Items(0).Selected = True
                ListViewRequests.Items(0).EnsureVisible()
            End If
        End If
        ListViewRequests.EndUpdate()
    End Sub
    Private Sub Load_Bills()
        Dim SQL As String = "SELECT Bills.BillID, BillStatus.Description AS Status, Bills.BillStatusID FROM Bills INNER JOIN BillStatus ON Bills.BillStatusID = BillStatus.BillStatusID WHERE Bills.BillStatusID = 1 and OfficeID=" & gOfficeID & " "
        Dim LI As ListViewItem
        Dim Reader As SqlClient.SqlDataReader
        ListViewBills.BeginUpdate()
        ListViewBills.Items.Clear()
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            LI = ListViewBills.Items.Add(Reader("BillID").ToString)
            LI.Tag = Reader("BillID").ToString
            LI.SubItems.Add(Reader("Status").ToString)
        Loop
        If ListViewBills.Items.Count > 0 Then
            ListViewBills.Items(0).Selected = True
        End If
        ListViewBills.EndUpdate()
    End Sub
    Private Sub TimerReminderReset_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerReminderReset.Tick
        TimerReminderReset.Enabled = False
        ListViewRequests.BackColor = Color.WhiteSmoke
        ListViewBills.BackColor = Color.WhiteSmoke
        ListViewNF2.BackColor = Color.WhiteSmoke

    End Sub


    Private Sub Clear_Request_Details()
        ListViewrequestActions.Items.Clear()
        ListViewRequestsDetails.Items(0).SubItems(1).Text = ""
        ListViewRequestsDetails.Items(1).SubItems(1).Text = ""
        ListViewRequestsDetails.Items(2).SubItems(1).Text = ""
        ListViewRequestsDetails.Items(3).SubItems(1).Text = ""
        ListViewRequestsDetails.Items(4).SubItems(1).Text = ""
        ListViewRequestsDetails.Items(5).SubItems(1).Text = ""
        ListViewRequestsDetails.Items(6).SubItems(1).Text = ""
        ListViewRequestsDetails.Items(7).SubItems(1).Text = ""
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ImageDisksProcessScanPOMToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImageDisksProcessScanPOMToolStripMenuItem.Click
        Dim Ret As Boolean
        Application.DoEvents()
        If gScannerMode = 1 Then
            Ret = ScanDocumentFromScannerApplication(18)
        Else
            Ret = ScanDocumentFromScanner(18)
        End If
    End Sub

    Private Sub btnShowPatientInformation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub
    Private Sub ListViewRequests_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewRequests.SelectedIndexChanged
        gHighlightListviewItem(ListViewRequests)
        If ListViewRequests.SelectedItems.Count = 0 Then
            Clear_Request_Details()
            Exit Sub
        End If


        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim R As Integer
        Dim LI As ListViewItem
        Clear_Request_Details()
        SQL = "SELECT    BillingRequests.RequestTypeID, BillingRequests.RequestID, BillingRequests.BillID, BillingRequests.PatientID, BillingRequests.RequestDescription, BillingRequests.RequestFrom,  BillingRequests.ResponsibleEmpID, BillingRequests.RequestDate, BillingRequests.RequestStatusID, BillingRequests.StatusDate, BillingRequests.CDProcedures, BillingRequestStatuses.Description AS Status, Patients.FName + ' ' + Patients.MI + ' ' + Patients.LName AS pName "
        SQL &= " FROM         BillingRequests INNER JOIN BillingRequestStatuses ON BillingRequests.RequestStatusID = BillingRequestStatuses.StatusID INNER JOIN Patients ON BillingRequests.PatientID = Patients.PatientID "
        SQL &= "Where BillingRequests.RequestID = " & Val(ListViewRequests.SelectedItems(0).Tag)

        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        If Reader.HasRows Then
            Reader.Read()
            ListViewRequestsDetails.Items(0).SubItems(1).Tag = Reader("RequestID").ToString
            ListViewRequestsDetails.Items(0).SubItems(1).Text = Reader("PatientID").ToString
            ListViewRequestsDetails.Items(1).SubItems(1).Text = Reader("PName").ToString
            ListViewRequestsDetails.Items(2).SubItems(1).Text = Reader("BillID").ToString
            ListViewRequestsDetails.Items(3).SubItems(1).Text = Reader("RequestDescription").ToString
            ListViewRequestsDetails.Items(3).SubItems(1).Tag = Reader("RequestTypeID").ToString
            ListViewRequestsDetails.Items(4).SubItems(1).Text = Reader("RequestFrom").ToString
            ListViewRequestsDetails.Items(5).SubItems(1).Text = FormatDateTime(Reader("RequestDate").ToString, DateFormat.ShortDate)
            ListViewRequestsDetails.Items(6).SubItems(1).Text = Reader("Status").ToString
            ListViewRequestsDetails.Items(6).SubItems(1).Tag = Reader("RequestStatusID").ToString
            ListViewRequestsDetails.Items(7).SubItems(1).Text = FormatDateTime(Reader("StatusDate").ToString, DateFormat.ShortDate)
            ListViewRequestsDetails.Items(8).SubItems(1).Text = Reader("CDProcedures").ToString
        End If
        SQL = "SELECT Fname+' '+Lname as EmpName, RequestActionID, RequestID, Description, RequestActionDate FROM BillingRequestActions inner join Employees on BillingRequestActions.CreatedBy = Employees.EmpID where RequestID = " & Val(ListViewRequests.SelectedItems(0).Tag)

        Reader = gSQLGetDataReader(SQL)
        ListViewrequestActions.Items.Clear()
        If Reader Is Nothing Then Exit Sub
        If Reader.HasRows Then
            Do Until Reader.Read = False
                LI = ListViewrequestActions.Items.Add(FormatDateTime(Reader("RequestActionDate").ToString, DateFormat.ShortDate))
                LI.Tag = Reader("RequestActionID").ToString
                LI.SubItems.Add(Reader("Description").ToString)
                LI.SubItems(1).Tag = Reader("EmpName").ToString

                LI.ToolTipText = Reader("Description").ToString
            Loop
        End If

    End Sub
    Private Sub btnSetAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ToolStripMenuItemRequestsMaintenance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemRequestsMaintenance.Click
        frmBillingRequests.MinimizeBox = False
        frmBillingRequests.MaximizeBox = False

        frmBillingRequests.ShowDialog(Me)
        frmBillingRequests.Dispose()
    End Sub
    Private Sub ListViewrequestActions_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewrequestActions.DoubleClick
        btnSetAction_Click(Nothing, Nothing)
    End Sub

    Private Sub ListViewrequestActions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewrequestActions.SelectedIndexChanged

    End Sub

    Private Sub ToolStripButtonInsuranceMainenance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonInsuranceMainenance.Click
        Application.DoEvents 
        InsurancesMaintenanceToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub DiagnosticsMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DiagnosticsMaintenanceToolStripMenuItem.Click
        Application.DoEvents()
        frmDiagnosticMaintenance.ShowDialog()
        frmDiagnosticMaintenance.Dispose()

    End Sub
    Private RedBallFlashCount As Integer
    Private Sub TimerFlashRedBall_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerFlashRedBall.Tick
        If RedBallFlashCount > 10 Then
            RedBallFlashCount = 0
            TimerFlashRedBall.Enabled = False
            PictureBoxPanelBills.Visible = False
            PictureBoxPanelReminders.Visible = False
            PictureBoxSchedule.Visible = False
        Else
            RedBallFlashCount = RedBallFlashCount + 1
            PictureBoxPanelBills.Visible = Not PictureBoxPanelBills.Visible
            PictureBoxPanelReminders.Visible = Not PictureBoxPanelReminders.Visible
            PictureBoxSchedule.Visible = Not PictureBoxSchedule.Visible
        End If
    End Sub
    Private Sub AnnouncementsToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnnouncementsToolStripMenuItem.Click
        Application.DoEvents()
        frmAnnouncement.MinimizeBox = False
        frmAnnouncement.MaximizeBox = False

        frmAnnouncement.ShowDialog(Me)
        frmAnnouncement.Dispose()
    End Sub

    Private Sub ToolStripMenuItemLetterHead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemLetterHead.Click
        Application.DoEvents()
        frmLetterHead.MinimizeBox = False
        frmLetterHead.MaximizeBox = False

        frmLetterHead.ShowDialog(Me)
        frmLetterHead.Dispose()
    End Sub

    Private Sub FindCheckToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindCheckToolStripMenuItem.Click
        Application.DoEvents()
        frmFindCheck.Show(Me)

    End Sub
    Private Sub Process_Database()
        gSQLUpdateData("exec CleanDocuments_Delete_InsInfo")
    End Sub

    Private Sub DatabaseProcesses()

        Dim t As New System.Threading.Thread(AddressOf Process_Database)
        t.IsBackground = True
        t.Start()
    End Sub

    Private Sub ToolStripMenuItemTodayPayments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemTodayPayments.Click
        Application.DoEvents()
        frmBillingTodayPayments.ShowDialog()
        frmBillingTodayPayments.Dispose()
    End Sub
    Private Sub ReferringOfficesMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReferringOfficesMaintenanceToolStripMenuItem.Click
        Application.DoEvents()
        frmReferringOfficesMaintenance.ShowDialog()
        frmReferringOfficesMaintenance.Dispose()
    End Sub

    Private Sub OfficesMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OfficesMaintenanceToolStripMenuItem.Click
        Application.DoEvents()
        frmOfficeMaintenance.ShowDialog()
        frmOfficeMaintenance.Dispose()
    End Sub

    Private Sub ToolStripBillingPaymentManagementReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripBillingPaymentManagementReport.Click
        Application.DoEvents()
        frmBillingPaymentsReport.MdiParent = Me
        'frmBillingPaymentsReport.Size = New Size(Me.Width, Me.Height)
        frmBillingPaymentsReport.WindowState = FormWindowState.Maximized
        Application.DoEvents()
        frmBillingPaymentsReport.Show()
        frmBillingPaymentsReport.BringToFront()
        frmBillingPaymentsReport.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ToolStripMenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Application.DoEvents()
        frmReferringOfficesMaintenance.ShowDialog()
        frmReferringOfficesMaintenance.Dispose()
    End Sub


    Private Sub ListViewNF2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewNF2.DoubleClick
        LastSelectedListView = ListViewNF2
        ToolStripButton3_Click(Nothing, Nothing)
    End Sub

    Private Sub ListViewNF2_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles ListViewNF2.ItemChecked
        If SkeepChecked = True Then Exit Sub
        If e.Item.Checked Then
            If e.Item.ImageIndex = 2 Then
                e.Item.Checked = False
            End If

        End If

    End Sub

    Private Sub ListViewNF2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewNF2.SelectedIndexChanged
        gHighlightListviewItem(ListViewNF2, True)
    End Sub

    Private Sub ListViewBills_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewBills.DoubleClick
        ToolStripMenuItem18_Click(Nothing, Nothing)
    End Sub

    Private Sub ListViewBills_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewBills.SelectedIndexChanged
        gHighlightListviewItem(ListViewBills)
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click
        Dim LI As ListViewItem
        ListViewNF2.BeginUpdate()
        For Each LI In ListViewNF2.Items
            LI.Checked = True
        Next
        ListViewNF2.EndUpdate()
    End Sub

    Private Sub SelectNoneToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectNoneToolStripMenuItem.Click
        Dim LI As ListViewItem
        ListViewNF2.BeginUpdate()
        For Each LI In ListViewNF2.Items
            LI.Checked = False
        Next
        ListViewNF2.EndUpdate()
    End Sub

    Private Sub mnuShowSelectedPatientInfo1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowSelectedPatientInfo1.Click
        ToolStripButton3_Click(Nothing, Nothing)
    End Sub
    Private Sub mnuPrinting1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrinting1.Click
        ButtonPrintNF2_Click(Nothing, Nothing)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TimerRefresh_Tick(Nothing, Nothing)
    End Sub

    Private Sub SplitContainer1_SplitterMoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.SplitterEventArgs) Handles SplitContainer1.SplitterMoved

    End Sub

    Private Sub PatientsNF2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PatientsNF2ToolStripMenuItem.Click
        Application.DoEvents()
        Dim frm As Form = FormsCollection.FindForm("frmPatientNF2")
        If Not frm Is Nothing Then
            frm.WindowState = FormWindowState.Normal
            frm.BringToFront()
            Exit Sub
        Else
            gWindow_Settings(frmPatientNF2, ReadWrite.sRead)
            frmPatientNF2.MdiParent = Me
            frmPatientNF2.Show()
            frmPatientNF2.BringToFront()
        End If
    End Sub


    Private Sub CheckBoxDoNotShowRequests_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxDoNotShowRequests.CheckedChanged
        Application.DoEvents()
        If CheckBoxDoNotShowRequests.Checked Then
            PanelRequests.Visible = False
            ShowRequestsToolStripMenuItem.Checked = False
        End If
    End Sub
    Private Sub CheckBoxDoNotShowBills_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxDoNotShowBills.CheckedChanged
        Application.DoEvents()
        If CheckBoxDoNotShowBills.Checked = True Then
            PanelBills.Visible = False
            ShowNotificationsToolStripMenuItem.Checked = False
        End If
    End Sub
    Private Sub ShowNotificationsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowNotificationsToolStripMenuItem.Click
        Application.DoEvents()
        If ShowNotificationsToolStripMenuItem.Checked Then
            CheckBoxDoNotShowBills.Checked = False
            TimerRefresh_Tick(Nothing, Nothing)
        Else
            CheckBoxDoNotShowBills.Checked = True
            PanelBills.Visible = False
        End If
    End Sub

    Private Sub ShowRequestsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowRequestsToolStripMenuItem.Click
        Application.DoEvents()
        If ShowRequestsToolStripMenuItem.Checked Then
            CheckBoxDoNotShowRequests.Checked = False
            TimerRefresh_Tick(Nothing, Nothing)
        Else
            CheckBoxDoNotShowRequests.Checked = True
            PanelRequests.Visible = False
        End If
    End Sub


    Private Sub ToolStripMenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem10.Click
        Application.DoEvents()
        ToolStripButtonBillMaintenance_Click(Nothing, Nothing)
    End Sub

    Private Sub ToolStripButton5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim PatientID() As String = Nothing
        Dim I As Integer = 0
        Application.DoEvents()
        If ListViewNF2.CheckedItems.Count = 0 And ListViewNF2.SelectedItems.Count = 0 Then
            MsgBox("Unable to produce NF2. No records checked / selected. Please check the record and try again.", MsgBoxStyle.Critical)
            ListViewNF2.Focus()
            Exit Sub
        End If
        TimerRefresh.Enabled = False
        Dim LI As ListViewItem
        If ListViewNF2.CheckedItems.Count = 0 Then
            If ListViewNF2.SelectedItems(0).ImageIndex = 1 Then
                ReDim Preserve PatientID(0)
                PatientID(0) = Val(ListViewNF2.SelectedItems(0).Tag)
            Else
                MsgBox("Unable to produce NF2 report." & vbCrLf & "Incomplete Patient's profile." & vbCrLf & vbCrLf & "Please open the Patient's profile and complete all required fields.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

        Else
            For Each LI In ListViewNF2.CheckedItems
                ReDim Preserve PatientID(I)
                PatientID(I) = Val(LI.Tag)
                I = I + 1
            Next
        End If
        frmNF2Report.Setup_report(PatientID)
        frmNF2Report.MinimizeBox = False

        frmNF2Report.ShowDialog(Me)
        frmNF2Report.Dispose()
        TimerRefresh.Enabled = True
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Dim LI As ListViewItem
        If ListViewNF2.SelectedItems.Count = 0 Then
            MsgBox("Unable to open patient's information. No record selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        LI = ListViewNF2.SelectedItems(0)
        Application.DoEvents()
        Dim newfrm As New frmPatient
        newfrm.MinimizeBox = False
        newfrm.InitialTab = 0
        newfrm.InitialPatientName = LI.Text
        newfrm.MinimizeBox = False
        newfrm.MaximizeBox = False
        newfrm.ShowDialog(Me)
        'Dim frm As Form = FormsCollection.FindForm("frmPatient")
        'If Not frm Is Nothing Then
        '    Dim newfrm As New frmPatient
        '    newfrm.InitialTab = 0
        '    newfrm.InitialPatientName = LI.Text
        '    newfrm.ShowDialog(Me)

        '    'MsgBox("The Patient's information window is already opened." & vbCrLf & vbCrLf & "Please close the previous patient information window before opening a new one.", MsgBoxStyle.Exclamation)
        '    'If frm.WindowState = FormWindowState.Minimized Then frm.WindowState = FormWindowState.Normal
        '    'frm.BringToFront()
        '    'Exit Sub
        'Else
        '    frmPatient.InitialTab = 0
        '    frmPatient.InitialPatientName = LI.Text
        '    frmPatient.ShowDialog(Me)
        'End If
    End Sub

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        If ListViewRequests.SelectedItems.Count = 0 Then
            MsgBox("Unable to show the patient's informatioln. No Request Selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If Val(ListViewRequestsDetails.Items(0).SubItems(1).Text) = 0 Then
            MsgBox("Unable to show the patient's informatioln. No Request Selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Application.DoEvents()
        Dim NewFrm As New frmPatient
        NewFrm.Width = 1225
        NewFrm.WindowState = FormWindowState.Normal
        NewFrm.Location = New Point(Me.Left + ((Width - frmPatient.Size.Width) \ 2), Me.Top + ((Height - frmPatient.Size.Height) \ 2))
        NewFrm.InitialTab = 0
        'frmPatient.InitialPatientName = LI.SubItems(1).Text
        NewFrm.InitialPatientName = Val(ListViewRequestsDetails.Items(0).SubItems(1).Text)
        NewFrm.InitialEdit = False
        NewFrm.MinimizeBox = False
        NewFrm.MaximizeBox = False
        NewFrm.ShowDialog(Me)
        NewFrm.Dispose()
        'Dim frm As Form = FormsCollection.FindForm("frmPatient")
        'If Not frm Is Nothing Then
        '    'MsgBox("The Patient's information window is already opened." & vbCrLf & vbCrLf & "Please close the previous patient information window before opening a new one.", MsgBoxStyle.Exclamation)
        '    'frm.WindowState = FormWindowState.Normal
        '    'frm.BringToFront()
        '    'Exit Sub

        'Else

        '    frmPatient.Width = 1225
        '    frmPatient.WindowState = FormWindowState.Normal
        '    frmPatient.Location = New Point(Me.Left + ((Width - frmPatient.Size.Width) \ 2), Me.Top + ((Height - frmPatient.Size.Height) \ 2))
        '    frmPatient.InitialTab = 0
        '    'frmPatient.InitialPatientName = LI.SubItems(1).Text
        '    frmPatient.InitialPatientName = Val(ListViewRequestsDetails.Items(0).SubItems(1).Text)
        '    frmPatient.InitialEdit = False
        '    frmPatient.ShowDialog(Me)
        '    frmPatient.Dispose()
        'End If
    End Sub

    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
        Dim Li As ListViewItem
        Dim NewLi As ListViewItem
        Application.DoEvents()
        If ListViewRequests.SelectedItems.Count = 0 Then
            MsgBox("Unable to set Action. No Request Selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If Val(ListViewRequestsDetails.Items(0).SubItems(1).Text) = 0 Then
            MsgBox("Unable to set Action. No Request Selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        StopTimers()
        frmReminder.RequestTypeID = Val(ListViewRequestsDetails.Items(3).SubItems(1).Tag)
        frmReminder.PatientID = Val(ListViewRequestsDetails.Items(0).SubItems(1).Text)
        frmReminder.RequestID = Val(ListViewRequestsDetails.Items(0).SubItems(1).Tag)
        frmReminder.txtPatientInfo.Text = ListViewRequestsDetails.Items(1).SubItems(1).Text
        frmReminder.txtRequest.Text = ListViewRequestsDetails.Items(3).SubItems(1).Text
        frmReminder.txtBillID.Text = ListViewRequestsDetails.Items(2).SubItems(1).Text
        frmReminder.lblRequestAge.Text = DateDiff(DateInterval.Day, CDate(ListViewRequests.SelectedItems(0).Text), Now)
        frmReminder.Load_Statuses()
        gFindComboItemByValue(frmReminder.ComboBoxStatus, Val(ListViewRequestsDetails.Items(6).SubItems(1).Tag), True)
        Select Case Val(frmReminder.lblRequestAge.Text)
            Case 0
                frmReminder.lblRequestAge.Text = "CREATED TODAY"
            Case 1
                frmReminder.lblRequestAge.Text = "CREATED " & frmReminder.lblRequestAge.Text & " AGO"
            Case 2
                frmReminder.lblRequestAge.Text = "CREATED " & frmReminder.lblRequestAge.Text & " AGO"
            Case Else
                frmReminder.lblRequestAge.Text = "ATTENTION! CREATED " & frmReminder.lblRequestAge.Text & " AGO"
                frmReminder.lblRequestAge.ForeColor = Color.Red
        End Select
        For Each Li In ListViewrequestActions.Items
            NewLi = frmReminder.ListViewrequestActions.Items.Add(Li.Text)
            NewLi.SubItems.Add(Li.SubItems(1))
            NewLi.SubItems.Add(Li.SubItems(1).Tag)
            NewLi.Tag = Li.Tag
        Next
        frmReminder.ActionsCount = ListViewrequestActions.Items.Count
        frmReminder.RequestStatus = Val(ListViewRequestsDetails.Items(6).SubItems(1).Tag)
        frmReminder.MinimizeBox = False
        frmReminder.MaximizeBox = False

        If frmReminder.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            ListViewRequests_SelectedIndexChanged(Nothing, Nothing)
        End If
        frmReminder.Dispose()
        ListViewRequests.Focus()
        StopTimers(False)
    End Sub

    Private Sub ChangeBillingProviderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Application.DoEvents()
        frmBillingManagement.PreselectStatus = 1
        frmBillingManagement.MdiParent = Me
        'frmBillingManagement.Size = New Size(Me.Width, Me.Height)
        frmBillingManagement.WindowState = FormWindowState.Maximized
        Application.DoEvents()
        frmBillingManagement.Show()
        frmBillingManagement.BringToFront()
        frmBillingManagement.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ToolStripMenuItemOTMaintenance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemOTMaintenance.Click
        Application.DoEvents()
        frmOTCompaniesMaintenance.MinimizeBox = False
        frmOTCompaniesMaintenance.MaximizeBox = False

        frmOTCompaniesMaintenance.ShowDialog(Me)
        frmOTCompaniesMaintenance.Dispose()
    End Sub

    Private Sub ToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem7.Click
        Application.DoEvents()
        frmImageDiskPOM.MinimizeBox = False
        frmImageDiskPOM.MaximizeBox = False

        frmImageDiskPOM.ShowDialog(Me)
        frmImageDiskPOM.Dispose()

    End Sub

    Private Sub ChangeRefferingDoctorToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeRefferingDoctorToolStripMenuItem.Click
        Application.DoEvents()
        frmPatientRefferingDoctor.MinimizeBox = False
        frmPatientRefferingDoctor.MaximizeBox = False

        frmPatientRefferingDoctor.ShowDialog(Me)
        frmPatientRefferingDoctor.Dispose()
    End Sub

    Private Sub ChangeTreatingProviderToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeTreatingProviderToolStripMenuItem.Click
        Application.DoEvents()
        frmPatientTreatingProvider.MinimizeBox = False
        frmPatientTreatingProvider.MaximizeBox = False

        frmPatientTreatingProvider.ShowDialog(Me)
        frmPatientTreatingProvider.Dispose()
    End Sub

    Private Sub ChangeBillingProviderToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeBillingProviderToolStripMenuItem.Click
        Application.DoEvents()
        frmPatientBillingProvider.MinimizeBox = False
        frmPatientBillingProvider.MaximizeBox = False

        frmPatientBillingProvider.ShowDialog(Me)
        frmPatientBillingProvider.Dispose()
    End Sub

    Private Sub ToolStripMenuItem6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        Application.DoEvents()
        frmPatientProceduresSwitchSchedule.MinimizeBox = False
        frmPatientProceduresSwitchSchedule.MaximizeBox = False

        frmPatientProceduresSwitchSchedule.ShowDialog(Me)
        frmPatientProceduresSwitchSchedule.Dispose()
    End Sub

    Private Sub PatientProcedureInformationToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PatientProcedureInformationToolStripMenuItem.Click
        Application.DoEvents()
        Dim frm As Form = FormsCollection.FindForm("frmPatientProcedureInformation")
        If Not frm Is Nothing Then
            frm.WindowState = FormWindowState.Normal
            frm.BringToFront()
            Exit Sub
        Else
            frmPatientProcedureInformation.MdiParent = Me
            frmPatientProcedureInformation.WindowState = FormWindowState.Normal
            frmPatientProcedureInformation.Show()
            frmPatientProcedureInformation.BringToFront()
        End If
    End Sub

    Private Sub mnuEmployeeMaintenance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEmployeeMaintenance.Click
        Application.DoEvents()
        frmEmployeeMaintenance.ShowDialog()
        frmEmployeeMaintenance.Dispose()
    End Sub

    Private Sub ToolStripButtonPatTreatment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonPatSearchAndTools.Click
        Application.DoEvents()
        PatientsSearchToolsToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub PatientsSearchToolsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PatientsSearchToolsToolStripMenuItem.Click
        Application.DoEvents()
        Dim frm As Form = FormsCollection.FindForm("frmPatientAttendancy")
        If Not frm Is Nothing Then
            frm.WindowState = FormWindowState.Normal
            frm.BringToFront()
            Exit Sub
        Else


            frmPatientAttendancy.MdiParent = Me
            frmPatientAttendancy.WindowState = FormWindowState.Normal
            frmPatientAttendancy.Show()
            frmPatientAttendancy.BringToFront()
        End If
    End Sub

    Private Sub LogOffToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogOffToolStripMenuItem.Click
        Application.DoEvents()
        My.Computer.Audio.Play(My.Resources.Lock, AudioPlayMode.Background)
        Me.Close()
        If FormsCollection.Forms.Count = 0 Then
            Application.Restart()
        End If

    End Sub
    Private Sub ToolStripMenuItem9_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem9.Click
        Application.DoEvents()
        frmPatientMissingInformation.ShowDialog()
        frmPatientMissingInformation.Dispose()
    End Sub

    Private Sub ToolStripLabel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripLabel2.Click
        frmAboutBox.ShowDialog()
    End Sub

    Private Sub ToolStripButton4_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripButtonSchedule.MouseEnter, ToolStripButtonPatientProfile.MouseEnter, ToolStripButtonPatSearchAndTools.MouseEnter, ToolStripButtonSearch.MouseEnter, ToolStripButtonInsuranceMainenance.MouseEnter, ToolStripButtonBilling.MouseEnter, ToolStripButtonBillMaintenance.MouseEnter
        If lblStatus.Text <> "   " & sender.ToolTipText Then lblStatus.Text = "   " & sender.ToolTipText
    End Sub

    Private Sub ToolStripButton4_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripButtonSchedule.MouseLeave, ToolStripButtonPatientProfile.MouseLeave, ToolStripButtonPatSearchAndTools.MouseLeave, ToolStripButtonSearch.MouseLeave, ToolStripButtonInsuranceMainenance.MouseLeave, ToolStripButtonBilling.MouseLeave, ToolStripButtonBillMaintenance.MouseLeave
        If lblStatus.Text <> "" Then lblStatus.Text = ""
    End Sub

    Private Sub TreatmentStatisticReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TreatmentStatisticReport.Click
        Application.DoEvents()
        frmPatientVisits.MdiParent = Me
        'frmSchedulePTFrontDesk.Size = New Size(Me.Width, Me.Height)
        frmPatientVisits.WindowState = FormWindowState.Normal
        Application.DoEvents()
        frmPatientVisits.Show()
        frmPatientVisits.BringToFront()
        frmPatientVisits.WindowState = FormWindowState.Normal

        'frmPatientTreatmentStatistic.ShowDialog()
        'frmPatientTreatmentStatistic.Dispose()
    End Sub

    Private Sub PrintTodaysScheduleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintTodaysScheduleToolStripMenuItem.Click
        Application.DoEvents()
        frmReportSchedule.ByPatient = True
        frmReportSchedule.ScheduleDate = Now.Date
        frmReportSchedule.MinimizeBox = False
        frmReportSchedule.MaximizeBox = False

        frmReportSchedule.ShowDialog(Me)
        frmReportSchedule.Dispose()
    End Sub

    Private Sub ScheduleMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScheduleMaintenanceToolStripMenuItem.Click
        Application.DoEvents()
        frmSchedulePT.MdiParent = Me
        'frmSchedulePT.Size = New Size(Me.Width, Me.Height)
        frmSchedulePT.WindowState = FormWindowState.Maximized
        Application.DoEvents()
        frmSchedulePT.Show()
        frmSchedulePT.BringToFront()
        frmSchedulePT.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowToBeScheduled.CheckedChanged
        Application.DoEvents()
        If ShowToBeScheduled.Checked = True Then
            PanelSchedule.Visible = False
            ToolStripMenuItemToBeScheduled.Checked = False
        End If
    End Sub

    Private Sub ToolStripMenuItemToBeScheduled_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemToBeScheduled.Click
        Application.DoEvents()
        If ToolStripMenuItemToBeScheduled.Checked Then
            ShowToBeScheduled.Checked = False
            TimerRefresh_Tick(Nothing, Nothing)
        Else
            ShowToBeScheduled.Checked = True
            PanelSchedule.Visible = False
        End If
    End Sub

    Private Sub ToolStripButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim LI As ListViewItem
        Dim LV As ListView
        If LastSelectedListView Is ListViewSchedule Then
            LV = ListViewSchedule
        ElseIf LastSelectedListView Is ListViewEUOIME Then
            LV = ListViewEUOIME
        Else
            MsgBox("Unable to open patient's information. No record selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If LV.SelectedItems.Count = 0 Then
            MsgBox("Unable to open patient's information. No record selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()
        LI = LV.SelectedItems(0)
        Application.DoEvents()
        Dim NewFrm As New frmPatient
        NewFrm.InitialTab = 0
        NewFrm.InitialPatientName = LI.Tag
        Me.Cursor = Cursors.Default
        NewFrm.MinimizeBox = False
        NewFrm.MaximizeBox = False
        NewFrm.ShowDialog(Me)

        'Dim frm As Form = FormsCollection.FindForm("frmPatient")
        'If Not frm Is Nothing Then
        '    Dim NewFrm As New frmPatient
        '    NewFrm.InitialTab = 0
        '    NewFrm.InitialPatientName = LI.Tag
        '    Me.Cursor = Cursors.Default
        '    NewFrm.ShowDialog(Me)

        '    'MsgBox("The Patient's information window is already opened." & vbCrLf & vbCrLf & "Please close the previous patient information window before opening a new one.", MsgBoxStyle.Exclamation)
        '    'If frm.WindowState = FormWindowState.Minimized Then frm.WindowState = FormWindowState.Normal
        '    'frm.BringToFront()
        '    'Me.Cursor = Cursors.Default
        '    'Exit Sub
        'Else
        '    frmPatient.InitialTab = 0
        '    frmPatient.InitialPatientName = LI.Tag
        '    Me.Cursor = Cursors.Default
        '    frmPatient.ShowDialog(Me)
        'End If
    End Sub

    Private Sub ListViewSchedule_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewSchedule.DoubleClick
        LastSelectedListView = ListViewSchedule
        ToolStripButton1_Click_1(Nothing, Nothing)
    End Sub
    Private LastSelectedListView As ListView

    Private Sub ListViewSchedule_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewSchedule.GotFocus
        LastSelectedListView = ListViewSchedule
    End Sub

    Private Sub ListViewSchedule_ItemActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewSchedule.ItemActivate

    End Sub
    Private Sub ListViewSchedule_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewSchedule.SelectedIndexChanged
        gHighlightListviewItem(ListViewSchedule, True, True)
    End Sub
    Private Sub ToolStripMenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem11.Click
        Application.DoEvents()
        frmReportVisitsByProcedures.MinimizeBox = False
        frmReportVisitsByProcedures.MaximizeBox = False

        frmReportVisitsByProcedures.ShowDialog(Me)
        frmReportVisitsByProcedures.Dispose()
    End Sub

    Private Sub ToolStripMenuItem12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem12.Click
        Application.DoEvents()
        If gOfficeTypeID = 1 Then
            frmToBeScheduledReport.MinimizeBox = False
            frmToBeScheduledReport.MaximizeBox = False

            frmToBeScheduledReport.ShowDialog(Me)
            frmToBeScheduledReport.Dispose()
        Else
            frmPatientIMEEUOReport.MinimizeBox = False
            frmPatientIMEEUOReport.MaximizeBox = False

            frmPatientIMEEUOReport.ShowDialog(Me)
            frmPatientIMEEUOReport.Dispose()
        End If
    End Sub

    Private Sub TimerAutoUpdate_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerAutoUpdate.Tick
        gProcessAutoUpdate(True)
    End Sub

    Private Sub ToolStripButton4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        PatientsNF2ToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub ListViewEUOIME_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewEUOIME.DoubleClick
        ToolStripButton1_Click_1(Nothing, Nothing)
    End Sub

    Private Sub ListViewEUOIME_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewEUOIME.GotFocus
        LastSelectedListView = ListViewEUOIME
    End Sub

 
    Private Sub ListViewEUOIME_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewEUOIME.SelectedIndexChanged
        gHighlightListviewItem(ListViewEUOIME, True)
        txtEUOComments.Text = ""
        With ListViewEUODetails
            .Items(0).SubItems(1).Text = ""
            .Items(1).SubItems(1).Text = ""
            .Items(2).SubItems(1).Text = ""
            .Items(3).SubItems(1).Text = ""
            .Items(4).SubItems(1).Text = ""
            .Items(5).SubItems(1).Text = ""
        End With
        If ListViewEUOIME.SelectedItems.Count = 0 Then Exit Sub
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        SQL = "SELECT     Patients.PatientID, Patients.FName + ' ' + Patients.MI + ' ' + Patients.LName + ' ' + Patients.Suffix AS PatName, Patients.Phone1, Patients.Phone2, Patients.CellPhone, InsuranceCompanies.CompanyName, InsuranceExaminations.ScheduleDate AS DT, InsuranceExaminations.AddressComments "
        SQL &= " FROM InsuranceExaminations INNER JOIN Patients ON InsuranceExaminations.PatientID = Patients.PatientID INNER JOIN InsuranceCompanies ON Patients.InsuranceCompanyID = InsuranceCompanies.CompanyID "
        SQL &= " WHERE ID= " & Val(ListViewEUOIME.SelectedItems(0).SubItems(2).Tag)
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        If Reader.HasRows Then
            Reader.Read()
            With ListViewEUODetails
                .Items(0).SubItems(1).Text = ListViewEUOIME.SelectedItems(0).SubItems(2).Text
                .Items(1).SubItems(1).Text = Reader("PatName").ToString
                .Items(2).SubItems(1).Text = Reader("Phone1").ToString
                .Items(3).SubItems(1).Text = IIf(Reader("Phone2").ToString <> "", Reader("Phone2").ToString & " ", "") & Reader("CellPhone").ToString
                .Items(4).SubItems(1).Text = CDate(Reader("DT").ToString)
                .Items(5).SubItems(1).Text = Reader("CompanyName").ToString
            End With
            txtEUOComments.Text = Reader("AddressComments").ToString
        End If


    End Sub

    Private Sub ButtonPrintNF2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        Dim PatientID() As String = Nothing
        Dim I As Integer = 0
        If ListViewNF2.SelectedItems.Count = 0 Then
            MsgBox("Unable to produce NF2. No Patient's profile selected.", MsgBoxStyle.Critical)
            ListViewNF2.Focus()
            Exit Sub
        End If
        Dim LI As ListViewItem
        If ListViewNF2.SelectedItems(0).ImageIndex = 1 Then
            ReDim Preserve PatientID(0)
            PatientID(0) = Val(ListViewNF2.SelectedItems(0).Tag)
        Else
            MsgBox("Unable to produce NF2 report for the Incomplete Patient's profile." & vbCrLf & vbCrLf & "Please open the Patient's profile and complete all required fields.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        frmNF2Report.Setup_report(PatientID)
        frmNF2Report.MinimizeBox = False
        frmNF2Report.ShowDialog(Me)
        frmNF2Report.Dispose()
    End Sub

    Private Sub ToolStripButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton8.Click

        ToolStripMenuItem12_Click(Nothing, Nothing)
    End Sub

    Private Sub ListViewEUODetails_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewEUODetails.DoubleClick
        LastSelectedListView = ListViewEUOIME
        ToolStripButton1_Click_1(Nothing, Nothing)
    End Sub

    Private Sub ListViewEUODetails_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewEUODetails.GotFocus
        LastSelectedListView = ListViewEUOIME
    End Sub

    Private Sub ListViewEUODetails_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewEUODetails.SelectedIndexChanged

    End Sub

    Private Sub ToolStripMenuItemProceduresSchedule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemProceduresSchedule.Click
        frmDiagSchedule.MinimizeBox = False
        frmDiagSchedule.MaximizeBox = False

        frmDiagSchedule.ShowDialog(Me)
        frmDiagSchedule.Dispose()
    End Sub

    Private Sub ToolStripMenuItem13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem13.Click
        Dim LI As ListViewItem
        If ListViewEUOIME.SelectedItems.Count = 0 Then Exit Sub
        LI = ListViewEUOIME.SelectedItems(0)
        If MsgBox("Please verify that " & LI.SubItems(2).Text & " has been confirmed with the patient:" & vbCrLf & LI.SubItems(1).Text & "?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        gSQLUpdateData("Update InsuranceExaminations set StatusID = 2 where ID=" & Val(LI.SubItems(2).Tag))
        gUpdate_Profile_Log(Val(LI.Tag), PatientLogTypes.tInsuranceExaminationConfirmed, LI.Text & " Appointment at " & LI.SubItems(1).Text & " has been confirmed on " & Now)
        LI.Remove()
    End Sub

    Private Sub ToolStripMenuItem14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem14.Click
        ToolStripButton1_Click_1(Nothing, Nothing)
    End Sub

    Private Sub ContextMenuStripWarning_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStripWarning.Opening
        If LastSelectedListView Is ListViewSchedule Then
            ToolStripMenuItem13.Visible = False
            ToolStripSeparator22.Visible = False
        ElseIf LastSelectedListView Is ListViewEUOIME Then
            ToolStripMenuItem13.Visible = True
            ToolStripSeparator22.Visible = True
        Else
            e.Cancel = True
        End If
    End Sub
    Private Sub ToolStripMenuItem16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem16.Click
        ToolStripButton6_Click(Nothing, Nothing)
    End Sub

    Private Sub ToolStripButton10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton10.Click
        ToolStripButton7_Click(Nothing, Nothing)
    End Sub

    Private Sub ToolStripMenuItem15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem15.Click
        PatientsNF2ToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub ToolStripMenuItem17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem17.Click
        frmDenialReasonMaintenance.MinimizeBox = False
        frmDenialReasonMaintenance.MaximizeBox = False

        frmDenialReasonMaintenance.ShowDialog(Me)
        frmDenialReasonMaintenance.Dispose()
    End Sub


    Private Sub ToolStripMenuItem18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem18.Click
        If ListViewBills.SelectedItems.Count = 0 Then Exit Sub
        Application.DoEvents()
        Me.Cursor = Cursors.WaitCursor
        frmBillingManagement.SearchBillID = ListViewBills.SelectedItems(0).Text
        frmBillingManagement.PreselectStatus = 0
        frmBillingManagement.MdiParent = Me
        'frmBillingManagement.Size = New Size(Me.Width, Me.Height)
        frmBillingManagement.WindowState = FormWindowState.Maximized
        Application.DoEvents()
        frmBillingManagement.Show()
        frmBillingManagement.BringToFront()
        frmBillingManagement.WindowState = FormWindowState.Maximized
        frmBillingManagement.ButtonFind_Click(Nothing, Nothing)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripMenuItem19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem19.Click
        ToolStripButton2_Click(Nothing, Nothing)
    End Sub

    Private Sub EmailerMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailerMaintenanceToolStripMenuItem.Click
        frmEmailerMaintenance.MinimizeBox = False
        frmEmailerMaintenance.MaximizeBox = False

        frmEmailerMaintenance.ShowDialog(Me)
        frmEmailerMaintenance.Dispose()
    End Sub

    Private Sub EmailerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailerToolStripMenuItem.Click
        frmMailer.MinimizeBox = False
        frmMailer.MaximizeBox = False

        frmMailer.ShowDialog(Me)
        frmMailer.Dispose()
    End Sub

    Private Sub ToolStripMenuItem20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem20.Click
        Application.DoEvents()
        Application.DoEvents()
        frmReportReschedulesCancelations.MdiParent = Me
        frmReportReschedulesCancelations.WindowState = FormWindowState.Normal
        Application.DoEvents()
        frmReportReschedulesCancelations.Show()
        frmReportReschedulesCancelations.BringToFront()
        frmReportReschedulesCancelations.WindowState = FormWindowState.Normal

    End Sub

    Private Sub ToolStripMenuItem21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmCDBurn.MinimizeBox = False
        frmCDBurn.MaximizeBox = False

        frmCDBurn.ShowDialog(Me)
        frmCDBurn.Dispose()
    End Sub

    Private Sub SecuritySettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SecuritySettingsToolStripMenuItem.Click
        frmSecuritySettings.MinimizeBox = False
        frmSecuritySettings.MaximizeBox = False

        frmSecuritySettings.ShowDialog(Me)
        frmSecuritySettings.Dispose()
    End Sub

    Private Sub ResetPatientInformationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetPatientInformationToolStripMenuItem.Click
        frmResetPatientInformation.MinimizeBox = False
        frmResetPatientInformation.MaximizeBox = False

        frmResetPatientInformation.ShowDialog(Me)
        frmResetPatientInformation.Dispose()
    End Sub

    Private Sub AdminMessagingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdminMessagingToolStripMenuItem.Click
        frmMessage.MinimizeBox = False
        frmMessage.MaximizeBox = False

        frmMessage.ShowDialog(Me)
        frmMessage.Dispose()
    End Sub

    Private Sub PictureBoxClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxClose.Click
        Dim SQL As String = "UPDATE MessagesRecipients set ConfirmedDT = getdate() where ID=" & Val(PanelMessage.Tag)
        If MsgBox("Please  confirm you have acknowledge this message?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            gSQLUpdateData(SQL)
            PanelMessage.Visible = False
        End If
    End Sub

    Private Sub AdministrativeToolsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdministrativeToolsToolStripMenuItem.Click

    End Sub

    Private Sub ToolStripMenuItemChangePatientInformation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemChangePatientInformation.Click

    End Sub

    Private Sub ToolStripMenuItemChangePatientInformation_DropDownOpening(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemChangePatientInformation.DropDownOpening

    End Sub

    Private Sub mnuBankDepositsAdmin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBankDepositsAdmin.Click
        frmBankDepositsAdmin.MinimizeBox = False
        frmBankDepositsAdmin.MaximizeBox = False

        frmBankDepositsAdmin.ShowDialog(Me)
        frmBankDepositsAdmin.Dispose()
    End Sub

    Private Sub ToolStripMenuItem21_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem21.Click
        frmAttorneyAssignCaseNumber.Panel1.BackColor = Color.MistyRose
        frmAttorneyAssignCaseNumber.Text = "Assign Arbitration / Litigation Attorney Case Number"
        frmAttorneyAssignCaseNumber.lblMsg.Text = "Assign Arbitration / Litigation Attorney Case Number"
        frmAttorneyAssignCaseNumber.Arbitration = True
        frmAttorneyAssignCaseNumber.ArbitrationFieldPrefix = "Arbitration"
        frmAttorneyAssignCaseNumber.ShowDialog()
        frmAttorneyAssignCaseNumber.Dispose()
    End Sub

    Private Sub ProceduresToBeRescheduledReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProceduresToBeRescheduledReportToolStripMenuItem.Click
        ToolStripMenuItem12_Click(Nothing, Nothing)
    End Sub

    Private Sub InsuranceVerificationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InsuranceVerificationToolStripMenuItem.Click
        Application.DoEvents()
        Application.DoEvents()
        frmVerifyInsurance.MdiParent = Me
        Application.DoEvents()
        frmVerifyInsurance.Show()
        frmVerifyInsurance.BringToFront()
        If frmVerifyInsurance.WindowState = FormWindowState.Minimized Then frmVerifyInsurance.WindowState = FormWindowState.Normal
    End Sub
    Public BillingProviderID As Long
    Private Sub ToolStripButtonIntakeForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonIntakeForm.Click
        Application.DoEvents()
        'If MsgBox("Print Intake Form?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
        '    Exit Sub
        'End If
        Me.Cursor = Cursors.WaitCursor
        Dim Reader As SqlClient.SqlDataReader
        Dim intCounter As Integer
        Dim CR As ReportDocument
        Dim ConInfo As New TableLogOnInfo

        frmPrinter.Show(Me)
        BillingProviderID = 0
        CR = New eMedicalOffice.rptChartIntake
        If SetupCrystalSecurityInfo(CR) = False Then Exit Sub
        Dim CB As New ComboBox
        Reader = gSQLGetDataReader("SELECT     Employees.EmpID, Employees.Fname+' '+Employees.Lname+' '+ Employees.Alias +' - '+  Employees.CorporationName as DName, Employees.ReferralColor FROM Employees INNER JOIN EmployeeOffice ON Employees.EmpID = EmployeeOffice.EmpID  WHERE PositionID = 5 AND ActiveInd = 1 AND BillingPrv = 1 AND EmployeeOffice.OfficeID = " & gOfficeID)
        If Reader.HasRows = False Then
            MsgBox("Unable to print intake form." & vbCrLf & "No billing provider is set in the current office.", MsgBoxStyle.Critical)
            Me.Cursor = Cursors.Default
            frmPrinter.Close()
            frmPrinter.Dispose()
            Exit Sub
        End If
        Do Until Reader.Read = False
            CB.Items.Add(New ValueDescription(Reader("EmpID").ToString, Reader("DName").ToString, Reader("ReferralColor").ToString))
            BillingProviderID = Reader("EmpID").ToString
        Loop
        Reader.Close()

        Dim CBItem As Object
        If CB.Items.Count > 1 Then
            For Each CBItem In CB.Items
                frmIntakeForm.ComboBoxBillingProvider.Items.Add(CBItem)
            Next
            BillingProviderID = 0
            frmIntakeForm.ComboBoxBillingProvider.SelectedIndex = -1
            frmPrinter.Visible = False
            If frmIntakeForm.ShowDialog(Me) <> Windows.Forms.DialogResult.OK Then
                frmIntakeForm.Dispose()
                Me.Cursor = Cursors.Default
                frmPrinter.Close()
                frmPrinter.Dispose()
                Exit Sub
            End If
            frmIntakeForm.Dispose()
            frmPrinter.Visible = True
            Application.DoEvents()
        End If
        CR.SetParameterValue("BillingProviderID", BillingProviderID.ToString)
        If gPrinterOtherDocuments <> "" Then CR.PrintOptions.PrinterName = gPrinterOtherDocuments
        'CR.PrintOptions.ApplyPageMargins(New PageMargins(0, 0, 0, 0))
        Try
            CR.PrintToPrinter(1, False, 0, 0)
        Catch ex As Exception
            frmPrinter.Close()
            Me.Cursor = Cursors.Default
            frmPrinter.Dispose()
            gProcess_Log(ex.Message & vbCrLf & "Printer Settings: Other Documents Default Printer" & vbCrLf & "Printer: " & gPrinterOtherDocuments, ex.StackTrace, True)
            Exit Sub
        End Try

        Me.Cursor = Cursors.Default
        frmPrinter.Close()
        frmPrinter.Dispose()
    End Sub

    Private ToolBarStyle As ToolStripItemDisplayStyle
    Private Sub ShowPrintIntakeFormButtonToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowPrintIntakeFormButtonToolStripMenuItem.Click
        Application.DoEvents()
        If ShowPrintIntakeFormButtonToolStripMenuItem.Checked Then
            ToolStripButtonIntakeForm.Visible = True
            gShowIntakeFormButton = True
        Else
            ToolStripButtonIntakeForm.Visible = False
            gShowIntakeFormButton = False
        End If
        SaveSetting(My.Application.Info.ProductName, "Settings", "gShowIntakeFormButton", gShowIntakeFormButton)
    End Sub

    Private Sub PrintPatientIntakeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPatientIntakeToolStripMenuItem.Click
        ToolStripButtonIntakeForm_Click(Nothing, Nothing)
    End Sub

    Private Sub ToolStripButton9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton9.Click
        If MsgBox("Please confirm you want to restore the default Workspace settings?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        ToolStripManager.LoadSettings(Me, "Restore")
        'Me.BackColor = Color.Gainsboro
        Me.BackColor = Color.FromArgb(69, 69, 69)
        SetToolBar(ToolStripItemDisplayStyle.Image)
        SetFormBackcolor()
        ShowNotificationsToolStripMenuItem.Checked = True
        ShowRequestsToolStripMenuItem.Checked = True
        ToolStripMenuItemToBeScheduled.Checked = True
        If gOfficeTypeID = 1 Then
            ShowNotificationsToolStripMenuItem.Text = "Show Bills Notifications"
            ShowPrintIntakeFormButtonToolStripMenuItem.Visible = True
            ShowPrintIntakeFormButtonToolStripMenuItem.Checked = True
            ToolStripButtonIntakeForm.Visible = gShowIntakeFormButton
        Else
            PrintPatientIntakeToolStripMenuItem.Visible = False
            ShowNotificationsToolStripMenuItem.Text = "Show Bills / NF2 Notifications"
            ToolStripButtonIntakeForm.Visible = False
            ShowPrintIntakeFormButtonToolStripMenuItem.Visible = False
            ShowPrintIntakeFormButtonToolStripMenuItem.Checked = False
        End If
    End Sub

    Private Sub ToolStripMenuItem23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem23.Click
        Me.BackColor = ToolStripMenuItem23.BackColor
        SetFormBackcolor()
    End Sub

    Private Sub ToolStripMenuItem24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem24.Click
        Me.BackColor = ToolStripMenuItem24.BackColor
        SetFormBackcolor()

    End Sub

    Private Sub ToolStripMenuItem25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem25.Click
        Me.BackColor = ToolStripMenuItem25.BackColor
        SetFormBackcolor()

    End Sub

    Private Sub ToolStripMenuItem26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem26.Click
        Me.BackColor = ToolStripMenuItem26.BackColor
        SetFormBackcolor()

    End Sub

    Private Sub ToolStripMenuItem27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem27.Click
        Me.BackColor = ToolStripMenuItem27.BackColor
        SetFormBackcolor()

    End Sub

    Private Sub ToolStripMenuItem28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem28.Click
        Me.BackColor = ToolStripMenuItem28.BackColor
        SetFormBackcolor()

    End Sub

    Private Sub ToolStripMenuItem29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem29.Click
        Me.BackColor = ToolStripMenuItem29.BackColor
        SetFormBackcolor()
    End Sub

    Private Sub CustomColorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomColorToolStripMenuItem.Click
        ColorDialog1.Color = Me.BackColor
        ColorDialog1.AllowFullOpen = True
        ColorDialog1.FullOpen = True
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.BackColor = ColorDialog1.Color
            SetFormBackcolor()
        End If
    End Sub

    Private Sub FindDuplicatePatientsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindDuplicatePatientsToolStripMenuItem.Click
        Application.DoEvents()
        Dim frm As Form = FormsCollection.FindForm("frmPatientsFindDuplicates")
        If Not frm Is Nothing Then
            frm.WindowState = FormWindowState.Normal
            frm.BringToFront()
            Exit Sub
        Else

            frmPatientsFindDuplicates.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
            frmPatientsFindDuplicates.MdiParent = Me
            frmPatientsFindDuplicates.WindowState = FormWindowState.Normal
            frmPatientsFindDuplicates.Show()
            frmPatientsFindDuplicates.BringToFront()
        End If
    End Sub

    Private Sub CourtIndexNumbersFilingDatesMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CourtIndexNumbersFilingDatesMaintenanceToolStripMenuItem.Click
        frmBillingIndexNumber.ShowDialog(Me)
        frmBillingIndexNumber.Dispose()
    End Sub

    Private Sub ToolStripMenuItemReadyForArbitration_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemReadyForArbitration.Click
        Application.DoEvents()
        Dim frm As Form = FormsCollection.FindForm("frmBillsForArbitration")
        If Not frm Is Nothing Then
            frm.WindowState = FormWindowState.Normal
            frm.BringToFront()
            Exit Sub
        Else

            frmBillsForArbitration.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
            frmBillsForArbitration.MdiParent = Me
            frmBillsForArbitration.WindowState = FormWindowState.Normal
            frmBillsForArbitration.Show()
            frmBillsForArbitration.BringToFront()
        End If
    End Sub
    Private Sub PaymentsProgressAnalysisToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaymentsProgressAnalysisToolStripMenuItem.Click
        frmPaymentsChart.ShowDialog(Me)
        frmPaymentsChart.Dispose()
    End Sub

    Private Sub ShowSmallToolBarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowSmallToolBarToolStripMenuItem.Click

    End Sub
    Private Sub SetToolBar(ByVal St As ToolStripItemDisplayStyle)
        For Each btn As ToolStripItem In ToolStrip1.Items
            If TypeOf (btn) Is ToolStripButton Then
                btn.DisplayStyle = St
            End If
        Next
        ShowImagesOnlyToolStripMenuItem.Checked = False
        ShowImagesAndTextToolStripMenuItem.Checked = False
        ShowTextOnlyToolStripMenuItem.Checked = False

        Select Case St
            Case ToolStripItemDisplayStyle.Image
                ShowImagesOnlyToolStripMenuItem.Checked = True
            Case ToolStripItemDisplayStyle.ImageAndText
                ShowImagesAndTextToolStripMenuItem.Checked = True
            Case ToolStripItemDisplayStyle.Text
                ShowTextOnlyToolStripMenuItem.Checked = True
        End Select

        SaveSetting(My.Application.Info.ProductName, "Settings", "ToolBarStyle", St)

    End Sub

    Private Sub ShowImagesOnlyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowImagesOnlyToolStripMenuItem.Click
        SetToolBar(ToolStripItemDisplayStyle.Image)
    End Sub

    Private Sub ShowTextOnlyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowTextOnlyToolStripMenuItem.Click
        SetToolBar(ToolStripItemDisplayStyle.Text)
    End Sub

    Private Sub ShowImagesAndTextToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowImagesAndTextToolStripMenuItem.Click
        SetToolBar(ToolStripItemDisplayStyle.ImageAndText)
    End Sub

    Private Sub ToolStripMenuItem22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem22.Click
        frmAttorneyFees.ShowDialog(Me)
        frmAttorneyFees.Dispose()
    End Sub

    'Private Sub mobjSubclassedSystemMenu_LaunchDialog() Handles mobjSubclassedSystemMenu.LaunchDialog
    '    ToolStripButton9_Click(Nothing, Nothing)
    'End Sub

    Private Sub ToolStripMenuItem30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem30.Click
        ToolStripButton9_Click(Nothing, Nothing)
    End Sub

    Private Sub ToolStripButtonCollection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonCollection.Click
        frmBillingCollection.MdiParent = Me
        'frmBillingManagement.Size = New Size(Me.Width, Me.Height)
        frmBillingCollection.WindowState = FormWindowState.Maximized
        Application.DoEvents()
        frmBillingCollection.Show()
        frmBillingCollection.BringToFront()
        frmBillingCollection.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ToolStripMenuItemCollection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemCollection.Click
        ToolStripButtonCollection_Click(Nothing, Nothing)
    End Sub

    
    Private Sub ToolStripMenuItem31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemBookMarkManager.Click
        frmWebBookmarksMaintenance.ShowDialog(Me)
        frmWebBookmarksMaintenance.Dispose()
    End Sub

End Class
