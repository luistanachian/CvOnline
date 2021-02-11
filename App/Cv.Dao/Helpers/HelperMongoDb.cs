using MongoDB.Driver;

namespace Cv.Dao.Helpers
{
    public static class HelperMongoDb
    {
        public static IMongoDatabase DataBase = 
            new MongoClient("mongodb://localhost:27017")
            .GetDatabase("CvOnline");
    }
}
