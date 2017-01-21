unit DragButton;

{$ifdef Ver90} { Delphi 2.0x }
  {$define DelphiLessThan3}
  {$define DelphiLessThan4}
{$endif}
{$ifdef Ver93} { C++ Builder 1.0x }
  {$define DelphiLessThan3}
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
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  StdCtrls;

type
  TDragButton = class(TButton)
  private
{$ifdef DelphiLessThan4}
    FDragImages: TImageList;
{$else}
    FDragImages: TDragImageList;
{$endif}
  protected
{$ifdef DelphiLessThan4}
    function GetDragImages: TCustomImageList; override;
{$else}
    function GetDragImages: TDragImageList; override;
{$endif}
    procedure MouseDown(Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer); override;
  public
    constructor Create(AOwner: TComponent); override;
  end;

procedure Register;

implementation

procedure Register;
begin
  RegisterComponents('Clinic', [TDragButton]);
end;

{ TDragButton }

constructor TDragButton.Create(AOwner: TComponent);
begin
  inherited Create(AOwner);
  ControlStyle := ControlStyle + [csDisplayDragImage]
end;

{$ifdef DelphiLessThan4}
function TDragButton.GetDragImages: TCustomImageList;
{$else}
function TDragButton.GetDragImages: TDragImageList;
{$endif}
var
  Bmp: TBitmap;
  BmpIdx: Integer;
  Pt: TPoint;
begin
  if not Assigned(FDragImages) then
  {$ifdef DelphiLessThan4}
    FDragImages := TImageList.Create(Self);
  {$else}
    FDragImages := TDragImageList.Create(Self);
  {$endif}
  Bmp := TBitmap.Create;
  try
    Bmp.Width := Width;
    Bmp.Height := Height;
  {$ifndef DelphiLessThan3}
    Bmp.Canvas.Lock;
  {$endif}
    try
      PaintTo(Bmp.Canvas.Handle, 0, 0);
    finally
    {$ifndef DelphiLessThan3}
      Bmp.Canvas.UnLock
    {$endif}
    end;
    FDragImages.Width := Width;
    FDragImages.Height := Height;
    BmpIdx := FDragImages.AddMasked(Bmp, clBtnFace);
    //Where is mouse relative to control?
    GetCursorPos(Pt);
    Pt := ScreenToClient(Pt);
    //Specify drag image and hot spot
    FDragImages.SetDragImage(BmpIdx, Pt.X, Pt.Y);
    Result := FDragImages;
  finally
    Bmp.Free
  end
end;

procedure TDragButton.MouseDown(Button: TMouseButton; Shift: TShiftState;
  X, Y: Integer);
begin
  inherited;
  //Automatically start dragging on a Ctrl-click
  if ssCtrl in Shift then
    BeginDrag(True)
end;

end.
