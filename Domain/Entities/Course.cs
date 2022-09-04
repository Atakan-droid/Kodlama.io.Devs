namespace Domain.Entities;

public class Course : AggregateEntity
{
    public Course(Guid id) : base(id)
    {

    }
    public Course()
    {

    }
    public string CourseName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double Price { get; set; }
}