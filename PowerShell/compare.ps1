(Get-FileHash "C:\path\to\your\firstfile.bin").Hash -eq (Get-FileHash "C:\path\to\your\secondfile.bin").Hash
