/* PagedList.cs
 *
 * This class represents a generic list that can be returned to the user.
 * This list also uses the "pageing" technique, which results in that not all items
 * in the list are returned to the user at once.
 * This generic list could, for example, hold users or messages.
 *
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Helpers
{
    public class PagedList<T> : List<T>
    {
        // The current page that we are on
        public int CurrentPage { get; set; }
        // The total number of pages
        public int TotalPages { get; set; }
        // The size of the current page
        public int PageSize { get; set; }
        // Total amount of items
        public int TotalCount { get; set; }

        /* Constructor
         * Used to initialize the class
         * Input:   (items): All the items in the list
         *          (count): The total amount of items in the list
         *          (pageNumber): The current page number
         *          (pageSize): The size of a page (number of items in a single page)
         * Output:  None
         */
        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            // Initialize properties
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int) Math.Ceiling(count / (double)pageSize);
            // Add the items to the list
            this.AddRange(items);
        }

        /* CreateAsync
         * Used to create a new instance of this class
         * Input:   (source): The source
         *          (pageNumber): The current page number
         *          (pageSize): The size of a page (number of items in a single page)
         * Output:  A PagedList object
         */
        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
        {
            // Get the total count of the items
            var count = await source.CountAsync();
            // Get the items from the source, using the pageNumber and pageSize to know which items to get
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }

    }
}