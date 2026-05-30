using L2.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace L2.Data;

public class AnimeDbContext : DbContext
{
    public DbSet<AnimeCharacter> AnimeCharacters { get; set; }
    public DbSet<Studio> Studios { get; set; }

    public AnimeDbContext(DbContextOptions<AnimeDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Начальные данные для студий
        modelBuilder.Entity<Studio>().HasData(
            new Studio { Id = 1, Name = "Pierrot", Country = "Япония", FoundedYear = 1979 },
            new Studio { Id = 2, Name = "Toei Animation", Country = "Япония", FoundedYear = 1948 },
            new Studio { Id = 3, Name = "Madhouse", Country = "Япония", FoundedYear = 1972 }
        );

        // Начальные данные для персонажей
        modelBuilder.Entity<AnimeCharacter>().HasData(
            new AnimeCharacter { Id = 1, Name = "Наруто Узумаки", Description = "Ниндзя.", Age = 17, ImageUrl = "https://i1-c.pinimg.com/736x/85/2c/88/852c880e20debd8b1ed40b1ce53aa250.jpg", StudioId = 1 },
            new AnimeCharacter { Id = 2, Name = "Гоку", Description = "Сайян, защищающий Землю.", Age = 35, ImageUrl = "https://i.pinimg.com/736x/e1/c4/d1/e1c4d1af1e67fa17ffa976df8285fcfc.jpg", StudioId = 2 },
            new AnimeCharacter { Id = 3, Name = "Лайт Ягами", Description = "Гениальный школьник, нашедший тетрадь смерти.", Age = 23, ImageUrl = "https://i.pinimg.com/736x/02/c1/11/02c11137c640b5a14e8428308a0a56ba.jpg", StudioId = 3 }
        );
    }
}