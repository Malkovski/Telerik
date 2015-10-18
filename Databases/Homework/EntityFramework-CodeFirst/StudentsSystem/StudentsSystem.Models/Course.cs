namespace StudentsSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Course
    {
        private ICollection<Homework> homeworks;
        private ICollection<Student> students;

        public Course()
        {
            this.homeworks = new HashSet<Homework>();
            this.students = new HashSet<Student>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        [Column("Course title")]
        public string Name { get; set; }

        public string Materials { get; set; }

        public virtual ICollection<Student> Students 
        {
            get { return this.students; }

            set { this.students = value; }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }

            set { this.homeworks = value; }
        }
    }
}