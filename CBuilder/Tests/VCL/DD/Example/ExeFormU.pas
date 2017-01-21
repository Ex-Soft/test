unit ExeFormU;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  StdCtrls;

type
  TExeForm = class(TForm)
    btnShowOtherForm: TButton;
    Edit1: TEdit;
    Label1: TLabel;
    procedure btnShowOtherFormClick(Sender: TObject);
    procedure Edit1DragOver(Sender, Source: TObject; X, Y: Integer;
      State: TDragState; var Accept: Boolean);
    procedure Edit1DragDrop(Sender, Source: TObject; X, Y: Integer);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  ExeForm: TExeForm;

implementation

uses
  DLLDragObject;

{$R *.DFM}

procedure ShowForm(Wnd: HWnd); stdcall;
external 'DllDrag.Dll';

procedure TExeForm.btnShowOtherFormClick(Sender: TObject);
begin
  ShowForm(Application.Handle)
end;

procedure TExeForm.Edit1DragOver(Sender, Source: TObject; X, Y: Integer;
  State: TDragState; var Accept: Boolean);
begin
  Accept := IsDragObject(Source)
end;

procedure TExeForm.Edit1DragDrop(Sender, Source: TObject; X, Y: Integer);
begin
  (Sender as TCustomEdit).Text := TTextDragObject(Source).Data
end;

end.
