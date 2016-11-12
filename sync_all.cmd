@echo off
for %%i in (vc vb.net vb sql pics js javascript java html c# cmd asp.net typescript) do call %~dp0sync x d %%i
