using System;
using System.IO;

using MongoDB.Driver;
using MongoDB.Bson;

namespace DatabaseAssignment.Core
{
    public class RegionDbHandler
    {
        IMongoCollection<BsonDocument> Collection { get; set; }
        private MongoClient Client { get; set; }

        public RegionDbHandler()
        {
            EstablishConnection();
            InitializeCollection();
        }

        private void EstablishConnection()
        {
            Console.WriteLine("Enter the password for the mongoDb connection (for user: vraut)");
            Console.WriteLine("(Hint: use the clts password)");
            string vrautPassword = Console.ReadLine();

            Client = new MongoClient(Util.GetConnectionString().Replace("<userPassword>", vrautPassword));
        }

        private void InitializeCollection(string collectionName = "Region")
        {
            Collection = Client.GetDatabase("test").GetCollection<BsonDocument>(collectionName);
        }

        public void TransferRegionsFromFileToDb(string filePath)
        {
            using (var streamReader = new StreamReader(filePath))
            {
                // Discard the heading
                _ = streamReader.ReadLine();

                while (streamReader.EndOfStream() == false)
                {
                    Collection.InsertOne(streamReader.ReadLine().ToRegion().ToBson());
                }
            }
        }
    }
}
