namespace WebApplication1.Models
{
    public class Sessions
    {
        public int Session_id { get; set; }
        public string Name { get; set; }
        public int Course_id { get; set; }
        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
        public Course? Course { get; set; }
    }
}
