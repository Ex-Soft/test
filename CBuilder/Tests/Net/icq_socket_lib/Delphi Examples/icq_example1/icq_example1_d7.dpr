program icq_example1_d7;

uses
  Forms,
  Unit2 in 'Unit2.pas' {ICQFrame: TFrame},
  Unit3 in 'Unit3.pas' {DemoForm},
  Unit4 in 'Unit4.pas' {MetaInfoForm},
  Unit1 in 'Unit1.pas' {Form1};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.CreateForm(TDemoForm, DemoForm);
  Application.Run;
end.
