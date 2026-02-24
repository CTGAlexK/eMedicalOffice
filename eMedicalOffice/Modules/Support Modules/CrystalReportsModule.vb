Imports System.IO
Imports System.Reflection
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports log4net

Module CrystalReportsModule
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Public Function SetupCrystalSecurityInfo(ByVal CR As ReportDocument) As Boolean
        Dim retry As Integer = 0
        Dim ConInfo As TableLogOnInfo

        Do While retry < 5
            Try
                ' Set report-level logon info
                CR.SetDatabaseLogon(gSQLServerUID, gSQLServerPassword, gSqlServerName, gSQLServerDatabase)

                ' Setup main report tables
                For Each table As Table In CR.Database.Tables
                    ConInfo = table.LogOnInfo
                    With ConInfo.ConnectionInfo
                        .UserID = gSQLServerUID
                        .Password = gSQLServerPassword
                        .ServerName = gSqlServerName
                        .DatabaseName = gSQLServerDatabase
                    End With
                    table.ApplyLogOnInfo(ConInfo)

                    ' Optional: only change location if not already set
                    If Not table.Location.StartsWith(gSQLServerDatabase & ".dbo.") Then
                        table.Location = gSQLServerDatabase & ".dbo." & GetTableName(table.Location)
                    End If
                Next

                ' Setup subreport tables
                For Each subreport As ReportDocument In CR.Subreports
                    For Each table As Table In subreport.Database.Tables
                        If Not table.Location.ToLowerInvariant().StartsWith("command") Then
                            ConInfo = table.LogOnInfo
                            With ConInfo.ConnectionInfo
                                .UserID = gSQLServerUID
                                .Password = gSQLServerPassword
                                .ServerName = gSqlServerName
                                .DatabaseName = gSQLServerDatabase
                            End With
                            table.ApplyLogOnInfo(ConInfo)

                            If Not table.Location.StartsWith(gSQLServerDatabase & ".dbo.") Then
                                table.Location = gSQLServerDatabase & ".dbo." & GetTableName(table.Location)
                            End If
                        End If
                    Next
                Next

                CR.Refresh()
                Return True ' Success
            Catch ex As Exception
                retry += 1
                DeleteTempFiles()
                Threading.Thread.Sleep(500) ' Small delay before retrying
            End Try
        Loop

        Return False ' Failed after retries
    End Function

    ' Helper to extract actual table name from location
    Private Function GetTableName(ByVal location As String) As String
        ' Handles cases like "MyDB.dbo.MyTable" or just "MyTable"
        If location.Contains(".") Then
            Return location.Substring(location.LastIndexOf(".") + 1)
        End If
        Return location
    End Function
    'Public Function SetupCrystalSecurityInfo(ByVal CR As ReportDocument) As Boolean
    '    Dim intCounter As Integer
    '    Dim ConInfo As New TableLogOnInfo
    '    Dim SR As ReportDocument
    '    Dim retry As Integer
    '    Do While retry < 5
    '        CR.SetDatabaseLogon(gSQLServerUID, gSQLServerPassword, gSqlServerName, gSQLServerDatabase)
    '        Try
    '            'For Each tbl In CR.Database.Tables
    '            '    ConInfo = tbl.LogOnInfo
    '            '    ConInfo.ConnectionInfo.UserID = gSQLServerUID
    '            '    ConInfo.ConnectionInfo.Password = gSQLServerPassword
    '            '    ConInfo.ConnectionInfo.ServerName = gSqlServerName
    '            '    ConInfo.ConnectionInfo.DatabaseName = gSQLServerDatabase
    '            '    'tbl.LogOnInfo.ConnectionInfo.UserID = gSQLServerUID
    '            '    'tbl.LogOnInfo.ConnectionInfo.Password = gSQLServerPassword
    '            '    'tbl.LogOnInfo.ConnectionInfo.ServerName = gSqlServerName
    '            '    'tbl.LogOnInfo.ConnectionInfo.DatabaseName = gSQLServerDatabase
    '            '    tbl.ApplyLogOnInfo(ConInfo)
    '            '    Dim tblNames = tbl.Location.ToString().Split(".")
    '            '    Dim tblName = tblNames(tblNames.Count - 1)
    '            '    tbl.Location = gSQLServerDatabase & ".dbo." & tblName
    '            'Next
    '            For intCounter = 0 To CR.Database.Tables.Count - 1
    '                ConInfo = CR.Database.Tables(intCounter).LogOnInfo
    '                ConInfo.ConnectionInfo.UserID = gSQLServerUID
    '                ConInfo.ConnectionInfo.Password = gSQLServerPassword
    '                ConInfo.ConnectionInfo.ServerName = gSqlServerName
    '                ConInfo.ConnectionInfo.DatabaseName = gSQLServerDatabase
    '                CR.Database.Tables(intCounter).LogOnInfo.ConnectionInfo.UserID = gSQLServerUID
    '                CR.Database.Tables(intCounter).LogOnInfo.ConnectionInfo.Password = gSQLServerPassword
    '                CR.Database.Tables(intCounter).LogOnInfo.ConnectionInfo.ServerName = gSqlServerName
    '                CR.Database.Tables(intCounter).LogOnInfo.ConnectionInfo.DatabaseName = gSQLServerDatabase
    '                Application.DoEvents()
    '                CR.Database.Tables(intCounter).ApplyLogOnInfo(ConInfo)
    '                Application.DoEvents()
    '                CR.Database.Tables(intCounter).Location = gSQLServerDatabase & ".dbo." & CR.Database.Tables(intCounter).Location
    '            Next
    '            CR.Refresh()
    '            For Each SR In CR.Subreports
    '                'For Each tbl In CR.Database.Tables
    '                '    If tbl.Location <> "command" Then
    '                '        ConInfo = tbl.LogOnInfo
    '                '        ConInfo.ConnectionInfo.UserID = gSQLServerUID
    '                '        ConInfo.ConnectionInfo.Password = gSQLServerPassword
    '                '        ConInfo.ConnectionInfo.ServerName = gSqlServerName
    '                '        ConInfo.ConnectionInfo.DatabaseName = gSQLServerDatabase
    '                '        'tbl.LogOnInfo.ConnectionInfo.UserID = gSQLServerUID
    '                '        'tbl.LogOnInfo.ConnectionInfo.Password = gSQLServerPassword
    '                '        'tbl.LogOnInfo.ConnectionInfo.ServerName = gSqlServerName
    '                '        'tbl.LogOnInfo.ConnectionInfo.DatabaseName = gSQLServerDatabase
    '                '        tbl.ApplyLogOnInfo(ConInfo)
    '                '        Dim tblNames = tbl.Location.ToString().Split(".")
    '                '        Dim tblName = tblNames(tblNames.Count - 1)
    '                '        tbl.Location = gSQLServerDatabase & ".dbo." & tblName
    '                '    End If
    '                'Next
    '                For intCounter = 0 To SR.Database.Tables.Count - 1
    '                    If SR.Database.Tables(intCounter).Location <> "command" Then
    '                        ConInfo = SR.Database.Tables(intCounter).LogOnInfo
    '                        ConInfo.ConnectionInfo.UserID = gSQLServerUID
    '                        ConInfo.ConnectionInfo.Password = gSQLServerPassword
    '                        ConInfo.ConnectionInfo.ServerName = gSqlServerName
    '                        ConInfo.ConnectionInfo.DatabaseName = gSQLServerDatabase
    '                        SR.Database.Tables(intCounter).LogOnInfo.ConnectionInfo.UserID = gSQLServerUID
    '                        SR.Database.Tables(intCounter).LogOnInfo.ConnectionInfo.Password = gSQLServerPassword
    '                        SR.Database.Tables(intCounter).LogOnInfo.ConnectionInfo.ServerName = gSqlServerName
    '                        SR.Database.Tables(intCounter).LogOnInfo.ConnectionInfo.DatabaseName = gSQLServerDatabase
    '                        SR.Database.Tables(intCounter).ApplyLogOnInfo(ConInfo)
    '                        SR.Database.Tables(intCounter).Location = gSQLServerDatabase & ".dbo." & SR.Database.Tables(intCounter).Location
    '                    End If
    '                Next

    '            Next
    '            Exit Do
    '        Catch ex As Exception
    '            retry = retry + 1
    '        End Try
    '        DeleteTempFiles()
    '    Loop
    '    SetupCrystalSecurityInfo = True
    'End Function

    Public Sub CloseReport(cr As ReportDocument)
        Try
            Dim fname As String
            If cr Is Nothing Then
                Exit Sub
            End If
            Dim Secs As Sections = cr.ReportDefinition.Sections
            For Each Sec As Section In Secs
                Dim ROs As ReportObjects = Sec.ReportObjects
                For Each RO As ReportObject In ROs
                    If RO.Kind = ReportObjectKind.SubreportObject Then
                        Dim SRO As SubreportObject = CType(RO, SubreportObject)
                        Dim subReportDocument As ReportDocument = SRO.OpenSubreport(SRO.SubreportName)
                        subReportDocument.Close()
                        subReportDocument.Dispose()
                    End If
                Next
            Next
            fname = cr.FileName.Replace("rassdk://", "")
            cr.Close()
            cr.Dispose()
            GC.Collect()
            IO.File.Delete(fname)
        Catch ex As Exception
        End Try
    End Sub
End Module
