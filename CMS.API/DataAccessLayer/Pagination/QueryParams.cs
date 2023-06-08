namespace CMS.API.DataAccessLayer.Pagination
{
    public class QueryParams
    {
        private int _pageSize = 5;
        public int StartIndex { get; set; }
        public int NextPageNumber { get; set; }
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }
    }
}
