namespace DTOLibrary.Exceptions;

public class NotFoundException: Exception
{
    public Error Error { get; private set; }

    public NotFoundException(Error error)
    {
        Error = error;
    }

}