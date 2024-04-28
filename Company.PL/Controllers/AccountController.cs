

using AutoMapper;
using Company.BLL.Interfaces;
using Company.DAL.Entities;
using Company.PL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Microsoft.AspNetCore.Authentication;

using Microsoft.AspNetCore.Http;

using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Threading.Tasks;

namespace Company.PL.Controllers
{
    public class AccountController : Controller
    {
        // private readonly UserManager<ApplicationUser> _userManager;
        //private readonly ILogger<AccountController> _logger;
        //private readonly SignInManager<ApplicationUser> _signInManager;
        //private readonly IMapper _mapper;

        //public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILogger<AccountController> logger, IMapper mapper)
        //{
        //    _userManager = userManager;
        //    _signInManager = signInManager;
        //    _logger = logger;
        //    _mapper = mapper;
        //}

        //public IActionResult SignUp()
        //{
        //    return View(new SignUpViewModel());
        //}

        //[HttpPost]
        //public async Task<IActionResult> SignUp(SignUpViewModel input)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = new ApplicationUser{
        //            Email=input.Email,
        //            UserName=input.Email.Split('@')[0],
                
        //        isActive = true
        //        };

        //        var result = await _userManager.CreateAsync(user, input.Password);

        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("Login");
        //        }

        //        foreach (var error in result.Errors)
        //        {
        //            ModelState.AddModelError("", error.Description);
        //        }
        //    }

        //    return View(input);
        //}
    }
}