using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class CardsController : Controller
{
  public IActionResult Basic() => View();
}
