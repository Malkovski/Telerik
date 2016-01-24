namespace TODOSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TODOSystem.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TodoDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TodoDbContext context)
        {
            var seedCategories = new Category[]
            {
                new Category { Name = "Andrews" },
                new Category { Name = "Brices" },
                new Category { Name = "Rowans" },
                new Category { Name = "Peters" },
                new Category { Name = "Lambsons" },
                new Category { Name = "Millers" },
                new Category { Name = "Andrews&Peters" },
                new Category { Name = "Brices&Lambson" },
                new Category { Name = "Rowans&Miller" },
                new Category { Name = "PetersAndrew" },
                new Category { Name = "BriLambsonce" },
                new Category { Name = "MRowaniller" }
            };

            context.Categories.AddOrUpdate(x => x.Name, seedCategories);
            context.SaveChanges();

            var seedTodos = new Todo[]
            {
                new Todo {Date =  DateTime.Now, UserId = "53640cee-555a-4782-ab7d-c43d8f874bc3", CategoryId = 1, Body = "qqqqq", Title = "Vodka" },
                new Todo {Date =  DateTime.Now, UserId = "53640cee-555a-4782-ab7d-c43d8f874bc3", CategoryId = 2, Body = "aaaa", Title = "Run" },
                new Todo {Date =  DateTime.Now, UserId = "53640cee-555a-4782-ab7d-c43d8f874bc3", CategoryId = 3, Body = "sssss" ,Title = "Sleep" },
                new Todo {Date =  DateTime.Now, UserId = "53640cee-555a-4782-ab7d-c43d8f874bc3", CategoryId = 4, Body = "hfghjhgjhghjghjghj" ,Title = "Cry" },
                new Todo {Date =  DateTime.Now, UserId = "53640cee-555a-4782-ab7d-c43d8f874bc3", CategoryId = 5, Body = "mmmmmmm" ,Title = "CryAgain" },
                new Todo {Date =  DateTime.Now, UserId = "53640cee-555a-4782-ab7d-c43d8f874bc3", CategoryId = 6, Body = "kkkkkkk" ,Title = "Lie" },
                new Todo {Date =  DateTime.Now, UserId = "53640cee-555a-4782-ab7d-c43d8f874bc3", CategoryId = 7, Body = "hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhg" ,Title = "Learn" },
                new Todo {Date =  DateTime.Now, UserId = "53640cee-555a-4782-ab7d-c43d8f874bc3", CategoryId = 8, Body = "1000hhhhhhhh" ,Title = "1234" },
                new Todo {Date =  DateTime.Now, UserId = "53640cee-555a-4782-ab7d-c43d8f874bc3", CategoryId = 8, Body = "9999999" ,Title = "Row87678787878r" },
                new Todo {Date =  DateTime.Now, UserId = "53640cee-555a-4782-ab7d-c43d8f874bc3", CategoryId = 8, Body = "kjkjkjkgffgffgfgfffffffffff" ,Title = "Go Home" },
                new Todo {Date =  DateTime.Now, UserId = "53640cee-555a-4782-ab7d-c43d8f874bc3", CategoryId = 9, Body = "hhhhhh" ,Title = "Work" },
                new Todo {Date =  DateTime.Now, UserId = "53640cee-555a-4782-ab7d-c43d8f874bc3", CategoryId = 4, Body = "hhhhhhhhh" ,Title = "Kill" }
            };

            context.Todos.AddOrUpdate(x => x.Title, seedTodos);
            context.SaveChanges();
        }
    }
}
