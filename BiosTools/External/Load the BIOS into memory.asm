; Load the BIOS into memory
mov ax, 0x0000
mov ds, ax
mov es, ax
mov si, 0xF000
mov di, 0x0000
mov cx, 0x1000
cld
rep movsb

; Save the BIOS to disk
mov ax, 0x0300
mov bx, 0x0001
mov cx, 0x1000
mov dx, 0x0000
int 0x13
jc error_handler ; Jump to error handler if an error occurs

; Load the firmware into memory
mov ax, 0x0000
mov ds, ax
mov es, ax
mov si, 0xF000
mov di, 0x1000
mov cx, 0x1000
cld
rep movsb

; Save the firmware to disk 
mov ax, 0x0300 
mov bx, 0x0001 
mov cx, 0x1000 
mov dx, 0x1000 
int 0x13 
jc error_handler ; Jump to error handler if an error occurs 

 ; Exit program 
 mov ax, 0x4C00 
 int 0x21