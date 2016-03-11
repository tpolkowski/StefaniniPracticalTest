using App.Models;
using App.Models.Dal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace App.ViewModels
{
    /// <summary>
    /// view model object for find client methods
    /// </summary>
    public class FindClientsViewModel
    {
        public FindClientsViewModel()
        {
            CityEnumerable = new List<SelectListItem>();
            RegionEnumerable = new List<SelectListItem>();
            ClassificationEnumerable = new List<SelectListItem>();
            SellerEnumerable = new List<SelectListItem>();
            GenderEnum = new GenderEnum();
            ClientList = new List<Client>();
        }

        public IEnumerable<SelectListItem> CityEnumerable { get; set; }
        public IEnumerable<SelectListItem> RegionEnumerable { get; set; }
        public IEnumerable<SelectListItem> ClassificationEnumerable { get; set; }
        public IEnumerable<SelectListItem> SellerEnumerable { get; set; }
        public GenderEnum GenderEnum { get; set; }

        public string Name { get; set; }
        public string CityId { get; set; }
        public string RegionId { get; set; }
        public string ClassificationId { get; set; }
        public string SellerId { get; set; }

        public string LastPurchase { get; set; }
        public string LastPurchaseUntil { get; set; }
        public List<Client> ClientList { get; set; }

        //get all lists for the select inputs parameters
        public void GetSearchItens()
        {
            //get city
            var data = new DbInterface().Find("SELECT * FROM City");
            City city;
            var cityList = new List<City>();
            foreach (var item in data)
            {
                city = new City();
                city.Id = item["CityId"];
                city.Name = item["CityName"];
                cityList.Add(city);
            }
            CityEnumerable = new SelectList(cityList, "Id", "Name", CityId);
            

            //get classification
            data = new DbInterface().Find("SELECT * FROM Classification");
            Classification classification;
            var classificationList = new List<Classification>();
            foreach (var item in data)
            {
                classification = new Classification();
                classification.Id = item["ClassificationId"];
                classification.Name = item["ClassificationName"];
                classificationList.Add(classification);

            }
            ClassificationEnumerable = new SelectList(classificationList, "Id", "Name", ClassificationId);


            //get Seller
            data = new DbInterface().Find("SELECT * FROM [User]");
            User user;
            var userList = new List<User>();
            foreach (var item in data)
            {
                user = new User();
                user.Id = item["UserId"];
                user.Name = item["Name"];
                userList.Add(user);

            }
            SellerEnumerable = new SelectList(userList, "Id", "Name", SellerId);

        }

        //get the client list using the find parameters 
        public void GetClientList()
        {
            var query = new StringBuilder();
            query.AppendLine("SELECT");
            query.AppendLine(" Client.[Address] ");
            query.AppendLine(",Client.ClientId ");
            query.AppendLine(",Client.Gender ");
            query.AppendLine(",Client.LastPurchase ");
            query.AppendLine(",Client.Name ");
            query.AppendLine(",Client.Occupation ");
            query.AppendLine(",Client.Phone ");
            query.AppendLine(",Client.RegionId ");
            query.AppendLine(",Region.RegionName ");
            query.AppendLine(",City.CityId");
            query.AppendLine(",City.CityName ");
            query.AppendLine(",Client.ClassificationId ");
            query.AppendLine(",Classification.ClassificationName ");
            query.AppendLine(",Client.SellerId ");
            query.AppendLine(",[User].Name AS UserName ");
            query.AppendLine(" FROM Client ");
            query.AppendLine(" LEFT JOIN Region ");
            query.AppendLine(" ON Region.RegionId = Client.RegionId ");
            if (RegionId != null) query.AppendLine(" AND Region.RegionId = '" + RegionId + "'");

            query.AppendLine(" LEFT JOIN City ");
            query.AppendLine(" ON City.CityId = Region.CityId ");
            if (CityId != null) query.AppendLine(" AND City.CityId = '" + CityId + "'");

            query.AppendLine(" LEFT JOIN Classification ");
            query.AppendLine(" ON Classification.ClassificationId = Client.ClassificationId ");
            if (ClassificationId != null) query.AppendLine(" AND  Classification.ClassificationId  = '" + ClassificationId + "'");

            query.AppendLine(" JOIN[User] ");
            query.AppendLine(" ON [User].UserId = Client.SellerId ");
            query.AppendLine(" WHERE ");

            if (Name != "") query.AppendLine(" Client.Name LIKE '%" + Name + "%'");
            if (GenderEnum != 0) query.AppendLine(" AND Client.Gender = '" + (char)GenderEnum + "'");
            if (RegionId != null) query.AppendLine(" AND Client.RegionId = '" + RegionId + "'");
            if (LastPurchase != null && LastPurchaseUntil != null) query.AppendLine(" AND Client.LastPurchase BETWEEN ('" + DateTime.Parse(LastPurchase).ToString("yyyy-MM-dd") + "') AND ('" + DateTime.Parse(LastPurchaseUntil).ToString("yyyy-MM-dd") + "') ");
            if (ClassificationId != null) query.AppendLine(" AND Client.ClassificationId = '" + ClassificationId + "'");
            if (SellerId != null) query.AppendLine(" AND Client.SellerId = '" + SellerId + "'");

            var data = new DbInterface().Find(query.ToString());

            var clientList = new List<Client>();
            Client client;
            foreach (var item in data)
            {
                client = new Client();
                client.Name = item["Name"];
                client.Phone = item["Phone"];
                client.Gender = char.Parse(item["Gender"]);
                client.LastPurchase = DateTime.Parse(item["LastPurchase"]);
                client.Seller.Id = item["SellerId"];
                client.Seller.Name = item["UserName"];
                client.City.Id = item["CityId"];
                client.City.Name = item["CityName"];
                client.City.Region.Add(new Region() { Id = item["RegionId"], Name = item["RegionName"] });
                client.Classification.Id = item["ClassificationId"];
                client.Classification.Name = item["ClassificationName"];
                client.Id = item["ClientId"];
                client.Address = item["Address"];
                client.Occupation = item["Occupation"];
                clientList.Add(client);
            }
            ClientList = clientList;
        }

        //get the region for teh city selected
        public void GetRegionByCity()
        {
            //get region
            RegionEnumerable = new SelectList(new List<Region>());
            if (CityId != null)
            {
                var data = new DbInterface().Find("SELECT * FROM Region WHERE Region.CityId = '" + CityId + "'");
                Region region;
                var regionList = new List<Region>();
                foreach (var item in data)
                {
                    region = new Region();
                    region.Id = item["RegionId"];
                    region.Name = item["RegionName"];
                    region.CityId = item["CityId"];
                    regionList.Add(region);

                }
                RegionEnumerable = new SelectList(regionList, "Id", "Name", RegionId);
            }
        }
    }
    
}