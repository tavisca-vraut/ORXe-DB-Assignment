using DatabaseAssignment.Models;
using MongoDB.Bson;
using System.IO;

namespace DatabaseAssignment.Core
{
    public static class ExtensionMethods
    {
        public static BsonDocument ToBson(this Region region)
        {
            return new BsonDocument
            {
                { "id", region.Id},
                { "name", region.Name },
                { "longName", region.LongName },
                { "latitude", region.Latitude },
                { "longitude", region.Longitude },
                { "subClassification", region.SubClassification }
            };
        }

        public static Region ToRegion(this string regionString)
        {
            var region = new Region();
            var regionValues = regionString.Split('|');

            if (regionValues.Length > 0)
            {
                if (int.TryParse(regionValues[0], out int id) == true)
                {
                    region.Id = id;
                }
            }

            if (regionValues.Length > 1)
            {
                region.Name = regionValues[1];
            }

            if (regionValues.Length > 2)
            {
                region.LongName = regionValues[2];
            }

            if (regionValues.Length > 3)
            {
                if (float.TryParse(regionValues[3], out float latitude) == true)
                {
                    region.Latitude = latitude;
                }
            }

            if (regionValues.Length > 4)
            {
                if (float.TryParse(regionValues[4], out float longitude) == true)
                {
                    region.Longitude = longitude;
                }
            }

            if (regionValues.Length > 5)
            {
                region.SubClassification= regionValues[5];
            }

            return region;
        }

        public static bool EndOfStream(this StreamReader streamReader)
        {
            return streamReader.Peek() == -1;
        }
    }
}
