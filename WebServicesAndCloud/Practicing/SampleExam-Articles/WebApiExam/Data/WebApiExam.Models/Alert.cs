namespace WebApiExam.Models
{
    using System;

    public class Alert
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ExpireOn { get; set; }
    }
}
