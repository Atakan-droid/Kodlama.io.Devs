namespace Domain.Entities;

public class CourseTechs : Entity
{
    public string Name { get; set; }

    public virtual Course Course { get; set; }
    public CourseTechs()
    {
    }

    public CourseTechs(Guid id, string name) : base(id)
    {
        Id = id;
        Name = name;
    }
}