using System.ComponentModel.DataAnnotations;

namespace Hospital_Web_Project_Fall.Models.Domain
{
    public class AnaBilimDali
    {
        [Key]
        public int AnaBilimDaliID { get; set; }
        public string Ad { get; set; }

        public List<Poliklinik>? Poliklinikler { get; set; }
    }
}
