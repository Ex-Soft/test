stdin   equ     0               ; standard input handle
stdout  equ     1               ; standard output handle
stderr  equ     2               ; standard error handle

cr      equ     0dh             ; ASCII carriage return
lf      equ     0ah             ; ASCII linefeed


_TEXT   segment word public 'CODE'

          org     100h            ; .COM files always have
                                  ; an origin of 100h

          assume  cs:_TEXT,ds:_TEXT,es:_TEXT,ss:_TEXT

  print   proc    near            ; entry point from MS-DOS

          mov     ah,40h          ; function 40h = write
          mov     bx,stdout       ; handle for standard output
          mov     cx,msg_len      ; length of message
          mov     dx,offset msg   ; address of message
          int     21h             ; transfer to MS-DOS

          mov     ax,4c00h        ; exit, return code = 0
          int     21h             ; transfer to MS-DOS

  print   endp


  msg     db      cr,lf           ; message to display
          db      'Hello World!',cr,lf

  msg_len equ     $-msg           ; length of message


  _TEXT   ends

          end     print