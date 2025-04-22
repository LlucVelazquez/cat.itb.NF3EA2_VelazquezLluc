using cat.itb.NF3EA2_VelazquezLluc.connections;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat.itb.NF3EA2_VelazquezLluc.cruds
{
    public static class GeneralCRUD
    {
		public static void DropCollection(string databaseName, string collectionName)
		{
			var database = MongoLocalConnection.GetDatabase(databaseName);
			var collection = database.GetCollection<BsonDocument>(collectionName);
			var documentCount = collection.CountDocuments(new BsonDocument());
			Console.WriteLine($"Nombre de documents a la col·lecció '{collectionName}': {documentCount}");

			database.DropCollection(collectionName);
			Console.WriteLine($"La col·lecció '{collectionName}' ha estat eliminada.");
			var remainingCollections = database.ListCollectionNames().ToList();
			Console.WriteLine("Col·leccions restants a la base de dades:");
			foreach (var remainingCollection in remainingCollections)
			{
				Console.WriteLine($"- {remainingCollection}");
			}
		}
	}
}
