using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cat.itb.NF3EA2_VelazquezLluc.connections;
using cat.itb.NF3EA2_VelazquezLluc.model;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace cat.itb.NF3EA2_VelazquezLluc.cruds
{
    public class PeopleCRUD
    {
		public static void LoadPeopleCollection()
		{
			FileInfo file = new FileInfo("../../../files/people.json");
			StreamReader sr = file.OpenText();
			string fileString = sr.ReadToEnd();
			sr.Close();
			List<Person> people = JsonConvert.DeserializeObject<List<Person>>(fileString);

			var database = MongoLocalConnection.GetDatabase("itb");
			database.DropCollection("people");
			var collection = database.GetCollection<BsonDocument>("people");

			if (people != null)
				foreach (var person in people)
				{
					Console.WriteLine(person.name);
					string json = JsonConvert.SerializeObject(person);
					var document = new BsonDocument();
					document.AddRange(BsonDocument.Parse(json));
					collection.InsertOne(document);
				}
		}
		public static void ShowFriendsByPeople(string name)
        {
            var database = MongoLocalConnection.GetDatabase("itb");
            var collection = database.GetCollection<BsonDocument>("people");
            var filter = Builders<BsonDocument>.Filter.Eq("name", name);
            var personDocument = collection.Find(filter).FirstOrDefault();
            Console.WriteLine($"Friends of {name}:");
            var friends = personDocument.GetValue("friends").AsBsonArray;
            foreach (var friend in friends)
            {
                Console.WriteLine(friend["name"]);
            }
        }
		public static void RemoveTagsFromTeachers()
		{
			var database = MongoLocalConnection.GetDatabase("itb");
			var collection = database.GetCollection<BsonDocument>("people");
			var filter = Builders<BsonDocument>.Filter.Eq("profession", "teacher");
			var update = Builders<BsonDocument>.Update.Unset("tags");
			var updateResult = collection.UpdateMany(filter, update);
			Console.WriteLine($"Nombre de professors actualitzats (camp 'tags' eliminat): {updateResult.ModifiedCount}");
		}

	}
}
