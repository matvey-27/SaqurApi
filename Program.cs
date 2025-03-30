using DataBase;

// Console.WriteLine("hello world");
// Console.WriteLine(ServerInfo.ServerCryptor.AesEncryptionString("hello world"));
// Console.WriteLine(ServerInfo.ServerCryptor.AesDecryptionString(ServerInfo.ServerCryptor.AesEncryptionString("hello world")));

await UserDB.SingInUserAsync("fcdssffff", "fffff");
await UserDB.SingInUserTokenAsync("fcdssffff", "fffff");