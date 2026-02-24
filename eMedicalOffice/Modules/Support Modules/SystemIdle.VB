Imports System.Runtime.InteropServices

Module SystemIdle
    Public Declare Function GetTickCount Lib "kernel32" () As Integer
    Public Declare Function GetLastInputInfo Lib "user32.dll" (ByRef plii As PLastInputInfo) As Boolean
    Public Structure PLastInputInfo
        Public cbSize As Integer
        Public dwTime As Integer
    End Structure


    Public Function GetIdleTime() As Integer
        Dim oPLII As PLastInputInfo
        Dim iTime As Integer = GetTickCount()
        oPLII.cbSize = Marshal.SizeOf(oPLII)
        If GetLastInputInfo(oPLII) Then
            Dim iLast As Integer = oPLII.dwTime
            On Error Resume Next
            Return iTime - iLast
        Else
            Return 0     ' Didn't read
        End If
    End Function
End Module

