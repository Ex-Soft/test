object TestForm: TTestForm
  Left = 192
  Top = 103
  Width = 135
  Height = 125
  Caption = 'Test'
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
    object Test1: TMenuItem
      Caption = 'Test'
      object Testprint1: TMenuItem
        Caption = 'Test print'
        OnClick = Testprint1Click
      end
      object Testmail1: TMenuItem
        Caption = 'Test mail'
        OnClick = Testmail1Click
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
