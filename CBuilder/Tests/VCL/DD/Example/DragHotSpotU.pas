unit DragHotSpotU;

{$ifdef Ver90} { Delphi 2.0x }
  {$define DelphiLessThan4}
{$endif}
{$ifdef Ver93} { C++ Builder 1.0x }
  {$define DelphiLessThan4}
{$endif}
{$ifdef Ver100} { Delphi 3.0x }
  {$define DelphiLessThan4}
{$endif}

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  StdCtrls, ComCtrls;

type
{$ifdef DelphiLessThan4}
  TDragImageList = TImageList;
{$endif}

  TControlDragObject = class(TDragControlObject)
  private
    FDragImages: TDragImageList;
    FX, FY: Integer;
  protected
{$ifdef DelphiLessThan4}
    function GetDragImages: TCustomImageList; override;
{$else}
    function GetDragImages: TDragImageList; override;
{$endif}
  public
    constructor CreateWithHotSpot(Control: TWinControl; X, Y: Integer);
    destructor Destroy; override;
  end;

  TForm1 = class(TForm)
    Button1: TButton;
    procedure FormCreate(Sender: TObject);
    procedure Button1StartDrag(Sender: TObject;
      var DragObject: TDragObject);
    procedure Button1EndDrag(Sender, Target: TObject; X, Y: Integer);
    procedure Button1MouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure FormDragOver(Sender, Source: TObject; X, Y: Integer;
      State: TDragState; var Accept: Boolean);
    procedure FormDragDrop(Sender, Source: TObject; X, Y: Integer);
  private
    FDragObject: TControlDragObject;
  end;

var
  Form1: TForm1;

implementation

{$R *.DFM}

{ TControlDragObject }

constructor TControlDragObject.CreateWithHotSpot(Control: TWinControl; X, Y: Integer);
begin
  inherited Create(Control);
  FX := X;
  FY := Y;
end;

destructor TControlDragObject.Destroy;
begin
  FDragImages.Free;
  inherited;
end;

{$ifdef DelphiLessThan4}
function TControlDragObject.GetDragImages: TCustomImageList;
{$else}
function TControlDragObject.GetDragImages: TDragImageList;
{$endif}
var
  Bmp: TBitmap;
  Idx: Integer;
begin
  if not Assigned(FDragImages) then
    FDragImages := TDragImageList.Create(nil);
  Result := FDragImages;
  Result.Clear;
  //Make bitmap that is same size as control
  Bmp := TBitmap.Create;
  try
    Bmp.Width := Control.Width;
    Bmp.Height := Control.Height;
    Bmp.Canvas.Lock;
    try
      //Draw control in bitmap
      (Control as TWinControl).PaintTo(Bmp.Canvas.Handle, 0, 0);
    finally
      Bmp.Canvas.UnLock
    end;
    FDragImages.Width := Control.Width;
    FDragImages.Height := Control.Height;
    //Add bitmap to image list, making the grey pixels transparent
    Idx := FDragImages.AddMasked(Bmp, clBtnFace);
    //Set the drag image and hot spot
    FDragImages.SetDragImage(Idx, FX, FY);
  finally
    Bmp.Free
  end
end;

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
  //Make sure appropriate flag is present in all
  //controls, so drag image is displayed
  FixControlStyles(Self)
end;

procedure TForm1.FormDragOver(Sender, Source: TObject; X, Y: Integer;
  State: TDragState; var Accept: Boolean);
begin
  Accept := True
end;

procedure TForm1.Button1StartDrag(Sender: TObject;
  var DragObject: TDragObject);
var
  Pt: TPoint;
begin
  //Get cursor pos
  GetCursorPos(Pt);
  //Make cursor pos relative to button
  Pt := Button1.ScreenToClient(Pt);
  //Pass info to drag object
  FDragObject := TControlDragObject.CreateWithHotSpot(Button1, Pt.X, Pt.Y);
  //Modify the var parameter
  DragObject := FDragObject
end;

procedure TForm1.Button1EndDrag(Sender, Target: TObject; X, Y: Integer);
begin
  FDragObject.Free;
  FDragObject := nil;
end;

procedure TForm1.Button1MouseDown(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
  if ssAlt in Shift then
    Button1.BeginDrag(True)
end;

procedure TForm1.FormDragDrop(Sender, Source: TObject; X, Y: Integer);
begin
  with Button1 do
    SetBounds(
      X - FDragObject.FX,
      Y - FDragObject.FY,
      Width, Height)
end;

end.
