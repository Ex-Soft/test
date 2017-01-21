object MainForm: TMainForm
  Left = 192
  Top = 107
  Width = 544
  Height = 375
  Caption = 'Main Form'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  Position = poScreenCenter
  PixelsPerInch = 96
  TextHeight = 13
  object CreateAdd: TButton
    Left = 16
    Top = 16
    Width = 75
    Height = 25
    Caption = 'CreateAdd'
    TabOrder = 0
    OnClick = CreateAddClick
  end
  object Table1: TTable
    IndexDefs = <
      item
        Name = 'Table1Index1'
      end>
    StoreDefs = True
    Left = 256
    Top = 160
  end
end
