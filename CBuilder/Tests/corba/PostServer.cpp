//---------------------------------------------------------------------------

#include <corbapch.h>
#pragma hdrstop

#include <corba.h>
#include "PostServer.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)


PostImpl::PostImpl(const char *object_name):
        _sk_PostModule::_sk_Post(object_name)
{
}

CORBA::Long PostImpl::GetText(const char* _text, const char* _name)
{
   Cout<<"Text: "<<_text<<Endl;
   Cout<<"Sender: "<<_name<<Endl;
   int words=0;
   for(int i=0;i<(int)strlen(_text);i++)
      {
         char ch=_text[i];
         if((ch==' ')||(ch==',')||(ch=='.'))
           words++;
      }
   if(words>32)
     {
        Cout<<" Too many words you say..."<<Endl;
        CapacityExceeded excep(32);
        throw excep;
     }
   return words;
}
