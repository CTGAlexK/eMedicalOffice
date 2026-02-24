Imports System.Reflection
Imports log4net

Module WebBrowserModule
    public function BrowserIsNotBusy (browser As WebBrowser) As Boolean
        dim c as Integer
        do until browser.IsBusy=false   
            c=c+1
            Threading.Thread.Sleep(1000)
            if c >50 Then
                return False
            End If
        Loop
        return true 
    End function

End Module
