/* UserForUpdateDto (DataTransferObject)
 *
 * The purpose of this DTO is to make sure that changes made to the users profile
 * are saved to the server.
 *
 * Note:    This DTO is 'automapped'. See: AutoMapperProfiles.cs
 *
 * Author:  JoNi
 * Date:    2019-12-16
 */
namespace DatingApp.API.Dtos
{
    public class UserForUpdateDto
    {
        // The introduction text that the user is allowed to change
        public string Introduction { get; set; }
        // The looking for text that the user is allowed to change
        public string LookingFor { get; set; }
        // The interests text that the user is allowed to change
        public string Interests { get; set; }
        // The city text that the user is allowed to change
        public string City { get; set; }
        // The country text that the user is allowed to change
        public string Country { get; set; }  
    }
}