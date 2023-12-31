namespace Hospital_Web_Project_Fall.Models.Doktor
{
    public class UpdateDoktorViewModel
    {
        public Guid DoktorId { get; set; }
        public string? DoktorAdi { get; set; }
        public string? DoktorSoyadi { get; set; }
        public string? DoktorBrans { get; set; }
        public string? DoktorTelefon { get; set; }
        public string? DoktorMail { get; set; }
        public string? DoktorSifre { get; set; }
        public string? DoktorUnvan { get; set; }
    }
}
