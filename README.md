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




