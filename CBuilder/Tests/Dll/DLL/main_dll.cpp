//---------------------------------------------------------------------------

#include <vcl.h>
#include <windows.h>
#include <new>
#pragma hdrstop

#include "main_dll.h"
#include "form_dll.h"

#pragma argsused
int WINAPI DllEntryPoint(HINSTANCE hinst, unsigned long reason, void* lpReserved)
{
   return(1);
}
//---------------------------------------------------------------------------

void WINAPI ShowDynamicTestForm(HWND Parent, AnsiString ShowString)
{
   TForm *MainForm;
   TLabel *ShowStringLabel;

   try
     {
        MainForm=new TForm((void *)NULL);
        ShowStringLabel=new TLabel(MainForm);
     }
   catch(std::bad_alloc)
     {
        if(ShowStringLabel)
          delete ShowStringLabel;
        if(MainForm)
          delete MainForm;
        return;
     }

   SetWindowLong(MainForm->Handle,GWL_HWNDPARENT,(LONG)Parent);
   MainForm->AutoSize=false;
   MainForm->BorderIcons=TBorderIcons()<<biSystemMenu<<biMinimize<<biMaximize;
   MainForm->BorderStyle=bsSingle;
   MainForm->Caption="New Form";
   MainForm->Icon->LoadFromFile("D:\\PROGRAM FILES\\COMMON FILES\\BORLAND SHARED\\IMAGES\\ICONS\\EARTH.ICO");
   MainForm->Position=poScreenCenter;
   MainForm->Scaled=false;

   ShowStringLabel->Parent=MainForm;
   ShowStringLabel->Alignment=taCenter;
   ShowStringLabel->AutoSize=false;
   ShowStringLabel->Color=clRed;
   ShowStringLabel->Font->Color=clAqua;
   ShowStringLabel->Font->Size=12;
   ShowStringLabel->Font->Style=TFontStyles()<<fsBold<<fsItalic<<fsUnderline;
   ShowStringLabel->Caption=ShowString;
   ShowStringLabel->Height=MainForm->ClientHeight-10;
   ShowStringLabel->Width=MainForm->ClientWidth-10;
   ShowStringLabel->Left=(MainForm->ClientWidth-ShowStringLabel->Width)/2;
   ShowStringLabel->Top=(MainForm->ClientHeight-ShowStringLabel->Height)/2;

   MainForm->ShowModal();

   delete ShowStringLabel;
   delete MainForm;
}
//---------------------------------------------------------------------------

void WINAPI ShowStaticTestForm(HWND Parent, AnsiString ShowString)
{
   try
     {
        DFMForm=new TDFMForm(NULL);
     }
   catch(std::bad_alloc)
     {
        return;
     }
   SetWindowLong(DFMForm->Handle,GWL_HWNDPARENT,(LONG)Parent);
   DFMForm->ShowLabel->Caption=ShowString;
   DFMForm->ShowModal();

   delete DFMForm;
}
//---------------------------------------------------------------------------

