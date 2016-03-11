using System;
using System.ComponentModel;

namespace App.Models
{
    /// <summary>
    /// Client object
    /// </summary>
    public class Client
    {
        public Client()
        {
            Seller = new User();
            City = new City();
            Classification = new Classification();
        }

        public Client(string name, string phone, char gender, DateTime lastPurchase, string sellerId, string regionId, string classificationId, string id, string address, string occupation)
            : this()
        {
            Name = name;
            Phone = phone;
            Gender = gender;
            LastPurchase = lastPurchase;
            Id = id;
            Address = address;
            Occupation = occupation;
        }

        public string Name { get; set; }
        public string Phone { get; set; }
        public char Gender { get; set; }
        public DateTime LastPurchase { get; set; }

        public string Id { get; set; }
        public string Address { get; set; }
        public string Occupation { get; set; }

        public User Seller { get; set; }
        public Classification Classification { get; set; }
        public City City { get; set; }
    }
    public enum GenderEnum
    {
        [Description("F")]
        Female = 'F',
        [Description("M")]
        Male = 'M'
    }
}