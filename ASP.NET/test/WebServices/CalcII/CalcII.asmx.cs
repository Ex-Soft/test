using System.Web.Services;

namespace CalcII
{
    [WebService(Name="Calculator Web Service", Description="Performs simple math over the Web")]
    public class CalcII
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
}
