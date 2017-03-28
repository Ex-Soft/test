#include <stdio.h>
#include <math.h>

double mysqrt(double inputValue)
{
	fprintf(stdout, "mysqtr\r\n");
	double result;
	
	// if we have both log and exp then use them
	#if defined (HAVE_LOG) && defined (HAVE_EXP)
		fprintf(stdout, "exp(log(inputValue)*0.5)\r\n");
		result = exp(log(inputValue)*0.5);
	#else
		fprintf(stdout, "sqrt(inputValue)\r\n");
		result = sqrt(inputValue);
	#endif

	return result;
}