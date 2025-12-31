using System.Diagnostics;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using CredaData.Client;
using System.Linq.Expressions;
using DocumentFormat.OpenXml.Spreadsheet;

namespace WebApp.Controllers;
[AllowAnonymous]
public class AuthController : Controller
{
    private readonly IFacade<UserProfileModel> _userFacade;
    private readonly IFacade<AdminPanelUserModel> adminPanelUserFacade;
    public AuthController(IFacade<UserProfileModel> userFacade
        , IFacade<AdminPanelUserModel> adminPanelUserFacade)
    {
        _userFacade = userFacade;
        this.adminPanelUserFacade = adminPanelUserFacade;
    }

    public IActionResult ForgotPasswordBasic() => View();
    public IActionResult LoginBasic() => View();
    public IActionResult RegisterBasic() => View();

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginModel model, string returnUrl = null)
    {
        if (ModelState.IsValid)
        {
            var mobileNumber = model.Username;
            Expression<Func<UserProfileModel, bool>> filter = a => a.MobileNumber == mobileNumber;
            var res = _userFacade.ListAllAsync(filter).Result.FirstOrDefault();
            if (res != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, res.UserName)
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                //var authProperties = new AuthenticationProperties
                //{
                //    IsPersistent = model.RememberMe
                //};

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction(nameof(DashboardsController.LandingPage), "Dashboards");
                    //return RedirectToAction(nameof(DashboardsController.Index), "Dashboards");
                }
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        }

        return View("LoginBasic", model);
    }


    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> AdminPanelLogin(LoginModel model, string returnUrl = null)
    {
        if (ModelState.IsValid)
        {
            var userName = model.Username;
            var password = model.Password;

            // Retrieve the user based on username
            Expression<Func<AdminPanelUserModel, bool>> filter = a => a.UserName == userName;
            var res = adminPanelUserFacade.ListAllAsync(filter).Result.FirstOrDefault();

            if (res != null)
            {
                // Check if the provided password matches the stored password
                if (res.Password == password) // Consider hashing the password for security
                {
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, res.UserName),
                    new Claim("UserId", res.Id.ToString() ?? string.Empty), // Additional claims if needed
                    new Claim("RoleId", res.RoleId?.ToString() ?? string.Empty),
                    new Claim("DistrictId", res.DistrictId?.ToString() ?? string.Empty),
                    new Claim("ZonalId", res.ZonalId?.ToString() ?? string.Empty)
                };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity));

                    //if (Url.IsLocalUrl(returnUrl))
                    //{
                    //    return Redirect(returnUrl);
                    //}
                    //else
                    //{
                    //    return RedirectToAction(nameof(DashboardsController.LandingPage), "Dashboards");
                    //    //return RedirectToAction(nameof(DashboardsController.Index), "Dashboards");
                    //}
                    if (res.RoleId == -1) // Assuming -1 is Administrator RoleId
                    {
                        return RedirectToAction(nameof(AdministratorController.Index), "Administrator");
                    }
                    else
                    {
                        return RedirectToAction(nameof(DashboardsController.LandingPage), "Dashboards");
                    }

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt. Incorrect password.");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt. User not found.");
            }
        }
        return View("LoginBasic", model);
    }


    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction(nameof(HomeController.Index), "Home");
    }

    private bool ValidateUser(string mobileNumber, string password)
    {
        // Replace with your actual user validation logic
        //var res = _userFacade.GetAsync(mobileNumber).Result;
        Expression<Func<UserProfileModel, bool>> filter = a => a.MobileNumber == mobileNumber;
        var res = _userFacade.ListAllAsync(filter).Result;
        if (res == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
