namespace SaqurApi.Crypton;


public partial class Cryptor{

    Cryptor(byte[] AesKeyDataBase, byte[] AesIvDataBase){
        this.AesKeyDataBase = AesKeyDataBase;
        this.AesIvDataBase = AesIvDataBase;
    }
}