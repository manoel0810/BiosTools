#include <stdio.h>

extern "C" long bios_size();

__asm__(
        "bios_size:\n"
        "mov eax, e820h\n"
        "int 15h\n"
        "ret ebx"
    );


long getBiosLenghth(){
    return bios_size();
}

//TODO: Obter o handler da flag com o
//exito do __asm__(args x86);

int main(){
    printf("%s", getBiosLenghth());
    return 0; // ? teve sucesso
}
