namespace WebApiExam.Models
{
    using System;
    using System.Linq;

    public class Tag
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ArticleId { get; set; }

        public virtual Article Atricle { get; set; }
    }
}
