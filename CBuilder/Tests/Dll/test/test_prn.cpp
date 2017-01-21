#include <vcl.h>
#include <comobj.hpp>

void test_prn(void)
{
   Variant MSWord=Unassigned;

   AnsiString CurrPath=GetCurrentDir(),SignatureDoc,OutputDoc,FileNameDoc="test.doc";
   int point;

   SignatureDoc=CurrPath+"\\"+FileNameDoc;
   point=SignatureDoc.LastDelimiter(".");
   OutputDoc=SignatureDoc.SubString(1,point-1)+"_.doc";

   if(!FileExists(SignatureDoc))
     {
        OutputDoc="Can\'t find file: "+SignatureDoc+"!!!";
        Application->MessageBox(OutputDoc.c_str(),Application->Title.c_str(),MB_OK|MB_ICONSTOP);
        return;
     }

   try
     {
        MSWord.Exec(Procedure("FileOpen")<<SignatureDoc);
     }
   catch(...)
     {
        try
          {
             MSWord=CreateOleObject("Word.Basic");
          }
        catch(...)
          {
             Application->MessageBox("Помилка Microsoft Word. Спробуйте закрити програму та запустити її знову.\nЯкщо помилка не зникне, зверніться до фірми Microsoft.",Application->Title.c_str(),MB_ICONERROR);
             return;
          }
        try
          {
             MSWord.Exec(Procedure("FileOpen")<<SignatureDoc);
          }
        catch(...)
          {
             Application->MessageBox((AnsiString("Помилка відкриття файлу '") + SignatureDoc + "'.\nПеревірте його існування.").c_str(),Application->Title.c_str(),MB_ICONERROR);
             return;
          }
     }

   MSWord.Exec(Procedure("EditFind")<<"Line1");
   MSWord.Exec(Procedure("Insert")<<"Test Test Test");

   MSWord.Exec(Procedure("EditFind")<<"Line2");
   MSWord.Exec(Procedure("Insert")<<"UkrSotsStrakh UkrSotsStrakh UkrSotsStrakh");

   MSWord.Exec(Procedure("EditFind")<<"Line3");
   MSWord.Exec(Procedure("Insert")<<"Ex_Soft Ex_Soft Ex_Soft");

   MSWord.Exec(Procedure("FileSaveAs")<<OutputDoc);

   MSWord.Exec(Procedure("FilePrint"));
   MSWord.Exec(Procedure("FileClose"));
   MSWord.Exec(Procedure("AppClose"));
}
