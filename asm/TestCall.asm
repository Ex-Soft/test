                TITLE   TEST_CALL

_STACK          SEGMENT WORD STACK 'STACK'
                DW      16 DUP (?)
_STACK          ENDS

_DATA           SEGMENT WORD 'DATA'
_DATA           ENDS

_TEXT           SEGMENT word 'CODE'
begin           proc    far
                assume  cs:_TEXT,ds:_DATA,ss:_STACK,es:nothing
                PUSH    DS
                xor     ax,ax
                push    ax
                mov     ax,_DATA
                MOV     DS,AX
                
                mov	ax, 0abcdh
                push	ax
                call	subproc

                RET
begin           endp

subproc		proc	near
		push	bp
		
		mov	bp, sp
		mov	bx, [bp + 04h]
		and	bx, 010101b
		
		pop	bp
		ret	2
subproc		endp

_TEXT           ends
                end     begin
