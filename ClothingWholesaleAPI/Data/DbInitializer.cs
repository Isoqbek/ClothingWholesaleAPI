using ClothingWholesaleAPI.Models;
using System;
using System.Linq;

namespace ClothingWholesaleAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Check if database already has orders
            if (context.Orders.Any())
            {
                return; // DB has been seeded
            }

            // O'zbekiston va xalqaro mijozlar uchun mock data
            var customers = new[]
            {
                "Toshkent Moda", "Samarkand Tekstil", "Namangan Textile", "Bukhara Style",
                "Fergana Fashion", "Dubai Imports LLC", "London Fashion Hub", "Istanbul Garments",
                "Seoul K-Fashion", "Moscow Elegance", "Beijing Apparel Co.", "New York Wholesale",
                "Paris Boutique Supplies", "Milan Fashion Forward", "Berlin Textile GmbH"
            };

            var statuses = new[]
            {
                "Yangi", "Tayyorlanmoqda", "Yuborilgan", "Yetkazib berilgan", "Bekor qilingan"
            };

            var addresses = new[]
            {
                "Muqimiy ko'chasi 12, Toshkent", "Gagarin prospekti 45, Samarqand",
                "Navoiy shoh ko'chasi 78, Namangan", "A.Temur ko'chasi 23, Buxoro",
                "Al Barsha Street 14, Dubai", "Oxford Street 145, London",
                "Istiklal Caddesi 67, Istanbul", "Gangnam District 123, Seoul",
                "Tverskaya Street 89, Moscow", "Wangfujing Street 56, Beijing",
                "5th Avenue 234, New York", "Champs-Élysées 45, Paris",
                "Via Montenapoleone 12, Milan", "Kurfürstendamm 78, Berlin"
            };

            var random = new Random();

            // Generate 100 orders
            var orders = new Order[100];

            for (int i = 0; i < 100; i++)
            {
                var customer = customers[random.Next(customers.Length)];
                var status = statuses[random.Next(statuses.Length)];
                var orderDate = DateTime.Now.AddDays(-random.Next(1, 60));

                DateTime? deliveryDate = null;
                if (status == "Yetkazib berilgan")
                {
                    deliveryDate = orderDate.AddDays(random.Next(3, 14));
                }
                else if (status == "Yuborilgan")
                {
                    deliveryDate = DateTime.Now.AddDays(random.Next(1, 7));
                }

                var totalAmount = random.Next(1000, 10001); // $1000-$10,000

                orders[i] = new Order
                {
                    CustomerName = customer,
                    Status = status,
                    OrderDate = orderDate,
                    DeliveryDate = deliveryDate,
                    TotalAmount = totalAmount,
                    Currency = "USD",
                    ShippingAddress = addresses[random.Next(addresses.Length)],
                    ContactPhone = $"+{(customer.Contains("Toshkent") || customer.Contains("Samarkand") || customer.Contains("Namangan") || customer.Contains("Bukhara") || customer.Contains("Fergana") ? "998" : random.Next(1, 99))}{random.Next(100000000, 999999999)}",
                    TrackingNumber = $"WH{random.Next(100000, 999999)}",
                    Notes = random.Next(3) == 0 ? "Maxsus yetkazib berish talablari" : null
                };
            }

            context.Orders.AddRange(orders);
            context.SaveChanges();
        }
    }
}