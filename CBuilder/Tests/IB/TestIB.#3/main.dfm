object MainForm: TMainForm
  Left = 192
  Top = 107
  BorderIcons = [biSystemMenu]
  BorderStyle = bsSingle
  Caption = 'TestIB #3'
  ClientHeight = 453
  ClientWidth = 688
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
  object PageControl1: TPageControl
    Left = 0
    Top = 0
    Width = 688
    Height = 453
    ActivePage = TabSheet1
    Align = alClient
    TabIndex = 0
    TabOrder = 0
    object TabSheet1: TTabSheet
      Caption = 'TabSheet1'
      object ButtonCreateByIBX: TButton
        Left = 304
        Top = 200
        Width = 75
        Height = 25
        Caption = 'Create by IBX'
        TabOrder = 0
        OnClick = ButtonCreateByIBXClick
      end
      object ButtonCreateByAPI: TButton
        Left = 232
        Top = 72
        Width = 75
        Height = 25
        Caption = 'Create By API'
        TabOrder = 1
      end
    end
    object TabSheetIBSQLMonitor: TTabSheet
      Caption = 'IBSQLMonitor'
      ImageIndex = 1
      object MemoIBSQLMonitor: TMemo
        Left = 0
        Top = 0
        Width = 680
        Height = 425
        Align = alClient
        TabOrder = 0
      end
    end
  end
end
