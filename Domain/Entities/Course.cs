namespace Domain.Entities;

public class Course : AggregateEntity
{
    public Course(Guid id) : base(id)
    {

    }
    public Course()
    {
        CourseTechs = new HashSet<CourseTechs>();
    }

    public ICollection<CourseTechs> CourseTechs { get; set; }
    public DateTime StartDate { get; set; }
    public string CourseName { get; set; }
    public DateTime EndDate { get; set; }
    public double Price { get; set; }
}