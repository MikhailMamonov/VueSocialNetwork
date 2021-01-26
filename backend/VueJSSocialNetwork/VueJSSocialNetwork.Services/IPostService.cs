using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VueJSSocialNetwork.Data.Entities;
using VueJSSocialNetwork.Data.Entities.Enums;
using VueJSSocialNetwork.Services.Infrastructure;
using VueJSSocialNetwork.Services.Models;

namespace VueJSSocialNetwork.Services
{
    public interface IPostService : IService
    {
        Post PostById(int postId);

        List<Post> PostsByUserId(string userId);

        void Create(string userId, Post post);

        Task<ActionResult<Post>> Delete(int postId, string currentRootPathImages);
    }
}
