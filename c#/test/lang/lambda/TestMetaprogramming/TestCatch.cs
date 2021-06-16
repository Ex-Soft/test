using System;
using System.Linq.Expressions;
using DotNext.Linq.Expressions;
using static DotNext.Metaprogramming.CodeGenerator;

namespace TestMetaprogramming
{
    public class TestCatch
    {
        public static void Catch()
        {
            var lambda = Lambda<Func<long, long, bool>>((fun, result) =>
                {
                    var (arg1, arg2) = fun;
                    Assign(result, true.Const());
                    Try((Expression)(arg1.AsDynamic() / arg2))
                        .Catch<DivideByZeroException>(() => Assign(result, false.Const()))
                        .End();
                })
                .Compile();

            var result = lambda(6, 3);
            result = lambda(6, 0);
        }

        public static void ReturnFromCatch()
        {
            var lambda = Lambda<Func<long, long, bool>>((fun, result) =>
                {
                    var (arg1, arg2) = fun;
                    Try((Expression)(arg1.AsDynamic() / arg2))
                        .Catch<DivideByZeroException>(() => Return(false.Const()))
                        .End();
                    Return(true.Const());
                })
                .Compile();

            var result = lambda(6, 3);
            result = lambda(6, 0);
        }

        public static void CatchWithFilter()
        {
            var lambda = Lambda<Func<long, long, bool>>(static fun =>
                {
                    var (arg1, arg2) = fun;
                    Try(Expression.Block((Expression)(arg1.AsDynamic() / arg2), true.Const()))
                        .Catch(typeof(Exception), static e => e.InstanceOf<DivideByZeroException>(), static e =>  InPlaceValue(false))
                        .OfType<bool>()
                        .End();
                })
                .Compile();

            var result = lambda(6, 3);
            result = lambda(6, 0);
        }
    }
}
