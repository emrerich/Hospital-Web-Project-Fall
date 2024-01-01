Hastane Randevu Sistemi - Proje Tanıtımı

GitHub Deposu:
https://github.com/emrerich/Hospital-Web-Project-Fall

Proje Adı
Hastane Randevu Sistemi
Teknolojiler
•	ASP.NET Core 6 MVC: Projede kullanılan temel web uygulaması çatısı.
•	C#: Ana programlama dili.
•	SQL Server: Veritabanı yönetim sistemi.
•	Entity Framework Core ORM: Veritabanı işlemleri için kullanılan ORM aracı.
•	Bootstrap Tema: Kullanıcı arayüzü tasarımında kullanılan CSS ve JavaScript kütüphanesi.
•	HTML5, CSS3, JavaScript ve jQuery: Web sayfası tasarım ve etkileşim öğeleri.
Proje Açıklaması
Hastane Randevu Sistemi, hastaların internet üzerinden randevu alabilmelerini sağlayan bir web uygulamasını içermektedir. Projede ana bilim dalı, poliklinik, doktor gibi temel tanımlamalar bulunmaktadır. Kullanıcılar, uygun klinik ve doktor seçimleri ile randevularını kolayca alabilmektedirler.
Veritabanı Modeli
---------------------------------
|               User              |
---------------------------------
| UserID (PK)        | Guid       |
| Ad                 | nvarchar   |
| Soyad              | nvarchar   |
| Email              | nvarchar   |
| Sifre              | nvarchar   |
| Telefon            | nvarchar   |
| RolID (FK)         | Guid       |
---------------------------------

---------------------------------
|               Role              |
---------------------------------
| RolID (PK)         | Guid       |
| RolAdi             | nvarchar   |
---------------------------------






---------------------------------
|           Poliklinik            |
---------------------------------
| PoliklinikID (PK)  | Guid       |
| Ad                 | nvarchar   |
| AnaBilimDaliID (FK)| int        |
| SiraNo             | int        |
---------------------------------

---------------------------------
|           AnaBilimDali          |
---------------------------------
| AnaBilimDaliID (PK)| int        |
| Ad                 | nvarchar   |
---------------------------------

---------------------------------
|              Doktor             |
---------------------------------
| DoktorID (PK)      | Guid       |
| DoktorAdi          | nvarchar   |
| DoktorSoyadi       | nvarchar   |
| DoktorMail         | nvarchar   |
| DoktorSifre        | nvarchar   |
| DoktorTelefon      | nvarchar   |
| DoktorUnvan        | nvarchar   |
| PoliklinikID (FK)  | Guid       |
| RolID (FK)         | Guid       |
---------------------------------

---------------------------------
|           WorkingHours          |
---------------------------------
| WorkingHoursID (PK)| Guid       |
| BaslangicSaat       | nvarchar   |
| BitisSaat           | nvarchar   |
| Gun                 | nvarchar   |
| DoktorID (FK)       | Guid       |
---------------------------------

---------------------------------
|           Appointment           |
---------------------------------
| AppointmentID (PK) | Guid       |
| Tarih               | datetime2  |
| Saat                | nvarchar   |
| DoktorID (FK)      | Guid       |
| HastaUserID (FK)   | Guid       |
---------------------------------

---------------------------------
|              User               |
---------------------------------
| UserID (PK)        | Guid       |
| Ad                 | nvarchar   |
| Soyad              | nvarchar   |
| Email              | nvarchar   |
| Sifre              | nvarchar   |
| Telefon            | nvarchar   |
| RolID (FK)         | Guid       |





•	User ve Role tabloları arasında many-to-one ilişki vardır. Her kullanıcı bir rolle ilişkilidir, ancak aynı rol birden çok kullanıcıya sahip olabilir.
•	Poliklinik ve AnaBilimDali tabloları arasında one-to-many ilişki bulunmaktadır. Her ana bilim dalı birden çok poliklinik içerebilir, ancak bir poliklinik yalnızca bir ana bilim dalına aittir.
•	Doktor, Poliklinik, ve Role tabloları arasında da many-to-one ilişkiler vardır. Her doktor bir poliklinik ve bir rolle bağlıdır, ancak aynı poliklinik veya rol birden çok doktora sahip olabilir.
•	WorkingHours ve Doktor tabloları arasında one-to-many ilişki bulunmaktadır. Her doktorun birden çok çalışma saati olabilir, ancak bir çalışma saati yalnızca bir doktora aittir.
•	Appointment, Doktor, ve User tabloları arasında many-to-one ilişkiler vardır. Her randevu bir doktora ve bir hastaya aittir, ancak aynı doktor veya hasta birden çok randevuya sahip olabilir.
