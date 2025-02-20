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

    [HttpGet]
    [Route("/add")]
    public IActionResult Add()
    {
        // Sätter aktuellt år i ViewBag.
        var currentYear = DateTime.Now.Year;
        ViewBag.CurrentYear = currentYear;

        return View();
    }

    // Hantering av POST-anrop.
    [HttpPost]
    public IActionResult Add(BookModel model)
    {
        // Sätter aktuellt år i ViewBag.
        var currentYear = DateTime.Now.Year;
        ViewBag.CurrentYear = currentYear;

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
