//---------------------------------------------------------------------------

#include <vcl.h>
#include <fstream>
#pragma hdrstop

//---------------------------------------------------------------------------

int ReadIntFromFileDef(AnsiString InputFileName, int DefaultValue);

#pragma argsused
int main(int argc, char* argv[])
{
   AnsiString
     FileName="stub.log";

   std::fstream
     LogFile;

   LogFile.open(FileName.c_str(),std::ios_base::out|std::ios_base::trunc);
   if(!LogFile.is_open() || !LogFile.good())
   {
      FileName="Can't open file: \""+FileName+"\"";
      throw Exception(FileName);
   }

   FileName=Now().DateTimeString();
   LogFile<<FileName.c_str()<<" started..."<<std::endl;

   for(int i=1; i<argc; ++i)
      LogFile<<"argv["<<i<<"]="<<*(argv+i)<<std::endl;
      
   FileName="sleep";

   int
     dwMilliseconds=ReadIntFromFileDef(FileName,0);

   if(dwMilliseconds)
     Sleep(dwMilliseconds*1000);

   FileName="return";

   int
     ReturnValue=ReadIntFromFileDef(FileName,0);

   FileName=Now().DateTimeString();
   LogFile<<FileName.c_str()<<" finished"<<std::endl;
   LogFile.close();

   return(ReturnValue);
}
//---------------------------------------------------------------------------

int ReadIntFromFileDef(AnsiString InputFileName, int DefaultValue)
{
   if(!FileExists(InputFileName))
     return(DefaultValue);

   char
     *Buff=0;

   unsigned int
     BuffSize=0xffff,
     len;

   std::fstream
     InputFile;

   AnsiString
     Mess;

   int
     Result;

   try
   {
      while(!Buff&&BuffSize)
      {
         Buff=new char [BuffSize];
         if(!Buff)
           BuffSize>>=1;
      }
      if(!Buff&&!BuffSize)
      {
         Mess="Insufficient memory";
         throw Exception(Mess);
      }

      InputFile.open(InputFileName.c_str(),std::ios_base::in);
      if(!InputFile.is_open() || !InputFile.good())
      {
         Mess="Can't open file: \""+InputFileName+"\"";
         throw Exception(Mess);
      }

      while(!InputFile.eof())
      {
         InputFile.getline(Buff,BuffSize);
         if(!InputFile.good() && !InputFile.eof())
         {
            Mess="Data read error from file: \""+InputFileName+"\"";
            throw Exception(Mess);
         }

         if((len=strlen(Buff)) && *(Buff+len-1)=='\n')
           *(Buff+len-1)='\x0';

         Result=StrToIntDef(Buff,DefaultValue);
         break;
      }
   }
   __finally
   {
      if(Buff)
        delete []Buff;

      if(InputFile.is_open())
        InputFile.close();
   }

   return(Result);
}
//---------------------------------------------------------------------------
