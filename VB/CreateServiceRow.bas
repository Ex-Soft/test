Sub CreateServiceRow()
    Dim ws As Worksheet, r As Range, colName As String
    
    Set ws = Worksheets("base")
    ws.Rows(1).Insert shift:=xlShiftDown
    ws.Cells(1, 1).Value = "blah-blah-blah"
    ws.Cells(3, 1).Value = "LastCell.Column"
    ws.Cells(3, 2).Value = ws.Cells.SpecialCells(xlCellTypeLastCell).Column
    ws.Cells(4, 1).Value = "LastCell.Row"
    ws.Cells(4, 2).Value = ws.Cells.SpecialCells(xlCellTypeLastCell).Row
    
    Set r = ws.Range("b1:e1")
    For Each c In r.Cells
        If c.Column >= 2 Then colName = "1st"
        If c.Column >= 3 Then colName = colName & "_2nd"
        If c.Column >= 4 Then colName = colName & "_3rd"
        If c.Column >= 5 Then colName = colName & "_4th"
        ws.Cells(1, c.Column).Value = colName
    Next
End Sub
