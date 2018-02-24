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
    .locals init (int32, int32)
    
    ldc.i4 10
    stloc.0
    ldc.i4 20
    stloc.1
    
    ldloca 0          //Loads the address of first local variable 
    ldloc.1 //Loads the value of Second Local Variable
    call void DoSum(int32 &, int32 )
    ldloc.0
    //Load First variable again, but value this time, not address
    call void [mscorlib]System.Console::WriteLine(int32)
    ret 
} 
.method    public static void DoSum (int32 &, int32 ) cil managed 
{ 
    .maxstack 2 
    .locals    init (int32)    
    //Resolve the address,    and copy value to local variable 
    ldarg.0 
    ldind.i4 
    stloc.0
    ldloc.0
    //Perform the Sum
    ldarg.1
    add
    stloc.0

    ldarg.0
    ldloc.0
    stind.i4
    
    ret
}
