program TestDragComponents;

uses
  Forms,
  TestDragComponentsU in 'TestDragComponentsU.pas' {Form1};

{$R *.RES}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
