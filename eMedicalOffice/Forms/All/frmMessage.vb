Public Class frmMessage

    Private Sub frmMessage_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gListview_Settings(Me, ListViewMessages, ReadWrite.sWrite)
        gListview_Settings(Me, ListViewRecepients, ReadWrite.sWrite)
        gWindow_Settings(Me, ReadWrite.sWrite)
    End Sub

    Private Sub frmMessage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gWindow_Settings(Me, ReadWrite.sRead)
        gListview_Settings(Me, ListViewMessages, ReadWrite.sRead)
        gListview_Settings(Me, ListViewRecepients, ReadWrite.sRead)
        Application.DoEvents()
        Loading = True
        Load_Data()
        TextBox1.Text = "Message From Administrator"
        DateTimePickerFrom.Value = DateAdd(DateInterval.Month, 1, Date.Today)
        DateTimePickerTo.Value = Date.Today
        DateTimePickerFrom.Checked = False
        DateTimePickerTo.Checked = False
        Loading = False
        Timer1.Enabled = True
    End Sub

    Private Sub Load_Data()
        Dim Rs As SqlClient.SqlDataReader
        Dim SQL As String

        ComboBox1.Items.Add(New ValueDescription(0, "Send To All"))
        ComboBox2.Items.Add(New ValueDescription(0, "Show All"))
        SQL = "SELECT * FROM Positions Where ShowLicences=0 order by PositionID"
        Rs = gSQLGetDataReader(SQL)
        Do Until Rs.Read = False
            ComboBox1.Items.Add(New ValueDescription(Val(Rs("PositionID").ToString), Rs("Description").ToString))
            ComboBox2.Items.Add(New ValueDescription(Val(Rs("PositionID").ToString), Rs("Description").ToString))
        Loop
        ComboBoxReply.Items.Add("All")
        ComboBoxReply.Items.Add("No")
        ComboBoxReply.Items.Add("Yes")
        ComboBoxReply.SelectedIndex = 0
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
    End Sub

    Private Sub Load_Employees(Optional ByVal PositionID As Integer = 0)
        Dim Rs As SqlClient.SqlDataReader
        Dim SQL As String
        Dim LI As ListViewItem
        ListView1.Items.Clear()
        If PositionID = 0 Then
            SQL = "SELECT     EmpID, Fname +' '+ Lname as EmpName FROM         Employees WHERE     (PositionID <> 5) order by PositionID, EmpName"
        Else
            SQL = "SELECT     EmpID, Fname +' '+ Lname as EmpName FROM         Employees WHERE     PositionID = " & PositionID & " order by EmpName"
        End If
        Rs = gSQLGetDataReader(SQL)
        Do Until Rs.Read = False
            LI = ListView1.Items.Add(Rs("EmpName").ToString)
            LI.Tag = Val(Rs("EmpID").ToString)
        Loop
        Count_Recipients()
    End Sub

    Private Sub Load_Employees_Log(Optional ByVal PositionID As Integer = 0)
        Dim Rs As SqlClient.SqlDataReader
        Dim SQL As String
        Dim LI As ListViewItem
        ComboBox3.Items.Clear()
        ComboBox3.Items.Add(New ValueDescription(0, "Show All"))
        If PositionID = 0 Then
            SQL = "SELECT     EmpID, Fname +' '+ Lname as EmpName FROM         Employees WHERE     (PositionID <> 5) order by PositionID, EmpName"
        Else
            SQL = "SELECT     EmpID, Fname +' '+ Lname as EmpName FROM         Employees WHERE     PositionID = " & PositionID & " order by EmpName"
        End If
        Rs = gSQLGetDataReader(SQL)
        Do Until Rs.Read = False
            ComboBox3.Items.Add(New ValueDescription(Rs("EmpID").ToString, Rs("EmpName").ToString))
        Loop
        ComboBox3.SelectedIndex = 0
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex = -1 Then
            ListView1.Items.Clear()
            Exit Sub
        End If
        Load_Employees(CType(ComboBox1.SelectedItem, ValueDescription).Value)
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click
        Dim LI As ListViewItem
        For Each LI In ListView1.Items
            LI.Checked = True
        Next
    End Sub

    Private Sub SelectNoneToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectNoneToolStripMenuItem.Click
        Dim LI As ListViewItem
        For Each LI In ListView1.Items
            LI.Checked = False
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSendMessage.Click
        Dim LI As ListViewItem
        Dim SQL As String
        If ListView1.CheckedItems.Count = 0 Then
            MsgBox("Unable to send message." & vbCrLf & vbCrLf & "No recipient(s) selected.", MsgBoxStyle.Exclamation)
            ListView1.Focus()
            Exit Sub
        End If
        If TextBox1.Text.Trim = "" Then
            TextBox1.Text = "Message From Administrator"
        End If
        If TextBox2.Text.Trim = "" Then
            MsgBox("Unable to send message." & vbCrLf & vbCrLf & "No message body specified.", MsgBoxStyle.Exclamation)
            TextBox2.Focus()
            Exit Sub
        End If
        Dim Priority As Integer
        If CheckBoxPopUpMessage.Checked Then Priority = 2

        Dim MsgID As Integer

        SQL = "INSERT INTO Messages (Priority, MessageTitle, MessageBody, CreatedBy, CreatedDT, ResponseRequired) VALUES(" & Priority & ", '" & TextBox1.Text.Trim.ToSafeSQLString() & "','" & TextBox2.Text.Trim.ToSafeSQLString() & "'," & gCurrentEmployee.EmpID & ", getdate(), " & Math.Abs(Val(chkResponseRequired.Checked)) & ")"
        gSQLUpdateData(SQL)
        MsgID = gSQLGetSingleValue("Select IDENT_CURRENT('Messages')")
        For Each LI In ListView1.CheckedItems
            SQL = "INSERT INTO MessagesRecipients (MessageID, ToID) VALUES(" & MsgID & ", " & Val(LI.Tag) & ")"
            gSQLUpdateData(SQL)
        Next
        MsgBox("Administrative Message has been sent.", MsgBoxStyle.Information)
        'If MsgBox("Message Sent." & vbCrLf & vbCrLf & vbCrLf & "Reset Message System?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        'TextBox1.Text = "Message From Administrator"
        'TextBox2.Text = ""
        'ComboBox1.SelectedIndex = 0
        'For Each LI In ListView1.CheckedItems
        'LI.Checked = False
        'Next
        'End If
        Count_Recipients()
    End Sub

    Private Sub Count_Recipients()
        LabelCheckedCount.Text = ListView1.CheckedItems.Count & " Recipients Checked"
    End Sub

    Private Sub ListView1_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles ListView1.ItemChecked
        Count_Recipients()
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.SelectedIndex = -1 Then
            ComboBox3.Items.Clear()
            Exit Sub
        End If
        Load_Employees_Log(CType(ComboBox2.SelectedItem, ValueDescription).Value)
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        Load_Messages()
    End Sub

    Private Loading As Boolean

    Private Sub Load_Messages()
        Dim SQL As String
        Dim LI As ListViewItem
        Dim Reader As SqlClient.SqlDataReader
        If Loading Then Exit Sub
        ListViewMessages.Items.Clear()
        SQL = "SELECT  DISTINCT   Messages.MessageID, Messages.MessageTitle, Messages.MessageBody, Messages.CreatedDT, Messages.ResponseRequired FROM Messages INNER JOIN MessagesRecipients ON Messages.MessageID = MessagesRecipients.MessageID WHERE 1=1 "

        If ComboBox3.SelectedIndex > 0 Then
            SQL &= " AND MessagesRecipients.ToID = " & CType(ComboBox3.SelectedItem, ValueDescription).Value
        End If

        If txtMessageFilter.Text.Trim <> "" Then
            SQL &= " AND (MessageTitle like '%" & txtMessageFilter.Text.Trim & "%' or MessageBody like '%" & txtMessageFilter.Text.Trim & "%' or Response like '%" & txtMessageFilter.Text.Trim & "%') "
        End If
        If DateTimePickerFrom.Checked Then
            SQL &= " and DATEDIFF(d, Messages.CreatedDT, '" & DateTimePickerFrom.Value.Date & "')<=0  "
        End If
        If DateTimePickerTo.Checked Then
            SQL &= " and DATEDIFF(d, Messages.CreatedDT, '" & DateTimePickerTo.Value.Date & "')>=0 "
        End If
        If ComboBoxReply.SelectedIndex > 0 Then
            SQL &= " and isnull(ResponseRequired,0) = " & ComboBoxReply.SelectedIndex - 1
        End If

        SQL &= " order by MessageID Desc"
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub

        Do Until Reader.Read = False
            LI = ListViewMessages.Items.Add(CDate(Reader("CreatedDT").ToString).ToString("MM/dd/yyyy"))
            LI.UseItemStyleForSubItems = False
            LI.Tag = Reader("MessageID").ToString
            If Val(Reader("ResponseRequired").ToString) = 1 Then
                LI.SubItems.Add("Y")
                LI.SubItems(1).BackColor = Color.LightSalmon
            Else
                LI.SubItems.Add("N")
                LI.SubItems(1).BackColor = Color.White
            End If
            LI.SubItems.Add(Reader("MessageTitle").ToString)
            LI.SubItems(2).Tag = Reader("MessageBody").ToString
        Loop
        If ListViewMessages.Items.Count > 0 Then
            ListViewMessages.Items(0).Selected = True
            ListViewMessages.Items(0).EnsureVisible()
            ListViewMessages_SelectedIndexChanged(Nothing, Nothing)
        Else
            Clear_Log()
        End If
    End Sub

    Private Sub ListViewMessages_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewMessages.SelectedIndexChanged
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim SI As ListViewItem.ListViewSubItem
        Dim SQL As String
        Clear_Log()
        If ListViewMessages.SelectedItems.Count = 0 Then Exit Sub
        LI = ListViewMessages.SelectedItems(0)
        TextBoxTitle.Text = LI.SubItems(2).Text
        txtMessage.Text = LI.SubItems(2).Tag
        SQL = "SELECT     MessagesRecipients.ID, MessagesRecipients.MessageID, MessagesRecipients.ToID, MessagesRecipients.ConfirmedDT, MessagesRecipients.Response, Employees.Fname + ' ' + Employees.Lname AS EmpName FROM MessagesRecipients INNER JOIN Employees ON MessagesRecipients.ToID = Employees.EmpID WHERE MessageID = " & Val(ListViewMessages.SelectedItems(0).Tag) & " Order By Employees.Fname, Employees.Lname "
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            LI = ListViewRecepients.Items.Add(Reader("EmpName").ToString)
            LI.UseItemStyleForSubItems = False
            If IsDate(Reader("ConfirmedDT").ToString) = True Then
                SI = LI.SubItems.Add(CDate(Reader("ConfirmedDT").ToString).ToString("MM/dd/yyyy"))
            Else
                SI = LI.SubItems.Add("")
                SI.BackColor = Color.LightSalmon
            End If
            SI = LI.SubItems.Add(Reader("Response").ToString)
            LI.ToolTipText = Reader("Response").ToString
            If Reader("Response").ToString.Trim = "" And ListViewMessages.SelectedItems(0).SubItems(1).Text = "Y" Then
                SI.BackColor = Color.LightSalmon
            End If
        Loop

        If ListViewRecepients.Items.Count > 0 Then
            ListViewRecepients.Items(0).Selected = True
            ListViewRecepients.Items(0).EnsureVisible()
            ListViewRecepients_SelectedIndexChanged(Nothing, Nothing)
        End If

    End Sub

    Private Sub Clear_Log()
        TextBoxTitle.Text = ""
        txtMessage.Text = ""
        TextBoxReply.Text = ""
        ListViewRecepients.Items.Clear()
    End Sub

    Private Sub ListViewRecepients_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewRecepients.SelectedIndexChanged
        If ListViewRecepients.Items.Count = 0 Then
            TextBoxReply.Text = ""
        Else
            TextBoxReply.Text = ListViewRecepients.Items(0).SubItems(2).Text
        End If

    End Sub

    Private Sub txtMessageFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMessageFilter.TextChanged
        Timer2.Enabled = False
        Timer2.Enabled = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Interval = 10
        Me.Opacity += 0.02
        If Me.Opacity >= 1 Then
            Timer1.Enabled = False
            Load_Messages()
        End If

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        LabelCheckedCount.Visible = TabControl1.SelectedIndex = 0
        ButtonSendMessage.Visible = TabControl1.SelectedIndex = 0
        chkResponseRequired.Visible = TabControl1.SelectedIndex = 0
        ButtonDeleteMessage.Visible = TabControl1.SelectedIndex > 0

    End Sub

    Private Sub ButtonDeleteMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDeleteMessage.Click
        Dim LI As ListViewItem
        If ListViewMessages.SelectedItems.Count = 0 Then
            MsgBox("Unable to process your request." & vbCrLf & "No message selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        LI = ListViewMessages.SelectedItems(0)
        If MsgBox("Please confirm you want to delete message:" & vbCrLf & vbCrLf & "Date: " & LI.Text & vbCrLf & vbCrLf & "Title: " & LI.SubItems(2).Text & vbCrLf & vbCrLf & "Body: " & vbCrLf & LI.SubItems(2).Tag, MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        gSQLUpdateData("delete from Messages where MessageID = " & LI.Tag)
        gSQLUpdateData("delete from MessagesRecipients where MessageID = " & LI.Tag)
        ListViewMessages.Items.Remove(LI)
        If ListViewMessages.SelectedItems.Count > 0 Then
            ListViewMessages.SelectedItems(0).Selected = True
            ListViewMessages.SelectedItems(0).EnsureVisible()
            ListViewMessages_SelectedIndexChanged(Nothing, Nothing)

        ElseIf ListViewMessages.Items.Count > 0 Then
            ListViewMessages.Items(0).Selected = True
            ListViewMessages.Items(0).EnsureVisible()
            ListViewMessages_SelectedIndexChanged(Nothing, Nothing)
        End If

    End Sub

    Private Sub DateTimePickerFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePickerFrom.ValueChanged
        Load_Messages()
    End Sub

    Private Sub DateTimePickerTo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePickerTo.ValueChanged
        Load_Messages()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Loading = True
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
        ComboBoxReply.SelectedIndex = 0
        txtMessageFilter.Text = ""
        DateTimePickerFrom.Checked = False
        DateTimePickerTo.Checked = False
        Loading = False
        Load_Messages()
    End Sub

    Private Sub ComboBoxReply_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxReply.SelectedIndexChanged
        Load_Messages()
    End Sub

    Private Sub CheckBoxPopUpMessage_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxPopUpMessage.CheckedChanged
        'If CheckBoxPopUpMessage.Checked Then
        '    chkResponseRequired.Enabled = False
        '    chkResponseRequired.Checked = False
        'Else
        '    chkResponseRequired.Enabled = True
        'End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Timer2.Enabled = False
        Load_Messages()
    End Sub

End Class