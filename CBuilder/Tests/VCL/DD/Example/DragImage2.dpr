program DragImage2;

uses
  Forms,
  DragImage2U in 'DragImage2U.pas' {Form1};

{$R *.RES}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
