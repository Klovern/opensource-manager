//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace opensource_manager.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProjectUser
    {
        public int ProjectUserId { get; set; }
        public string FK_UserId { get; set; }
        public string Role { get; set; }
        public System.DateTime ProjectUser_DateTime { get; set; }
        public int FK_ProjectId { get; set; }
        public string Email { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Project Project { get; set; }
    }
}
