using Microsoft.AspNetCore.Http;

namespace DatingApp.API.Helpers
{
    /*
     * General extention class.
     *
     */
    public static class Extensions
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message); //< Header called Application-Error with a message
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error"); //< Allows the Application-Error to be displayed
            response.Headers.Add("Access-Control-Allow-Origin", "*"); //< Allows the Application-Error to be displayed. Allow any origin
        }
    }
}