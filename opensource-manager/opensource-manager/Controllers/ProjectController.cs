﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using opensource_manager.DB;
using opensource_manager.Models;

namespace opensource_manager.Controllers
{
    [RoutePrefix("project")]
    public class ProjectController : Controller
    {
        // GET: Project
        [Route("{ProjectId}/Index", Name = "ProjectIndex")]
        public ActionResult Index(int? id)
        {
            if (id.Equals(null))
            {
                return View();
            }
            else
            {
                return View("CurrentProject");
            }
        }


        [HttpPost]
        [Route("{ProjectId}/board")]
        public ActionResult CreateScrumListItem(ProjectViewModels.CreateNewList item)
        {
            using (var context = new Entities())
            {
                var CreateProjectQuery = context.sp_CreateScrumListItem(item.Id, item.Title);
            }

            return Json(new { success = true, responseText = "Added a ListItem!" }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        [Route("{ProjectId}/board/delete")]
        public ActionResult CreateScrumListItem(ProjectViewModels.DeleteScrumListItem item)
        {
            using (var context = new Entities())
            {
                var CreateProjectQuery = context.sp_DeleteScrumListItem(item.Id);
            }

            return Json(new { success = true, responseText = "Removed a ListItem!" }, JsonRequestBehavior.AllowGet);

        }


        [HttpGet]
        [Authorize]
        [Route("{ProjectId}/board")]
        public ActionResult Board(int ProjectId)
        {

            var Result = new ProjectViewModels.AllScrumListItems();

            using (var context = new Entities())
            {
                List<sp_RetrieveAllScrumListItems_Result> tmp = context.sp_RetrieveAllScrumListItems(ProjectId).ToList();
                var currentProject = context.sp_RetriveAllProjects(User.Identity.Name).First(x => x.ProjectId == ProjectId);
                Result.ResultList = tmp;
                Result.Title = currentProject.Title;
                Result.id = currentProject.ProjectId;
                ViewBag.data = Result;
                return View();

            }
        }


        // GET: Project/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }


        public ActionResult LeftNav(int? ProjectId)
        {
            Console.WriteLine("In partial controller");

            if (ProjectId != null)
            {
                using (var context = new Entities())
                {
                    var CurrentProject = context.sp_RetriveAllProjects(User.Identity.Name).First(x => x.ProjectId == ProjectId);

                    ViewBag.data = CurrentProject;
                }
                return PartialView("_Side-nav");
            }
            return null;
        }


        public ActionResult List()
        {
            ICollection<sp_RetriveAllProjects_Result> ResultList = new List<sp_RetriveAllProjects_Result>();

            using (var context = new Entities())
            {
                var CreateProjectQuery = context.sp_RetriveAllProjects(User.Identity.Name);

                foreach (var result in CreateProjectQuery)
                    ResultList.Add(result);
            }
            ViewBag.data = ResultList;
            return PartialView("_ProjectList");
        }

        [Authorize]
        public ActionResult Invite()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Invite(ProjectViewModels.Invite modelInvite)
        {
            var gmailClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("oskar.kindeland@gmail.com", "*******")
            };

            using (var msg = new MailMessage("Oskar.kindeland@gmail.com", modelInvite.Recipient, "OSM invite",
                "Go to this url www.url.com/example"))
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
                var Output = new ObjectParameter("new_identity", typeof(int));
                var CreateProjectQuery = context.sp_CreateProject(projectmodel.Title, Output);

                if (CreateProjectQuery == 0)
                    return View();

                var CreateUserQuery = context.sp_CreateProjectUser(User.Identity.GetUserId(), User.Identity.Name,
                    "Creator", int.Parse(Output.Value.ToString()), Output);

                if (CreateUserQuery != 1)
                    return View();
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