/* PaginationHeader.cs
 *
 * This class is used to represent an http response header
 *
 */
namespace DatingApp.API.Helpers
{
    public class PaginationHeader
    {
        // Variables below are what we want to give as a response in the http header
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }

        /* Constructor
         * Used to initialize the class
         * Input:   (currentPage): Which page is the current one
         *          (itemsPerPage): The amount of items per page
         *          (totalItems): The total amount of items
         *          (totalPages): The total amount of pages
         * Output:  None
         */
        public PaginationHeader(int currentPage, int itemsPerPage, int totalItems, int totalPages)
        {
            this.CurrentPage = currentPage;
            this.ItemsPerPage = itemsPerPage;
            this.TotalItems = totalItems;
            this.TotalPages = totalPages;
        }
    }
}