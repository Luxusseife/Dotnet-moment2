using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Moment2.Models;

namespace Moment2.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [Route("/add")]
    public IActionResult Add()
    {
        return View();
    }

    // Hantering av POST-anrop.
    [HttpPost]
    public IActionResult Add(BookModel model)
    {
        // Validerar formulär.
        if (ModelState.IsValid)
        {
            return View();
        }
        else
        {
            return View();
        }
    }

    [Route("/books")]
    public IActionResult Books()
    {
        // Läser in books.json-filen.
        string jsonStr = System.IO.File.ReadAllText("myBooks.json");

        // Deserialiserar JSON.
        var books = JsonSerializer.Deserialize<List<BookModel>>(jsonStr);

        // Returnerar vyn och skickar med listan med böcker.
        return View(books);
    }
}
