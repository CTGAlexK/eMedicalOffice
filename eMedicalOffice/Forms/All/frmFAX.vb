Imports System.Reflection
Imports log4net

Public Class frmFAX
    Public TreatingProviderID As Long = 0
    Public BatchProcess As Boolean
    Public FaxAttachements() As String
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

    Public Sub cmdStartFax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStartFax.Click
        Dim Msg As New SendFileTo
        Dim FaxAddress As String

        If gWebFaxAddress.Trim = "" Then
            MsgBox("Unable to send a Fax. No Fax Server specified. Please call your System Administrator.", MsgBoxStyle.Critical)
            txtFaxNumber.Focus()
            Exit Sub
        End If

        If txtFaxNumber.MaskCompleted = False Then
            MsgBox("Unable to send a Fax. Invalid or Missing Fax Number", MsgBoxStyle.Critical)
            txtFaxNumber.Focus()
            Exit Sub
        End If
        If (txtFaxAttachement.Text <> "") Then
            If txtFaxAttachement.Text.Contains(";") Then
                FaxAttachements = txtFaxAttachement.Text.Split(";")
            Else
                ReDim Preserve FaxAttachements(0)
                FaxAttachements(0) = txtFaxAttachement.Text
            End If
        End If
        FaxAddress = txtFaxNumber.Text
        FaxAddress = Replace(FaxAddress, "(", "")
        FaxAddress = Replace(FaxAddress, " ", "")
        FaxAddress = Replace(FaxAddress, ")", "")
        FaxAddress = Replace(FaxAddress, "-", "")
        If gWebFaxLeadingOne Then
            If FaxAddress.StartsWith("1") = False And FaxAddress.Length = 10 Then
                FaxAddress = "1" & FaxAddress
            End If
        End If
        FaxAddress = FaxAddress & "@" & gWebFaxAddress
        Try
            If (FaxAttachements Is Nothing) Then

                If Msg.SendMail(FaxAttachements, txtFrom.Text, txtText.Text, FaxAddress, False) Then
                    If cboTo.SelectedIndex = -1 And cboTo.Text <> "" Then
                        If MsgBox("Fax Sent. Do you want to add " & cboTo.Text & " to the Phone Book?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            gSQLUpdateData("INSERT INTO PhoneBook (ToName, Fax, InsertedBy) VALUES('" & cboTo.Text.ToSafeSQLString() & "', '" & txtFaxNumber.Text & "', " & gCurrentEmployee.EmpID & ")")
                            Load_Data()
                        End If
                    End If
                    SentFaxNumber = FaxAddress
                    Me.Close()
                Else
                    MsgBox("Sending fax(email) failed.")
                End If
            Else

                If Msg.SendMail(FaxAttachements, txtFrom.Text, txtText.Text, FaxAddress, False) Then
                    If cboTo.SelectedIndex = -1 And cboTo.Text <> "" Then
                        If MsgBox("Fax Sent. Do you want to add " & cboTo.Text & " to the Phone Book?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            gSQLUpdateData("INSERT INTO PhoneBook (ToName, Fax, InsertedBy) VALUES('" & cboTo.Text.ToSafeSQLString() & "', '" & txtFaxNumber.Text & "', " & gCurrentEmployee.EmpID & ")")
                            Load_Data()
                        End If
                    End If
                    SentFaxNumber = FaxAddress
                    Me.Close()
                Else
                    MsgBox("Sending fax(email) failed.")
                End If
            End If
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        DialogResult = DialogResult.No
        Me.Close()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        If txtFaxAttachement.Text = "" Then
            Exit Sub
        End If
        System.Diagnostics.Process.Start(txtFaxAttachement.Text)

        'Dim FileExt As String = ""
        'If IO.File.Exists(txtFaxAttachement.Text) Then
        '    FileExt = IO.Path.GetExtension(txtFaxAttachement.Text)
        '    Select Case FileExt.ToLower
        '        Case ".xls", ".xlsx"
        '            System.Diagnostics.Process.Start(txtFaxAttachement.Text)
        '        Case ".pdf"
        '            With frmPDFPreview
        '                .pdfViewer.Tag = txtFaxAttachement.Text
        '                .ShowDialog(Me)
        '                .Dispose()
        '            End With
        '    End Select
        'Else
        '    MsgBox("Unable to preview. No PDF Document.", MsgBoxStyle.Exclamation)
        'End If
    End Sub

    Private Sub frmFAX_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblLeadingOne.Visible = gWebFaxLeadingOne
        Load_Data()
        Text = "WEB FAX - " & gWebFaxAddress.ToUpper
    End Sub

    Public Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        If cboTo.Items.Count > 0 Then Exit Sub
        cboTo.Items.Clear()
        If TreatingProviderID = 0 Then
            SQL = "SELECT ' Dr. ' + Fname + ' ' + MI + ' ' + Lname AS ToName, CorporationFax AS Fax FROM Employees WHERE     (PositionID = 5) AND (ISNULL(CorporationFax, '') <> '') "
            SQL &= " UNION "
            SQL &= "SELECT     CompanyName AS ToName, Fax1 AS Fax FROM InsuranceCompanies WHERE isNull(Fax1, '') <> '' "
            SQL &= " UNION "
            SQL &= " SELECT     OfficeName AS ToName, Fax1 AS Fax FROM ReferringOffices WHERE isNull(Fax1, '') <> '' "
            SQL &= " UNION "
            SQL &= " SELECT     CompanyName AS ToName, Fax1 AS Fax FROM TransportationCompanies WHERE isNull(Fax1, '') <> '' "
            SQL &= " UNION "
            SQL &= " SELECT     ToName, Fax FROM PhoneBook ORDER BY ToName "
            Reader = gSQLGetDataReader(SQL)
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                cboTo.Items.Add(New ValueDescription(0, Reader("ToName").ToString, Reader("Fax").ToString))
            Loop
            Reader.Close() : Reader.Dispose()
        Else
            SQL = "SELECT  Fname+' '+Lname AS ToName, Phone2 AS Fax FROM Employees WHERE EmpID=" & TreatingProviderID
            Reader = gSQLGetDataReader(SQL)
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                cboTo.Items.Add(New ValueDescription(0, Reader("ToName").ToString, Reader("Fax").ToString))
            Loop
            If cboTo.Items.Count > 0 Then
                cboTo.SelectedIndex = 0
            End If
            Reader.Close() : Reader.Dispose()
        End If
    End Sub

    Private Sub cboTo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTo.KeyUp
        gComboboxAutoComplete(cboTo, e, False)
        cboTo_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub cboTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTo.SelectedIndexChanged
        If cboTo.SelectedIndex = -1 Then
            txtFaxNumber.Text = ""
        Else
            txtFaxNumber.Text = CType(cboTo.SelectedItem, ValueDescription).Value1
        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        frmMessagePool.txtBox = txtText
        frmMessagePool.ShowDialog(Me)
        frmMessagePool.Dispose()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmPhoneBook.cboTo = cboTo
        frmPhoneBook.txtPhoneNumber = txtFaxNumber
        frmPhoneBook.CalledForm = Me
        frmPhoneBook.ShowDialog()
        frmPhoneBook.Dispose()
    End Sub

    Private Sub ToolStripButton2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        frmPhoneBook.cboTo = cboTo
        frmPhoneBook.txtToNumber = txtFaxNumber
        frmPhoneBook.CalledForm = Me
        frmPhoneBook.ShowDialog(Me)
        frmPhoneBook.Dispose()
    End Sub

    Private Sub ButtonCancelBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancelBatch.Click
        DialogResult = Windows.Forms.DialogResult.No
        Me.Close()
    End Sub

    Private Sub ButtonContinueBatchProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinueBatchProcess.Click
        DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

End Class