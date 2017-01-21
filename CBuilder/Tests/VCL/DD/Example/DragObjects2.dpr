program DragObjects2;

uses
  Forms,
  DragObjects2U in 'DragObjects2U.pas' {Form1};

{$R *.RES}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
