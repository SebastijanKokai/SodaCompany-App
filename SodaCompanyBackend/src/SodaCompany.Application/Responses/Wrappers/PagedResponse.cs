using System;

namespace SodaCompany.Application.Responses.Wrappers
{
    public class PagedResponse<T> where T : class
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public T Data { get; set; }
        public PagedResponse(T data, int pageNumber, int pageSize, int totalRecords)
        {
            Data = data;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalRecords = totalRecords;
            TotalPages = Convert.ToInt32(Math.Ceiling((double)totalRecords / (double)pageSize));
        }
    }
}
