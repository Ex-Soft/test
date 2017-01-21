object MainForm: TMainForm
  Left = 192
  Top = 107
  Width = 555
  Height = 375
  Caption = 'Threads Test Form'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object SynchronizeThreadsGroupBox: TGroupBox
    Left = 8
    Top = 8
    Width = 185
    Height = 337
    Caption = ' Synchronize Threads '
    TabOrder = 0
    object SynchronizeModeRadioGroup: TRadioGroup
      Left = 8
      Top = 16
      Width = 169
      Height = 93
      Caption = ' Synchronize Mode '
      ItemIndex = 0
      Items.Strings = (
        'Critical Section'
        'Mutex'
        'Semaphore'
        'Not Synchronize')
      TabOrder = 0
      OnClick = SynchronizeModeRadioGroupClick
    end
    object SynchronizeThreadsButton: TButton
      Left = 18
      Top = 116
      Width = 150
      Height = 25
      Caption = 'Synchronize Threads'
      TabOrder = 1
      OnClick = SynchronizeThreadsButtonClick
    end
    object ListBox1: TListBox
      Left = 18
      Top = 148
      Width = 150
      Height = 181
      ItemHeight = 13
      TabOrder = 2
    end
  end
  object PriorityThreadsGroupBox: TGroupBox
    Left = 200
    Top = 8
    Width = 343
    Height = 201
    Caption = ' Priority Threads '
    TabOrder = 1
    object FirstThreadLabel: TLabel
      Left = 8
      Top = 61
      Width = 56
      Height = 13
      Caption = 'First Thread'
    end
    object SecondThreadLabel: TLabel
      Left = 8
      Top = 131
      Width = 74
      Height = 13
      Caption = 'Second Thread'
    end
    object PriorityLabel: TLabel
      Left = 145
      Top = 16
      Width = 31
      Height = 13
      Caption = 'Priority'
    end
    object ProgressLabel: TLabel
      Left = 262
      Top = 16
      Width = 41
      Height = 13
      Caption = 'Progress'
    end
    object SecondThreadTrackBar: TTrackBar
      Left = 110
      Top = 115
      Width = 100
      Height = 45
      Max = 6
      Orientation = trHorizontal
      PageSize = 1
      Frequency = 1
      Position = 3
      SelEnd = 5
      SelStart = 1
      TabOrder = 1
      TickMarks = tmBoth
      TickStyle = tsAuto
    end
    object FirstThreadTrackBar: TTrackBar
      Left = 110
      Top = 45
      Width = 100
      Height = 45
      Max = 6
      Orientation = trHorizontal
      PageSize = 1
      Frequency = 1
      Position = 3
      SelEnd = 5
      SelStart = 1
      TabOrder = 0
      TickMarks = tmBoth
      TickStyle = tsAuto
    end
    object FirstThreadProgressBar: TProgressBar
      Left = 232
      Top = 59
      Width = 100
      Height = 16
      Min = 0
      Max = 5000
      TabOrder = 2
    end
    object SecondThreadProgressBar: TProgressBar
      Left = 232
      Top = 129
      Width = 100
      Height = 16
      Min = 0
      Max = 5000
      TabOrder = 3
    end
    object PriorityThreadsButton: TButton
      Left = 98
      Top = 162
      Width = 150
      Height = 25
      Caption = 'Priority Threads'
      TabOrder = 4
      OnClick = PriorityThreadsButtonClick
    end
  end
end
