// Codility.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

int solution(int A[], int N);

int _tmain(int argc, _TCHAR* argv[])
{
    int
        A[] = { 3, 1, 2, 4, 3},
        min;

    min = solution(A, sizeof(A)/sizeof(A[0]));

	return 0;
}

int solution(int A[], int N) {
    int
        left = A[0],
        right = 0,
        min,
        tmpMin,
        i;
        
    for(i=1; i<N; ++i)
        right += A[i];
    
    min = abs(left-right);
    
    for(i=1; i<N-1; ++i)
        if((tmpMin = abs((left+=A[i]) - (right-=A[i]))) < min)
            min = tmpMin;

    return min;
}
