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

    public async Task AddAsync(AnimeCharacter character)
    {
        await _context.AnimeCharacters.AddAsync(character);
        await _context.SaveChangesAsync();
    }

    public async Task EditAsync(AnimeCharacter character)
    {
        var editingCharacter = await GetByIdAsync(character.Id);

        editingCharacter.StudioId = character.StudioId;
        editingCharacter.Age = character.Age;
        editingCharacter.Description = character.Description;
        editingCharacter.Name = character.Name;
        editingCharacter.ImageUrl = character.ImageUrl;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        var character = await GetByIdAsync(id);
        _context.AnimeCharacters.Remove(character);
        await _context.SaveChangesAsync();
    }

    public async Task<List<AnimeCharacter>> GetAllAsync(int countSkip, int countTake)
    {
        return await _context.AnimeCharacters
            .Skip(countSkip)
            .Take(countTake)
            .ToListAsync();
    }

    public async Task<(int countCharacters, List<AnimeCharacter> filteredCharacters)> GetFilteredAsync(
        string nameCharacter, int countSkip, int pageSize)
    {
        var queryFilteredCharacters = _context.AnimeCharacters
            .Where(c => c.Name.Contains(nameCharacter));

        var countCharacters = await queryFilteredCharacters.CountAsync();
        var filteredCharacters = await queryFilteredCharacters
            .Skip(countSkip)
            .Take(pageSize)
            .ToListAsync();

        return (countCharacters, filteredCharacters);
    }

    public async Task<int> GetCountAsync()
    {
        return await _context.AnimeCharacters.CountAsync();
    }

    public async Task<AnimeCharacter> GetByIdAsync(int id)
    {
        return await _context.AnimeCharacters.FirstAsync(x => x.Id == id);
    }

    public async Task<AnimeCharacter> GetDetailsByIdAsync(int id)
    {
        return await _context.AnimeCharacters
            .Include(x => x.Studio)
            .FirstAsync(x => x.Id == id);
    }
}