using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using opensource_manager.Models;
using Microsoft.AspNet.Identity;

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
        public async Task<ActionResult> Create(ProjectViewModels model)
        {
            string currentUserId = User.Identity.GetUserId();

            int? projectId = await CreateProject(model);

            Console.WriteLine(projectId);

            if (projectId != null)
            {
                await CreateProjectUser(model, currentUserId, (int)projectId);
            }
 
            return View();

        }

        public Task<bool> CreateProjectUser(ProjectViewModels model, string currentUserId, int projectId)
        {
            try
            {
                var cnnString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlConnection cnn = new SqlConnection(cnnString);

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnn;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_CreateProjectUser";
                    cmd.Parameters.Add("@UserId", SqlDbType.NChar, 128).Value = currentUserId;
                    cmd.Parameters.Add("@Role", SqlDbType.VarChar, 50).Value = "Creator";
                    cmd.Parameters.Add("@ProjectID", SqlDbType.VarChar, 50).Value = projectId;
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
                return Task.FromResult(true);
            }
            catch
            {
                return Task.FromResult(false);
            }
        }

        public Task<int> CreateProject(ProjectViewModels model)
        {
            int ProjectId;
            try
            {
                var cnnString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlConnection cnn = new SqlConnection(cnnString);

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnn;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_CreateProject";
                    cmd.Parameters.Add("@Title", SqlDbType.NChar, 128).Value = model.Title;
                    
                    SqlParameter outParameter = new SqlParameter();
                    outParameter.ParameterName = "@new_identity";
                    outParameter.SqlDbType = System.Data.SqlDbType.Int;
                    outParameter.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(outParameter);

                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    ProjectId =  (int)outParameter.Value;
                    cnn.Close();
                }
                return Task.FromResult(ProjectId);
            }
            catch
            {
                return null;
            }
        }
    }
}
