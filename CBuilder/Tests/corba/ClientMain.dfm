object Form1: TForm1
  Left = 193
  Top = 106
  Width = 557
  Height = 264
  Caption = 'Corba client'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  Position = poScreenCenter
  OnShow = FormShow
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 15
    Top = 16
    Width = 522
    Height = 20
    Alignment = taCenter
    AutoSize = False
    Caption = 'Телеграмма'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'MS Sans Serif'
    Font.Style = [fsBold, fsItalic]
    ParentFont = False
  end
  object Edit1: TEdit
    Left = 440
    Top = 144
    Width = 100
    Height = 21
    TabOrder = 0
  end
  object Memo1: TMemo
    Left = 15
    Top = 48
    Width = 522
    Height = 89
    TabOrder = 1
  end
  object BitBtn1: TBitBtn
    Left = 440
    Top = 176
    Width = 100
    Height = 25
    Caption = 'Послать'
    TabOrder = 2
    OnClick = BitBtn1Click
    Glyph.Data = {
      66010000424D6601000000000000760000002800000014000000140000000100
      040000000000F0000000330B0000330B00001000000010000000000000000000
      40008000000000C000000000FF0040FFFF0080808000C0C0C000FFFFFF000000
      0000000000000000000000000000000000000000000000000000777777777777
      7777777700007777777777777777777700007777777777777777777700007777
      7777777777777777000077666666666666666667000071111111111111111167
      0000718888888888888881670000718888888008008081670000718888888868
      6868816700007188888880800800816700007188888888888888816700007180
      8018888222328167000071886868888455538167000071811818888242228167
      0000718888888888888881670000711111111111111111770000777777777777
      7777777700007777777777777777777700007777777777777777777700007777
      77777777777777770000}
  end
  object StatusBar1: TStatusBar
    Left = 0
    Top = 218
    Width = 549
    Height = 19
    Panels = <
      item
        Width = 50
      end
      item
        Width = 50
      end>
    SimplePanel = False
  end
end
