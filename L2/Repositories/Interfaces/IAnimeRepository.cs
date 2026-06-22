using L2.Models;

namespace L2.Repositories.Interfaces;

public interface IAnimeRepository
{
    Task AddAsync(AnimeCharacter character);
    Task EditAsync(AnimeCharacter character);
    Task DeleteByIdAsync(int id);
    Task<(int countCharacters, List<AnimeCharacter> filteredCharacters)> GetFilteredAsync(string nameCharacter, int countSkip, int pageSize);
    Task<int> GetCountAsync();
    Task<List<AnimeCharacter>> GetAllAsync(int countSkip, int countTake);
    Task<AnimeCharacter> GetDetailsByIdAsync(int id);
}