object MainForm: TMainForm
  Left = 194
  Top = 107
  Width = 928
  Height = 480
  Caption = 'Test DD'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  OnDragDrop = FormDragDrop
  OnDragOver = FormDragOver
  PixelsPerInch = 96
  TextHeight = 13
  object Button: TButton
    Left = 128
    Top = 80
    Width = 75
    Height = 25
    Caption = 'Button'
    TabOrder = 0
    OnDragDrop = ButtonDragDrop
    OnMouseDown = ButtonMouseDown
    OnStartDrag = ButtonStartDrag
  end
end
