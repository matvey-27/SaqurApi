using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace DataBase;

class UserDB{
    private static IMongoDatabase userdb = DataBaseDB.client.GetDatabase("user"); 
    public static void CreateCollectionUser(){      
        userdb.CreateCollection("users");
    }
    public static async Task<String> SingInUserTokenAsync(string login , string password){

        var collection = userdb.GetCollection<BsonDocument>("users");

        var filter = new BsonDocument { { "login", login },
                                        { "password", password } };
        
        var user = collection.Find(filter);

        if (!(await user.AnyAsync())){
            return "Incorrect login or password";
        }
        
        // User NewUser = new User {
                                
        //                         login = ServerInfo.ServerCryptor.AesEncryptionStringDataBaseKey(login),
        //                         password = ServerInfo.ServerCryptor.AesEncryptionStringDataBaseKey(password)
        //                         };

        // var update = Builders<BsonDocument>.Update.Push("d", "s");

        Console.WriteLine(user.ToList()[0]["login"]);

        return "";
    }
    public static async Task<bool> SingInUserAsync(string login , string password){

        var collection = userdb.GetCollection<BsonDocument>("users");

        var filter = new BsonDocument { { "login", login } };

        if (!(await collection.Find(filter).AnyAsync())){
            long count = await collection.CountDocumentsAsync(new BsonDocument());

            User NewUser = new User {
                                    id = (int)(count + 1),
                                    login = ServerInfo.ServerCryptor.AesEncryptionStringDataBaseKey(login),
                                    password = ServerInfo.ServerCryptor.AesEncryptionStringDataBaseKey(password)
                                    };

            Console.WriteLine(NewUser.ToBsonDocument());

            await collection.InsertOneAsync(NewUser.ToBsonDocument());

            return true;
        }

        return false;
    } 
}