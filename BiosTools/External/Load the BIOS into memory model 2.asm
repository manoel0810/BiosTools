; Load the BIOS into memory
mov ax, 0x0000
mov ds, ax
mov es, ax
mov si, 0xF000
mov di, 0x0000
mov cx, 0x1000
cld
rep movsb

; Save the BIOS to a file
mov ah, 0x3C ; DOS function 3C - Create/Open file
mov al, 0x00 ; Open for writing
mov dx, offset filename ; Filename in DS:DX
int 0x21 ; Call DOS
jc error ; Jump if carry flag set (error)
mov bx, ax ; Save file handle in BX

; Write the BIOS to the file
mov ah, 0x40 ; DOS function 40 - Write to file/device
int 15h, AX=e820h ; get bios lenght into ebx

mov cx, ebx ; Number of bytes to write (1K)
mov dx, 0x0000 ; Offset of BIOS in memory (DS:DX)
int 0x21 ; Call DOS
jc error ; Jump if carry flag set (error)

; Close the file and exit
mov ah, 0x3E ; DOS function 3E - Close file handle 
int 0x21 ; Call DOS 
jmp exit ; Jump to exit label 
error: 
    mov ah, 0x4C ; DOS function 4C - Terminate with error code 
    int 0x21 ; Call DOS 
exit: 

    mov ax, 0x4C00 ; DOS function 4C - Terminate with return code 
    int 0x21 ; Call DOS