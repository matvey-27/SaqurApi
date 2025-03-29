// dotnet add package MongoDB.Driver
using MongoDB.Driver;
 
MongoClient client = new MongoClient("mongodb://SaqurDB:root@localhost:27017");
using (var cursor = await client.ListDatabasesAsync())
{
    var databases = cursor.ToList();
    foreach (var database in databases)
    {
        Console.WriteLine(database);
    }
}