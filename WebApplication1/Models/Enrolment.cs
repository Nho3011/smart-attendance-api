namespace WebApplication1.Models
{
    public class Enrolment
    {
        public int Enrolment_id {  get; set; }
        public string Status {  get; set; }
        public int Student_id {  get; set; }
        public int Course_id {  get; set; }
        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
        public Course? Course { get; set; }
        public Student? Student { get; set; } 
    }
}
