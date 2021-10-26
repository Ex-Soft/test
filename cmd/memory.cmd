rem https://www.windowscentral.com/how-get-full-memory-specs-speed-size-type-part-number-form-factor-windows-10

rem Check memory manufacturer
wmic memorychip get devicelocator, manufacturer

rem Check memory part number
wmic memorychip get devicelocator, partnumber

rem Check memory serial number
wmic memorychip get devicelocator, serialnumber

rem Check memory capacity
wmic memorychip get devicelocator, capacity

rem Determine total system memory capacity
systeminfo | findstr /C:"Total Physical Memory"

rem Check memory speed
wmic memorychip get devicelocator, speed

rem Check memory type
wmic memorychip get devicelocator, memorytype

rem Check memory form factor
wmic memorychip get devicelocator, formfactor

rem Check all memory details
wmic memorychip list full
wmic memorychip get devicelocator, manufacturer, partnumber, serialnumber, capacity, speed, memorytype, formfactor