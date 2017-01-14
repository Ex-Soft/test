// http://blog.nwcadence.com/shims-and-stubs-and-the-microsoft-fakes-framework/

using System;
using System.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Y2KBug.Test
{
    [TestClass]
    public class Y2KBugTest
    {
        [TestMethod]
        [ExpectedException(typeof (ApplicationException))]
        public void Y2KCheckerTest()
        {
            using (ShimsContext.Create())
            {
                ShimDateTime.NowGet = () => new DateTime(2000, 1, 1);
                Y2KChecker.Check();
            }
        }
    }
}
