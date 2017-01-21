object DataBases: TDataBases
  OldCreateOrder = False
  OnCreate = DataModuleCreate
  OnDestroy = DataModuleDestroy
  Left = 585
  Top = 153
  Height = 150
  Width = 215
  object Table1: TTable
    FieldDefs = <
      item
        Name = 'ftFloat'
        DataType = ftFloat
      end
      item
        Name = 'ftInteger'
        DataType = ftInteger
      end
      item
        Name = 'ftSmallint'
        DataType = ftSmallint
      end
      item
        Name = 'ftBCD_0'
        DataType = ftBCD
        Precision = 18
        Size = 4
      end
      item
        Name = 'ftBCD_4'
        DataType = ftBCD
        Precision = 18
        Size = 4
      end
      item
        Name = 'ftBCD_9'
        DataType = ftBCD
        Precision = 18
        Size = 9
      end
      item
        Name = 'ftDate'
        DataType = ftDate
      end
      item
        Name = 'ftTime'
        DataType = ftTime
      end
      item
        Name = 'ftDateTime'
        DataType = ftDateTime
      end
      item
        Name = 'ftString'
        DataType = ftString
        Size = 1024
      end
      item
        Name = 'ftBoolean'
        DataType = ftBoolean
      end>
    StoreDefs = True
    TableName = 'test.dbf'
    TableType = ttFoxPro
    Left = 8
    Top = 8
  end
  object Query1: TQuery
    Left = 48
    Top = 8
  end
end
