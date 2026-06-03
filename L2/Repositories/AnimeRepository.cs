using L2.Data;
using L2.Models;
using L2.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace L2.Repositories;

public class AnimeRepository : IAnimeRepository
{
    private readonly AnimeDbContext _context;

    public AnimeRepository(AnimeDbContext context)
    {
        _context = context;
    }

    public async Task<List<AnimeCharacter>> GetAllAsync()
    {
        return await _context.AnimeCharacters.ToListAsync();
    }

    public async Task<AnimeCharacter?> GetDetailsByIdAsync(int id)
    {
        return await _context.AnimeCharacters
            .Include(x => x.Studio)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddStudioAsync(Studio studio)
    {
        await _context.Studios.AddAsync(studio);
        await _context.SaveChangesAsync();
    }
}