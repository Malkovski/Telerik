namespace StudentsSystem.Models
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Homework
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Content { get; set; }


        public string TimeSent { get; set; }

        public int? StudentId { get; set; }

        public virtual Student Student { get; set; }

        [ForeignKey("Course")]
        public int? CourseIdentificator { get; set; }

        public virtual Course Course { get; set; }
    }
}