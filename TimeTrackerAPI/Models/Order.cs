using System;
using System.Collections.Generic;
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
        public virtual List<OrderItem> Items { get; set; }
        public decimal GrossTotal { get; set; }
    }
}
