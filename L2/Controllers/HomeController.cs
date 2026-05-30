using L2.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace L2.Controllers;

public class HomeController : Controller
{
    private readonly IAnimeRepository _animeRepository;

    public HomeController(IAnimeRepository animeRepository)
    {
        _animeRepository = animeRepository;
    }

    public async Task<IActionResult> Index()
    {
        var characters = await _animeRepository.GetAllAsync();
        return View(characters);
    }

    public async Task<IActionResult> Details(int id)
    {
        var character = await _animeRepository.GetDetailsByIdAsync(id);
        if (character == null) return NotFound();
        return View(character);
    }

    public IActionResult Contact()
    {
        return View();
    }
}