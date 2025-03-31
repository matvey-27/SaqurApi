using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

using SaqurApi.Crypton;

namespace SaqurApi.DataBase;

class UserDB{
    private static IMongoDatabase userdb = DataBaseDB.client.GetDatabase("user"); 
    public static void CreateCollectionUser(){      
        userdb.CreateCollection("users");
    }
    public static async Task<String> SingInUserTokenAsync(string login , string password, string ClientRsaOpenKey){

        var collection = userdb.GetCollection<BsonDocument>("users");

        var filter = new BsonDocument { { "login", login  },
                                        { "password", password } };
        
        var userF = collection.Find(filter);

        if (!(await userF.AnyAsync())){
            return "Incorrect login or password";
        }

        var user = userF.ToList();
        
        Token NewToken = new Token {
                                token = Cryptor.AesEncryptionTokenString(DateTime.UtcNow.ToString() + user[0]["login"]),
                                ClientRsaOpenKey = ClientRsaOpenKey
                                };

        var update = Builders<BsonDocument>.Update.Push("tokenList", NewToken.ToBsonDocument());

        var result = await collection.UpdateManyAsync(filter, update);
                        
        Console.WriteLine(result + "fff");

        return "";
    }
    public static async Task<bool> SingInUserAsync(string login , string password, string ClientRsaOpenKey){

        var collection = userdb.GetCollection<BsonDocument>("users");

        var filter = new BsonDocument { { "login", login } };

        if (!(await collection.Find(filter).AnyAsync())){
            long count = await collection.CountDocumentsAsync(new BsonDocument());

            // Token NewToken = new Token {
            //                     token = Cryptor.AesEncryptionTokenString(DateTime.UtcNow.ToString() + user[0]["login"]),
            //                     ClientRsaOpenKey = ClientRsaOpenKey
            //                     };

            User NewUser = new User {
                                    id = (int)(count + 1),
                                    login = login,
                                    password = password,
                                    tokenList = new List<Token>()
                                    };

            Console.WriteLine(NewUser.ToBsonDocument());

            await collection.InsertOneAsync(NewUser.ToBsonDocument());

            return true;
        }

        return false;
    } 
}