namespace SaqurApi;

static class ServerInfo{
    public static Cryptor cryptor = new Cryptor(
        Cryptor.StringHexToBytes("1F-46-22-46-0F-AA-66-4D-F6-7A-3D-02-4A-01-FE-D3-4B-EE-4E-A2-78-10-D5-2D-5B-52-86-97-85-B9-D9-7B"),
        Cryptor.StringHexToBytes("B9-F9-08-74-23-4D-74-E2-E0-C8-E7-2D-8E-F6-24-97") 
    );
    public static string _db_url = "mongodb://SaqurDB:root@localhost:27017";
}