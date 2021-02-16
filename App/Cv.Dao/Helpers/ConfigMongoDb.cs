using System;

namespace Cv.Dao.Configurations
{
    public static class ConfigMongoDb
    {
        //TODO que venga de la configuracion de la ui
        public const string ConectionString = "mongodb://localhost:27017";
        public const string BD_CvOnline = "CvOnline";

        public static string GetNameCollection<T>() where T : class
        {
            return typeof(T).Name switch
            {
                "CandidateModel" => "Candidates",
                "CountryModel" => "Countries",
                "ClientModel" => "Clients",
                _ => throw new Exception("The type of model, is not mapped."),
            };
        }
    }
}
