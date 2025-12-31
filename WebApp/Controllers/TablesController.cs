using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class TablesController : Controller
{
  public IActionResult Basic() => View();
}
