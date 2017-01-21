Sub TestRange()
aArr = Array("A1", "A2", "A3", "A4")
ActiveSheet.Range("A1:A4").Value = aArr
ActiveSheet.Range("A5:A8").Value2 = aArr
aArr1x4 = Array(Array("B1", "B2", "B3", "B4"))
ActiveSheet.Range("B1:B4").Value = aArr1x4
ActiveSheet.Range("B5:B8").Value2 = aArr1x4
aArr4x1 = Array(Array("C1"), Array("C2"), Array("C3"), Array("C4"))
ActiveSheet.Range("C1:C4").Value = aArr4x1
ActiveSheet.Range("C5:C8").Value2 = aArr4x1

aArr = Array(Array("A1", "A2", "A3", "A4"), Array("B1", "B2", "B3", "B4"), Array("C1", "C2", "C3", "C4"))
ActiveSheet.Range("A1:C4") = Application.Transpose(aArr)

Dim aArr4x2(1 To 4, 1 To 2)
aArr4x2(1, 1) = "D1"
aArr4x2(2, 1) = "D2"
aArr4x2(3, 1) = "D3"
aArr4x2(4, 1) = "D4"
aArr4x2(1, 2) = "E1"
aArr4x2(2, 2) = "E2"
aArr4x2(3, 2) = "E3"
aArr4x2(4, 2) = "E4"
ActiveSheet.Range("D1:E4") = aArr4x2

End Sub
