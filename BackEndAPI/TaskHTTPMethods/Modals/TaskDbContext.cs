using Microsoft.EntityFrameworkCore;

namespace TaskHTTPMethods.Modals
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Category)
                .WithMany(a => a.Employees)
                .HasForeignKey(e => e.CategoryId);
        }
    }
}
