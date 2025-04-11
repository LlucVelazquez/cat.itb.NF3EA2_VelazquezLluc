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
    public class StudentCRUD
    {
		public static void LoadStudentsCollection()
		{
			var database = MongoLocalConnection.GetDatabase("itb");
			database.DropCollection("students");
			var collection = database.GetCollection<BsonDocument>("students");
			FileInfo file = new FileInfo("../../../files/students.json");
			using (StreamReader sr = file.OpenText())
			{
				string line;
				while ((line = sr.ReadLine()) != null)
				{
					Student student = JsonConvert.DeserializeObject<Student>(line);
					Console.WriteLine(student.firstname);
					string json = JsonConvert.SerializeObject(student);
					var document = new BsonDocument();
					document.AddRange(BsonDocument.Parse(json));
					collection.InsertOne(document);
				}
			}
		}
	}
}
