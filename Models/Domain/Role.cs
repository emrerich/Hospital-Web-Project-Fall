using System.ComponentModel.DataAnnotations;

namespace Hospital_Web_Project_Fall.Models.Domain
{
    public class Role
    {
        [Key]
        public Guid RolID { get; set; }


        public string? RolAdi { get; set; }
        public List<User>? Kullanicilar { get; set; }

    }
}