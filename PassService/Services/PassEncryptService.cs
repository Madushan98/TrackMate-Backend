using Microsoft.AspNetCore.DataProtection;

namespace PassService.Services;

public class PassEncryptService: IPassEncryptService
{
    private readonly IDataProtector _dataProtector;

    public PassEncryptService(IDataProtectionProvider  dataProtector)
    {
        _dataProtector = dataProtector.CreateProtector("SeacreteKey");
    }

    public string EncryptPass(string passData)
    {
        string encryptPass = _dataProtector.Protect(passData);

        return encryptPass;
    }

    public string DecryptPass(string encryptPass)
    {
        string decryptPass = _dataProtector.Unprotect(encryptPass);

        return decryptPass;
    }
}