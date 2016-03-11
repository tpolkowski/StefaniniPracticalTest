using System.Collections.Generic;

namespace App.Models
{
    /// <summary>
    /// City object
    /// </summary>
    public class City
    {
        public City()
        {
            Region = new List<Region>();
        }
        public City(string id, string name)
            : this()
        {
            Id = id;
            Name = name;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public List<Region> Region { get; set; }
    }

  


}