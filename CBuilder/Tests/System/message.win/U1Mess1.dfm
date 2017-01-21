object Form1: TForm1
  Left = 190
  Top = 140
  Width = 230
  Height = 175
  Caption = 'Form1'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  Visible = True
  PixelsPerInch = 96
  TextHeight = 13
  object Button1: TButton
    Left = 8
    Top = 8
    Width = 90
    Height = 25
    Caption = 'Show Form2'
    TabOrder = 0
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 112
    Top = 8
    Width = 90
    Height = 25
    Caption = 'Close Form2'
    TabOrder = 1
    OnClick = Button2Click
  end
  object Button3: TButton
    Left = 16
    Top = 56
    Width = 90
    Height = 25
    Caption = 'Exec PMess2'
    TabOrder = 2
    OnClick = Button3Click
  end
  object Button4: TButton
    Left = 120
    Top = 56
    Width = 90
    Height = 25
    Caption = 'Close PMess2'
    TabOrder = 3
    OnClick = Button4Click
  end
end
