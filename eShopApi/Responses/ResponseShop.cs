using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace eShopApi.Responses
{
    public class ResponseShop
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
        public List<ResponseShopImages> Images { get; set; } = new List<ResponseShopImages>();
        public string ContactNumber { get; set; } = "";
        public string Website { get; set; } = "";
        public double Latitude { get; set; }
        public double Longtitude { get; set; }
        public string CreatedBy { get; set; } = "";
        public string UserName { get; set; } = "";

    }

    public class ResponseShopImages
    {
        public bool Main { get; set; } = false;
        public string Url { get; set; } = "";

    }
}
