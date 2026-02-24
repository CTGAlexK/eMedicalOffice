Imports System.Reflection
Imports System.Xml
Imports log4net

Module GeoCoding
    private readonly log as ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Public Function gVerifyAddress(Addr As Address) As Address
        Dim Address As String
        Dim doc As XmlDocument
        Try
            gVerifyAddress = New Address
            Address = Addr.StreetAddress & ", " & Addr.City & ", " & Addr.State & ", " & Addr.Zip
            Address = Replace(Address, "  ", " ")
            Address = Replace(Address, " ", "+")
            Address = Address & "&sensor=false"

            ' https://developers.google.com/maps/documentation/geocoding/#StatusCodes

            doc = New XmlDocument()
            Address = Replace(Address, "#", "Apt.")
            ' Load data  
            doc.Load("http://maps.googleapis.com/maps/api/geocode/xml?address=" & Address)

            If doc.SelectSingleNode("/GeocodeResponse/status").InnerXml.ToUpper = "OK" Then
                If doc.SelectSingleNode("/GeocodeResponse/result/type").InnerXml.ToUpper = "STREET_ADDRESS" Then

                    gVerifyAddress.AddressType = "OK"
                    gVerifyAddress.FormattedAddress =
                        doc.SelectSingleNode("/GeocodeResponse/result/formatted_address").InnerText
                    gVerifyAddress.StreetAddress =
                        doc.SelectSingleNode("/GeocodeResponse/result/address_component[type = 'street_number']/long_name").
                            InnerText & " " &
                        doc.SelectSingleNode("/GeocodeResponse/result/address_component[type = 'route']/long_name").
                            InnerText
                    If _
                        doc.SelectSingleNode("/GeocodeResponse/result/address_component[type = 'sublocality']/long_name") Is
                        Nothing Then
                        gVerifyAddress.City =
                            doc.SelectSingleNode("/GeocodeResponse/result/address_component[type = 'locality']/long_name").
                                InnerText
                    Else
                        gVerifyAddress.City =
                            doc.SelectSingleNode("/GeocodeResponse/result/address_component[type = 'sublocality']/long_name") _
                                .InnerText
                    End If


                    gVerifyAddress.State =
                        doc.SelectSingleNode(
                            "/GeocodeResponse/result/address_component[type = 'administrative_area_level_1']/short_name").
                            InnerText
                    gVerifyAddress.Zip =
                        doc.SelectSingleNode("/GeocodeResponse/result/address_component[type = 'postal_code']/long_name").
                            InnerText

                    If Not doc.SelectSingleNode("/GeocodeResponse/result/partial_match") Is Nothing Then
                        gVerifyAddress.Adjusted = True
                    End If
                    If gVerifyAddress.StreetAddress <> Addr.StreetAddress Then gVerifyAddress.Adjusted = True
                    If gVerifyAddress.City <> Addr.City Then gVerifyAddress.Adjusted = True
                    If gVerifyAddress.State <> Addr.State Then gVerifyAddress.Adjusted = True
                    If gVerifyAddress.Zip <> Addr.Zip Then gVerifyAddress.Adjusted = True

                Else
                    gVerifyAddress.AddressType = "NOMATCH"
                End If
            Else
                gVerifyAddress.AddressType = doc.SelectSingleNode("/GeocodeResponse/status").InnerXml.ToUpper
            End If

        Catch ex As Exception
            log.Error(ex.Message,ex)
        End Try
    End Function

End Module
