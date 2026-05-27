using L2.Models;
using L2.Repositories.Interfaces;

namespace L2.Repositories;

public class AnimeRepository : IAnimeRepository
{
    private List<AnimeCharacter> _characters;

    public AnimeRepository()
    {
        _characters = new List<AnimeCharacter>
        {
            new() { Id = 1, Name = "Наруто Узумаки", Anime = "Наруто", 
                Age = 17, Description = "Ниндзя.", 
                ImageUrl = "https://i1-c.pinimg.com/736x/85/2c/88/852c880e20debd8b1ed40b1ce53aa250.jpg" },
            new() { Id = 2, Name = "Гоку", Anime = "Драгонболл", 
                Age = 35, Description = "Сайян, защищающий Землю.", 
                ImageUrl = "https://i.pinimg.com/736x/e1/c4/d1/e1c4d1af1e67fa17ffa976df8285fcfc.jpg" },
            new() { Id = 3, Name = "Лайт Ягами", Anime = "Тетрадь смерти", 
                Age = 23, Description = "Гениальный школьник, нашедший тетрадь смерти.", 
                ImageUrl = "https://i.pinimg.com/736x/02/c1/11/02c11137c640b5a14e8428308a0a56ba.jpg" }
        };
    }

    public List<AnimeCharacter> GetAll() => _characters;
    public AnimeCharacter? GetById(int id) => _characters.FirstOrDefault(x => x.Id == id);
}