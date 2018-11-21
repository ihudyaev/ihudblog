using System;
using System.Web.Mvc;

namespace IH.IhudBlog.Web.Extensions
{
    public static class Helpers
    {
        public static MvcHtmlString NewNote(this HtmlHelper html)
        {
            return new MvcHtmlString("<input type=\"button\" value=\"Super\" />");
        }

        /// <summary>
        /// Текущая дата
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static DateTime Now(this HtmlHelper html)
        {
            return DateTime.Now;
        }
    }
}
