using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.API.Models;

namespace DatingApp.API.Data
{
    public interface IDatingRepository
    {
        // A generic method where T is a type of class.
        // Used to add users or photos.
         void Add<T>(T entity) where T: class;

        // A generic method where T is a type of class.
        // Used to delete users or photos.
         void Delete<T>(T entity) where T: class;

        // Save all changes. Returns bool depending on success.
        Task<bool> SaveAll();

        // Used to get users
        Task<IEnumerable<User>> GetUsers();

        // Get user
        Task<User> GetUser(int id);
        // Used to get a photo with a specific id
        Task<Photo> GetPhoto(int id);
        // Used to get the current main photo
        Task<Photo> GetMainPhotoForUser(int userId);
    }
}