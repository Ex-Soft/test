//---------------------------------------------------------------------------

#include <vcl.h>
#include <Lm.h>
#include <assert.h>
#include <stdio.h>
#pragma hdrstop

#include "main.h"
//---------------------------------------------------------------------------

#pragma package(smart_init)
#pragma resource "*.dfm"

//---------------------------------------------------------------------------
// Begin 4 Adding vertical text to popup menu
//---------------------------------------------------------------------------
const TEXT_SPACE = 15;
const ICON_SPACE = 35;
const MENU_TEXT_HEIGHT = 18;
const SPACE_BETWEEN_MENUS = 1;
const MENU_TEXT_LEFT = 2;
const MENU_ITEM_OFFSET = 19;
//---------------------------------------------------------------------------
// End 4 Adding vertical text to popup menu
//---------------------------------------------------------------------------

#define TEST_CAST

TMainForm *MainForm;
//---------------------------------------------------------------------------

__fastcall TMainForm::TMainForm(TComponent* Owner):TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormCreate(TObject *Sender)
{
   AllPageControl->ActivePage=ForReallyAnyTestTabSheet;

   ForReallyAnyTestBitBtn->Caption=AnsiString("For\r\n")+"Really\r\n"+"Any\r\n"+"Test's\r\n"+"Button";
   long btnstyle=GetWindowLong(ForReallyAnyTestBitBtn->Handle,GWL_STYLE);
   btnstyle|=BS_MULTILINE;
   SetWindowLong(ForReallyAnyTestBitBtn->Handle,GWL_STYLE,btnstyle);

   ButtonImageLoad->Hint="Line #1\nLine #2\nLine #3";
   //ButtonImageLoad->Hint="Line #1\r\nLine #2\r\nLine #3";
   
   StringGridDateTimePicker->Visible=false;
   StringGridData->DefaultRowHeight=StringGridDateTimePicker->Height;
   StringGridData->Hint="0 0";
   StringGridData->ShowHint=true;
//   HRGN rgn=CreateRoundRectRgn(0,0,Width,Height,15,10);
//   HRGN rgn=CreateEllipticRgn(0,0,Width*2,Height*2);
//   SetWindowRgn(Handle,rgn,true);

//---------------------------------------------------------------------------
// Begin 4 Adding vertical text to popup menu
//---------------------------------------------------------------------------
   if(VerticalTextPopupMenu->Items->Count>0)
     {
        for(int i=0;i<VerticalTextPopupMenu->Items->Count;i++)
           {
              VerticalTextPopupMenu->Items->Items[i]->OnMeasureItem=ExpandMenuItemWidth;
              VerticalTextPopupMenu->Items->Items[i]->OnDrawItem=DrawNewItem;
           }
     }
   CreateVerticalFont();
   Icon = new TIcon;
//---------------------------------------------------------------------------
// End 4 Adding vertical text to popup menu
//---------------------------------------------------------------------------
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormShow(TObject *Sender)
{
   int result;

   TMenuItem *MenuItem,*MenuItem2;

   for(int i=0;i<MainMenu1->ComponentCount;i++)
      {
         MenuItem=MainMenu1->Items;
         for(int i=0;i</*MenuItem->Count*/1;i++)
            {
               MenuItem2=MenuItem->Items[i];
               for(int i=0;i<MenuItem2->Count;i++)
                  {
                     MenuItem2->Items[i]->Enabled=false;
                  }
            }
      }

   CoolBar1->Top=0;
   CoolBar2->Top=0;
   CoolBar1->Left=0;
   CoolBar1Left->Text=CoolBar1->Left;
   CoolBar1Width->Text=CoolBar1->Width;
   CoolBar2->Left=CoolBar1->Left+CoolBar1->Width;
   CoolBar2Left->Text=CoolBar2->Left;
   CoolBar2Width->Text=CoolBar2->Width;

   TRect rcH(0,0,StringGridData->DefaultColWidth,StringGridData->DefaultRowHeight);

   StringGridData->Cells[1][1]="1234567890 1234567890";
//   if(result=DrawText(StringGridData->Canvas->Handle,StringGridData->Cells[1][1].c_str(),-1,&rcH,DT_WORDBREAK|DT_CENTER|DT_CALCRECT))
//     ShowMessage(result);

#if defined(TEST_CAST)
   TButton
     *tmpButtonPtr;

   AnsiString
     tmpAnsiStringS="",
     tmpAnsiStringD="";

   for(int i=ControlCount-1; i>=0; --i)
      {
         tmpButtonPtr=static_cast<TButton *>(Controls[i]);
         if(tmpButtonPtr)
           {
              if(!tmpAnsiStringS.IsEmpty())
                tmpAnsiStringS+=" ";
              tmpAnsiStringS+=tmpButtonPtr->Name;
           }

         tmpButtonPtr=dynamic_cast<TButton *>(Controls[i]);
         if(tmpButtonPtr)
           {
              if(!tmpAnsiStringD.IsEmpty())
                tmpAnsiStringD+=" ";
              tmpAnsiStringD+=tmpButtonPtr->Name;
           }
      }
   ShowMessage(tmpAnsiStringS+"\n"+tmpAnsiStringD);
#endif

}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ControlBar1BandMove(TObject *Sender, TControl *Control, TRect &ARect)
{
   CoolBar1Left->Text=CoolBar1->Left;
   CoolBar1Width->Text=CoolBar1->Width;
   CoolBar2Left->Text=CoolBar2->Left;
   CoolBar2Width->Text=CoolBar2->Width;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::StartAlphaBlendButtonClick(TObject *Sender)
{
   //AlphaBlend=true; // мигает при установке
   TransparentColor=UseTransparentColorCheckBox->Checked;
   if(TransparentColor)
     TransparentColorValue=clWhite; //цвет который будет прозрачным
   for(int i=255;i>-1;i--)
      {
         AlphaBlendValue=i;
         Application->ProcessMessages();
      }
   for(int i=0;i<256;i++)
      {
         AlphaBlendValue=i;
         Application->ProcessMessages();
      }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::StringGridDataSelectCell(TObject *Sender, int ACol, int ARow, bool &CanSelect)
{
   if(ACol!=1)
     return;

   StringGridDateTimePicker->Date=StrToDateDef(StringGridData->Cells[ACol][ARow],0);
   StringGridDateTimePicker->Left=StringGridData->Left+StringGridData->CellRect(ACol,ARow).Left+1;
   StringGridDateTimePicker->Top=StringGridData->Top+StringGridData->CellRect(ACol,ARow).Top+1;
   StringGridDateTimePicker->Width=StringGridData->CellRect(ACol,ARow).Right-StringGridData->CellRect(ACol,ARow).Left+1;
   StringGridDateTimePicker->Height=StringGridData->CellRect(ACol,ARow).Bottom-StringGridData->CellRect(ACol,ARow).Top+1;
   StringGridDateTimePicker->Visible=true;
   StringGridDateTimePicker->SetFocus();
   CanSelect=true;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::StringGridDateTimePickerExit(TObject *Sender)
{
   StringGridData->Cells[StringGridData->Col][StringGridData->Row]=StringGridDateTimePicker->Date.DateString();
   StringGridDateTimePicker->Visible=false;
   StringGridData->SetFocus();
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::StringGridDataDrawCell(TObject *Sender, int ACol, int ARow, TRect &Rect, TGridDrawState State)
{
   TColor clPaleGreen=0x0CCFFCC,clPaleRed=0x0CCCCFF;

   if(State.Contains(gdFocused))
     {
        StringGridData->Canvas->Brush->Color=clBlack;
        StringGridData->Canvas->Font->Color=clWhite;
     }
   else
     if(ACol==2) //&& StringGridData->Cells[ACol][ARow]=="31.12.1899"
       StringGridData->Canvas->Brush->Color=clPaleGreen;
     else
       StringGridData->Canvas->Brush->Color=clPaleRed;

   if(ACol>0 && ARow>0)
     {
        StringGridData->Canvas->FillRect(Rect);
        StringGridData->Canvas->TextOut(Rect.Left,Rect.Top,StringGridData->Cells[ACol][ARow]);
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::StringGridDataMouseMove(TObject *Sender, TShiftState Shift, int X, int Y)
{
   int c,r;

   StringGridData->MouseToCell(X,Y,c,r);
   if(c>0 && r>0 && (Col!=c || Row!=r))
     {
        Col=c;
        Row=r;
        Application->CancelHint();
        StringGridData->Hint=IntToStr(c)+" "+IntToStr(r);
     }
}
//---------------------------------------------------------------------------

//---------------------------------------------------------------------------
// Begin 4 Adding vertical text to popup menu
//---------------------------------------------------------------------------
void __fastcall TMainForm::VerticalTextPopupMenuPopup(TObject *Sender)
{
   VerticalBarDrawn=false;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ExpandMenuItemWidth(TObject *Sender, TCanvas *ACanvas, int &Width, int &Height)
{
  // необходимо сделать меню шире, чтобы оставить место дл€ вертикального
  // текста
  Width+=TEXT_SPACE;
}
//---------------------------------------------------------------------------

void TMainForm::CreateVerticalFont()
{
  ZeroMemory(&VerticalFont,sizeof(VerticalFont));
  VerticalFont.lfHeight=-18;
  VerticalFont.lfEscapement=900;
  VerticalFont.lfOrientation=900;
  VerticalFont.lfWeight=FW_BOLD;
  StrPCopy(VerticalFont.lfFaceName,"Arial");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::DrawNewItem(TObject *Sender, TCanvas *ACanvas, const TRect &ARect, bool Selected)
{
   TMenuItem *MenuItem=((TMenuItem*)Sender);

   // получаем размеры, необходимые дл€ отметки пункта меню
   CheckmarkSize=GetSystemMetrics(SM_CXMENUCHECK);
   MenuHeight=ARect.Height()*MenuItem->Parent->Count;
   VerticalBarLength=MenuHeight/4;

   // собираемс€ рисовать вертикальный текст только один раз
   // тем не менее, если рабочий стол обновл€етс€, то вертикальный текст
   // исчезает
   if(!VerticalBarDrawn)
     {
        OldFont=(TFont*)SelectObject(ACanvas->Handle,CreateFontIndirect(&VerticalFont));
        OldForegroundColor=SetTextColor(ACanvas->Handle,clWhite);
        OldBackgroundColor=SetBkColor(ACanvas->Handle,clRed);

        VerticalDrawingRect=Rect(0,0,CheckmarkSize+TEXT_SPACE,MenuHeight);
        // € делаю строку немного длиннее, чем всплывающее меню
        VerticalText=VerticalText.StringOfChar(' ',VerticalBarLength);
        VerticalText.Insert(" Vertical Text",1);

        ExtTextOut(ACanvas->Handle,-1,MenuHeight,ETO_CLIPPED,&VerticalDrawingRect,VerticalText.c_str(),VerticalBarLength,NULL);

        SelectObject(ACanvas->Handle,OldFont);
        SetTextColor(ACanvas->Handle,OldForegroundColor);
        SetBkColor(ACanvas->Handle,OldBackgroundColor);
        VerticalBarDrawn=true;
     }

   TempRect = ARect;
   // оставл€ем место дл€ иконки
   TempRect.Left+=LOWORD(CheckmarkSize)+ICON_SPACE;

   ACanvas->Pen->Style=psClear;

   // пр€моугольник выбора
   // запустите программу без этого и посмотрите разницу
   ACanvas->Rectangle(TempRect.Left-MENU_TEXT_LEFT,MenuItem->MenuIndex*MENU_ITEM_OFFSET-SPACE_BETWEEN_MENUS,ARect.Width(),MenuItem->MenuIndex*MENU_ITEM_OFFSET+MENU_TEXT_HEIGHT);

   DrawText(ACanvas->Handle,MenuItem->Caption.c_str(),MenuItem->Caption.Length(),&TempRect,0);

   // если пункт меню выбран, рисуем приподн€тый пр€моугольник вокруг иконки
   // иначе стираем приподн€тый пр€моугольник
   if(Selected)
     {
        // смещаем 2 пр€моугольника дл€ объемного вида
        ACanvas->Pen->Style=psSolid;
        ACanvas->Pen->Color=clWhite;
        ACanvas->Rectangle(24,MenuItem->MenuIndex*MENU_ITEM_OFFSET-1,24+MENU_ITEM_OFFSET,MenuItem->MenuIndex*MENU_ITEM_OFFSET+MENU_TEXT_HEIGHT-1);

        ACanvas->Pen->Color = clGray;
        ACanvas->Rectangle(25,MenuItem->MenuIndex * MENU_ITEM_OFFSET,24+MENU_ITEM_OFFSET,MenuItem->MenuIndex * MENU_ITEM_OFFSET+MENU_TEXT_HEIGHT-1);

        // здесь мы извлекаем иконку из ImageList
        PageControlImageList->GetIcon(MenuItem->ImageIndex,Icon);
        ACanvas->Draw(26,MenuItem->MenuIndex*MENU_ITEM_OFFSET,Icon);
     }
   else
     {
        ACanvas->Pen->Style=psClear;
        ACanvas->Rectangle(24,MenuItem->MenuIndex*MENU_ITEM_OFFSET-2,25+MENU_ITEM_OFFSET+2,MenuItem->MenuIndex * MENU_ITEM_OFFSET+MENU_TEXT_HEIGHT+2);

        PageControlImageList->GetIcon(MenuItem->ImageIndex,Icon);
        ACanvas->Draw(26,MenuItem->MenuIndex * MENU_ITEM_OFFSET,Icon);
     }
}
//---------------------------------------------------------------------------
//---------------------------------------------------------------------------
// End 4 Adding vertical text to popup menu
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormClose(TObject *Sender, TCloseAction &Action)
{
//---------------------------------------------------------------------------
// Begin 4 Adding vertical text to popup menu
//---------------------------------------------------------------------------
   delete Icon;
//---------------------------------------------------------------------------
// End 4 Adding vertical text to popup menu
//---------------------------------------------------------------------------
}
//---------------------------------------------------------------------------

BOOL EnumHandler( HWND hWnd, DWORD dwLevel, LPNETRESOURCE lpNet )
{
   BOOL ret=TRUE;
   DWORD dwStatus, dwSize, dwEntries, i, j;
   LPSTR lpStr=NULL;
   LPNETRESOURCE lpNewNet=NULL;
   HANDLE hEnum=NULL;

   dwStatus = WNetOpenEnum( RESOURCE_GLOBALNET, //  Look for the works
                            RESOURCETYPE_ANY,   //  when opening
                            0, lpNet, &hEnum );
   if( dwStatus != NO_ERROR ){ ret=FALSE; goto mend; }
   //  Allocate buffer space for a mess of objects
   dwEntries = 1000; //  We can handle up to 128 entries
   dwSize = sizeof(NETRESOURCE) * dwEntries;
   lpNewNet=(LPNETRESOURCE)new char[dwSize];
   if(!lpNewNet){ ret=FALSE; goto mend; }
   //  Enumerate into the buffer
   dwStatus = WNetEnumResource( hEnum, &dwEntries, (LPVOID)lpNewNet, &dwSize );

   if( dwStatus != NO_ERROR ) //  Rats...error, free memory and exit
   {
      ret=FALSE; goto mend;
   }
   WNetCloseEnum( hEnum );//  Done with the handle...close it
   hEnum=NULL;

   lpStr=new char[512];
   if(!lpStr){ ret=FALSE; goto mend; }
   for( i = 0; i < dwEntries; i++ )//  Loop through each entry
   {
      if( lpNewNet[ i ].dwDisplayType==RESOURCEDISPLAYTYPE_NETWORK)
      {
            strcpy( lpStr, lpNewNet[ i ].lpProvider );
      }

      if( lpNewNet[ i ].lpRemoteName ) //  Is there a name?
      {
         if( lpNewNet[ i ].dwDisplayType == RESOURCEDISPLAYTYPE_DOMAIN )
            strcpy( lpStr, "Domain..." );

         if( lpNewNet[ i ].dwDisplayType == RESOURCEDISPLAYTYPE_GENERIC )
            strcpy( lpStr, "Generic.." );

         if( lpNewNet[ i ].dwDisplayType == RESOURCEDISPLAYTYPE_SERVER )
            strcpy( lpStr, "Server..." );

         if( lpNewNet[ i ].dwDisplayType == RESOURCEDISPLAYTYPE_SHARE )
            strcpy( lpStr, "Share...." );

         for( j = 0; j < dwLevel; j++ )    //  Indent levels deeper with spaces
            strcat( lpStr, "......" );
         //  ƒобавим им€ ресурса
         strcat( lpStr, lpNewNet[ i ].lpRemoteName );
      }
    //«анесЄм в листбох
      SendMessage( hWnd, LB_ADDSTRING, 0,(LPARAM)lpStr );
      UpdateWindow(hWnd);
    //”ровень детализации можете установить здесь
      if(dwLevel < 4) //0=—еть,1=Domain,2=Host,3=Resource
      EnumHandler( hWnd, dwLevel + 1, lpNewNet + i );
   }
mend:
   if(hEnum)WNetCloseEnum( hEnum );
   if(lpStr)delete lpStr;
   if(lpNewNet)delete lpNewNet;
   return ret;
}

void __fastcall TMainForm::ForReallyAnyTestBitBtnClick(TObject *Sender)
{
   TPoint cp=Memo1->CaretPos,co=Memo1->ClientOrigin;
   TRect cr=Memo1->ClientRect;
   HDC hDC;
   RECT r;
   AnsiString Str;
   long h;
   TEXTMETRIC tm;

   Memo1->Lines->Add(AnsiString::StringOfChar('A',50)+" "+AnsiString::StringOfChar('A',60)+" "+AnsiString::StringOfChar('A',70));
   cp=Memo1->CaretPos;
   Str=Memo1->Lines->Text;
   hDC=GetDC(Memo1->Handle);
   r.top=r.bottom=r.left=0;
   r.right=Memo1->Width ;
   DrawText(hDC,Str.c_str(),-1,&r,DT_CALCRECT|DT_WORDBREAK);
   GetTextMetrics(hDC,&tm);
   ReleaseDC(Memo1->Handle,hDC);
   if(r.bottom>(Memo1->Height-6))
     Memo1->ScrollBars=ssVertical ;
   h=-Memo1->Font->Height*cp.y;
   if(h>(Memo1->Height-6))
     Memo1->ScrollBars=ssVertical ;

   Memo1->Lines->Add(AnsiString::StringOfChar('A',500));
   cp=Memo1->CaretPos;
   Str=Memo1->Lines->Text;
   hDC=GetDC(Memo1->Handle);
   r.top=r.bottom=r.left=0;
   r.right=Memo1->Width ;
   DrawText(hDC,Str.c_str(),-1,&r,DT_CALCRECT|DT_WORDBREAK);
   ReleaseDC(Memo1->Handle,hDC);
   if(r.bottom>(Memo1->Height-6))
     Memo1->ScrollBars=ssVertical;
   h=-Memo1->Font->Height*cp.y;
   if(h>(Memo1->Height-6))
     Memo1->ScrollBars=ssVertical;
   
   AllPageControl->ActivePage=AlphaBlendTabSheet;
   Memo1->SetFocus();
/*
union TSuperRef
{
   private:
     void *Addr;
     int &Ref;

   public:
     TSuperRef(int &X):Ref(X){};
     int& operator=(int X){return Ref=X;}
     void ReRef(int &X){Addr=&X;}
};

int a=2;
int b=3;
TSuperRef R=a;
R=4; //a=4, b=3
R.ReRef(b);
R=7; //a=4, b=7
*/
}
//---------------------------------------------------------------------------
/*

*/
void __fastcall TMainForm::Button1Click(TObject *Sender)
{
wchar_t *pszServerName = NULL;
   DWORD nLevel = 1;                   
   SHARE_INFO_1* pBuf = NULL;
   SHARE_INFO_1* pTmpBuf = NULL;

   DWORD nEntriesRead = 0;
   DWORD nTotalEntries = 0;
   DWORD nTotalCount = 0;
   DWORD resume = 0;
   DWORD i;
   NET_API_STATUS nStatus;

   WideString W;
   AnsiString S;

   ListBox1->Clear();

   W=WideString("Nozhenko");
   pszServerName=W.c_bstr();

  do // begin do
  {
   //
   // Call the NetShareEnum function to list the
   //  shares, specifying information level 1.
   //
   nStatus = NetShareEnum(pszServerName,
                          nLevel,
                          (LPBYTE *)&pBuf,
                          -1,
                          &nEntriesRead,
                          &nTotalEntries,
                          &resume);
   //
   // Loop through the entries; process errors.
   //
   if ((nStatus == NERR_Success) || (nStatus == ERROR_MORE_DATA))
   {
      if ((pTmpBuf = pBuf) != NULL)
      {
         for (i = 0; (i < nEntriesRead); i++)
         {
            assert(pTmpBuf != NULL);

            if (pTmpBuf == NULL)
            {
               S.printf("An access violation has occurred");
               ListBox1->Items->Add(S);
               break;
            }
            //
            // Display the information for each entry retrieved.
            //
            S.printf("Share: %s , %s", AnsiString(pTmpBuf->shi1_netname).c_str(),
                                       AnsiString(pTmpBuf->shi1_remark).c_str());
            ListBox1->Items->Add(S);

            pTmpBuf++;
            nTotalCount++;
         }
        NetApiBufferFree(pBuf);
      }
   }
   else
   {
      S.printf("A system error has occurred: %d", nStatus);
      ListBox1->Items->Add(S);
   }
  }
  while (nStatus==ERROR_MORE_DATA);

   S.printf("Total of %d entries enumerated", nTotalCount);
   ListBox1->Items->Add(S);
/*
   HCURSOR hOldCursor;
   NETRESOURCE netResource;
   ZeroMemory(&netResource, sizeof(NETRESOURCE));
   netResource.dwType = RESOURCETYPE_DISK;
   netResource.lpRemoteName ="\\\\Nozhenko"; //»м€ машины в сети
//   ListBox1->Clear();
   SendMessage(MainForm->ListBox1->Handle , LB_RESETCONTENT, 0, 0 );
   UpdateWindow(MainForm->ListBox1->Handle);
   hOldCursor = ::SetCursor( LoadCursor( NULL, IDC_WAIT ) );
   EnumHandler( MainForm->ListBox1->Handle, 0, &netResource );
   ::SetCursor( hOldCursor );
*/
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ButtonImageLoadClick(TObject *Sender)
{
   AnsiString
     Mess;

   Mess="Height="+IntToStr(Image1->Height)+"\r\nWidth="+IntToStr(Image1->Width);
   ShowMessage(Mess);

   Mess="Picture->Height="+IntToStr(Image1->Picture->Height)+"\r\nPicture->Width="+IntToStr(Image1->Picture->Width);
   ShowMessage(Mess);

   Mess="Picture->Bitmap->Height="+IntToStr(Image1->Picture->Bitmap->Height)+"\r\nPicture->Bitmap->Width="+IntToStr(Image1->Picture->Bitmap->Width);
   ShowMessage(Mess);

   OpenDialog->DefaultExt="*.bmp";
   OpenDialog->Filter="Bitmaps (*.bmp)|*.bmp|JPEG Image File (*.jpg)|*.jpg|JPEG Image File (*.jpeg)|*.jpeg|Any files (*.*)|*.*";
   OpenDialog->FilterIndex=1;
   OpenDialog->InitialDir=ExtractFilePath(Application->ExeName);
   OpenDialog->Title="Select image";

   if(OpenDialog->Execute())
     {
        Image1->Picture->LoadFromFile(OpenDialog->FileName);

        Mess="Height="+IntToStr(Image1->Height)+"\r\nWidth="+IntToStr(Image1->Width);
        ShowMessage(Mess);

        Mess="Picture->Height="+IntToStr(Image1->Picture->Height)+"\r\nPicture->Width="+IntToStr(Image1->Picture->Width);
        ShowMessage(Mess);

        Mess="Picture->Bitmap->Height="+IntToStr(Image1->Picture->Bitmap->Height)+"\r\nPicture->Bitmap->Width="+IntToStr(Image1->Picture->Bitmap->Width);
        ShowMessage(Mess);
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::OpenDialogShow(TObject *Sender)
{
/*
   ShowWindow(GetDlgItem(GetParent(OpenDialog->Handle), 0x0443), false);
   ShowWindow(GetDlgItem(GetParent(OpenDialog->Handle), 0x0471), false);
   ShowWindow(GetDlgItem(GetParent(OpenDialog->Handle), 0x04a0), false);
   ShowWindow(GetDlgItem(GetParent(OpenDialog->Handle), 0x0442), false); // Win98 & Win2000
   ShowWindow(GetDlgItem(GetParent(OpenDialog->Handle), 0x047C), false); // Win2000
   ShowWindow(GetDlgItem(GetParent(OpenDialog->Handle), 0x0480), false); // Win98
   ShowWindow(GetDlgItem(GetParent(OpenDialog->Handle), 0x0441), false); // Win98 & Win2000
   ShowWindow(GetDlgItem(GetParent(OpenDialog->Handle), 0x0470), false); // Win98 & Win2000
*/
/*
   FILE
  * ff = fopen("id", "wt");
  for ( HWND child(GetWindow(GetParent(OpenDialog->Handle), GW_CHILD)), child0(child); ; )
  {
    if ( child == 0 || child == (HWND)0xFFFFFFFF )
      break;
  char
    name [ 256 ], cls [ 256 ];
    GetWindowText(child, name, 256);
    GetClassName(child, cls, 256);
    fprintf(ff, "%04X : '%s' : \"%s\"\n", GetDlgCtrlID(child), cls, name);
    child = GetWindow(child, GW_HWNDNEXT);
    if ( child == child0 )
      break;
  }
  fclose(ff);
*/
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ButtonSetterClick(TObject *Sender)
{
   unsigned char
     Alpha=50;

   LONG
     l;

   AnsiString
     tmpAnsiString;

   if(l=GetWindowLong(ButtonGetter->Handle,GWL_EXSTYLE))
   {
      SetWindowLong(ButtonGetter->Handle,GWL_EXSTYLE,l^WS_EX_LAYERED);
      SetLayeredWindowAttributes(ButtonGetter->Handle, 0, Alpha, LWA_ALPHA);
   }
   else
   {
      l=GetLastError();
      tmpAnsiString=SysErrorMessage(l);
   }

   if(l=GetWindowLong(MainForm->Handle, GWL_EXSTYLE))
   {
      SetWindowLong(MainForm->Handle, GWL_EXSTYLE,l^WS_EX_LAYERED);
      if(!(l=SetLayeredWindowAttributes(MainForm->Handle, 0, Alpha, LWA_ALPHA)))
      {
         l=GetLastError();
         tmpAnsiString=SysErrorMessage(l);
      }
   }
   else
   {
      l=GetLastError();
      tmpAnsiString=SysErrorMessage(l);
   }
}
//---------------------------------------------------------------------------

