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
    public class ProductCRUD
    {
		public static void LoadProductsCollection()
		{
			var database = MongoLocalConnection.GetDatabase("itb");
			database.DropCollection("products");
			var collection = database.GetCollection<BsonDocument>("products");

			FileInfo file = new FileInfo("../../../files/products.json");

			using (StreamReader sr = file.OpenText())
			{
				string line;
				while ((line = sr.ReadLine()) != null)
				{
					Product product = JsonConvert.DeserializeObject<Product>(line);
					Console.WriteLine(product.name);
					string json = JsonConvert.SerializeObject(product);
					var document = new BsonDocument();
					document.AddRange(BsonDocument.Parse(json));
					collection.InsertOne(document);
				}
			}
		}
		public static void AddStockMinim(int price)
		{
			var database = MongoLocalConnection.GetDatabase("itb");
			var collection = database.GetCollection<BsonDocument>("products");
			var filter = Builders<BsonDocument>.Filter.Gt("price", price);
			var update = Builders<BsonDocument>.Update.Set("stock", 20);
			collection.UpdateMany(filter, update);
			var products = collection.Find(filter).ToList();
			int count = 0;
			foreach (var product in products)
			{
				Console.WriteLine(product.ToString());
				count++;
			}
			Console.WriteLine($"Productes actualitzats : {count}");
			Console.ReadKey();
			Console.Clear();
		}
	}
}
