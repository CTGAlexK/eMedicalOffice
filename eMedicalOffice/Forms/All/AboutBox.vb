Imports System.IO
Imports System.Reflection

Public NotInheritable Class frmAboutBox

    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set the title of the form.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Text = String.Format("About {0}", ApplicationTitle)
        LabelProductName.Text = My.Application.Info.ProductName
        LabelVersion.Text = "Version: " & My.Application.Info.Version.ToString
        LabelCopyright.Text = "Copyright: " & My.Application.Info.Copyright
        LabelCompanyName.Text = "Company: " & My.Application.Info.CompanyName
        TextBoxDescription.Text = My.Application.Info.Description
        lblCurrentOffice.Text = "Current Office: " & gOfficeName
        lblCurrentOfficeType.Text = "Office Type: " & gOfficeTypeIDName

        LabelVersionBildDate.Text = "Build Date: " & gGetAssemblyDate()
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub LogoPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBoxDescription_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Interaction.Shell("MSINFO32.EXE", AppWinStyle.NormalFocus)
    End Sub

End Class