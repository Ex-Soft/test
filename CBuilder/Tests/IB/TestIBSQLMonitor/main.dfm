object MainForm: TMainForm
  Left = 192
  Top = 107
  Width = 696
  Height = 480
  Caption = 'MainForm'
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
  object ButtonOpen: TButton
    Left = 0
    Top = 8
    Width = 75
    Height = 25
    Caption = 'Open'
    TabOrder = 0
    OnClick = ButtonOpenClick
  end
  object ButtonClose: TButton
    Left = 88
    Top = 8
    Width = 75
    Height = 25
    Caption = 'Close'
    Enabled = False
    TabOrder = 1
    OnClick = ButtonCloseClick
  end
  object ButtonLoad: TButton
    Left = 176
    Top = 8
    Width = 75
    Height = 25
    Caption = 'Load'
    TabOrder = 2
    OnClick = ButtonLoadClick
  end
  object ButtonFree: TButton
    Left = 256
    Top = 8
    Width = 75
    Height = 25
    Caption = 'Free'
    Enabled = False
    TabOrder = 3
    OnClick = ButtonFreeClick
  end
  object ButtonEnabled: TButton
    Left = 336
    Top = 8
    Width = 75
    Height = 25
    Caption = 'Enabled'
    Enabled = False
    TabOrder = 4
    OnClick = ButtonEnabledDisabledClick
  end
  object ButtonDisabled: TButton
    Left = 416
    Top = 8
    Width = 75
    Height = 25
    Caption = 'Disabled'
    Enabled = False
    TabOrder = 5
    OnClick = ButtonEnabledDisabledClick
  end
end
