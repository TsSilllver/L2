using L2.Data;
using L2.Models;
using L2.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace L2.Repositories;

public class StudioRepository : IStudioRepository
{
    private readonly AnimeDbContext _context;

    public StudioRepository(AnimeDbContext context)
    {
        _context = context;
    }

    public async Task<List<Studio>> GetAllAsync()
    {
        return await _context.Studios.ToListAsync();
    }
}