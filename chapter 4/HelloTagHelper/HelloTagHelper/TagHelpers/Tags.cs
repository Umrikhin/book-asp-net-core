using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HelloTagHelper.TagHelpers
{
    [HtmlTargetElement("hello", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class HelloTag : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "";
            output.Content.SetHtmlContent($"<h3>Привет, мир. Мое время: {DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")}</h3>");
        }
    }
    [HtmlTargetElement("AreaRec", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class AreaRecTag : TagHelper
    {
        [HtmlAttributeName("a")]
        public double a { get; set; }
        [HtmlAttributeName("b")]
        public double b { get; set; }
        [HtmlAttributeName("units")]
        public Units units { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "";
            switch(units)
            {
                case Units.m:
                    output.Content.SetHtmlContent($"Площадь прямоугольника {a.ToString()} &times; {b.ToString()}: {(a * b).ToString()} м<sup>2</sup>");
                    break;
                case Units.cm:
                    output.Content.SetHtmlContent($"Площадь прямоугольника {a.ToString()} &times; {b.ToString()}: {(a * b).ToString()} см<sup>2</sup>");
                    break;
                case Units.mm:
                    output.Content.SetHtmlContent($"Площадь прямоугольника {a.ToString()} &times; {b.ToString()}: {(a * b).ToString()} мм<sup>2</sup>");
                    break;
                case Units.km:
                    output.Content.SetHtmlContent($"Площадь прямоугольника {a.ToString()} &times; {b.ToString()}: {(a * b).ToString()} км<sup>2</sup>");
                    break;
            }
        }
    }
    public enum Units
    {
        mm, cm, m, km
    }
}
