/* UserForListDto
 *
 * Data Transfer Object class used to represent what should be returned
 * to the client if a GET on users list is made.
 *
 * Date:    2019-12-12
 * Author:  JoNi
 */
using System;

namespace DatingApp.API.Dtos
{
    public class UserForListDto
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
        // The city that the user lives in
        public string City { get; set; }
        // The country that the user lives in
        public string Country { get; set; }
        // URL for the users photo
        public string PhotoUrl {get; set;}
    }
}