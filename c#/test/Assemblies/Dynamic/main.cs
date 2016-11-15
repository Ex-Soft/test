using System;
using System.IO;
using System.Reflection;

namespace TestDynamicAssemblies
{
	class TestDynamicAssembliesClass
	{
		[STAThread]
		static void Main(string[] args)
		{
			string
				MathDllPath=Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)+Path.DirectorySeparatorChar+"Math.dll";

			if(!File.Exists(MathDllPath))
				return;

			Assembly
				myAssembly=Assembly.LoadFile(MathDllPath);

			Type[]
				types=myAssembly.GetTypes();

			object
				o;

			MethodInfo[]
				methods;

			foreach(Type type in types)
			{
				Console.WriteLine(type.Name);
				
				methods=type.GetMethods();
				foreach(MethodInfo method in methods)
					Console.WriteLine(method.Name);

				o=Activator.CreateInstance(type);

				int
					tmpInt;

				if(o.GetType().Name=="SimpleMath")
				{
					tmpInt=(int)o.GetType().InvokeMember("Add",BindingFlags.InvokeMethod,null,o,new object[]{2,3});
					tmpInt=(int)o.GetType().InvokeMember("Subtract",BindingFlags.InvokeMethod,null,o,new object[]{2,3});
				}

				if(o.GetType().Name=="ComplexMath")
					tmpInt=(int)o.GetType().InvokeMember("Square",BindingFlags.InvokeMethod,null,o,new object[]{3});
			}
		}
	}
}
