namespace TimeTrackerAPI.Models
{
    public class OrderDetail
    {
        public string StudentName { get; set; }
        public string Item { get; set; }
        public decimal GrossTotal { get; set; }
        public bool Paid { get; set; }
        public decimal Price { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public bool NameOnSleeve { get; set; }
        public decimal NameCharge { get; set; }
        public string SleeveName { get; set; }
        public decimal UpCharge { get; set; }
    }
}
