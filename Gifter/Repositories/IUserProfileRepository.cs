using Gifter.Models;

namespace Gifter.Repositories
{
    public interface IUserProfileRepository
    {
        UserProfile GetById(int id);
    }
}