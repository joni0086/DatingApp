using System;

namespace DatingApp.API.Dtos
{
    public class PhotoForReturnDto
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
        // What we get back from cloudinary
        public string PublicId { get; set; }
    }
}