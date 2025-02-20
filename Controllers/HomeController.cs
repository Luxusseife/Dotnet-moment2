using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Moment2.Models;

namespace Moment2.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        // Sätter titel på sidan.
        ViewData["Title"] = "Home";
        return View();
    }

    [HttpGet]
    [Route("/add")]
    public IActionResult Add()
    {
        // Sätter titel på sidan.
        ViewData["Title"] = "Add book";

        // Sätter aktuellt år i ViewBag.
        var currentYear = DateTime.Now.Year;
        ViewBag.CurrentYear = currentYear;

        return View();
    }

    // Sätter en statisk variabel som hanterar JSON-indentering i den interna JSON-filen. 
    private static readonly JsonSerializerOptions jsonOptions = new() { WriteIndented = true };

    // Hantering av POST-anrop.
    [HttpPost]
    [Route("/add")]
    public IActionResult Add(BookModel model)
    {
        // Sätter aktuellt år i ViewBag.
        var currentYear = DateTime.Now.Year;
        ViewBag.CurrentYear = currentYear;

        // Validerar formuläret, läser in json-fil och lagrar ny data.
        if (ModelState.IsValid)
        {
            // Läser in myBooks.json-filen.
            string jsonStr = System.IO.File.ReadAllText("myBooks.json");

            // Deserialiserar JSON.
            var books = JsonSerializer.Deserialize<List<BookModel>>(jsonStr, jsonOptions) ?? new List<BookModel>();

            // Genererar ett nytt ID. Börjar på 1 om listan är tom, annars läggs +1 på varje gång en bok läggs till.
            model.Id = books.Count > 0 ? books.Max(b => b.Id) + 1 : 1;

            // Lägger till en ny kurs.
            if (books != null)
            {
                books.Add(model);

                // Serialiserar JSON.
                jsonStr = JsonSerializer.Serialize(books, jsonOptions);

                // Skriver in/över ändringarna till myBooks.json-filen.
                System.IO.File.WriteAllText("myBooks.json", jsonStr);
            }

            // Återställer formuläret.
            ModelState.Clear();

            // Omdirigerar användaren till "My books", tabellen med böcker.
            return RedirectToAction("Books", "Home");
        }

        return View();
    }

    [Route("/books")]
    public IActionResult Books()
    {
        // Sätter titel på sidan.
        ViewData["Title"] = "My books";

        // Läser in books.json-filen.
        string jsonStr = System.IO.File.ReadAllText("myBooks.json");

        // Deserialiserar JSON.
        var books = JsonSerializer.Deserialize<List<BookModel>>(jsonStr);

        // Returnerar vyn och skickar med listan med böcker.
        return View(books);
    }
}
