using L2.Models;
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

    public IActionResult Create()
    {
        var studio = new Studio
        {
            Name = string.Empty,
            Country = string.Empty,
            FoundedYear = DateTime.Now.Year
        };
        return View(studio);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Studio studio)
    {
        await _animeRepository.AddStudioAsync(studio);
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Contact()
    {
        return View();
    }
}