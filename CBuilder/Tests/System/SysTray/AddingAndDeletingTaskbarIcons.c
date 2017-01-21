Adding and Deleting Taskbar Icons

You add an icon to the taskbar status area by filling a NOTIFYICONDATA structure and then sending the structure through the NIM_ADD message. The structure members must specify the handle of the window that is adding the icon, as well as the icon identifier and icon handle. You can also specify ToolTip text for the icon. If you need to receive mouse messages for the icon, specify the identifier of the callback message that the system should use to send the message to the window procedure. 

The function in the following example demonstrates how to add an icon to the taskbar.

// MyTaskBarAddIcon - adds an icon to the taskbar status area.  
// Returns TRUE if successful or FALSE otherwise. 
// hwnd - handle of the window to receive callback messages 
// uID - identifier of the icon 
// hicon - handle of the icon to add 
// lpszTip - ToolTip text 
BOOL MyTaskBarAddIcon(HWND hwnd, UINT uID, HICON hicon, LPSTR lpszTip) 
{ 
    BOOL res; 
    NOTIFYICONDATA tnid; 
 
    tnid.cbSize = sizeof(NOTIFYICONDATA); 
    tnid.hWnd = hwnd; 
    tnid.uID = uID; 

    tnid.uFlags = NIF_MESSAGE | NIF_ICON | NIF_TIP; 
    tnid.uCallbackMessage = MYWM_NOTIFYICON; 
    tnid.hIcon = hicon; 
    if (lpszTip) 
        lstrcpyn(tnid.szTip, lpszTip, sizeof(tnid.szTip)); 
    else 
        tnid.szTip[0] = '\0'; 
 
    res = Shell_NotifyIcon(NIM_ADD, &tnid); 
 
    if (hicon) 
        DestroyIcon(hicon); 
 
    return res; 
} 
 

To delete an icon from the taskbar status area, fill a NOTIFYICONDATA structure and send it to the system when you send a NIM_DELETE message. When deleting a taskbar icon, specify only the cbSize, hWnd, and uID members, as the following example shows.

// MyTaskBarDeleteIcon - deletes an icon from the taskbar  
//     status area. 
// Returns TRUE if successful or FALSE otherwise. 
// hwnd - handle of the window that added the icon 
// uID - identifier of the icon to delete 
BOOL MyTaskBarDeleteIcon(HWND hwnd, UINT uID) 
{ 
    BOOL res; 
    NOTIFYICONDATA tnid; 
 
    tnid.cbSize = sizeof(NOTIFYICONDATA); 
    tnid.hWnd = hwnd; 
    tnid.uID = uID; 
         
    res = Shell_NotifyIcon(NIM_DELETE, &tnid); 

    return res; 
} 
 

