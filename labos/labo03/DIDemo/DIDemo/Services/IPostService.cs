using DIDemo.Models;

namespace DIDemo.Services
{
    public interface IPostService
    {
        Task CreatePost(Post item);
        Task DeletePost(int id);
        Task<List<Post>> GetAllPosts();
        Task<Post?> GetPost(int id);
        Task<Post?> UpdatePost(int id, Post item);
    }
}