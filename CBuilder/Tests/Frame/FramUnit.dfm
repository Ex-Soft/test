object LabelFrame: TLabelFrame
  Left = 0
  Top = 0
  Width = 200
  Height = 156
  TabOrder = 0
  object GroupBox1: TGroupBox
    Left = 7
    Top = 8
    Width = 185
    Height = 139
    Caption = ' Frame '
    TabOrder = 0
    object Label1: TLabel
      Left = 18
      Top = 16
      Width = 150
      Height = 13
      Alignment = taCenter
      AutoSize = False
    end
    object SetupButton: TButton
      Left = 55
      Top = 40
      Width = 75
      Height = 25
      Caption = 'Setup'
      TabOrder = 0
      OnClick = SetupButtonClick
    end
    object IncButton: TButton
      Left = 55
      Top = 70
      Width = 75
      Height = 25
      Caption = 'Inc'
      TabOrder = 1
      OnClick = IncButtonClick
    end
    object ShowButton: TButton
      Left = 55
      Top = 100
      Width = 75
      Height = 25
      Caption = 'Show'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 2
      OnClick = ShowButtonClick
    end
  end
end
