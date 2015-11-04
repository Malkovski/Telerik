namespace SourceControlSystem.Api.Models.Projects
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Constants.ValidationConstants;

    public class SaveProjectRequestModel
    {
        [Required]
        [MaxLength(ValidationConstants.MaxProjectName)]
        public string Name { get; set; }

        [MaxLength(ValidationConstants.MaxProjectDescription)]
        public string Description { get; set; }

        public bool Private { get; set; }
    }
}