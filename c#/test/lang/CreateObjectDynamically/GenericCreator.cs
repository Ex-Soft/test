using System;
using System.Reflection;

namespace CreateObjectDynamically
{
    public class GenericCreator
    {
        public static void CreateGeneric(Type type)
        {
            var methods = typeof(GenericCreator).GetRuntimeMethods();
            var methodInfo = typeof(GenericCreator).GetMethod("CreateGeneric", Array.Empty<Type>());
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
    }
}
