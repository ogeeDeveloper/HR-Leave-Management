using System.ComponentModel.DataAnnotations;

namespace HrLeaveManagment.BlazerUI.Models
{
    public class LeaveTypeVM
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Display(Name="Default Number of Days")]
        public int DefaultDays { get; set; }
    }
}
