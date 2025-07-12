using eShopApi.Helper;

namespace eShopApi.DTOs
{
    public class PaginationDto
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class UserPaginationDto : PaginationDto
    {
        public string CurrentUsername { get; set; }
        public string Gender { get; set; }
    }

    public class ProductPaginationDto : PaginationDto
    {
        public string Name { get; set; } = "";
    }
}
