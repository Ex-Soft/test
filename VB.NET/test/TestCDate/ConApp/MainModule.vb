Imports System.Globalization
Imports System.Runtime.InteropServices
Imports System.Threading

Module MainModule

    <DllImport("Kernel32.dll", CharSet:=CharSet.Auto)>
    Public Function GetSystemDefaultUILanguage() As UShort

    End Function

    <DllImport("Kernel32.dll", CharSet:=CharSet.Auto)>
    Public Function GetUserDefaultUILanguage() As UShort

    End Function

    Sub Main()
        Console.WriteLine(String.Format("GetSystemDefaultUILanguage(): 0x{0:x4}", GetSystemDefaultUILanguage()))
        Console.WriteLine(String.Format("GetUserDefaultUILanguage(): 0x{0:x4}", GetUserDefaultUILanguage()))
        Console.WriteLine()

        Console.WriteLine(String.Format("Thread.CurrentThread.CurrentCulture: ""{0}"" DateTimeFormat: ""{1}""", Thread.CurrentThread.CurrentCulture, Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern))
        Console.WriteLine(String.Format("Thread.CurrentThread.CurrentUICulture: ""{0}"" DateTimeFormat: ""{1}""", Thread.CurrentThread.CurrentCulture, Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern))
        Console.WriteLine(String.Format("CultureInfo.CurrentCulture: ""{0}"" DateTimeFormat: ""{1}""", CultureInfo.CurrentCulture, CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern))
        Console.WriteLine(String.Format("CultureInfo.CurrentUICulture: ""{0}"" DateTimeFormat: ""{1}""", CultureInfo.CurrentUICulture, CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern))
        Console.WriteLine(String.Format("CultureInfo.DefaultThreadCurrentCulture: ""{0}"" DateTimeFormat: ""{1}""", CultureInfo.DefaultThreadCurrentCulture, If(CultureInfo.DefaultThreadCurrentCulture Is Nothing, "", CultureInfo.DefaultThreadCurrentCulture.DateTimeFormat.ShortDatePattern)))
        Console.WriteLine(String.Format("CultureInfo.DefaultThreadCurrentUICulture: ""{0}"" DateTimeFormat: ""{1}""", CultureInfo.DefaultThreadCurrentUICulture, If(CultureInfo.DefaultThreadCurrentUICulture Is Nothing, "", CultureInfo.DefaultThreadCurrentUICulture.DateTimeFormat.ShortDatePattern)))
        Console.WriteLine(String.Format("CultureInfo.InstalledUICulture: ""{0}"" DateTimeFormat: ""{1}""", CultureInfo.InstalledUICulture, CultureInfo.InstalledUICulture.DateTimeFormat.ShortDatePattern))
        Console.WriteLine(String.Format("CultureInfo.InvariantCulture: ""{0}"" DateTimeFormat: ""{1}""", CultureInfo.InvariantCulture, CultureInfo.InvariantCulture.DateTimeFormat.ShortDatePattern))

        Dim strDDMMYY As String
        Dim strMMDDYY As String
        Dim dt As DateTime

        strDDMMYY = "31/12/2019"
        strMMDDYY = "12/31/2019"

        'strDDMMYY = "08/03/2019"
        'strMMDDYY = "03/08/2019"

        Try
            dt = CDate(strDDMMYY)
            Console.WriteLine(dt.ToLongDateString())
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

        Try
            dt = CDate(strMMDDYY)
            Console.WriteLine(dt.ToLongDateString())
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

        Dim culture As CultureInfo

        'culture = CultureInfo.CreateSpecificCulture("en-US")
        culture = New CultureInfo("en-US")
        'culture = New CultureInfo("en-US", False)

        'culture.DateTimeFormat.ShortDatePattern = "M/d/yyyy"

        Thread.CurrentThread.CurrentCulture = culture
        Thread.CurrentThread.CurrentUICulture = culture

        Console.WriteLine()

        Console.WriteLine(String.Format("Thread.CurrentThread.CurrentCulture: ""{0}"" DateTimeFormat: ""{1}""", Thread.CurrentThread.CurrentCulture, Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern))
        Console.WriteLine(String.Format("Thread.CurrentThread.CurrentUICulture: ""{0}"" DateTimeFormat: ""{1}""", Thread.CurrentThread.CurrentCulture, Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern))
        Console.WriteLine(String.Format("CultureInfo.CurrentCulture: ""{0}"" DateTimeFormat: ""{1}""", CultureInfo.CurrentCulture, CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern))
        Console.WriteLine(String.Format("CultureInfo.CurrentUICulture: ""{0}"" DateTimeFormat: ""{1}""", CultureInfo.CurrentUICulture, CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern))
        Console.WriteLine(String.Format("CultureInfo.DefaultThreadCurrentCulture: ""{0}"" DateTimeFormat: ""{1}""", CultureInfo.DefaultThreadCurrentCulture, If(CultureInfo.DefaultThreadCurrentCulture Is Nothing, "", CultureInfo.DefaultThreadCurrentCulture.DateTimeFormat.ShortDatePattern)))
        Console.WriteLine(String.Format("CultureInfo.DefaultThreadCurrentUICulture: ""{0}"" DateTimeFormat: ""{1}""", CultureInfo.DefaultThreadCurrentUICulture, If(CultureInfo.DefaultThreadCurrentUICulture Is Nothing, "", CultureInfo.DefaultThreadCurrentUICulture.DateTimeFormat.ShortDatePattern)))
        Console.WriteLine(String.Format("CultureInfo.InstalledUICulture: ""{0}"" DateTimeFormat: ""{1}""", CultureInfo.InstalledUICulture, CultureInfo.InstalledUICulture.DateTimeFormat.ShortDatePattern))
        Console.WriteLine(String.Format("CultureInfo.InvariantCulture: ""{0}"" DateTimeFormat: ""{1}""", CultureInfo.InvariantCulture, CultureInfo.InvariantCulture.DateTimeFormat.ShortDatePattern))

        Try
            dt = CDate(strDDMMYY)
            Console.WriteLine(dt.ToLongDateString())
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

        Try
            dt = CDate(strMMDDYY)
            Console.WriteLine(dt.ToLongDateString())
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

        Console.ReadKey()

    End Sub

End Module
