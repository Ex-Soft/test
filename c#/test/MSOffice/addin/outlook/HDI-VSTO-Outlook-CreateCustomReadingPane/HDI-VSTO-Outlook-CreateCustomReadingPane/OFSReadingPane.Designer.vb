Option Strict Off
Option Explicit On

Partial Class OFSReadingPane
    Inherits Microsoft.Office.Tools.Outlook.ImportedFormRegion

    Private WithEvents olkCategory1 As Microsoft.Office.Interop.Outlook.OlkCategory
    Private WithEvents olkInfoBar1 As Microsoft.Office.Interop.Outlook.OlkInfoBar
    Private WithEvents olkSenderPhoto1 As Microsoft.Office.Interop.Outlook.OlkSenderPhoto
    Private _DocSiteControl1 As Microsoft.Office.Interop.Outlook._DDocSiteControl

    Public Sub New(ByVal formRegion As Microsoft.Office.Interop.Outlook.FormRegion)
        MyBase.New(formRegion)
    End Sub

    <System.Diagnostics.DebuggerStepThrough()> _
    Protected Overrides Sub InitializeControls()
        Me.olkCategory1 = Me.GetFormRegionControl(Of Microsoft.Office.Interop.Outlook.OlkCategory)("OlkCategory1")
        Me.olkInfoBar1 = Me.GetFormRegionControl(Of Microsoft.Office.Interop.Outlook.OlkInfoBar)("OlkInfoBar1")
        Me.olkSenderPhoto1 = Me.GetFormRegionControl(Of Microsoft.Office.Interop.Outlook.OlkSenderPhoto)("OlkSenderPhoto1")
        Me._DocSiteControl1 = Me.GetFormRegionControl(Of Microsoft.Office.Interop.Outlook._DDocSiteControl)("_DocSiteControl1")

    End Sub

    Partial Public Class OFSReadingPaneFactory
        Implements Microsoft.Office.Tools.Outlook.IFormRegionFactory

        Public Event FormRegionInitializing As System.EventHandler(Of Microsoft.Office.Tools.Outlook.FormRegionInitializingEventArgs)

        Private _Manifest As Microsoft.Office.Tools.Outlook.FormRegionManifest

        <System.Diagnostics.DebuggerNonUserCodeAttribute()> _
        Public Sub New()
            Me._Manifest = New Microsoft.Office.Tools.Outlook.FormRegionManifest()
            Me.InitializeManifest()
        End Sub

        <System.Diagnostics.DebuggerNonUserCodeAttribute()> _
        ReadOnly Property Manifest() As Microsoft.Office.Tools.Outlook.FormRegionManifest Implements Microsoft.Office.Tools.Outlook.IFormRegionFactory.Manifest
            Get
                Return Me._Manifest
            End Get
        End Property

        <System.Diagnostics.DebuggerNonUserCodeAttribute()> _
        Function CreateFormRegion(ByVal formRegion As Microsoft.Office.Interop.Outlook.FormRegion) As Microsoft.Office.Tools.Outlook.IFormRegion Implements Microsoft.Office.Tools.Outlook.IFormRegionFactory.CreateFormRegion
            Dim form as OFSReadingPane = New OFSReadingPane(formRegion)
            form.Factory = Me
            Return form
        End Function

        <System.Diagnostics.DebuggerNonUserCodeAttribute()> _
        Function GetFormRegionStorage(ByVal outlookItem As Object, ByVal formRegionMode As Microsoft.Office.Interop.Outlook.OlFormRegionMode, ByVal formRegionSize As Microsoft.Office.Interop.Outlook.OlFormRegionSize) As Byte() Implements Microsoft.Office.Tools.Outlook.IFormRegionFactory.GetFormRegionStorage
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(OFSReadingPane))
            Return CType(resources.GetObject("CustomReadingPane"), Byte())
        End Function

        <System.Diagnostics.DebuggerNonUserCodeAttribute()> _
        Function IsDisplayedForItem(ByVal outlookItem As Object, ByVal formRegionMode As Microsoft.Office.Interop.Outlook.OlFormRegionMode, ByVal formRegionSize As Microsoft.Office.Interop.Outlook.OlFormRegionSize) As Boolean Implements Microsoft.Office.Tools.Outlook.IFormRegionFactory.IsDisplayedForItem
            Dim cancelArgs As Microsoft.Office.Tools.Outlook.FormRegionInitializingEventArgs = New Microsoft.Office.Tools.Outlook.FormRegionInitializingEventArgs(outlookItem, formRegionMode, formRegionSize, False)
            cancelArgs.Cancel = False
            RaiseEvent FormRegionInitializing(Me, cancelArgs)
            Return Not cancelArgs.Cancel
        End Function

        <System.Diagnostics.DebuggerNonUserCodeAttribute()> _
        ReadOnly Property Kind() As String Implements Microsoft.Office.Tools.Outlook.IFormRegionFactory.Kind
            Get
                Return Microsoft.Office.Tools.Outlook.FormRegionKindConstants.Ofs
            End Get
        End Property
    End Class

End Class

Partial Class WindowFormRegionCollection

    Friend ReadOnly Property OFSReadingPane() As OFSReadingPane
        Get
            Return Me.FindFirst(Of OFSReadingPane)()
        End Get
    End Property
End Class