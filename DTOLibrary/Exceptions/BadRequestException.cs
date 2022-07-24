namespace DTOLibrary.Exceptions;

public class BadRequestException : Exception
{
    public Error Error { get; private set; }

    public BadRequestException(Error error)
    {
        Error = error;
    }
        
}