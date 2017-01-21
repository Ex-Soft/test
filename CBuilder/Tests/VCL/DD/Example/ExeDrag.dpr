program ExeDrag;

uses
  Forms,
  ExeFormU in 'ExeFormU.pas' {ExeForm},
  DLLDragObject in 'DLLDragObject.pas';

{$R *.RES}

begin
  Application.Initialize;
  Application.CreateForm(TExeForm, ExeForm);
  Application.Run;
end.
