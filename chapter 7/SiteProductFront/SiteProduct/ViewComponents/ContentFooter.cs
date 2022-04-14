using Microsoft.AspNetCore.Mvc;
namespace SiteProduct.ViewComponents
{
    public class ContentFooter: ViewComponent
    {
        private IConfiguration _config;
        public ContentFooter(IConfiguration config)
        {
            _config = config;
        }
        public IViewComponentResult Invoke()
        {
            var model = _config.GetSection("About")["Production"];
            return View("Default", model);
        }
    }
}
