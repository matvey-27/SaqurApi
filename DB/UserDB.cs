using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace DataBase;

class UserDB{
    private static IMongoDatabase userdb = DataBaseDB.client.GetDatabase("user"); 

    public static void CreateCollectionUser(){      
        userdb.CreateCollection("users");
    }



    public static async Task<string> SingInUserAsync(string login , string password){

        var collection = userdb.GetCollection<BsonDocument>("users");

        var filter = new BsonDocument { { "login", login } };

        if (!(await collection.Find(filter).AnyAsync())){
            long count = await collection.CountDocumentsAsync(new BsonDocument());

            User NewUser = new User { id = (int)(count + 1),
                                      login = login,
                                      password = password};

            Console.WriteLine(NewUser.ToBsonDocument());

            await collection.InsertOneAsync(NewUser.ToBsonDocument());
        } 

        return "";
    } 
}