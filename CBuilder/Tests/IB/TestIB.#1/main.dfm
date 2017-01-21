object MainForm: TMainForm
  Left = 221
  Top = 107
  Width = 415
  Height = 450
  Caption = 'Test InterBase'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  Position = poScreenCenter
  Scaled = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object PageControl: TPageControl
    Left = 0
    Top = 0
    Width = 407
    Height = 423
    ActivePage = IBDatabaseInfoTabSheet
    Align = alClient
    MultiLine = True
    TabIndex = 1
    TabOrder = 0
    object DatabaseTabSheet: TTabSheet
      Caption = 'Database'
      object DatabaseGroupBox: TGroupBox
        Left = 5
        Top = 6
        Width = 345
        Height = 195
        Caption = ' Database '
        TabOrder = 0
        object Label1: TLabel
          Left = 6
          Top = 20
          Width = 31
          Height = 13
          Caption = 'Server'
        end
        object Label2: TLabel
          Left = 6
          Top = 40
          Width = 46
          Height = 13
          Caption = 'Database'
        end
        object Label3: TLabel
          Left = 6
          Top = 94
          Width = 53
          Height = 13
          Caption = 'Parameters'
        end
        object ServerEdit: TEdit
          Left = 84
          Top = 16
          Width = 250
          Height = 21
          TabOrder = 0
          Text = 'localhost'
        end
        object DataBaseEdit: TEdit
          Left = 84
          Top = 36
          Width = 250
          Height = 21
          TabOrder = 1
          Text = 'D:\My_Doc\CBuilder\TestIB.#1\Test.gdb'
        end
        object DataBaseMemo: TMemo
          Left = 84
          Top = 56
          Width = 250
          Height = 89
          Lines.Strings = (
            'user_name=sysdba'
            'password=masterkey'
            'lc_ctype=WIN1251')
          TabOrder = 2
        end
        object OpenButton: TButton
          Left = 89
          Top = 154
          Width = 75
          Height = 25
          Caption = 'Open'
          TabOrder = 3
          OnClick = OpenButtonClick
        end
        object CloseButton: TButton
          Left = 182
          Top = 154
          Width = 75
          Height = 25
          Caption = 'Close'
          Enabled = False
          TabOrder = 4
          OnClick = CloseButtonClick
        end
      end
    end
    object IBDatabaseInfoTabSheet: TTabSheet
      Caption = 'Database Info'
      ImageIndex = 3
      object DatabaseInfoGroupBox: TGroupBox
        Left = 6
        Top = 6
        Width = 345
        Height = 367
        Caption = ' Database Info '
        TabOrder = 0
        object Label10: TLabel
          Left = 8
          Top = 64
          Width = 99
          Height = 13
          Caption = 'Extract Object Types'
        end
        object Label11: TLabel
          Left = 40
          Top = 113
          Width = 60
          Height = 13
          Caption = 'Extract Type'
        end
        object DBFileName: TLabeledEdit
          Left = 81
          Top = 37
          Width = 121
          Height = 21
          EditLabel.Width = 65
          EditLabel.Height = 13
          EditLabel.Caption = 'DB File Name'
          LabelPosition = lpLeft
          LabelSpacing = 10
          TabOrder = 0
        end
        object DBSQLDialect: TLabeledEdit
          Left = 308
          Top = 37
          Width = 25
          Height = 21
          EditLabel.Width = 75
          EditLabel.Height = 13
          EditLabel.Caption = 'DB SQL Dialect'
          LabelPosition = lpLeft
          LabelSpacing = 10
          TabOrder = 1
        end
        object GetIBDatabaseInfoButton: TButton
          Left = 98
          Top = 334
          Width = 150
          Height = 25
          Caption = 'Get Database Info'
          Enabled = False
          TabOrder = 2
          OnClick = GetIBDatabaseInfoButtonClick
        end
        object IBExtractMemo: TMemo
          Left = 8
          Top = 133
          Width = 329
          Height = 195
          ScrollBars = ssVertical
          TabOrder = 3
        end
        object ExtractObjectTypesComboBox: TComboBox
          Left = 115
          Top = 61
          Width = 145
          Height = 21
          Style = csDropDownList
          ItemHeight = 13
          ItemIndex = 0
          TabOrder = 4
          Text = 'eoDatabase'
          Items.Strings = (
            'eoDatabase'
            'eoDomain'
            'eoTable'
            'eoView'
            'eoProcedure'
            'eoFunction'
            'eoGenerator'
            'eoException'
            'eoBLOBFilter'
            'eoRole'
            'eoTrigger'
            'eoForeign'
            'eoIndexes'
            'eoChecks'
            'eoData')
        end
        object ExtractTypeComboBox: TComboBox
          Left = 115
          Top = 109
          Width = 145
          Height = 21
          Style = csDropDownList
          ItemHeight = 13
          ItemIndex = 0
          TabOrder = 5
          Text = 'All'
          Items.Strings = (
            'All'
            'etDomain'
            'etTable'
            'etRole'
            'etTrigger'
            'etForeign'
            'etIndex'
            'etData'
            'etGrant'
            'etCheck'
            'etAlterProc')
        end
        object ObjectNameLabeledEdit: TLabeledEdit
          Left = 115
          Top = 85
          Width = 145
          Height = 21
          EditLabel.Width = 62
          EditLabel.Height = 13
          EditLabel.Caption = 'Object Name'
          LabelPosition = lpLeft
          LabelSpacing = 10
          TabOrder = 6
        end
        object ServerVersion: TLabeledEdit
          Left = 81
          Top = 16
          Width = 252
          Height = 21
          EditLabel.Width = 69
          EditLabel.Height = 13
          EditLabel.Caption = 'Server Version'
          LabelPosition = lpLeft
          LabelSpacing = 10
          TabOrder = 7
        end
      end
    end
    object Transaction1TabSheet: TTabSheet
      Caption = 'Transaction #1'
      ImageIndex = 1
      object GroupBox1: TGroupBox
        Left = 6
        Top = 6
        Width = 345
        Height = 365
        Caption = ' #1 '
        TabOrder = 0
        object Label5: TLabel
          Left = 162
          Top = 109
          Width = 21
          Height = 13
          Caption = 'SQL'
        end
        object Label6: TLabel
          Left = 236
          Top = 189
          Width = 30
          Height = 13
          Caption = 'Result'
        end
        object StartButton1: TButton
          Tag = 1
          Left = 17
          Top = 160
          Width = 153
          Height = 25
          Caption = 'Start'
          Enabled = False
          TabOrder = 2
          OnClick = StartButton1Click
        end
        object CommitButton1: TButton
          Tag = 1
          Left = 17
          Top = 185
          Width = 153
          Height = 25
          Caption = 'Commit'
          Enabled = False
          TabOrder = 3
          OnClick = CommitButton1Click
        end
        object RollbackButton1: TButton
          Tag = 1
          Left = 17
          Top = 210
          Width = 153
          Height = 25
          Caption = 'Rollback'
          Enabled = False
          TabOrder = 4
          OnClick = RollbackButton1Click
        end
        object ExecButton1: TButton
          Tag = 1
          Left = 175
          Top = 160
          Width = 153
          Height = 25
          Caption = 'Exec'
          Enabled = False
          TabOrder = 5
          OnClick = ExecButton1Click
        end
        object SQLComboBox1: TComboBox
          Left = 8
          Top = 133
          Width = 328
          Height = 21
          ItemHeight = 13
          TabOrder = 1
          Text = 'update "Test" set "TestValue"='#39'#1'#39' where "TestId"=1'
          Items.Strings = (
            'update "Test" set "TestValue"='#39'#1'#39' where "TestId"=1'
            'select "TestValue" from "Test" where "TestId"=1')
        end
        object ResultEdit1: TEdit
          Left = 191
          Top = 210
          Width = 121
          Height = 21
          TabOrder = 6
        end
        object Transaction1GroupBox: TGroupBox
          Left = 8
          Top = 16
          Width = 328
          Height = 113
          Caption = ' Transaction '
          TabOrder = 0
          object Label4: TLabel
            Left = 66
            Top = 16
            Width = 35
            Height = 13
            Caption = 'Params'
          end
          object TransactionMemo1: TMemo
            Left = 8
            Top = 32
            Width = 150
            Height = 73
            Lines.Strings = (
              'nowait'
              'consistency'
              'lock_write=Test'
              'exclusive')
            TabOrder = 0
          end
          object TPBListBox1: TListBox
            Left = 170
            Top = 47
            Width = 150
            Height = 58
            ItemHeight = 13
            TabOrder = 2
          end
          object ShowTPBButton1: TButton
            Tag = 1
            Left = 208
            Top = 16
            Width = 75
            Height = 25
            Caption = 'Show TPB'
            Enabled = False
            TabOrder = 1
            OnClick = ShowTPBButton1Click
          end
        end
        object MemoPlan1: TMemo
          Left = 8
          Top = 265
          Width = 326
          Height = 90
          ScrollBars = ssVertical
          TabOrder = 7
        end
        object CheckBoxFetchAll1: TCheckBox
          Left = 45
          Top = 240
          Width = 97
          Height = 17
          Caption = 'FetchAll'
          TabOrder = 8
        end
      end
    end
    object Transaction2TabSheet: TTabSheet
      Caption = 'Transaction #2'
      ImageIndex = 2
      object GroupBox2: TGroupBox
        Left = 6
        Top = 6
        Width = 345
        Height = 365
        Caption = ' #2 '
        TabOrder = 0
        object Label8: TLabel
          Left = 162
          Top = 109
          Width = 21
          Height = 13
          Caption = 'SQL'
        end
        object Label9: TLabel
          Left = 236
          Top = 189
          Width = 30
          Height = 13
          Caption = 'Result'
        end
        object StartButton2: TButton
          Tag = 2
          Left = 17
          Top = 160
          Width = 153
          Height = 25
          Caption = 'Start'
          Enabled = False
          TabOrder = 2
          OnClick = StartButton1Click
        end
        object CommitButton2: TButton
          Tag = 2
          Left = 17
          Top = 185
          Width = 153
          Height = 25
          Caption = 'Commit'
          Enabled = False
          TabOrder = 3
          OnClick = CommitButton1Click
        end
        object RollbackButton2: TButton
          Tag = 2
          Left = 17
          Top = 210
          Width = 153
          Height = 25
          Caption = 'Rollback'
          Enabled = False
          TabOrder = 4
          OnClick = RollbackButton1Click
        end
        object ExecButton2: TButton
          Tag = 2
          Left = 175
          Top = 160
          Width = 153
          Height = 25
          Caption = 'Exec'
          Enabled = False
          TabOrder = 5
          OnClick = ExecButton1Click
        end
        object SQLComboBox2: TComboBox
          Left = 8
          Top = 133
          Width = 328
          Height = 21
          ItemHeight = 13
          TabOrder = 1
          Text = 'update "Test" set "TestValue"='#39'#2'#39' where "TestId"=1'
          Items.Strings = (
            'update "Test" set "TestValue"='#39'#2'#39' where "TestId"=1'
            'select "TestValue" from "Test" where "TestId"=1')
        end
        object ResultEdit2: TEdit
          Left = 191
          Top = 210
          Width = 121
          Height = 21
          TabOrder = 6
        end
        object Transaction2GroupBox: TGroupBox
          Left = 8
          Top = 16
          Width = 328
          Height = 113
          Caption = ' Transaction '
          TabOrder = 0
          object Label7: TLabel
            Left = 66
            Top = 16
            Width = 35
            Height = 13
            Caption = 'Params'
          end
          object TransactionMemo2: TMemo
            Left = 8
            Top = 32
            Width = 150
            Height = 73
            Lines.Strings = (
              'nowait'
              'read_committed'
              'rec_version')
            TabOrder = 0
          end
          object TPBListBox2: TListBox
            Left = 170
            Top = 47
            Width = 150
            Height = 58
            ItemHeight = 13
            TabOrder = 2
          end
          object ShowTPBButton2: TButton
            Tag = 2
            Left = 208
            Top = 16
            Width = 75
            Height = 25
            Caption = 'Show TPB'
            Enabled = False
            TabOrder = 1
            OnClick = ShowTPBButton1Click
          end
        end
        object MemoPlan2: TMemo
          Left = 8
          Top = 265
          Width = 326
          Height = 90
          ScrollBars = ssVertical
          TabOrder = 7
        end
        object CheckBoxFetchAll2: TCheckBox
          Left = 45
          Top = 240
          Width = 97
          Height = 17
          Caption = 'FetchAll'
          TabOrder = 8
        end
      end
    end
    object StoredProcTabSheet: TTabSheet
      Caption = 'Stored Procedure'
      ImageIndex = 4
      object GroupBox3: TGroupBox
        Left = 8
        Top = 8
        Width = 347
        Height = 166
        Caption = ' Stored Procedures '
        TabOrder = 0
        object GroupBox4: TGroupBox
          Left = 12
          Top = 16
          Width = 150
          Height = 137
          Caption = ' SP #1 '
          TabOrder = 0
          object SP1Arg1: TLabeledEdit
            Left = 53
            Top = 16
            Width = 80
            Height = 21
            EditLabel.Width = 32
            EditLabel.Height = 13
            EditLabel.Caption = 'Arg #1'
            LabelPosition = lpLeft
            LabelSpacing = 3
            TabOrder = 0
          end
          object SP1Arg2: TLabeledEdit
            Left = 53
            Top = 40
            Width = 80
            Height = 21
            EditLabel.Width = 32
            EditLabel.Height = 13
            EditLabel.Caption = 'Arg #2'
            LabelPosition = lpLeft
            LabelSpacing = 3
            TabOrder = 1
          end
          object ExecSP1Button: TButton
            Left = 25
            Top = 70
            Width = 100
            Height = 25
            Caption = 'Exec SP #1'
            Enabled = False
            TabOrder = 2
            OnClick = ExecSP1ButtonClick
          end
          object SP1Result: TLabeledEdit
            Left = 53
            Top = 105
            Width = 80
            Height = 21
            EditLabel.Width = 30
            EditLabel.Height = 13
            EditLabel.Caption = 'Result'
            LabelPosition = lpLeft
            LabelSpacing = 3
            TabOrder = 3
          end
        end
        object GroupBox5: TGroupBox
          Left = 184
          Top = 16
          Width = 150
          Height = 137
          Caption = ' SP #2'
          TabOrder = 1
          object SP2Arg1: TLabeledEdit
            Left = 53
            Top = 16
            Width = 80
            Height = 21
            EditLabel.Width = 32
            EditLabel.Height = 13
            EditLabel.Caption = 'Arg #1'
            LabelPosition = lpLeft
            LabelSpacing = 3
            TabOrder = 0
          end
          object ExecSP2Button: TButton
            Left = 25
            Top = 70
            Width = 100
            Height = 25
            Caption = 'Exec SP #2'
            Enabled = False
            TabOrder = 1
            OnClick = ExecSP2ButtonClick
          end
          object SP2Result: TLabeledEdit
            Left = 53
            Top = 105
            Width = 80
            Height = 21
            EditLabel.Width = 30
            EditLabel.Height = 13
            EditLabel.Caption = 'Result'
            LabelPosition = lpLeft
            LabelSpacing = 3
            TabOrder = 2
          end
        end
      end
    end
    object PrimaryKeyTabSheet: TTabSheet
      Caption = 'Primary Key'
      ImageIndex = 5
      object GroupBox6: TGroupBox
        Left = 8
        Top = 8
        Width = 367
        Height = 238
        Caption = ' Primary Keys'
        TabOrder = 0
        object Centre: TLabeledEdit
          Left = 65
          Top = 16
          Width = 121
          Height = 21
          EditLabel.Width = 31
          EditLabel.Height = 13
          EditLabel.Caption = 'Centre'
          LabelPosition = lpLeft
          LabelSpacing = 3
          TabOrder = 0
          Text = '1'
        end
        object Institution: TLabeledEdit
          Left = 65
          Top = 40
          Width = 121
          Height = 21
          EditLabel.Width = 45
          EditLabel.Height = 13
          EditLabel.Caption = 'Institution'
          LabelPosition = lpLeft
          LabelSpacing = 3
          TabOrder = 1
          Text = '1'
        end
        object Node: TLabeledEdit
          Left = 65
          Top = 64
          Width = 121
          Height = 21
          EditLabel.Width = 26
          EditLabel.Height = 13
          EditLabel.Caption = 'Node'
          LabelPosition = lpLeft
          LabelSpacing = 3
          TabOrder = 2
          Text = '5'
        end
        object Year: TLabeledEdit
          Left = 65
          Top = 88
          Width = 121
          Height = 21
          EditLabel.Width = 22
          EditLabel.Height = 13
          EditLabel.Caption = 'Year'
          LabelPosition = lpLeft
          LabelSpacing = 3
          TabOrder = 3
          Text = '5'
        end
        object Kind: TLabeledEdit
          Left = 65
          Top = 112
          Width = 121
          Height = 21
          EditLabel.Width = 21
          EditLabel.Height = 13
          EditLabel.Caption = 'Kind'
          LabelPosition = lpLeft
          LabelSpacing = 3
          TabOrder = 4
          Text = '5'
        end
        object Branch: TLabeledEdit
          Left = 65
          Top = 136
          Width = 121
          Height = 21
          EditLabel.Width = 34
          EditLabel.Height = 13
          EditLabel.Caption = 'Branch'
          LabelPosition = lpLeft
          LabelSpacing = 3
          TabOrder = 5
          Text = '5'
        end
        object ContrNo: TLabeledEdit
          Left = 65
          Top = 158
          Width = 121
          Height = 21
          EditLabel.Width = 39
          EditLabel.Height = 13
          EditLabel.Caption = 'ContrNo'
          LabelPosition = lpLeft
          LabelSpacing = 3
          TabOrder = 6
          Text = '5'
        end
        object CertNo: TLabeledEdit
          Left = 65
          Top = 182
          Width = 121
          Height = 21
          EditLabel.Width = 33
          EditLabel.Height = 13
          EditLabel.Caption = 'CertNo'
          LabelPosition = lpLeft
          LabelSpacing = 3
          TabOrder = 7
          Text = '5'
        end
        object Diff: TLabeledEdit
          Left = 65
          Top = 206
          Width = 121
          Height = 21
          EditLabel.Width = 39
          EditLabel.Height = 13
          EditLabel.Caption = 'DiffTime'
          LabelPosition = lpLeft
          LabelSpacing = 3
          TabOrder = 8
        end
        object FillTableCertifErsatz: TButton
          Left = 200
          Top = 16
          Width = 150
          Height = 25
          Caption = 'Fill Table "CertifErsatz"'
          Enabled = False
          TabOrder = 9
          OnClick = FillTableCertifErsatzClick
        end
        object FillTableCertifHash: TButton
          Left = 200
          Top = 41
          Width = 150
          Height = 25
          Caption = 'Fill Table "CertifHash"'
          Enabled = False
          TabOrder = 10
          OnClick = FillTableCertifHashClick
        end
        object SelectFromCertifErsatz: TButton
          Left = 200
          Top = 91
          Width = 150
          Height = 25
          Caption = 'Select From "CertifErsatz"'
          Enabled = False
          TabOrder = 11
          OnClick = SelectFromCertifErsatzClick
        end
        object SelectFromCertifHash: TButton
          Left = 200
          Top = 116
          Width = 150
          Height = 25
          Caption = 'Select From "CertifHash"'
          Enabled = False
          TabOrder = 12
          OnClick = SelectFromCertifHashClick
        end
      end
    end
    object DatatypesTabSheet: TTabSheet
      Caption = 'Datatypes'
      ImageIndex = 6
      object GroupBox7: TGroupBox
        Left = 8
        Top = 8
        Width = 385
        Height = 278
        Caption = ' Datatypes '
        TabOrder = 0
        object ReadDatatypes: TRadioGroup
          Left = 16
          Top = 16
          Width = 185
          Height = 35
          Caption = ' Read Datatypes by '
          Columns = 3
          ItemIndex = 0
          Items.Strings = (
            'IBTable'
            'IBQuery'
            'IBSQL')
          TabOrder = 0
          OnClick = ReadDatatypesClick
        end
        object DoReadDatatypesButton: TButton
          Left = 220
          Top = 23
          Width = 150
          Height = 25
          Caption = 'Read Datatypes'
          Enabled = False
          TabOrder = 1
          OnClick = DoReadDatatypesButtonClick
        end
        object ListView: TListView
          Left = 16
          Top = 60
          Width = 354
          Height = 206
          Columns = <
            item
              Caption = 'Name'
              Width = 120
            end
            item
              Caption = 'Datatype'
              Width = 110
            end
            item
              Caption = 'Precision'
              Width = 60
            end
            item
              Caption = 'Size'
              Width = 40
            end>
          RowSelect = True
          TabOrder = 2
          ViewStyle = vsReport
        end
      end
      object GroupBox8: TGroupBox
        Left = 8
        Top = 291
        Width = 385
        Height = 82
        Caption = ' Value '
        TabOrder = 1
        object Label13: TLabel
          Left = 132
          Top = 38
          Width = 12
          Height = 13
          Caption = 'As'
        end
        object ColumnNameComboBox: TComboBox
          Left = 8
          Top = 34
          Width = 120
          Height = 21
          Style = csDropDownList
          ItemHeight = 0
          TabOrder = 0
        end
        object AsTypeComboBox: TComboBox
          Left = 148
          Top = 34
          Width = 110
          Height = 21
          Style = csDropDownList
          ItemHeight = 0
          TabOrder = 1
        end
        object ValueEdit: TEdit
          Left = 286
          Top = 34
          Width = 91
          Height = 21
          TabOrder = 4
        end
        object GetValueButton: TButton
          Left = 264
          Top = 48
          Width = 15
          Height = 25
          Caption = '->'
          Enabled = False
          TabOrder = 3
          OnClick = GetValueButtonClick
        end
        object SetValueButton: TButton
          Left = 264
          Top = 16
          Width = 15
          Height = 25
          Caption = '<-'
          Enabled = False
          TabOrder = 2
          OnClick = SetValueButtonClick
        end
      end
    end
    object TabSheetAdditional: TTabSheet
      Caption = 'Additional'
      ImageIndex = 7
      object GroupBoxIBDatabaseINI: TGroupBox
        Left = 8
        Top = 8
        Width = 185
        Height = 80
        Caption = ' IBDatabaseINI '
        TabOrder = 0
        object IBDatabaseINIButton: TButton
          Left = 17
          Top = 50
          Width = 150
          Height = 25
          Caption = 'IBDatabaseINI'
          TabOrder = 0
          OnClick = IBDatabaseINIButtonClick
        end
        object RadioGroupIBDatabaseINIAction: TRadioGroup
          Left = 16
          Top = 16
          Width = 154
          Height = 32
          Caption = ' Action '
          Columns = 2
          ItemIndex = 1
          Items.Strings = (
            'Read'
            'Write')
          TabOrder = 1
        end
      end
      object GroupBoxIBScript: TGroupBox
        Left = 8
        Top = 96
        Width = 185
        Height = 105
        Caption = ' IBScript '
        TabOrder = 1
        object IBScriptButton: TButton
          Left = 17
          Top = 50
          Width = 150
          Height = 25
          Caption = 'IBScript'
          TabOrder = 0
          OnClick = IBScriptButtonClick
        end
      end
      object IBSQLParserGroupBox: TGroupBox
        Left = 8
        Top = 208
        Width = 185
        Height = 105
        Caption = ' IBSQLParser '
        TabOrder = 2
        object IBSQLParserButton: TButton
          Left = 17
          Top = 50
          Width = 150
          Height = 25
          Caption = 'IBSQLParser'
          TabOrder = 0
          OnClick = IBSQLParserButtonClick
        end
      end
    end
  end
end
