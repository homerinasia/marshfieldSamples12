using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/
        public string GetString()
        {
            person p = new person();
            p.Id = 1;
            p.Name = "bob";
            return p.Name;
        }

        public ActionResult GetView()
        {
            return View("MyView");
        }

    }

    public class person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
