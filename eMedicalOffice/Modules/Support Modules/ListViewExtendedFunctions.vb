

Imports System.Collections.Generic
Imports System.Configuration
Imports System.Drawing
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Windows.Forms


	Public Class ListViewExtendedFunctions
		Private Sub New()
		End Sub
		Private Shared Settings As List(Of ColumnInfo)

		Public Shared Sub saveSettigs(FRM As Form, lv As ListView)
			Try
				Dim config As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
				Settings = New List(Of ColumnInfo)()
				If config.AppSettings.Settings(FRM.Name & "_" & lv.Name) Is Nothing Then
					'If key exists, delete it
					config.AppSettings.Settings.Add(FRM.Name & "_" & lv.Name, "")
				End If


				For Each columnHeader As ColumnHeader In lv.Columns
					Dim columnInfo = New ColumnInfo() 
                    columnInfo.Width =columnHeader.Width
                    columnInfo.DisplayIndex = columnHeader.DisplayIndex
					Settings.Add(columnInfo)
				Next
				Using ms = New MemoryStream()
					Dim bf = New BinaryFormatter()
					bf.Serialize(ms, Settings)
					ms.Position = 0
					Dim buffer = New Byte(CInt(ms.Length) - 1) {}
					ms.Read(buffer, 0, buffer.Length)
					config.AppSettings.Settings(FRM.Name & "_" & lv.Name).Value = Convert.ToBase64String(buffer)
					config.Save(ConfigurationSaveMode.Modified)
				End Using
			Catch generatedExceptionName As Exception
			End Try
		End Sub

		Public Shared Sub loadSettings(FRM As Form, lv As ListView)
            Dim config As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)			
            If config.AppSettings.Settings(FRM.Name & "_" & lv.Name) Is Nothing Then
				Return
			End If
			Try
				Dim columnInfoList As List(Of ColumnInfo)
				Using ms = New MemoryStream(Convert.FromBase64String(config.AppSettings.Settings(FRM.Name & "_" & lv.Name).Value))
					Dim bf = New BinaryFormatter()
					columnInfoList = DirectCast(bf.Deserialize(ms), List(Of ColumnInfo))
				End Using

				Dim c As Integer = 0
				For Each columnHeader As ColumnHeader In lv.Columns
					columnHeader.Width = columnInfoList(c).Width
					columnHeader.DisplayIndex = columnInfoList(c).DisplayIndex
                c += 1
				Next
			Catch
			End Try
		End Sub

		Public Shared Sub AutosizeColumns(listView As ListView)
			listView.BeginUpdate()
			listView.SuspendLayout()
			For Each columnHeader As ColumnHeader In listView.Columns
				columnHeader.Width = -2
			Next
			listView.EndUpdate()
			listView.ResumeLayout()
		End Sub

		Public Shared Sub RestoreColumnLayout(listView As ListView)
			Dim columnIndex As Integer = 0
			listView.BeginUpdate()
			listView.SuspendLayout()
			For Each columnHeader As ColumnHeader In listView.Columns
				columnHeader.Width = -2
				columnHeader.DisplayIndex = columnIndex
				columnIndex += 1
			Next
			listView.EndUpdate()
			listView.ResumeLayout()
		End Sub

		Public Shared Sub HighlightListviewItem(lvView As ListView, Optional noForeColor As Boolean = False, Optional noBackColor As Boolean = False)
			lvView.SuspendLayout()
			Dim itemIndex As Integer = 0
			While itemIndex < lvView.Items.Count
				If noBackColor = False Then
					lvView.Items(itemIndex).BackColor = Nothing
				End If
				If noForeColor = False Then
					lvView.Items(itemIndex).ForeColor = Nothing
				End If
				itemIndex += 1
			End While
			For Each itemSelectedIndex As Integer In lvView.SelectedIndices
				If noBackColor = False Then
					lvView.Items(itemSelectedIndex).BackColor = SystemColors.Highlight
				End If
				If noForeColor = False Then
					lvView.Items(itemSelectedIndex).ForeColor = SystemColors.HighlightText
				End If
			Next
			lvView.ResumeLayout()
		End Sub

		<Serializable> _
		Private Class ColumnInfo
			Public DisplayIndex As Integer
			Public Width As Integer
		End Class
	End Class
