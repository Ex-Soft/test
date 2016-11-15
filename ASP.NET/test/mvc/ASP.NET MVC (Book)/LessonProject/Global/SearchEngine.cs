using LessonProject.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace LessonProject.Global
{
    public class SearchEngine
    {
        

        public static IEnumerable<User> Search(string searchString, IQueryable<User> source)
        {
            var term = CleanContent(searchString.ToLowerInvariant().Trim(), false);
            var terms = term.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var regex = string.Format(CultureInfo.InvariantCulture, "({0})", string.Join("|", terms));

            foreach (var entry in source)
            {
                var rank = 0;

              
                if (!string.IsNullOrWhiteSpace(entry.Email))
                {
                    rank += Regex.Matches(entry.Email.ToLowerInvariant(), regex).Count;
                }
                if (rank > 0)
                {
                    yield return entry;
                }
            }
        }

        /// <summary>
        /// The regex strip html.
        /// </summary>
        private static readonly Regex RegexStripHtml = new Regex("<[^>]*>", RegexOptions.Compiled);


        private static string StripHtml(string html)
        {
            return string.IsNullOrWhiteSpace(html) ? string.Empty : 
                RegexStripHtml.Replace(html, string.Empty).Trim();
        }

        private static string CleanContent(string content, bool removeHtml)
        {
            if (removeHtml)
            {
                content = StripHtml(content);
            }

            content =
                content.Replace("\\", string.Empty).
                Replace("|", string.Empty).
                Replace("(", string.Empty).
                Replace(")", string.Empty).
                Replace("[", string.Empty).
                Replace("]", string.Empty).
                Replace("*", string.Empty).
                Replace("?", string.Empty).
                Replace("}", string.Empty).
                Replace("{", string.Empty).
                Replace("^", string.Empty).
                Replace("+", string.Empty);

            var words = content.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var sb = new StringBuilder();
            foreach (var word in
                words.Select(t => t.ToLowerInvariant().Trim()).Where(word => word.Length > 1))
            {
                sb.AppendFormat("{0} ", word);
            }

            return sb.ToString();
        }
    }
}