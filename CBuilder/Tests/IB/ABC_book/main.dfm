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
  Position = poScreenCenter
  OnClose = FormClose
  OnCloseQuery = FormCloseQuery
  OnCreate = FormCreate
  OnShow = FormShow
  PixelsPerInch = 96
  TextHeight = 13
  object PageControlMain: TPageControl
    Left = 0
    Top = 0
    Width = 536
    Height = 348
    ActivePage = TabSheetLog
    Align = alClient
    TabIndex = 1
    TabOrder = 0
    object TabSheetTable: TTabSheet
      Caption = 'Table'
      object DBText1: TDBText
        Left = 8
        Top = 144
        Width = 42
        Height = 13
        AutoSize = True
      end
      object DBGridInsurant: TDBGrid
        Left = 8
        Top = 16
        Width = 320
        Height = 120
        TabOrder = 0
        TitleFont.Charset = DEFAULT_CHARSET
        TitleFont.Color = clWindowText
        TitleFont.Height = -11
        TitleFont.Name = 'MS Sans Serif'
        TitleFont.Style = []
      end
      object DBEdit1: TDBEdit
        Left = 8
        Top = 168
        Width = 121
        Height = 21
        TabOrder = 1
        OnChange = DBEdit1Change
      end
      object DBMemo1: TDBMemo
        Left = 8
        Top = 200
        Width = 185
        Height = 89
        TabOrder = 2
      end
    end
    object TabSheetLog: TTabSheet
      Caption = 'Log'
      ImageIndex = 1
      object RichEditLog: TRichEdit
        Left = 0
        Top = 0
        Width = 528
        Height = 320
        Align = alClient
        ScrollBars = ssBoth
        TabOrder = 0
      end
    end
  end
end
