using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;

namespace Repository;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<Hamster>? Hamsters { get; set; }
    public DbSet<Match>? Matches { get; set; }
    public DbSet<User>?  Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelbuilder)
    {
        modelbuilder.ApplyConfiguration(new HamsterConfiguration());
        modelbuilder.ApplyConfiguration(new MatchConfiguration());
    }
}
