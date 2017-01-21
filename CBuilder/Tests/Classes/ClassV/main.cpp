//---------------------------------------------------------------------------
#include <iostream>

#pragma hdrstop
//---------------------------------------------------------------------------

using namespace std;

class Class
{
public:
   void Show(void){cout<<"Class";};
};

#pragma argsused
int main(int argc, char* argv[])
{
   Class
     Class;

   Class.Show();

   return 0;
}
//---------------------------------------------------------------------------
