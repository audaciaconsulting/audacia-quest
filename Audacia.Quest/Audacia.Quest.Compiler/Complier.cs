using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Audacia.Quest.Compiler;
using Microsoft.CSharp;

namespace Audacia.Quest.Compiler;

public class Compiler : ICompiler
{
    private readonly CSharpCodeProvider _codeProvider = new CSharpCodeProvider();

    private readonly ICodeCompiler _codeCompiler;
    
    /// <summary>
    /// I think these should come from options -> as we could be about using different types of compilers (js, ts)
    /// </summary>
    private readonly CompilerParameters _compilerParameters;

    public string Output { get; set; }
    
    public Compiler()
    {
        _codeCompiler = _codeProvider.CreateCompiler();

        _compilerParameters = new CompilerParameters();
        _compilerParameters.GenerateExecutable = true;
        _compilerParameters.OutputAssembly = Output;
    }

    public string ConvertToSource(string code)
    {
        return code;
    }

    public string Compile(string source)
    {
        var compilerResult = _codeCompiler.CompileAssemblyFromSource(_compilerParameters, source);

        if (compilerResult.Errors.HasErrors)
        {
            LogErrors(compilerResult.Errors);
        }
        else
        {
            Console.WriteLine(compilerResult.Output);

            ExecuteCompiledCode();
        }

        return string.Empty;
    }

    private void ExecuteCompiledCode()
    {
        Output = Guid.NewGuid().ToString() + ".exe";
        var processStartInfo = new ProcessStartInfo()
        {
            FileName = Output,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            CreateNoWindow = true
        };

        var process = new Process()
        {
            StartInfo = processStartInfo
        };

        process.Start();
        while (!process.StandardOutput.EndOfStream)
        {
            var executedResult = process.StandardOutput.ReadLine();
            
            // this should be equal to 'Hello World!' using the MainExample
            Console.WriteLine($"Compile successful: {executedResult == "Hello World!"}");
        }
    }

    private void LogErrors(CompilerErrorCollection compilerErrorCollection)
    {
        foreach (CompilerError compilerError in compilerErrorCollection)
        {
            Console.WriteLine("Line number " + compilerError.Line +
                              ", Error Number: " + compilerError.ErrorNumber +
                              ", '" + compilerError.ErrorText + ";");
        }
    }
}