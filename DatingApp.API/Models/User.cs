using System;
using System.Collections.Generic;

namespace DatingApp.API.Models
{
    public class User
    {
        // The user ID
        public int Id {get; set;}
        // The user name
        public string Username {get; set;}
        // The user password hash
        public byte[] PasswordHash {get; set;}
        // The password salt
        public byte[] PasswordSalt {get; set;}
        // The gender of the user
        public string Gender { get; set; }
        // The users day of birth
        public DateTime DateOfBirth { get; set; }
        // What the user is known as
        public string KnownAs { get; set; }
        // When the profile was created
        public DateTime Created { get; set; }
        // When the user was last active
        public DateTime LastActive { get; set; }
        // The users introduction
        public string Introduction { get; set; }
        // What the user is looking for
        public string LookingFor { get; set; }
        // The interests of the user
        public string Interests { get; set; }
        // The city that the user lives in
        public string City { get; set; }
        // The country that the user lives in
        public string Country { get; set; }
        // The users photos
        public virtual ICollection<Photo> Photos { get; set; }
        // Used for like functionality
        public virtual ICollection<Like> Likers { get; set; }
        public virtual ICollection<Like> Likees { get; set; }
        // Used for messaging
        public virtual ICollection<Message> MessagesSent { get; set; }
        public virtual ICollection<Message> MessagesReceived { get; set; }

    }
}