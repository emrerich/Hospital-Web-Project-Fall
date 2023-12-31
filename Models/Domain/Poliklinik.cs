using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Hospital_Web_Project_Fall.Models.Domain
{
    public class Poliklinik
    {
        public Guid PoliklinikID { get; set; }
        public string Ad { get; set; }
        public int SiraNo { get; set; }
        public AnaBilimDali? AnaBilimDali { get; set; }

        public List<Doktor>? Doktorlar { get; set; }
        public int? AnaBilimDaliID { get; internal set; }
    }
}