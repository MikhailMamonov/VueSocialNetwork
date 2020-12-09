using System;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
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

        public PostService(ApplicationDbContext db, IPhotoService photoService)
        {
            this._db = db;
            this._photoService = photoService;
        }

        public PaginatedList<PostModel> PostsByUserId(string userId, int pageIndex, int pageSize)
        {
            var posts = this._db
                .Posts
                .Where(p => p.UserId == userId)
                .ProjectTo<PostModel>()
                .OrderByDescending(p => p.Date);

            return posts != null ? PaginatedList<PostModel>.Create(posts.AsNoTracking(), pageIndex, pageSize) : null;
        }

        public PostModel PostById(int postId)
        {
            return this._db.Posts.Where(p => p.Id == postId).ProjectTo<PostModel>().FirstOrDefault();
        }
        
        public void Create(string userId, string text, IFormFile photo)
        {
            var post = new Post
            {
                UserId = userId,
                Text = text,
                Likes = 0,
                Date = DateTime.UtcNow,
                Photo = photo != null ? this._photoService.PhotoAsBytes(photo) : null
            };

            _db.Posts.Add(post);
            _db.SaveChanges();
        }
    }
}
