using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Course
    {
        public int Course_id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int User_id {  get; set; }
        public ICollection<Sessions> Sessions { get; set; } = new List<Sessions>();
        public ICollection<Enrolment> Enrolments { get; set; }= new List<Enrolment>();
        public Users? User { get; set; }

    }
}
