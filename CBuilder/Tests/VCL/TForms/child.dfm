object ChildForm: TChildForm
  Left = 276
  Top = 202
  Width = 360
  Height = 197
  Caption = 'ChildForm'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  Scaled = False
  OnActivate = FormActivate
  OnClose = FormClose
  OnCloseQuery = FormCloseQuery
  OnCreate = FormCreate
  OnDestroy = FormDestroy
  OnDeactivate = FormDeactivate
  OnHide = FormHide
  OnPaint = FormPaint
  OnShow = FormShow
  PixelsPerInch = 96
  TextHeight = 13
  inline TestFrameWithException: TTestFrame
    Left = 76
    Top = 35
    Width = 200
    Height = 100
    TabOrder = 0
    inherited LabelFrame: TLabel
      Font.Color = clBlue
    end
  end
end
