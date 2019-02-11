using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeTrackerAPI.Models
{
    public class Apparel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApparelId { get; set; }
        public int ApparelImageId { get; set; }
        public string Item { get; set; }
        public string Description { get; set; }
        public string Gender { get; set; }
        public int Price { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }
        public int? Quantity { get; set; }
    }
}
