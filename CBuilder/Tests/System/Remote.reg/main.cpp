//---------------------------------------------------------------------------

#include <vcl.h>
#include <Registry.hpp>
#pragma hdrstop

#define __READ__
//#define __WRITE__

#include "main.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

TMainForm *MainForm;
//---------------------------------------------------------------------------

__fastcall TMainForm::TMainForm(TComponent* Owner):TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::DoItBitBtnClick(TObject *Sender)
{
   AnsiString
     ComputerName=ComputerNameEdit->Text.Trim(),
     ConstSubKey="S-1-5-21-3751998713-3526479812-4071731626-",
     SubKey,
     Value;

   TRegistry
     *Reg=new TRegistry(
#if defined(__READ__)
   KEY_READ
#endif
#if defined(__WRITE__)
   KEY_WRITE
#endif
);

   TRegKeyInfo
     RegKeyInfo;

   bool
     AllOk;

   DoItBitBtn->Enabled=false;
   if(!ComputerName.IsEmpty() && ComputerName[1]!='\\' && ComputerName[2]!='\\')
     ComputerName="\\\\"+ComputerName;

   if(!Reg)
   {
      Application->MessageBox("I\'m so sorry - insufficient memory!!!",Application->Title.c_str(),MB_ICONERROR|MB_OK);
      return;
   }

   switch(RootKeyRadioGroup->ItemIndex)
     {
        case  0 : {
                     Reg->RootKey=HKEY_CLASSES_ROOT;
                     break;
                  }
        case  1 : {
                     Reg->RootKey=HKEY_CURRENT_USER;
                     break;
                  }
        case  2 : {
                     Reg->RootKey=HKEY_LOCAL_MACHINE;
                     break;
                  }
        case  3 : {
                     Reg->RootKey=HKEY_USERS;
                     break;
                  }
        case  4 : {
                     Reg->RootKey=HKEY_CURRENT_CONFIG;
                     break;
                  }
        default : {
                     Reg->RootKey=HKEY_CURRENT_USER;
                     break;
                  }
     }

   if(!Reg->RegistryConnect(ComputerName))
   {
      delete Reg;
      return;
   }

   SubKey=ConstSubKey+"1481\\Control Panel\\Desktop";
   if(Reg->OpenKey(SubKey,false)
#if defined(__READ__)
   && Reg->ValueExists("SCRNSAVE.EXE")
#endif
   )
   {
      AllOk=Reg->GetKeyInfo(RegKeyInfo);
#if defined(__READ__)
      Value=Reg->ReadString("SCRNSAVE.EXE");
      Value=Reg->ReadString("ScreenSaveActive");
      Value=Reg->ReadString("ScreenSaveTimeOut");
#endif
#if defined(__WRITE__)
      Reg->WriteString("SCRNSAVE.EXE","C:\\PROGRA~1\\SCREEN~1\\SYSINT~1.SCR");
      Reg->WriteString("ScreenSaveActive","1");
      Reg->WriteString("ScreenSaveTimeOut","60");
#endif
   }

/*   for(int i=0;i<10000;i++)
      {
         SubKey=ConstSubKey+FormatFloat("0000",i)+"\\Control Panel\\Desktop";
         if(Reg->OpenKey(SubKey,false) && Reg->ValueExists("Wallpaper"))
           {
              AllOk=Reg->GetKeyInfo(RegKeyInfo);
              Value=Reg->ReadString("Wallpaper")+ " ("+FormatFloat("0000",i)+")";
              break;
           }
      }*/

   PathEdit->Text=Value;
   delete Reg;
   DoItBitBtn->Enabled=true;
}
//---------------------------------------------------------------------------

