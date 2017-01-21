object MainForm: TMainForm
  Left = 192
  Top = 107
  Width = 544
  Height = 375
  Caption = 'Test Excel'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  Menu = MainMenu1
  OldCreateOrder = False
  OnClose = FormClose
  PixelsPerInch = 96
  TextHeight = 13
  object MainMenu1: TMainMenu
    Left = 256
    Top = 160
    object File1: TMenuItem
      Caption = 'File'
      object RunExcel1: TMenuItem
        Caption = 'Run Excel'
        ShortCut = 32850
        OnClick = RunExcel1Click
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
