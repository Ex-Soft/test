#include <iostream>

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

	const int
		SizeMaxX = 2,
		SizeMaxY = 3;

    int
        array[5] = { 1, 2, 3, 4, 5},
        darray[SizeMaxX][SizeMaxY] = { {10, 20, 30}, { 40, 50, 60 } };

    a = array[3];
    b = *(array + 3);

    for(i = 0; i < 6; ++i)
        std::cout << "array[" << i << "] = " << *(array + i) << std::endl;

    ptrInt = (int *)darray;
    for(i = 0; i < SizeMaxX; ++i)
        for(j = 0; j < SizeMaxY; ++j)
        {
            std::cout << "darray[" << i << "][" << j << "] = " << darray[i][j] << std::endl;
            std::cout << "darray[" << i << "][" << j << "] = " << *(ptrInt + (SizeMaxY * i) + j) << std::endl;
        }
    
    for(i = 0; i < SizeMaxX * SizeMaxY; ++i)
        std::cout << "darray[" << i << "] = " << *(ptrInt + i) << std::endl;

	ptrInt = new int[SizeMaxX * SizeMaxY];
	memset(ptrInt, 0, SizeMaxX * SizeMaxY);

	for (i = 0; i < SizeMaxX; ++i)
		for (j = 0; j < SizeMaxY; ++j)
		{
			//std::cout << "darray[" << i << "][" << j << "] = " << ptrInt[i][j] << std::endl; // Error C2109 subscript requires array or pointer type
			std::cout << "darray[" << i << "][" << j << "] = " << *(ptrInt + (SizeMaxY * i) + j) << std::endl;
		}

	delete []ptrInt;

	int
		**arr = 0;

	arr = new int*[SizeMaxX];
	for (i = 0; i < SizeMaxX; ++i)
		arr[i] = new int[SizeMaxY];

	for (i = 0; i < SizeMaxX; ++i)
		for (j = 0; j < SizeMaxY; ++j)
			arr[i][j] = i + j;

	for (i = 0; i < SizeMaxX; ++i)
		for (j = 0; j < SizeMaxY; ++j)
		{
			std::cout << "arr[" << i << "][" << j << "] = " << arr[i][j] << std::endl;
		}

	for (i = 0; i < SizeMaxX; ++i)
		delete []arr[i];

	delete []arr;

    return 0;
}