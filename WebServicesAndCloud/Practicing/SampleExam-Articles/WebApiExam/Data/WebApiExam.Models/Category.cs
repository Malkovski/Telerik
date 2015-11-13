namespace WebApiExam.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class Category
    {
        private ICollection<Article> articles;

        public Category()
        {
            this.articles = new List<Article>();
        }

        public int Id { get; set; }

        //[Index(IsUnique=true)]
        //[MaxLength(30)]
        public string Name { get; set; }

        public virtual ICollection<Article> Articles
        {
            get { return this.articles; }
            set { this.articles = value; }
        }
    }
}
