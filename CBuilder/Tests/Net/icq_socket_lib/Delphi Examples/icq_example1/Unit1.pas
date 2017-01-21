unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  ExtCtrls, Unit2, StdCtrls, ICQSocket, ComCtrls, Menus;

type
  TForm1 = class(TForm)
    Panel1: TPanel;
    StatusBar: TStatusBar;
    Panel2: TPanel;
    Panel3: TPanel;
    Part1: TICQFrame;
    Panel4: TPanel;
    Part2: TICQFrame;
    procedure FormCreate(Sender: TObject);
    procedure FormDestroy(Sender: TObject);
    procedure UrlLabelClick(Sender: TObject);
    procedure Part1SetContactBtnClick(Sender: TObject);
    procedure StatusBarClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

procedure GotoInternet;

implementation

{$R *.DFM}

Uses ShellApi,ICQ_Socket_pas;

procedure GotoInternet;
begin
  ShellExecute(0,PChar('open'),
//    PChar('start'),
    PChar('http://softvariant.boom.ru'),
    nil,
    nil,
    SW_MAXIMIZE);
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
  StatusBar.SimpleText := Format(
    'http://softvariant.boom.ru,  softvariant@chat.ru,   %s  Version:  %s',
    [ICQ_LibName,ICQLib_GetStrVersion]);
    
  Part1.LoadState;
  Part2.LoadState;
end;

procedure TForm1.FormDestroy(Sender: TObject);
begin
  Part1.SaveState;
  Part2.SaveState;

  Part1.ICQSocket.Active := False;
  Part2.ICQSocket.Active := False;
end;

procedure TForm1.UrlLabelClick(Sender: TObject);
begin
  GotoInternet;
end;

procedure TForm1.Part1SetContactBtnClick(Sender: TObject);
begin
  Part1.SetContactBtnClick(Sender);
end;

procedure TForm1.StatusBarClick(Sender: TObject);
begin
  GotoInternet;
end;

end.
