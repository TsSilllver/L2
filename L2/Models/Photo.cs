namespace L2.Models;

public class Photo
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public byte[] PhotoData { get; set; } = [];
}