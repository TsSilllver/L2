using L2.Models;

namespace L2.ViewModels;

public class IndexCharacterViewModel
{
    public required FilteredCharactersViewModel FilteredCharactersViewModel { get; init; }
    public required PaginatedViewModelList<AnimeCharacter> PaginatedViewModelList { get; init; }
}