namespace DatingApp.API.Helpers
{
    public class UserParams
    {
        // The maximum page size that a user can request
        private const int MaxPageSize = 50;
        // The page number
        public int PageNumber { get; set; } = 1;
        // Size of a page
        private int pageSize = 10;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }
        
    }
}