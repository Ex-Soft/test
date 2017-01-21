program Cursor;

uses
  Forms,
  CursorU in 'CursorU.pas' {Form1};

{$R *.RES}

begin
{$ifdef Win32}
  Application.Initialize;
{$endif}
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
