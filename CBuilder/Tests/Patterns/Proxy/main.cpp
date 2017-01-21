//---------------------------------------------------------------------------

#include <vcl.h>
#include <iostream>
#pragma hdrstop
//---------------------------------------------------------------------------

using namespace std;

// "Subject"
class IMath
{
public:
    virtual double add(double x, double y) = 0;
    virtual double sub(double x, double y) = 0;
    virtual double mul(double x, double y) = 0;
    virtual double div(double x, double y) = 0;
};

// "Real Subject"
class Math : public IMath
{
public:
    double add(double x, double y) {
        return x + y;
    }

    double sub(double x, double y) {
        return x - y;
    }

    double mul(double x, double y) {
        return x * y;
    }

    double div(double x, double y) {
        return x / y;
    }
};

// "Proxy Object"
class MathProxy : public IMath {
public:
    double add(double x, double y) {
        return math.add(x, y);
    }

    double sub(double x, double y) {
        return math.sub(x, y);
    }

    double mul(double x, double y) {
        return math.mul(x, y);
    }

    double div(double x, double y) {
        return math.div(x, y);
    }

private:
    Math math;
};

#pragma argsused
int main(int argc, char* argv[])
{
   // Create math proxy
   MathProxy
     p;

    // Do the math
   cout << "4 + 2 = " << p.add(4, 2) << endl;
   cout << "4 - 2 = " << p.sub(4, 2) << endl;
   cout << "4 * 2 = " << p.mul(4, 2) << endl;
   cout << "4 / 2 = " << p.div(4, 2) << endl;

   return 0;
}
//---------------------------------------------------------------------------
 