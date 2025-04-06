using MongoDB.Driver;

namespace SaqurApi.DataBase;

class DataBase{
    public static MongoClient client = new MongoClient(ServerInfo._db_url);
    
}