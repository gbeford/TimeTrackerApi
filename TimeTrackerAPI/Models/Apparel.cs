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
        public Boolean CanHaveName { get; set; }
        public string Size { get; set; }
        public float Price { get; set; }
        public string Type { get; set; }
        public int? Quantity { get; set; }
        public decimal? UpCharge { get; set; }
        public decimal? NameCharge { get; set; }
        public string Filename { get; set; }
        public string Image { get; set; }
        public string ContentType { get; set; }

    }
}
