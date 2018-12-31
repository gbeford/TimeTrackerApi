using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeTrackerAPI.Models
{
    [Table("UserType", Schema = "Security")]
    public partial class AppUserType
    {
        [Required()]
        [Key()]
        public Guid RoleTypeId { get; set; }

        [Required()]
        public Guid UserId { get; set; }

        [Required()]
        public string RoleType { get; set; }

        [Required()]
        public string RoleTypeValue { get; set; }
    }
}