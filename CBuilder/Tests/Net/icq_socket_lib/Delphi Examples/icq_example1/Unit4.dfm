object MetaInfoForm: TMetaInfoForm
  Left = 219
  Top = 157
  Width = 577
  Height = 390
  Caption = 'Info'
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
  object Panel1: TPanel
    Left = 0
    Top = 0
    Width = 569
    Height = 27
    Align = alTop
    TabOrder = 0
    object Label2: TLabel
      Left = 13
      Top = 7
      Width = 23
      Height = 13
      Caption = 'UIN'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object UINLabel: TLabel
      Left = 39
      Top = 7
      Width = 45
      Height = 13
      Caption = 'UINLabel'
    end
    object LoadingLabel: TLabel
      Left = 377
      Top = 7
      Width = 70
      Height = 13
      Caption = 'Loading . . .'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clRed
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
    end
  end
  object PageControl1: TPageControl
    Left = 0
    Top = 27
    Width = 569
    Height = 335
    ActivePage = TabSheet1
    Align = alClient
    TabOrder = 1
    object TabSheet1: TTabSheet
      Caption = 'Main'
      object Label1: TLabel
        Left = 7
        Top = 13
        Width = 27
        Height = 13
        Caption = 'Nick'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object NickLabel: TLabel
        Left = 59
        Top = 13
        Width = 48
        Height = 13
        Caption = 'NickLabel'
      end
      object Label3: TLabel
        Left = 7
        Top = 39
        Width = 25
        Height = 13
        Caption = 'First'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object FirstLabel: TLabel
        Left = 59
        Top = 39
        Width = 45
        Height = 13
        Caption = 'FirstLabel'
      end
      object Label5: TLabel
        Left = 7
        Top = 65
        Width = 25
        Height = 13
        Caption = 'Last'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object LastLabel: TLabel
        Left = 59
        Top = 65
        Width = 46
        Height = 13
        Caption = 'LastLabel'
      end
      object Label7: TLabel
        Left = 7
        Top = 91
        Width = 31
        Height = 13
        Caption = 'Email'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object EmailLabel: TLabel
        Left = 59
        Top = 91
        Width = 51
        Height = 13
        Caption = 'EmailLabel'
      end
      object Label9: TLabel
        Left = 202
        Top = 13
        Width = 22
        Height = 13
        Caption = 'City'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object Label10: TLabel
        Left = 202
        Top = 39
        Width = 31
        Height = 13
        Caption = 'State'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object Label11: TLabel
        Left = 202
        Top = 65
        Width = 37
        Height = 13
        Caption = 'Phone'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object Label12: TLabel
        Left = 202
        Top = 91
        Width = 21
        Height = 13
        Caption = 'Fax'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object Label13: TLabel
        Left = 7
        Top = 117
        Width = 27
        Height = 13
        Caption = 'Addr'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object Label14: TLabel
        Left = 7
        Top = 143
        Width = 22
        Height = 13
        Caption = 'Cell'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object Label15: TLabel
        Left = 202
        Top = 143
        Width = 19
        Height = 13
        Caption = 'Zip'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object Label16: TLabel
        Left = 7
        Top = 169
        Width = 44
        Height = 13
        Caption = 'Country'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object Label17: TLabel
        Left = 202
        Top = 169
        Width = 62
        Height = 13
        Caption = 'TimeOffset'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object Label18: TLabel
        Left = 7
        Top = 195
        Width = 27
        Height = 13
        Caption = 'Auth'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object Label19: TLabel
        Left = 202
        Top = 195
        Width = 27
        Height = 13
        Caption = 'Web'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object Label20: TLabel
        Left = 338
        Top = 195
        Width = 39
        Height = 13
        Caption = 'HideIP'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object Loading1Label: TLabel
        Left = 377
        Top = 221
        Width = 70
        Height = 13
        Caption = 'Loading . . .'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clRed
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object AddrLabel: TLabel
        Left = 59
        Top = 117
        Width = 48
        Height = 13
        Caption = 'AddrLabel'
      end
      object CellLabel: TLabel
        Left = 59
        Top = 143
        Width = 43
        Height = 13
        Caption = 'CellLabel'
      end
      object CountryLabel: TLabel
        Left = 59
        Top = 169
        Width = 62
        Height = 13
        Caption = 'CountryLabel'
      end
      object AuthLabel: TLabel
        Left = 59
        Top = 195
        Width = 48
        Height = 13
        Caption = 'AuthLabel'
      end
      object TimeLabel: TLabel
        Left = 273
        Top = 169
        Width = 49
        Height = 13
        Caption = 'TimeLabel'
      end
      object ZipLabel: TLabel
        Left = 273
        Top = 143
        Width = 41
        Height = 13
        Caption = 'ZipLabel'
      end
      object FaxLabel: TLabel
        Left = 273
        Top = 91
        Width = 43
        Height = 13
        Caption = 'FaxLabel'
      end
      object PhoneLabel: TLabel
        Left = 273
        Top = 65
        Width = 57
        Height = 13
        Caption = 'PhoneLabel'
      end
      object StateLabel: TLabel
        Left = 273
        Top = 39
        Width = 51
        Height = 13
        Caption = 'StateLabel'
      end
      object CityLabel: TLabel
        Left = 273
        Top = 13
        Width = 43
        Height = 13
        Caption = 'CityLabel'
      end
      object WebLabel: TLabel
        Left = 273
        Top = 195
        Width = 49
        Height = 13
        Caption = 'WebLabel'
      end
      object HideLabel: TLabel
        Left = 384
        Top = 195
        Width = 48
        Height = 13
        Caption = 'HideLabel'
      end
    end
    object TabSheet2: TTabSheet
      Caption = 'Birthday / Lang'
      ImageIndex = 1
      object Label99: TLabel
        Left = 7
        Top = 13
        Width = 23
        Height = 13
        Caption = 'Age'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object Label78: TLabel
        Left = 7
        Top = 39
        Width = 42
        Height = 13
        Caption = 'Gender'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object Label8: TLabel
        Left = 7
        Top = 65
        Width = 61
        Height = 13
        Caption = 'Homepage'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object Label21: TLabel
        Left = 7
        Top = 91
        Width = 40
        Height = 13
        Caption = 'Lang 1'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object Label22: TLabel
        Left = 7
        Top = 117
        Width = 40
        Height = 13
        Caption = 'Lang 2'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object Label23: TLabel
        Left = 7
        Top = 143
        Width = 40
        Height = 13
        Caption = 'Lang 3'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object Label4: TLabel
        Left = 202
        Top = 13
        Width = 47
        Height = 13
        Caption = 'Birthday'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object HomepageLabel: TLabel
        Left = 72
        Top = 65
        Width = 78
        Height = 13
        Caption = 'HomepageLabel'
      end
      object GenderLabel: TLabel
        Left = 72
        Top = 39
        Width = 61
        Height = 13
        Caption = 'GenderLabel'
      end
      object AgeLabel: TLabel
        Left = 72
        Top = 13
        Width = 45
        Height = 13
        Caption = 'AgeLabel'
      end
      object BirthdayLabel: TLabel
        Left = 254
        Top = 13
        Width = 64
        Height = 13
        Caption = 'BirthdayLabel'
      end
      object Lang1Label: TLabel
        Left = 72
        Top = 91
        Width = 56
        Height = 13
        Caption = 'Lang1Label'
      end
      object Lang2Label: TLabel
        Left = 72
        Top = 117
        Width = 56
        Height = 13
        Caption = 'Lang2Label'
      end
      object Lang3Label: TLabel
        Left = 72
        Top = 143
        Width = 56
        Height = 13
        Caption = 'Lang3Label'
      end
      object Loading2Label: TLabel
        Left = 377
        Top = 221
        Width = 70
        Height = 13
        Caption = 'Loading . . .'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clRed
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
    end
    object TabSheet3: TTabSheet
      Caption = 'Work'
      ImageIndex = 2
      object Loading3Label: TLabel
        Left = 377
        Top = 221
        Width = 70
        Height = 13
        Caption = 'Loading . . .'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clRed
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object Label27: TLabel
        Left = 7
        Top = 13
        Width = 22
        Height = 13
        Caption = 'City'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object WCityLabel: TLabel
        Left = 59
        Top = 13
        Width = 43
        Height = 13
        Caption = 'CityLabel'
      end
      object Label29: TLabel
        Left = 7
        Top = 39
        Width = 31
        Height = 13
        Caption = 'State'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object WStateLabel: TLabel
        Left = 59
        Top = 39
        Width = 51
        Height = 13
        Caption = 'StateLabel'
      end
      object Label31: TLabel
        Left = 7
        Top = 65
        Width = 37
        Height = 13
        Caption = 'Phone'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object WPhoneLabel: TLabel
        Left = 59
        Top = 65
        Width = 57
        Height = 13
        Caption = 'PhoneLabel'
      end
      object Label33: TLabel
        Left = 7
        Top = 91
        Width = 21
        Height = 13
        Caption = 'Fax'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object WFaxLabel: TLabel
        Left = 59
        Top = 91
        Width = 43
        Height = 13
        Caption = 'FaxLabel'
      end
      object Label35: TLabel
        Left = 7
        Top = 117
        Width = 27
        Height = 13
        Caption = 'Addr'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object WAddrLabel: TLabel
        Left = 59
        Top = 117
        Width = 48
        Height = 13
        Caption = 'AddrLabel'
      end
      object Label37: TLabel
        Left = 7
        Top = 143
        Width = 19
        Height = 13
        Caption = 'Zip'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object WZipLabel: TLabel
        Left = 59
        Top = 143
        Width = 41
        Height = 13
        Caption = 'ZipLabel'
      end
      object Label6: TLabel
        Left = 7
        Top = 169
        Width = 44
        Height = 13
        Caption = 'Country'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object WCountryLabel: TLabel
        Left = 59
        Top = 169
        Width = 62
        Height = 13
        Caption = 'CountryLabel'
      end
      object Label25: TLabel
        Left = 202
        Top = 13
        Width = 52
        Height = 13
        Caption = 'Company'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object WCompanyLabel: TLabel
        Left = 280
        Top = 13
        Width = 43
        Height = 13
        Caption = 'CityLabel'
      end
      object Label39: TLabel
        Left = 202
        Top = 39
        Width = 66
        Height = 13
        Caption = 'Department'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object Label40: TLabel
        Left = 202
        Top = 65
        Width = 21
        Height = 13
        Caption = 'Job'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object Label41: TLabel
        Left = 202
        Top = 91
        Width = 66
        Height = 13
        Caption = 'Occupation'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object Label42: TLabel
        Left = 202
        Top = 117
        Width = 61
        Height = 13
        Caption = 'Homepage'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object WDepartmentLabel: TLabel
        Left = 280
        Top = 39
        Width = 92
        Height = 13
        Caption = 'WDepartmentLabel'
      end
      object WJobLabel: TLabel
        Left = 280
        Top = 65
        Width = 54
        Height = 13
        Caption = 'WJobLabel'
      end
      object WOccupationLabel: TLabel
        Left = 280
        Top = 91
        Width = 92
        Height = 13
        Caption = 'WOccupationLabel'
      end
      object WHomepageLabel: TLabel
        Left = 280
        Top = 117
        Width = 89
        Height = 13
        Caption = 'WHomepageLabel'
      end
    end
    object TabSheet4: TTabSheet
      Caption = 'Interests'
      ImageIndex = 3
      object Loading4Label: TLabel
        Left = 377
        Top = 221
        Width = 70
        Height = 13
        Caption = 'Loading . . .'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clRed
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object Label26: TLabel
        Left = 7
        Top = 13
        Width = 51
        Height = 13
        Caption = 'Category'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object Label28: TLabel
        Left = 202
        Top = 13
        Width = 44
        Height = 13
        Caption = 'Interest'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object ICategory0Label: TLabel
        Left = 20
        Top = 39
        Width = 77
        Height = 13
        Caption = 'ICategory0Label'
      end
      object ICategory1Label: TLabel
        Left = 20
        Top = 65
        Width = 77
        Height = 13
        Caption = 'ICategory1Label'
      end
      object ICategory2Label: TLabel
        Left = 20
        Top = 91
        Width = 77
        Height = 13
        Caption = 'ICategory2Label'
      end
      object ICategory3Label: TLabel
        Left = 20
        Top = 117
        Width = 77
        Height = 13
        Caption = 'ICategory3Label'
      end
      object Interest0Label: TLabel
        Left = 221
        Top = 39
        Width = 67
        Height = 13
        Caption = 'Interest0Label'
      end
      object Interest1Label: TLabel
        Left = 221
        Top = 65
        Width = 67
        Height = 13
        Caption = 'Interest1Label'
      end
      object Interest2Label: TLabel
        Left = 221
        Top = 91
        Width = 67
        Height = 13
        Caption = 'Interest2Label'
      end
      object Interest3Label: TLabel
        Left = 221
        Top = 117
        Width = 67
        Height = 13
        Caption = 'Interest3Label'
      end
    end
    object TabSheet5: TTabSheet
      Caption = 'Affiliations'
      ImageIndex = 4
      object Loading5Label: TLabel
        Left = 377
        Top = 221
        Width = 70
        Height = 13
        Caption = 'Loading . . .'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clRed
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object Label46: TLabel
        Left = 7
        Top = 13
        Width = 51
        Height = 13
        Caption = 'Category'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object ACategory0Label: TLabel
        Left = 20
        Top = 33
        Width = 77
        Height = 13
        Caption = 'ICategory0Label'
      end
      object Label48: TLabel
        Left = 202
        Top = 13
        Width = 54
        Height = 13
        Caption = 'Affiliation'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object Affiliation0Label: TLabel
        Left = 221
        Top = 33
        Width = 67
        Height = 13
        Caption = 'Interest0Label'
      end
      object Affiliation1Label: TLabel
        Left = 221
        Top = 52
        Width = 67
        Height = 13
        Caption = 'Interest1Label'
      end
      object Affiliation2Label: TLabel
        Left = 221
        Top = 72
        Width = 67
        Height = 13
        Caption = 'Interest2Label'
      end
      object Affiliation3Label: TLabel
        Left = 221
        Top = 91
        Width = 67
        Height = 13
        Caption = 'Interest3Label'
      end
      object ACategory3Label: TLabel
        Left = 20
        Top = 91
        Width = 77
        Height = 13
        Caption = 'ICategory3Label'
      end
      object ACategory2Label: TLabel
        Left = 20
        Top = 72
        Width = 77
        Height = 13
        Caption = 'ICategory2Label'
      end
      object ACategory1Label: TLabel
        Left = 20
        Top = 52
        Width = 77
        Height = 13
        Caption = 'ICategory1Label'
      end
      object Label56: TLabel
        Left = 7
        Top = 117
        Width = 51
        Height = 13
        Caption = 'Category'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object Label57: TLabel
        Left = 202
        Top = 117
        Width = 26
        Height = 13
        Caption = 'Past'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object PCategory0Label: TLabel
        Left = 20
        Top = 137
        Width = 77
        Height = 13
        Caption = 'ICategory0Label'
      end
      object PCategory1Label: TLabel
        Left = 20
        Top = 156
        Width = 77
        Height = 13
        Caption = 'ICategory1Label'
      end
      object PCategory2Label: TLabel
        Left = 20
        Top = 176
        Width = 77
        Height = 13
        Caption = 'ICategory2Label'
      end
      object PCategory3Label: TLabel
        Left = 20
        Top = 195
        Width = 77
        Height = 13
        Caption = 'ICategory3Label'
      end
      object Past0Label: TLabel
        Left = 221
        Top = 137
        Width = 67
        Height = 13
        Caption = 'Interest0Label'
      end
      object Past1Label: TLabel
        Left = 221
        Top = 156
        Width = 67
        Height = 13
        Caption = 'Interest1Label'
      end
      object Past2Label: TLabel
        Left = 221
        Top = 176
        Width = 67
        Height = 13
        Caption = 'Interest2Label'
      end
      object Past3Label: TLabel
        Left = 221
        Top = 195
        Width = 67
        Height = 13
        Caption = 'Interest3Label'
      end
    end
    object TabSheet6: TTabSheet
      Caption = 'About'
      ImageIndex = 5
      object Label24: TLabel
        Left = 7
        Top = 13
        Width = 34
        Height = 13
        Caption = 'About'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object AboutLabel: TLabel
        Left = 52
        Top = 13
        Width = 54
        Height = 13
        Caption = 'AboutLabel'
      end
      object Loading6Label: TLabel
        Left = 377
        Top = 221
        Width = 70
        Height = 13
        Caption = 'Loading . . .'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clRed
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
    end
  end
end
