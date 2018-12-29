#include <iostream>

void Parameters1(void);
void Parameters2(void);
void CaptureByValueAll(void);
void CaptureByReferenceAll(void);
void CaptureMix1(void);
void CaptureMix2(void);
void CaptureMix3(void);

int main(int argc, char **argv)
{
    Parameters1();
    Parameters2();
    CaptureByValueAll();
    CaptureByReferenceAll();
    CaptureMix1();
    CaptureMix2();
    CaptureMix3();

    return 0;
}

void Parameters1(void)
{
    std::cout << __func__ << std::endl;

    auto f = [](auto x, auto y, auto z) -> int {
        return x + y + z;
    };

    std::cout << "result=" << f(1, 2, 3) << std::endl << std::endl;
}

void Parameters2(void)
{
    std::cout << __func__ << std::endl;

    auto f = [](int x = 1, int y = 2, int z = 3) -> int {
        return x + y + z;
    };

    std::cout << "result=" << f(10, 20) << std::endl << std::endl;
}

void CaptureByValueAll(void)
{
    std::cout << __func__ << std::endl;

    int
        a = 1,
        b = 2,
        c = 3;

    auto f = [=]() mutable -> void {
        std::cout << "b4 (from lambda) a=" << a << " b=" << b << " c=" << c << std::endl;
        ++a; ++b; ++c;
        std::cout << "after (from lambda) a=" << a << " b=" << b << " c=" << c << std::endl;
    };

    std::cout << "b4 a=" << a << " b=" << b << " c=" << c << std::endl;
    f();
    std::cout << "after a=" << a << " b=" << b << " c=" << c << std::endl << std::endl;
}

void CaptureByReferenceAll(void)
{
    std::cout << __func__ << std::endl;

    int
        a = 1,
        b = 2,
        c = 3;

    auto f = [&]() {
        std::cout << "b4 (from lambda) a=" << a << " b=" << b << " c=" << c << std::endl;
        ++a; ++b; ++c;
        std::cout << "after (from lambda) a=" << a << " b=" << b << " c=" << c << std::endl;
    };

    std::cout << "b4 a=" << a << " b=" << b << " c=" << c << std::endl;
    f();
    std::cout << "after a=" << a << " b=" << b << " c=" << c << std::endl << std::endl;
}

void CaptureMix1(void)
{
    std::cout << __func__ << std::endl;

    int
        a = 1,
        b = 2,
        c = 3;

    auto f = [&x = a, y = b, &z = c]() mutable -> void {
        std::cout << "b4 (from lambda) a=" << x << " b=" << y << " c=" << z << std::endl;
        ++x; ++y; ++z;
        std::cout << "after (from lambda) a=" << x << " b=" << y << " c=" << z << std::endl;
    };

    std::cout << "b4 a=" << a << " b=" << b << " c=" << c << std::endl;
    f();
    std::cout << "after a=" << a << " b=" << b << " c=" << c << std::endl << std::endl;
}

void CaptureMix2(void)
{
    std::cout << __func__ << std::endl;

    int
        a = 1,
        b = 2,
        c = 3;

    auto f = [&, b]() mutable -> void {
        std::cout << "b4 (from lambda) a=" << a << " b=" << b << " c=" << c << std::endl;
        ++a; ++b; ++c;
        std::cout << "after (from lambda) a=" << a << " b=" << b << " c=" << c << std::endl;
    };

    std::cout << "b4 a=" << a << " b=" << b << " c=" << c << std::endl;
    f();
    std::cout << "after a=" << a << " b=" << b << " c=" << c << std::endl << std::endl;
}

void CaptureMix3(void)
{
    std::cout << __func__ << std::endl;

    int
        a = 1,
        b = 2,
        c = 3;

    auto f = [&, b, c]() mutable -> void {
        std::cout << "b4 (from lambda) a=" << a << " b=" << b << " c=" << c << std::endl;
        ++a; ++b; ++c;
        std::cout << "after (from lambda) a=" << a << " b=" << b << " c=" << c << std::endl;
    };

    std::cout << "b4 a=" << a << " b=" << b << " c=" << c << std::endl;
    f();
    std::cout << "after a=" << a << " b=" << b << " c=" << c << std::endl << std::endl;
}
