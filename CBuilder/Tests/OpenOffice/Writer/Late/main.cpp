//---------------------------------------------------------------------------

#include <vcl.h>
#include <comobj.hpp>
#include <olectrls.hpp>
#pragma hdrstop

//---------------------------------------------------------------------------

#pragma argsused
int main(int argc, char* argv[])
{
   HRESULT
     hRes=CoInitialize(0);

   int
     tmpInt;

   AnsiString
     Mess;

   if(hRes!=S_OK && hRes!=S_FALSE)
   {
      tmpInt=GetLastError();
      ShowMessage("Can\'t initialize the OLE library (ErrorNo: "+IntToStr(tmpInt)+" Message: \""+SysErrorMessage(tmpInt)+"\"");
      return(-1);
   }

   const char
     *ServiceManagerIDStr="com.sun.star.ServiceManager",
     *DesktopIDStr="com.sun.star.frame.Desktop",
     *PropertyValueIDStr="com.sun.star.beans.PropertyValue",
     *TextTableIDStr="com.sun.star.text.TextTable";

   Variant
     ServiceManager,
     Desktop,
     Document,
     Property,
     Properties,
     Text,
     Cursor,
     Table;

   try
   {
      try
      {
         if(ServiceManager.IsEmpty())
           Mess="ServiceManager.IsEmpty()";
         if(ServiceManager.IsNull())
           Mess="ServiceManager.IsNull()";
         if(VarIsClear(ServiceManager))
           Mess="VarIsClear(ServiceManager)";

         try
         {
            ServiceManager=Variant::GetActiveObject(ServiceManagerIDStr);
         }
         catch(EOleSysError &e)
         {
            if(e.ErrorCode==-2147221021L)
              ServiceManager=CreateOleObject(ServiceManagerIDStr);
            else
              throw;
         }

         if(ServiceManager.IsEmpty())
           Mess="ServiceManager.IsEmpty()";
         if(ServiceManager.IsNull())
           Mess="ServiceManager.IsNull()";
         if(VarIsClear(ServiceManager))
           Mess="VarIsClear(ServiceManager)";

         Desktop=ServiceManager.OleFunction("createInstance",DesktopIDStr);

         int
           Bounds[2]={0,0};

         Property=ServiceManager.OleFunction("Bridge_GetStruct",PropertyValueIDStr);
         Property.OlePropertySet("name","Hidden");
         Property.OlePropertySet("value",false);

         Properties=VarArrayCreate(Bounds,1,varVariant);
         Properties.PutElement(Property,0);

         Document=Desktop.OleFunction("LoadComponentFromURL","private:factory/swriter","_blank",0,Properties);

         Text=Document.OleFunction("getText");

         Text.OleProcedure("setString","Hello!!! I'm the first text!");

         Cursor=Text.OleFunction("createTextCursor");

         Text.OleProcedure("insertString",Cursor,"Line# 1\n",false);
         Text.OleProcedure("insertString",Cursor,"Line# 2",false);

         Table=ServiceManager.OleFunction("createInstance",TextTableIDStr);
         if(Table.IsEmpty())
           Mess="Table.IsEmpty()";
         if(Table.IsNull())
           Mess="Table.IsNull()";
         if(VarIsClear(Table))
           Mess="VarIsClear(Table)";

         Table.OleProcedure("initialize",2,2);
         
         Desktop.OleFunction("Terminate");
      }
      catch(EOleException &e)
      {
         Mess=e.ClassName();
         Mess+=" Error code "+IntToStr(e.ErrorCode)+" == \""+e.Message+"\"";
         Application->MessageBox(Mess.c_str(),Application->Title.c_str(),MB_OK|MB_ICONERROR);
      }
      catch(EOleSysError &e)
      {
         Mess=e.ClassName();
         Mess+=" Error code "+IntToStr(e.ErrorCode)+" == \""+e.Message+"\"";
         Application->MessageBox(Mess.c_str(),Application->Title.c_str(),MB_OK|MB_ICONERROR);
      }
      catch(EOleError &e)
      {
         Mess=e.ClassName();
         Mess+=" Error \""+e.Message+"\"";
         Application->MessageBox(Mess.c_str(),Application->Title.c_str(),MB_OK|MB_ICONERROR);
      }
      catch(EOleCtrlError &e)
      {
         Mess=e.ClassName();
         Mess+=" Error \""+e.Message+"\"";
         Application->MessageBox(Mess.c_str(),Application->Title.c_str(),MB_OK|MB_ICONERROR);
      }
      catch(Exception &e)
      {
         Mess=e.ClassName();
         Mess+=" Error \""+e.Message+"\"";
         Application->MessageBox(Mess.c_str(),Application->Title.c_str(),MB_OK|MB_ICONERROR);
      }
      catch(...)
      {
         Application->MessageBox("Помилка Microsoft Word. Спробуйте закрити програму та запустити її знову.\nЯкщо помилка не зникне, зверніться до фірми Microsoft.",Application->Title.c_str(),MB_ICONERROR|MB_OK);
      }
   }
   __finally
   {
      Table.Clear();
      VarClear(Table);
      Table=Unassigned;

      Cursor.Clear();
      VarClear(Cursor);
      Cursor=Unassigned;

      Text.Clear();
      VarClear(Text);
      Text=Unassigned;

      Property.Clear();
      VarClear(Property);
      Property=Unassigned;

      Document.Clear();
      VarClear(Document);
      Document=Unassigned;

      Desktop.Clear();
      VarClear(Desktop);
      Desktop=Unassigned;

      ServiceManager.Clear();
      VarClear(ServiceManager);
      ServiceManager=Unassigned;

      CoUninitialize();
   }

   return 0;
}
//---------------------------------------------------------------------------
