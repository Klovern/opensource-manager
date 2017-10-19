using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        public ActionResult Invite()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Invite(ProjectViewModels.Invite invite)
        {
            var gmailClient = new System.Net.Mail.SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential("oskar.kindeland@gmail.com", "*******")
            };

            using (var msg = new System.Net.Mail.MailMessage("Oskar.kindeland@gmail.com", "Wobbler160@hotmail.com", "OSM invite", "hello"))
            {
                try
                {
                    gmailClient.Send(msg);

                }
                catch (Exception e)
                {

                }
            }

            return Redirect("index");
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

                if (CreateProjectQuery != 1)
                {
                    // Show error message
                    return View();
                }

                var CreateUserQuery = context.sp_CreateProjectUser(User.Identity.GetUserId(), User.Identity.Name, "Creator", int.Parse(Output.Value.ToString()), Output);

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
