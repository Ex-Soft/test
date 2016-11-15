Imports System
Imports System.Reflection
<Assembly:AssemblyKeyFile ("KeyFile.snk")>
<Assembly:AssemblyVersion ("1.0.0.0")>

Public Class SimpleMath
	Function Add (a As Integer, b As Integer) As Integer
		Return a + b
	End Function

	Function Subtract (a As Integer, b As Integer) As Integer
		Return a - b
	End Function
End Class