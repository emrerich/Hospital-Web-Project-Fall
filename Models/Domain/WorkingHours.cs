using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Hospital_Web_Project_Fall.Models.Domain
{
    public class WorkingHours
    {
        public Guid WorkingHoursID { get; set; }

        public Doktor? Doktor { get; set; }

        public string Gun { get; set; }
        public string BaslangicSaat { get; set; }
        public string BitisSaat { get; set; }
    }
}