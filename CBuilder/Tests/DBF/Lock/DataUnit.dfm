object DataBases: TDataBases
  OldCreateOrder = False
  OnDestroy = DataModuleDestroy
  Left = 610
  Top = 136
  Height = 127
  Width = 189
  object TestTable: TTable
    SessionName = 'Default'
    TableType = ttFoxPro
    Left = 16
    Top = 8
  end
  object Query: TQuery
    SessionName = 'Default'
    Left = 72
    Top = 8
  end
end
