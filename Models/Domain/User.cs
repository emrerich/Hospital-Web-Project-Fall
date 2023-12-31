using System.ComponentModel.DataAnnotations;

namespace Hospital_Web_Project_Fall.Models.Domain
{
    public class User
    {
        public Guid UserID { get; set; }

        [Required]
        public string Ad { get; set; }
        [Required]
        public string Soyad { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Sifre { get; set; }
        public string? Telefon { get; set; }
        [Display(Name = "Rol Adı")]
        public string? RolAdi { get; set; }
        public Role? Rol { get; set; }

        public List<Appointment>?    Randevular { get; set; }
    }
}
