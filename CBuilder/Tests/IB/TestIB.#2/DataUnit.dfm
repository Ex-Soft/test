object DataBases: TDataBases
  OldCreateOrder = False
  OnCreate = DataModuleCreate
  OnDestroy = DataModuleDestroy
  Left = 192
  Top = 107
  Height = 215
  Width = 286
  object IBDatabase: TIBDatabase
    SQLDialect = 1
    Left = 16
    Top = 8
  end
  object IBTransaction: TIBTransaction
    Left = 16
    Top = 56
  end
  object IBSQL1: TIBSQL
    Left = 88
    Top = 56
  end
  object IBStoredProc: TIBStoredProc
    Left = 24
    Top = 120
  end
  object IBSecurityService: TIBSecurityService
    TraceFlags = []
    SecurityAction = ActionAddUser
    UserID = 0
    GroupID = 0
    Left = 96
    Top = 120
  end
  object IBServerProperties: TIBServerProperties
    TraceFlags = []
    Options = []
    Left = 192
    Top = 120
  end
  object IBSQL2: TIBSQL
    Left = 136
    Top = 56
  end
  object IBQuery1: TIBQuery
    Left = 88
    Top = 8
  end
  object IBQuery2: TIBQuery
    Left = 136
    Top = 8
  end
end
