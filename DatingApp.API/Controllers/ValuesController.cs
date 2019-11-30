using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

/* ValuesController.cs
 *
 * Manages requests.
 *
 * Author:  JoNi
 * Date:    2019-11-29
 */
namespace DatingApp.API.Controllers
{
    // GET http://localhost:5000/api/Values
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;
        }

        /* GetValues (GET api/values)
         * 
         * When a request comes to api/values, it is going to hit this method, go to the database
         * Get the values as a list and then return the values to the clients with a http 200 Ok
         * response.
         * This method is async/threaded since if many user wants the same thing, then it would lock
         * the application.
         *
         * Input:   None
         * Output:  IActionResult. This lets us return http responses instead of values.
         *              then we can return things like, Ok like a http 200 response.
         */
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            // Get the values from the databse and retrieve them as a list
            var values = await _context.Values.ToListAsync();
            return Ok(values);
        }

        /* GetValue (GET api/values/5)
         * 
         * When a request comes to api/values to get a specific value, it is going to hit this method, go to the database
         * Get the value to the clients with a http 200 Ok.
         * response.
         * This method is async/threaded since if many user wants the same thing, then it would lock
         * the application.
         *
         * Input:   (id): The id to get from the database
         * Output:  IActionResult. This lets us return http responses instead of a value.
         *              then we can return things like, Ok like a http 200 response.
         */
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            // Get the specific value from the database (if it is not found, it returns the default value, null)
            var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}