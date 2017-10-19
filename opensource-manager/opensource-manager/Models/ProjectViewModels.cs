﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace opensource_manager.Models
{
    public class ProjectViewModels
    {
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
    }
}