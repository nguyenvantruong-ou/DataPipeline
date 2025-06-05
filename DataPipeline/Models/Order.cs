namespace DataPipeline.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string Quantity { get; set; }
        public decimal Price { get; set; } = decimal.Zero;
        public bool Static { get; set; } = true;
        public DateTime CreatedDate { get; set; }

        public virtual User User { get; set; }
        public virtual Product Product { get; set; }

    }
}
