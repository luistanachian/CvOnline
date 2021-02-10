using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cv.Dao.Helpers
{
    public static class HelperMongoDb
    {
        public static IMongoDatabase DataBase = 
            new MongoClient("mongodb://localhost:27017")
            .GetDatabase("CvOnline");
    }
}
