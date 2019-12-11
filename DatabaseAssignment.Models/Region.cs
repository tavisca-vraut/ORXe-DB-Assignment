using System;

namespace DatabaseAssignment.Models
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LongName { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string SubClassification { get; set; }
    }
}
