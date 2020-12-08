using System.Collections.Generic;
using VueJSSocialNetwork.Services.Models;

namespace VueJSSocialNetwork.Services
{
    public interface IUserService : IService
    {
        UserModel GetById(string id);

        UserAccountModel UserDetails(string userId, int pageIndex, int pageSize);

        UserAccountModel UserDetailsFriendsCommentsAndPosts(string userId, int pageIndex, int pageSize);

        bool CheckIfFriends(string requestUserId, string targetUserId);

        //bool CheckIfDeleted(string userId);

        //bool CheckIfDeletedByUserName(string username);

        void MakeFriends(string senderId, string receiverId);

        //List<UserListModel> UsersBySearchTerm(string searchTerm, int pageIndex, int pageSize);

        //List<UserListModel> All(int pageIndex, int pageSize);

        //object GetUserFullName(string id);

        //void EditUser(string id, string firstName, string lastName, int age, string email, string username);

        //void DeleteUser(string id);

        //List<string> FriendsIds(string userId);
    }
}
