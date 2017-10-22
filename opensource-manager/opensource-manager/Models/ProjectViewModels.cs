using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace opensource_manager.Models
{
    public class ProjectViewModels
    {

        public class ScrumListItem
        {
            public string Title { get; set; }
            public int FK_ProjectID { get; set; }
        }
        public class Invite
        {
            public string Recipient { get; set; }
            public int Id { get; set; }
        }

        public class Project
        {
            [Required]
            public string Title { get; set; }
        }

        public class ProjectUser
        {
            public string UserID { get; set; }
            public string Role { get; set; }
            public int ProjectID { get; set; }

            [EmailAddress]
            public string Email { get; set; }
        }

        public class sp_RetriveAllProjects_Result
        {
        }

        public class sp_RetrieveAllScrumListItems_Result
        {
            
        }

        public class AllScrumListItems
        {
            // Logic

            public List<DB.sp_RetrieveAllScrumListItems_Result> ResultList { get; set; }
            public string Title { get; set; }
            public int id { get; set; }
        }
    }
}