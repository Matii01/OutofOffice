﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OutOfOfficeData;
using System.Security.Claims;

namespace OutofOffice.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected readonly UserManager<ApplicationUser> _userManager;
        protected BaseController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        protected async Task<ApplicationUser> GetUserByClaims(ClaimsPrincipal currentUser)
        {

            var userName = currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? throw new Exception("Unauthorized");

            var user = await _userManager.FindByNameAsync(userName);

            return user ?? throw new Exception("Unauthorized");
        }
    }
}
