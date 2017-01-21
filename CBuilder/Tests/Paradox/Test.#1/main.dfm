object MainForm: TMainForm
  Left = 194
  Top = 107
  Width = 544
  Height = 375
  Caption = 'Test# 1 (Paradox)'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  Menu = MainMenu
  OldCreateOrder = False
  Position = poScreenCenter
  Scaled = False
  PixelsPerInch = 96
  TextHeight = 13
  object PageControl1: TPageControl
    Left = 0
    Top = 0
    Width = 536
    Height = 329
    ActivePage = TabSheetQuery
    Align = alClient
    TabIndex = 0
    TabOrder = 0
    object TabSheetQuery: TTabSheet
      Caption = 'Query'
      object DBGrid1: TDBGrid
        Left = 0
        Top = 0
        Width = 528
        Height = 301
        Align = alClient
        DataSource = DataBases.DataSource1
        TabOrder = 0
        TitleFont.Charset = DEFAULT_CHARSET
        TitleFont.Color = clWindowText
        TitleFont.Height = -11
        TitleFont.Name = 'MS Sans Serif'
        TitleFont.Style = []
      end
    end
    object TabSheetSetGet: TTabSheet
      Caption = 'Set/Get'
      ImageIndex = 1
      DesignSize = (
        528
        301)
      object GroupBoxSetGet: TGroupBox
        Left = 8
        Top = 8
        Width = 512
        Height = 53
        Anchors = [akLeft, akTop, akRight]
        TabOrder = 0
        DesignSize = (
          512
          53)
        object LabelEditSetGet: TLabel
          Left = 78
          Top = 22
          Width = 40
          Height = 13
          AutoSize = False
          Caption = 'Value'
        end
        object LabelId: TLabel
          Left = 8
          Top = 22
          Width = 15
          Height = 13
          AutoSize = False
          Caption = 'Id'
        end
        object CheckBoxASCII: TCheckBox
          Left = 371
          Top = 20
          Width = 50
          Height = 17
          Anchors = [akTop, akRight]
          Caption = 'ASCII'
          TabOrder = 0
        end
        object ButtonSetGet: TButton
          Left = 429
          Top = 16
          Width = 75
          Height = 25
          Anchors = [akTop, akRight]
          Caption = 'Set/Get'
          TabOrder = 1
          OnClick = ButtonSetGetClick
        end
        object EditValue: TEdit
          Left = 126
          Top = 18
          Width = 237
          Height = 21
          Anchors = [akLeft, akTop, akRight]
          TabOrder = 2
        end
        object EditId: TEdit
          Left = 31
          Top = 18
          Width = 40
          Height = 21
          TabOrder = 3
        end
      end
      object RadioButtonSet: TRadioButton
        Left = 16
        Top = 7
        Width = 40
        Height = 17
        Caption = 'Set'
        Checked = True
        TabOrder = 1
        TabStop = True
      end
      object RadioButtonGet: TRadioButton
        Left = 64
        Top = 7
        Width = 40
        Height = 17
        Caption = 'Get'
        TabOrder = 2
      end
    end
  end
  object MainMenu: TMainMenu
    Left = 504
    object File1: TMenuItem
      Caption = '&File'
      object Exit1: TMenuItem
        Caption = 'E&xit'
        OnClick = Exit1Click
      end
    end
  end
end
