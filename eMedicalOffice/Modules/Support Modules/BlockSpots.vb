Imports System.Reflection
Imports System.Text
Imports log4net

Module BlockSpots
    Private ReadOnly log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

    Public Structure SpotInfo
        Public ID As Integer
        Public ScheduleDateTime As DateTime
        Public insertedBy As String
        Public Comments As String
        Public ToolTip As String
    End Structure

    Public Function GetSpotLockedID(DT As DateTime, DiagID As Integer) As SpotInfo
        Dim Reader As SqlClient.SqlDataReader
        Dim Sql As StringBuilder = New StringBuilder
        Dim ret As SpotInfo = New SpotInfo
        Try
            Sql.Append(" Select ScheduleBlock.ID, ScheduleBlock.ScheduleDateTime, ScheduleBlock.InsertedDT, ScheduleBlock.insertedBy, ")
            Sql.Append(" Employees.Fname + ' ' + Employees.Lname AS EmpName, ScheduleBlock.DiagID, ScheduleBlock.Comments ")
            Sql.Append(" From ScheduleBlock INNER Join Employees On ScheduleBlock.insertedBy = Employees.EmpID ")
            Sql.Append(" WHERE Removedby is null and ScheduleBlock.OfficeID = " & gOfficeID & " and ScheduleDateTime = '" & DT & "' and ScheduleBlock.DiagID = " & DiagID)
            Reader = gSQLGetDataReader(Sql.ToString())
            If Not Reader Is Nothing And Reader.HasRows = True Then
                Reader.Read()
                ret.ID = Reader("ID")
                ret.ScheduleDateTime = Reader("ScheduleDateTime")
                ret.insertedBy = Reader("insertedBy")
                ret.Comments = Reader("Comments")
                ret.ToolTip = "" & Reader("Comments").ToString()
                ret.ToolTip = ret.ToolTip & vbCrLf & "" & Reader("EmpName").ToString()
            End If
        Catch ex As Exception
            log.Error(ex)
        End Try
        Return ret
    End Function

    Public Function GetBlockedSpots(DT As DateTime) As SqlClient.SqlDataReader
        Dim Sql As StringBuilder = New StringBuilder
        Try
            Sql.Append(" Select ScheduleBlock.ID, ScheduleBlock.ScheduleDateTime, ScheduleBlock.InsertedDT, ScheduleBlock.insertedBy, ")
            Sql.Append(" Employees.Fname + ' ' + Employees.Lname AS EmpName, ScheduleBlock.DiagID, ScheduleBlock.Comments ")
            Sql.Append(" From ScheduleBlock INNER Join Employees On ScheduleBlock.insertedBy = Employees.EmpID ")
            Sql.Append(" WHERE Removedby is null and ScheduleBlock.OfficeID = " & gOfficeID & " and ScheduleDateTime > '" & DT.ToShortDateString & " 00:00" & "' and ScheduleDateTime < '" & DT.ToShortDateString & " 23:59" & "' ")
            Return gSQLGetDataReader(Sql.ToString())
        Catch ex As Exception
            log.Error(ex)
            Return Nothing
        End Try
    End Function

End Module