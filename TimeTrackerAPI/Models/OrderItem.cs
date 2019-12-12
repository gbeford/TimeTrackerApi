
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeTrackerAPI.Models
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
         public int ApparelId { get; set; }
        public string ItemName { get; set; }
        public string ItemType { get; set; }
        public string Gender { get; set; }
        public string Size { get; set; }
        public int? Quantity { get; set; }
        public float Price { get; set; }
        public decimal? UpCharge { get; set; }
        public decimal? NameCharge { get; set; }
         public Boolean? NameOnSleeve { get; set; }
        public string SleeveName { get; set; }
    }
}
