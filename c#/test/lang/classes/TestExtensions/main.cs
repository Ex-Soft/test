using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

namespace TestExtensions
{
    static class TestExtensions
    {
        public static void ShowItems<T>(this IEnumerable<T> collection)
        {
            foreach (var item in collection)
                Console.WriteLine(item);
        }

        public static void Ensure(this int? v, Func<int?, bool> f)
        {
            if(!f(v))
                Console.WriteLine("!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var request = new Request("en-gb");
            Debug.WriteLine($"{{PreferredLanguage: \"{request.PreferredLanguage}\", LanguageCode:\"{request.GetLanguageCode()}\", Country:\"{request.GetCountry()}\"}}");

            StringBuilder
                sb = null;

            //sb.IndexOf('X');

            //sb.Replace(',', '!');

            "String".ShowItems();

            new[] {"String1","String2"}.ShowItems();

            new List<Int32>(){1,2,3,4,5}.ShowItems();

            int?
                a=1;

            a.Ensure(id => id.HasValue && id>0);
        }
    }
}
