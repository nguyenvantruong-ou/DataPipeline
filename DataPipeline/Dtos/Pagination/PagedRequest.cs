using System.ComponentModel.DataAnnotations;

namespace DataPipeline.Dtos.Pagination
{
    public class PagedRequest
    {
        [MaxLength(100)]
        public string? Keyword { get; set; }
        public int Page { get; set; } = 1;

        [Range(1, 100, ErrorMessage = "PageSize must be between 1 and 100")]
        public int PageSize { get; set; } = 10;
        public string? OrderBy { get; set; }

        [RegularExpression("^(asc|desc)$", ErrorMessage = "SortDirection must be 'asc' or 'desc'")]
        public string SortDirection { get; set; } = "asc";
    }
}
