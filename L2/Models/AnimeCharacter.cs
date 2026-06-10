using System.ComponentModel.DataAnnotations;

namespace L2.Models;

public class AnimeCharacter
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Имя обязательно для заполнения")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Имя должно быть от 2 до 50 символов")]
    public string Name { get; set; } = "";

    [Required(ErrorMessage = "Описание обязательно для заполнения")]
    [StringLength(500, MinimumLength = 10, ErrorMessage = "Описание должно быть от 10 до 500 символов")]
    public string Description { get; set; } = "";

    [Range(1, 1000, ErrorMessage = "Возраст должен быть от 1 до 1000 лет")]
    public int Age { get; set; }

    [Required(ErrorMessage = "URL картинки обязателен")]
    [Url(ErrorMessage = "Введите корректный URL картинки")]
    public string ImageUrl { get; set; } = "";

    [Required(ErrorMessage = "Выберите студию")]
    public int StudioId { get; set; }

    public Studio? Studio { get; set; }
}