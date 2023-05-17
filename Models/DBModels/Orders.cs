namespace Gazenergokomplekt.Models.DBModels
{
    public class Orders
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Message { get; set; }
        public string? Product { get; set; }
        public DateTime? DateCreationOrder { get; set; }
    }
}
