#include <iostream>

void ShowCmdLine(int argc, char **argv)
{
    for(int i=0; i<argc; ++i)
        std::cout<<"Param #"<<i<<": \""<<*(argv+i)<<"\""<<std::endl;
}
