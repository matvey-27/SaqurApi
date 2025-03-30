using System.Threading.Tasks;
using MongoDB.Driver;

namespace DataBase;

class UserDB{
    private static IMongoDatabase userdb = DataBaseDB.client.GetDatabase("user"); 

    public static void CreateCollectionUser(){      
        userdb.CreateCollection("users");
    }
    public static async Task<string> SingInUserAsync(string login , string password){



        return "dd";
    } 
}