using L2.Models;
using L2.Repositories.Interfaces;
using L2.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace L2.Controllers;

public class HomeController : Controller
{
    private readonly IAnimeRepository _animeRepository;
    private readonly IStudioRepository _studioRepository;

    public HomeController(IAnimeRepository animeRepository, IStudioRepository studioRepository)
    {
        _animeRepository = animeRepository;
        _studioRepository = studioRepository;
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

    public async Task<IActionResult> Delete(int id)
    {
        await _animeRepository.DeleteByIdAsync(id);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(int id)
    {
        var character = await _animeRepository.GetDetailsByIdAsync(id);
        var studios = await _studioRepository.GetAllAsync();

        var viewModel = new EditCharacterViewModel
        {
            Character = character ?? new AnimeCharacter(),
            Studios = studios
        };

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditCharacterViewModel editCharacterViewModel)
    {
        var isModelValid = ModelState.IsValid;
        var characterName = editCharacterViewModel.Character?.Name;

        if (!isModelValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            // Ошибки увидишь в отладчике
        }
        if (ModelState.IsValid)
        {
            await _animeRepository.EditAsync(editCharacterViewModel.Character);
            return RedirectToAction("Index");
        }

        editCharacterViewModel.Studios = await _studioRepository.GetAllAsync();
        return View(editCharacterViewModel);
    }

    public async Task<IActionResult> Create()
    {
        var studios = await _studioRepository.GetAllAsync();

        var viewModel = new CreateCharacterViewModel
        {
            Character = new AnimeCharacter(),
            Studios = studios,
            ErrorsByProperty = new Dictionary<string, List<string>>()
        };

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCharacterViewModel viewModel)
    {
        viewModel.Studios = await _studioRepository.GetAllAsync();

        var errorsByProperty = new Dictionary<string, List<string>>
        {
            ["Name"] = [],
            ["Description"] = [],
            ["Age"] = [],
            ["ImageUrl"] = [],
            ["StudioId"] = []
        };

        if (string.IsNullOrWhiteSpace(viewModel.Character.Name))
        {
            errorsByProperty["Name"].Add("Вы ввели пустое имя");
        }
        else if (viewModel.Character.Name.Length < 2)
        {
            errorsByProperty["Name"].Add("Имя должно содержать минимум 2 символа");
        }
        else if (viewModel.Character.Name.Length > 50)
        {
            errorsByProperty["Name"].Add("Имя должно содержать максимум 50 символов");
        }


        if (string.IsNullOrWhiteSpace(viewModel.Character.Description))
        {
            errorsByProperty["Description"].Add("Вы ввели пустое описание");
        }
        else if (viewModel.Character.Description.Length < 10)
        {
            errorsByProperty["Description"].Add("Описание должно содержать минимум 10 символов");
        }
        else if (viewModel.Character.Description.Length > 500)
        {
            errorsByProperty["Description"].Add("Описание должно содержать максимум 500 символов");
        }


        if (viewModel.Character.Age < 1)
        {
            errorsByProperty["Age"].Add("Возраст должен быть минимум 1 год");
        }
        else if (viewModel.Character.Age > 1000)
        {
            errorsByProperty["Age"].Add("Возраст должен быть максимум 1000 лет");
        }


        if (string.IsNullOrWhiteSpace(viewModel.Character.ImageUrl))
        {
            errorsByProperty["ImageUrl"].Add("Введите URL картинки");
        }
        else if (!viewModel.Character.ImageUrl.StartsWith("http"))
        {
            errorsByProperty["ImageUrl"].Add("Введите корректный URL (начинается с http:// или https://)");
        }


        if (viewModel.Character.StudioId <= 0)
        {
            errorsByProperty["StudioId"].Add("Выберите студию");
        }


        if (errorsByProperty["Name"].Count > 0 ||
            errorsByProperty["Description"].Count > 0 ||
            errorsByProperty["Age"].Count > 0 ||
            errorsByProperty["ImageUrl"].Count > 0 ||
            errorsByProperty["StudioId"].Count > 0)
        {
            viewModel.ErrorsByProperty = errorsByProperty;
            return View(viewModel);
        }


        viewModel.Character.Name = viewModel.Character.Name.Trim();
        viewModel.Character.Description = viewModel.Character.Description.Trim();

        await _animeRepository.AddAsync(viewModel.Character);

        return RedirectToAction("Index");
    }

    public IActionResult Contact()
    {
        return View();
    }
}