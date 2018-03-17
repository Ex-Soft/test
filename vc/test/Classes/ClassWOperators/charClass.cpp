#include "CharClass.h"

using namespace std;

CharClass::CharClass(char aC) : c(aC)
{
    cout << "CharClass::CharClass(char)" << " c = " << aC << endl;
}

CharClass::CharClass(int aC) : c(aC)
{
    cout << "CharClass::CharClass(int)" << " c = " << aC << endl;
}

CharClass::CharClass(long aC) : c(aC)
{
    cout << "CharClass::CharClass(long)" << " c = " << aC << endl;
}

CharClass::CharClass(const CharClass &c) : c(c.c)
{
    cout<<"CharClass::CharClass(const CharClass&)"<<endl;
}

CharClass::~CharClass(void)
{
    cout<<"CharClass::~CharClass(void)"<<endl;
}

ostream& operator << (ostream& os, const CharClass &aCharClass)
{
    os<<"{ x: " << aCharClass.c << " }";

    return os;
}