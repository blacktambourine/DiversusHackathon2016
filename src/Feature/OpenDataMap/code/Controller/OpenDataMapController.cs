using System.Web.Mvc;
using Newtonsoft.Json;
using Sitecore.Mvc.Presentation;

namespace Sitecore.Feature.OpenDataMap.Controller
{
    public class OpenDataMapController : System.Web.Mvc.Controller
    {
        // GET: OpenDataMap
        public ActionResult OpenDataMap()
        {
            //var map = new Diversus.Feature.OpenDataMap.Models.Map(new Diversus.Hackathon2016.Foundation.OpenDataAgent.Models.Repository(RenderingContext.Current.Rendering.Item));
            //var items = JsonConvert.SerializeObject(map);
            var items = "";
            return this.View("OpenDataMapWidget", items);
        }
    }
}