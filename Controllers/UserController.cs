using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using myCoreProjectNew.Models;

namespace myCoreProjectNew.Controllers;

public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(int id)
    {
        Console.WriteLine(id);
        ViewBag.id = id;
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult SubmitForm(Models.User UserModel) 
    {
        Console.WriteLine(UserModel.Email);
        Console.WriteLine(UserModel.Name);
        ViewBag.Email = UserModel.Email;
        ViewBag.Name = UserModel.Name;
         return View(UserModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
