using L2.Models;

namespace L2.ViewModels;

public class FilteredCharactersViewModel
{
    public required string NameCharacter { get; init; }
    public required List<AnimeCharacter> FilteredCharacters { get; init; }
}