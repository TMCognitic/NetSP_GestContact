using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Parser.SyntaxTree;

namespace GestContact.Infrastructure
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString DisplayError(this HtmlHelper html, string key, string htmlClass = "text-danger")
        {
            if (!(html.ViewData[key] is null))
            {
                TagBuilder divTag = new TagBuilder("div");
                TagBuilder spanTag = new TagBuilder("span");
                spanTag.Attributes["class"] = htmlClass;
                spanTag.SetInnerText(html.ViewData[key] as string);
                divTag.InnerHtml = spanTag.ToString();
                return new MvcHtmlString(divTag.ToString());
            }
            else
                return new MvcHtmlString("");
        }
    }
}