using System;
using Microsoft.ClearScript.V8;

using static System.Console;

namespace TestCallJS
{
    class Program
    {
        const string JS = @"
var myArray = [0,1,2,3];
var a = myArray[0];
var b = myArray[1];
var c = myArray[2];
var d = myArray[3];
var rtnstr = ""{ errmsg: 'calculation never ran'}"";

function calculation()
{
    var one = a + b;
    var two = c + d;
    rtnstr = ""{ one:'"" + one + ""', two:'"" + two + ""'}"";
    return rtnstr;
}

function add(x, y)
{
    return x.toString() + y.toString();
}

function ClassI() {
	this.MethodI = function() {
        return ""ClassI.MethodI()"";
    };

    this.MethodII = function() {
        return ""ClassI.MethodII() -> "" + this.MethodI();
    };
}

function testObjectI()
{
    let obj = new ClassI();
    return obj.MethodII();
}

class ClassII {
	MethodI() {
        return ""ClassII.MethodI()"";
    }

    MethodII() {
        return ""ClassII.MethodII() -> "" + this.MethodI();
    };
}

function testObjectII()
{
    let obj = new ClassII();
    return obj.MethodII();
}
";

        static void Main(string[] args)
        {
            try
            {
                using (var engine = new V8ScriptEngine(V8ScriptEngineFlags.EnableDebugging))
                {
                    engine.Execute(JS);

                    var returnedVal = engine.Script.calculation();
                    WriteLine(returnedVal);

                    returnedVal = engine.Script.add(3, 5);
                    WriteLine(returnedVal);

                    returnedVal = engine.Script.testObjectI();
                    WriteLine(returnedVal);

                    returnedVal = engine.Script.testObjectII();
                    WriteLine(returnedVal);
                }
            }
            catch (Exception eException)
            {
                WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
        }
    }
}
