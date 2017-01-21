object DataBase: TDataBase
  OldCreateOrder = False
  OnCreate = DataModuleCreate
  OnDestroy = DataModuleDestroy
  Left = 192
  Top = 107
  Height = 150
  Width = 215
  object IBDatabase: TIBDatabase
    Left = 24
    Top = 8
  end
  object IBTransaction: TIBTransaction
    Left = 88
    Top = 8
  end
  object IBSQL: TIBSQL
    Left = 160
    Top = 8
  end
end
