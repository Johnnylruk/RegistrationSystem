using Microsoft.EntityFrameworkCore;
using RegistrationSystem.Domain.Models;
using RegistrationSystem.Infrastructure.Data.Map;

namespace RegistrationSystem.Infrastructure.Data
{
    public class DataBaseContext : DbContext
    {

        public DataBaseContext(DbContextOptions<DataBaseContext> opetins) : base(opetins)
        {

        }

        public DbSet<ContactModel> Contacts { get; set; }
        public DbSet<UserModel> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContactMap());

            base.OnModelCreating(modelBuilder);

        }

    }
}
