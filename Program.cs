using MongoDB.Driver;

using (var cursor = await DataBase.DataBaseDB.client.ListDatabasesAsync())
{
    var databases = cursor.ToList();
    foreach (var database in databases)
    {
        Console.WriteLine(database);
    }
}