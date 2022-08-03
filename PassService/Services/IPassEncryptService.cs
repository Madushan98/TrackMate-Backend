namespace PassService.Services;

public interface IPassEncryptService
{
    string EncryptPass(string passData);
    string DecryptPass(string encryptPass);
}