//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "main.h"
#include "dbf_tool.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

extern bool __fastcall DeleteFoxProDataBase(AnsiString FoxProDataBaseDir, AnsiString FoxProDataBaseName);
extern bool __fastcall CreateFoxProDataBase(AnsiString DataBaseDir, AnsiString FoxProDataBaseName, SFieldDef *FieldDef, int FielDefSize, SIndexDef *IndexDef=NULL, int IndexDefSize=0);

AnsiString
  FoxProDataBaseDir=ExtractFilePath(Application->ExeName),
  FoxProDataBaseName="test.tst";

TMainForm *MainForm;
//---------------------------------------------------------------------------

__fastcall TMainForm::TMainForm(TComponent* Owner):TForm(Owner)
{
   DeleteFoxProDataBase(FoxProDataBaseDir,FoxProDataBaseName);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::CreateAddClick(TObject *Sender)
{
   SFieldDef
     BlankDef[]={{"USBNUMBER",ftWord,0,0},
                 {"BLANK_NO",ftWord,0,0},
                 {"STATE",ftSmallint,0,0},
                 {"STATUS",ftSmallint,0,0},
                 {"USER_ID",ftSmallint,0,0},
                 {"N_REQUEST",ftFloat,0,0},
                 {"D_REQUEST",ftDate,0,0},
                 {"N_FIL_TO",ftFloat,0,0},
                 {"D_FIL_TO",ftDate,0,0},
                 {"N_ENV_TO",ftString,20,0},
                 {"D_ENV_TO",ftDate,0,0,},
                 {"N_FIL_FROM",ftFloat,0,0},
                 {"D_FIL_FROM",ftDate,0,0},
                 {"N_ENV_FROM",ftString,20,0},
                 {"D_ENV_FROM",ftDate,0,0}
                };

   SIndexDef
     BlankIndexDef[]={{"BLANK_NO","BLANK_NO",false,false,false},
                      {"N_FIL_FROM","N_FIL_FROM",false,false,false},
                      {"N_FIL_TO","N_FIL_TO",false,false,false},
                      {"N_REQUEST","N_REQUEST",false,false,false},
                      {"EXPRESS","USBNUMBER+BLANK_NO+USER_ID",true,false,false}
                     };

   CreateFoxProDataBase(FoxProDataBaseDir,FoxProDataBaseName,BlankDef,sizeof(BlankDef)/sizeof(SFieldDef),BlankIndexDef,sizeof(BlankIndexDef)/sizeof(SIndexDef));
}
//---------------------------------------------------------------------------
