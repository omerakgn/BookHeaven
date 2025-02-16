using BookHeaven.Core.Models;
using BookHeaven.Core.Models.Identity;
using BookHeaven.Repository.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookHeaven.Repository
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
       
        public DbSet<Book> Books { get; set; }
        public DbSet<Categori> Categories { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Core.Models.File> Files { get; set; }
        public DbSet<ProductImage> ProductImageFiles { get; set; }
        public DbSet<InvoiceFile> InvoiceFiles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfigurations());
            modelBuilder.ApplyConfiguration(new CategoriConfigurations());
            modelBuilder.ApplyConfiguration(new GroupConfigurations());
            modelBuilder.ApplyConfiguration(new PersonConfigurations());
            modelBuilder.ApplyConfiguration(new CommentConfigurations());
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            
            return base.SaveChanges();
        }

        public override  Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries().Where(x => x.Entity.GetType().GetProperty("CreateDate") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreateDate").CurrentValue = DateTime.Now;
                }
                else if (entry.State == EntityState.Modified)
                {
                   
                    entry.Property("CreateDate").IsModified = false;
                    entry.Property("UpdateDate").CurrentValue = DateTime.Now;
                }

                
            }

            return base.SaveChangesAsync(cancellationToken);
            
            /* var datas = ChangeTracker.Entries<BaseEntity>();

             foreach (var data in datas) 
             {
                 _ = data.State switch 
                 {
                     EntityState.Added => data.Entity.CreateDate = DateTime.Now,
                     EntityState.Modified => data.Entity.UpdateDate = DateTime.Now,

                 };


             }
            */


        }


    }
}
