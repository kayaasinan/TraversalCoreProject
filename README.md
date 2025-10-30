# 🧭 TraversalCoreProject (.NET 9.0)

### 🌍 Modern Seyahat & Tur Rezervasyon Sistemi

TraversalCoreProject, kullanıcıların destinasyonları keşfedip rezervasyon oluşturabildiği; yöneticilerin ve rehberlerin içerik ile rezervasyon yönetimi yapabildiği, **Repository Design Pattern** ve **MediatR destekli CQRS yaklaşımı**yla zenginleştirilmiş, **ASP.NET Core 9.0** tabanlı bir web uygulamasıdır.

---

## 📌 Proje Hakkında

Bu proje, çok katmanlı bir mimariyle geliştirilen bir **seyahat & rezervasyon yönetim sistemi**dir.  
Uygulama; **SQL Server** tabanlı genel veri yönetimi ve **PostgreSQL** tabanlı gerçek zamanlı **ziyaretçi istatistikleri** sağlar.

CRUD işlemleri temel olarak **Repository Pattern** ile yürütülürken, bazı karmaşık sayfalarda **MediatR (CQRS)** deseniyle komut/sorgu ayrımı uygulanmıştır.  
Bu sayede hem performans hem de okunabilirlik açısından sade bir yapı elde edilmiştir.

---

## 🚀 Kullanılan Teknolojiler

| Katman | Teknoloji |
|--------|------------|
| 🧩 Backend | ASP.NET Core MVC (.NET 9.0) |
| 🗄️ ORM | Entity Framework Core (Code First) |
| 🧠 Mimari | Repository Pattern + CQRS (MediatR destekli) |
| 🧾 Doğrulama | FluentValidation & DataAnnotations |
| 🔄 Dönüşüm | AutoMapper (Profiles ile mapping) |
| 🧰 Veritabanı | SQL Server (Ana DB) + PostgreSQL (Ziyaretçi Grafikleri) |
| 📊 Gerçek Zamanlı | SignalR (Visitor Hub) |
| 💬 E-posta | MailKit & MimeKit |
| 🧾 Raporlama | EPPlus (Excel) & iTextSharp (PDF) |
| 🎨 Arayüz | Bootstrap 5, FontAwesome, jQuery, SweetAlert |

---
  
## 🌍 Başlıca Modüller

| Modül | Açıklama |
|-------|-----------|
| 🧭 **Destinasyon Modülü** | • Admin tarafından destinasyon **ekleme**, **düzenleme**, **silme** işlemleri <br> • Kullanıcı tarafında **detay sayfaları** ve **rezervasyon yönlendirmesi** |
| 🧳 **Rezervasyon Modülü** | • Üye yeni rezervasyon oluşturabilir <br> • Admin ve Rehber rezervasyon durumlarını yönetebilir <br> • **MediatR** destekli listeleme ve işlem akışı |
| 📈 **Ziyaretçi İstatistikleri** *(SignalR + PostgreSQL)* | • Gerçek zamanlı **şehir bazlı ziyaretçi grafikleri** <br> • **PostgreSQL** üzerinde kayıtlanan veriler **SignalR Hub** ile canlı olarak çekilir |
| 📬 **E-Posta Modülü** | • Şifre sıfırlama, hesap onayı ve bilgilendirme e-postaları <br> • **MailKit** & **MimeKit** altyapısı |
| 🧾 **Raporlama** | • **Excel (EPPlus)** ve **PDF (iTextSharp)** çıktı alma özellikleri <br> • Yönetici panelinden dinamik rapor oluşturma |
| 🔧 **Kullanıcı & Rol Yönetimi** | • Admin, Rehber ve Üye rollerine göre yetkilendirme <br> • ASP.NET Core Identity ile kimlik doğrulama ve kullanıcı yönetimi |
| 🔍 **Arama & Filtreleme Modülü** | • Tur ve destinasyon listelerinde gelişmiş filtreleme ve arama <br> • Repository Pattern ile soyutlanmış CRUD yapısı |
| 🌐 **Çoklu Dil & Kültür Desteği** | • **TR, EN, RU, FR, ES** olmak üzere 5 farklı dil seçeneği <br> • ViewLocalization ve Culture middleware entegrasyonu |
| ⚠️ **Hata Yönetimi (Middleware)** | • Özel hata sayfaları middleware aracılığıyla yönetilir <br> • 404 gibi durumlarda özel arayüz yönlendirmeleri |

## 📷 Ekran Görüntüleri
---
##  Ana Sayfa
**📌 Ana Sayfa** 

![HomePage](https://github.com/kayaasinan/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/imagesReadMe/HomePage/HomePage1.png?raw=true) 

**📌 Rotalar** 

![Destination](https://github.com/kayaasinan/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/imagesReadMe/HomePage/HomePage2.png?raw=true) 

![Destination](https://github.com/kayaasinan/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/imagesReadMe/HomePage/HomePage4.png?raw=true) 

**📌 Öne Çıkanlar** 

![Banner](https://github.com/kayaasinan/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/imagesReadMe/HomePage/HomePage3.png?raw=true) 

**📌 Rehberler** 

![Guide](https://github.com/kayaasinan/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/imagesReadMe/HomePage/HomePage5.png?raw=true) 

**📌 Referanslar** 

![Testimonial](https://github.com/kayaasinan/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/imagesReadMe/HomePage/HomePage6.png?raw=true) 

**📌 Bize Ulaşın** 

![ContactUs](https://github.com/kayaasinan/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/imagesReadMe/HomePage/HomePage7.png?raw=true) 

##  Üye Paneli

**📌 Üye Ol** 

![Register](https://github.com/kayaasinan/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/imagesReadMe/Member/register1.png?raw=true) 

**📌 Giriş Yap** 

![Login](https://github.com/kayaasinan/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/imagesReadMe/Member/memberLogin.png?raw=true) 

**📌 Dashboard** 

![Dashboard](https://github.com/kayaasinan/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/imagesReadMe/Member/memberDashboard1.png?raw=true) 

![Dashboard](https://github.com/kayaasinan/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/imagesReadMe/Member/memberDashboard2.png?raw=true) 

**📌 Aktif Turlar Rotaları** 

![AllDestination](https://github.com/kayaasinan/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/imagesReadMe/Member/allDestination.png?raw=true) 

**📌 Son Eklenen Turlar** 

![LastDestination](https://github.com/kayaasinan/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/imagesReadMe/Member/lastDestination.png?raw=true) 

**📌 Profil Düzenleme Sayfası** 

![Profile](https://github.com/kayaasinan/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/imagesReadMe/Member/profile1.png?raw=true) 

![Profile](https://github.com/kayaasinan/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/imagesReadMe/Member/profile2.png?raw=true) 

*📌🏠 Onaylanan Rezervasyonlar** 

![Accepted](https://github.com/kayaasinan/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/imagesReadMe/Member/accepted.png?raw=true) 

**📌 Geçmiş Rezervasyonlar** 

![Past](https://github.com/kayaasinan/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/imagesReadMe/Member/past.png?raw=true) 

**📌 Onay Bekleyen Rezervasyonlar** 

![Register](https://github.com/kayaasinan/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/imagesReadMe/Member/approvel.png?raw=true) 

**📌 Dil Seçenekleri** 

![Language](https://github.com/kayaasinan/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/imagesReadMe/Member/russianLanguage.png?raw=true) 

**📌 Şifremi Yenileme Linki** 

![ForgetPassword](https://github.com/kayaasinan/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/imagesReadMe/Member/forgetPasswordAdmin.png?raw=true) 

##  Admin Paneli

**📌 Dashboard** 

![Register](https://github.com/kayaasinan/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/imagesReadMe/Admin/adminDashboard.png?raw=true) 
![Register](https://github.com/kayaasinan/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/imagesReadMe/Admin/adminDashboard1.png?raw=true) 

**📌 Rotalar** 

![Destinations](https://github.com/kayaasinan/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/imagesReadMe/Admin/cqrs.png?raw=true) 

**📌 Rezervasyonlar** 

![Reservations](https://github.com/kayaasinan/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/imagesReadMe/Admin/reservation.png?raw=true) 

**📌 Rehberler** 

![Guides](https://github.com/kayaasinan/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/imagesReadMe/Admin/guides.png?raw=true) 

**📌 Referanslar** 

![Testimonial](https://github.com/kayaasinan/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/imagesReadMe/Admin/testimonial.png?raw=true) 

**📌 Yorumlar** 

![Comments](https://github.com/kayaasinan/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/imagesReadMe/Admin/comments.png?raw=true) 

**📌 Mesaj Gönderme Sayfası** 

![SendMessage](https://github.com/kayaasinan/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/imagesReadMe/Admin/sendMail.png?raw=true) 

**📌 Öne Çıkanlar** 

![Banner](https://github.com/kayaasinan/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/imagesReadMe/Admin/banner.png?raw=true) 

**📌 Üyeler** 

![Members](https://github.com/kayaasinan/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/imagesReadMe/Admin/memberList.png?raw=true) 

**📌 Admine Gelen Mesajlar** 

![Messages](https://github.com/kayaasinan/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/imagesReadMe/Admin/messages.png?raw=true) 

**📌 Rol Atama** 

![Role](https://github.com/kayaasinan/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/imagesReadMe/Admin/assignrole.png?raw=true) 

**📌 Rapor Oluşturma Sayfaları** 

![Report](https://github.com/kayaasinan/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/imagesReadMe/Admin/pdfreport.png?raw=true) 

![Report](https://github.com/kayaasinan/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/imagesReadMe/Admin/excelReport%20(2).png?raw=true) 

![Report](https://github.com/kayaasinan/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/imagesReadMe/Admin/excelReport.png?raw=true) 

**📌 Booking Üzerinden Rapid APİ ile Paris Konumu İçin Anlık Rezervasyon Kontrolü ve Fiyat Bilgisi** 

![Bookings](https://github.com/kayaasinan/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/imagesReadMe/Admin/bookingList.png?raw=true) 

**📌 Rapid Api ile Anlık Döviz Bilgileri** 

![Exchange](https://github.com/kayaasinan/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/imagesReadMe/Admin/exchange.png?raw=true) 

**📌 Üyeler İçin IMDB Top l00 Film Listesi Önerisi-Rapid Api** 

![IMDB](https://github.com/kayaasinan/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/imagesReadMe/Admin/imdb.png?raw=true) 

**📌 Sweet Alert ile Uyarılar** 

![Alert](https://github.com/kayaasinan/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/imagesReadMe/Admin/alert.png?raw=true) 









