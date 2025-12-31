using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class IconsController : Controller
{
  public IActionResult Boxicons() => View();
}
