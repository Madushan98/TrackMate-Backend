using DAOLIbrary.User;

namespace DAOLibrary.Pass;

public class PassDao
{
    public Guid Id { get; set; }

    public DateTime GeneratedDateTime { get; set; }

    public bool IsValid { get; set; }

    public bool IsApproved { get; set; }

    public DateTime StartDateTime { get; set; }

    public DateTime EndDateTime { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }
    
    public Guid ApprovedUserId { get; set; }
    public User ApprovedUser { get; set; }
    
    public virtual ICollection<PassLogDao> PassLogs { get; set; }
}