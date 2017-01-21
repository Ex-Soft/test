object DataBase: TDataBase
  OldCreateOrder = False
  OnDestroy = DataModuleDestroy
  Left = 192
  Top = 107
  Height = 150
  Width = 215
  object IBDatabase: TIBDatabase
    LoginPrompt = False
    TraceFlags = [tfQPrepare, tfQExecute, tfQFetch, tfError, tfStmt, tfConnect, tfTransact, tfBlob, tfService, tfMisc]
    Left = 24
    Top = 8
  end
  object IBSQLMonitor: TIBSQLMonitor
    OnSQL = IBSQLMonitorSQL
    TraceFlags = [tfQPrepare, tfQExecute, tfQFetch, tfError, tfStmt, tfConnect, tfTransact, tfBlob, tfService, tfMisc]
    Left = 112
    Top = 8
  end
end
