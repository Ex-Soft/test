object frmMain: TfrmMain
  Left = 192
  Top = 107
  Width = 715
  Height = 540
  Caption = 'Scripting Example'
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
  object Memo1: TMemo
    Left = 32
    Top = 40
    Width = 325
    Height = 277
    Lines.Strings = (
      
        'connect database '#39'c:\program files\Firebird\examples\employee.gd' +
        'b'#39
      '   user '#39'sysdba'#39' user '#39'masterkey'#39';'
      ''
      'set term ^;'
      ''
      'select * from employee^'
      ''
      'set term ;^')
    ScrollBars = ssBoth
    TabOrder = 0
  end
  object Memo2: TMemo
    Left = 368
    Top = 40
    Width = 329
    Height = 169
    ScrollBars = ssBoth
    TabOrder = 1
  end
  object Button1: TButton
    Left = 343
    Top = 332
    Width = 75
    Height = 25
    Caption = 'Parse'
    TabOrder = 2
    OnClick = Button1Click
  end
  object Memo3: TMemo
    Left = 368
    Top = 216
    Width = 329
    Height = 105
    ScrollBars = ssBoth
    TabOrder = 3
  end
  object Button2: TButton
    Left = 246
    Top = 332
    Width = 75
    Height = 25
    Caption = 'LoadFromFile'
    TabOrder = 4
    OnClick = Button2Click
  end
  object Button3: TButton
    Left = 440
    Top = 332
    Width = 75
    Height = 25
    Action = Paused
    TabOrder = 5
  end
  object chkPause: TCheckBox
    Left = 536
    Top = 336
    Width = 121
    Height = 17
    Caption = 'Pause Statements'
    TabOrder = 6
  end
  object DBGrid1: TDBGrid
    Left = 40
    Top = 376
    Width = 649
    Height = 137
    DataSource = DataSource1
    TabOrder = 7
    TitleFont.Charset = DEFAULT_CHARSET
    TitleFont.Color = clWindowText
    TitleFont.Height = -11
    TitleFont.Name = 'MS Sans Serif'
    TitleFont.Style = []
  end
  object Button4: TButton
    Left = 149
    Top = 332
    Width = 75
    Height = 25
    Caption = 'Execute'
    TabOrder = 8
    OnClick = Button4Click
  end
  object Button5: TButton
    Left = 52
    Top = 332
    Width = 75
    Height = 25
    Caption = 'Validate'
    TabOrder = 9
    OnClick = Button5Click
  end
  object OpenDialog1: TOpenDialog
    Filter = 'SQL (*.SQL)|*.SQL'
    Left = 168
    Top = 304
  end
  object ActionList1: TActionList
    Left = 528
    Top = 332
    object Paused: TAction
      Caption = 'Paused'
      OnExecute = PausedExecute
      OnUpdate = PausedUpdate
    end
  end
  object IBDatabase1: TIBDatabase
    DatabaseName = 'C:\Program Files\Firebird\examples\employee.gdb'
    Params.Strings = (
      'user_name=sysdba'
      'password=masterkey')
    LoginPrompt = False
    DefaultTransaction = IBTransaction1
    SQLDialect = 1
    Left = 216
    Top = 8
  end
  object IBDataSet1: TIBDataSet
    Database = IBDatabase1
    Transaction = IBTransaction1
    InsertSQL.Strings = (
      '')
    SelectSQL.Strings = (
      '')
    Left = 272
    Top = 8
  end
  object IBTransaction1: TIBTransaction
    DefaultDatabase = IBDatabase1
    Params.Strings = (
      'read_committed'
      'rec_version'
      'nowait')
    Left = 240
    Top = 8
  end
  object IBScript1: TIBScript
    Dataset = IBDataSet1
    Database = IBDatabase1
    Transaction = IBTransaction1
    Terminator = ';'
    Statistics = False
    OnParse = IBScript1Parse
    OnParseError = IBScript1ParseError
    Left = 360
    Top = 8
  end
  object DataSource1: TDataSource
    DataSet = IBDataSet1
    Left = 304
    Top = 8
  end
end
