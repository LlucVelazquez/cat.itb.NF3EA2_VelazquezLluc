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
		public static void AddGamaField()
		{
			var database = MongoLocalConnection.GetDatabase("itb");
			var collection = database.GetCollection<BsonDocument>("products");
			var productDocuments = collection.Find(new BsonDocument()).ToList();
			foreach (var product in productDocuments)
			{
				int price = product.GetElement("price").Value.AsInt32;
				string gama = "";
				if (price <= 500)
				{
					gama = "Baixa";
				}
				else if (price > 500 && price <= 2000)
				{
					gama = "Mitjana";
				}
				else
				{
					gama = "Extra";
				}
				var filter = Builders<BsonDocument>.Filter.Eq("_id", product["_id"]);
				var update = Builders<BsonDocument>.Update.Set("gama", gama);
				collection.UpdateOne(filter, update);
			}
			var productsUpdate = collection.Find(new BsonDocument()).ToList();
			foreach (var product in productsUpdate)
			{
				Console.WriteLine(product.ToString());
			}
			Console.ReadKey();
			Console.Clear();
		}
		public static void UpdateProductCategory(string productName, string oldCategory, string newCategory)
		{
			var database = MongoLocalConnection.GetDatabase("itb");
			var collection = database.GetCollection<BsonDocument>("products");
			var filter = Builders<BsonDocument>.Filter.Eq("name", productName);
			var productBefore = collection.Find(filter).FirstOrDefault();
			Console.WriteLine("Abans de l'actualització:");
			Console.WriteLine(productBefore.ToString());
			var categories = productBefore["categories"].AsBsonArray;
			if (categories.Contains(oldCategory))
			{
				categories.Remove(oldCategory);
				categories.Add(newCategory);

				var update = Builders<BsonDocument>.Update.Set("categories", categories);
				collection.UpdateOne(filter, update);

				var productAfter = collection.Find(filter).FirstOrDefault();
				Console.WriteLine("Després de l'actualització:");
				Console.WriteLine(productAfter.ToString());
			}
			Console.ReadKey();
			Console.Clear();
		}
		public static void UpdateStockForPriceRange(int minPrice, int maxPrice, int newStock)
		{
			var database = MongoLocalConnection.GetDatabase("itb");
			var collection = database.GetCollection<BsonDocument>("products");
			var filter = Builders<BsonDocument>.Filter.And(
				Builders<BsonDocument>.Filter.Gte("price", minPrice),
				Builders<BsonDocument>.Filter.Lte("price", maxPrice)
			)
			var update = Builders<BsonDocument>.Update.Set("stock", newStock);
			var updateResult = collection.UpdateMany(filter, update);
			Console.WriteLine($"Nombre de documents actualitzats: {updateResult.ModifiedCount}")
			var updatedProducts = collection.Find(filter).ToList();
			Console.WriteLine("Documents actualitzats:");
			foreach (var product in updatedProducts)
			{
				Console.WriteLine(product.ToString());
			}
			Console.ReadKey();
			Console.Clear();
		}

	}
}
