#include <iostream>
#include <iomanip>

int main(int argc, char** argv)
{
    int
        a = 10,
        b,
        c;

    std::cout << "a=" << std::setw(10) << std::setfill('0') << std::hex << std::setiosflags(std::ios::showbase) << a << std::endl;

    std::cout << "> ";
    std::cin >> b >> c;

    std::cout << "b=" << b << " " << "c=" << c << std::endl;

    return 0;
}