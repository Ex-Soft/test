// http://blog.nwcadence.com/shims-and-stubs-and-the-microsoft-fakes-framework/
// https://msdn.microsoft.com/en-us/library/hh549175(v=vs.110).aspx

using System;

namespace Y2KBug
{
    public static class Y2KChecker
    {
        public static void Check()
        {
            if (DateTime.Now == new DateTime(2000, 1, 1))
                throw new ApplicationException("y2kbug!");
        }
    }
}
