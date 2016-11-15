Imports Forms = Microsoft.Vbe.Interop.Forms

Public Class OFSReadingPane


#Region "Form Region Factory"

  <Microsoft.Office.Tools.Outlook.FormRegionMessageClass("IPM.Note.CustomReadingPane")> _
  <Microsoft.Office.Tools.Outlook.FormRegionName("HDI-VSTO-Outlook-CreateCustomReadingPane.OFSReadingPane")> _
  Partial Public Class OFSReadingPaneFactory

    Private Sub InitializeManifest()
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(OFSReadingPane))
      Me.Manifest.FormRegionType = Microsoft.Office.Tools.Outlook.FormRegionType.Replacement
      Me.Manifest.Title = resources.GetString("Title")
      Me.Manifest.FormRegionName = resources.GetString("FormRegionName")
      Me.Manifest.Description = resources.GetString("Description")
      Me.Manifest.ShowInspectorCompose = False
      Me.Manifest.ShowInspectorRead = False
      Me.Manifest.ShowReadingPane = True

    End Sub

    ' Occurs before the form region is initialized.
    ' To prevent the form region from appearing, set e.Cancel to true.
    ' Use e.OutlookItem to get a reference to the current Outlook item.
    Private Sub OFSReadingPaneFactory_FormRegionInitializing(ByVal sender As Object, ByVal e As Microsoft.Office.Tools.Outlook.FormRegionInitializingEventArgs) Handles Me.FormRegionInitializing

    End Sub

  End Class

#End Region


  Private WithEvents btnCreateReminder As Outlook.OlkCommandButton
  Shadows WithEvents UserForm As Forms.UserForm


  Private Sub OFSReadingPane_FormRegionShowing(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.FormRegionShowing
    UserForm = Me.OutlookFormRegion.Form
    btnCreateReminder = DirectCast(UserForm.Controls.Item("btnCreateReminder"), Outlook.OlkCommandButton)

  End Sub

  Private Sub OFSReadingPane_FormRegionClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.FormRegionClosed


  End Sub

  Private Sub btnCreateReminder_Click() Handles btnCreateReminder.Click
    Dim newAppt As Outlook.AppointmentItem = Globals.ThisAddIn.Application.CreateItem(Outlook.OlItemType.olAppointmentItem)
    Dim currentMail As Outlook.MailItem = Me.OutlookItem

    newAppt.Subject = currentMail.Subject
    newAppt.Body = currentMail.Body
    newAppt.Start = DateAdd(DateInterval.Minute, 30, Now)
    newAppt.End = DateAdd(DateInterval.Minute, 0, newAppt.Start)

    newAppt.ReminderSet = True
    newAppt.ReminderMinutesBeforeStart = 0
    newAppt.Save()
    newAppt.Display()

  End Sub


End Class
