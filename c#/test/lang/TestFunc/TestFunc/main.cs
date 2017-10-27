// http://www.dotnetperls.com/func
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TestFunc
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listOfInt = new List<string>();
            Action<List<string>> fillList = (list) => { list.Add("blah-blah-blah"); };
            fillList(listOfInt);
            System.Diagnostics.Debug.WriteLine(listOfInt.Count);

            DataTable dataTable = new DataTable();
            Action<DataTable> fillDataTable = (dt) => { dt.Columns.Add(new DataColumn("fString", typeof(string))); };
            fillDataTable(dataTable);
            System.Diagnostics.Debug.WriteLine(dataTable.Columns.Count);

            Func<string>
                funcStr = () => "Func<string> funcStr = () => \"\"";

            Func<int, string>
                funcStrInt = (inputInt) => string.Format("InputInt: {0}", inputInt);

            Func<int, decimal, string>
                funcStrIntDecimal = (inputInt, inputDecimal) => string.Format("InputInt: {0}, InputDecimal: {1}", inputInt, inputDecimal);

            Console.WriteLine(funcStr());
            Console.WriteLine(funcStrInt(13));
            Console.WriteLine(CallFuncIntString(null));
            Console.WriteLine(funcStrIntDecimal(13, 13));
            Console.WriteLine(SmthFunc(funcStrIntDecimal,13,13));
            Console.WriteLine(SmthFunc(13));

            string
                tmpString = "tmpStringValue";

            Console.WriteLine(string.Format("tmpString=\"{0}\"", SmthFunc(() => tmpString)));

            tmpString = "() => string.Format(\"{0} {1}\", \"1st\", \"2nd\")";
            Console.WriteLine(string.Format("tmpString=\"{0}\"", SmthFunc(() => tmpString)));

            Expression<Func<int, bool>> expr = i => i < 5;
            Console.WriteLine(SmthFunc(expr));

            SmthFunc(funcStr)();
            var tmpVar1=SmthFunc(funcStr);
            tmpVar1();

            SmthFunc(funcStrInt)(13);
            var tmpVar2 = SmthFunc(funcStrInt);
            tmpVar2(13);

            SmthFunc(funcStrIntDecimal)(13, 13);
            var tmpVar3 = SmthFunc(funcStrIntDecimal);
            tmpVar3(13, 13);

            FuncWithOutParam(1, out tmpString);
            Console.WriteLine(tmpString);

            FuncWithOutParam(2, out tmpString);
            Console.WriteLine(tmpString);


            Console.ReadLine();
        }

        static string CallFuncIntString(Func<int, string> f)
        {
            return f(1);
        }

        static T SmthFunc<T>(T parameter)
        {
            Func<T>
                f = () => parameter;

            return f();
        }
// ??? http://blogs.msdn.com/b/csharpfaq/archive/2010/03/11/how-can-i-get-objects-and-property-values-from-expression-trees.aspx
// ??? http://stackoverflow.com/questions/5092387/how-can-i-get-object-instance-from-foo-title-expression
        static string SmthFunc<T>(Expression<Func<T>> expression) where T : class
        {
            string
                parameterValue = string.Empty;

            var func = expression.Compile();
            var obj = func();

            if (obj == null)
            {
                var memberExp = expression.Body as MemberExpression;
                if (memberExp != null)
                {
                    parameterValue = memberExp.Member.Name;
                }
            }
            else
            {
                parameterValue = obj.ToString();
            }

            return parameterValue;
        }

        static string SmthFunc(Func<int, decimal, string> f, int inputInt, decimal inputDecimal)
        {
            return f(inputInt, inputDecimal);
        }

        static void FuncWithOutParam(int setter, out string param1/*, out string param2*/)
        {
            // http://stackoverflow.com/questions/1495636/can-i-have-an-action-or-func-with-an-out-param
            // http://stackoverflow.com/questions/1283127/funct-with-out-parameter
            // http://stackoverflow.com/questions/14068426/using-a-out-parameter-in-func-delegate

            Func<string> setOutParamVal1 = () => "blah-blah-blah-1";
            Func<string> setOutParamVal2 = () => "blah-blah-blah-2";

            switch (setter)
            {
                case 1:
                    {
                        param1 = setOutParamVal1();
                        break;
                    }
                default:
                    {
                        param1 = setOutParamVal2();
                        break;
                    }
            }
        }
    }
}
