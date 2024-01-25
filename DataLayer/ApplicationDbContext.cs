using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DataLayer
{
    public partial class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<RequestEntity> Request { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
