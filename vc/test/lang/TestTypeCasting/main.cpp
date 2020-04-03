int main(int argc, char** argv)
{
	long double tmpLongDouble = 13;
	double tmpDouble = tmpLongDouble;
	float tmpFloat = tmpDouble;
	
	int tmpInt = tmpLongDouble;
	tmpInt = tmpDouble;
	tmpInt = tmpFloat;
	
	return 0;
}