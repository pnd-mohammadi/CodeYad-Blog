using CodeYad_Blog.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog.DataLayer.Context
{
    public class BlogContext:DbContext
    {
        public BlogContext(DbContextOptions<BlogContext>options):base(options)
        { }
        public DbSet<Post> posts { get; set; }
        public DbSet<PostComment> postComments { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Category> categories { get; set; }
        public object Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(s => s.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}
