Imports System.Reflection
Imports log4net

Public Class DocFields
    Public OFFICENAME As String = ""
    Public OFFICEADDRESS As String = ""
    Public OFFICECITYSTATEZIP As String = ""
    Public OFFICEPHONE As String = ""
    Public OFFICEFAX As String = ""
    Public BILLINGOFFICENAME As String = ""
    Public BILLINGOFFICEADDRESS As String = ""
    Public BILLINGOFFICECITYSTATEZIP As String = ""
    Public BILLINGOFFICEPHONE As String = ""
    Public BILLINGOFFICEFAX As String = ""
    Public PATIENTNAME As String = ""
    Public PATIENTDOB As String = ""
    Public HOMEADDRESS As String = ""
    Public HOMEADDRESSFULL As String = ""
    Public HOMECITYSTATEZIP As String = ""
    Public CURRENTDATE As String = ""
    Public INSURANCECOMP As String = ""
    Public INSADDRESS As String = ""
    Public INSCITYSTATEZIP As String = ""
    Public INSPHONE As String = ""
    Public INSFAX As String = ""
    Public CLAIMNUMBER As String = ""
    Public DATEACC As String = ""
    Public DATESOFSERVICES As String = ""
    Public BILLNO As String = ""
    Public BILLDATE As String = ""
    Public BILLAMOUNT As String = ""
    Public PATIENTID As Long
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

    Public Sub New(BillID As Long)
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String = ""
        SQL = " Select Bills.BillID As BILLNO, Employees.CorporationName As OFFICENAME, Employees.CorporationAddress1 + ' ' + Employees.CorporationAddress2 AS OFFICEADDRESS, "
        SQL &= " Employees.CorporationCity + ' ' + Employees.CorporationState + ', ' + Employees.CorporationZip AS OFFICECITYSTATEZIP, Employees.CorporationPhone AS OFFICEPHONE, Employees.CorporationFax AS OFFICEFAX, "
        SQL &= " BillingCompanies.CompanyName AS BILLINGOFFICENAME, BillingCompanies.Address1 + ' ' + BillingCompanies.Address2 AS BILLINGOFFICEADDRESS, "
        SQL &= " BillingCompanies.City + ' ' + BillingCompanies.State + ', ' + BillingCompanies.Zip AS BILLINGOFFICECITYSTATEZIP, "
        SQL &= " BillingCompanies.Phone1 As BILLINGOFFICEPHONE, BillingCompanies.Fax1 As BILLINGOFFICEFAX, "
        SQL &= " Patients.FName + ' ' + Patients.MI + ' ' + Patients.LName AS PATIENTNAME, InsuranceCompanies.CompanyName AS INSURANCECOMP, "
        SQL &= " InsuranceCompanyAddresses.Address AS INSADDRESS, "
        SQL &= " InsuranceCompanyAddresses.City + ' ' + InsuranceCompanyAddresses.State + ', ' + InsuranceCompanyAddresses.Zip AS INSCITYSTATEZIP, "
        SQL &= " Patients.ClaimNumber As CLAIMNUMBER, Patients.DOB As PATIENTDOB, Patients.DOA As DATEACC, Bills.ServiceFrom, Bills.ServiceTo, "
        SQL &= " Bills.BillDate As BILLDATE, Bills.BillAmount As BILLAMOUNT, Patients.PatientID As PATIENTID, InsuranceCompanies.Phone1 As INSPHONE, InsuranceCompanies.Fax1 AS INSFAX, "
        SQL &= " Patients.Address1 +' '+ Patients.Address2+'  '+Patients.City+' '+Patients.State+', '+Patients.Zip as HOMEADDRESSFULL, "
        SQL &= " Patients.Address1 +' '+ Patients.Address2 as HOMEADDRESS, "
        SQL &= " Patients.City+' '+Patients.State+', '+Patients.Zip as HOMECITYSTATEZIP "

        SQL &= " From Bills INNER Join "
        SQL &= "               Patients On Bills.PatientID = Patients.PatientID LEFT OUTER Join "
        SQL &= "               InsuranceCompanyAddresses On Bills.InsAddressID = InsuranceCompanyAddresses.AddressID LEFT OUTER Join "
        SQL &= "               InsuranceCompanies On Bills.InsCompanyID = InsuranceCompanies.CompanyID LEFT OUTER Join "
        SQL &= "               Offices On Patients.OfficeID = Offices.OfficeID LEFT OUTER Join "
        SQL &= "               BillingCompanies On Patients.BillingCompanyID = BillingCompanies.BillingCompanyID LEFT OUTER JOIN "
        SQL &= "               Employees ON Bills.BillingProviderID = Employees.EmpID "
        SQL &= " WHERE Bills.BillID = " & BillID
        Try
            Reader = gSQLGetDataReader(SQL)
            If Reader Is Nothing Then Exit Sub
            If Reader.HasRows = False Then Exit Sub
            Reader.Read()
            OFFICENAME = Reader("OFFICENAME").ToString()
            OFFICEADDRESS = Reader("OFFICEADDRESS").ToString()
            OFFICECITYSTATEZIP = Reader("OFFICECITYSTATEZIP").ToString()
            OFFICEPHONE = Reader("OFFICEPHONE").ToString()
            OFFICEFAX = Reader("OFFICEFAX").ToString()
            BILLINGOFFICENAME = Reader("BILLINGOFFICENAME").ToString()
            BILLINGOFFICEADDRESS = Reader("BILLINGOFFICEADDRESS").ToString()
            BILLINGOFFICECITYSTATEZIP = Reader("BILLINGOFFICECITYSTATEZIP").ToString()
            BILLINGOFFICEPHONE = Reader("BILLINGOFFICEPHONE").ToString()
            BILLINGOFFICEFAX = Reader("BILLINGOFFICEFAX").ToString()
            PATIENTNAME = Reader("PATIENTNAME").ToString()
            If IsDate(Reader("PATIENTDOB")) Then
                PATIENTDOB = CDate(Reader("PATIENTDOB")).ToString("MM/dd/yyyy")
            End If
            HOMEADDRESS = Reader("HOMEADDRESS").ToString()
            HOMEADDRESSFULL = Reader("HOMEADDRESSFULL").ToString()
            HOMECITYSTATEZIP = Reader("HOMECITYSTATEZIP").ToString()
            INSURANCECOMP = Reader("INSURANCECOMP").ToString()
            INSADDRESS = Reader("INSADDRESS").ToString()
            INSCITYSTATEZIP = Reader("INSCITYSTATEZIP").ToString()
            INSPHONE = Reader("INSPHONE").ToString()
            INSFAX = Reader("INSFAX").ToString()
            CLAIMNUMBER = Reader("CLAIMNUMBER").ToString()
            If IsDate(Reader("DATEACC")) Then DATEACC = CDate(Reader("DATEACC")).ToString("MM/dd/yyyy")
            If IsDate(Reader("ServiceFrom")) Then DATESOFSERVICES = CDate(Reader("ServiceFrom")).ToString("MM/dd/yyyy")
            If IsDate(Reader("ServiceTo")) Then
                If IsDate(Reader("ServiceFrom")) AndAlso CDate(Reader("ServiceFrom")) <> CDate(Reader("ServiceTo")) Then
                    DATESOFSERVICES &= " - " & CDate(Reader("ServiceTo")).ToString("MM/dd/yyyy")
                End If
            End If
            BILLNO = Reader("BILLNO").ToString()
            If IsDate(Reader("BILLDATE")) Then BILLDATE = CDate(Reader("BILLDATE")).ToString("MM/dd/yyyy")
            If IsNumeric(Reader("BILLAMOUNT")) Then BILLAMOUNT = CDec(Reader("BILLAMOUNT")).ToString("c")
            PATIENTID = Reader("PATIENTID").ToString()
            CURRENTDATE = Now.Date.ToString("MM/dd/yyyy")

        Catch ex As Exception
            log.Error("DocFields", ex)
            MsgBox("Unexpected Error: " & ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


End Class
