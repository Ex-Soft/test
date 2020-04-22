declare	@msg_stringMax nvarchar(max) = N'test formatmessage() ''%s'''
declare	@msg_string4000 nvarchar(4000) = N'test formatmessage() ''%s'''
print formatmessage(@msg_stringMax, N'blah-blah-blah')
print formatmessage(@msg_string4000, N'blah-blah-blah')
print formatmessage(N'test formatmessage() ''%s''', N'blah-blah-blah')