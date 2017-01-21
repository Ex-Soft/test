object MainForm: TMainForm
  Left = 194
  Top = 107
  Width = 373
  Height = 214
  Caption = 'MS Office Test'
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
  object MSWordGroupBox: TGroupBox
    Left = 6
    Top = 6
    Width = 173
    Height = 171
    Caption = ' MS Word '
    TabOrder = 0
    object TWordApplicationButton: TButton
      Left = 32
      Top = 132
      Width = 110
      Height = 25
      Caption = 'TWordApplication'
      TabOrder = 0
      OnClick = TWordApplicationButtonClick
    end
    object OLEObjectGroupBox: TGroupBox
      Left = 16
      Top = 16
      Width = 142
      Height = 105
      Caption = ' OLE Object '
      TabOrder = 1
      object WordBasicButton: TButton
        Left = 16
        Top = 24
        Width = 110
        Height = 25
        Caption = 'Word.Basic'
        TabOrder = 0
        OnClick = WordBasicButtonClick
      end
      object WordApplicationButton: TButton
        Left = 16
        Top = 56
        Width = 110
        Height = 25
        Caption = 'Word.Application'
        TabOrder = 1
        OnClick = WordApplicationButtonClick
      end
    end
  end
  object Edit1: TEdit
    Left = 200
    Top = 56
    Width = 121
    Height = 21
    TabOrder = 1
  end
end
