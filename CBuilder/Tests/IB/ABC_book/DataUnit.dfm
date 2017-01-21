object DataBase: TDataBase
  OldCreateOrder = False
  OnCreate = DataModuleCreate
  OnDestroy = DataModuleDestroy
  Left = 193
  Top = 107
  Height = 321
  Width = 421
  object IBDatabase: TIBDatabase
    SQLDialect = 1
    AfterConnect = IBDatabaseAfterConnect
    AfterDisconnect = IBDatabaseAfterDisconnect
    BeforeConnect = IBDatabaseBeforeConnect
    BeforeDisconnect = IBDatabaseBeforeDisconnect
    OnLogin = IBDatabaseLogin
    OnIdleTimer = IBDatabaseIdleTimer
    OnDialectDowngradeWarning = IBDatabaseDialectDowngradeWarning
    Left = 88
    Top = 8
  end
  object IBTransactionRead: TIBTransaction
    OnIdleTimer = IBTransactionReadIdleTimer
    Left = 40
    Top = 64
  end
  object IBTransactionWrite: TIBTransaction
    OnIdleTimer = IBTransactionReadIdleTimer
    Left = 136
    Top = 64
  end
  object IBTableInsurant: TIBTable
    AfterCancel = IBTableInsurantAfterCancel
    AfterClose = IBTableInsurantAfterClose
    AfterDelete = IBTableInsurantAfterDelete
    AfterEdit = IBTableInsurantAfterEdit
    AfterInsert = IBTableInsurantAfterInsert
    AfterOpen = IBTableInsurantAfterOpen
    AfterPost = IBTableInsurantAfterPost
    AfterRefresh = IBTableInsurantAfterRefresh
    AfterScroll = IBTableInsurantAfterScroll
    BeforeCancel = IBTableInsurantBeforeCancel
    BeforeClose = IBTableInsurantBeforeClose
    BeforeDelete = IBTableInsurantBeforeDelete
    BeforeEdit = IBTableInsurantBeforeEdit
    BeforeInsert = IBTableInsurantBeforeInsert
    BeforeOpen = IBTableInsurantBeforeOpen
    BeforePost = IBTableInsurantBeforePost
    BeforeRefresh = IBTableInsurantBeforeRefresh
    BeforeScroll = IBTableInsurantBeforeScroll
    OnCalcFields = IBTableInsurantCalcFields
    OnDeleteError = IBTableInsurantDeleteError
    OnEditError = IBTableInsurantEditError
    OnNewRecord = IBTableInsurantNewRecord
    OnPostError = IBTableInsurantPostError
    OnUpdateError = IBTableInsurantUpdateError
    OnUpdateRecord = IBTableInsurantUpdateRecord
    BeforeDatabaseDisconnect = IBTableInsurantBeforeDatabaseDisconnect
    AfterDatabaseDisconnect = IBTableInsurantAfterDatabaseDisconnect
    DatabaseFree = IBTableInsurantDatabaseFree
    BeforeTransactionEnd = IBTableInsurantBeforeTransactionEnd
    AfterTransactionEnd = IBTableInsurantAfterTransactionEnd
    TransactionFree = IBTableInsurantTransactionFree
    OnFilterRecord = IBTableInsurantFilterRecord
    Left = 40
    Top = 128
  end
  object IBDataSetInsurant: TIBDataSet
    AfterCancel = IBDataSetInsurantAfterCancel
    AfterClose = IBDataSetInsurantAfterClose
    AfterDelete = IBDataSetInsurantAfterDelete
    AfterEdit = IBDataSetInsurantAfterEdit
    AfterInsert = IBDataSetInsurantAfterInsert
    AfterOpen = IBDataSetInsurantAfterOpen
    AfterPost = IBDataSetInsurantAfterPost
    AfterRefresh = IBDataSetInsurantAfterRefresh
    AfterScroll = IBDataSetInsurantAfterScroll
    BeforeCancel = IBDataSetInsurantBeforeCancel
    BeforeClose = IBDataSetInsurantBeforeClose
    BeforeDelete = IBDataSetInsurantBeforeDelete
    BeforeEdit = IBDataSetInsurantBeforeEdit
    BeforeInsert = IBDataSetInsurantBeforeInsert
    BeforeOpen = IBDataSetInsurantBeforeOpen
    BeforePost = IBDataSetInsurantBeforePost
    BeforeRefresh = IBDataSetInsurantBeforeRefresh
    BeforeScroll = IBDataSetInsurantBeforeScroll
    OnCalcFields = IBDataSetInsurantCalcFields
    OnDeleteError = IBDataSetInsurantDeleteError
    OnEditError = IBDataSetInsurantEditError
    OnNewRecord = IBDataSetInsurantNewRecord
    OnPostError = IBDataSetInsurantPostError
    OnUpdateError = IBDataSetInsurantUpdateError
    OnUpdateRecord = IBDataSetInsurantUpdateRecord
    BeforeDatabaseDisconnect = IBDataSetInsurantBeforeDatabaseDisconnect
    AfterDatabaseDisconnect = IBDataSetInsurantAfterDatabaseDisconnect
    DatabaseFree = IBDataSetInsurantDatabaseFree
    BeforeTransactionEnd = IBDataSetInsurantBeforeTransactionEnd
    AfterTransactionEnd = IBDataSetInsurantAfterTransactionEnd
    TransactionFree = IBDataSetInsurantTransactionFree
    OnFilterRecord = IBDataSetInsurantFilterRecord
    Left = 240
    Top = 128
  end
  object IBTableJuridPerson: TIBTable
    Left = 40
    Top = 176
  end
  object IBTableNaturPerson: TIBTable
    Left = 40
    Top = 232
  end
  object IBQueryNaturPerson: TIBQuery
    Left = 152
    Top = 232
  end
  object IBQueryJuridPerson: TIBQuery
    Left = 152
    Top = 176
  end
  object IBQueryInsurant: TIBQuery
    Left = 152
    Top = 128
  end
  object IBSQLMonitor: TIBSQLMonitor
    OnSQL = IBSQLMonitorSQL
    TraceFlags = [tfQPrepare, tfQExecute, tfQFetch, tfError, tfStmt, tfConnect, tfTransact, tfBlob, tfService, tfMisc]
    Left = 224
    Top = 8
  end
  object DataSourceInsurant: TDataSource
    OnStateChange = DataSourceInsurantStateChange
    OnDataChange = DataSourceInsurantDataChange
    OnUpdateData = DataSourceInsurantUpdateData
    Left = 336
    Top = 128
  end
  object DataSourceJuridPerson: TDataSource
    OnStateChange = DataSourceInsurantStateChange
    OnDataChange = DataSourceInsurantDataChange
    OnUpdateData = DataSourceInsurantUpdateData
    Left = 336
    Top = 184
  end
  object DataSourceNaturPerson: TDataSource
    OnStateChange = DataSourceInsurantStateChange
    OnDataChange = DataSourceInsurantDataChange
    OnUpdateData = DataSourceInsurantUpdateData
    Left = 336
    Top = 240
  end
  object IBSQLInsurant: TIBSQL
    Left = 336
    Top = 64
  end
end
