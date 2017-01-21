object MainForm: TMainForm
  Left = 302
  Top = 126
  Width = 484
  Height = 375
  Align = alClient
  Caption = 'MainForm'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  Position = poScreenCenter
  Scaled = False
  DesignSize = (
    476
    348)
  PixelsPerInch = 96
  TextHeight = 13
  object PageControlMainForm: TPageControl
    Left = 225
    Top = 8
    Width = 241
    Height = 337
    ActivePage = TabSheet5
    Anchors = [akLeft, akTop, akRight, akBottom]
    TabIndex = 4
    TabOrder = 0
    object TabSheet1: TTabSheet
      Caption = 'TabSheet1'
      object EditTabSheet1: TEdit
        Left = 8
        Top = 8
        Width = 200
        Height = 21
        TabOrder = 0
        Text = 'EditTabSheet1'
      end
      object ComboBoxTabSheet1: TComboBox
        Left = 8
        Top = 40
        Width = 200
        Height = 21
        ItemHeight = 13
        TabOrder = 1
        Text = 'ComboBoxTabSheet1'
      end
      object DateTimePickerTabSheet1: TDateTimePicker
        Left = 8
        Top = 72
        Width = 200
        Height = 21
        CalAlignment = dtaLeft
        Date = 37851.422676956
        Time = 37851.422676956
        DateFormat = dfShort
        DateMode = dmComboBox
        Kind = dtkDate
        ParseInput = False
        TabOrder = 2
      end
      object GroupBoxTabSheet1: TGroupBox
        Left = 8
        Top = 104
        Width = 216
        Height = 113
        Caption = 'GroupBoxTabSheet1'
        TabOrder = 3
        Visible = False
        object EditGroupBoxTabSheet1: TEdit
          Left = 8
          Top = 14
          Width = 200
          Height = 21
          TabOrder = 0
          Text = 'EditGroupBoxTabSheet1'
        end
        object ComboBoxGroupBoxTabSheet1: TComboBox
          Left = 8
          Top = 46
          Width = 200
          Height = 21
          ItemHeight = 13
          TabOrder = 1
          Text = 'ComboBoxGroupBoxTabSheet1'
        end
        object DateTimePickerGroupBoxTabSheet1: TDateTimePicker
          Left = 8
          Top = 78
          Width = 200
          Height = 21
          CalAlignment = dtaLeft
          Date = 37851.422676956
          Time = 37851.422676956
          DateFormat = dfShort
          DateMode = dmComboBox
          Kind = dtkDate
          ParseInput = False
          TabOrder = 2
        end
      end
      object StringGridTabSheet1: TStringGrid
        Left = 8
        Top = 224
        Width = 216
        Height = 80
        ColCount = 3
        RowCount = 3
        Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goEditing, goThumbTracking]
        TabOrder = 4
        RowHeights = (
          24
          24
          24)
      end
    end
    object TabSheet2: TTabSheet
      Caption = 'TabSheet2'
      ImageIndex = 1
      object EditTabSheet2: TEdit
        Left = 8
        Top = 8
        Width = 200
        Height = 21
        TabOrder = 0
        Text = 'EditTabSheet2'
      end
      object ComboBoxTabSheet2: TComboBox
        Left = 8
        Top = 40
        Width = 200
        Height = 21
        ItemHeight = 13
        TabOrder = 1
        Text = 'ComboBoxTabSheet2'
      end
      object DateTimePickerTabSheet2: TDateTimePicker
        Left = 8
        Top = 72
        Width = 200
        Height = 21
        CalAlignment = dtaLeft
        Date = 37851.422676956
        Time = 37851.422676956
        DateFormat = dfShort
        DateMode = dmComboBox
        Kind = dtkDate
        ParseInput = False
        TabOrder = 2
      end
      object GroupBoxTabSheet2: TGroupBox
        Left = 8
        Top = 104
        Width = 216
        Height = 113
        Caption = 'GroupBoxTabSheet2'
        TabOrder = 3
        object EditGroupBoxTabSheet2: TEdit
          Left = 8
          Top = 14
          Width = 200
          Height = 21
          TabOrder = 0
          Text = 'EditGroupBoxTabSheet2'
        end
        object ComboBoxGroupBoxTabSheet2: TComboBox
          Left = 8
          Top = 46
          Width = 200
          Height = 21
          ItemHeight = 13
          TabOrder = 1
          Text = 'ComboBoxGroupBoxTabSheet2'
        end
        object DateTimePickerGroupBoxTabSheet2: TDateTimePicker
          Left = 8
          Top = 78
          Width = 200
          Height = 21
          CalAlignment = dtaLeft
          Date = 37851.422676956
          Time = 37851.422676956
          DateFormat = dfShort
          DateMode = dmComboBox
          Kind = dtkDate
          ParseInput = False
          TabOrder = 2
        end
      end
    end
    object TabSheet3: TTabSheet
      Caption = 'TabSheet3'
      ImageIndex = 2
      object TreeView1: TTreeView
        Left = 0
        Top = 0
        Width = 233
        Height = 309
        Align = alClient
        Indent = 19
        SortType = stText
        TabOrder = 0
      end
    end
    object TabSheet4: TTabSheet
      Caption = 'TabSheet4'
      ImageIndex = 3
      object ShowControlMemo: TMemo
        Left = 0
        Top = 0
        Width = 233
        Height = 309
        Align = alClient
        ScrollBars = ssBoth
        TabOrder = 0
      end
    end
    object TabSheet5: TTabSheet
      Caption = 'TabSheet5'
      ImageIndex = 4
      inline FrameTest1: TFrameTest
        Left = 38
        Top = 120
        Width = 158
        Height = 69
        TabOrder = 0
      end
    end
  end
  object EditMainForm: TEdit
    Left = 8
    Top = 8
    Width = 200
    Height = 21
    Enabled = False
    TabOrder = 1
    Text = 'EditMainForm'
  end
  object ComboBoxMainForm: TComboBox
    Left = 8
    Top = 40
    Width = 200
    Height = 21
    ItemHeight = 13
    TabOrder = 2
    Text = 'ComboBoxMainForm'
  end
  object GroupBoxMainForm: TGroupBox
    Left = 8
    Top = 136
    Width = 216
    Height = 135
    Caption = 'GroupBoxMainForm'
    TabOrder = 3
    object EditGroupBoxMainForm: TEdit
      Left = 8
      Top = 14
      Width = 200
      Height = 21
      TabOrder = 0
      Text = 'EditGroupBoxMainForm'
    end
    object ComboBoxGroupBoxMainForm: TComboBox
      Left = 8
      Top = 46
      Width = 200
      Height = 21
      ItemHeight = 13
      TabOrder = 1
      Text = 'ComboBoxGroupBoxMainForm'
    end
    object DateTimePickerGroupBoxMainForm: TDateTimePicker
      Left = 8
      Top = 72
      Width = 200
      Height = 21
      CalAlignment = dtaLeft
      Date = 37851.422676956
      Time = 37851.422676956
      DateFormat = dfShort
      DateMode = dmComboBox
      Kind = dtkDate
      ParseInput = False
      TabOrder = 2
    end
    object RadioGroupGroupBoxMainForm: TRadioGroup
      Left = 8
      Top = 96
      Width = 200
      Height = 35
      Caption = ' RadioGroupGroupBoxMainForm '
      Columns = 3
      Items.Strings = (
        '1st'
        '2nd'
        '3rd')
      TabOrder = 3
    end
  end
  object DateTimePickerMainForm: TDateTimePicker
    Left = 8
    Top = 72
    Width = 200
    Height = 21
    CalAlignment = dtaLeft
    Date = 37851.422676956
    Time = 37851.422676956
    DateFormat = dfShort
    DateMode = dmComboBox
    Kind = dtkDate
    ParseInput = False
    TabOrder = 4
  end
  object ShowTreeButton: TButton
    Left = 79
    Top = 280
    Width = 75
    Height = 25
    Caption = 'Show Tree'
    TabOrder = 5
    OnClick = ShowTreeButtonClick
  end
  object ShowControlButton: TButton
    Left = 79
    Top = 320
    Width = 75
    Height = 25
    Caption = 'Show Control'
    TabOrder = 6
    OnClick = ShowControlButtonClick
  end
  object RadioGroupMainForm: TRadioGroup
    Left = 8
    Top = 96
    Width = 200
    Height = 35
    Caption = ' RadioGroupMainForm '
    Columns = 3
    Items.Strings = (
      '1st'
      '2nd'
      '3rd')
    TabOrder = 7
  end
end
