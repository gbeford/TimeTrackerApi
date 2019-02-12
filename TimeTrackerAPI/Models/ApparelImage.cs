using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeTrackerAPI.Models
{
    public class ApparelImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApparelImageId { get; set; }
        public string FileName { get; set; }
        public string ImageName { get; set; }
        public Byte [] Image { get; set; }
        public string ContentType { get; set; }
    }
}

