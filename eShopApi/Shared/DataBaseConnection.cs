using MongoDB.Driver;
using eShopApi.Interfaces;

namespace eShopApi.Shared
{
    public class DBConnection : IDBConnection
    {
        public IMongoDatabase DataBase { get; set; }
        public IMongoClient Client { get; set; }
        public DBConnection(IConfiguration configuration, DataBaseSetting settings)
        {
            Client = new MongoClient(settings.ConnectionString);
            DataBase = Client.GetDatabase(settings.DatabaseName);
        }

    }
}