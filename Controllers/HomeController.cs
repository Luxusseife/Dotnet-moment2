using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Moment2.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
