using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace opensource_manager.Controllers
{
    [RoutePrefix("project/{projectId}/sprint")]
    public class SprintController : Controller
    {
        // GET: Sprint
        [Route("Index")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("{sprintId}")]
        public ActionResult Index(int sprintId)
        {
            Console.WriteLine("hello" + sprintId);
            return View();
        }
    }
}