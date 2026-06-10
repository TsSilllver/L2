using L2.Models;

namespace L2.Repositories.Interfaces;

public interface IStudioRepository
{
    Task<List<Studio>> GetAllAsync();
}