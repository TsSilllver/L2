using L2.Models;

namespace L2.Repositories.Interfaces;

public interface IAnimeRepository
{
    List<AnimeCharacter> GetAll();
    AnimeCharacter? GetById(int id);
}