object MainForm: TMainForm
  Left = 193
  Top = 107
  Width = 544
  Height = 375
  Caption = 'MainForm'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object Edit1: TEdit
    Left = 16
    Top = 16
    Width = 121
    Height = 21
    TabOrder = 0
    OnKeyDown = Edit1KeyDown
    OnKeyPress = Edit1KeyPress
    OnKeyUp = Edit1KeyUp
  end
  object Memo1: TMemo
    Left = 144
    Top = 8
    Width = 377
    Height = 321
    ScrollBars = ssVertical
    TabOrder = 1
  end
end
