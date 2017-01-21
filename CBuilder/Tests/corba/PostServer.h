//---------------------------------------------------------------------------

#ifndef PostServerH
#define PostServerH
#include "PostServ_s.hh"
//---------------------------------------------------------------------------
class PostImpl: public _sk_PostModule::_sk_Post
{
protected:
public:
        PostImpl(const char *object_name=NULL); 
        CORBA::Long GetText(const char* _text, const char* _name);
};
#endif
