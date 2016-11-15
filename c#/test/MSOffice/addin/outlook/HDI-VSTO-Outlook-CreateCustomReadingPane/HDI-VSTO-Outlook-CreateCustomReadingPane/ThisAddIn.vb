Imports Microsoft.Office.Core

Public Class ThisAddIn

  Dim WithEvents _ex As Outlook.Explorer


  Private Sub ThisAddIn_Startup(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Startup
    _ex = Globals.ThisAddIn.Application.ActiveExplorer

  End Sub

  Private Sub ThisAddIn_Shutdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shutdown

  End Sub


  Private Sub ChangeMessageClass(ByVal mail As Outlook.MailItem)
    Dim newClass As String = "IPM.Note.CustomReadingPane"

    mail.MessageClass = newClass
    mail.Save()

  End Sub


  Private Sub _ex_SelectionChange() Handles _ex.SelectionChange
    Dim inbox As Outlook.Folder
    inbox = Globals.ThisAddIn.Application.ActiveExplorer.CurrentFolder
    Dim mi As Outlook.MailItem = _ex.Selection.Item(1)
    If mi.MessageClass <> "IPM.Note.CustomReadingPane" Then
      ChangeMessageClass(mi)
    End If

  End Sub



End Class
