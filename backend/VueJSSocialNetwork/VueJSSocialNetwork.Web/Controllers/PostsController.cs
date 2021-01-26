using Microsoft.AspNetCore.Mvc;

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query;
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
        private readonly IWebHostEnvironment _hostEnvironment;

        public PostsController(IPostService postService, 
              IWebHostEnvironment hostEnvironment)
        {
            this.postService = postService;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: api/Employee
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            try
            {
                string userId = User.Claims.First(c => c.Type == "UserID").Value;

                return postService.PostsByUserId(userId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        [HttpDelete("{id}")]
        public IActionResult Destroy(int postId)
        {
            var currentRootPathImages = Path.Combine(_hostEnvironment.ContentRootPath, "Images");
            //this.postService.Delete(postId, currentRootPathImages);


            return Ok();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Post model)
        {
            try
            {
                string userId = User.Claims.First(c => c.Type == "UserID").Value; ;
                
                model.ImageName = await SaveImage(model.ImageFile);

                this.postService.Create(userId, model);

                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imageName;
        }


    }
}
