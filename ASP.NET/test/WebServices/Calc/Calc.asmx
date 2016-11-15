<%@ WebService Language="C#" Class="CalcService" %>

using System;
using System.Web.Services;

[WebService (Name="Calculator Web Service", Description="Performs simple math over the Web")]
class CalcService
{
	[WebMethod (Description="Computes the sum of two integers")]
	public int Add(int a, int b)
	{
		return(a+b);
	}
	[WebMethod (Description="Computes the difference between two integers")]
	public int Substract(int a, int b)
	{
		return(a-b);
	}
}