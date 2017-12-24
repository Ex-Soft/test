int fooC(int, int);
void fooAsm(int);

int main(int argc, char **argv)
{
	int result;

	fooAsm(0xabcd);
	__asm
	{
		mov	result, eax
	}
	
	result = fooC(1, 2);
	
	return 0;
}

int fooC(int a, int b)
{
	return a + b;
}

void fooAsm(int a)
{
	__asm
	{
		mov	eax, [ebp + 08h]
		and	eax, 010101b
	}
}

