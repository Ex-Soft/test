object DataBase: TDataBase
  OldCreateOrder = False
  OnCreate = DataModuleCreate
  OnDestroy = DataModuleDestroy
  Left = 193
  Top = 107
  Height = 150
  Width = 215
  object ADOConnectionDbf: TADOConnection
    Left = 40
    Top = 16
  end
  object ADOTableDbf: TADOTable
    Left = 40
    Top = 72
  end
  object ADOQueryDbf: TADOQuery
    Parameters = <>
    Left = 128
    Top = 72
  end
  object DataSourceDbGrid: TDataSource
    Left = 128
    Top = 16
  end
end
