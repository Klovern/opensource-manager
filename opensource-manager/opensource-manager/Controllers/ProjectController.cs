using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using opensource_manager.Models;
using Microsoft.AspNet.Identity;
using opensource_manager.DB;

namespace opensource_manager.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {
            return View();
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Project/Create       
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create(ProjectViewModels.Project projectmodel)
        {
            using (var context = new Entities())
            {
                ObjectParameter Output = new ObjectParameter("new_identity", typeof(Int32));
                var CreateProjectQuery = context.sp_CreateProject(projectmodel.Title, Output);
                int projectId = int.Parse(Output.Value.ToString());

                if (CreateProjectQuery != 1)
                {
                    // Show error message
                    return View();
                }

                var CreateUserQuery = context.sp_CreateProjectUser(User.Identity.GetUserId(), "Creator", projectId);

                if (CreateUserQuery != 1)
                {
                    // Show error message
                    return View();
                }
            }
            return View();
        }

        // GET: Project
        public ActionResult Details()
        {
            return View();
        }
    }
}
