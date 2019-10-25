using System;
using static System.Console;

namespace TestMarkdownDeep
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string
                    input,
                    output;

                var md = new MarkdownDeep.Markdown();
                md.ExtraMode = true;

                //input = "## Welcome to MarkdownDeep";
                input = "<a name=\"C1\"></a>Chapter 1";
                output = md.Transform(input, out var definition);

                WriteLine(output);

                ReadKey();
            }
            catch (Exception eException)
            {
                WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
        }
    }
}
