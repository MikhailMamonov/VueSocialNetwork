using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using VueJSSocialNetwork.Services.Models;
using VueJSSocialNetwork.Services;
using VueJSSocialNetwork.Web.Extensions;

namespace VueJSSocialNetwork.Web.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private const int PageSize = 3;

        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
            //db = context;
            //if (!db.Users.Any())
            //{
            //    db.Users.Add(new User { Name = "Tom", Age = 26 });
            //    db.Users.Add(new User { Name = "Alice", Age = 31 });
            //    db.SaveChanges();
            //}
        }

        [HttpGet("{page}", Name = "Index")]
        public IActionResult Index(int? page)
        {
            UserAccountModel user = this.userService.UserDetailsFriendsCommentsAndPosts(this.User.GetUserId(), page ?? 1, PageSize);

            return new OkObjectResult(user);

        }

        [HttpGet("{id, page}", Name = "Get")]
        public IActionResult AccountDetails(string id, int? page)
        {
            //if (this.User.GetUserId() == id) {
            //    ViewData[GlobalConstants.Authorization] = GlobalConstants.FullAuthorization;
            //}

            UserAccountModel user = this.userService.UserDetails(id, page ?? 1, PageSize);
            return new OkObjectResult(user);
        }

        //public IActionResult Search(string searchTerm, int? page) 
        //{
        //    if (string.IsNullOrEmpty(searchTerm))
        //    {
        //        //var users = this.userService.All(page ?? 1, PageSize);
        //        return new OkObjectResult(users);
        //    }
        //    else 
        //    {
        //        //var users = this.userService.UsersBySearchTerm(searchTerm, page ?? 1, PageSize);
        //        return new OkObjectResult(users);
        //    }

        //}
    }
}