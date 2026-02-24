Public Class frmSecuritySettings
    Private LoadingInd As Boolean

    Private Sub frmSecuritySettings_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gWindow_Settings(Me, ReadWrite.sWrite)
    End Sub
    Private Sub frmSecuritySettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gWindow_Settings(Me, ReadWrite.sRead)
        LoadingInd = True
        Load_Data()
        LoadingInd = False
        Timer1.Enabled = True
        FpSpread1_Sheet1.RowHeader.Visible = False


    End Sub
    Private Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim Arlst As New ArrayList
        Dim ArlstData As New ArrayList
        Dim cmbocell As New FarPoint.Win.Spread.CellType.ComboBoxCellType
        SQL = "SELECT PositionID ,Description FROM Positions"
        Reader = gSQLGetDataReader(SQL)
        If Not Reader Is Nothing Then

            Do Until Reader.Read = False
                Arlst.Add(Reader("PositionID").ToString & " - " & Reader("Description").ToString)
                ArlstData.Add(Reader("PositionID").ToString)
            Loop

            cmbocell.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData
            cmbocell.Items = Arlst.ToArray(GetType(String))
            cmbocell.ItemData = ArlstData.ToArray(GetType(String))
            cmbocell.AutoSearch = FarPoint.Win.AutoSearch.SingleCharacter
            cmbocell.Editable = False
            cmbocell.MaxDrop = 10
            FpSpread1.ActiveSheet.Columns(2).CellType = cmbocell
        End If
        cmbocell = New FarPoint.Win.Spread.CellType.ComboBoxCellType
        Arlst.Insert(0, "")
        ArlstData.Insert(0, "0")
        cmbocell.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData
        cmbocell.Items = Arlst.ToArray(GetType(String))
        cmbocell.ItemData = ArlstData.ToArray(GetType(String))
        cmbocell.AutoSearch = FarPoint.Win.AutoSearch.SingleCharacter
        cmbocell.Editable = False
        cmbocell.MaxDrop = 10
        FpSpread1.ActiveSheet.Columns(4).CellType = cmbocell
        ' Search Criterias
        cboGroup.Items.Add(New ValueDescription(-1, "All"))
        SQL = "SELECT     FunctionGroupID, Description FROM SecurityFunctionsGroup ORDER BY Description"
        Reader = gSQLGetDataReader(SQL)
        If Not Reader Is Nothing Then
            Do Until Reader.Read = False
                cboGroup.Items.Add(New ValueDescription(Reader("FunctionGroupID").ToString, Reader("Description").ToString))
            Loop
        End If
        cboGroup.SelectedIndex = 0

        cboAccessType.Items.Add(New ValueDescription(-1, "All"))
        SQL = "SELECT     ID, Description FROM SecurityLevelTypes "
        Reader = gSQLGetDataReader(SQL)
        If Not Reader Is Nothing Then
            Do Until Reader.Read = False
                cboAccessType.Items.Add(New ValueDescription(Reader("ID").ToString, Reader("Description").ToString))
            Loop
        End If
        cboAccessType.SelectedIndex = 0


        cboSecurityLevel.Items.Add(New ValueDescription(-1, "All"))
        SQL = "SELECT     PositionID, Description FROM         Positions "
        Reader = gSQLGetDataReader(SQL)
        If Not Reader Is Nothing Then
            Do Until Reader.Read = False
                cboSecurityLevel.Items.Add(New ValueDescription(Reader("PositionID").ToString, Reader("Description").ToString))
            Loop
        End If
        cboSecurityLevel.SelectedIndex = 0

        cboActive.Items.Add(New ValueDescription(-1, "All"))
        cboActive.Items.Add(New ValueDescription(1, "Active"))
        cboActive.Items.Add(New ValueDescription(0, "Not Active"))
        cboActive.SelectedIndex = 0


    End Sub
    Private Sub Load_Functions()
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        If LoadingInd = True Then Exit Sub
        FpSpread1.ActiveSheet.RowCount = 0
        SQL = "SELECT     FunctionID, FunctionName, SecurityLevel, SecurityLevel1, SecurityLevelType, Description AS FunctionGroup , ActiveInd FROM SecurityFunctions INNER JOIN SecurityFunctionsGroup ON SecurityFunctions.FunctionGroup = SecurityFunctionsGroup.FunctionGroupID Where OfficeID=" & gOfficeID & " "
        If cboGroup.SelectedIndex > 0 Then
            SQL &= " AND FunctionGroup = " & CType(cboGroup.SelectedItem, ValueDescription).Value
        End If
        If cboAccessType.SelectedIndex > 0 Then
            SQL &= " AND SecurityLevelType = " & CType(cboAccessType.SelectedItem, ValueDescription).Value
        End If
        If cboActive.SelectedIndex > 0 Then
            SQL &= " AND ActiveInd = " & CType(cboActive.SelectedItem, ValueDescription).Value
        End If
        If cboSecurityLevel.SelectedIndex > 0 Then
            SQL &= " AND SecurityLevel = " & CType(cboSecurityLevel.SelectedItem, ValueDescription).Value
        End If

        If txtFunction.Text <> "" Then
            SQL &= " AND FunctionName Like '%" & txtFunction.Text & "%'"
        End If


        SQL &= " order by FunctionGroup, FunctionName"

        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            With FpSpread1.ActiveSheet
                .RowCount = .RowCount + 1
                .SetText(.RowCount - 1, 0, Reader("FunctionGroup").ToString)
                .SetText(.RowCount - 1, 1, Reader("FunctionName").ToString)
                .SetTag(.RowCount - 1, 1, Reader("FunctionID").ToString)
                .SetValue(.RowCount - 1, 2, Reader("SecurityLevel").ToString)
                .SetValue(.RowCount - 1, 3, Reader("SecurityLevelType").ToString)
                .SetValue(.RowCount - 1, 4, Reader("SecurityLevel1").ToString)
                .SetText(.RowCount - 1, 5, Reader("ActiveInd").ToString)
                If Val(Reader("ActiveInd").ToString) = 0 Then
                    .Rows(.RowCount - 1).BackColor = Color.LightSalmon
                End If
            End With
        Loop
        Reader.Close()
        Reader = Nothing

    End Sub
    Private Sub ButtonUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonUpdate.Click
        Dim R As Integer
        Dim SQL As String
        With FpSpread1.ActiveSheet
            .Cells(0, 2, FpSpread1.ActiveSheet.RowCount - 1, 5).Locked = True
            For R = 0 To .RowCount - 1
                SQL = "UPDATE SecurityFunctions "
                SQL &= " SET "
                SQL &= " SecurityLevel = " & Val(.GetValue(R, 2).ToString)
                SQL &= " ,SecurityLevelType=" & Val(.GetValue(R, 3).ToString)
                SQL &= " ,SecurityLevel1 = " & Val(.GetValue(R, 4).ToString)
                If .GetText(R, 5).ToString.ToUpper = "TRUE" Then
                    SQL &= " ,ActiveInd = 1 "
                Else
                    SQL &= " ,ActiveInd = 0 "
                End If

                SQL &= " WHERE FunctionID = " & Val(.GetTag(R, 1).ToString)
                gSQLUpdateData(SQL)
            Next
        End With

        ButtonUpdate.Enabled = False
        ButtonCancel.Enabled = False
        ButtonEdit.Enabled = True
        Panel3.Enabled = True
        Load_Functions()
    End Sub
    Private Sub cboGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboGroup.SelectedIndexChanged
        Load_Functions()
    End Sub

    Private Sub txtFunction_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFunction.TextChanged
        Load_Functions()
    End Sub

    Private Sub cboSecurityLevel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSecurityLevel.SelectedIndexChanged
        Load_Functions()
    End Sub

    Private Sub cboAccessType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAccessType.SelectedIndexChanged
        Load_Functions()
    End Sub

    Private Sub cboActive_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboActive.SelectedIndexChanged
        Load_Functions()
    End Sub

    Private Sub ButtonEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEdit.Click
        FpSpread1.ActiveSheet.Cells(0, 2, FpSpread1.ActiveSheet.RowCount - 1, 5).Locked = False
        ButtonUpdate.Enabled = True
        ButtonCancel.Enabled = True
        ButtonEdit.Enabled = False
        Panel3.Enabled = False
    End Sub

    Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
        Load_Functions()
        FpSpread1.ActiveSheet.Cells(0, 2, FpSpread1.ActiveSheet.RowCount - 1, 5).Locked = True
        ButtonUpdate.Enabled = False
        ButtonCancel.Enabled = False
        ButtonEdit.Enabled = True
        Panel3.Enabled = True
    End Sub



    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Timer1.Interval = 500
        Load_Functions()
    End Sub

    Private Sub FpSpread1_CellClick(ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs) Handles FpSpread1.CellClick

    End Sub

    Private Sub FpSpread1_CellDoubleClick(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs) Handles FpSpread1.CellDoubleClick
        If ButtonEdit.Enabled Then ButtonEdit_Click(Nothing, Nothing)
    End Sub
End Class