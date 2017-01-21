object DataBases: TDataBases
  OldCreateOrder = False
  OnDestroy = DataModuleDestroy
  Left = 192
  Top = 103
  Height = 375
  Width = 544
  object IBDatabase: TIBDatabase
    Left = 72
    Top = 8
  end
  object IBTransaction: TIBTransaction
    Left = 32
    Top = 168
  end
  object IBQuery: TIBQuery
    Left = 32
    Top = 232
  end
  object IBEvents: TIBEvents
    AutoRegister = False
    Registered = False
    OnEventAlert = IBEventsEventAlert
    Left = 288
    Top = 16
  end
  object IBViewQuery: TIBQuery
    Left = 128
    Top = 232
  end
  object DataSource: TDataSource
    Left = 72
    Top = 72
  end
end
