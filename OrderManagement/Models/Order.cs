using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Models
{
    public class Order
    {
        [Required]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? OrderStatus { get; set; }
        public double Price { get; set; }
    }
}
