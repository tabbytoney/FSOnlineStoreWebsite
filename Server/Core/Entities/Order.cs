using Core.Enums;

namespace Core.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime Orderdate { get; set; }
        public string Description { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DepositAmount { get; set; }

        // flags
        public int IsDelivery { get; set; }
        public Status Status { get; set; }
        public string OtherNotes { get; set; }
        public int IsDeleted { get; set; }
        public Customer Customer { get; set; }
    }
}