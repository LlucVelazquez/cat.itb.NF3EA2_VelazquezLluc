﻿using cat.itb.NF3EA2_VelazquezLluc.connections;
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
	}
}
