//---------------------------------------------------------------------------

#include <vcl.h>
#include <fstream>
#pragma hdrstop

#include "main.h"
#include "child.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

#define CREATE_BY_NEW

extern std::fstream
  File;

TMainForm *MainForm;
//---------------------------------------------------------------------------

__fastcall TMainForm::TMainForm(TComponent* Owner):TForm(Owner)
{
   Application->OnException=OnAppException;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormCreate(TObject *Sender)
{
   if(File.is_open() && File.good())
     File<<"MainForm OnCreate"<<std::endl;

   ForReallyAnyTestBitBtn->Height=caFreeCheckBox->Top-5;
   ForReallyAnyTestBitBtn->Width=ClientWidth;
   ForReallyAnyTestBitBtn->Caption=AnsiString("For\r\n")+"Really\r\n"+"Any\r\n"+"Test's\r\n"+"Button";
   long btnstyle=GetWindowLong(ForReallyAnyTestBitBtn->Handle,GWL_STYLE);
   btnstyle|=BS_MULTILINE;
   SetWindowLong(ForReallyAnyTestBitBtn->Handle,GWL_STYLE,btnstyle);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ForReallyAnyTestBitBtnClick(TObject *Sender)
{
   int
     i;

   TControl
     *tmpControl;

   TComponent
     *tmpComponent;

   for(i=0; i<ControlCount; ++i) // Returns the number of child controls.
   {
      if(!(tmpControl=dynamic_cast<TControl *>(Controls[i])))
        continue;
   }

   for(i=0; i<ComponentCount; ++i) // Indicates the number of components owned by the component.
   {
      if(!(tmpComponent=dynamic_cast<TComponent *>(Components[i])))
        continue;
   }

   if(File.is_open() && File.good())
     {
        File<<AnsiString::StringOfChar('-',10).c_str()<<std::endl;
        File<<"Action=caFree="<<(caFreeCheckBox->Checked ? "On" : "Off")<<std::endl;
        File<<"Modal="<<(ModalCheckBox->Checked ? "On" : "Off")<<std::endl;
        File<<AnsiString::StringOfChar('-',10).c_str()<<std::endl;
     }

   ChildForm=0;

   try
     {
        #if defined(CREATE_BY_NEW)
           ChildForm=new TChildForm(MainForm,1,2);
           //ChildForm=new TChildForm(0,1,2);
        #else
           Application->CreateForm(__classid(TChildForm),&ChildForm);
        #endif

        if(ModalCheckBox->Checked)
          {
             ChildForm->ShowModal();
             #if defined(CREATE_BY_NEW)
                delete ChildForm;
             #else
                ChildForm->Free();
             #endif
             ChildForm=0;
          }
        else
          ChildForm->Show();
     }
   catch(Exception &eException)
     {
        ShowMessage(eException.Message+"\r\nChildForm="+IntToStr(ChildForm));
        if(ChildForm)
          {
             #if defined(CREATE_BY_NEW)
                delete ChildForm;
             #else
                ChildForm->Free();
             #endif
             ChildForm=0;
          }
     }
   catch(...)
     {
        ShowMessage("ChildForm="+IntToStr(ChildForm));
        if(ChildForm)
          {
             #if defined(CREATE_BY_NEW)
                delete ChildForm;
             #else
                ChildForm->Free();
             #endif
             ChildForm=0;
          }
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormClose(TObject *Sender, TCloseAction &Action)
{
   if(File.is_open() && File.good())
     File<<"MainForm OnClose"<<std::endl;

   if(ChildForm && !ModalCheckBox->Checked)
     ChildForm->Free();
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormActivate(TObject *Sender)
{
   if(File.is_open() && File.good())
     File<<"MainForm OnActivate"<<std::endl;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormCloseQuery(TObject *Sender, bool &CanClose)
{
   if(File.is_open() && File.good())
     File<<"MainForm OnCloseQuery"<<std::endl;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormDeactivate(TObject *Sender)
{
   if(File.is_open() && File.good())
     File<<"MainForm OnDeactivate"<<std::endl;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormDestroy(TObject *Sender)
{
   if(File.is_open() && File.good())
     File<<"MainForm OnDestroy"<<std::endl;

   if(File.is_open())
     File.close();
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormHide(TObject *Sender)
{
   if(File.is_open() && File.good())
     File<<"MainForm OnHide"<<std::endl;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormPaint(TObject *Sender)
{
   if(File.is_open() && File.good())
     File<<"MainForm OnPaint"<<std::endl;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormShow(TObject *Sender)
{
   if(File.is_open() && File.good())
     File<<"MainForm OnShow"<<std::endl;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::OnAppException(TObject *Sender, Exception *eException)
{
   TWinControl
     *tmpWinControl;

   if(tmpWinControl=dynamic_cast<TWinControl *>(Sender))
     {
        AnsiString
          Mess="MainForm OnAppException from "+Sender->ClassName()+" "+tmpWinControl->Name;

        if(File.is_open() && File.good())
          File<<Mess.c_str()<<std::endl;
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormResize(TObject *Sender)
{
   if(File.is_open() && File.good())
     File<<"MainForm OnResize"<<std::endl;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormCanResize(TObject *Sender, int &NewWidth, int &NewHeight, bool &Resize)
{
   if(File.is_open() && File.good())
     File<<"MainForm OnCanResize"<<std::endl<<" (NewWidth="<<NewWidth<<" NewHeight="<<NewHeight<<" Resize="<<Resize<<")";

   Resize=false;
}
//---------------------------------------------------------------------------

