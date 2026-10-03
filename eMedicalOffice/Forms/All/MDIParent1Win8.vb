Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net.Mail
Imports System.Reflection
Imports System.Threading
Imports System.Web
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports log4net

Public Class MDIForm1Win8
    Private exitflag As Boolean
    Private ReadOnly log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Private SystemStartUpTime As DateTime
    Private m_SortingColumnSchedule As System.Windows.Forms.ColumnHeader
    Private Sub ExitToolsStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CascadeToolStripMenuItem.Click
        LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles TileVerticalToolStripMenuItem.Click
        LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles TileHorizontalToolStripMenuItem.Click
        LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles CloseAllToolStripMenuItem.Click
        ' Close all child forms of the parent.
        For Each ChildForm As Form In MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private Sub MDIForm1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.Cancel Then Exit Sub
        Try
            Hide()
            Application.DoEvents()
            PanelExit.Visible = True
            PanelExit.BringToFront()
            PanelExit.Refresh()
            exitflag = True
            Dim sql As String
            sql = "UPDATE Patients Set LockDT=Null, LockByID=0, LockedByIP = '', LockedByHostName='', LockedByName='' Where LockByID=" & gCurrentEmployee.EmpID.ToString & " " & vbCrLf
            sql &= "Delete From EmailerPrinting Where EmpID=" & gCurrentEmployee.EmpID & " " & vbCrLf
            sql &= "DELETE  FROM  ToBeScheduled    Where empid = " & gCurrentEmployee.EmpID & " " & vbCrLf
            gSQLUpdateData(sql)

            If Not FormsCollection.FindForm("frmPatientAttendancy") Is Nothing Then
                frmPatientAttendancy.Close()
                frmPatientAttendancy.Dispose()
            End If
            'ToolStripManager.SaveSettings(Me, "Custom" & gCurrentEmployee.UID)
            Dim frm As Form
            frm = FormsCollection.FindForm("frmPatient")
            If Not frm Is Nothing AndAlso frm.IsDisposed = False Then
                frm.Close()
                frm.Dispose()
            End If
            frm = FormsCollection.FindForm("frmBilling")
            If Not frm Is Nothing AndAlso frm.IsDisposed = False Then
                frm.Close()
                frm.Dispose()
            End If

            If gfrmSearchLoaded = True Then
                frmSearch.Close()
                frmSearch.Dispose()
            End If

            If Not gCapturePhoto Is Nothing AndAlso gCapturePhoto.IsDisposed = False Then
                gCapturePhoto.ClosePreviewWindow()
            End If
            frm = FormsCollection.FindForm("frmScheduleInstance")
            If Not frm Is Nothing AndAlso frm.IsDisposed = False Then
                frm.Close()
                frm.Dispose()
            End If

            frm = FormsCollection.FindForm("frmProceduresReportInstance")
            If Not frm Is Nothing AndAlso frm.IsDisposed = False Then
                frm.Close()
                frm.Dispose()
            End If

            gSettings(ReadWrite.sWrite)
            Reset()
            SaveSetting(My.Application.Info.ProductName, "Settings", "WorkSpaceBackColor" & gCurrentEmployee.UID, BackColor.ToArgb)
            SaveSetting(My.Application.Info.ProductName, "Settings", Name & "StatusBar", StatusBarToolStripMenuItem.Checked)
            SaveSetting(My.Application.Info.ProductName, "Settings", Name & "ToolBarLarge", LargeButtonsToolStripMenuItem.Checked)

            Application.DoEvents()
            If EZTwain.State = EZTwain.TWAIN_SOURCE_OPEN Then EZTwain.CloseSource()
            If EZTwain.State = EZTwain.TWAIN_SM_OPEN Then EZTwain.UnloadSourceManager()
            GC.Collect()
            gDeleteAllFiles(Path.GetTempPath, "PDF*.PDF", False, True)
            gDeleteAllFiles(Path.GetTempPath, "JPG*.JPG", False, True)
            gDeleteAllFiles(Path.GetTempPath, "*.XLS", False, True)
            gDeleteAllFiles(Path.GetTempPath, "*.rpt", False, True)
            gDeleteAllFiles(Path.GetTempPath, "*.tmp", False, True)
            SaveSetting(My.Application.Info.ProductName, "Settings", "PanelReminder", PanelRequests.Width)
            gListview_Settings(Me, ListViewRequests, ReadWrite.sWrite)
            MDILoaded = False
            SaveSetting(My.Application.Info.ProductName, "Settings", Name & "SplitterDistanceNF2", SplitContainer1.SplitterDistance)
            My.Application.OpenForms.Cast(Of Form)() _
              .Except({Me}) _
              .ToList() _
              .ForEach(Sub(form) form.Close())
        Catch ex As Exception

        End Try
        'DeleteTempFiles(False)
        gAppConfig.BackupConfiguration()
        Try
            End
        Catch
        End Try

    End Sub

    Private Sub SetMdiClientBorder()
        For Each c As Control In Controls
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

    Private Sub MDIForm1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'BackColor = Color.FromArgb(GetSetting(My.Application.Info.ProductName, "Settings", "WorkSpaceBackColor" & gCurrentEmployee.UID, Color.Gainsboro.ToArgb))
            frmMDIParent = Me
            SystemStartUpTime = CDate(gSQLGetSingleValueString("select getdate()"))
            Text = "eMedicalOffice - " + gOfficeName
            BackColor = Color.FromArgb(69, 69, 69)
            ResetSearchComboTimer.Interval = 500
            AddHandler ResetSearchComboTimer.Tick, AddressOf ResetComboSearchObjject
            SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            SetFormBackcolor()

            LoadSettings()
            gLoadSystemFunctions()
            gSQLUpdateData("InitialiseDummyProcedures")
            SetMdiClientBorder()
            If gCurrentEmployee.SC Then
                ToolStripStatusDBServer.Text = gSqlServerName
            End If
            Dim ServerIP =
                    gSQLGetSingleValueString(
                        "select local_net_address FROM sys.dm_exec_connections WHERE Session_id = @@SPID").ToString()
            If ServerIP = "" Then
                ServerIP = gGetIPInfo.HostName
            End If
            If gSqlServerName <> ServerIP Then
                lblServer.Text = " " & gSqlServerName & " / " & ServerIP & "    "
            Else
                lblServer.Text = " " & gSqlServerName & "    "
            End If

            MDILoaded = True

            lblOffice.Text = " " & gOfficeName.ToUpper & "    "
            lblOfficeType.Text = " " & gOfficeTypeIDName & "    "
            lblDate.Text = Now.ToString("dddd, MMMM dd, yyyy")
            lblTime.Text = Now.ToLongTimeString
            lblUserName.Text = gCurrentEmployee.FName & " " & gCurrentEmployee.LName
            lblPosition.Text = " " & gCurrentEmployee.Position & "    "
            Setup_Security()
            gSQLUpdateData(
                "update PatientProcedures set ProcedureInformationID = 0 WHERE (ProcedureInformationID IS NULL)")
            'PanelRequests.Width = GetSetting(My.Application.Info.ProductName, "Settings", "PanelReminder", PanelRequests.Width)
            gListview_Settings(Me, ListViewRequests, ReadWrite.sRead)
            SplitContainer1.SplitterDistance = GetSetting(My.Application.Info.ProductName, "Settings",
                                                          Name & "SplitterDistanceNF2", SplitContainer1.SplitterDistance)
            Load_Payers()
            If gOfficeTypeID = 1 Then
                ShowNotificationsToolStripMenuItem.Text = "Show Bills Notifications"
                ShowPrintIntakeFormButtonToolStripMenuItem.Visible = True
                ShowPrintIntakeFormButtonToolStripMenuItem.Checked = gShowIntakeFormButton
                ButtonIntakeFormBack.Visible = gShowIntakeFormButton
            ElseIf gOfficeTypeID = 3 Then
                ShowNotificationsToolStripMenuItem.Text = "Show Bills Notifications"
                PrintPatientIntakeToolStripMenuItem.Visible = False
                ButtonIntakeFormBack.Visible = False
                ShowPrintIntakeFormButtonToolStripMenuItem.Visible = False
                ShowPrintIntakeFormButtonToolStripMenuItem.Checked = False
            Else
                PrintPatientIntakeToolStripMenuItem.Visible = False
                ShowNotificationsToolStripMenuItem.Text = "Show Bills / NF2 Notifications"
                ButtonIntakeFormBack.Visible = False
                ShowPrintIntakeFormButtonToolStripMenuItem.Visible = False
                ShowPrintIntakeFormButtonToolStripMenuItem.Checked = False
            End If
            ButtonIntakeFormBack.Visible = True
            For Each mnu In MenuStrip.Items
                If TypeOf mnu Is ToolStripMenuItem Then
                    Setup_Menus(mnu)
                End If
            Next
            Setup_Security()

            'ToolStripManager.SaveSettings(Me, "Restore")
            'ToolStripManager.LoadSettings(Me, "Custom" & gCurrentEmployee.UID)
            'If MenuStrip.Visible = False Then
            'ToolStripManager.LoadSettings(Me, "Restore")
            'End If
            ToolStripMenuItem1.Visible = True
            ToolStripMenuItemPreCertification.Visible = gOfficeTypeID = 3
            ToolStripMenuItemCariskPayersMaintenance.Visible = gEnableElectronicBillFiling > 0
            'SetSysFunctions
            If SystemFunctions.Schedule = False Then
                ButtonSchedule.Visible = False
                SchedToolStripMenuItem.Visible = False
            End If
            If SystemFunctions.PatientMaintenance = False Then
                ButtonPatientProfileBack.Visible = False
                NewPatientToolStripMenuItem.Visible = False
            End If
            If SystemFunctions.Billing = False Then
                ButtonBillingBack.Visible = False
                BillingToolStripMenuItem1.Visible = False
                ButtonInsuranceMainenanceBack.Visible = False
            End If

            If SystemFunctions.BillingManagement = False Then
                ButtonBillMaintenanceBack.Visible = False
                CollectionToolStripMenuItem.Visible = False
            End If

            TechScheduleToolStripMenuItem.Visible = False
            ToolStripMenuItemProceduresSchedule.Visible = False
            'Dim ST As ToolStripItemDisplayStyle
            'ST = GetSetting(My.Application.Info.ProductName, "Settings", "ToolBarStyle", 2)
            'SetToolBar( ST)
            'SetToolBar(ToolStripItemDisplayStyle.ImageAndText)
            'gInstall_BarCode_Font()
            Check_Version_Functions()
            CheckBoxDoNotShowRequests.Checked = True
            CheckBoxDoNotShowBills.Checked = True
            ShowToBeScheduled.Checked = True


            TimerRefresh.Enabled = True
            DatabaseProcesses()
            init_ButtonImages()
            TimerEmailAlerts.Enabled = True
            'mobjSubclassedSystemMenu = New SubclassedSystemMenu(Handle.ToInt32, "Restore Environment")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
        StatusStrip.Renderer = New ToolStripOverride   ' Remove ToolBar White Border
        StatusStrip.Visible = False
        StatusStrip.Visible = True
        TimerOpacity.Enabled = True
        TimerToolBar.Enabled = True
    End Sub
    Private Sub Load_Payers()
        Dim Sql As String = ""
        Dim reader As SqlDataReader


        Sql = "SELECT [Payer Name],[PayerId],[States],[Professional],[Institutional],[PharmacyRx],[WorkComp],[Automotive],[835/EOB] FROM [dbo].[CariskPayers] order by [Payer Name]"
        reader = gSQLGetDataReader(Sql.ToString)
        Do While reader.Read
            Dim p As New Payer
            p.PayerName = reader("Payer Name").ToString()
            p.PayerId = reader("PayerId").ToString()
            p.States = reader("States").ToString()
            p.Professional = reader("Professional").ToString()
            p.Institutional = reader("Institutional").ToString()
            p.PharmacyRx = reader("PharmacyRx").ToString()
            p.WorkComp = reader("WorkComp").ToString()
            p.Automotive = reader("Automotive").ToString()
            p.EOB = reader("835/EOB").ToString()
            PayersList.Add(p)

        Loop
        reader.Close()
        reader = Nothing
    End Sub
    Private Sub init_ButtonImages()
        ImageListToolBar.ColorDepth = ColorDepth.Depth32Bit
        ImageListToolBar.Images.Add("ButtonSchedule", ButtonSchedule.Image)
        ImageListToolBar.Images.Add("ButtonPatientProfile", ButtonPatientProfile.Image)
        ImageListToolBar.Images.Add("ButtonIntakeForm", ButtonIntakeForm.Image)
        ImageListToolBar.Images.Add("ButtonMessaging", ButtonMessaging.Image)
        ImageListToolBar.Images.Add("ButtonPatSearchAndTools", ButtonPatSearchAndTools.Image)
        ImageListToolBar.Images.Add("ButtonSearch", ButtonSearch.Image)
        ImageListToolBar.Images.Add("ButtonNetSearch", ButtonNetSearch.Image)
        ImageListToolBar.Images.Add("ButtonInsuranceMainenance", ButtonInsuranceMainenance.Image)
        ImageListToolBar.Images.Add("ButtonBilling", ButtonBilling.Image)
        ImageListToolBar.Images.Add("ButtonBillMaintenance", ButtonBillMaintenance.Image)
        ImageListToolBar.Images.Add("ButtonCollection", ButtonCollection.Image)
        ImageListToolBar.Images.Add("ButtonNotes", ButtonNotes.Image)
        ImageListToolBar.Images.Add("ButtonAbout", ButtonAbout.Image)

        ButtonAbout.Tag = ButtonAbout.Image
    End Sub

    Private Sub Check_Version_Functions()
        ' Check if the table / field exists then function available.
        Dim SQL As String
        ' Check if the Collection Function is available
        SQL = "select count(*) from sys.columns where Name = N'ReminderDT' and Object_ID = Object_ID(N'BillComments')"
        If ButtonCollectionBack.Visible Then ButtonCollectionBack.Visible = gSQLGetSingleValue(SQL)
        gCollectionFunction = ButtonCollectionBack.Visible
    End Sub

    Private Sub Setup_Security()
        'admin options
        ScheduleBlocksReportToolStripMenuItem.Visible = gCurrentEmployee.PositionID < 3
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
        ReferringOfficesStatisticReportToolStripMenuItem.Visible = gCurrentEmployee.PositionID < 3
        'ChangeRefferingDoctorToolStripMenuItem.Visible = gCurrentEmployee.PositionID < 4
        'ChangeTreatingProviderToolStripMenuItem.Visible = gCurrentEmployee.PositionID < 4
        'ChangeBillingProviderToolStripMenuItem.Visible = gCurrentEmployee.PositionID < 4
        'ToolStripMenuItemChangePatientInformation.Visible = gCurrentEmployee.PositionID < 4
        PatientProcedureInformationToolStripMenuItem.Visible = gCurrentEmployee.PositionID < 3
        ResetPatientInformationToolStripMenuItem.Visible = gCurrentEmployee.PositionID < 3
        PaymentsReportToolStripMenuItem.Visible = gCurrentEmployee.PositionID < 4 Or gCurrentEmployee.PositionID = 6
        ToolStripSeparator1.Visible = gCurrentEmployee.PositionID < 4
        TechScheduleToolStripMenuItem.Visible = gCurrentEmployee.PositionID < 3
        InsuranceStatisticsReportToolStripMenuItem.Visible = gCurrentEmployee.PositionID < 3
        'ToolStripBillingPaymentManagementReport.Visible = gCurrentEmployee.PositionID <3
        If gCurrentEmployee.SC = False Then
            'lblPosition.Image = Nothing
        End If
        If gCurrentEmployee.PositionID < 3 Then
            PatientsScheduleReportToolStripMenuItem.ForeColor = Color.SteelBlue
            PatientsScheduleReportToolStripMenuItem.Font = New Font(PatientsScheduleReportToolStripMenuItem.Font,
                                                                    FontStyle.Bold)
        End If
        'ButtonInsuranceMainenanceBack.Visible = False
        If gCurrentEmployee.PositionID < 3 Then
            ButtonInsuranceMainenanceBack.Visible = True
            BillingTemplatesMaintenanceToolStripMenuItem.Visible = True
            'ShowBillingRemindersToolStripMenuItem.Visible = True
            'Check_Billing_Reminders()
        End If
        If gCurrentEmployee.PositionID = 4 Or gCurrentEmployee.PositionID = 10 Or gCurrentEmployee.PositionID = 110 Then ' FronDesk / Technician / FrontDesk Admin
            ButtonInsuranceMainenanceBack.Visible = False
            ButtonBillingBack.Visible = False
            ButtonBillMaintenanceBack.Visible = False
            InsuranceStatisticsReportToolStripMenuItem.Visible = False
            TreatmentStatisticReport.Visible = False
            BillingToolStripMenuItem1.Visible = False
            CollectionToolStripMenuItem.Visible = False
            ButtonCollectionBack.Visible = False
            AdminMessagingToolStripMenuItem.Visible = False
            AdminTasksToolStripMenuItem.Visible = False
            ButtonMessagingBack.Visible = False
            ToolStripSeparator10.Visible = False
            ToolStripSeparator1.Visible = False
            ToolStripSeparator7.Visible = False
            AdministrativeToolsToolStripMenuItem.Visible = False
        End If
        mnuReffOfficesFromtDeskAdmin.Visible = gCurrentEmployee.PositionID = 110
        mnuOfficesCompaniesMaintenance.Visible = gCurrentEmployee.PositionID = 1
        mnuAdminStripSeparator2.Visible = gCurrentEmployee.PositionID = 1
        mnuDiagnosticsProceduresMaintenance.Visible = gCurrentEmployee.PositionID = 1
        mnuAdminStripSeparator3.Visible = gCurrentEmployee.PositionID = 1

        TodaysScheduledProceduresToolStripMenuItem.Visible = False ' Not In USe - Until Tech Touch Screen
        SearchToolStripMenuItem.Visible = False

        CheckBoxDoNotShowBills.Visible = gCurrentEmployee.PositionID <> 4 And gCurrentEmployee.PositionID <> 110
        CheckBoxDoNotShowRequests.Visible = gCurrentEmployee.PositionID <> 4 And gCurrentEmployee.PositionID <> 110
        ToolStripSeparatorNotifications.Visible = gCurrentEmployee.PositionID <> 4 And gCurrentEmployee.PositionID <> 110
        ShowToBeScheduled.Visible = gCurrentEmployee.PositionID <> 4 And gCurrentEmployee.PositionID <> 110
        ShowNotificationsToolStripMenuItem.Visible = gCurrentEmployee.PositionID <> 4 And gCurrentEmployee.PositionID <> 110
        ShowRequestsToolStripMenuItem.Visible = gCurrentEmployee.PositionID <> 4 And gCurrentEmployee.PositionID <> 110
        ToolStripMenuItemToBeScheduled.Visible = gCurrentEmployee.PositionID <> 4 And gCurrentEmployee.PositionID <> 110

        AdminMessagingToolStripMenuItem.Visible = gCurrentEmployee.PositionID < 4
        'AdminTasksToolStripMenuItem.Visible = gCurrentEmployee.PositionID < 4
        AdminTasksToolStripMenuItem.Visible = False
        ButtonMessagingBack.Visible = gCurrentEmployee.PositionID < 4
        mnuBankDepositsAdmin.Visible = gCurrentEmployee.PositionID < 3
        mnuUpdateTreatingProvider.Visible = gCurrentEmployee.PositionID < 4
        FindDuplicatePatientsToolStripMenuItem.Visible = gCurrentEmployee.PositionID < 4
        PanelNetSearch.Visible = False
        '1	Administrator
        '2	Manager
        '3	Supervisor
        '4	Front Desk
        '5	Doctor
        '6	Billing
        '10	Technician
        '100	Transcriptionist
        Dim ConnectionsCount As Integer = gOffices.Where(Function(x) x.ConnectionString <> "").Count()
        If ConnectionsCount > 1 And
            (gCurrentEmployee.PositionID < 5 Or gCurrentEmployee.PositionID = 6 Or gCurrentEmployee.PositionID = 110) Then
            PanelNetSearch.Visible = True
        End If
    End Sub

    Private Sub LoadSettings()
        FullScreenToolStripMenuItem.Checked = Not gFullScreen
        FullScreenToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub Setup_Menus(mnu As ToolStripMenuItem)
        Dim m
        Dim mnuVisible As Boolean
        For Each m In mnu.DropDownItems
            mnuVisible = True
            If Val(m.Tag) > 0 Then
                m.Visible = False
                mnuVisible = False
                Select Case gOfficeTypeID
                    Case 1, 3
                        If Val(m.Tag) = 1 Or Val(m.Tag) = 3 Then
                            m.Visible = True
                            mnuVisible = True
                        End If
                    Case 2
                        If Val(m.Tag) = 2 Then
                            m.Visible = True
                            mnuVisible = True
                        End If
                End Select
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

        Dim mdi As MdiClient
        For Each ctl In Controls
            If TypeOf ctl Is MdiClient Then
                mdi = DirectCast(ctl, MdiClient) '/// cast mdi as the Control.
                mdi.BackColor = BackColor
                ' Prevent MDI Flickering
                Dim mi As MethodInfo = GetType(MdiClient).GetMethod("SetStyle",
                                                                    BindingFlags.Instance Or BindingFlags.NonPublic)
                mi.Invoke(mdi,
                          New Object() _
                             {ControlStyles.AllPaintingInWmPaint Or ControlStyles.DoubleBuffer Or
                              ControlStyles.ResizeRedraw Or ControlStyles.UserPaint, True})
                Exit For
            End If

        Next
    End Sub
    Private Sub Timer30Sec_Tick(sender As Object, e As EventArgs) Handles Timer5Sec.Tick
        ' Check IdleTime
        '''''''''''''     TURN OFF APPLICATION AFTER 10 days
        Dim ServerTime As DateTime = CDate(gSQLGetSingleValueString("select getdate()"))
        If DateDiff(DateInterval.Day, SystemStartUpTime, ServerTime) = 4 Then
            If lblShutDownMessage.Visible = False Then
                My.Computer.Audio.Play(My.Resources.Lock, AudioPlayMode.Background)
            End If
            lblSecurityRestart.Text = "          Due to security protocols, eMedicalOffice requires a restart. You can restart it now or it will restart automatically by tomorrow."
            lblSecurityRestart.Refresh()
            lblSecurityRestart.Visible = True
            lblSecurityRestart.BringToFront()
            Me.Refresh()
            Return
        End If

        If DateDiff(DateInterval.Day, SystemStartUpTime, Now) > 4 Then
            Timer5Sec.Enabled = False
            Try
                Application.Exit()
                Return
            Catch ex As Exception

            End Try
        End If

        gIdleTimeCurrent = GetIdleTime() / 1000
        If gIdleTimeCurrent > 0 AndAlso gIdleShutDown > 0 Then
            If gIdleTimeCurrent > (gIdleShutDown * 60) + 300 Then ' +5 Min Warning
                End
            ElseIf gIdleTimeCurrent > gIdleShutDown * 60 Then 'Minutes * 60 to get seconds
                lblShutDownMessage.BringToFront()
                If lblShutDownMessage.Visible = False Then
                    My.Computer.Audio.Play(My.Resources.WakeUp, AudioPlayMode.Background)
                    lblShutDownMessage.Visible = True
                End If
            Else
                lblShutDownMessage.Visible = False
            End If
        Else
            lblShutDownMessage.Visible = False
        End If
        lblTime.Text = Now.ToString("hh:mm tt")
    End Sub

    Private Sub FullScreenToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles FullScreenToolStripMenuItem.Click
        FullScreenToolStripMenuItem.Checked = Not FullScreenToolStripMenuItem.Checked

        If FullScreenToolStripMenuItem.Checked Then
            FormBorderStyle = FormBorderStyle.None
            WindowState = FormWindowState.Normal
            Application.DoEvents()
            WindowState = FormWindowState.Maximized
        Else
            FormBorderStyle = FormBorderStyle.Sizable
        End If
        gFullScreen = FullScreenToolStripMenuItem.Checked
    End Sub

    Private Sub ButtonSchedule_Click(sender As Object, e As EventArgs) Handles ButtonSchedule.Click

        Application.DoEvents()
        gfrmScheduleLoaded = True
        PanelButtonsBack.UseWaitCursor = True
        ButtonSchedule.Enabled = False
        ButtonFocus.Focus()
        Application.DoEvents()
        If frmScheduleInstance Is Nothing OrElse frmScheduleInstance.IsDisposed Then
            frmScheduleInstance = New frmSchedule()
            If Screen.AllScreens.Count > 1 Then
                frmScheduleInstance.ToolStripButtonDetach.Visible = True
                'If Val(GetSetting(My.Application.Info.ProductName, "GUI\USER-" & gCurrentEmployee.EmpID & "\" & UCase(frmScheduleInstance.Name), "DETACHED", "0")) = 0 Then
                frmScheduleInstance.ToolStripButtonDetach.Image = gDetachAttachWindow(frmScheduleInstance, Me, eAttachDetach.Attach)
                frmScheduleInstance.PanelTop.Visible = False
                'Else
                'frmScheduleInstance.ToolStripButtonDetach.Image = gDetachAttachWindow(frmScheduleInstance, Me, eAttachDetach.Detacvh)
                'frmScheduleInstance.PanelTop.Visible = True
                'End If
            Else
                frmScheduleInstance.MdiParent = Me
                frmScheduleInstance.WindowState = FormWindowState.Minimized
                Application.DoEvents()
                frmScheduleInstance.Show()
                frmScheduleInstance.WindowState = FormWindowState.Maximized
                frmScheduleInstance.ToolStripButtonDetach.Visible = False
                frmScheduleInstance.PanelTop.Visible = False
            End If
        End If

        frmScheduleInstance.Size = New Size(Width, Height)
        frmScheduleInstance.WindowState = FormWindowState.Maximized
        Application.DoEvents()
        frmScheduleInstance.Show()
        frmScheduleInstance.BringToFront()
        frmScheduleInstance.WindowState = FormWindowState.Maximized
        PanelButtonsBack.UseWaitCursor = False
        ButtonSchedule.Enabled = True

        'ButtonFocus.Focus()
        'PanelButtonsBack.UseWaitCursor = True

        'Application.DoEvents()
        'gfrmScheduleLoaded = True
        'SchedToolStripMenuItem.Enabled = False
        'ButtonSchedule.Enabled = False
        'frmSchedule.MdiParent = Me
        ''frmSchedule.Size = New Size(Width, Height)
        'frmSchedule.WindowState = FormWindowState.Maximized
        'Application.DoEvents()
        'frmSchedule.Show()
        'frmSchedule.BringToFront()
        'frmSchedule.WindowState = FormWindowState.Maximized
        'SchedToolStripMenuItem.Enabled = True
        'ButtonSchedule.Enabled = True
        'PanelButtonsBack.UseWaitCursor = False
    End Sub

    Private Sub ToolStripMenuItem2_Click_1(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Using frm As frmProperties = New frmProperties
            frm.ShowDialog()
            frm.Dispose()
        End Using
        lblServer.Text = gSqlServerName
        If gRestart = True Then
            MsgBox("In order to apply the new system settings, eMedical Office should be restarted.",
                   MsgBoxStyle.Exclamation)
            Close()
            If FormsCollection.Forms.Count = 0 Then
                Application.Restart()
            Else
                MsgBox(
                    "Unable to restart eMedical Office automatially." & vbCrLf & vbCrLf &
                    "Please save all unsaved data and restart  eMedical Office manually.", MsgBoxStyle.Critical)
            End If
        End If
    End Sub

    Private Sub ProcedureMaintenanceToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles ProcedureMaintenanceToolStripMenuItem.Click
        Using frm As frmProcedureMaintenance = New frmProcedureMaintenance
            frm.ShowDialog()
            frm.Dispose()
        End Using
    End Sub

    Private Sub InsurancesMaintenanceToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles InsurancesMaintenanceToolStripMenuItem.Click

        Dim frm As Form = FormsCollection.FindForm("frmInsuranceMaintenance")
        If Not frm Is Nothing Then
            frm.WindowState = FormWindowState.Normal
            frm.BringToFront()
            Exit Sub
        Else
            'frmInsuranceMaintenance.Width = 1000
            frm = New frmInsuranceMaintenance
            frm.WindowState = FormWindowState.Normal
            frm.Location = New Point(Left + ((Width - frm.Size.Width) \ 2),
                                                         Top + ((Height - frm.Size.Height) \ 2))
            frm.Show(Me)
            frm.BringToFront()
        End If
    End Sub

    Private Sub AttorneyMaintenanceToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles AttorneyMaintenanceToolStripMenuItem.Click
        Using frm As frmAttorneyMaintenance = New frmAttorneyMaintenance
            frm.ShowDialog()
            frm.Dispose()
        End Using
    End Sub

    Private Sub TransportationMaintenanceToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles TransportationMaintenanceToolStripMenuItem.Click
        Using frm As frmTransportationCompaniesMaintenance = New frmTransportationCompaniesMaintenance
            frm.ShowDialog()
            frm.Dispose()
        End Using
    End Sub

    Private Sub InjuryTypesMaintenanceToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles InjuryTypesMaintenanceToolStripMenuItem.Click
        Using frm = New frmInjuryTypesMaintenance

            frm.ShowDialog()
            frm.Dispose()
        End Using
    End Sub

    Private Sub lblPosition_DoubleClick(sender As Object, e As EventArgs) Handles lblPosition.DoubleClick
        If Not lblPosition.Image Is Nothing Then
            gCurrentEmployee.SC = False
            Setup_Security()
        End If
    End Sub

    Private Sub ScannerDocumentMaintenanceToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles ScannerDocumentMaintenanceToolStripMenuItem.Click
        Using frm As frmDocumentsMaintenance = New frmDocumentsMaintenance
            frm.ShowDialog()
            frm.Dispose()
        End Using

    End Sub

    Public Sub ButtonPatientProfile_Click(sender As Object, e As EventArgs) Handles ButtonPatientProfile.Click
        PanelButtonsBack.UseWaitCursor = True
        ButtonPatientProfile.Enabled = False

        ButtonFocus.Focus()
        Application.DoEvents()
        Dim frm As Form = FormsCollection.FindForm("frmPatient")
        If frm Is Nothing Then
            frm = New frmPatient
            frm.MdiParent = Me
            gWindow_Settings(frm, ReadWrite.sRead)
        End If
        If MdiChildren.Count = 0 Then
            frm.WindowState = FormWindowState.Normal
        Else
            frm.WindowState = FormWindowState.Maximized
        End If
        frm.Visible = True
        frm.Show()
        frm.BringToFront()
        'Cursor = Cursors.WaitCursor
        PanelButtonsBack.UseWaitCursor = False
        ButtonPatientProfile.Enabled = True
    End Sub

    Private gfrmSearchLoaded As Boolean

    Private Sub ButtonSearch_Click(sender As Object, e As EventArgs) Handles ButtonSearch.Click

        Application.DoEvents()
        ButtonFocus.Focus()
        Application.DoEvents()
        Using frm As frmQuickSearch = New frmQuickSearch
            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
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

    Private Sub NewPatientToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles NewPatientToolStripMenuItem.Click
        ButtonPatientProfile_Click(Nothing, Nothing)
    End Sub

    Private Sub SchedToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles SchedToolStripMenuItem.Click
        ButtonSchedule_Click(Nothing, Nothing)
    End Sub

    Private Sub UnlockPatientProfilesToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles mnuUnlockPatientProfiles.Click
        Using frm As frmUnlockProfiles = New frmUnlockProfiles
            frm.ShowDialog()
            frm.Dispose()
        End Using
    End Sub

    Private Sub SearchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SearchToolStripMenuItem.Click
        If gfrmSearchLoaded = False Then
            gfrmSearchLoaded = True
            frmSearch.StartPosition = FormStartPosition.CenterParent
            frmSearch.Show(Me)
        Else
            frmSearch.StartPosition = FormStartPosition.Manual
            frmSearch.Location = New Point(Left + ((Width - frmSearch.Size.Width) \ 2),
                                           Top + ((Height - frmSearch.Size.Height) \ 2))
            frmSearch.Show(Me)
        End If
    End Sub

    Private Sub TransportationRequestToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles ToolStripMenuItemTransportationRequest.Click
        Application.DoEvents()
        Using frm As frmTransportationRequest = New frmTransportationRequest
            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.ShowDialog(Me)
        End Using
    End Sub

    Private Sub PatientsScheduleReportToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles PatientsScheduleReportToolStripMenuItem.Click
        Application.DoEvents()
        Application.DoEvents()
        Dim frm As frmReportPatientVisits = New frmReportPatientVisits
        frm.MdiParent = Me
        frm.WindowState = FormWindowState.Normal
        Application.DoEvents()
        frm.Show()
        frm.BringToFront()
        frm.WindowState = FormWindowState.Normal

        'frmReportPatientVisits.ShowDialog(Me)
        'frmReportPatientVisits.Dispose()
    End Sub

    Private Sub PatientInformationReportToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles PatientInformationReportToolStripMenuItem.Click
        Application.DoEvents()
        Using frm As frmReportPatientInfo = New frmReportPatientInfo
            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Sub TodaysScheduledProceduresToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles TodaysScheduledProceduresToolStripMenuItem.Click
    End Sub

    Private Sub DiagnosisMaintenanceToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles DiagnosisMaintenanceToolStripMenuItem.Click
        Using frm As frmDiagnosisMaintenance = New frmDiagnosisMaintenance
            frm.ShowDialog()
            frm.Dispose()
        End Using
    End Sub

    Private Sub TechScheduleToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles TechScheduleToolStripMenuItem.Click
        'frmScheduleTechnician.ShowDialog()
        'frmScheduleTechnician.Dispose()
    End Sub

    Private Sub QuickSearchToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles QuickSearchToolStripMenuItem.Click
        ButtonSearch_Click(Nothing, Nothing)
    End Sub

    Private Sub BillingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BillingToolStripMenuItem.Click
        ButtonBilling_Click(Nothing, Nothing)
    End Sub

    Private Sub BillMaintenanceToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles BillMaintenanceToolStripMenuItem.Click
        ButtonBillMaintenance_Click(Nothing, Nothing)
    End Sub

    Private Sub RequestImageDiskToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles RequestImageDiskToolStripMenuItem.Click
        Using frm As frmImageDiskRequest = New frmImageDiskRequest
            frm.MinimizeBox = False
            frm.MaximizeBox = False

            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Sub ProduceDiskToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles ProduceDiskToolStripMenuItem.Click
        Using frm As frmImageDiskProcessing = New frmImageDiskProcessing

            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Sub ButtonBillMaintenance_Click(sender As Object, e As EventArgs) Handles ButtonBillMaintenance.Click

        Application.DoEvents()
        PanelButtonsBack.UseWaitCursor = True
        ButtonBillMaintenance.Enabled = False
        ButtonFocus.Focus()
        Application.DoEvents()
        If frmBillingManagementInstance Is Nothing OrElse frmBillingManagementInstance.IsDisposed Then
            frmBillingManagementInstance = New frmBillingManagement()
            If Screen.AllScreens.Count > 1 Then
                frmBillingManagementInstance.ToolStripButtonDetach.Visible = True
                'If Val(GetSetting(My.Application.Info.ProductName, "GUI\USER-" & gCurrentEmployee.EmpID & "\" & UCase(frmBillingManagementInstance.Name), "DETACHED", "0")) = 0 Then
                frmBillingManagementInstance.ToolStripButtonDetach.Image = gDetachAttachWindow(frmBillingManagementInstance, Me, eAttachDetach.Attach)
                frmBillingManagementInstance.PanelTop.Visible = False
                'Else
                'frmBillingManagementInstance.ToolStripButtonDetach.Image = gDetachAttachWindow(frmBillingManagementInstance, Me, eAttachDetach.Detacvh)
                'frmBillingManagementInstance.PanelTop.Visible = True
                'End If
            Else
                frmBillingManagementInstance.MdiParent = Me
                frmBillingManagementInstance.WindowState = FormWindowState.Minimized
                Application.DoEvents()
                frmBillingManagementInstance.Show()
                frmBillingManagementInstance.WindowState = FormWindowState.Maximized

                frmBillingManagementInstance.ToolStripButtonDetach.Visible = False
                frmBillingManagementInstance.PanelTop.Visible = False
            End If
        End If
        'frmBillingManagementInstance.Size = New Size(Width, Height)
        frmBillingManagementInstance.WindowState = FormWindowState.Maximized
        Application.DoEvents()
        frmBillingManagementInstance.Show()
        frmBillingManagementInstance.BringToFront()

        PanelButtonsBack.UseWaitCursor = False
        ButtonBillMaintenance.Enabled = True
    End Sub

    Private Sub ButtonBilling_Click(sender As Object, e As EventArgs) Handles ButtonBilling.Click

        Application.DoEvents()
        PanelButtonsBack.UseWaitCursor = True
        ButtonBilling.Enabled = False
        ButtonFocus.Focus()
        Application.DoEvents()

        ' tEMP
        frmBilling.MdiParent = Me
        frmBilling.Size = New Size(Width, Height)
        frmBilling.WindowState = FormWindowState.Maximized
        Application.DoEvents()
        frmBilling.Show()
        frmBilling.BringToFront()
        frmBilling.WindowState = FormWindowState.Maximized
        PanelButtonsBack.UseWaitCursor = False
        ButtonBilling.Enabled = True
    End Sub

    Private Sub ImageDiskReportToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles ImageDiskReportToolStripMenuItem.Click
        Using frm As frmImageDiskReport = New frmImageDiskReport

            frm.MinimizeBox = False
            frm.MaximizeBox = False

            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Sub ToolStripMenuItemCDReport_Click(sender As Object, e As EventArgs) _
        Handles ToolStripMenuItemCDReport.Click
        Using frm As frmImageDiskReport = New frmImageDiskReport

            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Function ScanDocumentFromScanner(DocProfileID As Integer) As Boolean
        Dim PatientID As Long
        Using frm As frmDocumentScannerPDF = New frmDocumentScannerPDF

            frm.IniDocProfile = DocProfileID
            frm.PatientID = 0
            frm.MinimizeBox = False
            frm.MaximizeBox = False

            If frm.ShowDialog(Me) = DialogResult.OK Then
                ScanDocumentFromScanner = True
            End If
            frm.Dispose()
        End Using
    End Function

    Private Function ScanDocumentFromScannerApplication(DocProfileID As Integer) As Boolean
        Dim PatientID As Long
        If gScannerFolder = "" Then
            MsgBox(
                "Unable to scan. The Scanner Folder has not been specified." & vbCrLf &
                "Please call your system administrator.", MsgBoxStyle.Exclamation)
            Exit Function
        End If
        If Directory.Exists(gScannerFolder) = False Then
            MsgBox(
                "Unable to scan. Invalid Scanner Folder specified." & vbCrLf & "Please call your system administrator.",
                MsgBoxStyle.Exclamation)
            Exit Function
        End If
        Using frm As frmDocumentScannerExternalProgram = New frmDocumentScannerExternalProgram

            frm.IniDocProfile = DocProfileID
            frm.PatientID = 0
            frm.MinimizeBox = False
            frm.MaximizeBox = False

            If frm.ShowDialog(Me) = DialogResult.OK Then
                ScanDocumentFromScannerApplication = True
            End If
            frm.Dispose()
        End Using
    End Function

    Private Sub POMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles POMToolStripMenuItem.Click
        Dim Ret As Boolean
        If gScannerMode = 1 Then
            Ret = ScanDocumentFromScannerApplication(3)
        Else
            Ret = ScanDocumentFromScanner(3)
        End If
    End Sub

    Private Sub FindPOMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FindPOMToolStripMenuItem.Click
        Using frm As frmFindPOM = New frmFindPOM

            frm.MinimizeBox = False
            frm.MaximizeBox = False

            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Sub MessagePoolToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles MessagePoolToolStripMenuItem.Click
        Using frm As frmMessagePool = New frmMessagePool

            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Sub PhoneBookToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles PhoneBookToolStripMenuItem.Click
        Using frm As frmPhoneBook = New frmPhoneBook

            frm.MinimizeBox = False
            frm.MaximizeBox = False

            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Sub BillingCompaniesMaintenanceToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles BillingCompaniesMaintenanceToolStripMenuItem.Click
        Using frm As frmBillingCompanyMaintenance = New frmBillingCompanyMaintenance

            frm.MinimizeBox = False
            frm.MaximizeBox = False

            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Sub SignInSheetByDateToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles SignInSheetByDateToolStripMenuItem.Click
        Using frm As frmReportPatientVisitsTodayProcedures = New frmReportPatientVisitsTodayProcedures

            frm.MinimizeBox = False
            frm.MaximizeBox = False

            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Sub SignInSheetByPatientToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles SignInSheetByPatientToolStripMenuItem.Click
        Using frm As frmReportPatientVisitsProceduresByPatient = New frmReportPatientVisitsProceduresByPatient

            frm.MinimizeBox = False
            frm.MaximizeBox = False

            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Sub PatientsProcedureReadingsToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles PatientsProcedureReadingsToolStripMenuItem.Click, PatientsProcedureReadingsToolStripMenuItem1.Click
        Application.DoEvents()
        Using frm As frmReadings = New frmReadings

            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Sub MRIDataExportToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles MRIDataExportToolStripMenuItem.Click
        Application.DoEvents()
        Using frm As frmMRIExport = New frmMRIExport

            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Sub NoFaultMissingClaimNumberReportToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles NoFaultMissingClaimNumberReportToolStripMenuItem.Click
        Application.DoEvents()
        Using frm As frmMissingInsuranceInformation = New frmMissingInsuranceInformation

            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Sub InsuranceStatisticsReportToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles InsuranceStatisticsReportToolStripMenuItem.Click
        Application.DoEvents()
        Using frm As frmInsuranceCompanyStatistics = New frmInsuranceCompanyStatistics
            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.ShowDialog(Me)
            frm.Dispose()
        End Using

    End Sub

    Private Sub NoFaultMissingInformationReceivedToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles NoFaultMissingInformationReceivedToolStripMenuItem.Click
        Application.DoEvents()
        Using frm As frmIncompletePatientInformation = New frmIncompletePatientInformation
            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Sub BillingTemplatesMaintenanceToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles BillingTemplatesMaintenanceToolStripMenuItem.Click
        Application.DoEvents()
        Using frm As frmBillingTemplates = New frmBillingTemplates
            frm.MinimizeBox = False
            frm.MaximizeBox = False

            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Sub QuickScheduleReportToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles QuickScheduleReportToolStripMenuItem.Click
        Application.DoEvents()
        frmQuickScheduleReport.MdiParent = Me
        gWindow_Settings(frmQuickScheduleReport, ReadWrite.sRead)
        Application.DoEvents()
        frmQuickScheduleReport.Show()
        frmQuickScheduleReport.BringToFront()
    End Sub

    Private Sub ReferringOfficesStatisticReportToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles ReferringOfficesStatisticReportToolStripMenuItem.Click, ToolStripMenuItemRefOfficeStatiosticReport.Click
        Application.DoEvents()
        Using frm As frmOfficeStatistics = New frmOfficeStatistics
            frm.MinimizeBox = False
            frm.MaximizeBox = True
            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        Using frm As frmAttorneyAssignCaseNumber = New frmAttorneyAssignCaseNumber
            If frm.ShowDialog() = DialogResult.OK Then
                Dim frmbillingmanager As Form = FormsCollection.FindForm("frmBillingManagement")
                If Not frmbillingmanager Is Nothing Then
                    CType(frmbillingmanager, frmBillingManagement).ButtonFind_Click(Nothing, Nothing)
                End If
            End If
            frm.Dispose()
        End Using
    End Sub

    Private SkeepChecked As Boolean

    Public Sub TimerRefresh_Tick(sender As Object, e As EventArgs) Handles TimerRefresh.Tick
        Dim Saverequests As Integer = ListViewRequests.Items.Count
        Dim SaveBills As Integer = ListViewBills.Items.Count
        Dim SaveNF2 As Integer = ListViewNF2.Items.Count
        Dim SaveReDone As Integer = ListViewSchedule.Items.Count
        If gIdleTimeCurrent > 1200 Then Exit Sub
        On Error GoTo Er
        If exitflag Then Return
        If IsDisposed Then Exit Sub
        TimerRefresh.Interval = 60000
        TimerRefresh.Stop()

        'If PanelMessage.Visible = False Then
        '    lblMessage.Text = ""
        '    CheckMessages()
        'End If

        'Dim empReader As SqlDataReader = gSQLGetDataReader("select UID, Password, PositionID, activeind from Employees Where ActiveInd=1 and EmpId = " & gCurrentEmployee.EmpID)
        'If empReader.HasRows Then
        '    empReader.Read()
        '    If Val(empReader("activeind").ToString()) = 0 Or empReader("UID").ToString() <> gCurrentEmployee.UID.ToString Or empReader("Password").ToString() <> gEncrypt(gCurrentEmployee.Password) Or Val(empReader("PositionID").ToString()) <> gCurrentEmployee.PositionID Then
        '        On Error Resume Next
        '        If lblSecurityRestart.Visible = True Then
        '            MsgBox("Due to security protocols, eMedicalOffice will be terminated now.", MsgBoxStyle.Exclamation, "Attention")
        '            Application.Exit()
        '            Return
        '        Else
        '            If MsgBox("Due to security protocols, eMedicalOffice requires a restart. Do you want to restart it now?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Attention") = MsgBoxResult.Yes Then
        '                Application.Exit()
        '                Return
        '            End If
        '            lblSecurityRestart.Text = "          Due to security protocols, eMedicalOffice requires a restart. You can restart it now or it will restart automatically in one minute. Please save all your changes."
        '            lblSecurityRestart.Refresh()
        '            lblSecurityRestart.Visible = True
        '            lblSecurityRestart.BringToFront()
        '            Me.Refresh()
        '        End If

        '    End If
        'End If

        If exitflag Then Return
        CheckMessages()
        If exitflag Then Return
        If CheckBoxDoNotShowRequests.Checked And CheckBoxDoNotShowBills.Checked And ShowToBeScheduled.Checked Then
            ListViewSchedule.Items.Clear()
            ListViewBills.Items.Clear()
            ListViewRequests.Items.Clear()
            Exit Sub
        End If

        'If gCurrentEmployee.PositionID <> 6 And gCurrentEmployee.PositionID <> 4 And gCurrentEmployee.PositionID <> 1 And gCurrentEmployee.PositionID <> 2 And gCurrentEmployee.PositionID <> 3 Then Exit Sub

        If ShowToBeScheduled.Checked = False Then
            If _
                gCurrentEmployee.PositionID = 1 Or gCurrentEmployee.PositionID = 2 Or gCurrentEmployee.PositionID = 3 Or
                gCurrentEmployee.PositionID = 4 Then
                Load_ReDoneProcedures()
            End If

            Application.DoEvents()
        Else
            ListViewSchedule.Items.Clear()
        End If

        Application.DoEvents()
        If exitflag Then Return
        If CheckBoxDoNotShowRequests.Checked = False Then
            Load_Requests()
        Else
            ListViewRequests.Items.Clear()
        End If

        If CheckBoxDoNotShowBills.Checked = False Then
            If gCurrentEmployee.PositionID = 6 Or gCurrentEmployee.PositionID = 1 Or gCurrentEmployee.PositionID = 2 _
                Then Load_Bills() ' Admin, Billing
            Application.DoEvents()
            If gCurrentEmployee.PositionID = 6 Or gCurrentEmployee.PositionID = 1 Or gCurrentEmployee.PositionID = 2 _
                Then Load_NF2() ' Admin, Billing
            Application.DoEvents()
        Else
            ListViewBills.Items.Clear()
            ListViewNF2.Items.Clear()
        End If
        If exitflag Then Return
        If ListViewRequests.Items.Count > 0 Then
            PanelRequests.Left = Width
            Application.DoEvents()
            PanelRequests.Visible = True
        Else
            PanelRequests.Visible = False
        End If
        If IsDisposed Then Exit Sub
        SkeepChecked = True
        If ListViewSchedule.Items.Count > 0 Then
            If exitflag Then Return
            If ListViewSchedule.Items.Count = 0 Then
                SplitContainerEUOIME.Panel1Collapsed = True
            Else
                SplitContainerEUOIME.Panel1Collapsed = False
                If LastSelectedListView Is ListViewSchedule Then LastSelectedListView = Nothing
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
        If exitflag Then Return
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
        If IsDisposed Then Exit Sub
        LockWindowUpdate(Handle)
        If _
            Saverequests < ListViewRequests.Items.Count Or SaveBills < ListViewBills.Items.Count Or
            SaveNF2 < ListViewNF2.Items.Count Or SaveReDone < ListViewSchedule.Items.Count Then
            If exitflag Then Return
            PictureBoxPanelBills.Visible = True
            PictureBoxPanelReminders.Visible = True
            PictureBoxSchedule.Visible = True
            TimerFlashRedBall.Enabled = True
            My.Computer.Audio.Play(My.Resources.Notify, AudioPlayMode.Background)
            Refresh()
        Else
            If exitflag Then Return
            If lblMessage.Text <> "" And PanelMessage.Visible = False Then
                My.Computer.Audio.Play(My.Resources.Notify, AudioPlayMode.Background)
                Refresh()
            End If
        End If
        If lblMessage.Text <> "" And PanelMessage.Visible = False Then

            PanelMessage.Visible = True
            PanelMessage.BringToFront()
        End If
        LockWindowUpdate(0)
Er:
        TimerRefresh.Start()
    End Sub

    Public ArrMessages As New ArrayList
    Private MessageDisplayed As Boolean

    Private Sub CheckMessages()
        Dim SQL As String
        Dim Reader As SqlDataReader
        Dim gr As Graphics = CreateGraphics()
        Dim TextHeight As Single
        Dim SaveMessagesNumber As Integer
        If MessageDisplayed = True Then Exit Sub
        'lblMessage.Text = ""
        'ToolTip1.SetToolTip(lblMessage, "")
        SaveMessagesNumber = ArrMessages.Count
        ArrMessages.Clear()
        'SQL = "SELECT     TOP (1) MessagesRecipients.ID, Messages.ResponseRequired, Messages.MessageTitle, Messages.MessageBody, MessagesRecipients.ConfirmedDT"
        SQL =
            "SELECT Messages.MessageID, Priority, MessagesRecipients.ID, Messages.ResponseRequired, Messages.MessageTitle, Messages.MessageBody, MessagesRecipients.ConfirmedDT"
        SQL &= " FROM MessagesRecipients INNER JOIN Messages ON MessagesRecipients.MessageID = Messages.MessageID "
        SQL &= " WHERE MessagesRecipients.ConfirmedDT IS NULL and MessagesRecipients.ToID = " & gCurrentEmployee.EmpID
        SQL &= " ORDER BY Messages.Priority desc, Messages.MessageID asc"
        If exitflag Then Return
        Reader = gSQLGetDataReader(SQL)
        If exitflag Then Return
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            If exitflag Then Return
            If Val(Reader("Priority").ToString) = 2 Then
                MessageDisplayed = True
                If Val(Reader("ResponseRequired").ToString) = 1 Then
                    Using frm As frmMessageConfirmation = New frmMessageConfirmation
                        frm.Label2.Text = "Urgent Message!" & vbCrLf & "Response required"
                        frm.cmdClose.Text = "Postpone"
                        frm.HightPriority = True
                        frm.MessageID = Val(Reader("ID").ToString)
                        frm.OriginalMessage = Reader("MessageBody").ToString.Trim
                        frm.PictureBox1.Image = frmMessageConfirmation.PictureBox2.Image
                        frm.TextBoxOriginalMessage.Text = Reader("MessageBody").ToString.Trim
                        If frm.ShowDialog(Me) <> DialogResult.OK Then
                            SQL = "UPDATE Messages set Priority = 1 where MessageID=" & Val(Reader("MessageID").ToString)
                            gSQLUpdateData(SQL)
                            ArrMessages.Add(New ValueDescription(Reader("ID").ToString.Trim,
                                                                 Reader("MessageTitle").ToString.Trim,
                                                                 Reader("MessageBody").ToString.Trim,
                                                                 Val(Reader("ResponseRequired").ToString.Trim)))
                        End If
                        frm.Dispose()
                    End Using
                Else
                    MsgBox(Reader("MessageBody").ToString.Trim, MsgBoxStyle.Exclamation,
                           "Urgent! " & Reader("MessageTitle").ToString.Trim)
                    SQL = "UPDATE MessagesRecipients set ConfirmedDT = getdate() where ID=" & Val(Reader("ID").ToString)
                    gSQLUpdateData(SQL)
                End If
                MessageDisplayed = False
            Else
                ArrMessages.Add(New ValueDescription(Reader("ID").ToString.Trim, Reader("MessageTitle").ToString.Trim,
                                                     Reader("MessageBody").ToString.Trim,
                                                     Val(Reader("ResponseRequired").ToString.Trim)))
            End If
        Loop

        lblMessages.Text = " Of  " & ArrMessages.Count
        LabelBtnMsgNumber.Text = ArrMessages.Count
        If exitflag Then Return
        If ArrMessages.Count > 0 Then

            If PanelMessage.Visible = False Then
                MsgNumber = 0
                ShowMessage(True)
            End If
        Else
            PanelMessage.Visible = False
            lblMessage.Text = ""

            lblMessageTitle.Text = ""
            ToolTip1.SetToolTip(lblMessage, "")
        End If
    End Sub

    Dim MsgNumber As Integer

    Private Sub ShowMessage(ShowNext As Boolean)
        Dim Msg As ValueDescription
        If exitflag Then Return
        If ShowNext Then
            MsgNumber = MsgNumber + 1
            If MsgNumber > ArrMessages.Count Then MsgNumber = 1
        Else
            MsgNumber = MsgNumber - 1
            If MsgNumber < 1 Then MsgNumber = ArrMessages.Count
        End If
        Msg = CType(ArrMessages.Item(MsgNumber - 1), ValueDescription)
        LabelCurMessage.Text = MsgNumber

        lblMessageTitle.Text = Msg.Description
        lblMessage.Text = Msg.Value1
        lblMessage.Tag = Msg.Fld1
        PanelMessage.Tag = Msg.Value
        'TextHeight = gr.MeasureString(lblMessage.Text, lblMessage.Font).Height
        PanelMessage.Height = lblMessage.Height + 20
        ToolTip1.SetToolTip(lblMessage, Msg.Value1)
        'My.Computer.Audio.Play(My.Resources.pop3, AudioPlayMode.Background)
    End Sub

    Private Sub PictureBoxClose_Click(sender As Object, e As EventArgs) Handles PictureBoxClose.Click
        Dim SQL As String
        TimerRefresh.Enabled = False

        MessageDisplayed = True
        If Val(lblMessage.Tag) = 1 Then
            Using frm As frmMessageConfirmation = New frmMessageConfirmation
                frm.MessageID = Val(PanelMessage.Tag)
                frm.OriginalMessage = lblMessage.Text
                frm.TextBoxOriginalMessage.Text = lblMessage.Text
                If frm.ShowDialog(Me) = DialogResult.OK Then
                    Try
                        ArrMessages.RemoveAt(MsgNumber - 1)
                    Catch
                    End Try
                    If ArrMessages.Count = 0 Then
                        PanelMessage.Visible = False
                    Else
                        ShowMessage(True)
                    End If
                End If
                frm.Dispose()
            End Using
        Else

            If MsgBox("Please  confirm you have acknowledge this message?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                SQL = "UPDATE MessagesRecipients set ConfirmedDT = getdate() where ID=" & Val(PanelMessage.Tag)
                gSQLUpdateData(SQL)
                Try
                    ArrMessages.RemoveAt(MsgNumber - 1)
                Catch
                End Try

                If ArrMessages.Count = 0 Then
                    PanelMessage.Visible = False
                Else
                    ShowMessage(True)
                End If
            End If
        End If
        MessageDisplayed = False
        TimerRefresh.Enabled = True
        lblMessages.Text = " Of  " & ArrMessages.Count
        LabelBtnMsgNumber.Text = ArrMessages.Count
    End Sub

    Private Sub Load_ReDoneProcedures()
        Dim LI As ListViewItem
        Dim Reader As SqlDataReader
        Dim SQL As String
        Dim R As Integer
        Dim PatientID As Long
        Dim tMSG As String
        Dim SaveText = ""
        If exitflag Then Return
        If gOfficeTypeID = 2 Then
            ListViewSchedule.Items.Clear()
            Exit Sub
        End If

        If ListViewSchedule.SelectedItems.Count > 0 Then
            PatientID = ListViewSchedule.SelectedItems(0).Tag
            SaveText = ListViewSchedule.SelectedItems(0).Text
        End If
        SQL =
            "SELECT  DISTINCT  Patients.InsertedDT, Patients.PatientID, isnull(Patients.FName,'') + ' ' + isnull(Patients.MI,'') + ' ' + isnull(Patients.LName,'') AS PatName, PatientProcedures.DoNotBillInd, PatientProcedures.DoNotBillAction"
        SQL &=
            " FROM         Patients INNER JOIN PatientProcedures ON Patients.PatientID = PatientProcedures.PatientID "
        SQL &= " WHERE     Patients.OfficeID = " & gOfficeID
        SQL &=
            " AND (Patients.CaseStatusID = 1 or (Patients.CaseStatusID = 4 and PatientProcedures.DoNotBillAction=1)) "
        SQL &= " AND (Patients.NoMoreAppointmentsInd = 0 or PatientProcedures.DoNotBillAction=1)"
        SQL &= " AND PatientProcedures.ProcedureStatusID = 0 "
        SQL &= " ORDER BY PatientProcedures.DoNotBillAction DESC, PatName "
        If exitflag Then Return
        Reader = gSQLGetDataReader(SQL)
        If exitflag Then Return
        ListViewSchedule.BeginUpdate()
        ListViewSchedule.Items.Clear()
        If Reader Is Nothing Then GoTo ExitSub

        Do Until Reader.Read = False
            If exitflag Then Return
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

        SQL =
            " SELECT DISTINCT Patients.InsertedDT, Patients.PatientID, isnull(Patients.FName,'') + ' ' + isnull(Patients.MI,'') + ' ' + isnull(Patients.LName,'') AS PatName, PatientProcedures.PatientID "
        SQL = SQL &
              " FROM         PatientProcedures INNER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID INNER JOIN Patients ON PatientProcedures.PatientID = Patients.PatientID "
        SQL = SQL & " WHERE Patients.OfficeID = " & gOfficeID &
              " AND Patients.CaseStatusID = 1 and (DATEDIFF(hh, Schedule.ScheduleDateTime, GETDATE()) >  " &
              gNoShowHours & ") AND (PatientProcedures.ProcedureStatusID = 1) "
        SQL = SQL & " ORDER BY PatName "

        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then GoTo ExitSub
        Do Until Reader.Read = False
            LI = ListViewSchedule.Items.Add("NS-" & Reader("PatientID").ToString)
            LI.SubItems.Add(Reader("PatName"))
            LI.UseItemStyleForSubItems = True
            LI.Tag = Reader("PatientID").ToString
            LI.ToolTipText = "NoShow! Procedure should be rescheduled"
            If IsDate(Reader("InsertedDT").ToString) Then
                If DateDiff(DateInterval.Day, CDate(Reader("InsertedDT").ToString), Now) > 30 Then
                    LI.ForeColor = Color.Red
                    'LI.BackColor = Color.LightGoldenrodYellow
                    LI.ToolTipText = "NoShow! Reschedule! Patient's profile more then 30 days old."
                End If
            End If
        Loop
        Dim LIs = ListViewSchedule.FindItemWithText(SaveText)
        If Not LIs Is Nothing Then
            LIs.Selected = True
            LIs.EnsureVisible()
        Else
            If ListViewSchedule.Items.Count > 0 Then
                ListViewSchedule.Items(0).Selected = True
                ListViewSchedule.Items(0).EnsureVisible()
            End If
        End If

ExitSub:
        'ListViewSchedule.ResumeLayout()
        ListViewSchedule.EndUpdate()
        'ListViewSchedule.ResumeLayout(True)
    End Sub

    Private Sub Load_NF2()
        Dim LI As ListViewItem
        Dim Reader As SqlDataReader
        Dim SQL As String
        Dim R As Integer
        Dim PatientID As Long
        Dim tMSG As String
        If exitflag Then Return
        If gOfficeTypeID = 1 Or gOfficeTypeID = 3 Then
            ListViewNF2.Items.Clear()
            Exit Sub
        End If

        If ListViewNF2.SelectedItems.Count > 0 Then
            PatientID = ListViewNF2.SelectedItems(0).Tag
        End If
        ListViewNF2.BeginUpdate()
        ListViewNF2.Items.Clear()
        SQL =
            "SELECT     PatientID,  FName + ' ' + LName AS PName, DOA, InsuranceCompanyID, ClaimAddressID, PolicyNumber FROM  Patients "

        SQL &= " WHERE    OfficeID = " & gOfficeID & " AND NF2Date IS NULL "
        SQL &= " AND DOA <= '" & DateAdd(DateInterval.Day, -gNF2MinAge, Now.Date).ToString("MM/dd/yyyy 23:59") & "' "
        'SQL &= " AND DOA >= '" & DateAdd(DateInterval.Day, -gNF2MaxAge, Now.Date).ToString("MM/dd/yyyy 00:00") & "') "
        SQL &= " ORDER BY DOA"
        If exitflag Then Return
        Reader = gSQLGetDataReader(SQL)
        If exitflag Then Return
        If Reader Is Nothing Then Exit Sub

        Do Until Reader.Read = False
            If exitflag Then Return
            If _
                Val(Reader("InsuranceCompanyID").ToString) = 0 Or Val(Reader("ClaimAddressID").ToString) = 0 Or
                Reader("DOA").ToString = "" Or Reader("PolicyNumber").ToString = "" Then
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

            If _
                CDate(Reader("DOA").ToString) <
                DateAdd(DateInterval.Day, -gNF2MaxAge, Now.Date).ToString("MM/dd/yyyy 00:00") Then
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
        Dim Reader As SqlDataReader
        Dim SQL As String
        Dim R As Integer
        Dim SaverequestID As Long
        If exitflag Then Return
        If ListViewRequests.SelectedItems.Count > 0 Then
            SaverequestID = ListViewRequests.SelectedItems(0).Tag
        End If

        SQL =
            "SELECT Priority, RequestID, RequestDescription, RequestDate FROM BillingRequests inner join Patients on BillingRequests.PatientID = Patients.PatientID  Where RequestStatusID < 3 and ResponsibleEmpID = " &
            gCurrentEmployee.EmpID
        SQL &= " AND  Patients.OfficeID = " & gOfficeID & " "
        SQL &= " AND  Patients.CaseStatusID <> 3 and CaseStatusID<>5 "
        SQL &= " order by Priority, RequestDate desc"
        If exitflag Then Return
        Reader = gSQLGetDataReader(SQL)
        If exitflag Then Return
        ListViewRequests.BeginUpdate()
        ListViewRequests.Items.Clear()

        If Reader Is Nothing Then GoTo ExitSub

        Do Until Reader.Read = False
            If exitflag Then Return
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

        LI = Nothing
        If ListViewRequests.Items.Count > 0 Then
            For Each LI In ListViewRequests.Items
                If LI.Tag = SaverequestID Then
                    LI.Selected = True
                    LI.EnsureVisible()
                End If
            Next
            If ListViewRequests.SelectedItems.Count = 0 Then
                ListViewRequests.Items(0).Selected = True
                ListViewRequests.Items(0).EnsureVisible()
            End If

        End If
ExitSub:
        ListViewRequests.EndUpdate()
    End Sub

    Private Sub Load_Bills()
        Dim SQL As String =
                "SELECT Bills.BillID, BillStatus.Description AS Status, Bills.BillStatusID FROM Bills INNER JOIN BillStatus ON Bills.BillStatusID = BillStatus.BillStatusID WHERE Bills.BillStatusID = 1 and OfficeID=" &
                gOfficeID & " "
        Dim LI As ListViewItem
        Dim Reader As SqlDataReader
        Dim SaveText = ""
        If exitflag Then Return
        Reader = gSQLGetDataReader(SQL)
        If exitflag Then Return
        If ListViewBills.SelectedItems.Count > 0 Then SaveText = ListViewBills.SelectedItems(0).Text
        ListViewBills.BeginUpdate()
        ListViewBills.Items.Clear()
        If Reader Is Nothing Then GoTo ExitSub
        Do Until Reader.Read = False
            If exitflag Then Return
            LI = ListViewBills.Items.Add(Reader("BillID").ToString)
            LI.Tag = Reader("BillID").ToString
            LI.SubItems.Add(Reader("Status").ToString)
        Loop
        If exitflag Then Return
        Dim LIs = ListViewBills.FindItemWithText(SaveText)
        If Not LIs Is Nothing Then
            LIs.Selected = True
            LIs.EnsureVisible()
        Else
            If ListViewBills.Items.Count > 0 Then
                ListViewBills.Items(0).Selected = True
            End If
        End If

ExitSub:
        ListViewBills.EndUpdate()
    End Sub

    Private Sub TimerReminderReset_Tick(sender As Object, e As EventArgs) Handles TimerReminderReset.Tick
        If exitflag Then Return
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
        ListViewRequestsDetails.Items(8).SubItems(1).Text = ""
        ListViewRequestsDetails.Items(9).SubItems(1).Text = ""
    End Sub

    Private Sub ImageDisksProcessScanPOMToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles ImageDisksProcessScanPOMToolStripMenuItem.Click
        Dim Ret As Boolean
        Application.DoEvents()
        If gScannerMode = 1 Then
            Ret = ScanDocumentFromScannerApplication(18)
        Else
            Ret = ScanDocumentFromScanner(18)
        End If
    End Sub

    Private Sub ListViewRequests_DoubleClick(sender As Object, e As EventArgs) Handles ListViewRequests.DoubleClick
        If ListViewRequests.SelectedItems.Count = 0 Then Exit Sub
        ToolStripButton7_Click(Nothing, Nothing)
    End Sub

    Private Sub ListViewRequests_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles ListViewRequests.SelectedIndexChanged
        gHighlightListviewItem(ListViewRequests)
        If ListViewRequests.SelectedItems.Count = 0 Then
            Clear_Request_Details()
            Exit Sub
        End If

        Dim Reader As SqlDataReader
        Dim SQL As String
        Dim R As Integer
        Dim LI As ListViewItem
        Clear_Request_Details()
        SQL =
            "SELECT  Bills.ServiceFrom, Bills.ServiceTo,  BillingRequests.RequestTypeID, BillingRequests.RequestID, BillingRequests.BillID, BillingRequests.PatientID, BillingRequests.RequestDescription, BillingRequests.RequestFrom,  BillingRequests.ResponsibleEmpID, BillingRequests.RequestDate, BillingRequests.RequestStatusID, BillingRequests.StatusDate, BillingRequests.CDProcedures, BillingRequestStatuses.Description AS Status, Patients.FName + ' ' + Patients.MI + ' ' + Patients.LName AS pName "
        SQL &=
            " FROM         BillingRequests INNER JOIN BillingRequestStatuses ON BillingRequests.RequestStatusID = BillingRequestStatuses.StatusID INNER JOIN Patients ON BillingRequests.PatientID = Patients.PatientID LEFT OUTER JOIN Bills on BillingRequests.BillID=Bills.BillID "
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
            ListViewRequestsDetails.Items(5).SubItems(1).Text = FormatDateTime(Reader("RequestDate").ToString,
                                                                               DateFormat.ShortDate)
            ListViewRequestsDetails.Items(6).SubItems(1).Text = Reader("Status").ToString
            ListViewRequestsDetails.Items(6).SubItems(1).Tag = Reader("RequestStatusID").ToString
            ListViewRequestsDetails.Items(7).SubItems(1).Text = FormatDateTime(Reader("StatusDate").ToString,
                                                                               DateFormat.ShortDate)
            ListViewRequestsDetails.Items(8).SubItems(1).Text = Reader("CDProcedures").ToString
            If IsDate(Reader("ServiceFrom")) Then
                ListViewRequestsDetails.Items(9).SubItems(1).Text = CDate(Reader("ServiceFrom")).ToString("MM/dd/yy")
            End If
            If IsDate(Reader("ServiceTo")) Then
                ListViewRequestsDetails.Items(9).SubItems(1).Text &= " - " &
                                                                     CDate(Reader("ServiceTo")).ToString("MM/dd/yy")
            End If

        End If
        SQL =
            "SELECT Fname+' '+Lname as EmpName, RequestActionID, RequestID, Description, RequestActionDate FROM BillingRequestActions inner join Employees on BillingRequestActions.CreatedBy = Employees.EmpID where RequestID = " &
            Val(ListViewRequests.SelectedItems(0).Tag)

        Reader = gSQLGetDataReader(SQL)
        ListViewrequestActions.Items.Clear()
        If Reader Is Nothing Then Exit Sub
        If Reader.HasRows Then
            Do Until Reader.Read = False
                LI = ListViewrequestActions.Items.Add(FormatDateTime(Reader("RequestActionDate").ToString,
                                                                     DateFormat.ShortDate))
                LI.Tag = Reader("RequestActionID").ToString
                LI.SubItems.Add(Reader("Description").ToString)
                LI.SubItems(1).Tag = Reader("EmpName").ToString

                LI.ToolTipText = Reader("Description").ToString
            Loop
        End If
    End Sub

    Private Sub ToolStripMenuItemRequestsMaintenance_Click(sender As Object, e As EventArgs) _
        Handles ToolStripMenuItemRequestsMaintenance.Click
        Using frm As frmBillingRequests = New frmBillingRequests
            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Sub ButtonInsuranceMainenance_Click(sender As Object, e As EventArgs) _
        Handles ButtonInsuranceMainenance.Click

        Application.DoEvents()
        ButtonFocus.Focus()
        Application.DoEvents()
        Application.DoEvents()
        InsurancesMaintenanceToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub DiagnosticsMaintenanceToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles DiagnosticsMaintenanceToolStripMenuItem.Click
        Application.DoEvents()
        Using frm As frmDiagnosticMaintenance = New frmDiagnosticMaintenance
            frm.ShowDialog()
            frm.Dispose()
        End Using
    End Sub

    Private RedBallFlashCount As Integer

    Private Sub TimerFlashRedBall_Tick(sender As Object, e As EventArgs) Handles TimerFlashRedBall.Tick
        If exitflag Then Return
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

    Private Sub AnnouncementsToolStripMenuItem_Click_1(sender As Object, e As EventArgs) _
        Handles AnnouncementsToolStripMenuItem.Click
        Application.DoEvents()
        Using frm As frmAnnouncement = New frmAnnouncement
            frm.MinimizeBox = False
            frm.MaximizeBox = False

            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Sub ToolStripMenuItemLetterHead_Click(sender As Object, e As EventArgs) _
        Handles ToolStripMenuItemLetterHead.Click
        Application.DoEvents()
        Using frm As frmLetterHead = New frmLetterHead
            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Sub FindCheckToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles FindCheckToolStripMenuItem.Click
        Application.DoEvents()
        frmFindCheck.Show(Me)
    End Sub

    Private Sub Process_Database()
        gSQLUpdateData("exec CleanDocuments_Delete_InsInfo")
    End Sub

    Private Sub DatabaseProcesses()
        Dim t As New Thread(AddressOf Process_Database)
        t.IsBackground = True
        t.Start()
        t = Nothing
        t = New Thread(AddressOf Track_Noshows)
        t.IsBackground = True
        t.Start()
    End Sub

    Private Sub ToolStripMenuItemTodayPayments_Click(sender As Object, e As EventArgs) _
        Handles ToolStripMenuItemTodayPayments.Click
        Application.DoEvents()
        Using frm As frmBillingTodayPayments = New frmBillingTodayPayments
            frm.ShowDialog()
            frm.Dispose()
        End Using
    End Sub

    Private Sub ReferringOfficesMaintenanceToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles ReferringOfficesMaintenanceToolStripMenuItem.Click
        Application.DoEvents()
        Using frm As frmReferringOfficesMaintenance = New frmReferringOfficesMaintenance
            frm.ShowDialog()
            frm.Dispose()
        End Using
    End Sub

    Private Sub OfficesMaintenanceToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles OfficesMaintenanceToolStripMenuItem.Click
        Application.DoEvents()
        Using frm = New frmOfficeMaintenance
            frm.ShowDialog()
            frm.Dispose()
        End Using
        ToolStripMenuItemCariskPayersMaintenance.Visible = gEnableElectronicBillFiling
        If gRestart = True And gDebugMode = False Then
            MsgBox("In order to apply changes to the office settings, eMedical Office should be restarted.",
                   MsgBoxStyle.Exclamation)
            Close()
            If FormsCollection.Forms.Count = 0 Then
                Application.Restart()
            Else
                MsgBox(
                    "Unable to restart eMedical Office automatially." & vbCrLf & vbCrLf &
                    "Please save all unsaved data and restart  eMedical Office manually.", MsgBoxStyle.Critical)
            End If
        End If
    End Sub

    Private Sub ToolStripBillingPaymentManagementReport_Click(sender As Object, e As EventArgs) _
        Handles ToolStripBillingPaymentManagementReport.Click
        Application.DoEvents()
        frmBillingPaymentsReport.MdiParent = Me
        frmBillingPaymentsReport.WindowState = FormWindowState.Maximized
        Application.DoEvents()
        frmBillingPaymentsReport.Show()
        frmBillingPaymentsReport.BringToFront()
        frmBillingPaymentsReport.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ListViewNF2_DoubleClick(sender As Object, e As EventArgs) Handles ListViewNF2.DoubleClick
        LastSelectedListView = ListViewNF2
        ToolStripButton3_Click(Nothing, Nothing)
    End Sub

    Private Sub ListViewNF2_ItemChecked(sender As Object, e As ItemCheckedEventArgs) Handles ListViewNF2.ItemChecked
        If SkeepChecked = True Then Exit Sub
        If e.Item.Checked Then
            If e.Item.ImageIndex = 2 Then
                e.Item.Checked = False
            End If

        End If
    End Sub

    Private Sub ListViewNF2_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles ListViewNF2.SelectedIndexChanged
        gHighlightListviewItem(ListViewNF2, True)
    End Sub

    Private Sub ListViewBills_DoubleClick(sender As Object, e As EventArgs) Handles ListViewBills.DoubleClick
        ToolStripMenuItem18_Click(Nothing, Nothing)
    End Sub

    Private Sub ListViewBills_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles ListViewBills.SelectedIndexChanged
        gHighlightListviewItem(ListViewBills)
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles SelectAllToolStripMenuItem.Click
        Dim LI As ListViewItem
        ListViewNF2.BeginUpdate()
        For Each LI In ListViewNF2.Items
            LI.Checked = True
        Next
        ListViewNF2.EndUpdate()
    End Sub

    Private Sub SelectNoneToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles SelectNoneToolStripMenuItem.Click
        Dim LI As ListViewItem
        ListViewNF2.BeginUpdate()
        For Each LI In ListViewNF2.Items
            LI.Checked = False
        Next
        ListViewNF2.EndUpdate()
    End Sub

    Private Sub mnuShowSelectedPatientInfo1_Click(sender As Object, e As EventArgs) _
        Handles mnuShowSelectedPatientInfo1.Click
        ToolStripButton3_Click(Nothing, Nothing)
    End Sub

    Private Sub CheckBoxDoNotShowRequests_CheckedChanged(sender As Object, e As EventArgs) _
        Handles CheckBoxDoNotShowRequests.CheckedChanged
        Application.DoEvents()
        If CheckBoxDoNotShowRequests.Checked Then
            PanelRequests.Visible = False
            ShowRequestsToolStripMenuItem.Checked = False
        End If
    End Sub

    Private Sub CheckBoxDoNotShowBills_CheckedChanged(sender As Object, e As EventArgs) _
        Handles CheckBoxDoNotShowBills.CheckedChanged
        Application.DoEvents()
        If CheckBoxDoNotShowBills.Checked = True Then
            PanelBills.Visible = False
            ShowNotificationsToolStripMenuItem.Checked = False
        End If
    End Sub

    Private Sub ShowNotificationsToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles ShowNotificationsToolStripMenuItem.Click
        Application.DoEvents()
        If ShowNotificationsToolStripMenuItem.Checked Then
            CheckBoxDoNotShowBills.Checked = False
            TimerRefresh_Tick(Nothing, Nothing)
        Else
            CheckBoxDoNotShowBills.Checked = True
            PanelBills.Visible = False
        End If
    End Sub

    Private Sub ShowRequestsToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles ShowRequestsToolStripMenuItem.Click
        Application.DoEvents()
        If ShowRequestsToolStripMenuItem.Checked Then
            CheckBoxDoNotShowRequests.Checked = False
            TimerRefresh_Tick(Nothing, Nothing)
        Else
            CheckBoxDoNotShowRequests.Checked = True
            PanelRequests.Visible = False
        End If
    End Sub

    Private Sub ToolStripMenuItem10_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem10.Click
        Application.DoEvents()
        ButtonBillMaintenance_Click(Nothing, Nothing)
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Dim LI As ListViewItem
        If ListViewNF2.SelectedItems.Count = 0 Then
            MsgBox("Unable to open patient's information. No record selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        LI = ListViewNF2.SelectedItems(0)
        Application.DoEvents()
        Using newfrm As New frmPatient

            newfrm.MinimizeBox = False
            newfrm.InitialTab = 0
            newfrm.InitialPatientName = LI.Text
            newfrm.MinimizeBox = False
            newfrm.MaximizeBox = False
            newfrm.ShowDialog(Me)
        End Using
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

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        If ListViewRequests.SelectedItems.Count = 0 Then
            MsgBox("Unable to show the patient's informatioln. No Request Selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If Val(ListViewRequestsDetails.Items(0).SubItems(1).Text) = 0 Then
            MsgBox("Unable to show the patient's informatioln. No Request Selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Application.DoEvents()
        Using NewFrm As New frmPatient
            NewFrm.Width = 1225
            NewFrm.WindowState = FormWindowState.Normal
            NewFrm.Location = New Point(Left + ((Width - frmPatient.Size.Width) \ 2),
                                        Top + ((Height - frmPatient.Size.Height) \ 2))
            NewFrm.InitialTab = 0
            'frmPatient.InitialPatientName = LI.SubItems(1).Text
            NewFrm.InitialPatientName = Val(ListViewRequestsDetails.Items(0).SubItems(1).Text)
            NewFrm.InitialEdit = False
            NewFrm.MinimizeBox = False
            NewFrm.MaximizeBox = False
            NewFrm.ShowDialog(Me)
            NewFrm.Dispose()
        End Using
        'Dim frm As Form = FormsCollection.FindForm("frmPatient")
        'If Not frm Is Nothing Then
        '    'MsgBox("The Patient's information window is already opened." & vbCrLf & vbCrLf & "Please close the previous patient information window before opening a new one.", MsgBoxStyle.Exclamation)
        '    'frm.WindowState = FormWindowState.Normal
        '    'frm.BringToFront()
        '    'Exit Sub

        'Else

        '    frmPatient.Width = 1225
        '    frmPatient.WindowState = FormWindowState.Normal
        '    frmPatient.Location = New Point(Left + ((Width - frmPatient.Size.Width) \ 2), Top + ((Height - frmPatient.Size.Height) \ 2))
        '    frmPatient.InitialTab = 0
        '    'frmPatient.InitialPatientName = LI.SubItems(1).Text
        '    frmPatient.InitialPatientName = Val(ListViewRequestsDetails.Items(0).SubItems(1).Text)
        '    frmPatient.InitialEdit = False
        '    frmPatient.ShowDialog(Me)
        '    frmPatient.Dispose()
        'End If
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
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
        Using frm As frmReminder = New frmReminder

            frm.RequestTypeID = Val(ListViewRequestsDetails.Items(3).SubItems(1).Tag)
            frm.PatientID = Val(ListViewRequestsDetails.Items(0).SubItems(1).Text)
            frm.RequestID = Val(ListViewRequestsDetails.Items(0).SubItems(1).Tag)
            frm.txtPatientInfo.Text = ListViewRequestsDetails.Items(1).SubItems(1).Text
            frm.txtRequest.Text = ListViewRequestsDetails.Items(3).SubItems(1).Text
            frm.txtBillID.Text = ListViewRequestsDetails.Items(2).SubItems(1).Text
            frm.lblRequestAge.Text = DateDiff(DateInterval.Day, CDate(ListViewRequests.SelectedItems(0).Text), Now)
            frm.Load_Statuses()
            gFindComboItemByValue(frm.ComboBoxStatus, Val(ListViewRequestsDetails.Items(6).SubItems(1).Tag), True)
            Select Case Val(frm.lblRequestAge.Text)
                Case 0
                    frm.lblRequestAge.Text = "CREATED TODAY"
                Case 1
                    frm.lblRequestAge.Text = "CREATED " & frm.lblRequestAge.Text & " AGO"
                Case 2
                    frm.lblRequestAge.Text = "CREATED " & frm.lblRequestAge.Text & " AGO"
                Case Else
                    frm.lblRequestAge.Text = "ATTENTION! CREATED " & frm.lblRequestAge.Text & " AGO"
                    frm.lblRequestAge.ForeColor = Color.Red
            End Select
            For Each Li In ListViewrequestActions.Items
                NewLi = frm.ListViewrequestActions.Items.Add(Li.Text)
                NewLi.SubItems.Add(Li.SubItems(1))
                NewLi.SubItems.Add(Li.SubItems(1).Tag)
                NewLi.Tag = Li.Tag
            Next
            frm.ActionsCount = ListViewrequestActions.Items.Count
            frm.RequestStatus = Val(ListViewRequestsDetails.Items(6).SubItems(1).Tag)
            frm.MinimizeBox = False
            frm.MaximizeBox = False

            If frm.ShowDialog(Me) = DialogResult.OK Then
                ListViewRequests_SelectedIndexChanged(Nothing, Nothing)
            End If
            frm.Dispose()
        End Using
        ListViewRequests.Focus()
        StopTimers(False)
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Application.DoEvents()
        frmBillingManagement.PreselectStatus = 1
        frmBillingManagement.MdiParent = Me
        'frmBillingManagement.Size = New Size(Width, Height)
        frmBillingManagement.WindowState = FormWindowState.Maximized
        Application.DoEvents()
        frmBillingManagement.Show()
        frmBillingManagement.BringToFront()
        frmBillingManagement.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem7.Click
        Application.DoEvents()
        Using frm As frmImageDiskPOM = New frmImageDiskPOM

            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Sub ChangeRefferingDoctorToolStripMenuItem_Click_1(sender As Object, e As EventArgs) _
        Handles ChangeRefferingDoctorToolStripMenuItem.Click
        Application.DoEvents()
        Using frm As frmPatientRefferingDoctor = New frmPatientRefferingDoctor()

            frm.MinimizeBox = False
            frm.MaximizeBox = False

            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Sub ChangeTreatingProviderToolStripMenuItem_Click_1(sender As Object, e As EventArgs) _
        Handles ChangeTreatingProviderToolStripMenuItem.Click
        Application.DoEvents()
        Using frm As frmPatientTreatingProvider = New frmPatientTreatingProvider()
            frm.MinimizeBox = False
            frm.MaximizeBox = False

            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Sub ChangeBillingProviderToolStripMenuItem_Click_1(sender As Object, e As EventArgs) _
        Handles ChangeBillingProviderToolStripMenuItem.Click
        Application.DoEvents()
        Using frm As frmPatientBillingProvider = New frmPatientBillingProvider()
            frm.MinimizeBox = False
            frm.MaximizeBox = False

            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Sub ToolStripMenuItem6_Click_1(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click
        Application.DoEvents()
        Using frm As frmPatientProceduresSwitchSchedule = New frmPatientProceduresSwitchSchedule()

            frm.MinimizeBox = False
            frm.MaximizeBox = False

            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Sub PatientProcedureInformationToolStripMenuItem_Click_1(sender As Object, e As EventArgs) _
        Handles PatientProcedureInformationToolStripMenuItem.Click
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

    Private Sub mnuEmployeeMaintenance_Click(sender As Object, e As EventArgs) Handles mnuEmployeeMaintenance.Click
        Application.DoEvents()
        On Error Resume Next
        Using frm As frmEmployeeMaintenance = New frmEmployeeMaintenance()
            frm.ShowDialog()
            frm.Dispose()
        End Using
    End Sub

    Private Sub ButtonPatSearchAndTools_Click(sender As Object, e As EventArgs) Handles ButtonPatSearchAndTools.Click

        Application.DoEvents()
        PanelButtonsBack.UseWaitCursor = True
        ButtonPatSearchAndTools.Enabled = False
        ButtonFocus.Focus()
        Application.DoEvents()
        PatientsSearchToolsToolStripMenuItem_Click(Nothing, Nothing)
        PanelButtonsBack.UseWaitCursor = False
        ButtonPatSearchAndTools.Enabled = True
        Application.DoEvents()
    End Sub

    Private Sub PatientsSearchToolsToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles PatientsSearchToolsToolStripMenuItem.Click
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

    Private Sub LogOffToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOffToolStripMenuItem.Click
        Dim i As Double
        Application.DoEvents()
        My.Computer.Audio.Play(My.Resources.Lock, AudioPlayMode.Background)
        Close()
        If FormsCollection.Forms.Count = 0 Then
            Application.Restart()
        End If
    End Sub

    Private Sub ToolStripMenuItem9_Click_1(sender As Object, e As EventArgs) Handles ToolStripMenuItem9.Click
        Application.DoEvents()
        Using frm As frmPatientMissingInformation = New frmPatientMissingInformation()
            frm.ShowDialog()
            frm.Dispose()
        End Using
    End Sub

    Private Sub ButtonAbout_Click(sender As Object, e As EventArgs) Handles ButtonAbout.Click

        Application.DoEvents()
        ButtonFocus.Focus()
        Application.DoEvents()
        My.Computer.Audio.Play(My.Resources.WakeUp, AudioPlayMode.Background)
        Using frm As frmAboutBox = New frmAboutBox()
            frm.ShowDialog()
            frm.Dispose()
        End Using
    End Sub

    Private Sub ToolTip_MouseEnter(sender As Object, e As EventArgs) _
        Handles ButtonSchedule.MouseEnter, ButtonPatientProfile.MouseEnter, ButtonIntakeForm.MouseEnter,
                ButtonMessaging.MouseEnter, ButtonPatSearchAndTools.MouseEnter, ButtonSearch.MouseEnter,
                ButtonInsuranceMainenance.MouseEnter, ButtonBilling.MouseEnter, ButtonBillMaintenance.MouseEnter,
                ButtonCollection.MouseEnter, ButtonAbout.MouseEnter
        If sender.name = "ButtonAbout" Then
            If lblStatus.Text <> "   About" Then lblStatus.Text = "   About"
            Exit Sub
        End If

        If lblStatus.Text <> "   " & sender.tag Then lblStatus.Text = "   " & sender.tag
    End Sub

    Private Sub ToolTip_MouseLeave(sender As Object, e As EventArgs) _
        Handles ButtonSchedule.MouseLeave, ButtonPatientProfile.MouseLeave, ButtonIntakeForm.MouseLeave,
                ButtonMessaging.MouseLeave, ButtonPatSearchAndTools.MouseLeave, ButtonSearch.MouseLeave,
                ButtonInsuranceMainenance.MouseLeave, ButtonBilling.MouseLeave, ButtonBillMaintenance.MouseLeave,
                ButtonCollection.MouseLeave, ButtonAbout.MouseLeave
        If lblStatus.Text <> "" Then lblStatus.Text = ""
    End Sub

    Private Sub TreatmentStatisticReport_Click(sender As Object, e As EventArgs) Handles TreatmentStatisticReport.Click
        Application.DoEvents()
        'frmPatientVisits.MdiParent = Me
        ''frmSchedulePTFrontDesk.Size = New Size(Width, Height)
        'frmPatientVisits.WindowState = FormWindowState.Normal
        'Application.DoEvents()
        'frmPatientVisits.Show()
        'frmPatientVisits.BringToFront()
        'frmPatientVisits.WindowState = FormWindowState.Normal

        ''frmPatientTreatmentStatistic.ShowDialog()
        ''frmPatientTreatmentStatistic.Dispose()
        PanelButtonsBack.UseWaitCursor = True
        ButtonPatientProfile.Enabled = False

        ButtonFocus.Focus()
        Application.DoEvents()
        Dim frm As Form = FormsCollection.FindForm("frmPatientProceduresStatistic")
        If Not frm Is Nothing Then
            frm.WindowState = FormWindowState.Normal
            frm.Visible = True
            frmPatientProceduresStatistic.Show()
            frm.BringToFront()
        Else
            'frmPatientProceduresStatistic.Width = 1225
            'frmPatientProceduresStatistic.WindowState = FormWindowState.Normal
            'frmPatientProceduresStatistic.Location = New Point(Left + ((Width - frmPatientProceduresStatistic.Size.Width) \ 2), Top + ((Height - frmPatientProceduresStatistic.Size.Height) \ 2))
            frmPatientProceduresStatistic.MdiParent = Me
            gWindow_Settings(frmPatientProceduresStatistic, ReadWrite.sRead)
            frmPatientProceduresStatistic.Show()
            frmPatientProceduresStatistic.BringToFront()
        End If
        'Cursor = Cursors.WaitCursor
        PanelButtonsBack.UseWaitCursor = False
        ButtonPatientProfile.Enabled = True
    End Sub

    Private Sub PrintTodaysScheduleToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles PrintTodaysScheduleToolStripMenuItem.Click
        Application.DoEvents()
        Using frm As frmReportSchedule = New frmReportSchedule()

            frm.ByPatient = True
            frm.ScheduleDate = Now.Date
            frm.MinimizeBox = False
            frm.MaximizeBox = False

            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles ShowToBeScheduled.CheckedChanged
        Application.DoEvents()
        If ShowToBeScheduled.Checked = True Then
            PanelSchedule.Visible = False
            ToolStripMenuItemToBeScheduled.Checked = False
        End If
    End Sub

    Private Sub ToolStripMenuItemToBeScheduled_Click(sender As Object, e As EventArgs) _
        Handles ToolStripMenuItemToBeScheduled.Click
        Application.DoEvents()
        If ToolStripMenuItemToBeScheduled.Checked Then
            ShowToBeScheduled.Checked = False
            TimerRefresh_Tick(Nothing, Nothing)
        Else
            ShowToBeScheduled.Checked = True
            PanelSchedule.Visible = False
        End If
    End Sub

    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim LI As ListViewItem
        Dim LV As ListView
        If LastSelectedListView Is ListViewSchedule Then
            LV = ListViewSchedule
        Else
            MsgBox("Unable to open patient's information. No record selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If LV.SelectedItems.Count = 0 Then
            MsgBox("Unable to open patient's information. No record selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        LI = LV.SelectedItems(0)
        Application.DoEvents()
        Using NewFrm As New frmPatient

            NewFrm.InitialTab = 0
            NewFrm.InitialPatientName = LI.Tag
            Cursor = Cursors.Default
            NewFrm.MinimizeBox = False
            NewFrm.MaximizeBox = False
            NewFrm.ShowDialog(Me)
        End Using
        'Dim frm As Form = FormsCollection.FindForm("frmPatient")
        'If Not frm Is Nothing Then
        '    Dim NewFrm As New frmPatient
        '    NewFrm.InitialTab = 0
        '    NewFrm.InitialPatientName = LI.Tag
        '    Cursor = Cursors.Default
        '    NewFrm.ShowDialog(Me)

        '    'MsgBox("The Patient's information window is already opened." & vbCrLf & vbCrLf & "Please close the previous patient information window before opening a new one.", MsgBoxStyle.Exclamation)
        '    'If frm.WindowState = FormWindowState.Minimized Then frm.WindowState = FormWindowState.Normal
        '    'frm.BringToFront()
        '    'Cursor = Cursors.Default
        '    'Exit Sub
        'Else
        '    frmPatient.InitialTab = 0
        '    frmPatient.InitialPatientName = LI.Tag
        '    Cursor = Cursors.Default
        '    frmPatient.ShowDialog(Me)
        'End If
    End Sub

    Private Sub ListViewSchedule_DoubleClick(sender As Object, e As EventArgs) Handles ListViewSchedule.DoubleClick
        LastSelectedListView = ListViewSchedule
        ToolStripButton1_Click_1(Nothing, Nothing)
    End Sub

    Private LastSelectedListView As ListView

    Private Sub ListViewSchedule_GotFocus(sender As Object, e As EventArgs) Handles ListViewSchedule.GotFocus
        LastSelectedListView = ListViewSchedule
    End Sub

    Private Sub ListViewSchedule_ItemActivate(sender As Object, e As EventArgs) Handles ListViewSchedule.ItemActivate
    End Sub

    Private Sub ListViewSchedule_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles ListViewSchedule.SelectedIndexChanged
        gHighlightListviewItem(ListViewSchedule, True)
    End Sub

    Private Sub ListViewSchedule_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles ListViewSchedule.ColumnClick
        Dim new_sorting_column As ColumnHeader = ListViewSchedule.Columns(e.Column)
        Dim sort_order As SortOrder
        If m_SortingColumnSchedule Is Nothing Then
            sort_order = SortOrder.Ascending
        Else
            If new_sorting_column.Equals(m_SortingColumnSchedule) Then
                If m_SortingColumnSchedule.ImageKey = "SORT1" Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                sort_order = SortOrder.Ascending
            End If
            m_SortingColumnSchedule.ImageKey = "SORT0"
        End If

        m_SortingColumnSchedule = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            m_SortingColumnSchedule.ImageKey = "SORT1"
        Else
            m_SortingColumnSchedule.ImageKey = "SORT2"
        End If

        ListViewSchedule.ListViewItemSorter = New ListViewComparer(e.Column, sort_order)
        ListViewSchedule.Sort()
    End Sub

    Private Sub ToolStripMenuItem12_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem12.Click
        Application.DoEvents()
        If gOfficeTypeID = 1 Or gOfficeTypeID = 3 Then
            Using frm As frmToBeScheduledReport = New frmToBeScheduledReport()

                frm.MinimizeBox = False
                frm.MaximizeBox = False

                frm.ShowDialog(Me)
                frm.Dispose()
            End Using
        Else
            Using frm As frmPatientIMEEUOReport = New frmPatientIMEEUOReport

                frm.MinimizeBox = False
                frm.MaximizeBox = False

                frm.ShowDialog(Me)
                frm.Dispose()
            End Using
        End If
    End Sub

    Private Sub TimerAutoUpdate_Tick(sender As Object, e As EventArgs) Handles TimerAutoUpdate.Tick
        If exitflag Then Return
        gProcessAutoUpdate(True, False)
    End Sub

    Private Sub ListViewEUOIME_DoubleClick(sender As Object, e As EventArgs)
        ToolStripButton1_Click_1(Nothing, Nothing)
    End Sub



    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click

        ToolStripMenuItem12_Click(Nothing, Nothing)
    End Sub

    Private Sub ListViewEUODetails_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripMenuItemProceduresSchedule_Click(sender As Object, e As EventArgs) _
        Handles ToolStripMenuItemProceduresSchedule.Click
        Using frm As frmDiagSchedule = New frmDiagSchedule()

            frm.MinimizeBox = False
            frm.MaximizeBox = False

            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Sub ToolStripMenuItem14_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem14.Click
        ToolStripButton1_Click_1(Nothing, Nothing)
    End Sub

    Private Sub ContextMenuStripWarning_Opening(sender As Object, e As CancelEventArgs) _
        Handles ContextMenuStripWarning.Opening
        If LastSelectedListView Is ListViewSchedule Then
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub ToolStripMenuItem16_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem16.Click
        ToolStripButton6_Click(Nothing, Nothing)
    End Sub

    Private Sub ToolStripButton10_Click(sender As Object, e As EventArgs) Handles ToolStripButton10.Click
        ToolStripButton7_Click(Nothing, Nothing)
    End Sub

    Private Sub ToolStripMenuItem17_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem17.Click
        Using frm As frmDenialReasonMaintenance = New frmDenialReasonMaintenance()
            frm.MinimizeBox = False
            frm.MaximizeBox = False

            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Sub ToolStripMenuItem18_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem18.Click
        If ListViewBills.SelectedItems.Count = 0 Then Exit Sub
        Application.DoEvents()
        Cursor = Cursors.WaitCursor
        frmBillingManagement.SearchBillID = ListViewBills.SelectedItems(0).Text
        frmBillingManagement.PreselectStatus = 0
        frmBillingManagement.MdiParent = Me
        'frmBillingManagement.Size = New Size(Width, Height)
        frmBillingManagement.WindowState = FormWindowState.Maximized
        Application.DoEvents()
        frmBillingManagement.Show()
        frmBillingManagement.BringToFront()
        frmBillingManagement.WindowState = FormWindowState.Maximized
        frmBillingManagement.ButtonFind_Click(Nothing, Nothing)
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripMenuItem19_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem19.Click
        ToolStripButton2_Click(Nothing, Nothing)
    End Sub

    Private Sub EmailerMaintenanceToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles EmailerMaintenanceToolStripMenuItem.Click
        Using frm = New frmEmailerMaintenance()

            frm.MinimizeBox = False
            frm.MaximizeBox = False

            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Sub EmailerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmailerToolStripMenuItem.Click
        Using frm = New frmMailer()
            frm.MinimizeBox = False
            frm.MaximizeBox = False

            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Sub ToolStripMenuItem20_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem20.Click
        Application.DoEvents()
        Application.DoEvents()
        frmReportReschedulesCancelations.MdiParent = Me
        frmReportReschedulesCancelations.WindowState = FormWindowState.Normal
        Application.DoEvents()
        frmReportReschedulesCancelations.Show()
        frmReportReschedulesCancelations.BringToFront()
        frmReportReschedulesCancelations.WindowState = FormWindowState.Normal
    End Sub

    Private Sub SecuritySettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles SecuritySettingsToolStripMenuItem.Click
        Using frm = New frmSecuritySettings

            frm.MinimizeBox = False
            frm.MaximizeBox = False

            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Sub ResetPatientInformationToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles ResetPatientInformationToolStripMenuItem.Click
        Using frm = New frmResetPatientInformation
            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Sub AdminMessagingToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles AdminMessagingToolStripMenuItem.Click
        'frmMessage.MinimizeBox = False
        'frmMessage.MaximizeBox = False
        ButtonFocus.Focus()
        Application.DoEvents()
        Using frm As frmMessage = New frmMessage
            frm.Width = (Width / 3) * 2
            frm.Height = (Height / 3) * 2
            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Sub AdministrativeToolsToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles AdministrativeToolsToolStripMenuItem.Click
    End Sub

    Private Sub ToolStripMenuItemChangePatientInformation_Click(sender As Object, e As EventArgs) _
        Handles ToolStripMenuItemChangePatientInformation.Click
    End Sub

    Private Sub ToolStripMenuItemChangePatientInformation_DropDownOpening(sender As Object, e As EventArgs) _
        Handles ToolStripMenuItemChangePatientInformation.DropDownOpening
    End Sub

    Private Sub mnuBankDepositsAdmin_Click(sender As Object, e As EventArgs) Handles mnuBankDepositsAdmin.Click
        Using frm = New frmBankDepositsAdmin

            frm.MinimizeBox = False
            frm.MaximizeBox = False

            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Sub ToolStripMenuItem21_Click_1(sender As Object, e As EventArgs) Handles ToolStripMenuItem21.Click
        Using frm As frmAttorneyAssignCaseNumber = New frmAttorneyAssignCaseNumber
            frm.Panel1.BackColor = Color.MistyRose
            frm.Text = "Assign Arbitration / Litigation Attorney Case Number"
            frm.lblMsg.Text = "Assign Arbitration / Litigation Attorney Case Number"
            frm.Arbitration = True
            frm.ArbitrationFieldPrefix = "Arbitration"
            frm.ShowDialog()
            frm.Dispose()
        End Using
    End Sub

    Private Sub ProceduresToBeRescheduledReportToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles ProceduresToBeRescheduledReportToolStripMenuItem.Click
        ToolStripMenuItem12_Click(Nothing, Nothing)
    End Sub

    Private Sub InsuranceVerificationToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles InsuranceVerificationToolStripMenuItem.Click
        Application.DoEvents()
        Application.DoEvents()
        frmVerifyInsurance.MdiParent = Me
        Application.DoEvents()
        frmVerifyInsurance.Show()
        frmVerifyInsurance.BringToFront()
        If frmVerifyInsurance.WindowState = FormWindowState.Minimized Then _
            frmVerifyInsurance.WindowState = FormWindowState.Normal
    End Sub

    Public BillingProviderID As Long

    Private Sub ButtonIntakeForm_Click(sender As Object, e As EventArgs) Handles ButtonIntakeForm.Click
        ButtonFocus.Focus()
        ButtonIntakeForm.Enabled = False
        Application.DoEvents()
        'If MsgBox("Print Intake Form?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
        '    Exit Sub
        'End If
        If Not frmPrinter.IsDisposed Then
            frmPrinter.Close()
            frmPrinter.Dispose()
        End If
        Cursor = Cursors.WaitCursor
        Dim Reader As SqlDataReader
        Dim intCounter As Integer

        Dim ConInfo As New TableLogOnInfo

        BillingProviderID = 0
        Dim CB As New ComboBox
        'frmPrinter.Show(Me)
        Application.DoEvents()
        Reader =
            gSQLGetDataReader(
                "SELECT     Employees.EmpID, Employees.Fname+' '+Employees.Lname+' '+ Employees.Alias +' - '+  Employees.CorporationName as DName, Employees.ReferralColor FROM Employees INNER JOIN EmployeeOffice ON Employees.EmpID = EmployeeOffice.EmpID  WHERE PositionID = 5 AND ActiveInd = 1 AND BillingPrv = 1 AND EmployeeOffice.OfficeID = " &
                gOfficeID)
        If Reader.HasRows = False Then
            MsgBox("Unable to print intake form." & vbCrLf & "No billing provider is set in the current office.",
                   MsgBoxStyle.Critical)
            'frmPrinter.Close()
            'frmPrinter.Dispose()
            Cursor = Cursors.Default
            ButtonIntakeForm.Enabled = True
            Exit Sub
        End If
        Do Until Reader.Read = False
            CB.Items.Add(New ValueDescription(Reader("EmpID").ToString, Reader("DName").ToString,
                                              Reader("ReferralColor").ToString))
            BillingProviderID = Reader("EmpID").ToString
        Loop
        Reader.Close()
        Dim CBItem As Object
        If CB.Items.Count > 1 Then
            Using frm As frmIntakeForm = New frmIntakeForm
                For Each CBItem In CB.Items
                    frm.ComboBoxBillingProvider.Items.Add(CBItem)
                Next
                BillingProviderID = 0
                frm.ComboBoxBillingProvider.SelectedIndex = -1
                frm.Visible = False
                If frm.ShowDialog(Me) <> DialogResult.OK Then
                    frm.Dispose()
                    If frmPrinter.IsDisposed = False Then
                        'frmPrinter.Close()
                        'frmPrinter.Dispose()
                    End If
                    Cursor = Cursors.Default
                    ButtonIntakeForm.Enabled = True
                    Exit Sub
                End If
                frm.Dispose()
            End Using
            Application.DoEvents()
        End If

        Application.DoEvents()
        Application.DoEvents()
        Dim frmintake As frmIntakeFormReport = New frmIntakeFormReport
        frmintake.BillingProviderID = BillingProviderID.ToString
        Application.DoEvents()
        frmintake.MinimizeBox = False
        frmintake.MaximizeBox = False

        frmintake.ShowDialog(Me)
        frmintake.Dispose()

        'Using CR As ReportDocument = New rptChartIntake

        '    If SetupCrystalSecurityInfo(CR) = False Then
        '        If frmPrinter.IsDisposed = False Then
        '            frmPrinter.Close()
        '            frmPrinter.Dispose()
        '        End If
        '        ButtonIntakeForm.Enabled = True
        '        Cursor = Cursors.Default
        '        Exit Sub
        '    End If

        '    CR.SetParameterValue("BillingProviderID", BillingProviderID.ToString)
        '    If gPrinterOtherDocuments <> "" Then CR.PrintOptions.PrinterName = gPrinterOtherDocuments
        '    'CR.PrintOptions.ApplyPageMargins(New PageMargins(0, 0, 0, 0))
        '    Try
        '        CR.PrintToPrinter(1, False, 0, 0)
        '    Catch ex As Exception
        '        frmPrinter.Close()
        '        Cursor = Cursors.Default
        '        ButtonIntakeForm.Enabled = True
        '        If frmPrinter.IsDisposed = False Then
        '            frmPrinter.Close()
        '            frmPrinter.Dispose()
        '        End If
        '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        '        log.Error(
        '            "Printer Settings: Other Documents Default Printer" & vbCrLf & "Printer: " & gPrinterOtherDocuments, ex)
        '        Exit Sub
        '    End Try
        '    CR.Dispose()
        'End Using
        Cursor = Cursors.Default
        'If frmPrinter.IsDisposed = False Then
        '    frmPrinter.Close()
        '    frmPrinter.Dispose()
        'End If
        ButtonIntakeForm.Enabled = True
    End Sub

    Private Sub ShowPrintIntakeFormButtonToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles ShowPrintIntakeFormButtonToolStripMenuItem.Click
        Application.DoEvents()
        If ShowPrintIntakeFormButtonToolStripMenuItem.Checked Then
            ButtonIntakeFormBack.Visible = True
            gShowIntakeFormButton = True
        Else
            ButtonIntakeFormBack.Visible = False
            gShowIntakeFormButton = False
        End If
        SaveSetting(My.Application.Info.ProductName, "Settings", "gShowIntakeFormButton", gShowIntakeFormButton)
    End Sub

    Private Sub PrintPatientIntakeToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles PrintPatientIntakeToolStripMenuItem.Click
        ButtonIntakeForm_Click(Nothing, Nothing)
    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        'ToolStripManager.LoadSettings(Me, "Restore")
        'BackColor = Color.Gainsboro
        'BackColor = Color.FromArgb(69, 69, 69)
        'SetToolBar(ToolStripItemDisplayStyle.Image)
        'SetFormBackcolor()
        If _
            MsgBox("Please confirm you want to restore default Workspace settings?",
                   MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        If gCurrentEmployee.PositionID < 3 Then
            DeleteSetting(My.Application.Info.ProductName, "GUI\")
        Else
            DeleteSetting(My.Application.Info.ProductName, "GUI\USER-" & gCurrentEmployee.EmpID & "\")
        End If

        ShowNotificationsToolStripMenuItem.Checked = True
        ShowRequestsToolStripMenuItem.Checked = True
        ToolStripMenuItemToBeScheduled.Checked = True
        If gOfficeTypeID = 1 Then
            ShowNotificationsToolStripMenuItem.Text = "Show Bills Notifications"
            ShowPrintIntakeFormButtonToolStripMenuItem.Visible = True
            ShowPrintIntakeFormButtonToolStripMenuItem.Checked = gShowIntakeFormButton
            ButtonIntakeFormBack.Visible = gShowIntakeFormButton
        ElseIf gOfficeTypeID = 3 Then
            ShowNotificationsToolStripMenuItem.Text = "Show Bills Notifications"
            PrintPatientIntakeToolStripMenuItem.Visible = False
            ButtonIntakeFormBack.Visible = False
            ShowPrintIntakeFormButtonToolStripMenuItem.Visible = False
            ShowPrintIntakeFormButtonToolStripMenuItem.Checked = False
        Else
            PrintPatientIntakeToolStripMenuItem.Visible = False
            ShowNotificationsToolStripMenuItem.Text = "Show Bills / NF2 Notifications"
            ButtonIntakeFormBack.Visible = False
            ShowPrintIntakeFormButtonToolStripMenuItem.Visible = False
            ShowPrintIntakeFormButtonToolStripMenuItem.Checked = False
        End If
        StatusBarToolStripMenuItem.Checked = True
    End Sub

    Private Sub ToolStripMenuItem23_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem23.Click
        BackColor = ToolStripMenuItem23.BackColor
        SetFormBackcolor()
    End Sub

    Private Sub ToolStripMenuItem24_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem24.Click
        BackColor = ToolStripMenuItem24.BackColor
        SetFormBackcolor()
    End Sub

    Private Sub ToolStripMenuItem25_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem25.Click
        BackColor = ToolStripMenuItem25.BackColor
        SetFormBackcolor()
    End Sub

    Private Sub ToolStripMenuItem26_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem26.Click
        BackColor = ToolStripMenuItem26.BackColor
        SetFormBackcolor()
    End Sub

    Private Sub ToolStripMenuItem27_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem27.Click
        BackColor = ToolStripMenuItem27.BackColor
        SetFormBackcolor()
    End Sub

    Private Sub ToolStripMenuItem28_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem28.Click
        BackColor = ToolStripMenuItem28.BackColor
        SetFormBackcolor()
    End Sub

    Private Sub ToolStripMenuItem29_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem29.Click
        BackColor = ToolStripMenuItem29.BackColor
        SetFormBackcolor()
    End Sub

    Private Sub CustomColorToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles CustomColorToolStripMenuItem.Click
        ColorDialog1.Color = BackColor
        ColorDialog1.AllowFullOpen = True
        ColorDialog1.FullOpen = True
        If ColorDialog1.ShowDialog = DialogResult.OK Then
            BackColor = ColorDialog1.Color
            SetFormBackcolor()
        End If
    End Sub

    Private Sub FindDuplicatePatientsToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles FindDuplicatePatientsToolStripMenuItem.Click
        Application.DoEvents()
        Dim frm As Form = FormsCollection.FindForm("frmPatientsFindDuplicates")
        If Not frm Is Nothing Then
            frm.WindowState = FormWindowState.Normal
            frm.BringToFront()
            Exit Sub
        Else

            frmPatientsFindDuplicates.FormBorderStyle = FormBorderStyle.Sizable
            frmPatientsFindDuplicates.MdiParent = Me
            frmPatientsFindDuplicates.WindowState = FormWindowState.Normal
            frmPatientsFindDuplicates.Show()
            frmPatientsFindDuplicates.BringToFront()
        End If
    End Sub

    Private Sub CourtIndexNumbersFilingDatesMaintenanceToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles CourtIndexNumbersFilingDatesMaintenanceToolStripMenuItem.Click
        Using frm As frmBillingIndexNumber = New frmBillingIndexNumber

            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Sub ToolStripMenuItemReadyForArbitration_Click(sender As Object, e As EventArgs) _
        Handles ToolStripMenuItemReadyForArbitration.Click
        Application.DoEvents()
        Dim frm As Form = FormsCollection.FindForm("frmBillsForArbitration")
        If Not frm Is Nothing Then
            frm.WindowState = FormWindowState.Normal
            frm.BringToFront()
            Exit Sub
        Else

            frmBillsForArbitration.FormBorderStyle = FormBorderStyle.Sizable
            frmBillsForArbitration.MdiParent = Me
            frmBillsForArbitration.WindowState = FormWindowState.Normal
            frmBillsForArbitration.Show()
            frmBillsForArbitration.BringToFront()
        End If
    End Sub

    Private Sub PaymentsProgressAnalysisToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles PaymentsProgressAnalysisToolStripMenuItem.Click
        Using frm As frmPaymentsChart = New frmPaymentsChart

            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Sub ToolStripMenuItem22_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem22.Click
        Using frm As frmAttorneyFees = New frmAttorneyFees

            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    'Private Sub mobjSubclassedSystemMenu_LaunchDialog() Handles mobjSubclassedSystemMenu.LaunchDialog
    '    ToolStripButton9_Click(Nothing, Nothing)
    'End Sub

    Private Sub ButtonCollection_Click(sender As Object, e As EventArgs) Handles ButtonCollection.Click
        Application.DoEvents()
        PanelButtonsBack.UseWaitCursor = True
        ButtonCollection.Enabled = False
        ButtonFocus.Focus()
        Application.DoEvents()
        If frmBillingCollectionInstance Is Nothing OrElse frmBillingCollectionInstance.IsDisposed Then
            frmBillingCollectionInstance = New frmBillingCollection()
            If Screen.AllScreens.Count > 1 Then
                frmBillingCollectionInstance.Loading = True
                frmBillingCollectionInstance.ToolStripButtonDetach.Visible = True
                'If Val(GetSetting(My.Application.Info.ProductName, "GUI\USER-" & gCurrentEmployee.EmpID & "\" & UCase(frmBillingCollectionInstance.Name), "DETACHED", "0")) = 0 Then
                frmBillingCollectionInstance.ToolStripButtonDetach.Image = gDetachAttachWindow(frmBillingCollectionInstance, Me, eAttachDetach.Attach)
                frmBillingCollectionInstance.PanelTop.Visible = False
                'Else
                'frmBillingCollectionInstance.ToolStripButtonDetach.Image = gDetachAttachWindow(frmBillingCollectionInstance, Me, eAttachDetach.Detacvh)
                'frmBillingCollectionInstance.PanelTop.Visible = True
                'End If
            Else
                frmBillingCollectionInstance.Loading = True
                frmBillingCollectionInstance.MdiParent = Me
                frmBillingCollectionInstance.WindowState = FormWindowState.Minimized
                Application.DoEvents()
                frmBillingCollectionInstance.Show()
                frmBillingCollectionInstance.WindowState = FormWindowState.Maximized
                frmBillingCollectionInstance.PanelTop.Visible = False
                frmBillingCollectionInstance.ToolStripButtonDetach.Visible = False
            End If
        End If

        'frmBillingManagement.Size = New Size(Width, Height)
        frmBillingCollectionInstance.WindowState = FormWindowState.Maximized
        Application.DoEvents()
        frmBillingCollectionInstance.Show()
        frmBillingCollectionInstance.BringToFront()
        frmBillingCollectionInstance.WindowState = FormWindowState.Maximized
        PanelButtonsBack.UseWaitCursor = False
        ButtonCollection.Enabled = True

        'Application.DoEvents()
        'PanelButtonsBack.UseWaitCursor = True
        'ButtonCollection.Enabled = False
        'ButtonFocus.Focus()
        'Application.DoEvents()
        'frmBillingCollection.MdiParent = Me
        ''frmBillingManagement.Size = New Size(Width, Height)
        'frmBillingCollection.WindowState = FormWindowState.Maximized
        'Application.DoEvents()
        'frmBillingCollection.Show()
        'frmBillingCollection.BringToFront()
        'frmBillingCollection.WindowState = FormWindowState.Maximized
        'PanelButtonsBack.UseWaitCursor = False
        'ButtonCollection.Enabled = True
    End Sub

    Private Sub ToolStripMenuItemCollection_Click(sender As Object, e As EventArgs) _
        Handles ToolStripMenuItemCollection.Click
        ButtonCollection_Click(Nothing, Nothing)
    End Sub

    Private Sub TimerToolBar_Tick(sender As Object, e As EventArgs) Handles TimerToolBar.Tick
        TimerToolBar.Enabled = False
        Refresh()
        LargeButtonsToolStripMenuItem.Checked = GetSetting(My.Application.Info.ProductName, "Settings",
                                                           Name & "ToolBarLarge", True)
        LargeButtonsToolStripMenuItem_Click(Nothing, Nothing)
        StatusBarToolStripMenuItem.Checked = GetSetting(My.Application.Info.ProductName, "Settings", Name & "StatusBar",
                                                        True)
        StatusStrip.Visible = StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub MDIForm1Win8_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
    End Sub

    Private Sub TimerOpacity_Tick(sender As Object, e As EventArgs) Handles TimerOpacity.Tick
        TimerOpacity.Enabled = False
        Opacity = 1
    End Sub

    Private Sub ButtonMessaging_Click(sender As Object, e As EventArgs) Handles ButtonMessaging.Click

        Application.DoEvents()
        AdminMessagingToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBoxNext.Click
        ShowMessage(True)
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBoxPrevious.Click
        ShowMessage(False)
    End Sub

    Private Sub AcknowledgeMessageToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles AcknowledgeMessageToolStripMenuItem.Click
        PictureBoxClose_Click(Nothing, Nothing)
    End Sub

    Private Sub NextMessageToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles NextMessageToolStripMenuItem.Click
        ShowMessage(True)
    End Sub

    Private Sub PreviousMessageToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles PreviousMessageToolStripMenuItem.Click
        ShowMessage(False)
    End Sub

    Private Sub CopyToClipboardToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles CopyToClipboardToolStripMenuItem.Click
        Clipboard.Clear()
        Clipboard.SetText(lblMessage.Text)
    End Sub

    Private Sub PanelMessage_DoubleClick(sender As Object, e As EventArgs) Handles PanelMessage.DoubleClick
        PictureBoxClose_Click(Nothing, Nothing)
    End Sub

    Private Sub NewPatientsStatisticReportToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles NewPatientsStatisticReportToolStripMenuItem.Click
        Application.DoEvents()
        Using frm As frmPatientsChart = New frmPatientsChart

            frm.ShowDialog()
            frm.Dispose()
        End Using
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles StatusBarToolStripMenuItem.Click
        StatusStrip.Visible = StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub LargeButtonsToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles LargeButtonsToolStripMenuItem.Click
        If LargeButtonsToolStripMenuItem.Checked Then
            ButtonScheduleBack.Height = 77
            PanelButtonsBack.Height = 60
            ButtonSchedule.Image = My.Resources.ButtonSchedule  'ImageListToolBar.Images("ButtonSchedule")
            Application.DoEvents()
            ButtonPatientProfile.Image = My.Resources.ButtonPatientProfile _
            'ImageListToolBar.Images("ButtonPatientProfile")
            Application.DoEvents()
            ButtonIntakeForm.Image = My.Resources.ButtonIntakeForm  'ImageListToolBar.Images("ButtonIntakeForm")
            Application.DoEvents()
            ButtonMessaging.Image = My.Resources.ButtonMessaging  'ImageListToolBar.Images("ButtonMessaging")
            Application.DoEvents()
            ButtonPatSearchAndTools.Image = My.Resources.ButtonPatSearchAndTools _
            'ImageListToolBar.Images("ButtonPatSearchAndTools")
            Application.DoEvents()
            ButtonSearch.Image = My.Resources.ButtonSearch 'ImageListToolBar.Images("ButtonSearch")
            Application.DoEvents()
            ButtonNetSearch.Image = My.Resources.NetSearch 'ImageListToolBar.Images("ButtonSearch")
            Application.DoEvents()
            ButtonInsuranceMainenance.Image = My.Resources.ButtonInsuranceMainenance _
            'ImageListToolBar.Images("ButtonInsuranceMainenance")
            Application.DoEvents()
            ButtonBilling.Image = My.Resources.ButtonBilling 'ImageListToolBar.Images("ButtonBilling")
            Application.DoEvents()
            ButtonBillMaintenance.Image = My.Resources.ButtonBillMaintenance _
            'ImageListToolBar.Images("ButtonBillMaintenance")
            Application.DoEvents()
            ButtonCollection.Image = My.Resources.ButtonCollection  'ImageListToolBar.Images("ButtonCollection")
            Application.DoEvents()
            ButtonNotes.Image = My.Resources.ButtonNotes 'ImageListToolBar.Images("ButtonNotes")
            Application.DoEvents()
            'ButtonAbout.Image = ImageListToolBar.Images("ButtonAbout")
            ButtonAbout.Image = ButtonAbout.Tag
            ButtonAbout.Text = ""
            ButtonAbout.BackColor = Color.FromKnownColor(KnownColor.Transparent)
            Application.DoEvents()
            LabelBtnMsgNumber.Visible = True
        Else
            ButtonSchedule.Image = Nothing
            ButtonPatientProfile.Image = Nothing
            ButtonIntakeForm.Image = Nothing
            ButtonMessaging.Image = Nothing
            ButtonPatSearchAndTools.Image = Nothing
            ButtonSearch.Image = Nothing
            ButtonNetSearch.Image = Nothing
            ButtonInsuranceMainenance.Image = Nothing
            ButtonBilling.Image = Nothing
            ButtonBillMaintenance.Image = Nothing
            ButtonCollection.Image = Nothing
            ButtonAbout.Image = Nothing
            ButtonNotes.Image = Nothing
            ButtonAbout.Text = "About"
            ButtonAbout.BackColor = Color.FromKnownColor(KnownColor.SlateGray)

            ButtonScheduleBack.Height = 57
            PanelButtonsBack.Height = 40
            Application.DoEvents()
            LabelBtnMsgNumber.Visible = False
        End If
    End Sub

    Dim TMail As New Thread(AddressOf Process_EmailAlerts)
    Private lastRunningDate As Date = Now.AddDays(-1)
    Private Sub TimerEmailAlerts_Tick(sender As Object, e As EventArgs) Handles TimerEmailAlerts.Tick
        If lastRunningDate = Now.Date Then Exit Sub
        TimerEmailAlerts.Interval = 3600000
        TimerEmailAlerts.Enabled = False
        If exitflag Then Return
        If gSMTPUID = "" Or gSMTPPWD = "" Or gSMTPHost = "" Then
            Exit Sub
        End If
        'TMail = New Threading.Thread(AddressOf Process_EmailAlerts)

        If TMail.IsAlive = False Then
            TMail = New Thread(AddressOf Process_EmailAlerts)
            TMail.IsBackground = True
            TMail.Start()
        End If
        lastRunningDate = Now.Date
        TimerEmailAlerts.Enabled = True
    End Sub

    Private Sub Process_EmailAlerts()
        On Error GoTo er
        Dim schReader As SqlDataReader
        Dim DReader As SqlDataReader
        Dim OfReader As SqlDataReader
        Dim SQL As String
        Dim StartProcess As Boolean
        Dim MessageGenerated As Boolean
        Dim EmailBody As String
        Dim EmailMessage1 As String, EmailMessage2 As String
        Dim EmpID As Integer
        Dim sLine = "--------------------------------------"
        Dim LastDay As String
        ''''''''''''''' Check If Last Day Was Day Off
        If exitflag Then Return
        OfReader =
            gSQLGetDataReader(
                "SELECT count(*) as C, MAX(Su) AS '0', MAX(Mo) AS '1', MAX(Tu) AS '2', MAX(We) AS '3', MAX(Th) AS '4', MAX(Fr) AS '5', MAX(Sa) AS '6' FROM OfficeDiagnostics WHERE OfficeID = " &
                gOfficeID)
        LastDay = CInt(DateAdd(DateInterval.Day, -1, Now).DayOfWeek).ToString
        If OfReader.HasRows Then
            OfReader.Read()
            If Val(OfReader(LastDay).ToString) = 0 And Val(OfReader("C").ToString) > 0 Then
                OfReader.Close()
                Exit Sub
            End If
        End If
        ''''''''''''''' Check If Last Day Was Holiday
        If _
            gSQLGetSingleValue(
                "SELECT COUNT(*) AS C FROM HolidaysOffDays WHERE ActiveInd = 1 AND (OffDate = DATEADD(day, DATEDIFF(day, 0, GETDATE()), - 1))") >
            0 Then
            Exit Sub
        End If

        EmailMessage1 = vbCrLf & "OFFICE STATISTIC" & vbCrLf
        EmailMessage1 &= sLine & vbCrLf
        EmailMessage1 &= "All Active Patients: " &
                         gSQLGetSingleValue(
                             "SELECT     COUNT(*) AS C FROM Patients WHERE CaseStatusID = 1 OR CaseStatusID = 4") &
                         vbCrLf
        EmailMessage1 &= "All Procedures: " &
                         gSQLGetSingleValue(
                             "SELECT     COUNT(*) AS C FROM         Patients INNER JOIN PatientProcedures ON Patients.PatientID = PatientProcedures.PatientID WHERE  isnull(PatientProcedures.DoNotBillInd,0)=0 and     (Patients.CaseStatusID = 1 OR Patients.CaseStatusID = 4) AND (PatientProcedures.ProcedureStatusID = 1 OR PatientProcedures.ProcedureStatusID = 2 OR PatientProcedures.ProcedureStatusID = 4 OR PatientProcedures.ProcedureStatusID = 0)") &
                         vbCrLf
        EmailMessage1 &= "All Completed Procedures: " &
                         gSQLGetSingleValue(
                             "SELECT     COUNT(*) AS C FROM         Patients INNER JOIN PatientProcedures ON Patients.PatientID = PatientProcedures.PatientID WHERE isnull(PatientProcedures.DoNotBillInd,0)=0 and  (Patients.CaseStatusID = 1 OR Patients.CaseStatusID = 4) AND (PatientProcedures.ProcedureStatusID = 2)") &
                         vbCrLf

        DReader = gSQLGetDataReader("Select DiagID, DiagName from Diagnostics Where ActiveInd=1")
        Do Until DReader.Read = False
            If exitflag Then Return
            EmailMessage1 &= "All Completed " & DReader("DiagName").ToString.Trim & ": " &
                             gSQLGetSingleValue(
                                 "SELECT     COUNT(*) AS C FROM         Patients INNER JOIN PatientProcedures ON Patients.PatientID = PatientProcedures.PatientID WHERE PatientProcedures.DiagID = " &
                                 Val(DReader("DiagID").ToString) &
                                 " and isnull(PatientProcedures.DoNotBillInd,0)=0 and  (Patients.CaseStatusID = 1 OR Patients.CaseStatusID = 4) AND (PatientProcedures.ProcedureStatusID = 2)") &
                             vbCrLf
            EmailMessage1 &= "All Scheduled " & DReader("DiagName").ToString.Trim & ": " &
                             gSQLGetSingleValue(
                                 "SELECT     COUNT(*) AS C FROM         Patients INNER JOIN PatientProcedures ON Patients.PatientID = PatientProcedures.PatientID WHERE PatientProcedures.DiagID = " &
                                 Val(DReader("DiagID").ToString) &
                                 " and isnull(PatientProcedures.DoNotBillInd,0)=0 and (Patients.CaseStatusID = 1 OR Patients.CaseStatusID = 4) AND (PatientProcedures.ProcedureStatusID = 1)") &
                             vbCrLf
        Loop
        DReader.Close()
        EmailMessage1 &= vbCrLf & vbCrLf & "DAILY STATISTIC" & vbCrLf
        EmailMessage1 &= sLine & vbCrLf
        EmailMessage1 &= DateAdd(DateInterval.Day, -1, Now).ToShortDateString & " - New Patients: " &
                         gSQLGetSingleValue(
                             "SELECT     COUNT(*) AS C FROM Patients WHERE DATEDIFF(dd, InsertedDT, GETDATE()) = 1") &
                         vbCrLf

        DReader = gSQLGetDataReader("Select DiagID, DiagName from Diagnostics Where ActiveInd=1")
        Do Until DReader.Read = False
            EmailMessage1 &= DateAdd(DateInterval.Day, -1, Now).ToShortDateString & " - Completed " &
                             DReader("DiagName").ToString.Trim & " Procedures: " &
                             gSQLGetSingleValue(
                                 "SELECT     COUNT(*) AS C FROM PatientProcedures INNER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID WHERE  PatientProcedures.DiagID = " &
                                 Val(DReader("DiagID").ToString) &
                                 " and isnull(PatientProcedures.DoNotBillInd,0)=0 and   (DATEDIFF(dd, Schedule.ScheduleDateTime, GETDATE()) = 1) AND (PatientProcedures.ProcedureStatusID = 2)") &
                             vbCrLf
            EmailMessage1 &= DateAdd(DateInterval.Day, -1, Now).ToShortDateString & " - NoShow(s) " &
                             DReader("DiagName").ToString.Trim & ": " &
                             gSQLGetSingleValue(
                                 "SELECT COUNT(*) AS C FROM PatientProcedures INNER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID WHERE PatientProcedures.DiagID = " &
                                 Val(DReader("DiagID").ToString) &
                                 " and isnull(PatientProcedures.DoNotBillInd,0)=0 and    (DATEDIFF(dd, Schedule.ScheduleDateTime, GETDATE()) = 1) AND (PatientProcedures.ProcedureStatusID = 1 or PatientProcedures.ProcedureStatusID = 4)") &
                             vbCrLf
        Loop
        DReader.Close()
        EmailMessage2 = vbCrLf & "ADMINISTRATOR ATTENTION REQUIRED" & vbCrLf
        EmailMessage2 &= sLine & vbCrLf
        If exitflag Then Return
        EmailMessage2 &= "No Readings: (All): " &
                         gSQLGetSingleValue(
                             "SELECT     COUNT(*) AS C FROM PatientProcedures INNER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID LEFT OUTER JOIN PatientProcedureReadings ON PatientProcedures.PatientProcedureID = PatientProcedureReadings.PatientProcedureID WHERE isnull(PatientProcedures.DoNotBillInd,0)=0  and  (PatientProcedures.ProcedureStatusID = 2) AND (PatientProcedureReadings.ResultID IS NULL)") &
                         "   (5+ Days) :" &
                         gSQLGetSingleValue(
                             "SELECT     COUNT(*) AS C FROM PatientProcedures INNER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID LEFT OUTER JOIN PatientProcedureReadings ON PatientProcedures.PatientProcedureID = PatientProcedureReadings.PatientProcedureID WHERE isnull(PatientProcedures.DoNotBillInd,0)=0 and  (PatientProcedures.ProcedureStatusID = 2) AND (PatientProcedureReadings.ResultID IS NULL) AND (DATEDIFF(d, Schedule.ScheduleDateTime, GETDATE()) > 5)") &
                         vbCrLf
        EmailMessage2 &= "No Attorney Confirmations (5+ Days): " &
                         gSQLGetSingleValue(
                             "SELECT     COUNT(*) AS C FROM Bills INNER JOIN Patients ON Bills.PatientID = Patients.PatientID WHERE (DATEDIFF(d, Bills.AttorneyDate, GETDATE()) >= 5) AND (Bills.AttorneyCompanyID IS NOT NULL) AND (Bills.AttorneyCompanyID <> 0) AND (Bills.AttorneyCaseNumber IS NULL) AND (Patients.OfficeID = " &
                             gOfficeID &
                             ") AND (Patients.CaseStatusID <> 3) AND (Patients.CaseStatusID <> 5) AND (Bills.BillStatusID = 4 OR Bills.BillStatusID = 5) ") &
                         vbCrLf
        EmailMessage2 &= "Not Processed Bill(s): " &
                         gSQLGetSingleValue(
                             "SELECT COUNT(*) AS C FROM Bills INNER JOIN Patients ON Bills.PatientID = Patients.PatientID WHERE (Patients.OfficeID = " &
                             gOfficeID &
                             ") AND (Patients.CaseStatusID <> 3) AND (Patients.CaseStatusID <> 5) AND (Bills.BillStatusID = 1) AND (Bills.BillStatusID <> 6) AND (Bills.BillStatusID <> 7) AND (Bills.BillStatusID <> 8)") &
                         vbCrLf
        EmailMessage2 &= "Incomplete Request(s): " &
                         gSQLGetSingleValue(
                             "SELECT     COUNT(*) AS C FROM BillingRequests LEFT OUTER JOIN Bills ON BillingRequests.BillID = Bills.BillID LEFT OUTER JOIN Patients ON BillingRequests.PatientID = Patients.PatientID WHERE     (Patients.OfficeID = " &
                             gOfficeID &
                             ") AND (Patients.CaseStatusID <> 3) AND (Patients.CaseStatusID <> 5) AND (Bills.BillStatusID <> 8) AND (DATEDIFF(d, BillingRequests.RequestDate, GETDATE()) >= 5) AND (BillingRequests.RequestStatusID < 3)") &
                         vbCrLf
        EmailMessage2 &= "To Be ReScheduled: " &
                         gSQLGetSingleValue(
                             "SELECT  DISTINCT  COUNT(*) as C FROM         Patients INNER JOIN PatientProcedures ON Patients.PatientID = PatientProcedures.PatientID  WHERE isnull(PatientProcedures.DoNotBillInd,0)=0 and Patients.OfficeID = " &
                             gOfficeID &
                             " AND (Patients.CaseStatusID = 1 or (Patients.CaseStatusID = 4 and PatientProcedures.DoNotBillAction=1))  AND (Patients.NoMoreAppointmentsInd = 0 or PatientProcedures.DoNotBillAction=1) AND PatientProcedures.ProcedureStatusID = 0") +
                         gSQLGetSingleValue(
                             "SELECT  DISTINCT  COUNT(*) as C FROM         Patients INNER JOIN PatientProcedures ON Patients.PatientID = PatientProcedures.PatientID  WHERE Patients.OfficeID = " &
                             gOfficeID &
                             " AND (Patients.CaseStatusID = 1 or (Patients.CaseStatusID = 4 and PatientProcedures.DoNotBillAction=1))  AND (Patients.NoMoreAppointmentsInd = 0 or PatientProcedures.DoNotBillAction=1) AND PatientProcedures.ProcedureStatusID = 0")

        SQL =
            " SELECT     EmpID, Fname, Lname, eMail, EmailMessage1, EmailMessage2, EmailMessage3, EmailMessage4, EmailMessage5, EmailMessage6, EmailMessage7, EmailMessage8, EmailMessage9, EmailMessage10, LastDateEmailSent "
        SQL &= " FROM Employees "
        SQL &=
            " WHERE     isnull(eMail,'') <> '' AND (isnull(EmailMessage1,0) <> 0 or isnull(EmailMessage2,0) <> 0 or isnull(EmailMessage3,0) <> 0 or isnull(EmailMessage4,0) <> 0 or isnull(EmailMessage5,0) <> 0 or isnull(EmailMessage6,0) <> 0 or isnull(EmailMessage7,0) <> 0 or isnull(EmailMessage8,0) <> 0 or isnull(EmailMessage9,0) <> 0 or isnull(EmailMessage10,0) <> 0) "
        SQL &= " AND EmpID in (select EmpID from EmployeeOffice Where OfficeID = " & gOfficeID & ")"
        If exitflag Then Return
        schReader = gSQLGetDataReader(SQL)
        If exitflag Then Return
        If schReader Is Nothing Then TimerEmailAlerts.Enabled = True : Exit Sub
        If schReader.HasRows = False Then TimerEmailAlerts.Enabled = True : Exit Sub
        Dim SaveEmailAsync As Integer = gSMTPAsync
        gSMTPAsync = 0
        Do Until schReader.Read = False
            If exitflag Then Return
            EmpID = schReader("EmpID").ToString
            EmailBody = ""
            MessageGenerated = False
            StartProcess = False
            If IsDate(schReader("LastDateEmailSent").ToString) = False Then
                ' Never Been Sent
                StartProcess = True
            Else
                If DateDiff(DateInterval.Hour, CDate(schReader("LastDateEmailSent").ToString), Now) > 23 Then
                    StartProcess = True
                End If
            End If
            If StartProcess Then
                EmailBody &= "eMedicalOffice Admin Report as of " & Now.ToShortDateString & vbCrLf
                EmailBody &= "Office: " & gOfficeName & vbCrLf & vbCrLf

                'Office Statistic
                If Val(schReader("EmailMessage1").ToString) = 1 Then
                    MessageGenerated = True
                    EmailBody &= EmailMessage1 & vbCrLf
                End If
                'Admin Warnings
                If Val(schReader("EmailMessage2").ToString) = 1 Then
                    MessageGenerated = True
                    EmailBody &= EmailMessage2 & vbCrLf
                End If

                If Val(schReader("EmailMessage3").ToString) = 1 Then
                    MessageGenerated = True

                End If
                'Reserved
                If Val(schReader("EmailMessage4").ToString) = 1 Then
                    MessageGenerated = True

                End If
                'Reserved
                If Val(schReader("EmailMessage5").ToString) = 1 Then
                    MessageGenerated = True

                End If
                'Reserved
                If Val(schReader("EmailMessage6").ToString) = 1 Then
                    MessageGenerated = True

                End If
                'Reserved
                If Val(schReader("EmailMessage7").ToString) = 1 Then
                    MessageGenerated = True

                End If
                'Reserved
                If Val(schReader("EmailMessage8").ToString) = 1 Then
                    MessageGenerated = True

                End If
                'Reserved
                If Val(schReader("EmailMessage9").ToString) = 1 Then
                    MessageGenerated = True

                End If
                'Reserved
                If Val(schReader("EmailMessage10").ToString) = 1 Then
                    MessageGenerated = True

                End If
                If exitflag Then Return
                If MessageGenerated Then
                    EmailBody &= vbCrLf & vbCrLf & vbCrLf
                    EmailBody &=
                        "This e-mail and any files transmitted with it are private and confidential and are solely for the use of the addressee. It may contain material which is legally privileged. If you are not the addressee or the person responsible for delivering to the addressee, be advised that you have received this e-mail in error and that any use of it is strictly prohibited."
                    If exitflag Then Return
                    gSendEmail(schReader("eMail").ToString, "eMedicalOffice Admin Report as of " & Now.ToShortDateString,
                               EmailBody, Nothing, MailPriority.Normal, False)
                    If gDebugMode Then _
                        log.Debug(
                            "EmailAdminReport Report For " & schReader("Fname").ToString & " " &
                            schReader("Lname").ToString & " has been sent on " & Now)
                End If
                gSQLUpdateData("Update Employees Set LastDateEmailSent=getdate() Where EmpID = " & EmpID)
            End If

        Loop
        gSMTPAsync = SaveEmailAsync
        TimerEmailAlerts.Enabled = True
        schReader.Close()
        Exit Sub
er:
        MsgBox(Err.Description, MsgBoxStyle.Critical, "Error")
        log.Error(Err.Description)
        TimerEmailAlerts.Enabled = True
    End Sub

    Private Sub ToolStripMenuItem30_Click_1(sender As Object, e As EventArgs) Handles ToolStripMenuItem30.Click
        ToolStripMenuItem30.Enabled = False
        Application.DoEvents()
        TimerRefresh_Tick(Nothing, Nothing)
        TimerSMS_Tick(Nothing, Nothing)
        ToolStripMenuItem30.Enabled = True
    End Sub

    Private Sub PatientChiropractorEvaluationRequiredReportToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles PatientEvaluationRequiredReportToolStripMenuItem.Click
        Using frm As frmChiropractorExams = New frmChiropractorExams

            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Sub AttorneyFeesManagementToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles AttorneyFeesManagementToolStripMenuItem.Click
        Using frm As frmAttorneyFees = New frmAttorneyFees

            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Sub ButtonNotes_Click(sender As Object, e As EventArgs) Handles ButtonNotes.Click
        Application.DoEvents()
        PanelButtonsBack.UseWaitCursor = True
        ButtonNotes.Enabled = False
        ButtonFocus.Focus()
        Application.DoEvents()
        frmNotes.MdiParent = Me
        If frmNotes.WindowState = FormWindowState.Minimized Then frmNotes.WindowState = FormWindowState.Normal
        Application.DoEvents()
        frmNotes.Show()
        frmNotes.BringToFront()
        If frmNotes.WindowState = FormWindowState.Minimized Then frmNotes.WindowState = FormWindowState.Normal
        PanelButtonsBack.UseWaitCursor = False
        ButtonNotes.Enabled = True
    End Sub

    Private Sub CollectionReportingToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles CollectionReportingToolStripMenuItem.Click
        Using frm As frmBillingCollectionReport = New frmBillingCollectionReport

            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Sub ToolStripMenuItemPreCertification_Click(sender As Object, e As EventArgs) _
        Handles ToolStripMenuItemPreCertification.Click
        Using frm As frmPreCertification = New frmPreCertification

            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Sub ButtonNetSearch_Click(sender As Object, e As EventArgs) Handles ButtonNetSearch.Click

        Application.DoEvents()
        ButtonFocus.Focus()
        Application.DoEvents()
        Using frm As frmNetSearch = New frmNetSearch
            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Sub TimerSMS_Tick(sender As Object, e As EventArgs) Handles TimerSMS.Tick
        TimerSMS.Enabled = False
        If exitflag Then Return
        If gTwilioMessageTypeId = 0 Or gTwilioFromPhoneNumber = "" Or gTwilioAccountSid = "" Or gTwilioAuthToken = "" _
            Then
            TimerSMS.Enabled = True
            Exit Sub
        End If
        If exitflag Then Return
        Dim t As New Thread(AddressOf Send_Reminders)
        t.IsBackground = True
        t.Start()
        TimerSMS.Enabled = True
    End Sub

    Private Sub Send_Reminders()
        Dim SavePatientID = ""
        Dim reader As SqlDataReader
        Dim sql As String
        Dim SMSmsg As String
        Dim Voicemsg As String
        Dim smsPhoneNumber = ""
        Dim OfficePhoneNumber As String
        Dim ScheduleID = ""
        Dim dt As String = DateAdd(DateInterval.Day, 1, Now.Date).ToShortDateString()
        If gTwilioMessageTypeId = 0 Then Exit Sub
        If exitflag Then Return
        sql =
            "SELECT        Patients.PatientID, Schedule.ScheduleID, Schedule.ScheduleDateTime, Diagnostics.DiagName, rtrim(Patients.FName) as FName, rtrim(Patients.LName) as LName, Offices.OfficeName, Offices.Phone1, Patients.CellPhone "
        sql &= "FROM            Schedule INNER JOIN "
        sql &= "                PatientProcedures ON Schedule.ScheduleID = PatientProcedures.ScheduleID INNER JOIN "
        sql &= "                Diagnostics ON PatientProcedures.DiagID = Diagnostics.DiagID INNER JOIN "
        sql &= "         Patients ON PatientProcedures.PatientID = Patients.PatientID INNER JOIN "
        sql &= "         Offices ON Patients.OfficeID = Offices.OfficeID "
        sql &= " WHERE "
        sql &= " (Schedule.ShowUpDatetime IS NULL) AND (ISNULL(Schedule.ConfirmedBy, '') = '') "
        sql &= " AND (PatientProcedures.ProcedureStatusID = 1) "
        sql &= " AND ScheduleDateTime > '" & dt & "' AND ScheduleDateTime < '" & dt & " 23:59' "
        sql &= " AND ISNULL(SMSSentInd,0)=0 "
        sql &= " AND ISNULL(CellPhone,'')<>'' "
        sql &= " ORDER BY Patients.PatientID, ScheduleDateTime "
        Application.DoEvents()
        If exitflag Then Return
        reader = gSQLGetDataReader(sql)
        If exitflag Then Return
        If reader Is Nothing Then Exit Sub
        If reader.HasRows = False Then Exit Sub

        Dim Rnd = New Random(DateTime.Now.Millisecond)
        Dim rndKey As Integer = Rnd.Next(10, 32000)

        '' Update before processing to prevent other instance of the program to pickup the same records while sms processing.
        sql = "update Schedule set SMSSentInd =  " & rndKey.ToString()
        sql &= "FROM Schedule INNER JOIN "
        sql &= " PatientProcedures ON Schedule.ScheduleID = PatientProcedures.ScheduleID INNER JOIN "
        sql &= "         Patients ON PatientProcedures.PatientID = Patients.PatientID "
        sql &= " WHERE "
        sql &= " (Schedule.ShowUpDatetime Is NULL) And (ISNULL(Schedule.ConfirmedBy, '') = '') "
        sql &= " AND (PatientProcedures.ProcedureStatusID = 1) "
        sql &= " AND ScheduleDateTime > '" & dt & "' AND ScheduleDateTime < '" & dt & " 23:59' "
        sql &= " AND ISNULL(SMSSentInd,0)=0 "
        sql &= " AND ISNULL(CellPhone,'')<>'' "
        gSQLUpdateData(sql)

        Do Until reader.Read = False
            If exitflag Then Return
            Application.DoEvents()
            If SavePatientID <> reader("PatientID").ToString() Then
                If SavePatientID <> "" Then
                    SMSmsg &= "Questions? Call: " & vbCrLf & OfficePhoneNumber
                    Voicemsg = HttpUtility.UrlEncode(Voicemsg)
                    Send_Twilio_Message(smsPhoneNumber, SMSmsg, Voicemsg, SavePatientID, ScheduleID, rndKey)
                End If
                OfficePhoneNumber = reader("Phone1").ToString()
                smsPhoneNumber = reader("CellPhone").ToString()
                ' Testing
                'smsPhoneNumber =  "(347) 522-7327"
                ScheduleID = reader("ScheduleID").ToString()
                SavePatientID = reader("PatientID").ToString()
                '''' SMS
                SMSmsg = "Reminder for:" & vbCrLf
                SMSmsg &= StrConv(reader("Fname"), VbStrConv.ProperCase) & " " &
                          StrConv(reader("Lname"), VbStrConv.ProperCase) & vbCrLf
                SMSmsg &= "Tomorrow, " & CDate(reader("ScheduleDateTime")).ToString("MM/dd/yy") & vbCrLf
                SMSmsg &= "Appointment at " & StrConv(reader("OfficeName"), VbStrConv.ProperCase) & vbCrLf

                Voicemsg = "Hellow," & vbCrLf
                Voicemsg &= "This is reminder message from " & StrConv(reader("OfficeName"), VbStrConv.ProperCase) &
                            " for " & vbCrLf
                Voicemsg &= StrConv(reader("Fname"), VbStrConv.ProperCase) & " " &
                            StrConv(reader("Lname"), VbStrConv.ProperCase) & ", " & vbCrLf
                Voicemsg &= "You have scheduled appointment, tomorrow, at " &
                            CDate(reader("ScheduleDateTime")).ToString("hh:mm tt") & ". " & vbCrLf
                Voicemsg &= "If you have any questions Or need to reschedule this appointment, please call us at " &
                            OfficePhoneNumber & ", again " & OfficePhoneNumber
            End If
            SMSmsg &= reader("DiagName").ToString() & " - " & CDate(reader("ScheduleDateTime")).ToString("hh:mm tt") &
                      vbCrLf
        Loop
        If String.IsNullOrEmpty(SavePatientID) = False Then
            SMSmsg &= "Questions? Call: " & vbCrLf & OfficePhoneNumber
            Voicemsg = HttpUtility.UrlEncode(Voicemsg)
            Send_Twilio_Message(smsPhoneNumber, SMSmsg, Voicemsg, SavePatientID, ScheduleID, rndKey)
        End If
        reader.Close()
    End Sub

    Private Sub Send_Twilio_Message(PhoneNumber As String, SMSMsg As String, VoiceMsg As String, PatientID As String, ScheduleID As String, rndKey As Integer)
        Dim Ret As String
        'ReCheck if another instance of application not sent a message
        If gSQLGetSingleValue("select count(*) from Schedule where (SMSSentInd = 0 or SMSSentInd = " & rndKey & ") and ScheduleID=" & ScheduleID) = 0 Then
            Return
        End If
        'TESTING
        'PhoneNumber = "(646) 220-1391"
        Select Case gTwilioMessageTypeId
            Case 1 'SMS
                Ret = gSendSMSMessage(PhoneNumber, SMSMsg)
            Case 2 'Voice
                Ret = gSendVoiceMessage(PhoneNumber, VoiceMsg)
            Case 3 'SMS & Voice
                Ret = gSendSMSMessage(PhoneNumber, SMSMsg)
                Application.DoEvents()
                gSendVoiceMessage(PhoneNumber, VoiceMsg)
        End Select
        Application.DoEvents()
        If Ret = "" Then
            log.Debug("SMS/Voice message sent to: " & PhoneNumber)
            gUpdate_Profile_Log(PatientID, PatientLogTypes.tOther, "Schedule SMS/Voice Reminder Sent on " & Now.ToString())
        Else
            log.Debug("SMS/Voice message vailed to: " & PhoneNumber)
            gUpdate_Profile_Log(PatientID, PatientLogTypes.tOther, "Schedule SMS/Voice Reminder Faild on " & Now.ToString() & ". " & Ret)
        End If
        gSQLUpdateData("UPDATE Schedule set SMSSentInd = 1 where ScheduleID=" & ScheduleID)
        Application.DoEvents()
    End Sub

    Private Sub ToolStripMenuItem11_Click(sender As Object, e As EventArgs) Handles mnuUpdateTreatingProvider.Click
        Application.DoEvents()
        Using frm As frmTreatingProviderUpdate = New frmTreatingProviderUpdate
            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Sub ProceduresResearchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProceduresResearchToolStripMenuItem.Click
        Application.DoEvents()
        If frmProceduresReportInstance Is Nothing OrElse frmProceduresReportInstance.IsDisposed Then
            frmProceduresReportInstance = New frmProceduresReport
        End If
        frmProceduresReportInstance.MinimizeBox = True
        frmProceduresReport.MaximizeBox = True
        frmProceduresReportInstance.MdiParent = Me
        frmProceduresReportInstance.WindowState = FormWindowState.Maximized
        frmProceduresReportInstance.Show()
        frmProceduresReportInstance.BringToFront()

    End Sub

    Private Sub ScheduleBlocksReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ScheduleBlocksReportToolStripMenuItem.Click
        Application.DoEvents()
        Using frm = New frmScheduleBlocks()
            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Sub PaymentsReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PaymentsReportToolStripMenuItem.Click
        Application.DoEvents()
        Using frm As frmPaymentsReport = New frmPaymentsReport

            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Sub ToolStripMenuItemCDPaymentsReport_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemCDPaymentsReport.Click
        Using frm As frmPaymentsReportRequests = New frmPaymentsReportRequests
            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Sub AdminTasksToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdminTasksToolStripMenuItem.Click
        'frmMessage.MinimizeBox = False
        'frmMessage.MaximizeBox = False
        ButtonFocus.Focus()
        Application.DoEvents()
        Using frm As frmAdminTasks = New frmAdminTasks

            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Sub AttorneyCasesReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AttorneyCasesReportToolStripMenuItem.Click
        ButtonFocus.Focus()
        Application.DoEvents()
        Using frm As frmAttorneysReport = New frmAttorneysReport

            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

    Private Sub ButtonMessagingBack_Paint(sender As Object, e As PaintEventArgs) Handles ButtonMessagingBack.Paint

    End Sub

    Private Sub mnuReffOfficesFromtDeskAdmin_Click(sender As Object, e As EventArgs) Handles mnuReffOfficesFromtDeskAdmin.Click
        Application.DoEvents()
        Using frm As frmReferringOfficesMaintenance = New frmReferringOfficesMaintenance
            frm.ShowDialog()
            frm.Dispose()
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripMenuItemCariskPayersMaintenance_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemCariskPayersMaintenance.Click
        Dim frm As New frmCariskPayersMaintenance
        frm.ShowDialog(Me)
        frm.Dispose()
    End Sub

    Private Sub ReceivableAgingReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReceivableAgingReportToolStripMenuItem.Click
        Dim frm As New frmAgingReport
        frm.ShowDialog(Me)
        frm.Dispose()
    End Sub

End Class