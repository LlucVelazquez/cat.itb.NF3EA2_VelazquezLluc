using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cat.itb.NF3EA2_VelazquezLluc.connections;
using cat.itb.NF3EA2_VelazquezLluc.model;
using MongoDB.Bson;
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
	}
}
