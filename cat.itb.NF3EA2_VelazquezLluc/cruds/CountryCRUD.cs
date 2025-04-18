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
    public class CountryCRUD
    {
		public static void LoadCountriesCollection()
		{
			FileInfo file = new FileInfo("../../../files/countries.json");
			StreamReader sr = file.OpenText();
			string fileString = sr.ReadToEnd();
			sr.Close();
			List<Country> countries = JsonConvert.DeserializeObject<List<Country>>(fileString);

			var database = MongoLocalConnection.GetDatabase("itb");
			database.DropCollection("countries");
			var collection = database.GetCollection<BsonDocument>("countries");

			if (countries != null)
				foreach (var country in countries)
				{
					Console.WriteLine(country.name);
					string json = JsonConvert.SerializeObject(country);
					var document = new BsonDocument();
					document.AddRange(BsonDocument.Parse(json));
					collection.InsertOne(document);
				}
		}
		public static void ShowCountriesEurope()
		{
			var database = MongoLocalConnection.GetDatabase("itb");
			var collection = database.GetCollection<BsonDocument>("countries");
			var filter = Builders<BsonDocument>.Filter.Eq("region", "Europe");
			var cursor = collection.Find(filter).ToCursor();
			int num = 0;
			foreach (var document in cursor.ToEnumerable())
			{
				num++;
				var population = document.GetElement("population");
				var country = document.GetElement("name");
				Console.WriteLine($"{num} {country.ToString()} {population.ToString()}");
			}
			Console.ReadKey();
			Console.Clear();
		}
		public static void ShowOneCountry(string countryName)
		{
			var database = MongoLocalConnection.GetDatabase("itb");
			var collection = database.GetCollection<BsonDocument>("countries");
			var filter = Builders<BsonDocument>.Filter.Eq("name", countryName);
			var countryDocument = collection.Find(filter).FirstOrDefault();
			var capital = countryDocument.GetElement("capital");
			var population = countryDocument.GetElement("population");
			var latlng = countryDocument.GetElement("latlng");
			Console.WriteLine(capital.ToString());
			Console.WriteLine(population.ToString());
			Console.WriteLine(latlng.ToString());
			Console.ReadKey();
			Console.Clear();
		}
		public static void AddCallingCodeToIceland(int newCode)
		{
			var database = MongoLocalConnection.GetDatabase("itb");
			var collection = database.GetCollection<BsonDocument>("countries");

			var filter = Builders<BsonDocument>.Filter.Eq("name", "Iceland");

			var countryBefore = collection.Find(filter).FirstOrDefault();
			if (countryBefore == null)
			{
				Console.WriteLine("El país 'Iceland' no existeix a la col·lecció.");
				return;
			}

			Console.WriteLine("Abans de l'actualització:");
			Console.WriteLine(countryBefore.ToString());

			var update = Builders<BsonDocument>.Update.AddToSet("callingCodes", newCode);
			collection.UpdateOne(filter, update);

			var countryAfter = collection.Find(filter).FirstOrDefault();
			Console.WriteLine("Després de l'actualització:");
			Console.WriteLine(countryAfter.ToString());
			Console.ReadKey();
			Console.Clear();
		}
		public static void DeleteCountriesByLanguage(string language)
		{
			var database = MongoLocalConnection.GetDatabase("itb");
			var collection = database.GetCollection<BsonDocument>("countries");
			var filter = Builders<BsonDocument>.Filter.AnyEq("languages", language);
			var deleteResult = collection.DeleteMany(filter);
			Console.WriteLine($"Nombre de països eliminats on es parla '{language}': {deleteResult.DeletedCount}");
		}

	}
}
