using System;

namespace Cv.Dao.Configurations
{
    public static class ConfigMongoDb
    {
        //TODO que venga de la configuracion de la ui
        public const string ConectionString = "mongodb://localhost:27017";
        public const string BD_CvOnline = "CvOnline";
        public const string ConectionStringAtlas = "mongodb+srv://prueba:fRWCQiIDIrmOI2gO@cluster0.b4a5c.mongodb.net";
        public static string GetNameCollection<T>() where T : class
        {
            return typeof(T).Name switch
            {
                "CandidateModel" => "Candidates",
                "CandidateHistoryModel" => "CandidatesHistories",
                "CountryModel" => "Countries",
                "StateModel" => "States",
                _ => throw new Exception("The type of model, is not mapped."),
            };
        }
    }
}
