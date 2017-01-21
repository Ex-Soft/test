object OpenFileFrame: TOpenFileFrame
  Left = 0
  Top = 0
  Width = 320
  Height = 68
  TabOrder = 0
  object GroupBox1: TGroupBox
    Left = 12
    Top = 6
    Width = 297
    Height = 53
    Caption = ' Fram'#39's file '
    TabOrder = 0
    object Label1: TLabel
      Left = 16
      Top = 22
      Width = 16
      Height = 13
      Caption = 'File'
    end
    object Edit1: TEdit
      Left = 40
      Top = 18
      Width = 165
      Height = 21
      ParentShowHint = False
      ShowHint = True
      TabOrder = 0
      OnExit = Edit1Exit
    end
    object ViewButton: TButton
      Left = 210
      Top = 16
      Width = 75
      Height = 25
      Hint = 'Select file|Select file from directory'
      Caption = 'View...'
      ParentShowHint = False
      ShowHint = True
      TabOrder = 1
      OnClick = ViewButtonClick
    end
  end
  object ApplicationEvents1: TApplicationEvents
    OnShowHint = ApplicationEvents1ShowHint
    Left = 24
    Top = 24
  end
  object OpenDialog1: TOpenDialog
    Filter = 'All file(s)|*.*'
    Left = 56
    Top = 24
  end
end
