//https://www.codeproject.com/Articles/3778/Introduction-to-IL-Assembly-Language
//Methods.il
//Creating Methods

.assembly extern mscorlib {}

.assembly Methods
{
    .ver 1:0:1:0
}
.module Methods.exe

.method static void main() cil managed
{
    .maxstack 2
    .entrypoint
    
    ldc.i4 10
    ldc.i4 20
	//ldc.i4 30 // Unhandled Exception: System.InvalidProgramException: Common Language Runtime detected an invalid program. at main()
    call int32 DoSum(int32, int32)
    call void PrintSum(int32)
    ret
}

.method public static int32 DoSum (int32 , int32 ) cil managed
{
    .maxstack 2    
    
    ldarg.0
    ldarg.1
    add
    
    ret
}

.method public static void PrintSum(int32) cil managed
{
    .maxstack 2
    ldstr "The Result is : "
    call void [mscorlib]System.Console::Write(string)
    
    ldarg.0
    call void [mscorlib]System.Console::Write(int32)
    
    ret
}
