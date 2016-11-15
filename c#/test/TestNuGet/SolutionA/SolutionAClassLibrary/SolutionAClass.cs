using NLog;

namespace SolutionAClassLibrary
{
    public class SolutionAClass
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public void Foo([System.Runtime.CompilerServices.CallerMemberName] string memberName = "", [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "", [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            _logger.Trace("SolutionAClassLibrary.SolutionAClass.Foo() (CallerMemberName: \"{0}\", CallerFilePath: \"{1}\", CallerLineNumber: {2})", memberName, sourceFilePath, sourceLineNumber);
        }
    }
}
