using L2.Models;

namespace L2.ViewModels;

public class EditCharacterViewModel
{
    public required AnimeCharacter Character { get; set; }
    public required List<Studio> Studios { get; set; }
}