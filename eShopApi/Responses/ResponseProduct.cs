using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace eShopApi.Responses
{
    public class ResponseProduct
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public double Price { get; set; } = 0;
        public List<string> Tags { get; set; } = new List<string>();
        public List<ResponseProductImages> Images { get; set; } = new List<ResponseProductImages>();
        public string CategoryId { get; set; } = "";
        public string CategoryName { get; set; } = "";
        public string SubCategoryId { get; set; } = "";
        public string SubCategoryName { get; set; } = "";
        public string ShopId { get; set; } = "";
        public string ShopName { get; set; } = "";
        public string CreatedBy { get; set; } = "";
        public string UserName { get; set; } = "";
        public bool IsHotItem { get; set; }

    }

    public class ResponseProductImages
    {
        public bool Main { get; set; } = false;
        public string Url { get; set; } = "";
    }
}
