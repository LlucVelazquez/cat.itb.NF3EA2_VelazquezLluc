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
    public class BookCRUD
    {
		public static void LoadBooksCollection()
		{
			FileInfo file = new FileInfo("../../../files/books.json");
			StreamReader sr = file.OpenText();
			string fileString = sr.ReadToEnd();
			sr.Close();
			List<Book> books = JsonConvert.DeserializeObject<List<Book>>(fileString);

			var database = MongoLocalConnection.GetDatabase("itb");
			database.DropCollection("books");
			var collection = database.GetCollection<BsonDocument>("books");

			if (books != null)
				foreach (var book in books)
				{
					Console.WriteLine(book.title);
					string json = JsonConvert.SerializeObject(book);
					var document = new BsonDocument();
					document.AddRange(BsonDocument.Parse(json));
					collection.InsertOne(document);
				}
		}
		public static void ShowBooksFields()
		{
			var database = MongoLocalConnection.GetDatabase("itb");
			var collection = database.GetCollection<BsonDocument>("books");
			var sort = Builders<BsonDocument>.Sort.Descending("pageCount");
			var cursor = collection.Find(new BsonDocument()).Sort(sort).ToCursor();
			foreach (var document in cursor.ToEnumerable())
			{
				var title = document.GetElement("title");
				var pageCount = document.GetElement("pageCount");
				var categories = document.GetElement("categories");
				Console.WriteLine($"{title.ToString()} {pageCount.ToString()} {categories.ToString()}");
			}
			Console.ReadKey();
			Console.Clear();
		}
	}
}
