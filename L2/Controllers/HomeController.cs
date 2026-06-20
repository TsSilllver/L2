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

    [HttpGet]
    public async Task<IActionResult> Index(string nameCharacter)
    {
        FilteredCharactersViewModel filteredCharactersViewModel;

        if (!string.IsNullOrEmpty(nameCharacter))
        {
            filteredCharactersViewModel = new FilteredCharactersViewModel
            {
                NameCharacter = nameCharacter,
                FilteredCharacters = await _animeRepository.GetFilteredAsync(nameCharacter)
            };
        }
        else
        {
            filteredCharactersViewModel = new FilteredCharactersViewModel
            {
                NameCharacter = nameCharacter,
                FilteredCharacters = await _animeRepository.GetAllAsync()
            };
        }

        return View(filteredCharactersViewModel);
    }

    public async Task<IActionResult> Details(int id)
    {
        var character = await _animeRepository.GetDetailsByIdAsync(id);
        if (character == null) return NotFound();
        return View(character);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var character = await _animeRepository.GetDetailsByIdAsync(id);
        if (character == null) return NotFound();
        return View(character);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(AnimeCharacter character)
    {
        await _animeRepository.DeleteByIdAsync(character.Id);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var character = await _animeRepository.GetDetailsByIdAsync(id);
        var studios = await _studioRepository.GetAllAsync();

        var editCharacterViewModel = new EditCharacterViewModel()
        {
            Character = character,
            Studios = studios
        };

        return View(editCharacterViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditCharacterViewModel editCharacterViewModel)
    {
        editCharacterViewModel.Studios = await _studioRepository.GetAllAsync();
        await _animeRepository.EditAsync(editCharacterViewModel.Character);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Create()
    {
        var character = new AnimeCharacter
        {
            Name = string.Empty,
            Description = string.Empty,
            Age = 0,
            ImageUrl = string.Empty,
            StudioId = 1
        };

        var studios = await _studioRepository.GetAllAsync();

        var createCharacterViewModel = new CreateCharacterViewModel()
        {
            Character = character,
            Studios = studios,
            ErrorsByProperty = []
        };

        return View(createCharacterViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCharacterViewModel createCharacterViewModel)
    {
        createCharacterViewModel.Studios = await _studioRepository.GetAllAsync();

        var errorsByProperty = new Dictionary<string, List<string>>
        {
            ["Name"] = [],
            ["Description"] = []
        };

        if (createCharacterViewModel.Character.Name == null)
        {
            errorsByProperty["Name"].Add("Вы ввели пустое имя");
        }

        if (createCharacterViewModel.Character.Description == null)
        {
            errorsByProperty["Description"].Add("Вы ввели пустое описание");
        }

        if (createCharacterViewModel.Character.Description?.Length > 500)
        {
            errorsByProperty["Description"].Add("Вы ввели слишком большое описание, максимальный размер 500 символов");
        }

        if (errorsByProperty["Name"].Count > 0 || errorsByProperty["Description"].Count > 0)
        {
            createCharacterViewModel.ErrorsByProperty = errorsByProperty;
            return View(createCharacterViewModel);
        }

        createCharacterViewModel.Character.Name = createCharacterViewModel.Character.Name.Trim();
        createCharacterViewModel.Character.Description = createCharacterViewModel.Character.Description.Trim();

        await _animeRepository.AddAsync(createCharacterViewModel.Character);

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Contact()
    {
        return View();
    }
}