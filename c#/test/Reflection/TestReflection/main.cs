using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TestReflection
{
    class Program
    {
        static void Main(string[] args)
        {
	        Type
		        tmpType;

            tmpType = typeof(BaseClass);

            MethodInfo[]
                methodInfos = tmpType.GetMethods(BindingFlags.FlattenHierarchy | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            MethodInfo
                baseMethodInfo = tmpType.GetMethod("BasePrivateMethod", BindingFlags.Instance | BindingFlags.NonPublic);

            tmpType = typeof(DerivedClass);
            methodInfos = tmpType.GetMethods(BindingFlags.FlattenHierarchy | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            var derived = new DerivedClass("Derived (from Derived)", "Base (from Derived)");

            baseMethodInfo.Invoke(derived, null);

            var data = new[]
	        {
		        new {FString = "FString1", FInt = 1, FDecimal = 1.1m},
				new {FString = "FString2", FInt = 2, FDecimal = 2.2m}
	        };
	        Show(tmpType = data[0].GetType(), data[0]);
	        var tmpObject = Activator.CreateInstance(tmpType, new object[] {"Fstring3", 3, 3.3m});

            var testClass = new TestClass("field1", "field2", "field3", "field4", "property1", "property2");
			Show(typeof(TestClass), testClass);

            Type
				typeTestClass = typeof(TestClass);

			FieldInfo[]
				fi = typeTestClass.GetFields(/*BindingFlags.DeclaredOnly | */ /*BindingFlags.NonPublic | */BindingFlags.Public | BindingFlags.Instance/* | BindingFlags.Static*/);

			PropertyInfo[]
				propertyInfos = typeTestClass.GetProperties(/*BindingFlags.DeclaredOnly | BindingFlags.NonPublic | */BindingFlags.Public | BindingFlags.Instance/* | BindingFlags.Static*/);

            var exportInfos = new Dictionary<string, ExportInfo>
            {
                { "Property1", new ExportInfo("Property# 1", 1) },
                { "Property_2", new ExportInfo("Property# 2", 2) }
            };

            var result = propertyInfos
                .GroupJoin(exportInfos, pi => pi.Name, ei => ei.Key, (pi, ei) => new { PropertyInfo = pi, ExportInfo = ei.Select(item => new { item.Value.ColumnName, item.Value.Order }) })
                .SelectMany(groupJoinItem => groupJoinItem.ExportInfo.DefaultIfEmpty(), (pi, ei) => new { Order = ei != null ? ei.Order : 0, pi.PropertyInfo, ColumnName = ei != null ? ei.ColumnName : string.Empty })
                .OrderBy(item => item.Order)
                .ToList();
        }

	    static void Show(Type type, object obj)
	    {
			var mi = type.GetMembers(/*BindingFlags.DeclaredOnly | BindingFlags.NonPublic | */BindingFlags.Public | BindingFlags.Instance/* | BindingFlags.Static*/);
			
			string
				name;

			Type
				tmpType;

			object
				value;

			FieldInfo
				fieldInfo;

			PropertyInfo
				propertyInfo;

			foreach (var memberInfo in mi)
			{
				name = memberInfo.Name;

				switch (memberInfo.MemberType)
				{
					case MemberTypes.Field:
					{
						if ((fieldInfo = memberInfo as FieldInfo) != null)
						{
							tmpType = fieldInfo.FieldType;
							value = fieldInfo.GetValue(obj);
						}
						break;
					}
					case MemberTypes.Property:
					{
						if ((propertyInfo = memberInfo as PropertyInfo) != null)
						{
							tmpType = propertyInfo.PropertyType;
							value = propertyInfo.GetValue(obj);
						}
						break;
					}
					case MemberTypes.Method:
					{
						if (name.StartsWith("get_"))
							value = type.InvokeMember(name, BindingFlags.InvokeMethod, null, obj, null);

						break;
					}
				}
			}
	    }
    }
}
