unit DragObjectsU;

{$ifdef Ver90} { Delphi 2.0x }
  {$define DelphiLessThan4}
{$endif}
{$ifdef Ver93} { C++ Builder 1.0x }
  {$define DelphiLessThan4}
{$endif}
{$ifdef Ver100} { Delphi 3.0x }
  {$define DelphiLessThan4}
{$endif}
{$ifdef Ver110} { C++ Builder 3.0x }
  {$define DelphiLessThan4}
{$endif}

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  StdCtrls, ExtCtrls;

type
  //Delphi 4 and later allows us to inherit custom drag objects from 
  //TDragControlObject (earlier versions forced you to go back to TDragObject)
  TTextDragObject = class(TDragControlObject)
  public
    Data: String;
  end;

  TForm1 = class(TForm)
    Label1: TLabel;
    Edit1: TEdit;
    Panel1: TPanel;
    Button1: TButton;
    Memo1: TMemo;
    ListBox1: TListBox;
    ComboBox1: TComboBox;
    procedure Button1StartDrag(Sender: TObject;
      var DragObject: TDragObject);
    procedure Label1StartDrag(Sender: TObject;
      var DragObject: TDragObject);
    procedure ComboBox1StartDrag(Sender: TObject;
      var DragObject: TDragObject);
    procedure Edit1StartDrag(Sender: TObject; var DragObject: TDragObject);
    procedure Memo1StartDrag(Sender: TObject; var DragObject: TDragObject);
    procedure ListBox1StartDrag(Sender: TObject;
      var DragObject: TDragObject);
    procedure SharedEndDrag(Sender, Target: TObject; X, Y: Integer);
    procedure Panel1DragOver(Sender, Source: TObject; X, Y: Integer;
      State: TDragState; var Accept: Boolean);
    procedure Panel1DragDrop(Sender, Source: TObject; X, Y: Integer);
  private
    FDragObject: TTextDragObject;
  end;

var
  Form1: TForm1;

implementation

{$R *.DFM}

{ TForm1 }

procedure TForm1.Button1StartDrag(Sender: TObject;
  var DragObject: TDragObject);
begin
  FDragObject := TTextDragObject.Create(Sender as TButton);
  FDragObject.Data := TButton(Sender).Caption;
  DragObject := FDragObject;
end;

procedure TForm1.Label1StartDrag(Sender: TObject;
  var DragObject: TDragObject);
begin
  FDragObject := TTextDragObject.Create(Sender as TLabel);
  FDragObject.Data := TLabel(Sender).Caption;
  DragObject := FDragObject;
end;

procedure TForm1.ComboBox1StartDrag(Sender: TObject;
  var DragObject: TDragObject);
begin
  FDragObject := TTextDragObject.Create(Sender as TComboBox);
  FDragObject.Data := TComboBox(Sender).Text;
  DragObject := FDragObject;
end;

procedure TForm1.Edit1StartDrag(Sender: TObject;
  var DragObject: TDragObject);
begin
  FDragObject := TTextDragObject.Create(Sender as TEdit);
  FDragObject.Data := TEdit(Sender).Text;
  DragObject := FDragObject;
end;

procedure TForm1.Memo1StartDrag(Sender: TObject;
  var DragObject: TDragObject);
begin
  FDragObject := TTextDragObject.Create(Sender as TMemo);
  FDragObject.Data := TMemo(Sender).Text;
  DragObject := FDragObject;
end;

procedure TForm1.ListBox1StartDrag(Sender: TObject;
  var DragObject: TDragObject);
begin
  FDragObject := TTextDragObject.Create(Sender as TListBox);
  with TListBox(Sender) do
    FDragObject.Data := Items[ItemIndex];
  DragObject := FDragObject;
end;

procedure TForm1.SharedEndDrag(Sender, Target: TObject; X, Y: Integer);
begin
  //All draggable controls share this event handler
  FDragObject.Free;
  FDragObject := nil
end;

procedure TForm1.Panel1DragOver(Sender, Source: TObject; X, Y: Integer;
  State: TDragState; var Accept: Boolean);
begin
  //It is tempting to write this...
  //Accept := Source is TTextDragObject
  //...however we are advised to write this instead in VCL apps
  Accept := IsDragObject(Source)
end;

procedure TForm1.Panel1DragDrop(Sender, Source: TObject; X, Y: Integer);
begin
  //The OnDragOver event handler verified we are dealing with a
  //drag object so there is no chance of getting a normal control
  (Sender as TPanel).Caption := TTextDragObject(Source).Data
end;

end.