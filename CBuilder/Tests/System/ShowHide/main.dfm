object MainForm: TMainForm
  Left = 192
  Top = 107
  BorderIcons = [biSystemMenu]
  BorderStyle = bsSingle
  Caption = 'Test Show/Hide'
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
  OnActivate = FormActivate
  PixelsPerInch = 96
  TextHeight = 13
  object ButtonShow: TButton
    Left = 8
    Top = 8
    Width = 75
    Height = 25
    Caption = 'Show'
    TabOrder = 0
    OnClick = ButtonClick
  end
  object ButtonHide: TButton
    Left = 96
    Top = 8
    Width = 75
    Height = 25
    Caption = 'Hide'
    TabOrder = 1
    OnClick = ButtonClick
  end
end
