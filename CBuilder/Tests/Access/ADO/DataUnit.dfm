object DataBase: TDataBase
  OldCreateOrder = False
  OnCreate = DataModuleCreate
  OnDestroy = DataModuleDestroy
  Left = 193
  Top = 107
  Height = 150
  Width = 215
  object ADOQuery1: TADOQuery
    Parameters = <>
    Left = 88
    Top = 48
  end
  object ADOConnection: TADOConnection
    Left = 32
    Top = 8
  end
end
