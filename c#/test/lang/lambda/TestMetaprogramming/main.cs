using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AgileObjects.ReadableExpressions;
using DotNext.Linq.Expressions;
using DotNext.Metaprogramming;
using static System.Console;
using static DotNext.Metaprogramming.CodeGenerator;

namespace TestMetaprogramming
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Expression<Func<string, Task<object>>> expStrToInt = str => StrToInt(str);
            Expression<Func<string, Task<object>>> expStrToDouble = str => StrToDouble(str);
            string tmpString = expStrToInt.ToString();
            tmpString = expStrToInt.ToReadableString();

            Func<string, Task<object>> f = expStrToInt.Compile();
            object tmpObject = await f("1");
            f = expStrToDouble.Compile();
            tmpObject = await f("1.3");

            var tmpExpression = Expression.Invoke(expStrToInt, Expression.Constant(tmpString, typeof(string))).Await();

            var fStrToInt = new Func<string, Task<object>>(StrToInt).Method;
            var fStrToDouble = new Func<string, Task<object>>(StrToDouble).Method;

            Expression<Func<string, Task<object>>> accumulateExpression;
            accumulateExpression = AsyncLambda<Func<string, Task<object>>>(
                (lambdaContext, result) =>
                {
                    ParameterExpression param = lambdaContext[0];

                    Try(() =>
                    {
                        //Assign(result, Expression.Invoke(expStrToInt, param).Await());
                        Assign(result, Expression.Call(null, fStrToInt, param).Await());
                        Return(result);
                    })
                    .Catch<Exception>(() =>
                    {
                        //Assign(result, Expression.Invoke(expStrToDouble, param).Await());
                        Assign(result, Expression.Call(null, fStrToDouble, param).Await());
                        Return(result);
                    })
                    .End();
                });

            tmpString = accumulateExpression.ToString();
            tmpString = accumulateExpression.ToReadableString();

            tmpString = "1.3";
            f = accumulateExpression.Compile();

            try
            {
                tmpObject = await f(tmpString);
            }
            catch (Exception e)
            {
                WriteLine(e);
            }

            try
            {
                tmpObject = await Task.Run(async () => await StrToInt(tmpString));
            }
            catch (Exception e)
            {
                try
                {
                    tmpObject = await Task.Run(async () => await StrToDouble(tmpString));
                }
                catch (Exception exception)
                {
                    WriteLine(exception);
                }
            }
        }

        public static async Task<object> StrToInt(string str)
        {
            return await Task.FromResult<object>(int.Parse(str));
        }

        public static async Task<object> StrToDouble(string str)
        {
            return await Task.FromResult<object>(double.Parse(str));
        }
    }
}
