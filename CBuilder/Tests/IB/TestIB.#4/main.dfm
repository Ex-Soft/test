object MainForm: TMainForm
  Left = 192
  Top = 107
  Width = 544
  Height = 375
  Caption = 'InterBase Test'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  Position = poScreenCenter
  Scaled = False
  PixelsPerInch = 96
  TextHeight = 13
  object ServerNameLabel: TLabel
    Left = 16
    Top = 20
    Width = 62
    Height = 13
    Caption = 'Server Name'
  end
  object UserNameLabel: TLabel
    Left = 16
    Top = 44
    Width = 53
    Height = 13
    Caption = 'User Name'
  end
  object UserPasswordLabel: TLabel
    Left = 16
    Top = 68
    Width = 71
    Height = 13
    Caption = 'User Password'
  end
  object DataBaseNameLabel: TLabel
    Left = 16
    Top = 92
    Width = 77
    Height = 13
    Caption = 'Database Name'
  end
  object FullDataBaseNameLabel: TLabel
    Left = 16
    Top = 116
    Width = 96
    Height = 13
    Caption = 'Full Database Name'
  end
  object ResultLabel: TLabel
    Left = 16
    Top = 140
    Width = 30
    Height = 13
    Caption = 'Result'
  end
  object ServerName: TEdit
    Left = 120
    Top = 16
    Width = 121
    Height = 21
    TabOrder = 0
    Text = 'USI-GW'
  end
  object UserName: TEdit
    Left = 120
    Top = 40
    Width = 121
    Height = 21
    TabOrder = 1
    Text = 'sysdba'
  end
  object UserPassword: TEdit
    Left = 120
    Top = 64
    Width = 121
    Height = 21
    PasswordChar = '*'
    TabOrder = 2
    Text = 'masterkey'
  end
  object ServerExistsButton: TButton
    Left = 264
    Top = 16
    Width = 250
    Height = 25
    Caption = 'Test ServerExists()'
    TabOrder = 3
    OnClick = ServerExistsButtonClick
  end
  object TestServerVersionButton: TButton
    Left = 264
    Top = 40
    Width = 250
    Height = 25
    Caption = 'Test ServerVersion()'
    TabOrder = 4
    OnClick = TestServerVersionButtonClick
  end
  object TestUserExistButton: TButton
    Left = 264
    Top = 64
    Width = 250
    Height = 25
    Caption = 'Test UserExists()'
    TabOrder = 5
    OnClick = UserExistsButtonClick
  end
  object TestAddUserButton: TButton
    Left = 264
    Top = 88
    Width = 250
    Height = 25
    Caption = 'Test AddUser()'
    TabOrder = 6
    OnClick = TestAddUserButtonClick
  end
  object TestSplitIBDatabaseNameButton: TButton
    Left = 264
    Top = 112
    Width = 250
    Height = 25
    Caption = 'Test SplitIBDatabaseName()'
    TabOrder = 7
    OnClick = TestSplitIBDatabaseNameButtonClick
  end
  object TestTCPIP2DNSButton: TButton
    Left = 264
    Top = 136
    Width = 250
    Height = 25
    Caption = 'Test TCPIP2DNS()'
    TabOrder = 8
    OnClick = TestTCPIP2DNSButtonClick
  end
  object TestDNS2TCPIPButton: TButton
    Left = 264
    Top = 160
    Width = 250
    Height = 25
    Caption = 'Test DNS2TCPIP()'
    TabOrder = 9
    OnClick = TestDNS2TCPIPButtonClick
  end
  object TestIsLocalPathButton: TButton
    Left = 264
    Top = 184
    Width = 250
    Height = 25
    Caption = 'Test IsLocalPath()'
    TabOrder = 10
    OnClick = TestIsLocalPathButtonClick
  end
  object TestIsDNSPathButton: TButton
    Left = 264
    Top = 208
    Width = 250
    Height = 25
    Caption = 'Test IsDNSPath()'
    TabOrder = 11
    OnClick = TestIsDNSPathButtonClick
  end
  object DataBaseName: TEdit
    Left = 120
    Top = 88
    Width = 121
    Height = 21
    TabOrder = 12
  end
  object FullDataBaseName: TEdit
    Left = 120
    Top = 112
    Width = 121
    Height = 21
    TabOrder = 13
  end
  object Result: TEdit
    Left = 120
    Top = 136
    Width = 121
    Height = 21
    TabOrder = 14
  end
end
