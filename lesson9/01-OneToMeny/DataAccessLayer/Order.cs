using System;

namespace DataAccessLayer
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public DateTime PurchaseDate { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
