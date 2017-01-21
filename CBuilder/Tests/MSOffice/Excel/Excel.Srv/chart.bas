Sub Макрос1()
'
' Макрос1 Макрос
' Макрос записан 17.09.2004 (Igor Nozhenko)
'

'
    Charts.Add
    ActiveChart.ChartType = xlLineMarkers
    ActiveChart.SeriesCollection(1).Delete
    ActiveChart.SeriesCollection(1).XValues = "=Лист1!R1C1:R19C1"
    ActiveChart.SeriesCollection(1).Name = "=""sin"""
    ActiveChart.SeriesCollection(2).XValues = "=Лист1!R1C1:R19C1"
    ActiveChart.SeriesCollection(2).Name = "=""cos"""
    ActiveChart.Location Where:=xlLocationAsObject, Name:="Лист1"
    With ActiveChart
        .HasTitle = True
        .ChartTitle.Characters.Text = "name"
        .Axes(xlCategory, xlPrimary).HasTitle = True
        .Axes(xlCategory, xlPrimary).AxisTitle.Characters.Text = "x"
        .Axes(xlValue, xlPrimary).HasTitle = True
        .Axes(xlValue, xlPrimary).AxisTitle.Characters.Text = "y"
    End With
    With ActiveChart.Axes(xlCategory)
        .HasMajorGridlines = False
        .HasMinorGridlines = False
    End With
    With ActiveChart.Axes(xlValue)
        .HasMajorGridlines = True
        .HasMinorGridlines = False
    End With
    ActiveChart.HasLegend = True
    ActiveChart.Legend.Select
    Selection.Position = xlBottom
    ActiveChart.ApplyDataLabels Type:=xlDataLabelsShowNone, LegendKey:=False
    ActiveChart.HasDataTable = False
    ActiveSheet.Shapes("Диагр. 1").IncrementLeft 13.5
    ActiveSheet.Shapes("Диагр. 1").IncrementTop -72#
    ActiveSheet.Shapes("Диагр. 1").ScaleHeight 1.55, msoFalse, msoScaleFromTopLeft
    ActiveSheet.Shapes("Диагр. 1").ScaleWidth 1.44, msoFalse, msoScaleFromTopLeft
End Sub
