object MainForm: TMainForm
  Left = 194
  Top = 107
  Width = 500
  Height = 500
  Caption = 'Test DD Image'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  Position = poScreenCenter
  OnDragOver = FormDragOver
  PixelsPerInch = 96
  TextHeight = 13
  object PaintBoxSrc: TPaintBox
    Left = 10
    Top = 36
    Width = 200
    Height = 400
    OnDragDrop = PaintBoxDragDrop
    OnDragOver = PaintBoxDragOver
    OnPaint = PaintBoxSrcPaint
  end
  object PaintBoxDest: TPaintBox
    Left = 278
    Top = 36
    Width = 200
    Height = 400
    OnDragDrop = PaintBoxDragDrop
    OnDragOver = PaintBoxDragOver
    OnPaint = PaintBoxDestPaint
  end
  object ImageCard: TImage
    Left = 80
    Top = 104
    Width = 105
    Height = 105
    AutoSize = True
    OnEndDrag = ImageCardEndDrag
    OnMouseDown = ImageCardMouseDown
  end
end
