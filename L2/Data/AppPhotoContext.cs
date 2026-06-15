using L2.Models;
using Microsoft.EntityFrameworkCore;

namespace L2.Data;

public class AppPhotoContext(DbContextOptions<AppPhotoContext> options) : DbContext(options)
{
    public DbSet<Photo> Photos { get; set; }
}