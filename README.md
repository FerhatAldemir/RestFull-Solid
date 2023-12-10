Kullanılan Teknolojiler
<br/>
Net Core 6
<br/>
Ef Core 6
<br />
JWT

Proje 4 Katmandan Oluşmaktadır
<br/>
Bussines Layer => Mantıksal İşlemlerin Yapıldığı Katman
<br/>
DataAcceslayer => RepoStorylerin bulunduğu katman
<br/>
Core => Genel Tipler(araç tipleri,renk tipleri,far durum tipleri) ve Base Arayüzler çekirdek katmanında bulunmaktadır 
<br/>
EntityLayer => Veritabanı Modelleri bu katmanda Tutulmaktadır

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
Not : Mssql server ayarları appsetting.json dosyasındaki ConnectionStrings.Defaultconnection tag değerinde bulunmaktadır..
