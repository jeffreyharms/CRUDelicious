#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
namespace CRUDelicious.Models;

public class CRUDeliciousContext : DbContext
{
    public CRUDeliciousContext(DbContextOptions options) : base(options) { }
    public DbSet<Dish> dishes { get; set; }
}