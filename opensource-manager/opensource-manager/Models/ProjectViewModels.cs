﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace opensource_manager.Models
{
    public class ProjectViewModels
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public class Project
        {
            [Required]
            [Display(Name = "Title")]
            public string Title { get; set; }
        }

        public class ProjectUser
        {
            public string UserID { get; set; }
            public string Role { get; set; }
            public int ProjectID { get; set; }
        }
    }
}