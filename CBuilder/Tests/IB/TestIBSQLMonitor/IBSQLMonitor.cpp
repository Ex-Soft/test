//---------------------------------------------------------------------------

#include <vcl.h>
#include <windows.h>
#pragma hdrstop
//---------------------------------------------------------------------------
//   Important note about DLL memory management when your DLL uses the
//   static version of the RunTime Library:
//
//   If your DLL exports any functions that pass String objects (or structs/
//   classes containing nested Strings) as parameter or function results,
//   you will need to add the library MEMMGR.LIB to both the DLL project and
//   any other projects that use the DLL.  You will also need to use MEMMGR.LIB
//   if any other projects which use the DLL will be performing new or delete
//   operations on any non-TObject-derived classes which are exported from the
//   DLL. Adding MEMMGR.LIB to your project will change the DLL and its calling
//   EXE's to use the BORLNDMM.DLL as their memory manager.  In these cases,
//   the file BORLNDMM.DLL should be deployed along with your DLL.
//
//   To avoid using BORLNDMM.DLL, pass string information using "char *" or
//   ShortString parameters.
//
//   If your DLL uses the dynamic version of the RTL, you do not need to
//   explicitly add MEMMGR.LIB as this will be done implicitly for you
//---------------------------------------------------------------------------

#define WITH_IB_SQL_MONITOR

#if defined(WITH_IB_SQL_MONITOR)
   #include <IBSQLMonitor.hpp>
#endif

#include "IBSQLMonitor.h"

#if defined(WITH_IB_SQL_MONITOR)
   TIBSQLMonitor
     *IBSQLMonitor=0;
#endif

#pragma argsused
int WINAPI DllEntryPoint(HINSTANCE hinst, unsigned long reason, void* lpReserved)
{
   switch(reason)
   {
      case DLL_PROCESS_ATTACH :
      {
         #if defined(WITH_IB_SQL_MONITOR)
            if(!IBSQLMonitor)
            {
               IBSQLMonitor=new TIBSQLMonitor(0);
               //IBSQLMonitor->Enabled=false;
            }
         #endif

         break;
      }
      case DLL_THREAD_ATTACH :
      {
         #if defined(WITH_IB_SQL_MONITOR)
            if(!IBSQLMonitor)
            {
               IBSQLMonitor=new TIBSQLMonitor(0);
               //IBSQLMonitor->Enabled=false;
            }
         #endif

         break;
      }
      case DLL_PROCESS_DETACH :
      {
         #if defined(WITH_IB_SQL_MONITOR)
            if(IBSQLMonitor)
            {
               delete IBSQLMonitor;
               IBSQLMonitor=0;
            }
         #endif

         break;
      }
      case DLL_THREAD_DETACH :
      {
         #if defined(WITH_IB_SQL_MONITOR)
            if(IBSQLMonitor)
            {
               delete IBSQLMonitor;
               IBSQLMonitor=0;
            }
         #endif

         break;
      }
      case DLL_PROCESS_VERIFIER :
      {
         break;
      }
   }
   return 1;
}
//---------------------------------------------------------------------------

void DLL_EI __stdcall IBSQLMonitorEnabled(void)
{
   #if defined(WITH_IB_SQL_MONITOR)
      if(IBSQLMonitor && !IBSQLMonitor->Enabled)
        IBSQLMonitor->Enabled=true;
   #endif
}
//---------------------------------------------------------------------------

void DLL_EI __stdcall IBSQLMonitorDisabled(void)
{
   #if defined(WITH_IB_SQL_MONITOR)
      if(IBSQLMonitor && IBSQLMonitor->Enabled)
        IBSQLMonitor->Enabled=false;
   #endif
}
//---------------------------------------------------------------------------
