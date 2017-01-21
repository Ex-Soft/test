unit DragImage2U;

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

{$ifndef DelphiLessThan4}
  'This project is designed for Delphi 2 and 3'
{$endif}

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  StdCtrls, ExtCtrls;

type
  //Custom drag object based on TDragObject 
  //in order to work well in Delphi 2 and 3
  TTextDragObject = class(TDragObject)
  private
    FControl: TControl;
    FDragImages: TImageList;
    FData: String;
  protected
    function GetDragCursor(Accepted: Boolean; X, Y: Integer): TCursor; override;
    function GetDragImages: TCustomImageList; override;
  public
    Data: String;
    constructor Create(Control: TControl; const Data: String);
    destructor Destroy; override;
    property Control: TControl read FControl;
  end;

  TForm1 = class(TForm)
    Panel1: TPanel;
    ListBox1: TListBox;
    Label1: TLabel;
    procedure FormCreate(Sender: TObject);
    procedure Label1StartDrag(Sender: TObject; var DragObject: TDragObject);
    procedure ListBox1StartDrag(Sender: TObject;
      var DragObject: TDragObject);
    procedure SharedEndDrag(Sender, Target: TObject; X, Y: Integer);
    procedure Panel1DragOver(Sender, Source: TObject; X, Y: Integer;
      State: TDragState; var Accept: Boolean);
    procedure Panel1DragDrop(Sender, Source: TObject; X, Y: Integer);
  private
    FDragObject: TTextDragObject;
  end;

var
  Form1: TForm1;

const
  crPacMan = 1; { Use values bigger than 0 }

implementation

{$R *.DFM}

{$R PacCur32.Res}

{ TTextDragObject }

constructor TTextDragObject.Create(Control: TControl; const Data: String);
begin
  inherited Create;
  FData := Data;
  FControl := Control
end;

destructor TTextDragObject.Destroy;
begin
  FDragImages.Free;
  inherited;
end;

function TTextDragObject.GetDragCursor(Accepted: Boolean; X, Y: Integer): TCursor;
begin
  if Accepted then
    Result := crPacMan
  else
    Result := inherited GetDragCursor(Accepted, X, Y)
end;

function TTextDragObject.GetDragImages: TCustomImageList;
var
  Bmp: TBitmap;
  BmpIdx: Integer;
  Txt: String;
begin
  if not Assigned(FDragImages) then
    FDragImages := TImageList.Create(nil);
  FDragImages.Clear;
  Bmp := TBitmap.Create;
  try
    //Make up some string to write on bitmap
    Txt := Format('      The control called %s says "%s" at %s',
      [Control.Name, Data, FormatDateTime('h:nn am/pm', Time)]);
    Bmp.Canvas.Font.Name := 'Arial';
    Bmp.Canvas.Font.Style := Bmp.Canvas.Font.Style + [fsItalic];
    Bmp.Height := Bmp.Canvas.TextHeight(Txt);
    Bmp.Width := Bmp.Canvas.TextWidth(Txt);
    //Fill background with olive
    Bmp.Canvas.Brush.Color := clOlive;
    Bmp.Canvas.FloodFill(0, 0, clWhite, fsSurface);
    //Write a string on bitmap
    Bmp.Canvas.TextOut(0, 0, Txt);
    FDragImages.Width := Bmp.Width;
    FDragImages.Height := Bmp.Height;
    //Make olive pixels transparent, whilst adding bmp to list
    BmpIdx := FDragImages.AddMasked(Bmp, clOlive);
    FDragImages.SetDragImage(BmpIdx, 0, 0);
    Result := FDragImages;
  finally
    Bmp.Free;
  end
end;

{ TForm1 }

procedure FixControlStyles(Parent: TControl);
var
  I: Integer;
begin
  Parent.ControlStyle := Parent.ControlStyle + [csDisplayDragImage];
  if Parent is TWinControl then
    with TWinControl(Parent) do
      for I := 0 to ControlCount - 1 do
        FixControlStyles(Controls[I]);
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
  Screen.Cursors[crPacMan] := LoadCursor(HInstance, 'PacMan');
  FixControlStyles(Self)
end;

procedure TForm1.Label1StartDrag(Sender: TObject;
  var DragObject: TDragObject);
begin
  FDragObject := TTextDragObject.Create(Label1, Label1.Caption);
  DragObject := FDragObject;
end;

procedure TForm1.ListBox1StartDrag(Sender: TObject;
  var DragObject: TDragObject);
begin
  FDragObject := TTextDragObject.Create(ListBox1, ListBox1.Items[ListBox1.ItemIndex]);
  DragObject := FDragObject;
end;

procedure TForm1.SharedEndDrag(Sender, Target: TObject; X, Y: Integer);
begin
  //All draggable controls share this event handler
  FDragObject.Free;
  FDragObject := nil
end;

procedure TForm1.Panel1DragOver(Sender, Source: TObject; X, Y: Integer;
  State: TDragState; var Accept: Boolean);
begin
  Accept := Source is TTextDragObject
end;

procedure TForm1.Panel1DragDrop(Sender, Source: TObject; X, Y: Integer);
begin
  (Sender as TPanel).Caption := TTextDragObject(Source).Data
end;

end.
