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
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 456
    Top = 88
    Width = 35
    Height = 13
    Caption = 'Answer'
  end
  object Button1: TButton
    Left = 432
    Top = 32
    Width = 75
    Height = 25
    Caption = 'Start Thread'
    TabOrder = 0
    OnClick = Button1Click
  end
  object Edit1: TEdit
    Left = 408
    Top = 112
    Width = 121
    Height = 21
    TabOrder = 1
  end
  object Memo1: TMemo
    Left = 24
    Top = 64
    Width = 353
    Height = 241
    TabOrder = 2
  end
end
