namespace Domain.Entities;

public class AggregateEntity : Entity
{
    public AggregateEntity(Guid id) : base(id)
    {

    }
    public AggregateEntity()
    {

    }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public Guid CreatedBy { get; set; }
    public Guid UpdatedBy { get; set; }
}