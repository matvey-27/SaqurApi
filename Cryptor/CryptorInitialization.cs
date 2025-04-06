// https://learn.microsoft.com/ru-ru/dotnet/api/system.bitconverter.tostring?view=net-8.0 
// BitConverter.ToString Метод

// https://stackoverflow.com/questions/724862/converting-from-hex-to-string  
// Как в C# строку, полученную через (BitConverter), преобразовать обратно в byte[]?


namespace SaqurApi;

public partial class Cryptor{

    public Cryptor(byte[] AesKeyDataBase, byte[] AesIvDataBase) {
        this.AesKeyDataBase = AesKeyDataBase;
        this.AesIvDataBase = AesIvDataBase;
    }
}