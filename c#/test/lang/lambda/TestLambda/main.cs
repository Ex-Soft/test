// http://www.codeproject.com/Articles/24255/Exploring-Lambda-Expression-in-C
// https://tyrrrz.me/blog/expression-trees
// DevExpress.Xpo.Metadata.ReflectionMemberInfo.CreateAccessorInternal()
// https://msdn.microsoft.com/en-us/library/bb397951.aspx

#define TEST_CALL_GENERIC_METHOD
//#define TEST_DUPLICATES
//#define TEST_MEMBER_EXPRESSION
//#define TEST_PARSE
//#define TEST_CREATE_ACCESSOR
//#define TEST_CLOSURE
//#define ANY_TEST

using System;
using System.CodeDom;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace TestLambda
{
	#if TEST_MEMBER_EXPRESSION
		public class CustomAttribute : Attribute
		{
			public string SmthValue { get; private set; }

			public CustomAttribute() : this(string.Empty)
			{
				System.Diagnostics.Debug.WriteLine("CustomAttribute.CustomAttribute()");
			}

			public CustomAttribute(string smthValue)
			{
				SmthValue = smthValue;

				System.Diagnostics.Debug.WriteLine("CustomAttribute.CustomAttribute(string)");
			}
		}
	#endif

	#if TEST_CREATE_ACCESSOR || TEST_MEMBER_EXPRESSION || TEST_DUPLICATES
        class A
        {
			public string PString { get; set; }

			#if TEST_MEMBER_EXPRESSION
				[CustomAttribute("TestMemberExpression")]
				public string FString;
			#endif
        }
    #endif

	#if TEST_CREATE_ACCESSOR
		public delegate object GetValueDelegate(object obj);
	#endif

    class Program
    {
		#if ANY_TEST
			delegate Func<TIn, TOut> FixedPointFunction<TIn, TOut>(Func<TIn, TOut> f);

			static Func<T, TRes> Fix<T, TRes>(FixedPointFunction<T, TRes> f)
			{
				return f(x => Fix(f)(x));
			}
		#endif

		#if TEST_CALL_GENERIC_METHOD
		    public static T Get<T>(object value)
            {
                return (T)value;
            }
		#endif

        static void Main(string[] args)
        {
			bool
				tmpBool;


            object?
                tmpNullableObject;

            string
                tmpString1,
                tmpString2;

			#if TEST_CALL_GENERIC_METHOD
			    var methodInfo = typeof(Program).GetMethod(nameof(Get), BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
				var genericMethod = methodInfo.MakeGenericMethod(typeof(IA));

				IA tmpIA = (IA)genericMethod.Invoke(null, new object[] { new A() });

				Expression<Func<object, IA>> expObjLong = value => Get<IA>(value);
				tmpString1 = expObjLong.ToString();

				ParameterExpression parameterExpression = Expression.Parameter(typeof(object), "value");
			    Expression<Func<object, IA>> expObjLongDynamic = Expression.Lambda<Func<object, IA>>(Expression.Call(null, genericMethod, parameterExpression), parameterExpression);
                tmpString2 = expObjLongDynamic.ToString();

			    System.Diagnostics.Debug.WriteLine($"{(expObjLong == expObjLongDynamic ? "=" : "!")}=");
			    System.Diagnostics.Debug.WriteLine($"{(Expression.Equals(expObjLong, expObjLongDynamic) ? string.Empty : "!")}Expression.Equals()");
			    System.Diagnostics.Debug.WriteLine($"{(tmpString1 == tmpString2 ? "=" : "!")}=");

			    Func<object, IA> funcObjLong = expObjLongDynamic.Compile();
				tmpIA = funcObjLong(new A());
			#endif

			#if TEST_DUPLICATES
				var listOfA = new List<A>(new[]
				{
					new A { PString = "PString" }
				});

				Func<A, bool> predicate = a => a.PString == "PString";
				tmpBool = listOfA.Any(predicate);

				Expression<Func<A, bool>> e = a => a.PString == "PString";
				var param = Expression.Parameter(typeof(A), "a");
				//var callGetItem = Expression.Call(param, typeof(A).GetProperty("PString").GetGetMethod(), Expression.Constant("PString"));
				//Console.WriteLine(callGetItem.ToString());
			#endif

			#if TEST_MEMBER_EXPRESSION
				var tmpA = new A();

				var memberExpression = Expression.Field(Expression.Constant(tmpA), "FString");
				CustomAttribute customAttribute;

				if ((customAttribute = Attribute.GetCustomAttribute(memberExpression.Member, typeof(CustomAttribute)) as CustomAttribute) != null)
					Console.WriteLine(customAttribute.SmthValue);

				Console.WriteLine(memberExpression.ToString());
			#endif

            #if TEST_CREATE_ACCESSOR
                var typeOfA = typeof(A);
                //var pi = typeOfA.GetProperties(/*BindingFlags.DeclaredOnly | BindingFlags.NonPublic | */BindingFlags.Public | BindingFlags.Instance/* | BindingFlags.Static*/);
                var pi = typeOfA.GetProperty("PString");
                var parameter = Expression.Parameter(typeof(object));
                var convertExpression = Expression.Convert(parameter, typeOfA);
                var memberAccessExpresiion = Expression.MakeMemberAccess(convertExpression, pi);
                var expression = Expression.Convert(memberAccessExpresiion, typeof(object));
                var get = Expression.Lambda<GetValueDelegate>(expression, new[] { parameter }).Compile();
                var a = new A { PString = "blah-blah-blah" };

                Console.WriteLine(get(a));

                try
                { 
                    Console.WriteLine(get(null));
                }
                catch(NullReferenceException eException)
                {
                    Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                }
            #endif

            #if TEST_PARSE
                var m = typeof(string).GetMethod("Format", new[] { typeof(string), typeof(object[])});
                var str = m.Invoke(null, new object[] { "\"1\" = {0}", new object[] { 1 } });
                //Expression<Func<DataRow, object>> exprDataRowObject = row => row["F1"];
                //var paramIn = exprDataRowObject.Parameters[0];
                //var paramOut = Expression.Parameter(typeof(DataRow), "row");
                //var tmp = Expression.Call(paramOut, typeof (DataRow).GetProperty("Item").GetGetMethod(), Expression.Constant("F1"));
                
                /*
                string fieldName = "F1";

                Expression<Func<string>> expressionMemberAccess = () => fieldName;
                var memberExpression = Expression.Field(Expression.Constant(Program.Main, "fieldName"));
                Expression<Func<DataRow, object>> exprTreeIn = row => !row.IsNull(fieldName) ? row[fieldName] : string.Empty;
                */

                
                //Expression<Func<DataRow, object>> exprTreeIn = row => !row.IsNull("F1") ? row["F1"] : string.Empty;
                //Expression<Func<DataRow, string>> exprTreeIn = row => string.Format("\"{0}\"_\"{1}\"", !row.IsNull("F1") ? row["F1"] : string.Empty, row["F2"]);
                Expression<Func<DataRow, string>> exprTreeIn = row => string.Format("\"{0}\"_\"{1}\"_\"{2}\"_\"{3}\"", row["F1"], row["F2"], row["F3"], row["F4"]);
                var body = exprTreeIn.Body as MemberExpression;

                var paramIn = (ParameterExpression) exprTreeIn.Parameters[0];
                var paramOut = Expression.Parameter(typeof(DataRow), "row");

                var callIn = exprTreeIn.Body;
                var callOut = Expression.Not(Expression.Call(paramOut, typeof(DataRow).GetMethod("IsNull", new[] {typeof (string)}), Expression.Constant("F1")));
                Console.WriteLine(callIn.ToString());
                Console.WriteLine(callOut.ToString());

                var fIn = Expression.Lambda<Func<DataRow, object>>(callIn, new[] { paramIn }).Compile();
                var fOut = Expression.Lambda<Func<DataRow, bool>>(callOut, new[] { paramOut }).Compile();

                //Expression.Call(paramOut, typeof(DataRow).GetMethod("IsNull", new[] { typeof(string) }), Expression.Constant("F1"));
                //Expression.Call(typeof(string), "Format", new[] { typeof(string), typeof(object[]) }, Expression.Constant("{0}"), Expression.Call(Expression.New(typeof(object)), typeof(object).GetProperty("Item").GetGetMethod(), Expression.Constant("F1") ));
            #endif

			#if ANY_TEST
				var fact = Fix<int, int>(f => x => (x <= 1) ? x : x*f(x - 1));

				Console.WriteLine(fact(5));

				Func<int, int> fib = null;
				fib = n => n > 1 ? fib(n - 1) + fib(n - 2) : n;
				Console.WriteLine(fib(6));
			#endif

			#if TEST_CLOSURE
				int tmpInt = 1;
				Func<int, int> testClosure = i => {
					Console.WriteLine("tmpInt: {0}, i: {1}", tmpInt, i);
					return tmpInt*i;
				};

				Console.WriteLine(testClosure(10));

				tmpInt = 2;
				Console.WriteLine(testClosure(10));

				// http://sergeyteplyakov.blogspot.com/2010/04/c.html
				// http://blogs.msdn.com/b/ruericlippert/archive/2009/11/12/9983705.aspx
				// http://blogs.msdn.com/b/ruericlippert/archive/2009/11/16/9984832.aspx
				// http://weblogs.asp.net/fbouma/archive/2009/06/25/linq-beware-of-the-access-to-modified-closure-demon.aspx
				List<int>
					listInt = new List<int> { 1, 2, 3, 4, 5 },
					_listInt_ = new List<int> { 1, 2, 3, 4, 5 },
					listIntII = new List<int>();

				var funcs = new List<Func<int>>();
				foreach (int i in listInt)
				{
					/*
					int ii = i;
					funcs.Add(() => ii);
					*/
					funcs.Add(() => i);
				}

				foreach (var f in funcs)
				{
					Console.WriteLine(f());
				}

				listInt.ForEach(i=>listIntII.Add(f(i)));

				listIntII.Clear();
				foreach (int i in _listInt_)
				{
					var items = listInt.Where(ii => ii == i);  // Access to foreach variable in closure.
					listIntII.AddRange(items);

					var item = listInt.FirstOrDefault(ii => ii == i);
					listIntII.Add(item);
				}

                funcs.Clear();
				for (int i = 0; i < 5; ++i)
                {
                    int ii = i;
				    funcs.Add(() => ii);
				    //funcs.Add(() => i);
			    }
				foreach (var f in funcs)
				{
					Console.WriteLine(f());
				}
			#endif
		}

		#if TEST_CLOSURE
			static int f(int i)
			{
				return i*i;
			}
		#endif
    }

    public interface IA
    {
		string IProperty { get; set; }
    }

    public class A : IA
    {
        public string IProperty { get; set; }
        public string Property { get; set; }
	}
}