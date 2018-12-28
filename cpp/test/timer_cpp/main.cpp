// http://www.fluentcpp.com/2018/12/28/timer-cpp/

#include <iostream>
#include "timer.h"

int main(int argc, char **argv)
{
    Timer t = Timer();
 
    t.setInterval([&]() {
        std::cout << "Hey.. After each 1s..." << std::endl;
    }, 1000); 
 
    t.setTimeout([&]() {
        std::cout << "Hey.. After 5.2s. But I will stop the timer!" << std::endl;
        t.stop();
    }, 5200);

    std::cout << "I am Timer" << std::endl;

    while(true);

    return 0;
}
