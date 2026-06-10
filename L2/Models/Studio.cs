using System.ComponentModel.DataAnnotations;

namespace L2.Models;

public class Studio
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Название студии обязательно")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Название должно быть от 2 до 100 символов")]
    public string Name { get; set; } = "";

    [Required(ErrorMessage = "Страна обязательна")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Страна должна быть от 2 до 50 символов")]
    public string Country { get; set; } = "";

    [Range(1900, 2026, ErrorMessage = "Год основания должен быть от 1900 до 2026")]
    public int FoundedYear { get; set; }
}