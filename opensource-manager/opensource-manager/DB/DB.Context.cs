﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectUser> ProjectUsers { get; set; }
        public virtual DbSet<ScrumListItem> ScrumListItems { get; set; }
        public virtual DbSet<EventLog> EventLogs { get; set; }
    
        public virtual int sp_CreateProject(string title, ObjectParameter new_identity)
        {
            var titleParameter = title != null ?
                new ObjectParameter("Title", title) :
                new ObjectParameter("Title", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_CreateProject", titleParameter, new_identity);
        }
    
        public virtual int sp_CreateProjectUser(string userId, string email, string role, Nullable<int> projectId, ObjectParameter new_identity)
        {
            var userIdParameter = userId != null ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var roleParameter = role != null ?
                new ObjectParameter("Role", role) :
                new ObjectParameter("Role", typeof(string));
    
            var projectIdParameter = projectId.HasValue ?
                new ObjectParameter("ProjectId", projectId) :
                new ObjectParameter("ProjectId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_CreateProjectUser", userIdParameter, emailParameter, roleParameter, projectIdParameter, new_identity);
        }
    
        public virtual ObjectResult<sp_RetriveAllProjects_Result> sp_RetriveAllProjects(string email)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_RetriveAllProjects_Result>("sp_RetriveAllProjects", emailParameter);
        }
    
        public virtual int sp_CreateScrumListItem(Nullable<int> fK_ProjectID, string title)
        {
            var fK_ProjectIDParameter = fK_ProjectID.HasValue ?
                new ObjectParameter("FK_ProjectID", fK_ProjectID) :
                new ObjectParameter("FK_ProjectID", typeof(int));
    
            var titleParameter = title != null ?
                new ObjectParameter("Title", title) :
                new ObjectParameter("Title", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_CreateScrumListItem", fK_ProjectIDParameter, titleParameter);
        }
    
        public virtual ObjectResult<sp_RetrieveAllScrumListItems_Result> sp_RetrieveAllScrumListItems(Nullable<int> projectId)
        {
            var projectIdParameter = projectId.HasValue ?
                new ObjectParameter("ProjectId", projectId) :
                new ObjectParameter("ProjectId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_RetrieveAllScrumListItems_Result>("sp_RetrieveAllScrumListItems", projectIdParameter);
        }
    
        public virtual int sp_DeleteScrumListItem(Nullable<int> scrumListId)
        {
            var scrumListIdParameter = scrumListId.HasValue ?
                new ObjectParameter("ScrumListId", scrumListId) :
                new ObjectParameter("ScrumListId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_DeleteScrumListItem", scrumListIdParameter);
        }
    }
}
