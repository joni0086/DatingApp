using System;

namespace DatingApp.API.Models
{
    public class Photo
    {
        // User ID
        public int Id { get; set; }
        // The photo URL
        public string Url { get; set; }
        // Description
        public string Description { get; set; }
        // When the photo was added
        public DateTime DateAdded { get; set; }
        // If the photo is a main photo (displayed on member card etc)
        public bool IsMain { get; set; }
        // Used for cloudinary
        public string PublicId { get; set; }
        // Relation variables between the photo and the user
        public User User { get; set; }
        public int UserId { get; set; }
    }
}