// https://blogs.msdn.microsoft.com/ruericlippert/2011/12/05/523/

.assembly extern mscorlib {}

.assembly Methods
{
    .ver 1:0:1:0
}
.module testcallreference.exe

.method static void main() cil managed
{
    .entrypoint
	.maxstack 1
    .locals init ([0] object o1, [1] object o2)
    
    newobj instance void [mscorlib]System.Object::.ctor()
    stloc.0
	
	ldloc.0
    call void TestCallVoidReference(object)
	
	ldloc.0
	call object TestCallObjectReference(object)
	stloc.1

    ret
}

.method public static void TestCallVoidReference(object) cil managed
{
    .maxstack 8
    
    ldarg.0
    callvirt instance string [mscorlib]System.Object::ToString()
    pop
	
    ret
}

.method public static object TestCallObjectReference(object o) cil managed
{
	.maxstack  1
	.locals init ([0] object V_0)

	ldarg.0
	callvirt instance string [mscorlib]System.Object::ToString()
	pop

	ldarg.0
	stloc.0

	ldloc.0

	ret
}

