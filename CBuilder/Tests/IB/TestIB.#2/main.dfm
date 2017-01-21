object MainForm: TMainForm
  Left = 192
  Top = 107
  Width = 504
  Height = 465
  Caption = 'MainForm'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object InterBaseAdminGroupBox: TGroupBox
    Left = 16
    Top = 16
    Width = 465
    Height = 179
    Caption = ' InterBase Admin '
    TabOrder = 0
    object ServerNameLabel: TLabel
      Left = 257
      Top = 20
      Width = 62
      Height = 13
      Caption = 'Server Name'
    end
    object UserNameLabel: TLabel
      Left = 257
      Top = 50
      Width = 53
      Height = 13
      Caption = 'User Name'
    end
    object PasswordLabel: TLabel
      Left = 257
      Top = 80
      Width = 46
      Height = 13
      Caption = 'Password'
    end
    object Label1: TLabel
      Left = 257
      Top = 140
      Width = 23
      Height = 13
      Caption = 'GDB'
    end
    object IBServerPropertiesGroupBox: TGroupBox
      Left = 136
      Top = 16
      Width = 107
      Height = 113
      Caption = ' IBServerProperties '
      TabOrder = 0
      object VersionButton: TButton
        Left = 16
        Top = 16
        Width = 75
        Height = 25
        Caption = 'Version'
        TabOrder = 0
        OnClick = VersionButtonClick
      end
      object LicenseButton: TButton
        Left = 16
        Top = 46
        Width = 75
        Height = 25
        Caption = 'License'
        TabOrder = 1
        OnClick = LicenseButtonClick
      end
      object LicenseMaskButton: TButton
        Left = 16
        Top = 76
        Width = 75
        Height = 25
        Caption = 'License Mask'
        TabOrder = 2
        OnClick = LicenseMaskButtonClick
      end
    end
    object IBSecurityServiceGroupBox: TGroupBox
      Left = 16
      Top = 16
      Width = 107
      Height = 147
      Caption = ' IBSecurityService '
      TabOrder = 1
      object AddUserButton: TButton
        Left = 16
        Top = 16
        Width = 75
        Height = 25
        Caption = 'Add User'
        TabOrder = 0
        OnClick = AddUserButtonClick
      end
      object ModifyUserButton: TButton
        Left = 16
        Top = 46
        Width = 75
        Height = 25
        Caption = 'Modify User'
        TabOrder = 1
        OnClick = ModifyUserButtonClick
      end
      object DeleteUserButton: TButton
        Left = 16
        Top = 76
        Width = 75
        Height = 25
        Caption = 'Delete User'
        TabOrder = 2
        OnClick = DeleteUserButtonClick
      end
      object ListUserButton: TButton
        Left = 16
        Top = 106
        Width = 75
        Height = 25
        Caption = 'List User'
        TabOrder = 3
        OnClick = ListUserButtonClick
      end
    end
    object ServerName: TEdit
      Left = 328
      Top = 16
      Width = 121
      Height = 21
      TabOrder = 2
      Text = 'localhost'
    end
    object UserName: TEdit
      Left = 328
      Top = 46
      Width = 121
      Height = 21
      TabOrder = 3
      Text = 'sysdba'
    end
    object Password: TEdit
      Left = 328
      Top = 76
      Width = 121
      Height = 21
      TabOrder = 4
      Text = 'masterkey'
    end
    object IBAPICheckBox: TCheckBox
      Left = 257
      Top = 106
      Width = 97
      Height = 17
      Alignment = taLeftJustify
      BiDiMode = bdLeftToRight
      Caption = 'By InterBase API'
      Checked = True
      ParentBiDiMode = False
      State = cbChecked
      TabOrder = 5
      OnClick = IBAPICheckBoxClick
    end
    object GDBComboBox: TComboBox
      Left = 285
      Top = 136
      Width = 164
      Height = 21
      ItemHeight = 13
      TabOrder = 6
      Text = 'localhost:E:\Soft.src\CBuilder\Tests\IB\TestIB.#1\test.gdb'
      Items.Strings = (
        'localhost:E:\Soft.src\CBuilder\Tests\IB\TestIB.#1\test.gdb'
        'begemot.insurance:/insurance/center/Node.ib6'
        'galaxy.medic.insurance:d:\ptw\ptw.gdb'
        'sasin.medic.insurance:e:\works\testbase\600\usi.ib6')
    end
  end
  object DataGroupBox: TGroupBox
    Left = 16
    Top = 201
    Width = 465
    Height = 119
    Caption = ' InterBase Data '
    TabOrder = 1
    object BranchLabel: TLabel
      Left = 257
      Top = 20
      Width = 34
      Height = 13
      Caption = 'Branch'
    end
    object MinRiskNoLabel: TLabel
      Left = 257
      Top = 50
      Width = 55
      Height = 13
      Caption = 'Min RiskNo'
    end
    object MaxRiskNoLabel: TLabel
      Left = 257
      Top = 80
      Width = 58
      Height = 13
      Caption = 'Max RiskNo'
    end
    object IBStoredProcGroupBox: TGroupBox
      Left = 16
      Top = 16
      Width = 107
      Height = 87
      Caption = ' IBStoredProc '
      TabOrder = 0
      object FindContractButton: TButton
        Left = 16
        Top = 16
        Width = 75
        Height = 25
        Caption = 'Find Contract'
        TabOrder = 0
        OnClick = FindContractButtonClick
      end
      object FindCertifButton: TButton
        Left = 16
        Top = 46
        Width = 75
        Height = 25
        Caption = 'Find Certif'
        TabOrder = 1
        OnClick = FindCertifButtonClick
      end
    end
    object IBSQLGroupBox: TGroupBox
      Left = 136
      Top = 16
      Width = 107
      Height = 87
      Caption = ' IBSQL '
      TabOrder = 1
      object DoubleSQLButton: TButton
        Left = 16
        Top = 16
        Width = 75
        Height = 25
        Caption = 'Double SQL'
        TabOrder = 0
        OnClick = DoubleSQLButtonClick
      end
      object DoubleQueryButton: TButton
        Left = 16
        Top = 46
        Width = 75
        Height = 25
        Caption = 'Double Query'
        TabOrder = 1
        OnClick = DoubleQueryButtonClick
      end
    end
    object Branch: TEdit
      Left = 328
      Top = 16
      Width = 121
      Height = 21
      TabOrder = 2
      Text = '1'
    end
    object MinRiskNo: TEdit
      Left = 328
      Top = 46
      Width = 121
      Height = 21
      TabOrder = 3
      Text = '1'
    end
    object MaxRiskNo: TEdit
      Left = 328
      Top = 76
      Width = 121
      Height = 21
      TabOrder = 4
      Text = '3'
    end
  end
  object ResultGroupBox: TGroupBox
    Left = 16
    Top = 326
    Width = 465
    Height = 105
    Caption = ' Result'
    TabOrder = 2
    object ResultMemo: TListBox
      Left = 16
      Top = 16
      Width = 433
      Height = 73
      ItemHeight = 13
      TabOrder = 0
    end
  end
end
