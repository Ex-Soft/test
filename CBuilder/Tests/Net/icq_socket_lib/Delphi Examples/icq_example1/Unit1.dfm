object Form1: TForm1
  Left = 264
  Top = 122
  BorderIcons = [biSystemMenu, biMinimize]
  BorderStyle = bsDialog
  Caption = 'Send to Send'
  ClientHeight = 401
  ClientWidth = 587
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  Position = poDesktopCenter
  OnCreate = FormCreate
  OnDestroy = FormDestroy
  PixelsPerInch = 96
  TextHeight = 13
  object Panel1: TPanel
    Left = 0
    Top = 0
    Width = 587
    Height = 27
    Align = alTop
    TabOrder = 0
  end
  object StatusBar: TStatusBar
    Left = 0
    Top = 382
    Width = 587
    Height = 19
    Panels = <>
    SimplePanel = True
    SimpleText = 'http://softvariant.boom.ru        softvariant@chat.ru'
    OnClick = StatusBarClick
  end
  object Panel2: TPanel
    Left = 0
    Top = 27
    Width = 587
    Height = 357
    Align = alTop
    BevelOuter = bvNone
    TabOrder = 2
    object Panel3: TPanel
      Left = 0
      Top = 0
      Width = 293
      Height = 357
      Align = alLeft
      TabOrder = 0
      inline Part1: TICQFrame
        Tag = 1
        Left = 3
        Top = 5
        Width = 287
        Height = 348
        TabOrder = 0
        inherited LogLabel: TLabel
          Left = 7
          Top = 247
        end
        inherited TopPanel: TPanel
          Width = 287
          Height = 261
          inherited Label1: TLabel
            Left = 7
            Top = 7
          end
          inherited Label2: TLabel
            Left = 72
            Top = 7
          end
          inherited Label3: TLabel
            Left = 124
            Top = 7
          end
          inherited Label4: TLabel
            Left = 7
            Top = 46
          end
          inherited Bevel1: TBevel
            Top = 163
            Width = 280
            Height = 7
          end
          inherited UrlLabel: TLabel
            Left = 7
            Top = 169
          end
          inherited Label7: TLabel
            Left = 7
            Top = 208
          end
          inherited Shape: TShape
            Left = 202
            Top = 7
            Width = 78
            Height = 7
          end
          inherited UINEdit: TEdit
            Left = 7
            Top = 20
            Width = 65
            Height = 24
          end
          inherited PassEdit: TEdit
            Left = 72
            Top = 20
            Width = 52
            Height = 24
          end
          inherited StatusCombo: TComboBox
            Left = 124
            Top = 20
            Width = 72
          end
          inherited ConnectBtn: TBitBtn
            Left = 202
            Top = 20
            Width = 78
            Height = 17
          end
          inherited ContactList: TListBox
            Left = 7
            Top = 59
            Width = 189
            Height = 72
          end
          inherited RemoveContactBtn: TBitBtn
            Left = 202
            Top = 111
            Width = 78
            Height = 17
          end
          inherited ContactUINEdit: TEdit
            Left = 7
            Top = 137
            Width = 65
            Height = 24
          end
          inherited ContactVisCombo: TComboBox
            Left = 78
            Top = 137
            Width = 118
          end
          inherited SetContactBtn: TBitBtn
            Left = 202
            Top = 137
            Width = 78
            Height = 17
          end
          inherited UrlEdit: TEdit
            Left = 7
            Top = 182
            Width = 189
            Height = 24
          end
          inherited DescEdit: TEdit
            Left = 7
            Top = 221
            Width = 189
            Height = 24
          end
          inherited SendRadio: TRadioGroup
            Left = 202
            Top = 176
            Width = 78
            Height = 39
          end
          inherited SendBtn: TBitBtn
            Left = 202
            Top = 221
            Width = 78
            Height = 17
          end
          inherited Trace: TCheckBox
            Left = 202
            Top = 39
            Width = 78
            Height = 14
          end
          inherited GetInfoBtn: TBitBtn
            Left = 202
            Top = 59
            Width = 78
            Height = 17
          end
          inherited SearchBtn: TBitBtn
            Left = 202
            Top = 85
            Width = 78
            Height = 17
          end
        end
        inherited LogMemo: TMemo
          Left = 7
          Top = 267
          Width = 273
          Height = 78
        end
      end
    end
    object Panel4: TPanel
      Left = 293
      Top = 0
      Width = 294
      Height = 357
      Align = alClient
      TabOrder = 1
      inline Part2: TICQFrame
        Tag = 2
        Left = 4
        Top = 5
        Width = 287
        Height = 348
        TabOrder = 0
        inherited LogLabel: TLabel
          Left = 7
          Top = 247
        end
        inherited TopPanel: TPanel
          Width = 287
          Height = 261
          inherited Label1: TLabel
            Left = 7
            Top = 7
          end
          inherited Label2: TLabel
            Left = 72
            Top = 7
          end
          inherited Label3: TLabel
            Left = 124
            Top = 7
          end
          inherited Label4: TLabel
            Left = 7
            Top = 46
          end
          inherited Bevel1: TBevel
            Top = 163
            Width = 280
            Height = 7
          end
          inherited UrlLabel: TLabel
            Left = 7
            Top = 169
          end
          inherited Label7: TLabel
            Left = 7
            Top = 208
          end
          inherited Shape: TShape
            Left = 202
            Top = 7
            Width = 78
            Height = 7
          end
          inherited UINEdit: TEdit
            Left = 7
            Top = 20
            Width = 65
            Height = 24
          end
          inherited PassEdit: TEdit
            Left = 72
            Top = 20
            Width = 52
            Height = 24
          end
          inherited StatusCombo: TComboBox
            Left = 124
            Top = 20
            Width = 72
          end
          inherited ConnectBtn: TBitBtn
            Left = 202
            Top = 20
            Width = 78
            Height = 17
          end
          inherited ContactList: TListBox
            Left = 7
            Top = 59
            Width = 189
            Height = 72
          end
          inherited RemoveContactBtn: TBitBtn
            Left = 202
            Top = 111
            Width = 78
            Height = 17
          end
          inherited ContactUINEdit: TEdit
            Left = 7
            Top = 137
            Width = 65
            Height = 24
          end
          inherited ContactVisCombo: TComboBox
            Left = 78
            Top = 137
            Width = 118
          end
          inherited SetContactBtn: TBitBtn
            Left = 202
            Top = 137
            Width = 78
            Height = 17
          end
          inherited UrlEdit: TEdit
            Left = 7
            Top = 182
            Width = 189
            Height = 24
          end
          inherited DescEdit: TEdit
            Left = 7
            Top = 221
            Width = 189
            Height = 24
          end
          inherited SendRadio: TRadioGroup
            Left = 202
            Top = 176
            Width = 78
            Height = 39
          end
          inherited SendBtn: TBitBtn
            Left = 202
            Top = 221
            Width = 78
            Height = 17
          end
          inherited Trace: TCheckBox
            Left = 202
            Top = 39
            Width = 78
            Height = 14
          end
          inherited GetInfoBtn: TBitBtn
            Left = 202
            Top = 59
            Width = 78
            Height = 17
          end
          inherited SearchBtn: TBitBtn
            Left = 202
            Top = 85
            Width = 78
            Height = 17
          end
        end
        inherited LogMemo: TMemo
          Left = 7
          Top = 267
          Width = 273
          Height = 78
        end
      end
    end
  end
end
