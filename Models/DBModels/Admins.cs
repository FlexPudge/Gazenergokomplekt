namespace Gazenergokomplekt.Models.DBModels
{
    public class Admins
    {
        public int ID { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Roles { get; set; }
    }
}
