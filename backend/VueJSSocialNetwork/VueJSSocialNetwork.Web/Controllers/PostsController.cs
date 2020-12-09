using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using VueJSSocialNetwork.Data;
using VueJSSocialNetwork.Data.Entities;
using VueJSSocialNetwork.Services;
using VueJSSocialNetwork.Web.Extensions;
using VueJSSocialNetwork.Web.Helpers;

namespace VueJSSocialNetwork.Web.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        private readonly IPostService postService;
        private IFormFile photo = null;

        [HttpPost]
        public IActionResult Create([FromBody] Post model)
        {
            // Check for any uploaded file  
            if (Request.Form.Files.Count > 0)
            {
                photo = Request.Form.Files[0];
            }

            if (photo != null)
            {
                if (photo.Length > DataConstants.MaxPhotoLength)
                {
                    return BadRequest(Errors.AddErrorToModelState("photo_failure", "Your photo should be a valid image file with max size 5MB!", ModelState)); 
                }
            }

            this.postService.Create(this.User.GetUserId(), model.Text, photo);

            return Ok();
        }

    }
}
