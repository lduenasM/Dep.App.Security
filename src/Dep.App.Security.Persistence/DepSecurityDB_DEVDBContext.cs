using Dep.App.Security.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dep.App.Security.Persistence;
public class DepSecurityDB_DEVDBContext : DbContext
{
    public DepSecurityDB_DEVDBContext()
    {

    }
    public DepSecurityDB_DEVDBContext(DbContextOptions<DepSecurityDB_DEVDBContext> options): base(options)
    {

    }

    public DbSet<Genre> Genres { get; set; }
}
