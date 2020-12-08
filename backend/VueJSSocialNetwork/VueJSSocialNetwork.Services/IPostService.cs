using VueJSSocialNetwork.Services.Infrastructure;
using VueJSSocialNetwork.Services.Models;

namespace VueJSSocialNetwork.Services
{
    public interface IPostService : IService
    {
        PostModel PostById(int postId);

        PaginatedList<PostModel> PostsByUserId(string userId, int pageIndex, int pageSize);
    }
}
