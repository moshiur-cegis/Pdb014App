using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models;
using Pdb014App.Models.UserManage;
using Pdb014App.Repository;

namespace Pdb014App.Controllers.UserController
{
    public class AdministrationController : Controller
    {
        //private readonly UserManager<TblUserRegistrationDetail> userManager;

        //public AdministrationController(UserManager<TblUserRegistrationDetail> userManager)
        //{
        //    this.userManager = userManager;
        //}


        private readonly UserDbContext _context;

        public AdministrationController(UserDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ListUsers()
        {
            //var users = userManager.Users;

            //var role = userManager.Users;
            //.Where(i => i.UserActivationStatusId != null)

            var users = _context.TblUserRegistrationDetail.Include(i=>i.UserActivationStatus);

            return View(users);
        }

        //[HttpGet]
        //public async Task<IActionResult> EditUser(string id)
        //{
        //    var user = await userManager.FindByIdAsync(id);

        //    if (user == null)
        //    {
        //        ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
        //        return View("NotFound");
        //    }

        //    // GetClaimsAsync retunrs the list of user Claims
        //    var userClaims = await userManager.GetClaimsAsync(user);
        //    // GetRolesAsync returns the list of user Roles
        //    var userRoles = await userManager.GetRolesAsync(user);

        //    var model = new EditUserViewModel
        //    {
        //        Id = user.Id,
        //        Email = user.Email,
        //        UserName = user.UserName,
        //        City = user.City,
        //        Claims = userClaims.Select(c => c.Value).ToList(),
        //        Roles = userRoles
        //    };

        //    return View(model);
        //}
    }
    }