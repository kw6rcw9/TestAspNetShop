using Microsoft.EntityFrameworkCore;
using testAspShop.Models;

namespace testAspShop.Data;

public class AppDbContext: DbContext
{
    public DbSet<Blog> posts { get; set; } = null!;
    public DbSet<Item> items { get; set; } = null!;
    public DbSet<Category> categories { get; set; } = null!;
    public DbSet<Order> orders { get; set; } = null!;


    public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }
}
