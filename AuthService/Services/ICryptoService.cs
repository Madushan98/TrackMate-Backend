namespace AuthService.Services;

public interface ICryptoService
{
    string GetHash(string input);
    Tuple<string, string, string> Encrypt(string value);
    string Decrypt(string value, string key, string iv);
}