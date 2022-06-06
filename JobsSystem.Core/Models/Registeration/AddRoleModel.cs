using System.ComponentModel.DataAnnotations;

namespace JobsSystem.Core.Models.Registeration
{
    public class AddRoleModel
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
