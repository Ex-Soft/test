object MainForm: TMainForm
  Left = 193
  Top = 107
  BorderIcons = [biSystemMenu]
  BorderStyle = bsSingle
  Caption = 'Test connect'
  ClientHeight = 348
  ClientWidth = 536
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
  object LabelPrompt: TLabel
    Left = 16
    Top = 20
    Width = 50
    Height = 13
    AutoSize = False
    Caption = 'Prompt'
  end
  object DBGrid: TDBGrid
    Left = 16
    Top = 48
    Width = 505
    Height = 147
    DataSource = DataSource
    TabOrder = 0
    TitleFont.Charset = DEFAULT_CHARSET
    TitleFont.Color = clWindowText
    TitleFont.Height = -11
    TitleFont.Name = 'MS Sans Serif'
    TitleFont.Style = []
  end
  object EditInput: TEdit
    Left = 71
    Top = 16
    Width = 150
    Height = 21
    TabOrder = 1
    OnChange = EditInputChange
  end
  object Memo: TMemo
    Left = 16
    Top = 208
    Width = 505
    Height = 89
    ScrollBars = ssBoth
    TabOrder = 2
  end
  object IBDatabase: TIBDatabase
    DatabaseName = 'E:\Soft.src\CBuilder\Tests\IB\TestIB.#1\TEST.GDB'
    Params.Strings = (
      'user_name=sysdba'
      'password=masterkey'
      'lc_ctype=WIN1251')
    LoginPrompt = False
    DefaultTransaction = IBTransaction
    TraceFlags = [tfQPrepare, tfQExecute, tfQFetch, tfError, tfStmt, tfConnect, tfTransact, tfBlob, tfService, tfMisc]
    Left = 384
    Top = 8
  end
  object IBTransaction: TIBTransaction
    DefaultDatabase = IBDatabase
    DefaultAction = TARollback
    Params.Strings = (
      'read'
      'nowait'
      'read_committed'
      'rec_version')
    Left = 424
    Top = 8
  end
  object IBQuery: TIBQuery
    Database = IBDatabase
    Transaction = IBTransaction
    Left = 464
    Top = 8
  end
  object DataSource: TDataSource
    DataSet = IBQuery
    Left = 504
    Top = 8
  end
  object IBSQLMonitor: TIBSQLMonitor
    OnSQL = IBSQLMonitorSQL
    TraceFlags = [tfQPrepare, tfQExecute, tfQFetch, tfError, tfStmt, tfConnect, tfTransact, tfBlob, tfService, tfMisc]
    Left = 352
    Top = 8
  end
end
