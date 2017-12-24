.386
.model flat, stdcall
.stack 4096

ExitProcess proto, dwExitCode:dword

.code
main	proc

	push	0abcdh
	call	subproc
	add		esp, 4
	
	invoke	ExitProcess, 0
main	endp

subproc	proc	near
	push	ebp
	mov		ebp, esp
	
	mov		eax, [ebp + 08h]
	and		eax, 010101b

	pop		ebp
	ret
subproc	endp

end main
