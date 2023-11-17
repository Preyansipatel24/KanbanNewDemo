using KanbanNewDemo.Models;
using KanbanNewDemo.Models.Project;
using KanbanNewDemo.Models.User;
using Microsoft.EntityFrameworkCore;

namespace KanbanNewDemo.Contxet
{
    public class KanbanContext : DbContext
    {
        public KanbanContext(DbContextOptions<KanbanContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Task1> Task1 { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>()
                .HasQueryFilter(c => !c.IsDelete);

            modelBuilder.Entity<Project>()
                .HasQueryFilter(p => !p.IsDelete);

            modelBuilder.Entity<User>()
                .HasQueryFilter(u => !u.IsDelete);
        }
    }
}