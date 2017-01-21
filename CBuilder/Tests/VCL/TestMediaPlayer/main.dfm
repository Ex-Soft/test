object MainForm: TMainForm
  Left = 190
  Top = 107
  BorderIcons = [biSystemMenu]
  BorderStyle = bsSingle
  Caption = 'Test MediaPlayer'
  ClientHeight = 453
  ClientWidth = 688
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  Position = poScreenCenter
  Scaled = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object MediaPlayer1: TMediaPlayer
    Left = 232
    Top = 224
    Width = 253
    Height = 30
    TabOrder = 0
  end
  object ListBox1: TListBox
    Left = 24
    Top = 8
    Width = 121
    Height = 97
    ItemHeight = 13
    TabOrder = 1
    OnClick = ListBox1Click
  end
end
