Public Class frmVerivyInsuranceCompanyDetails
    Public LI As ListViewItem
    Public LV As ListView
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Dim SQL As String
        Dim Reader As SqlClient.SqlDataReader
        Dim RelatedLI As ListViewItem
        If CheckBox1.Checked Then
            If txtPolicyNumber.Text.Trim = "" Then
                If MsgBox("Warning." & vbCrLf & "The Policy Number is missing!" & vbCrLf & vbCrLf & "Continue without policy number?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    txtPolicyNumber.Focus()
                    Exit Sub
                End If
                'MsgBox("Unable to process insurance confirmation." & vbCrLf & "The Policy Number is required.", MsgBoxStyle.Exclamation)
            End If
            If txtClaimNumber.Text.Trim = "" Then
                MsgBox("Unable to process insurance confirmation." & vbCrLf & "The Claim Number is required.", MsgBoxStyle.Exclamation)
                txtClaimNumber.Focus()
                Exit Sub
            End If
            If MsgBox("Please confirm the insurance information for the patient " & vbCrLf & vbCrLf & lblPatient.Text & vbCrLf & vbCrLf & "has been verified?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
            SQL = "UPDATE Patients SET PolicyNumber='" & txtPolicyNumber.Text.Trim.ToSafeSQLString() & "', ClaimNumber='" & txtClaimNumber.Text.Trim.ToSafeSQLString() & "', Comments = '" & txtComments.Text.Trim.ToSafeSQLString() & IIf(txtCommentsNew.Text.Trim <> "", vbCrLf & txtCommentsNew.Text.Trim.ToSafeSQLString(), "") & "', InsuranceVerifyed=1 Where PatientID=" & Val(lblPatient.Tag)
        Else
            SQL = "UPDATE Patients SET PolicyNumber='" & txtPolicyNumber.Text.Trim.ToSafeSQLString() & "', ClaimNumber='" & txtClaimNumber.Text.Trim.ToSafeSQLString() & "', Comments = '" & txtComments.Text.Trim.ToSafeSQLString() & vbCrLf & IIf(txtCommentsNew.Text.Trim <> "", vbCrLf & txtCommentsNew.Text.Trim.ToSafeSQLString(), "") & "' Where PatientID=" & Val(lblPatient.Tag)
        End If
        gSQLUpdateData(SQL)
        LI.SubItems(9).Text = txtPolicyNumber.Text
        If txtPolicyNumber.Text = "" Then
            LI.SubItems(9).BackColor = Color.FromArgb(50, 255, 192, 128)
        Else
            LI.SubItems(9).BackColor = Color.White
        End If
        LI.SubItems(10).Text = txtClaimNumber.Text
        If txtClaimNumber.Text = "" Then
            LI.SubItems(10).BackColor = Color.FromArgb(50, 255, 192, 128)
        Else
            LI.SubItems(10).BackColor = Color.White
        End If

        LI.SubItems(11).Tag = txtComments.Text & IIf(txtCommentsNew.Text.Trim <> "", vbCrLf & txtCommentsNew.Text.Trim, "")
        LI.SubItems(11).Text = Replace(txtComments.Text, vbCrLf, " ") & Replace(txtCommentsNew.Text.Trim, vbCrLf, " ")
        If CheckBox1.Checked Then
            LI.UseItemStyleForSubItems = True
            LI.BackColor = Color.LightGreen
            gUpdate_Profile_Log(lblPatient.Tag, PatientLogTypes.tOther, "Insurance Information Verified")
        Else
            gUpdate_Profile_Log(lblPatient.Tag, PatientLogTypes.tOther, "Insurance Information Updated")
        End If

        Dim RelatedText As String
        Dim C As Integer
        SQL = " SELECT  DISTINCT   Patients.PatientID, ISNULL(Patients.FName, '') + '  ' + ISNULL(Patients.LName, '') + ' ' + ISNULL(Patients.MI, '') AS PatName "
        SQL &= " FROM PatientAccidentGroups inner join Patients on PatientAccidentGroups.PatientID =Patients.PatientID "
        SQL &= " Where GroupID = (SELECT     GroupID FROM PatientAccidentGroups where PatientID=" & Val(lblPatient.Tag) & ") and PatientAccidentGroups.PatientID<>" & Val(lblPatient.Tag)
        Reader = gSQLGetDataReader(SQL)
        If Not Reader Is Nothing Then
            If Reader.HasRows Then
                RelatedText = "The following Patient(s) found in the Patient Accident Group:" & vbCrLf & vbCrLf
                Do Until Reader.Read = False
                    C = C = 1
                    RelatedText &= Reader("PatientID").ToString & "  " & Reader("PatName").ToString & vbCrLf
                Loop
                If CheckBox1.Checked Then
                    If C = 1 Then
                        RelatedText &= vbCrLf & "Set this patient Insurance information as Verified?"
                    Else
                        RelatedText &= vbCrLf & "Set all these patients Insurance information as Verified?"
                    End If
                Else
                    If C = 1 Then
                        RelatedText &= vbCrLf & "Set this patient Claim Number / Policy Number?"
                    Else
                        RelatedText &= vbCrLf & "Set all these patients Claim Number / Policy Number?"
                    End If
                End If
                If MsgBox(RelatedText, MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Reader = gSQLGetDataReader(SQL)
                    Do Until Reader.Read = False
                        If CheckBox1.Checked Then
                            SQL = "UPDATE Patients SET PolicyNumber='" & txtPolicyNumber.Text.Trim.ToSafeSQLString() & "', ClaimNumber='" & txtClaimNumber.Text.Trim.ToSafeSQLString() & "', Comments = '" & txtComments.Text.Trim.ToSafeSQLString() & IIf(txtCommentsNew.Text.Trim <> "", vbCrLf & txtCommentsNew.Text.Trim.ToSafeSQLString(), "") & "', InsuranceVerifyed=1 Where PatientID=" & Val(Reader("PatientID").ToString)
                            gSQLUpdateData(SQL)
                            For Each RelatedLI In LV.Items
                                If Val(RelatedLI.Text) = Val(Reader("PatientID").ToString) Then
                                    RelatedLI.SubItems(9).Text = txtPolicyNumber.Text
                                    RelatedLI.SubItems(9).BackColor = Color.White
                                    RelatedLI.SubItems(10).Text = txtClaimNumber.Text
                                    RelatedLI.SubItems(10).BackColor = Color.White
                                    RelatedLI.SubItems(11).Tag = txtComments.Text
                                    RelatedLI.SubItems(11).Text = Replace(txtComments.Text, vbCrLf, " ")
                                    RelatedLI.UseItemStyleForSubItems = True
                                    RelatedLI.BackColor = Color.LightGreen
                                    gUpdate_Profile_Log(Val(Reader("PatientID").ToString), PatientLogTypes.tOther, "Insurance Information Verified")
                                End If
                            Next
                        Else
                            SQL = "UPDATE Patients SET PolicyNumber='" & txtPolicyNumber.Text.Trim.ToSafeSQLString() & "', ClaimNumber='" & txtClaimNumber.Text.Trim.ToSafeSQLString() & "', Comments = '" & txtComments.Text.Trim.ToSafeSQLString() & IIf(txtCommentsNew.Text.Trim <> "", vbCrLf & txtCommentsNew.Text.Trim.ToSafeSQLString(), "") & "' Where PatientID=" & Val(Reader("PatientID").ToString)
                            gSQLUpdateData(SQL)
                            For Each RelatedLI In LV.Items
                                If Val(RelatedLI.Text) = Val(Reader("PatientID").ToString) Then
                                    RelatedLI.SubItems(9).Text = txtPolicyNumber.Text
                                    If txtPolicyNumber.Text = "" Then
                                        RelatedLI.SubItems(9).BackColor = Color.FromArgb(50, 255, 192, 128)
                                    Else
                                        RelatedLI.SubItems(9).BackColor = Color.White
                                    End If
                                    RelatedLI.SubItems(10).Text = txtClaimNumber.Text
                                    If txtClaimNumber.Text = "" Then
                                        RelatedLI.SubItems(10).BackColor = Color.FromArgb(50, 255, 192, 128)
                                    Else
                                        RelatedLI.SubItems(10).BackColor = Color.White
                                    End If

                                    RelatedLI.SubItems(11).Tag = txtComments.Text & vbCrLf & IIf(txtCommentsNew.Text.Trim <> "", vbCrLf & txtCommentsNew.Text.Trim, "")
                                    RelatedLI.SubItems(11).Text = Replace(txtComments.Text, vbCrLf, " ") & vbCrLf & IIf(txtCommentsNew.Text.Trim <> "", vbCrLf & Replace(txtCommentsNew.Text.Trim, vbCrLf, " "), "")
                                    gUpdate_Profile_Log(Val(Reader("PatientID").ToString), PatientLogTypes.tOther, "Insurance Information Updated")
                                End If
                            Next
                        End If
                    Loop
                    Reader.Close()
                    Reader = Nothing
                End If
            End If
        End If
        Me.Close()

    End Sub
End Class