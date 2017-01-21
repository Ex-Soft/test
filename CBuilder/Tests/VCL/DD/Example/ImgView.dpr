program ImgView;

uses
  Forms,
  ImgViewU in 'ImgViewU.pas' {Form1};

{$R *.res}

begin
{$ifndef Ver80}
  Application.Initialize;
{$endif}
  Application.Title := 'Image Viewer';
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
