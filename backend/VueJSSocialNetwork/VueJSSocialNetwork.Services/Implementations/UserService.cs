using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using VueJSSocialNetwork.Services.Models;
using VueJSSocialNetwork.Data;
using VueJSSocialNetwork.Data.Entities;

namespace VueJSSocialNetwork.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext db;
        private IPostService postService;

        public UserModel GetById(string id)
        {
            if (this.UserExists(id))
            {
                return Mapper.Map<UserModel>(this.db.Users.Find(id));
            }

            return null;
        }

        public UserService(ApplicationDbContext db, IPostService postService)
        {
            this.db = db;
            this.postService = postService;

        }

        public bool CheckIfFriends(string requestUserId, string targetUserId)
        {
            return this.db.UserFriend.Any(uf =>
            (uf.UserId == requestUserId && uf.FriendId == targetUserId) || (uf.UserId == targetUserId && uf.FriendId == requestUserId));
        }

        public void MakeFriends(string senderId, string receiverId)
        {
            if (this.UserExists(senderId) && this.UserExists(receiverId) && !this.CheckIfFriends(senderId, receiverId))
            {
                var userFriend = new UserFriend
                {
                    UserId = senderId,
                    FriendId = receiverId
                };
                this.db.UserFriend.Add(userFriend);
                this.db.SaveChanges();
            }
        }

        public virtual UserAccountModel UserDetailsFriendsCommentsAndPosts(string userId, int pageIndex, int pageSize)
        {
            if (this.UserExists(userId))
            {
                UserAccountModel userAccountModel = db
                    .Users
                    .Where(u => u.Id == userId)
                    .Include(u => u.Interests)
                    .ProjectTo<UserAccountModel>()
                    .FirstOrDefault();

                return userAccountModel;
            }
            else
            {
                return null;
            }
        }


        public UserAccountModel UserDetails(string userId, int pageIndex, int pageSize)
        {
            if (this.UserExists(userId))
            {
                var userPosts = this.postService.PostsByUserId(userId, pageIndex, pageSize);
                var userAccountModel = db
                    .Users
                    .Where(u => u.Id == userId)
                    .Include(u => u.Interests)
                    .ProjectTo<UserAccountModel>()
                    .FirstOrDefault();

                var friends = this.db
                    .UserFriend
                    .Where(u => u.UserId == userId && !u.Friend.IsDeleted)
                    .Select(u => u.Friend)
                    .ProjectTo<UserListModel>()
                    .ToList();

                var otherFriends = this.db
                    .UserFriend
                    .Where(u => u.FriendId == userId && !u.User.IsDeleted)
                    .Select(u => u.User)
                    .ProjectTo<UserListModel>()
                    .ToList();

                friends.AddRange(otherFriends);

                userAccountModel.Posts = userPosts;
                userAccountModel.Friends = friends;
                

                return userAccountModel;
            }
            else
            {
                return null;
            }
        }

        //    public void DeleteUser(string id)
        //    {
        //        var user = this.db.Users.Find(id);

        //        user.IsDeleted = true;

        //        this.db.SaveChanges();
        //    }

            public bool UserExists(string userId) => this.db.Users.Any(u => u.Id == userId);

        }
    }

