using MongoDB.Driver;

namespace SaqurApi.DataBase;

class DataBaseDB{
    public static MongoClient client = new MongoClient(ServerInfo._db_url);
    
}