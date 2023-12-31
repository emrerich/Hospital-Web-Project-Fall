using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Hospital_Web_Project_Fall.Models.Domain
{
    public class Appointment
    {
        public Guid AppointmentID { get; set; }
        public User? Hasta { get; set; }

        public Doktor? Doktor { get; set; }

        public DateTime Tarih { get; set; }
        public string? Saat { get; set; }
    }
}