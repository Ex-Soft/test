declare
  @SUCCESS bit

exec @SUCCESS=sp_send_cdosysmail @From='nozhenko-i@foxtrot.com.ua', @To='380972514722@2sms.kyivstar.net', @Subject='Subject', @Body='Body'

select @SUCCESS /* 0 == success*/