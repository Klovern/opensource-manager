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
    
    public partial class Card
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Card()
        {
            this.CardActiveUsers = new HashSet<CardActiveUser>();
            this.Comments = new HashSet<Comment>();
        }
    
        public int Id { get; set; }
        public string Text { get; set; }
        public System.DateTime Created { get; set; }
        public int CreatorID { get; set; }
        public int ListID { get; set; }
    
        public virtual List List { get; set; }
        public virtual ProjectUser ProjectUser { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CardActiveUser> CardActiveUsers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }
    }
}