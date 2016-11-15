#include <stdio.h>

int main(int argc, char** argv)
{
    int
        a = 10,
        b = 20,
        c;

    char
        sc = 0x7f,
        scII = 0x81,
        scIII = 0x082,
        scIV = 0xfe,
        scV = 0xfd;

    unsigned char
        uc = 0x7f,
        ucII = 0x81,
        ucIII = 0x82;

    float
        f1 = 0.1;

    double
        d1 = 0.1;

    sc |= 0x80;
    uc |= 0x80;

    printf("blah-blah-blah a=%010d b=%d f1=%010.5f d1=%010f\n", a, b, f1, d1);

    scanf("%d %d", &b, &c);

    printf("b=%d c=%d\n", b, c);

    return 0;
}