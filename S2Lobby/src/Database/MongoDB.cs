using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace S2Lobby
{
    public sealed class MongoDB
    {
        private static readonly Lazy<MongoDB> lazy = new Lazy<MongoDB>(() => new MongoDB());
        private static readonly Lazy<Boolean> isActive = new Lazy<Boolean>(() =>
        {
            try
            {
                return Config.GetBool("database/mongo/active");
            }
            catch
            {
                return false;
            }
        });
        private static IMongoDatabase dbSession;

        public static MongoDB Instance { get { return lazy.Value; } }
        public static Boolean IsActive { get { return isActive.Value; } }

        private async void _InsertOneAsync(string collectionName, BsonDocument data)
        {
            try
            {
                IMongoCollection<BsonDocument> collection = dbSession.GetCollection<BsonDocument>(collectionName);
                //var filter = Builders<BsonDocument>.Filter.Eq("id", 1)
                await collection.InsertOneAsync(data);
            }
            catch (Exception e)
            {
                Logger.Log("MongoDB InsertOneAsync failed on collection " + collectionName + "with Document " + data.ToString());
                Logger.Log("The Error Message was: " + e.Message);
            }
        }

        private MongoDB()
        {
            try
            {
                if (IsActive)
                {
                    string ip = Config.Get("database/mongo/ip");
                    string port = Config.Get("database/mongo/port");
                    string dbName = Config.Get("database/mongo/name");
                    MongoClient client = new MongoClient("mongodb://" + ip + ":" + port);
                    dbSession = client.GetDatabase(dbName);
                    Logger.Log($"[Mongo database ready]");
                }
            }
            catch (Exception e)
            {
                Logger.Log("Mongo database startup failed with error: " + e.Message);
            }
        }

        public static MongoDB Get() => MongoDB.Instance;
        public static void InsertOneAsync(string collectionName, BsonDocument data) { if (IsActive) { Get()._InsertOneAsync(collectionName, data); }}
    }
}