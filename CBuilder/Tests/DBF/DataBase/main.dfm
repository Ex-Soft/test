object MainForm: TMainForm
  Left = 192
  Top = 107
  Width = 544
  Height = 375
  Caption = 'DataBase Test Form'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  Position = poScreenCenter
  OnClose = FormClose
  OnShow = FormShow
  PixelsPerInch = 96
  TextHeight = 13
  object PageControl1: TPageControl
    Left = 0
    Top = 0
    Width = 536
    Height = 348
    ActivePage = TabSheetTable
    Align = alClient
    TabIndex = 0
    TabOrder = 0
    object TabSheetTable: TTabSheet
      Caption = 'Table'
      object DBGrid1: TDBGrid
        Left = 0
        Top = 0
        Width = 528
        Height = 320
        Align = alClient
        DataSource = DataSource1
        ParentShowHint = False
        ShowHint = True
        TabOrder = 0
        TitleFont.Charset = DEFAULT_CHARSET
        TitleFont.Color = clWindowText
        TitleFont.Height = -11
        TitleFont.Name = 'MS Sans Serif'
        TitleFont.Style = []
        OnMouseMove = DBGrid1MouseMove
      end
    end
    object TabSheetQuery: TTabSheet
      Caption = 'Query'
      ImageIndex = 1
      object DBGridQuery1: TDBGrid
        Left = 0
        Top = 0
        Width = 528
        Height = 320
        Align = alClient
        DataSource = DataBases.DataSource1
        TabOrder = 0
        TitleFont.Charset = DEFAULT_CHARSET
        TitleFont.Color = clWindowText
        TitleFont.Height = -11
        TitleFont.Name = 'MS Sans Serif'
        TitleFont.Style = []
      end
    end
  end
  object Table1: TTable
    TableType = ttFoxPro
    Left = 16
    Top = 16
  end
  object DataSource1: TDataSource
    DataSet = Table1
    Left = 64
    Top = 16
  end
end
