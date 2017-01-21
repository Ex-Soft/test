object DataBases: TDataBases
  OldCreateOrder = False
  OnDestroy = DataModuleDestroy
  Left = 192
  Top = 103
  Height = 375
  Width = 544
  object IBDatabase: TIBDatabase
    Left = 16
    Top = 8
  end
  object IBTransaction: TIBTransaction
    Left = 72
    Top = 8
  end
  object IBSQL: TIBSQL
    Left = 136
    Top = 8
  end
end
