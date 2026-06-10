using L2.Models;

namespace L2.ViewModels;

public class CreateCharacterViewModel
{
    public required AnimeCharacter Character { get; set; }
    public required List<Studio> Studios { get; set; }
    public required Dictionary<string, List<string>> ErrorsByProperty { get; set; }
}