#include <iostream>
#include <memory>

void foo(int*);
void bar(std::shared_ptr<int>);

int main(int argc, char **argv)
{
    std::unique_ptr<int> up1(new int(42));
    std::unique_ptr<int> up2 = std::move(up1); // transfer ownership

    if(up1)
        foo(up1.get());

    (*up2)++;

    if(up2)
        foo(up2.get());

    std::shared_ptr<int> sp1(new int(42));
    std::shared_ptr<int> sp2 = sp1;
   
    bar(sp1);
    foo(sp2.get());

    auto p = std::make_shared<int>(42);
    std::weak_ptr<int> wp = p;

    {
        auto sp = wp.lock();
        std::cout << *sp << std::endl;
    }

    p.reset();

    if(wp.expired())
        std::cout << "expired" << std::endl;

    return 0;
}

void foo(int* p)
{
   std::cout << *p << std::endl;
}

void bar(std::shared_ptr<int> p)
{
   ++(*p);
}
