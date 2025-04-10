using System;

class ServerInfo{
    public static string _db_url = "mongodb://SaqurDB:root@localhost:27017";
    public static string _ServerRsaPunlicKey = "MIIBCgKCAQEAubpwRO3ZilWOUCmX+1IVwjHYDs4SLajYS5y4fWIUaHiby2XhTdKNl9s4bNkZeYDh5mLgnQjrjnBdbEg5Bj2NH02nEtXZon0K3mMnsGJN39pKQ266PFNbMLtefGBlRUUnRG8uvv+Xsi/LcWmpLWUNfL0l0U8lyCOfkh77/0F8WJRKCRRuk2hTMS+BtzGiyQMerYyJdSdBE6eYQR4QuXqt4BNKFx1kFTW9uxt2fR1XAmKeeLW+uC1QyRaO5UtKsVw36rVVNFKXpfiNV0gWrDY9Rpeg3NMh6aKE1bHeVRN6lKoCetn7EUtpRhirX+dg+K3unMBWKEOx4BigZJ3WggPJMQIDAQAB";
    public static string _ServerRsaPrivateKey = "MIIEowIBAAKCAQEAubpwRO3ZilWOUCmX+1IVwjHYDs4SLajYS5y4fWIUaHiby2XhTdKNl9s4bNkZeYDh5mLgnQjrjnBdbEg5Bj2NH02nEtXZon0K3mMnsGJN39pKQ266PFNbMLtefGBlRUUnRG8uvv+Xsi/LcWmpLWUNfL0l0U8lyCOfkh77/0F8WJRKCRRuk2hTMS+BtzGiyQMerYyJdSdBE6eYQR4QuXqt4BNKFx1kFTW9uxt2fR1XAmKeeLW+uC1QyRaO5UtKsVw36rVVNFKXpfiNV0gWrDY9Rpeg3NMh6aKE1bHeVRN6lKoCetn7EUtpRhirX+dg+K3unMBWKEOx4BigZJ3WggPJMQIDAQABAoIBAAQI3v1dWCJlXkeDJs0/rM+0mN2l9/7ATi4S0g5tu/UiyRohnQPNdxRZX5v8OZ2iSU4BoADjT6gvDFWAymXWfpdDbuWlqgIZ0quO9n7SPOA3+BDn0fGDa03HRTvBFZQcFui5fFfLekB1gbc1kRZ2jXTkMEMQM8k5rmLMi+OBOP381ba3PfSXWxtmM4mu6/K5fWOoHbKLcju/lMDhReBm/JqNGKIFT6KwhVouDA3A+uBuRpNjD0JV/rpNVjqVpcZRJW8Ucz8YJ2shGQA0AJ89VaXgx+oMs8KD6agYpAy6Wtqf9v0T48aOm0JJbJ6SoLA+RWWeiIm8A33b9Lfx/IxHL4ECgYEA3x+Y0M69bhYpkRSfi/kOweH4z5+L/rPmImaW8lma733esDfxd4dFUgMoEWBHADPfbMLtkxqmhhfdxFa8RzmDeuO1fIxCpir4MgCCzroP1dK0RGfyOOf0qdnVjEf2owkIO2kfyZ+B8rUDAytO8m2InTNdXI1IsVRYY09jN7GEtbECgYEA1RhD4Gtph8UBTHCiZ/juA8h2iyHg16+6W3vrBAuLAUGzpAtCPOi3q6PrZWsM9PKD9Qyv0BvBd6SiamSBFKtYFK4aEwVWK3y6rXuQjE+G0Pc4zJzdzDVVZo1bHq539agkhwlMQ0c27LxGTXSqi88iXu3BCOivU7ApXw1NgIv3q4ECgYEAugAUG1WNEr2E7z269yurQrNHAIXnZW/A1EKjaOqLv0Q1pL8uG0932TNqbnnNFn0nrvocpLndwgEZTThlAhcO5R34SBiA4xcFCmHkqcLvundI8ZGZmhi7m/BNFgFTuHuqEiTDbAf9gz+kgDrVOEFZVnrgRGw/AhznBfrDIkVo9TECgYBAG2CwLyA8XCQb3va82MKiGLiw+qwttwwVYZ4+RUq4Qg/NFiYDNO+sj0/N3vqy5hKUshBiRzdYywqhf0Ll+PYyon3tovldc9SlRDskOviP/Q/1XmvLd3ANvhDflhU4rjDu/vkWdGItriZoPuTf0pzAej5Mc9PrFWAc3F+ogHMuAQKBgCflGAlJA/BA+9zN57kIrDvO2XzehB8Pa+9PTW57girLUCRGgJnTsp4MD+JaVKsubVE41gsD01CEk1GUJZm1F0TuS+LLGdeb5ADZj3ezhQ9EXW9Vug5TdXh7qr2zQJZLUL6IKcsPXp7XwnFjs+CrGiZBUhUX4L7ofkgvEjpAr9en";
    public static string _ServerAesPunlicKey = "ZJDXhSwQFuOXVBY7G5VsEhCWXCRYJj4Vc6EXMVUp6FQ=";
    public static string _ServerAesPrivateIv = "27Oiw0djVfIwGvJZpoXUug==";
    public static Cryptor ServerCryptor = new Cryptor(
        Convert.FromBase64String(_ServerRsaPunlicKey), 
        Convert.FromBase64String(_ServerRsaPrivateKey),
        Convert.FromBase64String(_ServerAesPunlicKey),
        Convert.FromBase64String(_ServerAesPrivateIv)
        );
}