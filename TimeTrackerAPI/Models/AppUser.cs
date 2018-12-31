using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeTrackerAPI.Models
{
    [Table("User", Schema = "Security")]
    public partial class AppUser
    {
        [Required()]
        [Key()]
        public Guid UserId { get; set; }

        [Required()]
        [StringLength(255)]
        public string UserName { get; set; }

        [Required()]
        [StringLength(255)]
        public string Password { get; set; }

        [Required()]
        [StringLength(100)]
        public string DisplayName { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        public DateTime? LastLogin { get; set; }
    }

}