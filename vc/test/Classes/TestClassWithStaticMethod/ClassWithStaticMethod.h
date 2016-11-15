//---------------------------------------------------------------------------

#ifndef ClassWithStaticMethodH
#define ClassWithStaticMethodH
//---------------------------------------------------------------------------

class ClassWithStaticMethod
{
public:
  int
    X;

  static int
    staticX;

   ClassWithStaticMethod(int aX=0);
   ClassWithStaticMethod(const ClassWithStaticMethod &aClassWithStaticMethod);
   virtual ~ClassWithStaticMethod(void);

   static void StaticMethod(void);
   static void SetStatic(int aX);
   static int GetStatic(void);
};
//---------------------------------------------------------------------------

#endif
