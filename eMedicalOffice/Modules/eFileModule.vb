Imports System.IO
Imports System.Text

Module eFileModule
    Public Sub eFileBill(parentForm As Form, BillIds() As String)
        frmEFiling.BillIds = BillIds
        If frmEFiling.ShowDialog(parentForm) = DialogResult.OK Then

        End If
        frmEFiling.Dispose()
    End Sub


End Module
