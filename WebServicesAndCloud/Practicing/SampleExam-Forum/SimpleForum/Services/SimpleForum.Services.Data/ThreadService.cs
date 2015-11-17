namespace SimpleForum.Services.Data
{
    using System;
    using System.Linq;
    using SimpleForum.Data;
    using SimpleForum.Models;
    using SimpleForum.Services.Data.Contracts;
    using SimpleForum.GlobalConstants;

    public class ThreadService : IThreadService
    {
        private readonly IRepository<Thread> threads;
        private readonly IRepository<Category> categories;

        public ThreadService(IRepository<Thread> threadRepo, IRepository<Category> categoryRepo)
        {
            this.threads = threadRepo;
            this.categories = categoryRepo;
        }

        public IQueryable<Thread> All(int page = 1, int pageSize = UtilityConstants.DefaultPageSize)
        {
            return this.threads
                .All()
                .OrderByDescending(s => s.DateCreated)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }

        // The logic here can be different ofc - parameters depends ...!!!!!!!!
        public int Add(string title, string content, string category, string userId)
        {
            var newThread = new Thread
            {
                Title = title,
                Content = content,
                DateCreated = DateTime.UtcNow,
                UserId = userId
            };

            var existingCategory = this.categories.All().Where(x => x.Name == category).FirstOrDefault();

            if (existingCategory != null)
            {
                newThread.Categories.Add(existingCategory);
            }
            else
            {
                var newCategory = new Category
                {
                    Name = category
                };

                this.categories.Add(newCategory);
                newCategory.Threads.Add(newThread);
            }

            this.threads.Add(newThread);
            this.categories.SaveChanges();

            return newThread.Id;
        }
    }
}
