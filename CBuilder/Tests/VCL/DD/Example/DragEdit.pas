unit DragEdit;

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
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  StdCtrls;

type

  TDragEdit = class(TEdit)
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

{$R DragEditImage.Res}

procedure Register;
begin
  RegisterComponents('Clinic', [TDragEdit]);
end;

{ TDragEdit }

constructor TDragEdit.Create(AOwner: TComponent);
begin
  inherited Create(AOwner);
  ControlStyle := ControlStyle + [csDisplayDragImage];
end;

{$ifdef DelphiLessThan4}
function TDragEdit.GetDragImages: TCustomImageList;
{$else}
function TDragEdit.GetDragImages: TDragImageList;
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
    Bmp.LoadFromResourceName(HInstance, 'Athena');
    FDragImages.Width := Bmp.Width;
    FDragImages.Height := Bmp.Height;
    BmpIdx := FDragImages.AddMasked(Bmp, clSilver);
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

procedure TDragEdit.MouseDown(Button: TMouseButton; Shift: TShiftState; X,
  Y: Integer);
begin
  inherited;
  //Automatically start dragging on a Ctrl-click
  if ssCtrl in Shift then
    BeginDrag(True)
end;

end.
