Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Reflection
Imports log4net
Imports Newtonsoft.Json.Linq

Public Class FrmDiagnosisMaintenanceConvert
    Private ReadOnly log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Public callerForm As Form

    Private Sub frmDiagnosisMaintenance_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Dispose()
    End Sub

    Private Sub frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        FpSpread_Sheet1.ColumnHeaderVisible = False
        FpSpread_Sheet1.RowHeaderVisible = False

        Application.DoEvents()

        Cursor = Cursors.Default
        Application.DoEvents()
        gSetup_GotFocus(Me)
    End Sub

    Private Sub frmAdjusterMaintenance_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not callerForm Is Nothing And callerForm.IsDisposed = False Then
            callerForm.Location = Location
            callerForm.Opacity = 1
        End If
    End Sub

    Public Sub Load_Diagnose()
    End Sub

    Private Sub Clear_Controls()
        gLoop_Clear_Controls(Me)
    End Sub

    Public Async Sub GetICD10Codes(icd9 As String)
        Using client As New WebClient()
            'Dim retjson As String = client.DownloadString("http://www.lpitools.com/api/demo/icd9to10/" & icd9)
            'Dim assetsObject = JsonConvert.DeserializeObject(Of JObject)(retjson)
            'https://www.hipaaspace.com/myaccount/default.aspx
            'Web Services Token
            '3F5317A43193419AA5048E1BF3FF7C62EF97FFC4C65B4610B230A6AAD0A03114
            Dim stream As Stream =
                    client.OpenRead(
                        "https://www.HIPAASpace.com/api/icd9to10/mapcode?codeType=dx&q=" &
                        icd9.Replace(",", "").Replace(".", "") &
                        "&rt=json&token=3F5317A43193419AA5048E1BF3FF7C62EF97FFC4C65B4610B230A6AAD0A03114")
            Dim reader As New StreamReader(stream)
            Dim jsonData As String = reader.ReadToEnd
            reader.Close()
            Dim allData As JObject = JObject.Parse(jsonData)
            Dim i As Integer
            FpSpread.ActiveSheet.RowCount = 0
            Try
                Dim retTophData = allData("ICD9ToICD10")("PossibleMappings")("ICD10")
                If Not retTophData.SelectToken("@code") Is Nothing Then
                    FpSpread.ActiveSheet.RowCount = 1
                    FpSpread.ActiveSheet.Cells(0, 0).Value = 1
                    Dim code As String = retTophData.SelectToken("@code")
                    If code.Length > 3 Then
                        code = code.Left(3) & "." & code.Mid(5)
                    End If
                    FpSpread.ActiveSheet.Cells(0, 1).Value = code
                    FpSpread.ActiveSheet.Cells(0, 2).Value = retTophData.SelectToken("@description")
                Else
                    FpSpread.ActiveSheet.RowCount = retTophData.Count()
                    For Each retItems As JToken In retTophData
                        FpSpread.ActiveSheet.Cells(i, 0).Value = 1
                        Dim code As String = retItems.SelectToken("@code")
                        If code.Length > 3 Then
                            code = code.Left(3) & "." & code.Mid(5)
                        End If
                        FpSpread.ActiveSheet.Cells(i, 1).Value = code
                        FpSpread.ActiveSheet.Cells(i, 2).Value = retItems.SelectToken("@description")
                        FpSpread.ActiveSheet.Cells(i, 1).Text = code
                        FpSpread.ActiveSheet.Cells(i, 2).Text = retItems.SelectToken("@description")
                        i = i + 1
                    Next
                End If
            Catch ex As Exception

            End Try

        End Using
    End Sub

    Public Async Sub GetICD10CodesLimited(icd9 As String)
        Using client As New WebClient()
            'Dim retjson As String = client.DownloadString("http://www.lpitools.com/api/demo/icd9to10/" & icd9)
            'Dim assetsObject = JsonConvert.DeserializeObject(Of JObject)(retjson)
            Dim stream As Stream = client.OpenRead("http://www.lpitools.com/api/demo/icd9to10/" & icd9)
            Dim reader As New StreamReader(stream)
            Dim jsonData As String = reader.ReadToEnd
            reader.Close()
            Dim allData As JObject = JObject.Parse(jsonData)
            Dim ICDList As List(Of JToken) = allData.Children().ToList
            Dim i As Integer
            For Each item As JProperty In ICDList
                item.CreateReader()
                Select Case item.Name
                    Case "ICD10Codes"
                        Try
                            For Each msg As JObject In item.Values
                                i = i + 1
                                If i < 9 Then
                                    Dim txtCode As TextBox = GetTextBoxByItName("txtICDCode" & i)
                                    Dim txtDescription As TextBox = GetTextBoxByItName("txtICDDescription" & i)
                                    If Not txtCode Is Nothing Then txtCode.Text = msg("Code")
                                    If Not txtDescription Is Nothing Then txtDescription.Text = msg("Display")
                                End If
                            Next
                        Catch ex As Exception
                            Exit For
                        End Try
                End Select

            Next

        End Using
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Sub cmdUpdate_Click(sender As Object, e As EventArgs) Handles cmdUpdate.Click
        Dim Reader As SqlDataReader
        Dim ID As Long
        Dim LI As ListViewItem
        Dim I As Integer
        Dim Found As Integer
        'gLoop_Trim_Controls(Me)
        For r = 0 To FpSpread.ActiveSheet.Rows.Count - 1
            Dim checked = CBool(FpSpread.ActiveSheet.Cells(r, 0).Value)
            Dim code = FpSpread.ActiveSheet.Cells(r, 1).Value.ToString()
            Dim description = FpSpread.ActiveSheet.Cells(r, 2).Value.ToString()
            If checked Then
                If code.Trim().Length = 0 Then
                    FpSpread.ActiveSheet.SetActiveCell(r, 1)
                    FpSpread.ShowActiveCell(r, 1)
                    FpSpread.Focus()
                    Application.DoEvents()
                    MsgBox("Unable to update. The ICDCode is required.", MsgBoxStyle.Exclamation)
                    FpSpread.Focus()
                    FpSpread.EditMode = True
                    Return
                End If
                If description.Trim().Length = 0 Then
                    FpSpread.ActiveSheet.SetActiveCell(r, 2)
                    FpSpread.ShowActiveCell(r, 2)
                    FpSpread.Focus()
                    Application.DoEvents()
                    MsgBox("Unable to update. The ICDCode Description is required.", MsgBoxStyle.Exclamation)
                    FpSpread.Focus()
                    FpSpread.EditMode = True
                    Return
                End If
                Found = Found + 1
            End If

        Next
        If Found = 0 Then
            TabControl1.SelectedIndex = 0
            MsgBox("Unable to update. No new ICDCode specified for update.", MsgBoxStyle.Exclamation)
            FpSpread.Focus()
            Exit Sub
        End If
        Dim values = New List(Of String)
        For r = 0 To FpSpread.ActiveSheet.Rows.Count - 1
            Dim checked = CBool(FpSpread.ActiveSheet.Cells(r, 0).Value)
            Dim code = FpSpread.ActiveSheet.Cells(r, 1).Value.ToString()
            If checked = True Then
                values.Add(code)
            End If
        Next

        Dim d As Integer = values.GroupBy(Function(m) m).Count(Function(g) g.Count() > 1)
        If d > 0 Then
            TabControl1.SelectedIndex = 0
            MsgBox("Unable to update. Duplicate ICDCodes specified.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        TabControl1.Enabled = False
        cmdUpdate.Enabled = False
        cmdCancel.Enabled = False
        Application.DoEvents()
        ID = CInt(txtICDCode.Tag)

        For r = 0 To FpSpread.ActiveSheet.Rows.Count - 1
            Dim checked = CBool(FpSpread.ActiveSheet.Cells(r, 0).Value)
            Dim code = FpSpread.ActiveSheet.Cells(r, 1).Value.ToString()
            Dim description = FpSpread.ActiveSheet.Cells(r, 2).Value.ToString()

            If checked = True Then
                If gSQLGetSingleValue("Select count(*) as C from Diagnosis Where ICDCode = '" & code.ToSafeSQLString() & "' and DignosisID <> " & ID, gConnectionString) > 0 Then
                    TabControl1.SelectedIndex = 0
                    FpSpread.ActiveSheet.SetActiveCell(r, 1)
                    FpSpread.ShowActiveCell(r, 1)
                    FpSpread.Focus()
                    Application.DoEvents()
                    TabControl1.Enabled = True
                    cmdUpdate.Enabled = True
                    cmdCancel.Enabled = True
                    MsgBox("Unable to update. The ICD Code " & code & " is already exists in the database.",
                       MsgBoxStyle.Exclamation, "Duplicate ICDCode")
                    FpSpread.Focus()
                    FpSpread.EditMode = True
                    Return
                    Exit Sub
                End If
            End If
        Next

        If CheckedListBoxProcedures.CheckedItems.Count = 0 Then
            TabControl1.SelectedIndex = 1
            If _
                MsgBox(
                    "You have not assigned this Diagnose ICDCodes to any procedure(s)." & vbCrLf &
                    "Do you want to continue without procedure(s) assignment?",
                    MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                ErrorProvider1.SetError(CheckedListBoxProcedures, "No Procedure selected.")
                TabControl1.Enabled = True
                cmdUpdate.Enabled = True
                cmdCancel.Enabled = True
                CheckedListBoxProcedures.Focus()
                Exit Sub
            End If
        End If

        If ComboBoxGroups.Text = "" Then
            ComboBoxGroups.Text = "Ungrouped"
        End If

        Try
            If MsgBox("Please confirm you want to add " & Found & " codes?" & vbCrLf & "The old code will be set as inactive.", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Enabled = True
                Return
            End If
            LabelUpdate.Visible = True
            LabelUpdate.Refresh()
            Application.DoEvents()
            gSQLUpdateData("UPDATE Diagnosis set ActiveInd=0 Where DignosisID = " & ID, gConnectionString)
            For r = 0 To FpSpread.ActiveSheet.Rows.Count - 1

                LabelUpdate.Refresh()
                Dim checked = CBool(FpSpread.ActiveSheet.Cells(r, 0).Value)
                Dim code = FpSpread.ActiveSheet.Cells(r, 1).Value.ToString()
                Dim description = FpSpread.ActiveSheet.Cells(r, 2).Value.ToString()
                LabelUpdate.Text = "Update in progress. Please wait... ICDCode: " & code

                If checked = True And code.Trim.Length > 0 Then
                    Dim TA As New SqlDataAdapter("Select * from Diagnosis Where 1=2" & ID, gConnectionString)
                    Dim CB As New SqlCommandBuilder(TA)
                    CB.ConflictOption = ConflictOption.OverwriteChanges
                    Dim TR As DataRow
                    Dim dTab As New DataTable("Diagnosis")
                    TA.Fill(dTab)
                    TR = dTab.NewRow
                    TR("ICDCode") = code.Trim
                    TR("ICDGroup") = ComboBoxGroups.Text
                    TR("ICDDescription") = description.Trim
                    TR("ActiveInd") = 1
                    TR("ChangedBy") = gCurrentEmployee.EmpID
                    TR("ChangedDT") = Now.ToString("MM/dd/yyyy")
                    dTab.Rows.Add(TR)
                    TA.UpdateCommand = CB.GetUpdateCommand(True)
                    Try
                        TA.Update(dTab)
                        dTab.AcceptChanges()
                    Catch ex As Exception
                        TopMost = False
                        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                        log.Error(ex.Message, ex)
                        Exit Sub
                    End Try
                    dTab.Dispose()
                    CB.Dispose()
                    TA.Dispose()
                    ID = gSQLGetSingleValue("Select IDENT_CURRENT('Diagnosis')", gConnectionString)
                    gSQLUpdateData("Delete From ProcedureDiagnosis where DignosisID=" & ID, gConnectionString)
                    If CheckedListBoxProcedures.CheckedItems.Count > 0 Then
                        For I = 0 To CheckedListBoxProcedures.Items.Count - 1
                            If CheckedListBoxProcedures.GetItemChecked(I) Then
                                gSQLUpdateData(
                                    "INSERT INTO ProcedureDiagnosis (DignosisID, ProcID,ChangedBy, ChangedDT) VALUES(" &
                                    ID & ", " & CheckedListBoxProcedures.Items(I).value & ", " & gCurrentEmployee.EmpID &
                                    ", '" & Now.ToString("MM/dd/yyyy") & "')")
                            End If
                        Next
                    End If
                End If
            Next
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
            LabelUpdate.Visible = False
            LabelUpdate.Refresh()
            TabControl1.Enabled = True
            cmdUpdate.Enabled = True
            cmdCancel.Enabled = True
            Return
        End Try
        Enabled = True
        Me.DialogResult = DialogResult.OK
        Close()
    End Sub

    Private Function GetTextBoxByItName(name As String) As TextBox
        For Each value As Control In TabPage1.Controls
            If value.Name.ToUpper = name.ToUpper Then
                Return value
            End If
        Next

        Return Nothing
    End Function

    Private Function GetCheckBoxByItName(name As String) As CheckBox
        For Each value As Control In TabPage1.Controls
            If value.Name.ToUpper = name.ToUpper Then
                Return value
            End If
        Next

        Return Nothing
    End Function

    Private Sub txtICDCode_TextChanged(sender As Object, e As EventArgs) Handles txtICDCode.TextChanged
        ErrorProvider1.SetError(txtICDCode, "")
    End Sub

    Private Sub txtICDGroup_TextChanged(sender As Object, e As EventArgs)
        ErrorProvider1.SetError(ComboBoxGroups, "")
    End Sub

    Private Sub txtICDDescription_TextChanged(sender As Object, e As EventArgs) Handles txtICDDescription.TextChanged
        ErrorProvider1.SetError(txtICDDescription, "")
    End Sub

    Private Sub CheckedListBoxProcedures_ItemCheck(sender As Object, e As ItemCheckEventArgs)
        ErrorProvider1.SetError(CheckedListBoxProcedures, "")
    End Sub

    Private Sub ComboBoxGroups_KeyUp(sender As Object, e As KeyEventArgs) Handles ComboBoxGroups.KeyUp
        sSearchComboBox_KeyUp(ComboBoxGroups, e, False)
    End Sub

    Private Sub CopyCheckedProceduresToolStripMenuItem_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Interval = 5
        Opacity = Opacity + 0.1
        If Opacity >= 1 Then
            callerForm.Opacity = 0
            Timer1.Enabled = False
            Opacity = 1
        End If
    End Sub

    Private Sub ResetError(sender As Object, e As EventArgs)

        ErrorProvider1.SetError(sender, "")
    End Sub

    Private Sub FpSpread_CellClick(sender As Object, e As FarPoint.Win.Spread.CellClickEventArgs) Handles FpSpread.CellClick

    End Sub

End Class