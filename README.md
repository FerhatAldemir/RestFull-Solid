Kullanılan Teknolojiler
Net Core 6
Ef Core 6

Proje 4 Katmandan Oluşmaktadır

Bussines Layer => İşlerin Yapıldığı Katman
DataAcceslayer => Veri Tabanı Bağlantılarının
Core => Genel Tipler ve Base Arayüzler çekirdek katmanında bulunmaktadır 
EntityLayer => Veritabanı Satır Modelleri bu katmanda Tutulmaktadır


Kullanılan Desenler
Abstract Factory Desing Patern
IvehicleFactory arayüznden sadece bir türde Araçlar Oluşturduk
Strateji Patern
İşlem Yapılan Providere Ulaşdık
code first 
ef code first desnine göre önce kod yazılıp daha sonra data oluşturuldu
<br/>
Lütfen Projeyi Çalıştırmadan Önce appsetting.json dosyasındaki ConnectionStrings.Defaultconnection elementinin değerini mssql server'inize ait bilgilerinizi giriniz
