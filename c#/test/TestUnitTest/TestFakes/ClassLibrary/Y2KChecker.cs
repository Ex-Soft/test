// http://blog.nwcadence.com/shims-and-stubs-and-the-microsoft-fakes-framework/

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
