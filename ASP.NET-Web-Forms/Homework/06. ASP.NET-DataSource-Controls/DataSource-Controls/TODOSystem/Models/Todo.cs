namespace TODOSystem.Models
{
    using System;
    using System.Linq;

    public class Todo
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public DateTime Date { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public string UserId { get; set; }

        public virtual AppUser User { get; set; }
    }
}