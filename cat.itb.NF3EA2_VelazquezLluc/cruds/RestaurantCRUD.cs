using cat.itb.NF3EA2_VelazquezLluc.connections;
using cat.itb.NF3EA2_VelazquezLluc.model;
using MongoDB.Bson;
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
	}
}
