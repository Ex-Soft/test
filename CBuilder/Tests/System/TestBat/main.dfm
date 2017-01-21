object MainForm: TMainForm
  Left = 192
  Top = 107
  Width = 241
  Height = 427
  Caption = 'MainForm'
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
  object BatchFileName: TLabeledEdit
    Left = 11
    Top = 18
    Width = 210
    Height = 21
    EditLabel.Width = 85
    EditLabel.Height = 13
    EditLabel.Caption = 'Batch File'#39's Name'
    LabelPosition = lpAbove
    LabelSpacing = 3
    TabOrder = 0
  end
  object DoItBitBtn: TBitBtn
    Left = 79
    Top = 368
    Width = 75
    Height = 25
    TabOrder = 4
    OnClick = DoItBitBtnClick
    Kind = bkOK
  end
  object RunAs: TRadioGroup
    Left = 11
    Top = 261
    Width = 210
    Height = 42
    Caption = 'RunAs'
    Columns = 2
    ItemIndex = 0
    Items.Strings = (
      'Self'
      'By')
    TabOrder = 2
  end
  object Parameters: TGroupBox
    Left = 11
    Top = 41
    Width = 210
    Height = 217
    Caption = ' Parameters '
    TabOrder = 1
    object CountPara: TLabeledEdit
      Left = 45
      Top = 70
      Width = 121
      Height = 21
      EditLabel.Width = 28
      EditLabel.Height = 13
      EditLabel.Caption = 'Count'
      LabelPosition = lpLeft
      LabelSpacing = 3
      TabOrder = 3
      Text = '9'
    end
    object LengthPara: TLabeledEdit
      Left = 45
      Top = 90
      Width = 121
      Height = 21
      EditLabel.Width = 33
      EditLabel.Height = 13
      EditLabel.Caption = 'Length'
      LabelPosition = lpLeft
      LabelSpacing = 3
      TabOrder = 4
      Text = '15'
    end
    object DoubleQuotes: TRadioGroup
      Left = 10
      Top = 114
      Width = 190
      Height = 45
      Caption = ' Double Quotes '
      Columns = 2
      ItemIndex = 0
      Items.Strings = (
        'Inner'
        'Outer')
      TabOrder = 5
    end
    object AddAppName: TCheckBox
      Left = 10
      Top = 34
      Width = 190
      Height = 17
      Caption = 'Add Batch File Name'
      TabOrder = 1
    end
    object QuoteAppName: TCheckBox
      Left = 10
      Top = 52
      Width = 190
      Height = 17
      Caption = 'Quote Batch File Name'
      TabOrder = 2
    end
    object AddParameters: TCheckBox
      Left = 10
      Top = 16
      Width = 190
      Height = 17
      Caption = 'Add "Parameter"'
      TabOrder = 0
    end
    object TenthChar: TRadioGroup
      Left = 10
      Top = 163
      Width = 190
      Height = 45
      Caption = ' Tenth Char '
      Columns = 2
      ItemIndex = 0
      Items.Strings = (
        #39' '#39
        #39'0'#39)
      TabOrder = 6
    end
  end
  object CreateProc: TGroupBox
    Left = 11
    Top = 305
    Width = 210
    Height = 55
    Caption = ' CreateProcess '
    TabOrder = 3
    object UseAppName: TCheckBox
      Left = 10
      Top = 16
      Width = 190
      Height = 17
      Caption = 'Use Application Name'
      TabOrder = 0
    end
    object UseWorkPath: TCheckBox
      Left = 10
      Top = 34
      Width = 190
      Height = 17
      Caption = 'Use Work Path'
      TabOrder = 1
    end
  end
end
