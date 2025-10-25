Sub CreateSheetAndCopyData()
    Dim wsSource As Worksheet
    Dim wsNew As Worksheet
    Dim sheetName As String
    Dim sourceSheetIndex As Integer
    Dim lastRow As Long
    Dim i As Long
    Dim iNew As Long
    
    sourceSheetIndex = 2
    Set wsSource = ThisWorkbook.Sheets(sourceSheetIndex)
    
    sheetName = "CopiedData"
    
    On Error Resume Next
    Application.DisplayAlerts = False
    ThisWorkbook.Sheets(sheetName).Delete
    Application.DisplayAlerts = True
    On Error GoTo 0
    
    Set wsNew = ThisWorkbook.Sheets.Add(After:=ThisWorkbook.Sheets(ThisWorkbook.Sheets.Count))
    wsNew.Name = sheetName
    
    lastRow = wsSource.Cells.SpecialCells(xlCellTypeLastCell).Row
    iNew = 1
    
    For i = 8 To lastRow
        Dim valRank As Variant, valName As Variant
        Dim colRank As Long, colName As Long
        
        colRank = 6
        colName = 7
        valRank = wsSource.Cells(i, colRank).Value
        valName = wsSource.Cells(i, colName).Value
        
        If IsNonEmptyString(valRank) Or IsNonEmptyString(valName) Then
            If IsNonEmptyString(valRank) Then
                wsNew.Cells(iNew, 1).Value = ConvertRank(CStr(valRank))
            End If
            
            If IsNonEmptyString(valName) Then
                wsNew.Cells(iNew, 2).Value = valName
            End If
            
            iNew = iNew + 1
        End If
    Next i
    
    MsgBox "New sheet '" & sheetName & "' created and data copied.", vbInformation
End Sub

Function IsNonEmptyString(val As Variant) As Boolean
    IsNonEmptyString = VarType(val) = vbString And Len(Trim(val)) > 0
End Function

Function ConvertRank(inputStr As String) As String
    Select Case Trim(UCase(inputStr))
        Case "Ï²ÄÏÎËÊÎÂÍÈÊ"
            ConvertRank = "ï/ï-ê"
        Case "ÌÀÉÎÐ"
            ConvertRank = "ì-ð"
        Case Else
            ConvertRank = inputStr
    End Select
End Function

