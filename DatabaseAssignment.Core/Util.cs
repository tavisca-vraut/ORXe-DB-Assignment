using System;
using System.IO;
using System.Linq;

using Newtonsoft.Json;

using DatabaseAssignment.Models;

namespace DatabaseAssignment.Core
{
    public static class Util
    {
        public static string GetConnectionString()
        {
            using (var streamReader = new StreamReader(GetDbConfigFileLocation()))
            {
                var model = JsonConvert.DeserializeObject<DbConfig>(streamReader.ReadToEnd());
                return model.MongoConnectionString;
            }
        }

        public static string GetDbConfigFileLocation()
        {
            var dir = Environment.CurrentDirectory.Split("\\").ToList();
            
            dir.RemoveAt(dir.Count - 1);
            dir.RemoveAt(dir.Count - 1);
            dir.RemoveAt(dir.Count - 1);
            dir.RemoveAt(dir.Count - 1);
            dir.Add("DatabaseAssignment.Core");
            dir.Add("dbconfig.json");

            return string.Join("\\", dir);
        }
    }
}
