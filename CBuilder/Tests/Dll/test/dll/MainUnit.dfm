object TestDllForm: TTestDllForm
  Left = 195
  Top = 107
  Width = 151
  Height = 149
  Caption = 'Test Dll'
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
    object TestDll: TMenuItem
      Caption = 'Test Dll'
      object TestPrint: TMenuItem
        Caption = 'Tes tPrint'
        OnClick = TestPrintClick
      end
      object TestMail: TMenuItem
        Caption = 'Test Mail'
        OnClick = TestMailClick
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
