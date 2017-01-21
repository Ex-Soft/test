program icq_example1_d6;

uses
  Forms,
  Unit1 in 'Unit1.pas' {Form1},
  Unit3 in 'Unit3.pas' {DemoForm},
  Unit2 in 'Unit2.pas' {ICQFrame: TFrame},
  Unit4 in 'Unit4.pas' {MetaInfoForm},
  ICQSocket in '..\..\icqsocket\ICQSocket.pas';

{$R *.RES}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.CreateForm(TDemoForm, DemoForm);
  Application.Run;
end.
