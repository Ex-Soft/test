object DataBases: TDataBases
  OldCreateOrder = False
  OnDestroy = DataModuleDestroy
  Left = 459
  Top = 120
  Height = 344
  Width = 341
  object IBDatabase: TIBDatabase
    OnLogin = IBDatabaseLogin
    Left = 72
    Top = 16
  end
  object IBTransaction1: TIBTransaction
    Left = 32
    Top = 72
  end
  object IBSQL1: TIBSQL
    Left = 32
    Top = 128
  end
  object IBTransaction2: TIBTransaction
    Left = 112
    Top = 72
  end
  object IBSQL2: TIBSQL
    Left = 112
    Top = 128
  end
  object IBDatabaseInfo: TIBDatabaseInfo
    Left = 256
    Top = 16
  end
  object IBExtract: TIBExtract
    Left = 256
    Top = 72
  end
  object IBStoredProc1: TIBStoredProc
    Left = 32
    Top = 184
  end
  object IBStoredProc2: TIBStoredProc
    Left = 112
    Top = 184
  end
  object IBTable: TIBTable
    StoreDefs = True
    Left = 256
    Top = 128
  end
  object IBQuery: TIBQuery
    Left = 256
    Top = 184
  end
  object IBTableDBF: TIBTable
    Database = IBDatabase
    StoreDefs = True
    Left = 200
    Top = 128
  end
  object IBFilterDialog: TIBFilterDialog
    Caption = 'IBX Filter Dialog'
    Left = 32
    Top = 256
  end
  object IBScript: TIBScript
    Terminator = ';'
    OnParse = IBScriptParse
    OnParseError = IBScriptParseError
    OnExecuteError = IBScriptExecuteError
    OnParamCheck = IBScriptParamCheck
    Left = 120
    Top = 256
  end
  object IBSQLParser: TIBSQLParser
    Paused = False
    Terminator = ';'
    OnParse = IBSQLParserParse
    OnError = IBSQLParserError
    Left = 184
    Top = 256
  end
  object IBDatabaseINI: TIBDatabaseINI
    UseAppPath = ipoPathToServer
    Section = 'Database Settings'
    Left = 264
    Top = 256
  end
end
