//#include <iostream>

void swap_bad(int paramA, int paramB)
{
    int tmp = paramA;

    paramA = paramB;
    paramB = tmp;
}

void swapByPtr(int *paramA, int *paramB)
{
    int tmp = *paramA;

    *paramA = *paramB;
    *paramB = tmp;
}

void swapByReference(int &paramA, int &paramB)
{
    int tmp = paramA;

    paramA = paramB;
    paramB = tmp;
}

int main(int argc, char** argv)
{
    int
        a = 100,
        b = 200;

    swap_bad(a, b);
    swapByPtr(&a, &b);
    swapByReference(a, b);
/*
    a = 10;
    b = 20;

    int
        c,
        *ptrInt,
        &la = a,
        i,
        j;

    ptrInt = &a;
    *ptrInt = 100;

    ptrInt = &b;
    *ptrInt = 200;

    b = 300;

    la = 400;

    char
        str[15] = "blah-blah-blah",
        *ptrChar;

    ptrChar = str;

    int
        array[5] = { 1, 2, 3, 4, 5},
        darray[2][3] = { {10, 20, 30}, { 40, 50, 60 } };

    a = array[3];
    b = *(array + 3);

    for(i=0; i<6; ++i)
        std::cout << "array[" << i << "] = " << *(array + i) << std::endl;

    ptrInt = (int *)darray;
    for(i=0; i<2; ++i)
        for(j=0; j<3; ++j)
        {
            std::cout << "darray[" << i << "][" << j << "] = " << darray[i][j] << std::endl;
            std::cout << "darray[" << i << "][" << j << "] = " << *(ptrInt + (3 * i) + j) << std::endl;
        }
    
    for(i=0; i<6; ++i)
        std::cout << "darray[" << i << "] = " << *(ptrInt + i) << std::endl;
*/
    return 0;
}