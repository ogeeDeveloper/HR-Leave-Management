namespace HRLeaveManagement.Domain.Common;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public string? Created { get; set; }
    public DateTime? DateCreated { get; set; }
    public string? Modified { get; set; }
    public DateTime? DateModified { get; set; }
}
