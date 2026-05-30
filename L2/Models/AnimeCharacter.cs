namespace L2.Models;

public class AnimeCharacter
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public int Age { get; set; }
    public string ImageUrl { get; set; } = "";

    public int StudioId { get; set; }
    public Studio? Studio { get; set; }
}