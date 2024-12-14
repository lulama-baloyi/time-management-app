using System.ComponentModel.DataAnnotations;

namespace timeMnagementWebpage.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
    public class Module
    {
        public int Id { get; set; }                // Unique identifier for the module
        public string Code { get; set; }          // Module code, e.g., "PROG6212"
        public string Name { get; set; }          // Module name, e.g., "Programming 2B"
        public int Credits { get; set; }          // Number of credits for the module
        public int ClassHoursPerWeek { get; set; } // Weekly class hours
    }
    
}

