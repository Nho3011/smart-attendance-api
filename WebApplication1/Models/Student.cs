namespace WebApplication1.Models
{
    public class Student
    {
        public int Student_id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; }= string.Empty;
        public string Email {  get; set; } = string.Empty;
        public string? Face_id {  get; set; }
        public ICollection<Enrolment> Enrolments { get; set; } = new List<Enrolment>();
    }
}
