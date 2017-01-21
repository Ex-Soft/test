object MainForm: TMainForm
  Left = 194
  Top = 107
  Width = 500
  Height = 500
  Caption = 'Test TImage'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  Position = poScreenCenter
  PixelsPerInch = 96
  TextHeight = 13
  object TestImage: TImage
    Left = 16
    Top = 16
    Width = 100
    Height = 100
  end
  object PanelLog: TPanel
    Left = 0
    Top = 273
    Width = 492
    Height = 200
    Align = alBottom
    TabOrder = 0
    object MemoLog: TMemo
      Left = 1
      Top = 1
      Width = 490
      Height = 198
      Align = alClient
      TabOrder = 0
    end
  end
  object ButtonGetInfo: TButton
    Left = 384
    Top = 16
    Width = 75
    Height = 25
    Caption = 'Get Info'
    TabOrder = 1
    OnClick = ButtonGetInfoClick
  end
  object ButtonLoadImage: TButton
    Left = 384
    Top = 58
    Width = 75
    Height = 25
    Caption = 'Load Image'
    TabOrder = 2
    OnClick = ButtonLoadImageClick
  end
  object CheckBoxAutoSize: TCheckBox
    Left = 150
    Top = 20
    Width = 97
    Height = 17
    Alignment = taLeftJustify
    Caption = 'AutoSize'
    TabOrder = 3
    OnClick = CheckBoxAutoSizeClick
  end
  object ButtonDrawGrid: TButton
    Left = 384
    Top = 100
    Width = 75
    Height = 25
    Caption = 'Draw Grid'
    TabOrder = 4
    OnClick = ButtonDrawGridClick
  end
  object GroupBoxGridSettings: TGroupBox
    Left = 150
    Top = 56
    Width = 115
    Height = 95
    Caption = ' Grid Settings '
    TabOrder = 5
    object LabelPenWidth: TLabel
      Left = 8
      Top = 20
      Width = 50
      Height = 13
      Caption = 'Pen Width'
    end
    object LabelPadding: TLabel
      Left = 8
      Top = 44
      Width = 39
      Height = 13
      Caption = 'Padding'
    end
    object LabelLength: TLabel
      Left = 8
      Top = 68
      Width = 33
      Height = 13
      Caption = 'Length'
    end
    object EditPenWidth: TEdit
      Left = 80
      Top = 16
      Width = 20
      Height = 21
      TabOrder = 0
      Text = '1'
    end
    object EditPadding: TEdit
      Left = 80
      Top = 40
      Width = 20
      Height = 21
      TabOrder = 1
      Text = '3'
    end
    object EditLength: TEdit
      Left = 80
      Top = 64
      Width = 20
      Height = 21
      TabOrder = 2
      Text = '0'
    end
  end
  object ButtonClear: TButton
    Left = 384
    Top = 142
    Width = 75
    Height = 25
    Caption = 'Clear'
    TabOrder = 6
    OnClick = ButtonClearClick
  end
  object ButtonDoIt: TButton
    Left = 384
    Top = 184
    Width = 75
    Height = 25
    Caption = 'DoIt!'
    TabOrder = 7
    OnClick = ButtonDoItClick
  end
end
