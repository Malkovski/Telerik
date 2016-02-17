namespace MvcTemplate.Web.ViewModels.Home
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class CustomGridViewModel
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<JokeViewModel> Jokes { get; set; }
    }
}