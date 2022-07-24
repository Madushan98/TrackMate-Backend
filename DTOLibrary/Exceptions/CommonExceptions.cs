namespace DTOLibrary.Exceptions;

public class CommonExceptions
{
    public static readonly Error NationalIdAlreadyRegistered = new Error( "National Id Already Registered");
    public static readonly Error UserNotFound = new Error( "User Not Found");
    public static readonly Error UserPasswordMisMatch = new Error( "User Password MissMatch");
}