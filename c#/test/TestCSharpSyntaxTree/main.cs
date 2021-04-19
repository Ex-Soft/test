using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using static System.Console;

namespace TestCSharpSyntaxTree
{
    class Program
    {
        static void Main(string[] args)
        {
            IVictim victim = new Victim1();
            Runner.Run(victim);
            victim = new Victim2();
            Runner.Run(victim);
            victim = new Victim3();
            Runner.Run(victim);

            Analyze();
        }

        static void Analyze()
        {
            var currentDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;

            if (currentDirectory.IndexOf("bin", StringComparison.InvariantCultureIgnoreCase) != -1)
                currentDirectory = currentDirectory[..currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1, StringComparison.InvariantCultureIgnoreCase)];

            var fileName = Path.Combine(currentDirectory, "Runner.cs");

            if (!File.Exists(fileName))
                return;

            var fileText = File.ReadAllText(fileName);

            SyntaxTree eventProcessorSyntax = CSharpSyntaxTree.ParseText(fileText);

            SyntaxNode syntaxTreeRoot = eventProcessorSyntax.GetRoot();

            SyntaxNode[] syntaxNodes = syntaxTreeRoot.DescendantNodesAndSelf().ToArray();

            IdentifierNameSyntax[] identifiers = syntaxNodes.OfType<IdentifierNameSyntax>().ToArray();

            foreach (IdentifierNameSyntax identifier in identifiers)
            {
                WriteLine(identifier.ToFullString());
            }
        }
    }
}
