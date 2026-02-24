Public Class frmPatientsFindDuplicates

    Private Sub frmPatientsFindDuplicates_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gSpread_Settings(Me, FpSpreadPatients, ReadWrite.sWrite)
        If Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable Then
            gWindow_Settings(Me, ReadWrite.sWrite)
        End If
        PatientsFindDuplicatesOpened = False
    End Sub

    Private Sub frmPatientsFindDuplicates_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.SuspendLayout()
        PatientsFindDuplicatesOpened = True
        If Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable Then
            gWindow_Settings(Me, ReadWrite.sRead)
        End If
        gSpread_Settings(Me, FpSpreadPatients, ReadWrite.sRead)
        Me.ResumeLayout(False)
        Timer1.Enabled = True
    End Sub

    Public Sub Load_Data()
        Dim SQL As String
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        FpSpreadPatients.ActiveSheet.RowCount = 0
        If CheckBox1.Checked Then
            SQL = "SELECT SOUNDEX(FName) as Fname,SOUNDEX(LName) as LName , DOB into Tbl1 FROM Patients "
            SQL &= " GROUP BY SOUNDEX(FName),SOUNDEX(LName), DOB, isnull(DuplicateConfirmed,0)  "
            SQL &= " HAVING COUNT(*) > 1 and isnull(DuplicateConfirmed,0)<>1 "

            SQL &= " SELECT DISTINCT Patients.DuplicateConfirmed, Patients.PatientID, Patients.DOA, Patients.DOB, Patients.SEX, Patients.SSN, Patients.FName, Patients.LName, Patients.MI, CompanyName  from Patients inner Join Tbl1 on SOUNDEX(Patients.FName) = tbl1.Fname and Patients.DOB = tbl1.DOB  left outer join InsuranceCompanies on Patients.InsuranceCompanyID = InsuranceCompanies.CompanyID "
            SQL &= " Where isnull(Patients.DuplicateConfirmed,0)<>1"
            SQL &= " order by Patients.FName, Patients.LName "
            SQL &= " DROP TABLE Tbl1 "
        Else
            SQL = "SELECT SOUNDEX(FName) as Fname,SOUNDEX(LName) as LName , DOB into Tbl1 FROM Patients "
            SQL &= " GROUP BY SOUNDEX(FName),SOUNDEX(LName), DOB "
            SQL &= " HAVING COUNT(*) > 1 "

            SQL &= " SELECT DISTINCT Patients.DuplicateConfirmed, Patients.PatientID, Patients.DOA, Patients.DOB, Patients.SEX, Patients.SSN, Patients.FName, Patients.LName, Patients.MI, CompanyName  from Patients inner Join Tbl1 on SOUNDEX(Patients.FName) = tbl1.Fname and Patients.DOB = tbl1.DOB  left outer join InsuranceCompanies on Patients.InsuranceCompanyID = InsuranceCompanies.CompanyID "
            SQL &= " order by Patients.FName, Patients.LName "
            SQL &= " DROP TABLE Tbl1 "
        End If
        Reader = gSQLGetDataReader(SQL)

        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            FpSpreadPatients.ActiveSheet.RowCount += 1
            FpSpreadPatients.ActiveSheet.Cells(FpSpreadPatients.ActiveSheet.RowCount - 1, 0).Value = IIf(Val(Reader("DuplicateConfirmed").ToString) = 1, True, False)
            If Val(Reader("DuplicateConfirmed").ToString) = 1 Then
                FpSpreadPatients.ActiveSheet.Rows(FpSpreadPatients.ActiveSheet.RowCount - 1).BackColor = Color.Honeydew
            Else
                FpSpreadPatients.ActiveSheet.Rows(FpSpreadPatients.ActiveSheet.RowCount - 1).BackColor = Nothing
            End If
            FpSpreadPatients.ActiveSheet.Cells(FpSpreadPatients.ActiveSheet.RowCount - 1, 1).Text = Reader("PatientID").ToString
            FpSpreadPatients.ActiveSheet.Cells(FpSpreadPatients.ActiveSheet.RowCount - 1, 2).Text = Reader("Fname").ToString
            FpSpreadPatients.ActiveSheet.Cells(FpSpreadPatients.ActiveSheet.RowCount - 1, 3).Text = Reader("Lname").ToString
            FpSpreadPatients.ActiveSheet.Cells(FpSpreadPatients.ActiveSheet.RowCount - 1, 4).Text = Reader("MI").ToString
            FpSpreadPatients.ActiveSheet.Cells(FpSpreadPatients.ActiveSheet.RowCount - 1, 5).Text = IIf(IsDate(Reader("DOB").ToString), CDate(Reader("DOB").ToString).ToString("MM/dd/yyyy"), "")
            FpSpreadPatients.ActiveSheet.Cells(FpSpreadPatients.ActiveSheet.RowCount - 1, 6).Text = Reader("SEX").ToString
            FpSpreadPatients.ActiveSheet.Cells(FpSpreadPatients.ActiveSheet.RowCount - 1, 7).Text = Reader("SSN").ToString
            If IsDate(Reader("DOA").ToString) And Reader("DOA").ToString <> "" Then
                FpSpreadPatients.ActiveSheet.Cells(FpSpreadPatients.ActiveSheet.RowCount - 1, 8).Text = IIf(IsDate(Reader("DOA").ToString), CDate(Reader("DOA").ToString).ToString("MM/dd/yyyy"), "")
            End If
            FpSpreadPatients.ActiveSheet.Cells(FpSpreadPatients.ActiveSheet.RowCount - 1, 9).Text = Reader("CompanyName").ToString
        Loop

        Reader.Close() : Reader.Dispose()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If FpSpreadPatients.ActiveSheet.RowCount = 0 Then
            MsgBox("Unable to show Patient's profile. No Patient selected", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If FpSpreadPatients.ActiveSheet.ActiveRowIndex = -1 Or FpSpreadPatients.ActiveSheet.ActiveColumnIndex = -1 Then
            MsgBox("Unable to show Patient's profile. No Patient selected", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Using NewFrm As New frmPatient

            NewFrm.InitialTab = 0
            NewFrm.InitialPatientName = FpSpreadPatients.ActiveSheet.Cells(FpSpreadPatients.ActiveSheet.ActiveRowIndex, 1).Text
            NewFrm.MinimizeBox = False
            NewFrm.MaximizeBox = False
            NewFrm.NoFindDuplicatePatients = True
            NewFrm.ShowDialog(Me)
        End Using
    End Sub

    Private Sub FpSpreadPatients_ButtonClicked(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.EditorNotifyEventArgs) Handles FpSpreadPatients.ButtonClicked
        Dim PatientID
        If FpSpreadPatients.ActiveSheet.Rows(e.Row).BackColor = Color.Honeydew And FpSpreadPatients.ActiveSheet.Cells(e.Row, 0).Value = False Then
            PatientID = FpSpreadPatients.ActiveSheet.Cells(e.Row, 1).Text
            If MsgBox("Please confirm you want to remove duplicate record aknowlagement from the Patient # " & PatientID & "?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                FpSpreadPatients.ActiveSheet.Cells(e.Row, 0).Value = True
            Else
                FpSpreadPatients.ActiveSheet.Rows(e.Row).BackColor = Nothing
            End If
        End If
    End Sub

    Private Sub FpSpreadPatients_CellClick(ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs) Handles FpSpreadPatients.CellClick

    End Sub

    Private Sub FpSpreadPatients_CellDoubleClick(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs) Handles FpSpreadPatients.CellDoubleClick
        Button1_Click(Nothing, Nothing)
    End Sub

    Private Sub FpSpreadPatients_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles FpSpreadPatients.DoubleClick

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim Printinfo As New FarPoint.Win.Spread.PrintInfo
        Printinfo.SmartPrintPagesWide = 1
        Printinfo.Preview = False
        Printinfo.Header = "DUPLICATE PATIENTS LIST AS OF " & Now.Date.ToString("MM/dd/yyyy") & vbCrLf & vbCrLf
        Printinfo.BestFitRows = False
        Printinfo.BestFitCols = False
        Printinfo.ShowShadows = False
        Printinfo.JobName = "eMedical Office Patients Management"
        Printinfo.PrintType = FarPoint.Win.Spread.PrintType.All
        Printinfo.ShowColor = True
        Printinfo.ShowColumnHeader = FarPoint.Win.Spread.PrintHeader.Show
        Printinfo.ShowBorder = False
        Printinfo.ShowGrid = True
        Printinfo.ShowPrintDialog = True
        Printinfo.ShowRowHeader = FarPoint.Win.Spread.PrintHeader.Hide
        Printinfo.Orientation = FarPoint.Win.Spread.PrintOrientation.Portrait
        Printinfo.SmartPrintRules.Add(New FarPoint.Win.Spread.LandscapeRule(FarPoint.Win.Spread.ResetOption.All))
        Printinfo.SmartPrintRules.Add(New FarPoint.Win.Spread.BestFitColumnRule(FarPoint.Win.Spread.ResetOption.All))
        Printinfo.UseSmartPrint = True
        Printinfo.UseMax = True
        Printinfo.Printer = gPrinterOtherDocuments
        FpSpreadPatients.ActiveSheet.PrintInfo = Printinfo
        FpSpreadPatients.PrintSheet(FpSpreadPatients.ActiveSheet)
    End Sub

    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim I As Integer
        Dim Found As Integer
        Dim PatientID As Long

        For I = 0 To FpSpreadPatients.ActiveSheet.RowCount - 1
            If FpSpreadPatients.ActiveSheet.Cells(I, 0).Value = True Then
                Found += 1
            End If
        Next
        If Found > 0 Then
            If MsgBox("Please confirm you acknowledged " & Found & " duplicated patients..." & vbCrLf & vbCrLf & "The acknowledged patient(s) will appear on the list again.", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        For I = 0 To FpSpreadPatients.ActiveSheet.RowCount - 1
            PatientID = Val(FpSpreadPatients.ActiveSheet.Cells(I, 1).Text)
            If Val(PatientID) > 0 Then
                If FpSpreadPatients.ActiveSheet.Cells(I, 0).Value = True Then
                    gSQLUpdateData("UPDATE PATIENTS SET DuplicateConfirmed = 1 where PatientID=" & PatientID)
                    FpSpreadPatients.ActiveSheet.Rows(I).BackColor = Color.Honeydew
                Else
                    gSQLUpdateData("UPDATE PATIENTS SET DuplicateConfirmed = 0 where PatientID=" & PatientID)
                    FpSpreadPatients.ActiveSheet.Rows(I).BackColor = Nothing
                End If
            End If
        Next

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Load_Data()
    End Sub

End Class