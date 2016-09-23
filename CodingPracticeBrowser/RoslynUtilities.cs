using System;
using System.IO;
using System.Linq;
using System.Reflection;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;

namespace CodingPracticeBrowser
{
    public class DiagnosticException : Exception
    {
        public Diagnostic diagnostic { get; private set; }

        public DiagnosticException(Diagnostic diagnostic)
        {
            this.diagnostic = diagnostic;
        }
    }

    static class RoslynUtilities
    {
        static public Type CompileSolutionAndGetType(string stSolution)
        {
            // Create a syntax tree
            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(@"
    using System;

    namespace RoslynCompileSample
    {
        public class Writer
        {" + stSolution + @"
        }
    }");

            // Put it into a file 
            string assemblyName = Path.GetRandomFileName();
            MetadataReference[] references = new MetadataReference[]
            {
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(Enumerable).Assembly.Location)
            };

            CSharpCompilation compilation = CSharpCompilation.Create(
                assemblyName,
                syntaxTrees: new[] { syntaxTree },
                references: references,
                options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
            using (var ms = new MemoryStream())
            {
                EmitResult result = compilation.Emit(ms);

                if (!result.Success)
                {
                    Diagnostic diagnostic = result.Diagnostics.Where(diag =>
                        diag.IsWarningAsError ||
                        diag.Severity == DiagnosticSeverity.Error).First();

                    throw new DiagnosticException(diagnostic);
                }
                else
                {
                    ms.Seek(0, SeekOrigin.Begin);
                    Assembly assembly = Assembly.Load(ms.ToArray());
                    Type type = assembly.GetType("RoslynCompileSample.Writer");
                    object obj = Activator.CreateInstance(type);
                    return type;
                }
            }
        }
    }
}
