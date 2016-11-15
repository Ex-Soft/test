#include<iostream>

bool IsPrimeNumber(int candidate);

int main(void)
{
    const int N = 10;

    int
        primeNumber[N],
        i = 0,
        candidate = 1;

    do
    {
        if(IsPrimeNumber(++candidate))
            primeNumber[i++] = candidate;
    }
    while(i < N);

    for(i = 0; i < N; i++)
        std::cout<<primeNumber[i]<<std::endl;

    return 0;
}

bool IsPrimeNumber(int candidate)
{
    for(int i = 2; i < candidate; i++)
        if(candidate%i == 0)
            return false;

    return true; 
}