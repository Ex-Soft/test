@echo off
if exist arc\*.arj del arc\*.arj
arj u -x*.cgl arc\test_dll *.c* *.h* *.dfm *.bp? *.res