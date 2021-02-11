using MongoDB.Driver;

namespace Cv.Dao.Configurations
{
    public static class ConnectionsMongoDb<T> where T : class
    {
        public static IMongoCollection<T> GetCollection()
        {
            var Client = new MongoClient(ConfigMongoDb.ConectionString);
            var db = Client.GetDatabase(ConfigMongoDb.BD_CvOnline);
            var collection = db.GetCollection<T>(typeof(T).Name);
            return collection;
        }
    }
}
