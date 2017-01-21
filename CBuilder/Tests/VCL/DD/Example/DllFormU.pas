unit DllFormU;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  StdCtrls;

type
  TDLLForm = class(TForm)
    Memo1: TMemo;
    Label1: TLabel;
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure Memo1MouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure Memo1StartDrag(Sender: TObject; var DragObject: TDragObject);
    procedure Memo1EndDrag(Sender, Target: TObject; X, Y: Integer);
  private
    FDragObject: TDragObject;
  public
    { Public declarations }
  end;

procedure ShowForm(ApplicationHandle: HWnd); stdcall;

implementation

uses
  DLLDragObject;

{$R *.DFM}

procedure ShowForm(ApplicationHandle: HWnd); stdcall;
begin
  //Set Application object window handle to match that in the EXE,
  //meaning we do not get another task bar button for the form
  Application.Handle := ApplicationHandle;
  TDLLForm.Create(Application).Show
end;

procedure TDLLForm.FormClose(Sender: TObject; var Action: TCloseAction);
begin
  //The form frees itself when closed
  Action := caFree
end;

procedure TDLLForm.Memo1MouseDown(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
  //Check for right mouse button, and no other buttons/keys
  if Shift = [ssRight] then
    (Sender as TCustomEdit).BeginDrag(True);
end;

procedure TDLLForm.Memo1StartDrag(Sender: TObject;
  var DragObject: TDragObject);
begin
  DragObject := TTextDragObject.Create;
  TTextDragObject(DragObject).Data := (Sender as TMemo).SelText;
  FDragObject := DragObject
end;

procedure TDLLForm.Memo1EndDrag(Sender, Target: TObject; X, Y: Integer);
begin
  FDragObject.Free;
  FDragObject := nil
end;

end.
