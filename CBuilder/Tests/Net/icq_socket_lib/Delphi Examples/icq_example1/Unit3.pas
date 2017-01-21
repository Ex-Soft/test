unit Unit3;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  StdCtrls, Buttons;

type
  TDemoForm = class(TForm)
    Label2: TLabel;
    UrlLabel: TLabel;
    Label3: TLabel;
    BitBtn1: TBitBtn;
    Label4: TLabel;
    procedure UrlLabelClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  DemoForm: TDemoForm;

implementation

{$R *.DFM}

Uses Unit1;

procedure TDemoForm.UrlLabelClick(Sender: TObject);
begin
  GotoInternet;
end;

end.
