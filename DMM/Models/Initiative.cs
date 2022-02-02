using System.ComponentModel.DataAnnotations;

namespace DMM.Models
{
    public class Initiative
    {
        public string Name { get; set; }
        public int Roll { get; set; }
        public int Status { get; set; }
        public bool IsCurrent { get; set; }

        public Initiative(string name, int roll, int status, bool isCurrent)
        {
            Name = name;
            Roll = roll;
            Status = status;
            IsCurrent = isCurrent;
        }
    }

    public class InitiativeFormModel
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        [Range(0, 99, ErrorMessage = "Accommodation invalid (0-99).")]
        public int Roll { get; set; }
    }
}
