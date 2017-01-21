unit ImgViewU;

{$ifndef MSWINDOWS}
  {$ifdef WIN32}
    {$define MSWINDOWS}
  {$endif}
  {$ifdef WINDOWS}
    {$define MSWINDOWS}
  {$endif}
{$endif}

{$ifdef Ver80} { Delphi 1.0x }
  {$define DelphiLessThan4}
{$endif}
{$ifdef Ver90} { Delphi 2.0x }
  {$define DelphiLessThan4}
{$endif}
{$ifdef Ver93} { C++ Builder 1.0x }
  {$define DelphiLessThan4}
{$endif}
{$ifdef Ver100} { Delphi 3.0x }
  {$define DelphiLessThan4}
{$endif}
{$ifdef Ver110} { C++ Builder 3.0x }
  {$define DelphiLessThan4}
{$endif}

interface

uses
  Messages, SysUtils, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls;

type
  TForm1 = class(TForm)
    edtPath: TEdit;
    btnGetPath: TButton;
    lstImages: TListBox;
    imgLoadedImg: TImage;
    Label1: TLabel;
    Label2: TLabel;
    procedure FormCreate(Sender: TObject);
    procedure btnGetPathClick(Sender: TObject);
    procedure edtPathChange(Sender: TObject);
    procedure lstImagesDblClick(Sender: TObject);
    procedure lstImagesMouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure imgLoadedImgDragOver(Sender, Source: TObject; X, Y: Integer;
      State: TDragState; var Accept: Boolean);
    procedure imgLoadedImgDragDrop(Sender, Source: TObject; X, Y: Integer);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

{$ifdef MSWINDOWS}
uses
  FileCtrl;
{$endif}

function FixPath(const Path: String): String;
const
{$ifdef MSWINDOWS}
  Slash = '\';
{$endif}
{$ifdef LINUX}
  Slash = '/';
{$endif}
begin
  Result := Path;
  if Result[Length(Result)] <> Slash then
    Result := Result + Slash;
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
{$ifndef DelphiLessThan4}
  lstImages.Anchors := [akLeft, akTop, akBottom];
  imgLoadedImg.Anchors := [akLeft, akTop, akRight, akBottom];
  Constraints.MinWidth := Width;
  Constraints.MinHeight := Height;
{$else}
  BorderStyle := bsDialog;
{$endif}
end;

procedure TForm1.btnGetPathClick(Sender: TObject);
var
  Path: String;
const
{$ifdef MSWINDOWS}
  Root = '';
{$endif}
{$ifdef LINUX}
  Root = '/';
{$endif}
begin
  if SelectDirectory(Path, [], 0) then
    edtPath.Text := FixPath(Path)
end;

procedure TForm1.edtPathChange(Sender: TObject);
var
  Path: String;
  RetVal: Integer;
  SR: TSearchRec;
begin
  Path := FixPath((Sender as TEdit).Text) + '*.bmp';
  RetVal := FindFirst(Path, faArchive, SR);
  if RetVal = 0 then
    try
      lstImages.Clear;
      while RetVal = 0 do
      begin
        lstImages.Items.Add(SR.Name);
        RetVal := FindNext(SR)
      end
    finally
      FindClose(SR)
    end;
end;

procedure TForm1.lstImagesDblClick(Sender: TObject);
begin
  imgLoadedImg.Picture.LoadFromFile(
    FixPath(edtPath.Text) + lstImages.Items[lstImages.ItemIndex])
end;

procedure TForm1.lstImagesMouseDown(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
  { Check this is a listbox left mouse button event }
  if (Sender is TCustomListBox) and (Button = mbLeft) then
    with TCustomListBox(Sender) do
      { Verify mouse is over a listbox item }
      if ItemAtPos(Point(X, Y), True) <> -1 then
        { Start a non-immediate drag operation }
        BeginDrag(False)
end;

procedure TForm1.imgLoadedImgDragOver(Sender, Source: TObject; X,
  Y: Integer; State: TDragState; var Accept: Boolean);
begin
  Accept := Source = lstImages
end;

procedure TForm1.imgLoadedImgDragDrop(Sender, Source: TObject; X,
  Y: Integer);
begin
  lstImagesDblClick(lstImages)
end;

end.
