//---------------------------------------------------------------------------

#include <vcl.h>
#include <ComObj.hpp>
#include <OleCtrls.hpp>
#pragma hdrstop

//---------------------------------------------------------------------------

#define WITH_COINITIALIZEEX_IN_THREAD

AnsiString
  Title;


IStream
  *g_pStmPtr;

DWORD WINAPI ThreadFunc(PVOID pvParam)
{
   DWORD
     dwResult=0;

   Variant
     Excel=*(Variant *)pvParam,
     Workbook,
     Sheet,
     Range;

   AnsiString
     Mess;

   try
   {
      #if defined(WITH_COINITIALIZEEX_IN_THREAD)
        HRESULT
          HResult;

        if((HResult=CoInitializeEx(0,COINIT_MULTITHREADED))!=S_OK)
          return(-1);
      #endif

      try
      {
         Workbook=Excel.OlePropertyGet("ActiveWorkbook");
         Sheet=Workbook.OlePropertyGet("ActiveSheet");
         Range=Sheet.OlePropertyGet("Range","A2");
         Range.OlePropertySet("Value","From Thread");
      }
      catch(EOleException &e)
      {
         Mess=e.ClassName();
         Mess+=" Error code "+IntToStr(e.ErrorCode)+" == \""+e.Message+"\"";
         MessageBox(0,Mess.c_str(),Title.c_str(),MB_OK|MB_ICONERROR);
      }
      catch(EOleSysError &e)
      {
         Mess=e.ClassName();
         Mess+=" Error code "+IntToStr(e.ErrorCode)+" == \""+e.Message+"\"";
         MessageBox(0,Mess.c_str(),Title.c_str(),MB_OK|MB_ICONERROR);
      }
      catch(EOleError &e)
      {
         Mess=e.ClassName();
         Mess+=" Error \""+e.Message+"\"";
         MessageBox(0,Mess.c_str(),Title.c_str(),MB_OK|MB_ICONERROR);
      }
      catch(EOleCtrlError &e)
      {
         Mess=e.ClassName();
         Mess+=" Error \""+e.Message+"\"";
         MessageBox(0,Mess.c_str(),Title.c_str(),MB_OK|MB_ICONERROR);
      }
      catch(Exception &e)
      {
         Mess=e.ClassName();
         Mess+=" Error \""+e.Message+"\"";
         MessageBox(0,Mess.c_str(),Title.c_str(),MB_OK|MB_ICONERROR);
      }
      catch(...)
      {
          MessageBox(0,"Run Excel error!!!",Title.c_str(),MB_OK|MB_ICONERROR);
      }
   }
   __finally
   {
      if(!Range.IsEmpty())
      {
         Range.Clear();
         VarClear(Range);
         Range=Unassigned;
      }

      if(!Sheet.IsEmpty())
      {
         Sheet.Clear();
         VarClear(Sheet);
         Sheet=Unassigned;
      }

      if(!Workbook.IsEmpty())
      {
         Workbook.Clear();
         VarClear(Workbook);
         Workbook=Unassigned;
      }

      #if defined(WITH_COINITIALIZEEX_IN_THREAD)
        CoUninitialize();
      #endif
   }

   return(dwResult);
}

DWORD WINAPI ThreadFuncII(PVOID pvParam)
{
   HRESULT
     HResult;

   #if defined(WITH_COINITIALIZEEX_IN_THREAD)
     if((HResult=CoInitializeEx(0,COINIT_MULTITHREADED))!=S_OK)
       return(-1);
   #endif

   IDispatch
     *disp;

   if((HResult=CoGetInterfaceAndReleaseStream(g_pStmPtr,IID_IDispatch,(void**)disp))==S_OK)
   {
      Variant
        Excel=(IDispatch *)disp;
   }
   else
   {
      if(HResult==E_INVALIDARG)
        MessageBox(0,"Invalid argument!!!",Title.c_str(),MB_OK|MB_ICONERROR);
   }

   #if defined(WITH_COINITIALIZEEX_IN_THREAD)
      CoUninitialize();
   #endif
}

#pragma argsused
int main(int argc, char* argv[])
{
   int
     ReturnCode=0;

   AnsiString
     Mess;

   Variant
     Excel,
     Workbooks,
     Workbook,
     Sheet,
     Range,
     Value;

   Title=ExtractFileName(*argv);
   
   try
   {
      HRESULT
        HResult;

      if((HResult=CoInitializeEx(0,COINIT_MULTITHREADED))!=S_OK)
        return(-1);

      try
      {
         try
         {
            Excel=Variant::GetActiveObject("Excel.Application");
         }
         catch(EOleSysError &eException)
         {
            if(eException.ErrorCode==-2147221021)
            {
               try
               {
                  Excel=CreateOleObject("Excel.Application");
               }
               catch(...)
               {
                  MessageBox(0,"Object Excel was not created!!!",Title.c_str(),MB_OK|MB_ICONERROR);
                  return(-1);
               }
            }
         }

         if(Excel.IsEmpty())
         {
            MessageBox(0,"Object Excel was not created!!!",Title.c_str(),MB_OK|MB_ICONERROR);
            return(-1);
         }

         Excel.OlePropertySet("Visible",true);
         Excel.OlePropertySet("DisplayAlerts",false);

         Workbooks=Excel.OlePropertyGet("Workbooks");
         Workbook=Workbooks.OleFunction("Add");
         Sheet=Workbook.OlePropertyGet("ActiveSheet");
         Range=Sheet.OlePropertyGet("Range","A1");
         Range.OlePropertySet("Value","From Main (before)");

         DWORD
           ThreadID;

         HANDLE
           hThread;

         if(hThread=CreateThread(0,0,ThreadFunc,(PVOID)&Excel,0,&ThreadID))
         {
            WaitForSingleObject(hThread,INFINITE);
            CloseHandle(hThread);
         }

         Range=Sheet.OlePropertyGet("Range","A3");
         Range.OlePropertySet("Value","From Main (after)");

         IDispatch
           *disp=(IDispatch *)(Excel);

         if(CoMarshalInterThreadInterfaceInStream(IID_IDispatch,disp,&g_pStmPtr)==S_OK)
         {
            if(hThread=CreateThread(0,0,ThreadFuncII,0,0,&ThreadID))
            {
               WaitForSingleObject(hThread,INFINITE);
               CloseHandle(hThread);
            }

            Range=Sheet.OlePropertyGet("Range","A5");
            Range.OlePropertySet("Value","From Main (after)");
         }

         Mess=ExtractFilePath(*argv)+"out_xls.xls";
         Workbook.OleProcedure("SaveAs",Mess.c_str());
         Workbook.OleProcedure("Close");
      }
      catch(EOleException &e)
      {
         Mess=e.ClassName();
         Mess+=" Error code "+IntToStr(e.ErrorCode)+" == \""+e.Message+"\"";
         MessageBox(0,Mess.c_str(),Title.c_str(),MB_OK|MB_ICONERROR);
      }
      catch(EOleSysError &e)
      {
         Mess=e.ClassName();
         Mess+=" Error code "+IntToStr(e.ErrorCode)+" == \""+e.Message+"\"";
         MessageBox(0,Mess.c_str(),Title.c_str(),MB_OK|MB_ICONERROR);
      }
      catch(EOleError &e)
      {
         Mess=e.ClassName();
         Mess+=" Error \""+e.Message+"\"";
         MessageBox(0,Mess.c_str(),Title.c_str(),MB_OK|MB_ICONERROR);
      }
      catch(EOleCtrlError &e)
      {
         Mess=e.ClassName();
         Mess+=" Error \""+e.Message+"\"";
         MessageBox(0,Mess.c_str(),Title.c_str(),MB_OK|MB_ICONERROR);
      }
      catch(Exception &e)
      {
         Mess=e.ClassName();
         Mess+=" Error \""+e.Message+"\"";
         MessageBox(0,Mess.c_str(),Title.c_str(),MB_OK|MB_ICONERROR);
      }
      catch(...)
      {
          MessageBox(0,"Run Excel error!!!",Title.c_str(),MB_OK|MB_ICONERROR);
      }
   }
   __finally
   {
      if(!Range.IsEmpty())
      {
         Range.Clear();
         VarClear(Range);
         Range=Unassigned;
      }

      if(!Sheet.IsEmpty())
      {
         Sheet.Clear();
         VarClear(Sheet);
         Sheet=Unassigned;
      }

      if(!Workbook.IsEmpty())
      {
         Workbook.Clear();
         VarClear(Workbook);
         Workbook=Unassigned;
      }

      if(!Workbooks.IsEmpty())
      {
         Workbooks.Clear();
         VarClear(Workbooks);
         Workbooks=Unassigned;
      }

      if(!Excel.IsEmpty())
      {
         Excel.OleProcedure("Quit");
         Excel.Clear();
         VarClear(Excel);
         Excel=Unassigned;
      }

      CoUninitialize();
   }

   return(ReturnCode);
}
//---------------------------------------------------------------------------
