int _cdecl _cdeclFunc(int x, int y, int z)
{
        return x + y + z;
}

int _stdcall _stdcallFunc(int x, int y, int z)
{
        return x + y + z;
}

int _fastcall _fastcallFunc(int x, int y, int z)
{
        return x + y + z;
}

int main(int argc, char* argv[])
{
        int
                a = 1,
                b = 2,
                c = 3,
                result = 0x0ffffffff;

        result = _cdeclFunc(a, b, c);
        result = _stdcallFunc(a, b, c);
        result = _fastcallFunc(a, b, c);

        return 0;
}

 