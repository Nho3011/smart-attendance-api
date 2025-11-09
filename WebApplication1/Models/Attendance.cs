namespace WebApplication1.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public DateTime Date {  get; set; }
        public int Session_id { get; set; } 
        public int Enrolment_id { get; set; }

    }
}
