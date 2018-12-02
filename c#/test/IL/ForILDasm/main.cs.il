// Decompiled with JetBrains decompiler
// Type: ForILDasm.Program
// Assembly: ForILDasm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E402F956-6C92-4065-B6C3-AE773C0741C2
// Assembly location: D:\soft.src\c#\test\ForILDasm\bin\Debug\ForILDasm.exe
// Compiler-generated code is shown
// IL code is shown in comments

namespace ForILDasm
{

  // .class private auto ansi beforefieldinit 
    // ForILDasm.Program
      // extends [mscorlib]System.Object
  // 
  internal class Program
  {

    // .method private hidebysig static void 
      // Main(
        // string[] args
      // ) cil managed 
    private static void Main(string[] args)
    // .maxstack 2
    // .locals init (
    // [0] int32 V_0,
      // [1] int32 V_1,
      // [2] int32 V_2
    // )
    // 
    // IL_0000: nop          
    // IL_0001: ldc.i4       1234 // 0x000004d2
    // IL_0006: stloc.0      // V_0
    // IL_0007: ldc.i4       5678 // 0x0000162e
    // IL_000c: stloc.1      // V_1
    // IL_000d: ldloc.0      // V_0
    // IL_000e: ldloc.1      // V_1
    // IL_000f: call         int32 ForILDasm.Program::Add(int32, int32)
    // IL_0014: stloc.2      // V_2
    // IL_0015: ret          
    // 
    {
      Program.Add(1234, 5678);
    }


    // .method private hidebysig static int32 
      // Add(
        // int32 a, 
        // int32 b
      // ) cil managed 
    private static int Add(int a, int b)
    // .maxstack 2
    // .locals init (
    // [0] int32 V_0
    // )
    // 
    // IL_0000: nop          
    // IL_0001: ldarg.0      // a
    // IL_0002: ldarg.1      // b
    // IL_0003: add          
    // IL_0004: stloc.0      // V_0
    // IL_0005: br.s         IL_0007
    // IL_0007: ldloc.0      // V_0
    // IL_0008: ret          
    // 
    {
      return a + b;
    }


    // .method public hidebysig specialname rtspecialname instance void 
      // .ctor() cil managed 
    public Program()
    // .maxstack 8
    // 
    // IL_0000: ldarg.0      // this
    // IL_0001: call         instance void [mscorlib]System.Object::.ctor()
    // IL_0006: nop          
    // IL_0007: ret          
    // 
    {
      base.\u002Ector();
    }
  }
}
