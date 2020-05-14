struct TestStruct
{
	int
		fInt1,
		fInt2,
		fInt3;
};

int fooC(int, int, int *, int &);
void fooAsm(int, int, int *, int &);
TestStruct fooCWTestStruct(TestStruct);
void fooAsmWTestStruct(TestStruct);

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

	TestStruct testStructIn = TestStruct();
	testStructIn.fInt1 = 0xaa;
	testStructIn.fInt2 = 0xbb;
	testStructIn.fInt3 = 0xcc;
	TestStruct testStructOut = fooCWTestStruct(testStructIn);

	fooAsmWTestStruct(testStructIn);

	return 0;
}

int fooC(int a, int b, int *c, int &d)
{
	int local1 = 0x0fedc, local2 = 0x04321;
	return a + b + *c + d + local1 + local2;
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

TestStruct fooCWTestStruct(TestStruct testStruct)
{
	testStruct.fInt1 += testStruct.fInt1;
	testStruct.fInt2 += testStruct.fInt2;
	testStruct.fInt3 += testStruct.fInt3;

	return testStruct;
}

void fooAsmWTestStruct(TestStruct testStruct)
{
	__asm
	{
		mov eax, dword ptr [ebp + 08h]
		add eax, 0aa00h
		mov dword ptr[ebp + 08h], eax
		mov eax, dword ptr [ebp + 0ch]
		add eax, 0bb00h
		mov dword ptr[ebp + 0ch], eax
		mov eax, dword ptr [ebp + 010h]
		add eax, 0cc00h
		mov dword ptr[ebp + 010h], eax
	}
}