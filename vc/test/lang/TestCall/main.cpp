int fooC(int, int, int *, int &);
void fooAsm(int, int, int *, int &);

int main(int argc, char **argv)
{
	int
		param1 = 0x6789,
		param2 = 0xfefe,
		result;

	fooAsm(0xabcd, 0x1234, &param1, param2);
	__asm
	{
		mov	result, eax
	}
	
	result = fooC(1, 2, &param1, param2);
	
	return 0;
}

int fooC(int a, int b, int *c, int &d)
{
	return a + b + *c + d;
}

void fooAsm(int a, int b, int *c, int &d)
{
	__asm
	{
		mov	eax, dword ptr [ebp + 08h]
		and	eax, 010101b
		mov	ebx, dword ptr [ebp + 0ch]
		add	eax, ebx
		mov	ebx, dword ptr[ebp + 010h]
		add eax, dword ptr [ebx]
		mov	dword ptr [ebx], 0abcdh
		mov	ebx, dword ptr[ebp + 014h]
		add eax, dword ptr[ebx]
		mov	dword ptr[ebx], 04321h
	}
}

