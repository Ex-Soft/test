using System.Web.Mvc;
using NUnit.Framework;
using WebUI.HtmlHelpers;

namespace Tests
{
    [TestFixture]
    public class PagingHelperTests
    {
        [Test]
        public void PageLinks_Method_Extends_HtmlHelper()
        {
            HtmlHelper html = null;
            html.PageLinks(0, 0, null);
        }

        [Test]
        public void PageLinks_Produced_Anchor_Tags()
        {
            string links = ((HtmlHelper)null).PageLinks(2, 3, i => "Page" + i);
            Assert.AreEqual(@"<a href=""Page1"">1</a>
<a class=""selected"" href=""Page2"">2</a>
<a href=""Page3"">3</a>
", links);
        }
    }
}
