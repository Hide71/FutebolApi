using FutebolApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FutebolApi.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    public DbSet<Time> Times => Set<Time>();
}