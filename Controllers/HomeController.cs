using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

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

    [Route("/books")]
    public IActionResult Books()
    {
        return View();
    }
}
