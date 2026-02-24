Imports System.Reflection
Imports log4net

Public Class frmBillingTemplatesMaintenanceAdd
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

    Private Sub TextBoxDescription_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxDescription.TextChanged
        Load_Diagnosis()
    End Sub

    Private Sub TextBoxCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxCode.TextChanged
        Load_Diagnosis()
    End Sub

    Private Sub Load_Diagnosis()
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim SQL As String
        ListViewDiagnosis.Items.Clear()
        Try
            SQL = "SELECT     DignosisID, ICDCode, ICDDescription, ICDGroup FROM Diagnosis  "
            SQL &= " WHERE Diagnosis.ActiveInd = 1 "
            If TextBoxCode.Text.Trim <> "" Then
                SQL &= " AND Diagnosis.ICDCode like '" & TextBoxCode.Text.Trim.ToSafeSQLString() & "%' "
            End If
            If TextBoxDescription.Text.Trim <> "" Then
                SQL &= " AND Diagnosis.ICDDescription like '" & TextBoxDescription.Text.Trim.ToSafeSQLString() & "%' "
            End If

            SQL &= "ORDER BY ICDCode "

            Reader = gSQLGetDataReader(SQL)
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                If CalledForm.ListViewDiagnosis.Items.Find("K" & Reader("DignosisID").ToString, False).Length = 0 Then
                    LI = ListViewDiagnosis.Items.Add("K" & Reader("DignosisID").ToString, Reader("ICDCode").ToString, "")
                    LI.SubItems.Add(Reader("ICDDescription").ToString)
                    LI.SubItems.Add(Reader("ICDGroup").ToString)
                    LI.Tag = Reader("DignosisID").ToString
                    LI.ToolTipText = Reader("ICDDescription").ToString
                End If
            Loop
            Reader.Close() : Reader.Dispose()
            If ListViewDiagnosis.Items.Count > 0 Then
                ListViewDiagnosis.Items(0).Selected = True
                ListViewDiagnosis.Items(0).EnsureVisible()
            End If
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex)
        End Try
    End Sub

    Public CalledForm As frmBillingTemplates

    Private Sub frmBillingTemplatesMaintenanceAdd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Load_Diagnosis()
    End Sub

    Private Sub ListViewDiagnosis_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListViewDiagnosis.MouseDoubleClick
        cmdUpdate_Click(Nothing, Nothing)
    End Sub

    Private Sub ListViewDiagnosis_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewDiagnosis.SelectedIndexChanged
        'gHighlightListviewItem(ListViewDiagnosis)
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim LI As ListViewItem
        If ListViewDiagnosis.SelectedItems.Count = 0 Then Exit Sub
        LI = CalledForm.ListViewDiagnosis.Items.Add("K" & ListViewDiagnosis.SelectedItems(0).Tag, ListViewDiagnosis.SelectedItems(0).Text, "")
        LI.SubItems.Add(ListViewDiagnosis.SelectedItems(0).SubItems(1).Text)
        LI.SubItems.Add(ListViewDiagnosis.SelectedItems(0).SubItems(2).Text)
        LI.Tag = ListViewDiagnosis.SelectedItems(0).Tag
        ListViewDiagnosis.Items.Remove(ListViewDiagnosis.SelectedItems(0))
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

End Class