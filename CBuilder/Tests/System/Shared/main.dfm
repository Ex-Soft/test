object MainForm: TMainForm
  Left = 192
  Top = 107
  Width = 544
  Height = 375
  Caption = 'Shared'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  Position = poScreenCenter
  Scaled = False
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 16
    Top = 16
    Width = 60
    Height = 13
    Caption = 'Server name'
  end
  object Label2: TLabel
    Left = 16
    Top = 40
    Width = 46
    Height = 13
    Caption = 'Net name'
  end
  object Edit1: TEdit
    Left = 128
    Top = 8
    Width = 121
    Height = 21
    TabOrder = 0
  end
  object Edit2: TEdit
    Left = 128
    Top = 40
    Width = 121
    Height = 21
    TabOrder = 1
  end
  object Button1: TButton
    Left = 320
    Top = 24
    Width = 150
    Height = 25
    Caption = 'SHARE_INFO_0'
    TabOrder = 2
    OnClick = Button1Click
  end
  object StaticText1: TStaticText
    Left = 24
    Top = 80
    Width = 4
    Height = 4
    TabOrder = 3
  end
  object Button2: TButton
    Left = 320
    Top = 58
    Width = 150
    Height = 25
    Caption = 'SHARE_INFO_1'
    TabOrder = 4
    OnClick = Button2Click
  end
end
