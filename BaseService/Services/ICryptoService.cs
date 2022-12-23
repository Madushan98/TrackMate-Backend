namespace BaseService.Services;

public interface ICryptoService
{
    Tuple<string, string, string> Encrypt(string value);
    string Decrypt(string value, string key, string iv);

    string EncryptLogData(string value, string key, string iv);
}