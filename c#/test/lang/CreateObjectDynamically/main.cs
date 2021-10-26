//#define CREATE_BY_CLSID
//#define CREATE_BY_TYPE
#define CREATE_GENERIC

using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace CreateObjectDynamically
{
	class ClassTest
	{
		int _id;

		public int Id
		{
			get { return _id; }
			set { _id = value; }
		}

        public void DoSmth()
        {
            Console.WriteLine("ClassTest.DoSmth()");
        }

        public void DoSmth(string p1)
        {
            Console.WriteLine("ClassTest.DoSmth(\"{0}\")", p1);
        }

        public void DoSmth(string p1, string p2)
        {
            Console.WriteLine("ClassTest.DoSmth(\"{0}\", \"{1}\")", p1, p2);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            #if CREATE_GENERIC
                CreateGeneric(typeof(A));
                CreateGeneric<B>();
            #endif

            #if CREATE_BY_CLSID
                CreateByCLSID();
            #endif

            #if CREATE_BY_TYPE
                CreateByType();
            #endif
        }
        public static void CreateGeneric(Type type)
        {
            var methods = typeof(Program).GetRuntimeMethods();
            var methodInfo = typeof(Program).GetMethod("CreateGeneric", Array.Empty<Type>());
            var methodInfoConstructed = methodInfo?.MakeGenericMethod(type);
            methodInfoConstructed?.Invoke(null, Array.Empty<object>());
        }

        public static void CreateGeneric<T>()
        {
            var dataType = new[] { typeof(T) };
            var genericBase = typeof(GenericClass<>);
            var combinedType = genericBase.MakeGenericType(dataType);

            object genericInstance = null;

            try
            {
                genericInstance = Activator.CreateInstance(combinedType, "1st", "2nd");
            }
            catch (MissingMethodException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            var methods = genericInstance?.GetType().GetRuntimeMethods();

            var method = genericInstance?.GetType().GetRuntimeMethod("Foo", new[] { typeof(string) });

            var result = method?.Invoke(genericInstance, new object?[] { "arg" });

            if (genericInstance is IGenericClass<T> interfaceObject)
            {
                T result2 = interfaceObject.Foo("arg");
            }
        }

        static void CreateByCLSID()
        {
            object
                tmpObject = null;

            try
            {
                try
                {
                    Guid
                        tmpGuid = new Guid("A8C48C2F-1F5E-4648-B361-AD1AFC5F0083");

                    Type
                        tmpType;

                    if ((tmpType = Type.GetTypeFromCLSID(tmpGuid)) != null)
                    {
                        MethodInfo[]
                            methods = tmpType.GetMethods();

                        foreach (MethodInfo methodInfo in methods)
                            Console.WriteLine(methodInfo.Name);

                        if ((tmpObject = Activator.CreateInstance(tmpType)) != null)
                        {
                            object
                                objVersion = tmpObject.GetType().InvokeMember("Version", BindingFlags.InvokeMethod, null, tmpObject, null);

                            string
                                version = Convert.ToString(objVersion);

                            Console.WriteLine(version);

                            tmpObject = null;
                        }
                    }
                }
                catch (Exception eException)
                {
                    Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                }
            }
            finally
            {
                if (tmpObject != null)
                {
                    Marshal.ReleaseComObject(tmpObject);
                    tmpObject = null;
                }

                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.GetTotalMemory(true);
                //GC.SuppressFinalize(this);
            }
        }

        static void CreateByType()
        {
            Assembly
                assembly = Assembly.GetExecutingAssembly();

            AssemblyName
                assemblyName = assembly.GetName();

            Type
                t = assembly.GetType(assemblyName.Name + "." + "ClassTest");

            object
                tmpObject = Activator.CreateInstance(t);

            tmpObject.GetType().InvokeMember("DoSmth", BindingFlags.InvokeMethod, null, tmpObject, null);
            tmpObject.GetType().InvokeMember("DoSmth", BindingFlags.InvokeMethod, null, tmpObject, new object[] { "parameter# 1" });
            tmpObject.GetType().InvokeMember("DoSmth", BindingFlags.InvokeMethod, null, tmpObject, new object[] { "parameter# 1", "parameter# 2" });
        }
    }
}
