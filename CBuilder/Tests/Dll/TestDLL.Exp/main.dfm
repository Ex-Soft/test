object MainForm: TMainForm
  Left = 193
  Top = 107
  Width = 269
  Height = 265
  Caption = 'Expanded test DLL'
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
  object DoItBitBtn: TBitBtn
    Left = 80
    Top = 136
    Width = 75
    Height = 97
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -21
    Font.Name = 'MS Sans Serif'
    Font.Style = [fsBold, fsItalic, fsUnderline]
    ParentFont = False
    TabOrder = 1
    OnClick = DoItBitBtnClick
    Glyph.Data = {
      76020000424D7602000000000000760000002800000020000000200000000100
      0400000000000002000000000000000000001000000000000000000000000000
      80000080000000808000800000008000800080800000C0C0C000808080000000
      FF0000FF000000FFFF00FF000000FF00FF00FFFF0000FFFFFF00FFFFFFFFFFFF
      FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF00000FFF
      FFFFFFFF0000FFFFFFFFFFFF011110FFFFFFFFF08870FFFFFFFFFFFF0999110F
      FFFFFF088770FFFFFFFFFFFFF0999110FFFFF0887770FFFFFFFFFFFFFF099911
      0FFF0887770FFFFFFFFFFFFFFFF0999110F0887770FFFFFFFFFFFFFFFFFF0999
      110887770FFFFFFFFFFFFFFFFFFFF09990887770FFFFFFFFFFFFFFFFFFFFFF09
      0887770FFFFFFFFFFFFFFFFFFFFFFFF0887770FFFFFFFFFFFFFFFFFFFFFFFF08
      8777010FFFFFFFFFFFFFFFFFFFFFF08877709110FFFFFFFFFFFFFFFFFFFF0887
      770999110FFFFFF08FFF00000000087770F0999110FFFF0808FF000000000777
      0FFF0999110FFF03808F000000000000FFFFF09991000003380800000000000F
      FFFFFF09910888833880000FFFF0000FFFFFFFF09088888B000F000FFFF0000F
      FFFFFFFF083333330FFFFFFFFFF0000FFFFFFFFF0B333BBB0FFFFFFF0000000F
      FFFFFFFF0B33BBB80FFFFFFF0000000FFFFFFFFF0B3BBBB80FFFFFFF0000000F
      FFFFFFFF083BBBB80FFFFFFFFFFFFFFFFFFFFFFF0833BB80FFFFFFFFFFFFFFFF
      FFFFF0003300008FFFFFFFFFFFFFFFFFFF0003BBBB0FFFFFFFFFFFFFFFFFFFFF
      FF0BBBBBB0FFFFFFFFFFFFFFFFFFFFFFFF0000000FFFFFFFFFFFFFFFFFFFFFFF
      FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF}
  end
  object ActionGroupBox: TGroupBox
    Left = 8
    Top = 8
    Width = 244
    Height = 122
    Caption = ' Action '
    TabOrder = 0
    object LoadLibraryCheckBox: TCheckBox
      Left = 16
      Top = 16
      Width = 97
      Height = 17
      Caption = 'Load Library'
      TabOrder = 0
      OnClick = LoadLibraryCheckBoxClick
    end
    object InitializePointerCheckBox: TCheckBox
      Left = 16
      Top = 36
      Width = 97
      Height = 17
      Caption = 'Initialize Pointer'
      TabOrder = 1
      OnClick = InitializePointerCheckBoxClick
    end
    object CallFunctionCheckBox: TCheckBox
      Left = 16
      Top = 56
      Width = 97
      Height = 17
      Caption = 'Call Function'
      TabOrder = 2
      OnClick = CallFunctionCheckBoxClick
    end
    object TypeFunctionRadioGroup: TRadioGroup
      Left = 8
      Top = 76
      Width = 227
      Height = 37
      Caption = ' Type Function '
      Columns = 2
      ItemIndex = 0
      Items.Strings = (
        '(void)'
        '(FILE *, AnsiString)')
      TabOrder = 3
    end
  end
end
