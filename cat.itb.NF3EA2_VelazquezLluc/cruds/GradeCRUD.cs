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
    public class GradeCRUD
    {
		public static void LoadGradesCollection()
		{
			var database = MongoLocalConnection.GetDatabase("itb");
			database.DropCollection("grades");
			var collection = database.GetCollection<BsonDocument>("grades");
			FileInfo file = new FileInfo("../../../files/grades.json");
			using (StreamReader sr = file.OpenText())
			{
				string line;
				while ((line = sr.ReadLine()) != null)
				{
					Grade grades = JsonConvert.DeserializeObject<Grade>(line);
					Console.WriteLine(grades.student_id);
					string json = JsonConvert.SerializeObject(grades);
					var document = new BsonDocument();
					document.AddRange(BsonDocument.Parse(json));
					collection.InsertOne(document);
				}
			}
		}
	}
}
