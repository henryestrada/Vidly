using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Vidly.Controllers;

[AllowAnonymous]
public class RentalsController : Controller
{
    public IActionResult New()
    {
        return View();
    }
}
