Public Module Settings

    Public Enum ReadWrite
        sRead = 1
        sWrite = 2
    End Enum

    Public Sub gDatabaseSettingsRegistery(RW As ReadWrite)
        gConnectionString = ""
        gPacsConnectionString = ""

        If gMultiOfficeMode Then
            If (RW = ReadWrite.sRead) Then

                gSqlServerName = GetSetting(My.Application.Info.ProductName, "Settings" & "\" & gOfficeID,
                                            "SQLServerName", "")
                gSQLServerDatabase = GetSetting(My.Application.Info.ProductName, "Settings" & "\" & gOfficeID,
                                                "SQLServerDatabase", "")
                gSQLServerUID = GetSetting(My.Application.Info.ProductName, "Settings" & "\" & gOfficeID, "SQLServerUID",
                                           "")
                gSQLServerPassword = gEncrypt(GetSetting(My.Application.Info.ProductName, "Settings" & "\" & gOfficeID,
                                                         "SQLServerPassword", ""))
                gPACSSQLServerName = GetSetting(My.Application.Info.ProductName, "Settings" & "\" & gOfficeID,
                                                "PACSSQLServerName", "")
                gPACSSQLServerDatabase = GetSetting(My.Application.Info.ProductName, "Settings" & "\" & gOfficeID,
                                                    "PACSSQLServerDatabase", "")
                gPACSSQLServerUID = GetSetting(My.Application.Info.ProductName, "Settings" & "\" & gOfficeID,
                                               "PACSSQLServerUID", "")
                gPACSSQLServerPassword = gEncrypt(GetSetting(My.Application.Info.ProductName,
                                                             "Settings" & "\" & gOfficeID, "PACSSQLServerPassword", ""))
                gPACSPath = GetSetting(My.Application.Info.ProductName, "Settings" & "\" & gOfficeID, "PACSPath", "")
                If gSqlServerName <> "" And gSQLServerDatabase <> "" And gSQLServerUID <> "" Then
                    gConnectionString = "Server=" & gSqlServerName & ";Database=" & gSQLServerDatabase & ";User ID=" &
                                        gSQLServerUID & ";Password=" & gSQLServerPassword &
                                        ";Trusted_Connection=False; Max Pool Size=500"
                End If
                If gPACSSQLServerName <> "" And gPACSSQLServerDatabase <> "" And gPACSSQLServerUID <> "" Then
                    gPacsConnectionString = "Server=" & gPACSSQLServerName & ";Database=" & gPACSSQLServerDatabase &
                                            ";User ID=" & gPACSSQLServerUID & ";Password=" & gPACSSQLServerPassword &
                                            ";Trusted_Connection=False; Max Pool Size=500"
                End If
            Else
                SaveSetting(My.Application.Info.ProductName, "Settings" & "\" & gOfficeID, "SQLServerName",
                            gSqlServerName)
                SaveSetting(My.Application.Info.ProductName, "Settings" & "\" & gOfficeID, "SQLServerDatabase",
                            gSQLServerDatabase)
                SaveSetting(My.Application.Info.ProductName, "Settings" & "\" & gOfficeID, "SQLServerUID", gSQLServerUID)
                SaveSetting(My.Application.Info.ProductName, "Settings" & "\" & gOfficeID, "SQLServerPassword",
                            gEncrypt(gSQLServerPassword))
                SaveSetting(My.Application.Info.ProductName, "Settings" & "\" & gOfficeID, "PACSSQLServerName",
                            gPACSSQLServerName)
                SaveSetting(My.Application.Info.ProductName, "Settings" & "\" & gOfficeID, "PACSSQLServerName",
                            gPACSSQLServerName)
                SaveSetting(My.Application.Info.ProductName, "Settings" & "\" & gOfficeID, "PACSSQLServerDatabase",
                            gPACSSQLServerDatabase)
                SaveSetting(My.Application.Info.ProductName, "Settings", "PACSSQLServerUID" & "\" & gOfficeID,
                            gPACSSQLServerUID)
                SaveSetting(My.Application.Info.ProductName, "Settings" & "\" & gOfficeID, "PACSSQLServerPassword",
                            gEncrypt(gPACSSQLServerPassword))
                If gPACSSQLServerName <> "" And gPACSSQLServerDatabase <> "" And gPACSSQLServerUID <> "" Then
                    gPacsConnectionString = "Server=" & gPACSSQLServerName & ";Database=" & gPACSSQLServerDatabase &
                                            ";User ID=" & gPACSSQLServerUID & ";Password=" & gPACSSQLServerPassword &
                                            ";Trusted_Connection=False; Max Pool Size=500"
                End If
                If gSqlServerName <> "" And gSQLServerDatabase <> "" And gSQLServerUID <> "" Then
                    gConnectionString = "Server=" & gSqlServerName & ";Database=" & gSQLServerDatabase & ";User ID=" &
                                        gSQLServerUID & ";Password=" & gSQLServerPassword &
                                        ";Trusted_Connection=False; Max Pool Size=500"
                End If
                SaveSetting(My.Application.Info.ProductName, "Settings" & "\" & gOfficeID, "PACSPath", "" & gPACSPath)
            End If
        Else
            If (RW = ReadWrite.sRead) Then

                gSqlServerName = GetSetting(My.Application.Info.ProductName, "Settings", "SQLServerName", "")
                gSQLServerDatabase = GetSetting(My.Application.Info.ProductName, "Settings", "SQLServerDatabase", "")
                gSQLServerUID = GetSetting(My.Application.Info.ProductName, "Settings", "SQLServerUID", "")
                gSQLServerPassword = gEncrypt(GetSetting(My.Application.Info.ProductName, "Settings",
                                                         "SQLServerPassword", ""))
                gPACSSQLServerName = GetSetting(My.Application.Info.ProductName, "Settings", "PACSSQLServerName", "")
                gPACSSQLServerDatabase = GetSetting(My.Application.Info.ProductName, "Settings", "PACSSQLServerDatabase",
                                                    "")
                gPACSSQLServerUID = GetSetting(My.Application.Info.ProductName, "Settings", "PACSSQLServerUID", "")
                gPACSSQLServerPassword = gEncrypt(GetSetting(My.Application.Info.ProductName, "Settings",
                                                             "PACSSQLServerPassword", ""))
                gPACSPath = GetSetting(My.Application.Info.ProductName, "Settings", "PACSPath", "")
                If gSqlServerName <> "" And gSQLServerDatabase <> "" And gSQLServerUID <> "" Then
                    gConnectionString = "Server=" & gSqlServerName & ";Database=" & gSQLServerDatabase & ";User ID=" &
                                        gSQLServerUID & ";Password=" & gSQLServerPassword &
                                        ";Trusted_Connection=False; Max Pool Size=500"
                End If
                If gPACSSQLServerName <> "" And gPACSSQLServerDatabase <> "" And gPACSSQLServerUID <> "" Then
                    gPacsConnectionString = "Server=" & gPACSSQLServerName & ";Database=" & gPACSSQLServerDatabase &
                                            ";User ID=" & gPACSSQLServerUID & ";Password=" & gPACSSQLServerPassword &
                                            ";Trusted_Connection=False; Max Pool Size=500"
                End If
            Else
                SaveSetting(My.Application.Info.ProductName, "Settings", "SQLServerName", gSqlServerName)
                SaveSetting(My.Application.Info.ProductName, "Settings", "SQLServerDatabase", gSQLServerDatabase)
                SaveSetting(My.Application.Info.ProductName, "Settings", "SQLServerUID", gSQLServerUID)
                SaveSetting(My.Application.Info.ProductName, "Settings", "SQLServerPassword",
                            gEncrypt(gSQLServerPassword))
                SaveSetting(My.Application.Info.ProductName, "Settings", "PACSSQLServerName", gPACSSQLServerName)
                SaveSetting(My.Application.Info.ProductName, "Settings", "PACSSQLServerDatabase", gPACSSQLServerDatabase)
                SaveSetting(My.Application.Info.ProductName, "Settings", "PACSSQLServerUID", gPACSSQLServerUID)
                SaveSetting(My.Application.Info.ProductName, "Settings", "PACSSQLServerPassword",
                            gEncrypt(gPACSSQLServerPassword))
                If gSqlServerName <> "" And gSQLServerDatabase <> "" And gSQLServerUID <> "" Then
                    gConnectionString = "Server=" & gSqlServerName & ";Database=" & gSQLServerDatabase & ";User ID=" &
                                        gSQLServerUID & ";Password=" & gSQLServerPassword &
                                        ";Trusted_Connection=False; Max Pool Size=500"
                End If
                If gPACSSQLServerName <> "" And gPACSSQLServerDatabase <> "" And gPACSSQLServerUID <> "" Then
                    gPacsConnectionString = "Server=" & gPACSSQLServerName & ";Database=" & gPACSSQLServerDatabase &
                                            ";User ID=" & gPACSSQLServerUID & ";Password=" & gPACSSQLServerPassword &
                                            ";Trusted_Connection=False; Max Pool Size=500"
                End If
                SaveSetting(My.Application.Info.ProductName, "Settings", "PACSPath", gPACSPath)
            End If
        End If
    End Sub

    Public Sub gDatabaseSettings(RW As ReadWrite)
        gConnectionString = ""
        gPacsConnectionString = ""
        If RW = ReadWrite.sWrite Then gDatabaseSettingsRegistery(ReadWrite.sWrite)
        If gMultiOfficeMode Then
            If (RW = ReadWrite.sRead) Then
                gSqlServerName = gAppConfig.GetValueStr("SQLServerName_" & gOfficeID, "")
                gSQLServerDatabase = gAppConfig.GetValueStr("SQLServerDatabase_" & gOfficeID, "")
                gSQLServerUID = gAppConfig.GetValueStr("SQLServerUID_" & gOfficeID, "")
                gSQLServerPassword = gEncrypt(gAppConfig.GetValueStr("SQLServerPassword_" & gOfficeID, ""))
                gPACSSQLServerName = gAppConfig.GetValueStr("PACSSQLServerName_" & gOfficeID, "")
                gPACSSQLServerDatabase = gAppConfig.GetValueStr("PACSSQLServerDatabase_" & gOfficeID, "")
                gPACSSQLServerUID = gAppConfig.GetValueStr("PACSSQLServerUID_" & gOfficeID, "")
                gPACSSQLServerPassword = gEncrypt(gAppConfig.GetValueStr("PACSSQLServerPassword_" & gOfficeID, ""))
                gPACSPath = gAppConfig.GetValueStr("PACSPath_" & gOfficeID, "")
                If gSqlServerName <> "" And gSQLServerDatabase <> "" And gSQLServerUID <> "" Then
                    gConnectionString = "Server=" & gSqlServerName & ";Database=" & gSQLServerDatabase & ";User ID=" &
                                        gSQLServerUID & ";Password=" & gSQLServerPassword &
                                        ";Trusted_Connection=False; Max Pool Size=500"
                End If
                If gPACSSQLServerName <> "" And gPACSSQLServerDatabase <> "" And gPACSSQLServerUID <> "" Then
                    gPacsConnectionString = "Server=" & gPACSSQLServerName & ";Database=" & gPACSSQLServerDatabase &
                                            ";User ID=" & gPACSSQLServerUID & ";Password=" & gPACSSQLServerPassword &
                                            ";Trusted_Connection=False; Max Pool Size=500"
                End If
            Else
                gAppConfig.SaveSetting("SQLServerName_" & gOfficeID, gSqlServerName, True)
                gAppConfig.SaveSetting("SQLServerDatabase_" & gOfficeID, gSQLServerDatabase, True)
                gAppConfig.SaveSetting("SQLServerUID_" & gOfficeID, gSQLServerUID, True)
                gAppConfig.SaveSetting("SQLServerPassword_" & gOfficeID, gEncrypt(gSQLServerPassword), True)
                gAppConfig.SaveSetting("PACSSQLServerName_" & gOfficeID, gPACSSQLServerName, True)
                gAppConfig.SaveSetting("PACSSQLServerDatabase_" & gOfficeID, gPACSSQLServerDatabase, True)
                gAppConfig.SaveSetting("PACSSQLServerUID_" & gOfficeID, gPACSSQLServerUID, True)
                gAppConfig.SaveSetting("PACSSQLServerPassword_" & gOfficeID, gEncrypt(gPACSSQLServerPassword), True)
                If gPACSSQLServerName <> "" And gPACSSQLServerDatabase <> "" And gPACSSQLServerUID <> "" Then
                    gPacsConnectionString = "Server=" & gPACSSQLServerName & ";Database=" & gPACSSQLServerDatabase &
                                            ";User ID=" & gPACSSQLServerUID & ";Password=" & gPACSSQLServerPassword &
                                            ";Trusted_Connection=False; Max Pool Size=500"
                End If
                If gSqlServerName <> "" And gSQLServerDatabase <> "" And gSQLServerUID <> "" Then
                    gConnectionString = "Server=" & gSqlServerName & ";Database=" & gSQLServerDatabase & ";User ID=" &
                                        gSQLServerUID & ";Password=" & gSQLServerPassword &
                                        ";Trusted_Connection=False; Max Pool Size=500"
                End If
                gAppConfig.SaveSetting("PACSPath_" & gOfficeID, "" & gPACSPath, True)
                gAppConfig.SaveSettingToFile()
            End If
        Else
            If (RW = ReadWrite.sRead) Then

                gSqlServerName = gAppConfig.GetValueStr("SQLServerName", "")
                gSQLServerDatabase = gAppConfig.GetValueStr("SQLServerDatabase", "")
                gSQLServerUID = gAppConfig.GetValueStr("SQLServerUID", "")
                gSQLServerPassword = gEncrypt(gAppConfig.GetValueStr("SQLServerPassword", ""))
                gPACSSQLServerName = gAppConfig.GetValueStr("PACSSQLServerName", "")
                gPACSSQLServerDatabase = gAppConfig.GetValueStr("PACSSQLServerDatabase", "")
                gPACSSQLServerUID = gAppConfig.GetValueStr("PACSSQLServerUID", "")
                gPACSSQLServerPassword = gEncrypt(gAppConfig.GetValueStr("PACSSQLServerPassword", ""))
                gPACSPath = gAppConfig.GetValueStr("PACSPath", "")

                If gSqlServerName <> "" And gSQLServerDatabase <> "" And gSQLServerUID <> "" Then
                    gConnectionString = "Server=" & gSqlServerName & ";Database=" & gSQLServerDatabase & ";User ID=" &
                                        gSQLServerUID & ";Password=" & gSQLServerPassword &
                                        ";Trusted_Connection=False; Max Pool Size=500"
                End If
                If gPACSSQLServerName <> "" And gPACSSQLServerDatabase <> "" And gPACSSQLServerUID <> "" Then
                    gPacsConnectionString = "Server=" & gPACSSQLServerName & ";Database=" & gPACSSQLServerDatabase &
                                            ";User ID=" & gPACSSQLServerUID & ";Password=" & gPACSSQLServerPassword &
                                            ";Trusted_Connection=False; Max Pool Size=500"
                End If
            Else
                gAppConfig.SaveSetting("SQLServerName", gSqlServerName, True)
                gAppConfig.SaveSetting("SQLServerDatabase", gSQLServerDatabase, True)
                gAppConfig.SaveSetting("SQLServerUID", gSQLServerUID, True)
                gAppConfig.SaveSetting("SQLServerPassword", gEncrypt(gSQLServerPassword), True)
                gAppConfig.SaveSetting("PACSSQLServerName", gPACSSQLServerName, True)
                gAppConfig.SaveSetting("PACSSQLServerDatabase", gPACSSQLServerDatabase, True)
                gAppConfig.SaveSetting("PACSSQLServerUID", gPACSSQLServerUID, True)
                gAppConfig.SaveSetting("PACSSQLServerPassword", gEncrypt(gPACSSQLServerPassword), True)
                If gSqlServerName <> "" And gSQLServerDatabase <> "" And gSQLServerUID <> "" Then
                    gConnectionString = "Server=" & gSqlServerName & ";Database=" & gSQLServerDatabase & ";User ID=" &
                                        gSQLServerUID & ";Password=" & gSQLServerPassword &
                                        ";Trusted_Connection=False; Max Pool Size=500"
                End If
                If gPACSSQLServerName <> "" And gPACSSQLServerDatabase <> "" And gPACSSQLServerUID <> "" Then
                    gPacsConnectionString = "Server=" & gPACSSQLServerName & ";Database=" & gPACSSQLServerDatabase &
                                            ";User ID=" & gPACSSQLServerUID & ";Password=" & gPACSSQLServerPassword &
                                            ";Trusted_Connection=False; Max Pool Size=500"
                End If
                gAppConfig.SaveSetting("PACSPath", gPACSPath, True)
                gAppConfig.SaveSettingToFile()
            End If
        End If
    End Sub

    Public Sub gSettings(RW As ReadWrite)
        If RW = ReadWrite.sWrite Then gSettingsCompatability(ReadWrite.sWrite)
        If RW = ReadWrite.sRead Then
            gDebugMode = gAppConfig.GetValueBool("DebugMode", False)
            gIdleShutDown = gAppConfig.GetValueInt("IdleShutDown", 120)
            gDefaultState = gAppConfig.GetValueStr("DefaultState", "NY")
            gOfficeID = gAppConfig.GetValueStr("OfficeID", "0")
            gOfficeName = gAppConfig.GetValueStr("OfficeName", "")
            gQuikSearch = CBool(gAppConfig.GetValueBool("QuikSearch", False))
            gMemoPad = CBool(gAppConfig.GetValueBool("MemoPad", False))
            gFullScreen = CBool(gAppConfig.GetValueBool("FullScreen", False))
            gDefaultState = gAppConfig.GetValueStr("DefaultState", "NY")
            gOfficeID = gAppConfig.GetValueStr("OfficeID", "0")
            gLicenseKeyValidated = gAppConfig.GetValueBool("ManualScanMode", False)
            gScannerMode = gAppConfig.GetValueInt("ScannerMode", 0)
            gScannerFolder = gAppConfig.GetValueStr("ScannerFolder", "")
            gDatabaseSettings(ReadWrite.sRead)
            gPrintPatientLabel = gAppConfig.GetValueInt("PrintPatientLabel", 1)
            gPrinterFileLabel = gAppConfig.GetValueStr("PrinterFileLabel", "")
            gCDLabelPrinter = gAppConfig.GetValueStr("CDLabelPrinter", "")
            gPrinterNF3 = gAppConfig.GetValueStr("PrinterNF3", "")
            gPrinterBillingEnvelope = gAppConfig.GetValueStr("PrinterBillingEnvelope", "")
            gEnvelopPaperType = gAppConfig.GetValueInt("EnvelopPaperType", 20)
            gEnvelopShiftToCenter = gAppConfig.GetValueBool("EnvelopShiftToCenter", False)
            gEnvelopNoPageSize = gAppConfig.GetValueBool("EnvelopNoPageSize", False)
            gCDEnvelopeLabelType = gAppConfig.GetValueInt("CDEnvelopeLabelType", 1)
            gPrinterOtherDocuments = gAppConfig.GetValueStr("PrinterOtherDocuments", "")
            gWebFaxAddress = gAppConfig.GetValueStr("WebFaxAddress", "FaxAge.com")
            gWebFaxLeadingOne = gAppConfig.GetValueBool("WebFaxLeadingOne", False)

            gPrinterFileLabel = CheckPrinter(gPrinterFileLabel)
            gCDLabelPrinter = CheckPrinter(gCDLabelPrinter)
            gPrinterNF3 = CheckPrinter(gPrinterNF3)
            gPrinterBillingEnvelope = CheckPrinter(gPrinterBillingEnvelope)
            gPrinterOtherDocuments = CheckPrinter(gPrinterOtherDocuments)
            gScannerImageIndex = gAppConfig.GetValueInt("ScannerImageIndex", -1)
            gShowIntakeFormButton = gAppConfig.GetValueInt("ShowIntakeFormButton" & gCurrentEmployee.UID, True)

            gDebugMode = Debugger.IsAttached
        Else
            gAppConfig.SaveSetting("IdleShutDown", gIdleShutDown, True)
            gAppConfig.SaveSetting("DebugMode", gDebugMode, True)
            gAppConfig.SaveSetting("DefaultState", gDefaultState, True)
            gAppConfig.SaveSetting("OfficeID", gOfficeID, True)
            gAppConfig.SaveSetting("OfficeName", gOfficeName, True)
            gAppConfig.SaveSetting("QuikSearch", gQuikSearch.ToString, True)
            gAppConfig.SaveSetting("MemoPad", gMemoPad.ToString, True)
            gAppConfig.SaveSetting("FullScreen", gFullScreen.ToString, True)
            gAppConfig.SaveSetting("DefaultState", gDefaultState, True)
            gAppConfig.SaveSetting("ScannerMode", gScannerMode, True)
            gAppConfig.SaveSetting("ScannerFolder", gScannerFolder, True)

            ' Save db settings for the License generator
            gAppConfig.SaveSetting("SQLServerName", gSqlServerName, True)
            gAppConfig.SaveSetting("SQLServerDatabase", gSQLServerDatabase, True)
            gAppConfig.SaveSetting("SQLServerUID", gSQLServerUID, True)
            gAppConfig.SaveSetting("SQLServerPassword", gEncrypt(gSQLServerPassword), True)

            gDatabaseSettings(ReadWrite.sWrite)
            gAppConfig.SaveSetting("ScannerImageIndex", gScannerImageIndex, True)
            gAppConfig.SaveSetting("PrintPatientLabel", gPrintPatientLabel, True)
            gAppConfig.SaveSetting("PrinterFileLabel", gPrinterFileLabel, True)
            gAppConfig.SaveSetting("CDLabelPrinter", gCDLabelPrinter, True)

            gAppConfig.SaveSetting("PrinterNF3", gPrinterNF3, True)
            gAppConfig.SaveSetting("PrinterBillingEnvelope", gPrinterBillingEnvelope, True)
            gAppConfig.SaveSetting("EnvelopPaperType", gEnvelopPaperType, True)
            gAppConfig.SaveSetting("EnvelopShiftToCenter", gEnvelopShiftToCenter, True)
            gAppConfig.SaveSetting("EnvelopNoPageSize", gEnvelopNoPageSize, True)

            gAppConfig.SaveSetting("PrinterOtherDocuments", gPrinterOtherDocuments, True)
            gAppConfig.SaveSetting("WebFaxAddress", gWebFaxAddress, True)
            gAppConfig.SaveSetting("WebFaxLeadingOne", gWebFaxLeadingOne, True)
            gAppConfig.SaveSetting("CDEnvelopeLabelType", gCDEnvelopeLabelType, True)
            gAppConfig.SaveSetting("ShowIntakeFormButton" & gCurrentEmployee.UID, gShowIntakeFormButton, True)
            gAppConfig.SaveSettingToFile()
            ' Save db settings for the License generator

            'gDatabaseSettings(ReadWrite.sWrite)

            'PREPAIR FOR DB SETTINGS
            'With gAppSettings
            '    .IntValue("IdleShutDown") = gIdleShutDown
            '    .BoolValue("DebugMode") = gDebugMode
            '    .StrValue("DefaultState") = gDefaultState
            '    .IntValue("OfficeID") = gOfficeID
            '    .StrValue("OfficeName") = gOfficeName
            '    .BoolValue("QuikSearch") = gQuikSearch
            '    .BoolValue("MemoPad") = gMemoPad
            '    .BoolValue("FullScreen") = gFullScreen
            '    .IntValue("ScannerMode") = gScannerMode
            '    .StrValue("ScannerFolder") = gScannerFolder
            '    .StrValue("SQLServerName") = gSqlServerName
            '    .StrValue("SQLServerDatabase") = gSQLServerDatabase
            '    .StrValue("SQLServerUID") = gSQLServerUID
            '    .StrValue("SQLServerPassword") = gEncrypt(gSQLServerPassword)
            '    .IntValue("ScannerImageIndex") = gScannerImageIndex
            '    .IntValue("PrintPatientLabel") = gPrintPatientLabel
            '    .StrValue("PrinterFileLabel") = gPrinterFileLabel
            '    .StrValue("CDLabelPrinter") = gCDLabelPrinter

            '    .StrValue("PrinterNF3") = gPrinterNF3
            '    .StrValue("PrinterBillingEnvelope") = gPrinterBillingEnvelope
            '    .IntValue("EnvelopPaperType") = gEnvelopPaperType
            '    .BoolValue("EnvelopShiftToCenter") = gEnvelopShiftToCenter
            '    .StrValue("PrinterOtherDocuments") = gPrinterOtherDocuments
            '    .StrValue("WebFaxAddress") = gWebFaxAddress
            '    .IntValue("CDEnvelopeLabelType") = gCDEnvelopeLabelType
            '    .BoolValue("ShowIntakeFormButton" & gCurrentEmployee.UID) = gShowIntakeFormButton
            '    .SaveAll()
            'End With

        End If
    End Sub

    Public Sub gSettingsCompatability(RW As ReadWrite)

        If RW = ReadWrite.sRead Then

            gDebugMode = GetSetting(My.Application.Info.ProductName, "Settings", "DebugMode", False)
            gIdleShutDown = GetSetting(My.Application.Info.ProductName, "Settings", "IdleShutDown", 120)
            gDefaultState = GetSetting(My.Application.Info.ProductName, "Settings", "DefaultState", "NY")
            gOfficeID = GetSetting(My.Application.Info.ProductName, "Settings", "OfficeID", "0")
            gOfficeName = GetSetting(My.Application.Info.ProductName, "Settings", "OfficeName", "")
            gQuikSearch = CBool(GetSetting(My.Application.Info.ProductName, "Settings", "QuikSearch", "0"))
            gMemoPad = CBool(GetSetting(My.Application.Info.ProductName, "Settings", "MemoPad", "0"))
            gFullScreen = CBool(GetSetting(My.Application.Info.ProductName, "Settings", "FullScreen", "0"))
            gDefaultState = GetSetting(My.Application.Info.ProductName, "Settings", "DefaultState", "NY")
            gOfficeID = GetSetting(My.Application.Info.ProductName, "Settings", "OfficeID", "0")
            gLicenseKeyValidated = GetSetting(My.Application.Info.ProductName, "Settings", "ManualScanMode", False)
            gScannerMode = GetSetting(My.Application.Info.ProductName, "Settings", "ScannerMode", "0")
            gScannerFolder = GetSetting(My.Application.Info.ProductName, "Settings", "ScannerFolder", "")
            gDatabaseSettingsRegistery(ReadWrite.sRead)
            gPrintPatientLabel = GetSetting(My.Application.Info.ProductName, "Settings", "PrintPatientLabel", 1)
            gPrinterFileLabel = GetSetting(My.Application.Info.ProductName, "Settings", "PrinterFileLabel", "")
            gCDLabelPrinter = GetSetting(My.Application.Info.ProductName, "Settings", "CDLabelPrinter", "")
            gPrinterNF3 = GetSetting(My.Application.Info.ProductName, "Settings", "PrinterNF3", "")
            gPrinterBillingEnvelope = GetSetting(My.Application.Info.ProductName, "Settings", "PrinterBillingEnvelope",
                                                 "")
            gEnvelopPaperType = GetSetting(My.Application.Info.ProductName, "Settings", "EnvelopPaperType", 20)
            gEnvelopShiftToCenter = GetSetting(My.Application.Info.ProductName, "Settings", "EnvelopShiftToCenter", False)
            gEnvelopNoPageSize = GetSetting(My.Application.Info.ProductName, "Settings", "EnvelopNoPageSize", False)
            gCDEnvelopeLabelType = GetSetting(My.Application.Info.ProductName, "Settings", "CDEnvelopeLabelType", 1)
            gPrinterOtherDocuments = GetSetting(My.Application.Info.ProductName, "Settings", "PrinterOtherDocuments", "")
            gWebFaxAddress = GetSetting(My.Application.Info.ProductName, "Settings", "WebFaxAddress", "FaxAge.com")
            gWebFaxLeadingOne = GetSetting(My.Application.Info.ProductName, "Settings", "WebFaxLeadingOne", False)

            gPrinterFileLabel = CheckPrinter(gPrinterFileLabel)
            gCDLabelPrinter = CheckPrinter(gCDLabelPrinter)
            gPrinterNF3 = CheckPrinter(gPrinterNF3)
            gPrinterBillingEnvelope = CheckPrinter(gPrinterBillingEnvelope)
            gPrinterOtherDocuments = CheckPrinter(gPrinterOtherDocuments)
            gScannerImageIndex = GetSetting(My.Application.Info.ProductName, "Settings", "ScannerImageIndex", -1)
            gShowIntakeFormButton = GetSetting(My.Application.Info.ProductName, "Settings",
                                               "gShowIntakeFormButton" & gCurrentEmployee.UID, True)

            gDebugMode = Debugger.IsAttached
        Else

            SaveSetting(My.Application.Info.ProductName, "Settings", "IdleShutDown", gIdleShutDown)
            SaveSetting(My.Application.Info.ProductName, "Settings", "DebugMode", gDebugMode)
            SaveSetting(My.Application.Info.ProductName, "Settings", "DefaultState", gDefaultState)
            SaveSetting(My.Application.Info.ProductName, "Settings", "OfficeID", gOfficeID)
            SaveSetting(My.Application.Info.ProductName, "Settings", "OfficeName", gOfficeName)
            SaveSetting(My.Application.Info.ProductName, "Settings", "QuikSearch", gQuikSearch.ToString)
            SaveSetting(My.Application.Info.ProductName, "Settings", "MemoPad", gMemoPad.ToString)
            SaveSetting(My.Application.Info.ProductName, "Settings", "FullScreen", gFullScreen.ToString)
            SaveSetting(My.Application.Info.ProductName, "Settings", "DefaultState", gDefaultState)
            SaveSetting(My.Application.Info.ProductName, "Settings", "ScannerMode", gScannerMode)
            SaveSetting(My.Application.Info.ProductName, "Settings", "ScannerFolder", gScannerFolder)

            ' Save db settings for the License generator
            SaveSetting(My.Application.Info.ProductName, "Settings", "SQLServerName", gSqlServerName)
            SaveSetting(My.Application.Info.ProductName, "Settings", "SQLServerDatabase", gSQLServerDatabase)
            SaveSetting(My.Application.Info.ProductName, "Settings", "SQLServerUID", gSQLServerUID)
            SaveSetting(My.Application.Info.ProductName, "Settings", "SQLServerPassword", gEncrypt(gSQLServerPassword))

            gDatabaseSettings(ReadWrite.sWrite)
            SaveSetting(My.Application.Info.ProductName, "Settings", "ScannerImageIndex", gScannerImageIndex)
            SaveSetting(My.Application.Info.ProductName, "Settings", "PrintPatientLabel", gPrintPatientLabel)
            SaveSetting(My.Application.Info.ProductName, "Settings", "PrinterFileLabel", gPrinterFileLabel)
            SaveSetting(My.Application.Info.ProductName, "Settings", "CDLabelPrinter", gCDLabelPrinter)

            SaveSetting(My.Application.Info.ProductName, "Settings", "PrinterNF3", gPrinterNF3)
            SaveSetting(My.Application.Info.ProductName, "Settings", "PrinterBillingEnvelope", gPrinterBillingEnvelope)
            SaveSetting(My.Application.Info.ProductName, "Settings", "EnvelopPaperType", gEnvelopPaperType)
            SaveSetting(My.Application.Info.ProductName, "Settings", "EnvelopShiftToCenter", gEnvelopShiftToCenter)
            SaveSetting(My.Application.Info.ProductName, "Settings", "EnvelopNoPageSize", gEnvelopNoPageSize)

            SaveSetting(My.Application.Info.ProductName, "Settings", "PrinterOtherDocuments", gPrinterOtherDocuments)
            SaveSetting(My.Application.Info.ProductName, "Settings", "WebFaxAddress", gWebFaxAddress)
            SaveSetting(My.Application.Info.ProductName, "Settings", "WebFaxLeadingOne", gWebFaxLeadingOne)

            SaveSetting(My.Application.Info.ProductName, "Settings", "CDEnvelopeLabelType", gCDEnvelopeLabelType)
            SaveSetting(My.Application.Info.ProductName, "Settings", "gShowIntakeFormButton" & gCurrentEmployee.UID,
                        gShowIntakeFormButton)
        End If
    End Sub

    Public Sub gToolStripSettings(FRM As Form, TS As ToolStrip, RW As ReadWrite)
        Dim TSi As ToolStripItem
        If RW = ReadWrite.sRead Then
            For Each TSi In TS.Items
                If _
                    TSi.Name <> "ToolStripAutoResize" And TSi.Name <> "ToolStripFontIncrease" And
                    TSi.Name <> "ToolStripFonrDecrease" And TSi.Name <> "ToolStripButtonDetach" Then
                    TSi.Visible = GetSetting(My.Application.Info.ProductName,
                                             "GUI\USER-" & gCurrentEmployee.EmpID & "\" & UCase(FRM.Name) & "\" &
                                             UCase(TS.Name), TSi.Name, True)
                End If
            Next
        Else
            For Each TSi In TS.Items
                SaveSetting(My.Application.Info.ProductName,
                            "GUI\USER-" & gCurrentEmployee.EmpID & "\" & UCase(FRM.Name) & "\" & UCase(TS.Name),
                            TSi.Name, TSi.Visible)
            Next
        End If
    End Sub

End Module