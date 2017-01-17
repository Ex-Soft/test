                TITLE   TEST_CALL

_STACK          SEGMENT WORD STACK 'STACK'
                DW      16 DUP (?)
_STACK          ENDS

_DATA           SEGMENT WORD 'DATA'
var1		dw	(?)
var2		dw	(?)
_DATA           ENDS

_TEXT           SEGMENT word 'CODE'
begin           proc    far
                assume  cs:_TEXT,ds:_DATA,ss:_STACK,es:nothing
                PUSH    DS
                xor     ax,ax
                push    ax
                mov     ax,_DATA
                MOV     DS,AX

		mov	al, 101b
		mov	ah, 0ah
		
		mov	word ptr var1, 0102h
		mov	word ptr var2, 0304h
		
		mov	bx, word ptr var1
		mov	cx, word ptr var2
		
		mov	ax, 2
		mov	bx, 3
		cmp	ax, bx
		je	e
		mov	cx, 0ah
		
e:		mov	cx, 0eh
		
                RET
begin           endp
_TEXT           ends
                end     begin
