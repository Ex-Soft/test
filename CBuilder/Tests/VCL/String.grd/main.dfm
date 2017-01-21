object MainForm: TMainForm
  Left = 192
  Top = 103
  Width = 544
  Height = 375
  Caption = 'Main Form'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  OnShow = FormShow
  PixelsPerInch = 96
  TextHeight = 13
  object PageControlStringGrid: TPageControl
    Left = 0
    Top = 0
    Width = 536
    Height = 348
    ActivePage = TabSheetIntegrate
    Align = alClient
    TabIndex = 3
    TabOrder = 0
    object TabSheetSelfDraw: TTabSheet
      Caption = 'SelfDraw'
      object StringGrid: TStringGrid
        Left = 8
        Top = 8
        Width = 320
        Height = 201
        DefaultRowHeight = 50
        DefaultDrawing = False
        FixedCols = 0
        Options = [goRowSizing]
        TabOrder = 0
        OnDrawCell = StringGridDrawCell
      end
      object TestButton: TButton
        Left = 448
        Top = 295
        Width = 75
        Height = 25
        Caption = 'Test Button'
        TabOrder = 1
      end
    end
    object TabSheetOns: TTabSheet
      Caption = 'Ons'
      ImageIndex = 1
      object SplitterH: TSplitter
        Left = 0
        Top = 129
        Width = 528
        Height = 8
        Cursor = crVSplit
        Align = alTop
        Beveled = True
      end
      object StringGridOns: TStringGrid
        Left = 0
        Top = 0
        Width = 528
        Height = 129
        Align = alTop
        Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goColSizing, goEditing, goThumbTracking]
        ScrollBars = ssVertical
        TabOrder = 0
        OnDblClick = StringGridOnsDblClick
        OnGetEditMask = StringGridOnsGetEditMask
        OnGetEditText = StringGridOnsGetEditText
        OnSelectCell = StringGridOnsSelectCell
        OnSetEditText = StringGridOnsSetEditText
        ColWidths = (
          64
          64
          67
          64
          64)
      end
      object RichEdit1: TRichEdit
        Left = 0
        Top = 137
        Width = 528
        Height = 183
        Align = alClient
        ScrollBars = ssVertical
        TabOrder = 1
      end
    end
    object TabSheetRunTime: TTabSheet
      Caption = 'RunTime'
      ImageIndex = 2
      object StringGridRunTime: TStringGrid
        Left = 0
        Top = 0
        Width = 320
        Height = 281
        ColCount = 4
        FixedCols = 0
        RowCount = 2
        Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goColSizing, goEditing]
        TabOrder = 0
        OnKeyDown = StringGridRunTimeKeyDown
        OnSelectCell = StringGridRunTimeSelectCell
      end
    end
    object TabSheetIntegrate: TTabSheet
      Caption = 'Integrate'
      ImageIndex = 3
      object StringGridIntegrate: TStringGrid
        Left = 0
        Top = 0
        Width = 513
        Height = 281
        ColCount = 4
        DefaultColWidth = 100
        DefaultRowHeight = 32
        FixedCols = 0
        RowCount = 2
        GridLineWidth = 10
        Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goColSizing, goThumbTracking]
        TabOrder = 0
        OnSelectCell = StringGridIntegrateSelectCell
      end
      object ComboBoxIntegrate: TComboBox
        Left = 232
        Top = 288
        Width = 100
        Height = 32
        Style = csDropDownList
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -19
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ItemHeight = 24
        ParentFont = False
        TabOrder = 1
        Visible = False
        OnExit = ComboBoxIntegrateExit
        Items.Strings = (
          '1'
          '2'
          '3'
          '4'
          '5'
          '6'
          '7'
          '8'
          '9')
      end
      object ComboBoxIntegrateSelfDraw: TComboBox
        Left = 384
        Top = 288
        Width = 145
        Height = 19
        Style = csOwnerDrawFixed
        ItemHeight = 13
        TabOrder = 2
        Visible = False
        OnDrawItem = ComboBoxIntegrateSelfDrawDrawItem
        OnExit = ComboBoxIntegrateExit
        Items.Strings = (
          '1234567890 1234567890 1234567890 1234567890'
          '2345678901 2345678901 2345678901 2345678901'
          '3456789012 3456789012 3456789012 3456789012'
          '4567890123 4567890123 4567890123 4567890123'
          '5678901234 5678901234 5678901234 5678901234'
          '6789012345 6789012345 6789012345 6789012345'
          '7890123456 7890123456 7890123456 7890123456')
      end
    end
  end
end
