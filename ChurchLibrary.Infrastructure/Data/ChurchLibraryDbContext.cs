using ChurchLibrary.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChurchLibrary.Infrastructure.Data
{
    public class ChurchLibraryDbContext : IdentityDbContext<User>
    {
        public ChurchLibraryDbContext(DbContextOptions<ChurchLibraryDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Personalize o modelo se for necessário
        }
    }
}
