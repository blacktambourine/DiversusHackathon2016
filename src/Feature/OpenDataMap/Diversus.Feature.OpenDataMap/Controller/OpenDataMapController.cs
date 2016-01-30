using System.Web.Mvc;
using Sitecore.Mvc.Presentation;

namespace Diversus.Feature.OpenDataMap.Controller
{
    public class OpenDataMapController : System.Web.Mvc.Controller
    {
        // GET: OpenDataMap
        public ActionResult OpenDataMap()
        {
            var items = "";
            return this.View("OpenDataMapWidget", items);
        }
    }
}