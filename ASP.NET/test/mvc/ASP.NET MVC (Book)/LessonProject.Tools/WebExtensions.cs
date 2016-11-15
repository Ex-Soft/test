using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LessonProject.Tools
{
    public static class WebExtensions
    {
        public static MvcHtmlString NlToBr(this string source)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                return new MvcHtmlString(string.Empty);
            }
            return new MvcHtmlString(source.Replace(Environment.NewLine, "<br />"));
        }

        public static string Teaser(this string content, int length, string more = "...")
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                return string.Empty;
            }

            if (content.Length < length)
            {
                return content;
            }
            return content.Substring(0, length) + more;
        }

        public static string CountWord(this int count, string first, string second, string five)
        {
            if (count % 10 == 1 && (int)(count / 10) != 1)
            {
                return first;
            }
            if (count % 10 > 1 && count % 10 < 5 && ((int)(count / 10) % 10) != 1)
            {
                return second;
            }
            return five;
        }
    }
}
