//---------------------------------------------------------------------------

#include <vcl.h>
#include <stdio.h>
#pragma hdrstop

#include "main.h"
#include "DataUnit.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

TForm1 *Form1;
//---------------------------------------------------------------------------

__fastcall TForm1::TForm1(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TForm1::Button1Click(TObject *Sender)
{
   try
     {
        DataBases->IBDatabase->Open();
     }
   catch(EIBClientError &eException)
     {
        ShowMessage(eException.Message+" (EIBClientError)");
        throw Exception("From catch(EIBClientError &eException): "+eException.Message);
     }
   catch(EIBError &eException)
     {
        ShowMessage(eException.Message+" (EIBError)");
        throw Exception("From catch(EIBError &eException): "+eException.Message);
     }
   catch(EDatabaseError &eException)
     {
        ShowMessage(eException.Message+" (EDatabaseError)");
        throw Exception("From catch(EDatabaseError &eException): "+eException.Message);
     }
   catch(Exception &eException)
     {
        ShowMessage(eException.Message+" (Exception)");
        throw Exception("From catch(Exception &eException): "+eException.Message);
     }
}
//---------------------------------------------------------------------------
