namespace SourceControlSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Constants.ValidationConstants;

    public class SoftwareProject
    {
        public SoftwareProject()
        {
            this.Users = new HashSet<User>();
            this.Commits = new HashSet<Commit>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.MaxProjectName)]
        public string Name { get; set; }

        public bool Private { get; set; }

        [MaxLength(ValidationConstants.MaxProjectDescription)]
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Commit> Commits { get; set; }
    }
}