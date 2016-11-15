int _cdecl _cdeclFunc(int a, int b, int c)
{
	return a + b + c;
}

int _stdcall _stdcallFunc(int a, int b, int c)
{
	return a + b + c;
}

int _fastcall _fastcallFunc(int a, int b, int c)
{
	return a + b + c;
}

int main(int argc, char **argv)
{
	int
		x = 1,
		y = 2,
		z = 3,
		result = 0x0ffffffff;

	result = _cdeclFunc(x, y, z);
	result = _stdcallFunc(x, y, z);
	result = _fastcallFunc(x, y, z);

	return 0;
}