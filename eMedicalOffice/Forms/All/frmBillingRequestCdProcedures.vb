Public Class frmBillingRequestCdProcedures
    Public ProcCell As FarPoint.Win.Spread.Cell

    Public Sub Load_Procedures(ByVal PatientID As Long, ByVal BillID As Long)
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim SQL As String
        ListViewProcedures.Items.Clear()
        If Val(PatientID) = 0 Then
            Exit Sub
        End If
        'SQL = "SELECT  Procedures.ProcName, PatientProcedures.PatientProcedureID, "
        'If BillID > 0 Then
        '    SQL &= " (SELECT     PatientProcedureID FROM BillProcedures WHERE (PatientProcedureID = PatientProcedures.PatientProcedureID)) AS Bill "
        'Else
        '    SQL &= " 0 AS Bill "
        'End If

        'SQL = SQL & " FROM         PatientProcedures INNER JOIN Procedures ON PatientProcedures.ProcID = Procedures.ProcID "
        'SQL = SQL & " Where PatientProcedures.ProcedureStatusID=2 and PatientProcedures.PatientID = " & Val(PatientID)
        SQL = "SELECT     Procedures.ProcName, PatientProcedures.PatientProcedureID, BillProcedures.BillID "
        SQL &= " FROM         PatientProcedures INNER JOIN Procedures ON PatientProcedures.ProcID = Procedures.ProcID LEFT OUTER JOIN BillProcedures ON PatientProcedures.PatientProcedureID = BillProcedures.PatientProcedureID "
        SQL = SQL & " Where PatientProcedures.ProcedureStatusID=2 and PatientProcedures.PatientID = " & Val(PatientID)
        SQL = SQL & " ORDER BY PatientProcedures.PatientProcedureID "

        Reader = gSQLGetDataReader(SQL)
        ListViewProcedures.BeginUpdate()
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            LI = ListViewProcedures.Items.Add(Reader("ProcName").ToString)
            LI.Tag = Reader("PatientProcedureID").ToString
            LI.SubItems.Add(Reader("BillID").ToString)
            If Val(Reader("BillID").ToString) = BillID Then
                LI.Checked = True
                LI.BackColor = Color.LightSteelBlue
            End If
        Loop
        Reader.Close() : Reader.Dispose()
        ListViewProcedures.EndUpdate()
    End Sub

    Private Sub frmBillingRequestCdProcedures_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gListview_Settings(Me, ListViewProcedures, ReadWrite.sWrite)
    End Sub

    Private Sub frmBillingRequestCdProcedures_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gListview_Settings(Me, ListViewProcedures, ReadWrite.sRead)
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Procs As String
        Dim LI As ListViewItem
        If ListViewProcedures.CheckedItems.Count = 0 Then
            MsgBox("Unable to process CD Request. No Procedures checked.", MsgBoxStyle.Exclamation)
            ListViewProcedures.Focus()
            Exit Sub
        End If
        For Each LI In ListViewProcedures.CheckedItems
            Procs = Procs & LI.Text & ", "
        Next
        If Procs <> "" Then Procs = Procs.Mid(1, Procs.Length - 2)
        ProcCell.Text = Procs
        DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

End Class