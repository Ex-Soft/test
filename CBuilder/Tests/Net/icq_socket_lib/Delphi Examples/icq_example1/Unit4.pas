unit Unit4;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms,
  Dialogs, ComCtrls, ExtCtrls, StdCtrls, ICQSocket, ICQ_Type_pas;

type
  TMetaInfoForm = class(TForm)
    Panel1: TPanel;
    PageControl1: TPageControl;
    TabSheet1: TTabSheet;
    TabSheet2: TTabSheet;
    TabSheet3: TTabSheet;
    TabSheet4: TTabSheet;
    TabSheet5: TTabSheet;
    Label1: TLabel;
    NickLabel: TLabel;
    Label3: TLabel;
    FirstLabel: TLabel;
    Label5: TLabel;
    LastLabel: TLabel;
    Label7: TLabel;
    EmailLabel: TLabel;
    Label9: TLabel;
    Label10: TLabel;
    Label11: TLabel;
    Label12: TLabel;
    Label13: TLabel;
    Label14: TLabel;
    Label15: TLabel;
    Label16: TLabel;
    Label17: TLabel;
    Label18: TLabel;
    Label19: TLabel;
    Label20: TLabel;
    Loading1Label: TLabel;
    AddrLabel: TLabel;
    CellLabel: TLabel;
    CountryLabel: TLabel;
    AuthLabel: TLabel;
    TimeLabel: TLabel;
    ZipLabel: TLabel;
    FaxLabel: TLabel;
    PhoneLabel: TLabel;
    StateLabel: TLabel;
    CityLabel: TLabel;
    WebLabel: TLabel;
    HideLabel: TLabel;
    Label2: TLabel;
    UINLabel: TLabel;
    Label99: TLabel;
    Label78: TLabel;
    Label8: TLabel;
    Label21: TLabel;
    Label22: TLabel;
    Label23: TLabel;
    Label4: TLabel;
    HomepageLabel: TLabel;
    GenderLabel: TLabel;
    AgeLabel: TLabel;
    BirthdayLabel: TLabel;
    Lang1Label: TLabel;
    Lang2Label: TLabel;
    Lang3Label: TLabel;
    Loading3Label: TLabel;
    Loading4Label: TLabel;
    Loading2Label: TLabel;
    Loading5Label: TLabel;
    Label27: TLabel;
    WCityLabel: TLabel;
    Label29: TLabel;
    WStateLabel: TLabel;
    Label31: TLabel;
    WPhoneLabel: TLabel;
    Label33: TLabel;
    WFaxLabel: TLabel;
    Label35: TLabel;
    WAddrLabel: TLabel;
    Label37: TLabel;
    WZipLabel: TLabel;
    Label6: TLabel;
    WCountryLabel: TLabel;
    Label25: TLabel;
    WCompanyLabel: TLabel;
    Label39: TLabel;
    Label40: TLabel;
    Label41: TLabel;
    Label42: TLabel;
    WDepartmentLabel: TLabel;
    WJobLabel: TLabel;
    WOccupationLabel: TLabel;
    WHomepageLabel: TLabel;
    LoadingLabel: TLabel;
    TabSheet6: TTabSheet;
    Label24: TLabel;
    AboutLabel: TLabel;
    Loading6Label: TLabel;
    Label26: TLabel;
    Label28: TLabel;
    ICategory0Label: TLabel;
    ICategory1Label: TLabel;
    ICategory2Label: TLabel;
    ICategory3Label: TLabel;
    Interest0Label: TLabel;
    Interest1Label: TLabel;
    Interest2Label: TLabel;
    Interest3Label: TLabel;
    Label46: TLabel;
    ACategory0Label: TLabel;
    Label48: TLabel;
    Affiliation0Label: TLabel;
    Affiliation1Label: TLabel;
    Affiliation2Label: TLabel;
    Affiliation3Label: TLabel;
    ACategory3Label: TLabel;
    ACategory2Label: TLabel;
    ACategory1Label: TLabel;
    Label56: TLabel;
    Label57: TLabel;
    PCategory0Label: TLabel;
    PCategory1Label: TLabel;
    PCategory2Label: TLabel;
    PCategory3Label: TLabel;
    Past0Label: TLabel;
    Past1Label: TLabel;
    Past2Label: TLabel;
    Past3Label: TLabel;
  private
    { Private declarations }
  public
    { Public declarations }

    procedure SetEventTo(ICQ: TICQSocket);
    procedure ResetInfo(UIN: DWORD);
    procedure ChangeLoading;

    procedure ICQSocketUserNotFound(Sender: TObject; UIN: DWORD);
    procedure ICQSocketMetaUserAbout(Sender: TObject;
      const About: String);
    procedure ICQSocketMetaUserAffiliations(Sender: TObject; Num,
      Cat1: Cardinal; const Aff1: String; Cat2: Cardinal; const Aff2: String;
      Cat3: Cardinal; const Aff3: String; Cat4: Cardinal; const Aff4: String;
      BNum, BCat1: Cardinal; const BAck1: String; BCat2: Cardinal;
      const BAck2: String; BCat3: Cardinal; const BAck3: String;
      BCat4: Cardinal; const BAck4: String);
    procedure ICQSocketMetaUserInfo2(Sender: TObject; const Nick,
      First, Last, PriEml, SecEml, OldEml, City, State, Phone, Fax, Street,
      Cellular: String; Zip, Country: Cardinal; TimeOffset: Single;
      Auth: ICQ_Auth; Web, HideIp: Boolean);
    procedure ICQSocketMetaUserInterests(Sender: TObject; Num,
      Cat1: Cardinal; const Int1: String; Cat2: Cardinal; const Int2: String;
      Cat3: Cardinal; const Int3: String; Cat4: Cardinal; const Int4: String);
    procedure ICQSocketMetaUserMore(Sender: TObject; Age: Cardinal;
      Gender: ICQ_Gender; const HomePage: String; BDate: TDateTime; Lang1,
      Lang2, Lang3: Cardinal);
    procedure ICQSocketMetaUserWork(Sender: TObject; const City,
      State, Phone, Fax, Address: String; Zip, Country: Cardinal;
      const Company, Department, Job: String; Occupation: Cardinal;
      const HomePage: String);

  end;

implementation

{$R *.dfm}

Uses ICQ_Socket_pas;

const
  LoadingStr: string = 'Loading . . .';

function GetAuthStr(Auth: ICQ_Auth): string;
begin
  if Auth = ICQ_Auth_Authorize then
    Result := 'Need authorize' else
    Result := 'Trust';
end;

function GetGenderStr(Gender: ICQ_Gender): string;
begin
  case Gender of
    ICQ_Gender_Void: Result := 'Not entered';
    ICQ_Gender_Female: Result := 'Female';
    ICQ_Gender_Male: Result := 'Male';
  end;
end;

function GetBoolStr(Value: Boolean): string;
begin
  if Value then
    Result := 'True' else
    Result := 'False';
end;

function GetDateStr(Value: TDateTime): string;
begin
  if Value = ICQ_VoidDate then
    Result := '--/--/----' else
    Result := FormatDateTime('dd/mm/yyyy',Value);
end;

procedure TMetaInfoForm.SetEventTo(ICQ: TICQSocket);
begin
  ICQ.OnUserNotFound := ICQSocketUserNotFound;
  ICQ.OnMetaUserAbout := ICQSocketMetaUserAbout;
  ICQ.OnMetaUserAffiliations := ICQSocketMetaUserAffiliations;
  ICQ.OnMetaUserInfo2 := ICQSocketMetaUserInfo2;
  ICQ.OnMetaUserInterests := ICQSocketMetaUserInterests;
  ICQ.OnMetaUserMore := ICQSocketMetaUserMore;
  ICQ.OnMetaUserWork := ICQSocketMetaUserWork;
end;

procedure TMetaInfoForm.ChangeLoading;
begin
  if (Loading1Label.Caption <> '') or
     (Loading2Label.Caption <> '') or
     (Loading3Label.Caption <> '') or
     (Loading4Label.Caption <> '') or
     (Loading5Label.Caption <> '') or
     (Loading6Label.Caption <> '')
  then
    LoadingLabel.Caption := LoadingStr else
    LoadingLabel.Caption := '';
end;

procedure TMetaInfoForm.ResetInfo(UIN: DWORD);
begin
//  TabSheet1.SetFocus;
  UINLabel.Caption := Format('%d',[UIN]);
  LoadingLabel.Caption := LoadingStr;

  NickLabel.Caption := '';
  FirstLabel.Caption := '';
  LastLabel.Caption := '';
  EmailLabel.Caption := '';
  AddrLabel.Caption := '';
  CellLabel.Caption := '';
  CountryLabel.Caption := '';
  AuthLabel.Caption := '';
  CityLabel.Caption := '';
  StateLabel.Caption := '';
  PhoneLabel.Caption := '';
  FaxLabel.Caption := '';
  ZipLabel.Caption := '';
  TimeLabel.Caption := '';
  WebLabel.Caption := '';
  HideLabel.Caption := '';
  Loading1Label.Caption := LoadingStr;

  AgeLabel.Caption := '';
  GenderLabel.Caption := '';
  HomepageLabel.Caption := '';
  Lang1Label.Caption := '';
  Lang2Label.Caption := '';
  Lang3Label.Caption := '';
  BirthdayLabel.Caption := '';
  Loading2Label.Caption := LoadingStr;

  WCityLabel.Caption := '';
  WStateLabel.Caption := '';
  WPhoneLabel.Caption := '';
  WFaxLabel.Caption := '';
  WAddrLabel.Caption := '';
  WZipLabel.Caption := '';
  WCountryLabel.Caption := '';
  WCompanyLabel.Caption := '';
  WDepartmentLabel.Caption := '';
  WJobLabel.Caption := '';
  WOccupationLabel.Caption := '';
  WHomepageLabel.Caption := '';
  Loading3Label.Caption := LoadingStr;

  ICategory0Label.Caption := '';
  ICategory1Label.Caption := '';
  ICategory2Label.Caption := '';
  ICategory3Label.Caption := '';
  Interest0Label.Caption := '';
  Interest1Label.Caption := '';
  Interest2Label.Caption := '';
  Interest3Label.Caption := '';
  Loading4Label.Caption := LoadingStr;

  ACategory0Label.Caption := '';
  ACategory1Label.Caption := '';
  ACategory2Label.Caption := '';
  ACategory3Label.Caption := '';
  Affiliation0Label.Caption := '';
  Affiliation1Label.Caption := '';
  Affiliation2Label.Caption := '';
  Affiliation3Label.Caption := '';
  PCategory0Label.Caption := '';
  PCategory1Label.Caption := '';
  PCategory2Label.Caption := '';
  PCategory3Label.Caption := '';
  Past0Label.Caption := '';
  Past1Label.Caption := '';
  Past2Label.Caption := '';
  Past3Label.Caption := '';
  Loading5Label.Caption := LoadingStr;

  AboutLabel.Caption := '';
  Loading6Label.Caption := LoadingStr;
end;

procedure TMetaInfoForm.ICQSocketUserNotFound(Sender: TObject; UIN: DWORD);
begin
  Loading1Label.Caption := '';
  Loading2Label.Caption := '';
  Loading3Label.Caption := '';
  Loading4Label.Caption := '';
  Loading5Label.Caption := '';
  Loading6Label.Caption := '';
  ChangeLoading;
  MessageBox(0,PChar(Format('Пользователей %d не найден!',[UIN])),nil,MB_OK);
end;

procedure TMetaInfoForm.ICQSocketMetaUserAbout(Sender: TObject;
  const About: String);
begin
  AboutLabel.Caption := About;
  Loading6Label.Caption := '';
  ChangeLoading;
end;

procedure TMetaInfoForm.ICQSocketMetaUserAffiliations(Sender: TObject; Num,
  Cat1: Cardinal; const Aff1: String; Cat2: Cardinal; const Aff2: String;
  Cat3: Cardinal; const Aff3: String; Cat4: Cardinal; const Aff4: String;
  BNum, BCat1: Cardinal; const BAck1: String; BCat2: Cardinal;
  const BAck2: String; BCat3: Cardinal; const BAck3: String;
  BCat4: Cardinal; const BAck4: String);
begin
  ACategory0Label.Caption := ICQ_GetAffiliation(Cat1);
  ACategory1Label.Caption := ICQ_GetAffiliation(Cat2);
  ACategory2Label.Caption := ICQ_GetAffiliation(Cat3);
  ACategory3Label.Caption := ICQ_GetAffiliation(Cat4);
  Affiliation0Label.Caption := Aff1;
  Affiliation1Label.Caption := Aff2;
  Affiliation2Label.Caption := Aff3;
  Affiliation3Label.Caption := Aff4;
  PCategory0Label.Caption := ICQ_GetBackground(BCat1);
  PCategory1Label.Caption := ICQ_GetBackground(BCat2);
  PCategory2Label.Caption := ICQ_GetBackground(BCat3);
  PCategory3Label.Caption := ICQ_GetBackground(BCat4);
  Past0Label.Caption := BAck1;
  Past1Label.Caption := BAck2;
  Past2Label.Caption := BAck3;
  Past3Label.Caption := BAck4;
  Loading5Label.Caption := '';
  ChangeLoading;
end;

procedure TMetaInfoForm.ICQSocketMetaUserInfo2(Sender: TObject; const Nick,
  First, Last, PriEml, SecEml, OldEml, City, State, Phone, Fax, Street,
  Cellular: String; Zip, Country: Cardinal; TimeOffset: Single;
  Auth: ICQ_Auth; Web, HideIp: Boolean);
begin
  NickLabel.Caption := Nick;
  FirstLabel.Caption := First;
  LastLabel.Caption := Last;
  EmailLabel.Caption := PriEml;
  AddrLabel.Caption := Street;
  CellLabel.Caption := Cellular;
  CountryLabel.Caption := ICQ_GetCountry(Country);
  AuthLabel.Caption := GetAuthStr(Auth);
  CityLabel.Caption := City;
  StateLabel.Caption := State;
  PhoneLabel.Caption := Phone;
  FaxLabel.Caption := Fax;
  ZipLabel.Caption := Format('%d',[Zip]);
  TimeLabel.Caption := Format('%f',[TimeOffset]);
  WebLabel.Caption := GetBoolStr(Web);
  HideLabel.Caption := GetBoolStr(HideIp);
  Loading1Label.Caption := '';
  ChangeLoading;
end;

procedure TMetaInfoForm.ICQSocketMetaUserInterests(Sender: TObject; Num,
  Cat1: Cardinal; const Int1: String; Cat2: Cardinal; const Int2: String;
  Cat3: Cardinal; const Int3: String; Cat4: Cardinal; const Int4: String);
begin
  ICategory0Label.Caption := ICQ_GetInterest(Cat1);
  ICategory1Label.Caption := ICQ_GetInterest(Cat2);
  ICategory2Label.Caption := ICQ_GetInterest(Cat3);
  ICategory3Label.Caption := ICQ_GetInterest(Cat4);
  Interest0Label.Caption := Int1;
  Interest1Label.Caption := Int2;
  Interest2Label.Caption := Int3;
  Interest3Label.Caption := Int4;
  Loading4Label.Caption := '';
  ChangeLoading;
end;

procedure TMetaInfoForm.ICQSocketMetaUserMore(Sender: TObject; Age: Cardinal;
  Gender: ICQ_Gender; const HomePage: String; BDate: TDateTime; Lang1,
  Lang2, Lang3: Cardinal);
begin
  AgeLabel.Caption := Format('%d',[Age]);
  GenderLabel.Caption := GetGenderStr(Gender);
  HomepageLabel.Caption := HomePage;
  Lang1Label.Caption := ICQ_GetLanguage(Lang1);
  Lang2Label.Caption := ICQ_GetLanguage(Lang2);
  Lang3Label.Caption := ICQ_GetLanguage(Lang3);
  BirthdayLabel.Caption := GetDateStr(BDate);
  Loading2Label.Caption := '';
  ChangeLoading;
end;

procedure TMetaInfoForm.ICQSocketMetaUserWork(Sender: TObject; const City,
  State, Phone, Fax, Address: String; Zip, Country: Cardinal;
  const Company, Department, Job: String; Occupation: Cardinal;
  const HomePage: String);
begin
  WCityLabel.Caption := City;
  WStateLabel.Caption := State;
  WPhoneLabel.Caption := Phone;
  WFaxLabel.Caption := Fax;
  WAddrLabel.Caption := Address;
  WZipLabel.Caption := Format('%d',[Zip]);
  WCountryLabel.Caption := ICQ_GetCountry(Country);
  WCompanyLabel.Caption := Company;
  WDepartmentLabel.Caption := Department;
  WJobLabel.Caption := Job;
  WOccupationLabel.Caption := ICQ_GetOccupation(Occupation);
  WHomepageLabel.Caption := HomePage;
  Loading3Label.Caption := '';
  ChangeLoading;
end;

end.
