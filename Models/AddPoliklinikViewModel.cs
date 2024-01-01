using Hospital_Web_Project_Fall.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace Hospital_Web_Project_Fall.Models
{
    public class AddPoliklinikViewModel
    {
        public string PoliklinikAd { get; set; }
        public int SelectedAnaBilimDaliID { get; set; }

        public int SiraNo { get; set; }
        public List<AnaBilimDali> AnaBilimDallari { get; set; }
        public List<AnaBilimDali> BirdenFazlaPoliklinikIcerenDallar { get; set; }
    }
}
