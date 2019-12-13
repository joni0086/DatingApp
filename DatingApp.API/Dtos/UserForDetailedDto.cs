/* UserForDetailedDto
 *
 * Data Transfer Object class used to represent what should be returned
 * to the client if a GET on detailed user is made.
 *
 * Date:    2019-12-12
 * Author:  JoNi
 */
using System;
using System.Collections.Generic;
using DatingApp.API.Models;

namespace DatingApp.API.Dtos
{
    public class UserForDetailedDto
    {
        // The user ID
        public int Id {get; set;}
        // The user name
        public string Username {get; set;}
        // The gender of the user
        public string Gender { get; set; }
        // The users age
        public int Age { get; set; }
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
        // URL for the users photo
        public string PhotoUrl {get; set;}
        // Collections of photos the user has
        public ICollection<PhotosForDetailedDto> Photos { get; set; }
    }
}