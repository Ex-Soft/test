object SplashForm: TSplashForm
  Left = 192
  Top = 107
  Width = 544
  Height = 375
  Caption = 'Splash Form '
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  Position = poScreenCenter
  Scaled = False
  OnClose = FormClose
  OnPaint = FormPaint
  OnShow = FormShow
  PixelsPerInch = 96
  TextHeight = 13
  object Button: TButton
    Left = 448
    Top = 312
    Width = 75
    Height = 25
    Caption = 'Button'
    TabOrder = 0
    OnClick = ButtonClick
  end
end
