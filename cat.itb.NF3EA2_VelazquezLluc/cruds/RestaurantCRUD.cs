using cat.itb.NF3EA2_VelazquezLluc.connections;
using cat.itb.NF3EA2_VelazquezLluc.model;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat.itb.NF3EA2_VelazquezLluc.cruds
{
    public class RestaurantCRUD
    {
		public static void LoadRestaurantCollection()
		{
			var database = MongoLocalConnection.GetDatabase("itb");
			database.DropCollection("restaurants");
			var collection = database.GetCollection<BsonDocument>("restaurants");

			FileInfo file = new FileInfo("../../../files/restaurants.json");

			using (StreamReader sr = file.OpenText())
			{
				string line;
				while ((line = sr.ReadLine()) != null)
				{
					Restaurant restaurant = JsonConvert.DeserializeObject<Restaurant>(line);
					Console.WriteLine(restaurant.name);
					string json = JsonConvert.SerializeObject(restaurant);
					var document = new BsonDocument();
					document.AddRange(BsonDocument.Parse(json));
					collection.InsertOne(document);
				}
			}
		}
		public static void ShowRestaurantsByZipCode(string zipCode)
		{
			var database = MongoLocalConnection.GetDatabase("itb");
			var collection = database.GetCollection<BsonDocument>("restaurants");
			var filter = Builders<BsonDocument>.Filter.Eq("address.zipcode", zipCode);
			var restaurants = collection.Find(filter).ToList();
			foreach (var restaurant in restaurants)
			{
				var name = restaurant.GetElement("name");
				var cuisine = restaurant.GetElement("cuisine");
				Console.WriteLine($"{name.ToString()} {cuisine.ToString()}");
			}
			Console.ReadKey();
			Console.Clear();
		}
		public static void RestaurantsChineseBronx(string borough, string cuisine)
		{
			var database = MongoLocalConnection.GetDatabase("itb");
			var collection = database.GetCollection<BsonDocument>("restaurants");
			var filter = Builders<BsonDocument>.Filter.Eq("borough", borough) & Builders<BsonDocument>.Filter.Eq("cuisine", cuisine);
			var restaurants = collection.Find(filter).ToCursor();
			foreach (var restaurant in restaurants.ToEnumerable())
			{
				Console.WriteLine(restaurant.ToString());
			}
			Console.ReadKey();
			Console.Clear();
		}
		public static void UpdateZipcode(string name, string newZipCode)
        {
            var database = MongoLocalConnection.GetDatabase("itb");
            var collection = database.GetCollection<BsonDocument>("restaurants");
            var filter = Builders<BsonDocument>.Filter.Eq("name", name);
            var update = Builders<BsonDocument>.Update.Set("address.zipcode", newZipCode);
            collection.UpdateOne(filter, update);

        }
    }
}
