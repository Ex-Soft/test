int main(void)
{
   const int
     Max=2;
     
   char
     **d;

   unsigned long
     a;
     
   d=new char* [Max];
   a=(unsigned long)d;
   
   d[0]=new char [Max];
   a=(unsigned long)d[0];
   d[1]=new char [Max];
   a=(unsigned long)d[1];
   
   *(d[0])=1;
   *(d[0]+1)=2;
   *(d[1])=3;
   *(d[1]+1)=4;
   
   int
     x;
     
   x=*(d[0]);
   x=*(d[0]+1);
   x=*(d[1]);
   x=*(d[1]+1);
   
   for(int i=0; i<Max; ++i)
      delete []d[i];
      
   delete []d;
}
