using System;

namespace api.Helpers
{
    public class QueryObject
    {
        private int _pageNumber = 1;
        private int _pageSize = 20;
        private const int MaxPageSize = 100;

        public string? Title { get; set; } = null;

        public int PageNumber
        {
            get => _pageNumber;
            set => _pageNumber = (value > 0) ? value : 1;
        }

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > 0 && value <= MaxPageSize) ? value : 20;
        }
    }
}
