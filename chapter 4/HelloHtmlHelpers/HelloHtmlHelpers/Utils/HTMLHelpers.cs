using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HelloHtmlHelpers.Utils
{
    public static class HTMLHelpers
    {
        public static IHtmlContent HelloWorldStrong(this IHtmlHelper htmlHelper, string title)
            => new HtmlString($"<strong>{title}</strong>");

        public static IHtmlContent HelloWorld(this IHtmlHelper html, string[] names)
        {
            TagBuilder ul = new TagBuilder("ul");
            foreach (string val in names)
            {
                TagBuilder li = new TagBuilder("li");
                // добавляем текст в li
                li.InnerHtml.Append(val);
                // добавляем li в ul
                ul.InnerHtml.AppendHtml(li);
            }
            string result;
            using (var writer = new StringWriter())
            {
                ul.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);
                result = writer.ToString();
            }
            return new HtmlString(result);
        }
    }
}
