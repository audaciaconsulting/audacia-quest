namespace Audacia.Quest.Compiler
{
    public interface ICompiler
    {
        /// <summary>
        /// This is the code sent from the client.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        string ConvertToSource(string code);
        
        /// <summary>
        /// Compiles for the code with the string and returns a result.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        string Compile(string source);
    }
}