namespace NewsSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Like
    {
        public int Id { get; set; }

        [Required]
        public int Value { get; set; }
    }
}