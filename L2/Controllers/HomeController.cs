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

    public IActionResult Index()
    {
        var characters = _animeRepository.GetAll();
        return View(characters);
    }

    public IActionResult Details(int id)
    {
        var character = _animeRepository.GetById(id);
        return View(character);
    }

    public IActionResult Contact()
    {
        return View();
    }
}