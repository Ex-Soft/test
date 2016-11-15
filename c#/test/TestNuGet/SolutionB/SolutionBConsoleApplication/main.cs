// http://stackoverflow.com/questions/18376313/setting-up-a-common-nuget-packages-folder-for-all-solutions-when-some-projects-a

namespace SolutionBConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var v = new SolutionAClassLibrary.SolutionAClass();

            v.Foo();
        }
    }
}
