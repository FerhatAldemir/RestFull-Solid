Kullanılan Teknolojiler
<br/>
Net Core 6
<br/>
Ef Core 6

Proje 4 Katmandan Oluşmaktadır
<br/>
Bussines Layer => İşlerin Yapıldığı Katman
<br/>
DataAcceslayer => RepoStorylerin bulunduğu katman
<br/>
Core => Genel Tipler(araç tipleri,renk tipleri,far durum tipleri) ve Base Arayüzler çekirdek katmanında bulunmaktadır 
<br/>
EntityLayer => Veritabanı Satır Modelleri bu katmanda Tutulmaktadır

<br/>
Kullanılan Desenler
<br/>
Factory Desing Patern
<br/>
IvehicleFactory<T> türünden araba,tekne,otobüs gibi araç sınıflarını oluşturduk
<br/>
İşlem Yapılan Providere Ulaşdık
<br/>
code first 
<br/>
ef code first desnine göre önce kod yazılıp daha sonra data oluşturuldu
<br/>
Lütfen Projeyi Çalıştırmadan Önce appsetting.json dosyasındaki ConnectionStrings.Defaultconnection tag değerini mssql server bilgilerinizi giriniz
