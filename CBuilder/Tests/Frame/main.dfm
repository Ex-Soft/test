object MainForm: TMainForm
  Left = 296
  Top = 80
  Width = 449
  Height = 483
  Caption = 'Main Form'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  Position = poScreenCenter
  Scaled = False
  OnClose = FormClose
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 46
    Top = 8
    Width = 350
    Height = 13
    Alignment = taCenter
    AutoSize = False
  end
  inline LabelFrame11: TLabelFrame
    Left = 14
    Top = 40
    Width = 200
    Height = 156
    TabOrder = 0
    inherited GroupBox1: TGroupBox
      inherited SetupButton: TButton
        Font.Style = [fsBold]
        ParentFont = False
      end
    end
  end
  inline LabelFrame12: TLabelFrame
    Left = 228
    Top = 40
    Width = 200
    Height = 156
    TabOrder = 1
    inherited GroupBox1: TGroupBox
      inherited IncButton: TButton
        Font.Style = [fsBold]
        ParentFont = False
      end
    end
  end
  object ShowButton: TButton
    Left = 183
    Top = 208
    Width = 75
    Height = 25
    Caption = 'Show'
    TabOrder = 2
    OnClick = ShowButtonClick
  end
  inline Frame11: TOpenFileFrame
    Left = 60
    Top = 248
    Width = 320
    Height = 68
    TabOrder = 3
    inherited GroupBox1: TGroupBox
      Top = 7
    end
  end
  inline Frame12: TOpenFileFrame
    Left = 60
    Top = 319
    Width = 320
    Height = 68
    TabOrder = 4
    inherited GroupBox1: TGroupBox
      Caption = ' Application'#39's file '
    end
  end
  inline FrameWithParam1: TFrameWithParam
    Left = 9
    Top = 400
    Width = 200
    Height = 48
    TabOrder = 5
  end
  inline FrameWithParam2: TFrameWithParam
    Left = 233
    Top = 400
    Width = 200
    Height = 48
    TabOrder = 6
  end
end
