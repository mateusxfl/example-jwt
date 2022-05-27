using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ApiAuth.Models;
using Microsoft.AspNetCore.Authorization;

namespace ApiAuth.Controllers;

public class HomeController : Controller
{
    [HttpGet]
    [Route("anonymous")]
    [AllowAnonymous]
    public string Anonymous() => "Anonymous - Any user can have access.";

    [HttpGet]
    [Route("authenticated")]
    [Authorize]
    public string Authenticated() => $"Authenticated - {User.Identity.Name}";

    [HttpGet]
    [Route("employee")]
    [Authorize(Roles = "Employee,Manager")]
    public string Employee() => $"Employee - {User.Identity.Name}";

    [HttpGet]
    [Route("manager")]
    [Authorize(Roles = "Manager")]
    public string Manager() => $"Manager - {User.Identity.Name}";
}
