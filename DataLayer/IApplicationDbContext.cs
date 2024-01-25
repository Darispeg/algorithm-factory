using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public interface IApplicationDbContext
    {
        DbSet<RequestEntity> Request { get; set; }

        int SaveChanges();
    }
}