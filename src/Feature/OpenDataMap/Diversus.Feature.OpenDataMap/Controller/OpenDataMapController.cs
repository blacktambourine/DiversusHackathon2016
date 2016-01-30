using System.Web.Mvc;
using Sitecore.Mvc.Presentation;
using Newtonsoft.Json;

namespace Diversus.Feature.OpenDataMap.Controller
{
    public class OpenDataMapController : System.Web.Mvc.Controller
    {
        // GET: OpenDataMap
        public ActionResult OpenDataMap()
        {
            var map = new Models.Map(new Hackathon2016.Foundation.OpenDataAgent.Models.Repository(RenderingContext.Current.Rendering.Item));
            var items = JsonConvert.SerializeObject(map);
            return this.View("OpenDataMapWidget", items);
        }
    }
}