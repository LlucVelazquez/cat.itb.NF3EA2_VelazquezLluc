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
		public static void ShowBooksLess130()
		{
			var database = MongoLocalConnection.GetDatabase("itb");
			var collection = database.GetCollection<BsonDocument>("books");
			var filter = Builders<BsonDocument>.Filter.Lt("pageCount", 130);
			var cursor = collection.Find(filter).ToCursor();
            foreach (var document in cursor.ToEnumerable())
			{
                var title = document.GetElement("title");
                var pageCount = document.GetElement("pageCount");
                var authors = document.GetElement("authors");
                Console.WriteLine($"{title.ToString()} {pageCount.ToString()} {authors.ToString()}");
            }
            Console.ReadKey();
            Console.Clear();
        }
		public static void AddAuthorBook(string title, string author)
		{
			var database = MongoLocalConnection.GetDatabase("itb");
			var collection = database.GetCollection<BsonDocument>("books");
			var filter = Builders<BsonDocument>.Filter.Eq("title", title);
			var update = Builders<BsonDocument>.Update.AddToSet("authors", author);
			var document = collection.Find(filter).ToList();
			var authors = document[0].GetElement("authors");
			Console.WriteLine($"Authors: {authors.ToString()}");
			collection.UpdateMany(filter, update);
			var documentUpdate = collection.Find(filter).ToList();
			var authorsUpdate = documentUpdate[0].GetElement("authors");
			Console.WriteLine($"Authors: {authorsUpdate.ToString()}");
			Console.ReadKey();
			Console.Clear();
		}
		public static void DeleteBooksWithPageCountBetween(int minPages, int maxPages)
		{
			var database = MongoLocalConnection.GetDatabase("itb");
			var collection = database.GetCollection<BsonDocument>("books");
			var filter = Builders<BsonDocument>.Filter.And(
				Builders<BsonDocument>.Filter.Gte("pageCount", minPages),
				Builders<BsonDocument>.Filter.Lte("pageCount", maxPages)
			);
			var deleteResult = collection.DeleteMany(filter);
			Console.WriteLine($"Nombre de llibres eliminats: {deleteResult.DeletedCount}");
		}
		public static void RemoveLastCategoryByISBN(long isbn)
		{
			var database = MongoLocalConnection.GetDatabase("itb");
			var collection = database.GetCollection<BsonDocument>("books");
			var filter = Builders<BsonDocument>.Filter.Eq("isbn", isbn);
			var bookBefore = collection.Find(filter).FirstOrDefault();
			Console.WriteLine("Abans de l'actualització:");
			Console.WriteLine(bookBefore.ToString());
			var categories = bookBefore["categories"].AsBsonArray;
			if (categories.Count > 0)
			{
				categories.RemoveAt(categories.Count - 1);
				var update = Builders<BsonDocument>.Update.Set("categories", categories);
				collection.UpdateOne(filter, update);
				var bookAfter = collection.Find(filter).FirstOrDefault();
				Console.WriteLine("Després de l'actualització:");
				Console.WriteLine(bookAfter.ToString());
			}
			Console.ReadKey();
			Console.Clear();
		}

	}
}
