using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

using SaqurApi.Model;

namespace SaqurApi.DataBase;

class UserDB{
    private static IMongoDatabase userdb = DataBaseDB.client.GetDatabase("user"); 
    public static void CreateCollectionUser(){      
        userdb.CreateCollection("users");
    }
    public static async Task<String> SingInUserTokenAsync(string login , string password, string clientRsaOpenKey){

        var collection = userdb.GetCollection<BsonDocument>("users");

        var filter = new BsonDocument { { "login", ServerInfo.cryptor.AesEncryptionStringToHexString(login)  },
                                        { "password", ServerInfo.cryptor.AesEncryptionStringToHexString(password) } };
        
        var userF = collection.Find(filter);

        if (!(await userF.AnyAsync())){
            return "Incorrect login or password";
        }

        var user = userF.ToList();
        
        Token NewToken = new Token {
                                token = ServerInfo.cryptor.AesEncryptionStringToHexString(Cryptor.AesEncryptionTokenString(DateTime.UtcNow.ToString() + user[0]["login"])),
                                clientRsaOpenKey = ServerInfo.cryptor.AesEncryptionStringToHexString(clientRsaOpenKey)
                                };

        var update = Builders<BsonDocument>.Update.Push("tokenList", NewToken.ToBsonDocument());

        var result = await collection.UpdateManyAsync(filter, update);
                        
        Console.WriteLine(result + "fff");

        return "";
    }
    public static async Task<bool> SingInUserAsync(string login , string password, string clientRsaOpenKey){

        var collection = userdb.GetCollection<BsonDocument>("users");

        var filter = new BsonDocument { { "login", ServerInfo.cryptor.AesEncryptionStringToHexString(login) } };

        if (!(await collection.Find(filter).AnyAsync())){
            long count = await collection.CountDocumentsAsync(new BsonDocument());

            // Token NewToken = new Token {
            //                     token = Cryptor.AesEncryptionTokenString(DateTime.UtcNow.ToString() + user[0]["login"]),
            //                     clientRsaOpenKey = clientRsaOpenKey
            //                     };

            User NewUser = new User {
                                    id = (int)(count + 1),
                                    login = ServerInfo.cryptor.AesEncryptionStringToHexString(login),
                                    password = ServerInfo.cryptor.AesEncryptionStringToHexString(password),
                                    tokenList = new List<Token>()
                                    };

            Console.WriteLine(NewUser.ToBsonDocument());

            await collection.InsertOneAsync(NewUser.ToBsonDocument());

            return true;
        }

        return false;
    } 
}