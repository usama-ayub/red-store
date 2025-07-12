using MongoDB.Driver;


namespace eShopApi.Interfaces
{
    public interface IDBConnection
    {
        public IMongoDatabase DataBase { get; set; }
        public IMongoClient Client { get; set; }
    }
}