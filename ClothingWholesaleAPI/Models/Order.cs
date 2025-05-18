namespace ClothingWholesaleAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public required string CustomerName { get; set; } // required qo‘shildi
        public required string Status { get; set; } // required qo‘shildi
        public DateTime OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Currency { get; set; } = "USD"; // Default qiymat
        public required string ShippingAddress { get; set; } // required qo‘shildi
        public required string ContactPhone { get; set; } // required qo‘shildi
        public required string TrackingNumber { get; set; } // required qo‘shildi
        public string? Notes { get; set; } // Nullable qilindi
    }
}