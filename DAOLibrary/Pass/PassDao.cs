using DAOLibrary.User;


namespace DAOLibrary.Pass;

public class PassDao
{
    public Guid Id { get; set; }
    
    public DateTime GeneratedDateTime { get; set; }
    public string PassCategory { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public bool IsReoccurring { get; set; }
    public bool IsValid { get; set; }
    public bool IsApproved { get; set; }
    public DateTime? StartDateTime { get; set; }
    public DateTime? EndDateTime { get; set; }
    
    public ICollection<PassDataMap>? Data { get; set; }
    public Guid UserId { get; set; }
    public UserDao User { get; set; }
    public string NationalId { get; set; }
    public UserPassDao? UserPassDao { get; set; }
    public virtual ICollection<PassLogDao> PassLogs { get; set; }
}


public class PassDataMap
{
    public  Guid Id { get; set; }
    public  Guid PassDaoId { get; set; }
    public  PassDao? PassDao { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
}