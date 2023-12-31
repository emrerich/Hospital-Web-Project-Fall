﻿namespace Hospital_Web_Project_Fall.Models.Domain
{
    public class Doktor
    {
        public Guid DoktorId { get; set; }
        public string? DoktorAdi { get; set; }
        public string? DoktorSoyadi { get; set; }
        public string? DoktorBrans { get; set; }
        public string? DoktorTelefon { get; set; }
        public string? DoktorMail { get; set; }
        public string? DoktorSifre { get; set; }
        public string? DoktorUnvan { get; set; }


        public Role? Rol { get; set; }

        public Poliklinik? Poliklinik { get; set; }

        public List<WorkingHours>? CalismaSaatleri { get; set; }
        public List<Appointment>? Randevular { get; set; }
    }
}
