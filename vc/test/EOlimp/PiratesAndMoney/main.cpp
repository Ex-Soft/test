#include <iostream>
#include <cmath>

int A(int a1, int d, int n)
{
    std::cout << "A(" << a1 << ", " << d << ", " << n << ")" << std:: endl;

    int result = a1 + d*(n - 1);
    return result;
}

int S(int a, int n, int *aArray)
{
    std::cout << "S(" << a << ", " << n << ")" << std:: endl;
    int result = ((a + *(aArray + n))*n)/2;
    return result;
}

int main(int argc, char **argv)
{
    double
        x = 16,
        p = 0.5,
        result;

    result = std::exp(p * std::log(x));
    result = std::sqrt(x);
    result = std::pow(x,p);

    int
        a = 1,
        m = 15150,
        n = 1;

    while(a * 2 < m)
    {
        n++;
        m -= a;
        a++;
    }
    
    std::cout << "n = " << n << std::endl;

    a = 1;
    m = 15150;

    int
        aArray[15150];

    for(n = 2; (aArray[n] = A(a, 1, n))*2 < m - S(a, n-1, aArray); ++n)
        ;
    
    std::cout << "n = " << n << std::endl;

    a = 1;
    m = 15150;
    n = 2;

    while((aArray[n] = A(a, 1, n))*2 < m - S(a, n-1, aArray))
        ++n;
    
    std::cout << "n = " << n << std::endl;

    return 0;
}