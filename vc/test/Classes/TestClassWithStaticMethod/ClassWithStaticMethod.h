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

   ClassWithStaticMethod(int = 0);
   ClassWithStaticMethod(const ClassWithStaticMethod&);
   virtual ~ClassWithStaticMethod(void);

   static void StaticMethod(void);
   static void SetStatic(int);
   static int GetStatic(void);
};
//---------------------------------------------------------------------------

#endif
