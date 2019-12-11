using System;
using System.Linq;
using System.Collections.Generic;

using System.IO;

using MongoDB.Driver;
using MongoDB.Bson;
using System.Diagnostics;

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
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var bsonDocuments = File.ReadAllLines(filePath).Select(line => line.ToRegion().ToBson());   
            Collection.InsertMany(bsonDocuments);

            stopwatch.Stop();

            Console.WriteLine($"Time taken to insert: {stopwatch.ElapsedMilliseconds / 1000} seconds.");
        }
    }
}
