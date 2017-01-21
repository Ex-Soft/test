unit CursorU;

interface

uses
  WinProcs, WinTypes, Messages, SysUtils, Classes, Controls, Forms,
  Dialogs, StdCtrls, Menus;

type
  TForm1 = class(TForm)
    Edit1: TEdit;
    Memo1: TMemo;
    Label1: TLabel;
    procedure FormCreate(Sender: TObject);
    procedure Edit1MouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure Memo1DragOver(Sender, Source: TObject; X, Y: Integer;
      State: TDragState; var Accept: Boolean);
    procedure Memo1DragDrop(Sender, Source: TObject; X, Y: Integer);
  end;

var
  Form1: TForm1;

const
  crPacMan = 1; { Use values bigger than 0 }

implementation

{$R *.DFM}
{$ifdef Win32}
  {$R PacCur32.Res}
{$else}
  {$R PacCur16.Res}
{$endif}

procedure TForm1.FormCreate(Sender: TObject);
begin
  Screen.Cursors[crPacMan] := LoadCursor(HInstance, 'PacMan');
  Edit1.DragCursor := crPacMan
end;

procedure TForm1.Edit1MouseDown(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
  if ssCtrl in Shift then
    (Sender as TControl).BeginDrag(False)
end;

procedure TForm1.Memo1DragOver(Sender, Source: TObject; X, Y: Integer;
  State: TDragState; var Accept: Boolean);
begin
  Accept := Source is TEdit
end;

procedure TForm1.Memo1DragDrop(Sender, Source: TObject; X, Y: Integer);
begin
  Memo1.Text := Edit1.Text
end;

end.
