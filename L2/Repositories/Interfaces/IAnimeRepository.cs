using L2.Models;

namespace L2.Repositories.Interfaces;

public interface IAnimeRepository
{
    Task AddAsync(AnimeCharacter character);
    Task EditAsync(AnimeCharacter character);
    Task DeleteByIdAsync(int id);
    Task<List<AnimeCharacter>> GetFilteredAsync(string nameCharacter);
    Task<List<AnimeCharacter>> GetAllAsync();
    Task<AnimeCharacter> GetDetailsByIdAsync(int id);
}