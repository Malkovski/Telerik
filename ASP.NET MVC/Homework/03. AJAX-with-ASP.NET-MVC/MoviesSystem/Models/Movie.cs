namespace MoviesSystem.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Movie
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Director { get; set; }

        public string Year { get; set; }

        public string Studio { get; set; }

        public string StudioAddress { get; set; }

        public int? LeadingMaleRoleId { get; set; }

        [ForeignKey("LeadingMaleRoleId")]
        public virtual Actor LeadingMaleRole { get; set; }

        public int? LeadingFemaleRoleId { get; set; }

        [ForeignKey("LeadingFemaleRoleId")]
        public virtual Actor LeadingFemaleRole { get; set; }
    }
}