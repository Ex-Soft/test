//----------------------------------------------------------------------------
//Borland C++Builder
//Copyright (c) 1987, 1998-2002 Borland International Inc. All Rights Reserved.
//----------------------------------------------------------------------------
//---------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop
//---------------------------------------------------------------------
USEFILE("readme.txt");
USEFORM("auto1.cpp", FormMain);
USERES("autocon.res");
USEUNIT("..\autosrv\autosrv_tlb.cpp");
//----------------------------------------------------------------------------
WINAPI WinMain(HINSTANCE, HINSTANCE, LPSTR, int)
{
    Application->Initialize();
    Application->CreateForm(__classid(TFormMain), &FormMain);
    Application->Run();

    return 0;
}
//---------------------------------------------------------------------
