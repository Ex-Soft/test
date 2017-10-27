using System;
using System.Reflection;

namespace LibXls
{
	class LibXls
	{
		[STAThread]
		static void Main(string[] args)
		{
			ILibXls.ILibXls
				LibXls=null;

			AssemblyName
				AssemblyName=new AssemblyName();

			AssemblyName.Name="LibXlsCalc";

			Type[]
				types=Assembly.Load(AssemblyName).GetTypes(),
				interfaces;

			foreach(Type assemblyType in types)
			{
				interfaces=assemblyType.GetInterfaces();
				foreach(Type assemblyInterface in interfaces)
				{
					if(assemblyInterface==typeof(ILibXls.ILibXls))
						LibXls=(ILibXls.ILibXls)Activator.CreateInstance(assemblyType);
				}
			}

			if(LibXls!=null)
			{
				LibXls.Range=1;
				LibXls.WorkbookSave();
			}
		}
	}
}
