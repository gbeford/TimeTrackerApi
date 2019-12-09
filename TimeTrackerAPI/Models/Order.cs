using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeTrackerAPI.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public DateTime OrderDate { get; set; }
        public string ItemName { get; set; }
        public string ItemType { get; set; }
        public string Gender { get; set; }
        public string Size { get; set; }
        public Boolean CanHaveName { get; set; }
        public string NameOnSleeve{ get; set; }
        public int? Quantity { get; set; }
        public float Price { get; set; }
        public decimal? UpCharge { get; set; }
        public decimal? NameCharge { get; set; }
        public decimal OrderTotal { get; set; }
        public decimal ToTalAmountDue { get; set; }
    }
}
