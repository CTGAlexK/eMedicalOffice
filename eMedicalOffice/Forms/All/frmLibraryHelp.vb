Public Class frmLibraryHelp
    Private Sub frmLibraryHelp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gWindow_Settings(Me, ReadWrite.sRead, True)
        SetFont()
        Dim LV As ListViewItem
        LV = ListViewDocuments.Items.Add("OFFICENAME")
        LV.SubItems.Add("Please of treatment Office name")
        LV = ListViewDocuments.Items.Add("OFFICEADDRESS")
        LV.SubItems.Add("Please of treatment Office address")
        LV = ListViewDocuments.Items.Add("OFFICECITYSTATEZIP")
        LV.SubItems.Add("Please of treatment Office City State, Zip Code")
        LV = ListViewDocuments.Items.Add("OFFICEPHONE")
        LV.SubItems.Add("Please of treatment Office phone")
        LV = ListViewDocuments.Items.Add("OFFICEFAX")
        LV.SubItems.Add("Please of treatment Office fax")
        LV = ListViewDocuments.Items.Add("BILLINGOFFICENAME")
        LV.SubItems.Add("Billing Office name")
        LV = ListViewDocuments.Items.Add("BILLINGOFFICEADDRESS")
        LV.SubItems.Add("Billing Office address")
        LV = ListViewDocuments.Items.Add("BILLINGOFFICECITYSTATEZIP")
        LV.SubItems.Add("Billing Office City State, Zip Code")
        LV = ListViewDocuments.Items.Add("BILLINGOFFICEPHONE")
        LV.SubItems.Add("Billing Office phone")
        LV = ListViewDocuments.Items.Add("BILLINGOFFICEFAX")
        LV.SubItems.Add("Billing Office fax")
        LV = ListViewDocuments.Items.Add("PATIENTID")
        LV.SubItems.Add("Patient ID")
        LV = ListViewDocuments.Items.Add("PATIENTNAME")
        LV.SubItems.Add("Patient name")
        LV = ListViewDocuments.Items.Add("PATIENTDOB")
        LV.SubItems.Add("Patient Date Of Birth DOB")
        LV = ListViewDocuments.Items.Add("HOMEADDRESS")
        LV.SubItems.Add("Patient Address Line1 + Line2")
        LV = ListViewDocuments.Items.Add("HOMECITYSTATEZIP")
        LV.SubItems.Add("Patient Address City State, Zip Code")
        LV = ListViewDocuments.Items.Add("HOMEADDRESSFULL")
        LV.SubItems.Add("Patient Address All In One Line")
        LV = ListViewDocuments.Items.Add("CURRENTDATE")
        LV.SubItems.Add("Current Date")
        LV = ListViewDocuments.Items.Add("CURRDATE")
        LV.SubItems.Add("Current Date")
        LV = ListViewDocuments.Items.Add("INSURANCENAME")
        LV.SubItems.Add("Insurance company name")
        LV = ListViewDocuments.Items.Add("INSURANCECOMP")
        LV.SubItems.Add("Insurance company name")
        LV = ListViewDocuments.Items.Add("INSADDRESS")
        LV.SubItems.Add("Insurance company address Line1 + Line2")
        LV = ListViewDocuments.Items.Add("INSCITYSTATEZIP")
        LV.SubItems.Add("Insurance company City State, Zip Code")
        LV = ListViewDocuments.Items.Add("INSPHONE")
        LV.SubItems.Add("Insurance company phone")
        LV = ListViewDocuments.Items.Add("INSFAX")
        LV.SubItems.Add("Insurance company fax")
        LV = ListViewDocuments.Items.Add("CLAIMNUMBER")
        LV.SubItems.Add("Clain Nunmer")
        LV = ListViewDocuments.Items.Add("DATEACC")
        LV.SubItems.Add("Date Of Accident DOA")
        LV = ListViewDocuments.Items.Add("DATEOFACCIDENT")
        LV.SubItems.Add("Date Of Accident DOA")
        LV = ListViewDocuments.Items.Add("MONTHDATEYEAR")
        LV.SubItems.Add("Date Of Accident DOA")
        LV = ListViewDocuments.Items.Add("DATESOFSERVICES")
        LV.SubItems.Add("Date(s) Of Service DOS")
        LV = ListViewDocuments.Items.Add("SERVICEDATE")
        LV.SubItems.Add("Date(s) Of Service DOS")
        LV = ListViewDocuments.Items.Add("DATEOFSERVICE")
        LV.SubItems.Add("Date(s) Of Service DOS")
        LV = ListViewDocuments.Items.Add("BILLNO")
        LV.SubItems.Add("Bill Number")
        LV = ListViewDocuments.Items.Add("BILLDATE")
        LV.SubItems.Add("Bill Date")
        LV = ListViewDocuments.Items.Add("BILLAMOUNT")
        LV.SubItems.Add("Bill Amount")

    End Sub

    Private Sub frmLibraryHelp_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        gWindow_Settings(Me, ReadWrite.sWrite)
    End Sub

    Private Sub SetFont(Optional incr As Integer = 0)
        Dim BaseSize = 8
        If BaseSize + My.Settings.FontSize + incr < 8 Or BaseSize + My.Settings.FontSize + incr > 15 Then Return
        My.Settings.FontSize = My.Settings.FontSize + incr
        My.Settings.Save()
        Dim F = New Font(Font.FontFamily, BaseSize + My.Settings.FontSize, FontStyle.Regular)
        ListViewDocuments.Font = F
    End Sub

    Private Sub ButtonUp_Click(sender As Object, e As EventArgs) Handles ButtonUp.Click
        SetFont(-1)
    End Sub

    Private Sub ButtonDn_Click(sender As Object, e As EventArgs) Handles ButtonDn.Click
        SetFont(1)
    End Sub

    Private Sub ListViewDocuments_DoubleClick(sender As Object, e As EventArgs) Handles ListViewDocuments.DoubleClick
        If ListViewDocuments.SelectedItems.Count = 0 Then
            Exit Sub
        End If
        Dim word As String = ListViewDocuments.SelectedItems(0).Text
        Try
            Clipboard.Clear()
            Clipboard.SetText(word)
            Label1.Text = "RESERVER WORD: " & word & " HAS BEEN COPIED TO CLIPBOARD"
            Label1.Visible = True
            Timer1.Enabled = False
            Timer1.Interval = 5000
            Timer1.Enabled = True
        Catch

        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = True
        Label1.Visible = False
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        If ListViewDocuments.SelectedItems.Count = 0 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub CopyReservedWordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyReservedWordToolStripMenuItem.Click
        ListViewDocuments_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ListViewDocuments.SelectedItems.Count = 0 Then
            MsgBox("Unable to copy." & vbCrLf & "No Reserved Word selected.", MsgBoxStyle.Exclamation, "Oops")
        End If
        ListViewDocuments_DoubleClick(Nothing, Nothing)
    End Sub
End Class