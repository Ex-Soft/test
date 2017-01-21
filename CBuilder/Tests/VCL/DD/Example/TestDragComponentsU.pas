unit TestDragComponentsU;

interface

uses
{$ifndef Ver100}
  ImgList, //Not found in Delphi 3
{$endif}
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  StdCtrls, ComCtrls, DragEdit, DragButton;

type
  TForm1 = class(TForm)
    DragButton1: TDragButton;
    TreeView1: TTreeView;
    ImageList1: TImageList;
    ListView1: TListView;
    DragEdit1: TDragEdit;
    procedure FormCreate(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.DFM}

procedure FixControlStyles(Parent: TControl);
var
  I: Integer;
begin
  Parent.ControlStyle := Parent.ControlStyle + [csDisplayDragImage];
  if Parent is TWinControl then
    with TWinControl(Parent) do
      for I := 0 to ControlCount - 1 do
        FixControlStyles(Controls[I]);
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
  FixControlStyles(Self)
end;

end.
