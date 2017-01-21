object DemoForm: TDemoForm
  Left = 249
  Top = 197
  BorderStyle = bsSingle
  Caption = 'ICQ_Socket . dll'
  ClientHeight = 180
  ClientWidth = 387
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  Position = poDesktopCenter
  PixelsPerInch = 96
  TextHeight = 13
  object Label2: TLabel
    Left = 0
    Top = 40
    Width = 385
    Height = 57
    Alignment = taCenter
    AutoSize = False
    Caption = 
      #1042' '#1076#1072#1085#1085#1099#1081' '#1084#1086#1084#1077#1085#1090' '#1042#1099' '#1080#1089#1087#1086#1083#1100#1079#1091#1077#1090#1077' '#1076#1077#1084#1086' '#1074#1077#1088#1089#1080#1102' '#1073#1080#1073#1083#1080#1086#1090#1077#1082#1080' ICQ_Socket' +
      '. '#1044#1083#1103' '#1087#1086#1083#1091#1095#1077#1085#1080#1103' '#1087#1086#1083#1085#1086#1081' '#1074#1077#1088#1089#1080#1080' '#1087#1086#1089#1077#1090#1080#1090#1077' '#1089#1072#1081#1090
    Font.Charset = RUSSIAN_CHARSET
    Font.Color = clActiveCaption
    Font.Height = -15
    Font.Name = 'Arial'
    Font.Style = [fsBold, fsItalic]
    ParentFont = False
    WordWrap = True
  end
  object UrlLabel: TLabel
    Left = 28
    Top = 104
    Width = 319
    Height = 18
    Cursor = crHandPoint
    Caption = 'http://softvariant.boom.ru/icq_socket/index.htm'
    Font.Charset = RUSSIAN_CHARSET
    Font.Color = clBlue
    Font.Height = -16
    Font.Name = 'Arial'
    Font.Style = []
    ParentFont = False
    OnClick = UrlLabelClick
  end
  object Label3: TLabel
    Left = 0
    Top = 8
    Width = 385
    Height = 25
    Alignment = taCenter
    AutoSize = False
    Caption = #1069#1090#1072' '#1092#1091#1085#1082#1094#1080#1103' '#1079#1072#1073#1083#1086#1082#1080#1088#1086#1074#1072#1085#1072' !'
    Font.Charset = RUSSIAN_CHARSET
    Font.Color = clRed
    Font.Height = -15
    Font.Name = 'Arial'
    Font.Style = [fsBold]
    ParentFont = False
    WordWrap = True
  end
  object Label4: TLabel
    Left = 279
    Top = 158
    Width = 105
    Height = 15
    Caption = 'softvariant@chat.ru'
    Font.Charset = RUSSIAN_CHARSET
    Font.Color = clNavy
    Font.Height = -12
    Font.Name = 'Arial'
    Font.Style = []
    ParentFont = False
  end
  object BitBtn1: TBitBtn
    Left = 156
    Top = 144
    Width = 75
    Height = 25
    TabOrder = 0
    Kind = bkOK
  end
end
