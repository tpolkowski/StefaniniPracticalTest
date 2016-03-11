namespace App.Models
{
    /// <summary>
    /// Region object
    /// </summary>
    public class Region
    {
        public Region()
        {

        }
        public Region(string id, string name, string cityId)
        {
            Id = id;
            Name = name;
            CityId = cityId;
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string CityId { get; set; }
    }

}