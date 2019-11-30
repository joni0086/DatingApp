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
    }
}