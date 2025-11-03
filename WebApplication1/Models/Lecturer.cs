namespace WebApplication1.Models
{
    public class Lecturer
    {
        public int User_id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Phone {  get; set; }
        public Users? User { get; set; }
    }
}
