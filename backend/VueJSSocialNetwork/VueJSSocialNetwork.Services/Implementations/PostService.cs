using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VueJSSocialNetwork.Services.Models;
using VueJSSocialNetwork.Services;
using VueJSSocialNetwork.Services.Infrastructure;
using VueJSSocialNetwork.Data;
using VueJSSocialNetwork.Data.Entities;
using VueJSSocialNetwork.Data.Entities.Enums;

namespace VueJSSocialNetwork.Services.Implementations
{
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext _db;
        private readonly IPhotoService _photoService;
        private UserManager<User> _userManager;


        public PostService(ApplicationDbContext db, UserManager<User> userManager)
        {
            this._db = db;
            _userManager = userManager;
        }

        public List<Post> PostsByUserId(string userId)
        {
            var posts = this._db
                .Posts
                .Where(p => p.UserId == userId)
                //.ProjectTo<PostModel>()
                .OrderByDescending(p => p.Date);

            return posts.ToList();
        }

        public Post PostById(int postId)
        {
            return this._db.Posts/*.ProjectTo<PostModel>()*/.FirstOrDefault(p => p.Id == postId);
        }

        public void Create(string userId, Post post)
        {
            try
            {

                var newPost = new Post
                {
                    UserId = userId,
                    Text = post.Text,
                    Likes = 0,
                    Date = DateTime.UtcNow,
                    ImageFile = post.ImageFile,
                    ImageName = post.ImageName,
                    ImageSrc = post.ImageSrc

                };

                _db.Posts.AddAsync(newPost);
                _db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public async Task<ActionResult<Post>> Delete(int postId, string currentRootPathImages)
        {
            var postModel = await _db.Posts.FindAsync(postId);
            if (postModel == null)
            {
                return null;
            }
            DeleteImage(currentRootPathImages + postModel.ImageName);
            _db.Posts.Remove(postModel);
            await _db.SaveChangesAsync();

            return postModel;
        }

        [NonAction]
        public void DeleteImage(string imagePath)
        {
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
        }
    }
}
