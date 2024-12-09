namespace OrderManagementApp.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? OrderStatus { get; set; }
        public double Price { get; set; }

        public OrderModel()
        {
                
        }
    }
}
