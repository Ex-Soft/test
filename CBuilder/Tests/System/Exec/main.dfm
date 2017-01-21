object MainForm: TMainForm
  Left = 192
  Top = 107
  Width = 544
  Height = 375
  Caption = 'Exec'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  Menu = MainMenu1
  OldCreateOrder = False
  Position = poScreenCenter
  PixelsPerInch = 96
  TextHeight = 13
  object MainMenu1: TMainMenu
    Left = 8
    Top = 8
    object File1: TMenuItem
      Caption = 'File'
      object Pack1: TMenuItem
        Caption = 'Pack'
        ShortCut = 32848
        OnClick = Pack1Click
      end
      object UnPack1: TMenuItem
        Caption = 'UnPack'
        ShortCut = 32853
        OnClick = UnPack1Click
      end
      object N1: TMenuItem
        Caption = '-'
      end
      object Exit1: TMenuItem
        Caption = 'E&xit'
        ShortCut = 32856
        OnClick = Exit1Click
      end
    end
  end
end
