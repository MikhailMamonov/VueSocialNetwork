using System.Linq;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using VueJSSocialNetwork.Services.Models;
using VueJSSocialNetwork.Services;
using VueJSSocialNetwork.Services.Infrastructure;
using VueJSSocialNetwork.Data;

namespace VueJSSocialNetwork.Services.Implementations
{
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext db;

        public PostService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public PaginatedList<PostModel> PostsByUserId(string userId, int pageIndex, int pageSize)
        {
            var posts = this.db
                .Posts
                .Where(p => p.UserId == userId)
                .ProjectTo<PostModel>()
                .OrderByDescending(p => p.Date);

            return posts != null ? PaginatedList<PostModel>.Create(posts.AsNoTracking(), pageIndex, pageSize) : null;
        }

        public PostModel PostById(int postId)
        {
            return this.db.Posts.Where(p => p.Id == postId).ProjectTo<PostModel>().FirstOrDefault();
        }
    }
}
