unit DragImageU;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  StdCtrls, ExtCtrls;

type
  //Delphi 4 and later allows us to inherit custom drag objects from
  //TDragControlObject (earlier versions forced you to go back to TDragObject)
  TTextDragObject = class(TDragControlObject)
  private
    FDragImages: TDragImageList;
    FData: String;
  protected
    function GetDragCursor(Accepted: Boolean; X, Y: Integer): TCursor; override;
    function GetDragImages: TDragImageList; override;
  public
    constructor Create(Control: TControl; Data: String); reintroduce;
    destructor Destroy; override;
    property Data: String read FData;
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

constructor TTextDragObject.Create(Control: TControl; Data: String);
begin
  inherited Create(Control);
  FData := Data;
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

function TTextDragObject.GetDragImages: TDragImageList;
var
  Bmp: TBitmap;
  Txt: String;
  BmpIdx: Integer;
begin
  if not Assigned(FDragImages) then
    FDragImages := TDragImageList.Create(nil);
  Result := FDragImages;
  Result.Clear;
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
    Result.Width := Bmp.Width;
    Result.Height := Bmp.Height;
    //Make olive pixels transparent, whilst adding bmp to list
    BmpIdx := Result.AddMasked(Bmp, clOlive);
    Result.SetDragImage(BmpIdx, 0, 0);
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
