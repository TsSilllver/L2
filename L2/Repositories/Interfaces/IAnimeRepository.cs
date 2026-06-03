using L2.Models;

namespace L2.Repositories.Interfaces;

public interface IAnimeRepository
{
    Task<List<AnimeCharacter>> GetAllAsync();
    Task<AnimeCharacter?> GetDetailsByIdAsync(int id);

    Task AddStudioAsync(Studio studio);
}