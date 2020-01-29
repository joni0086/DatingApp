using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.API.Helpers;
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

        // Used to get users (paged list)
        Task<PagedList<User>> GetUsers(UserParams userParams);

        // Get user
        Task<User> GetUser(int id);
        // Used to get a photo with a specific id
        Task<Photo> GetPhoto(int id);
        // Used to get the current main photo
        Task<Photo> GetMainPhotoForUser(int userId);
        Task<Like> GetLike(int userId, int recipientId);

        /* Used to get a single message from the database.
         * Input:   (id): The id of the message
         * Output:  The message
         */
        Task<Message> GetMessage(int id);
        /* Used to get messages for the user
         * Input:   (messageParams): 
         * Output:  The messages
         */
        Task<PagedList<Message>> GetMessagesForUser(MessageParams messageParams);
        /* The conversation between two users. Should be displayed on tabbed panel.
         * Input:   (userId): The id of the user
         *          (recipientId): The id of the recipient
         * Output:  The messages
         */
        Task<IEnumerable<Message>> GetMessageThread(int userId, int recipientId);

    }
}