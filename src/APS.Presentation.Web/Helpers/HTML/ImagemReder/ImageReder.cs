using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APS.Presentation.Web.Helpers.HTML.ImagemReder
{
    public static class ImageRederHelpér
    {
        public static MvcHtmlString ImageReder(this HtmlHelper helper, string base64, object atributes=null)
        {
            return MvcHtmlString.Create(ImgHtml(base64, atributes));
        }


        private static string ImgHtml(string base64, object atributes)
        {
            var builder = new TagBuilder("img");

            if (atributes != null)
            {
                var htmlAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(atributes);
                builder.MergeAttributes(htmlAttributes);
            }            

            builder.Attributes.Add("src", $"data:image/png;base64, {base64}");

            return builder.ToString(TagRenderMode.Normal);
        }

    }

}