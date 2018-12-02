//https://www.codeproject.com/Articles/3778/Introduction-to-IL-Assembly-Language
//Add.il
//Add Two Numbers

.assembly extern mscorlib {}

.assembly Add
{
    .ver 1:0:1:0
}
.module add.exe

.method static void main() cil managed
{
    .maxstack 2
    .entrypoint
    
    ldstr "The sum of 50 and 30 is = "
    call void [mscorlib]System.Console::Write (string)
    
    ldc.i4.s 50
    ldc.i4 30    
    add
    call void [mscorlib]System.Console::Write (int32)
    ret
}
