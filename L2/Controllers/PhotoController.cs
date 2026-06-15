using L2.Data;
using L2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace L2.Controllers;

public class PhotoController(AppPhotoContext appPhotoContext) : Controller
{
    public async Task<IActionResult> Index()
    {
        var photos = await appPhotoContext.Photos.ToListAsync();
        return View(photos);
    }

    [HttpGet]
    public IActionResult Upload()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Upload(string name, IFormFile uploadedFile)
    {
        using var memoryStream = new MemoryStream();
        await uploadedFile.CopyToAsync(memoryStream);
        var photoData = memoryStream.ToArray();

        var photo = new Photo
        {
            Name = string.IsNullOrWhiteSpace(name) ? uploadedFile.FileName : name,
            PhotoData = photoData
        };

        await appPhotoContext.Photos.AddAsync(photo);
        await appPhotoContext.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> GetImage(int id)
    {
        var photo = await appPhotoContext.Photos.FirstAsync(x => x.Id == id);
        return File(photo.PhotoData, "image/png");
    }
}