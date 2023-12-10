Türkçe
<br/>
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

Solid prensiplere Dikkat Edilerek Yazılmaya Çalışılmıştır
<br />
Açıklamalar
<br />
1.Single Responsibility
<br/>
Her bir metoda Sadece bir iş verildi
<br/>
2.Open/Closed 
<br/>
metotların işlevselşiğini değiştirmeden Araç Türünün özelliklerine göre işlemler yaptırdık buda bize metodun değişime kapalı geliştirmeye açık bırakılma prensibini karşılaşmış oldu
<br/>
3.Liskov Substitution Prensibi
<br/>
Araç Türleri sınıflarında kullanılmayan metot bırakılmadı far açma ve kapatma ve Silme işlemi sadece Araba Türündeki araçlarda yapıldı
<br/>
4. Interface Segregation
<br/>
Araç Türlerinin İşlemlerine göre Interfaceleri parçaladık
<br/>
5.Dependency Inversion
<br/>
Araç Ekleme İşlemlerinde alt sınıf bağımlılığını ortadan kaldırdık


English

Used Technologies
<br/>
.Net Core 6
<br/>
Ef Core 6
<br/>
JWT

The Project Consists of 4 Layers
<br/>
Business Layer => Layer where logical operations are performed
<br/>
Data Access Layer => Layer where repositories are located
<br/>
Core => General types (tool types, color types, headlight status types) and Base Interfaces are in the core layer
<br/>
Entity Layer => Database Models are kept in this layer

<br/>
Used Patterns
<br/>
Factory Design Pattern
<br/>
We created vehicle classes such as car, boat, bus from the IvehicleFactory<T> type
<br/>
Accessed the Provider where operations are performed
<br/>
Code First
<br/>
According to the EF Code First design, code was written first and then data was generated
<br/>
Note: MSSQL Server settings are in the ConnectionStrings.DefaultConnection tag value in the appsettings.json file.
Written with Attention to Solid Principles
<br/>
Explanations
<br/>

Single Responsibility
<br/>
Only one task is given to each method
<br/>

Open/Closed
<br/>
We performed operations based on the characteristics of the Vehicle Type without changing the functionality of the methods, adhering to the principle of being closed to modification and open to extension.
<br/>

Liskov Substitution Principle
<br/>
Unused methods were not left in the vehicle type classes; turning on and off the headlights and deletion operations were only performed on vehicle types of the car.
<br/>

Interface Segregation
<br/>
We split the interfaces according to the operations of vehicle types.
<br/>

Dependency Inversion
<br/>
We eliminated the subclass dependency in vehicle addition operations.
