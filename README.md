# Online Grocery Store  

## Veritabanı
Bu projede fotoğraftaki gibi bir veri tabanı tasarımı yapılmıştır. Veri tabanı smarterasp.net adresinde host edilmektedir.

![Veritabanı Diyagramı](image.jpg)

<br>

## Entities Class Library

Bu kütüphanede veri tabanındaki her bir tabloya karşılık gelecek şekilde veri tutan sınıflarımızı (Entity) oluşturduk. Her sınıf veri tabanındaki ilgili tabloda bir satıra denk gelecek şekilde oluşturuldu. User sınıfı admin ve customer tipi kullanıcıların ortak özelliklerini barındırıyor.

<br>

## Veri Erişim Katmanı (Data Access Layer)

Bu katmanda her bir Entity için veri tabanına yazma, okuma, güncelleme ve silme (CRUD) işlemleri yazılmıştır. İhtiyaca göre gerek ilgili entity nin id sine göre gerek başka herhangi bir özelliğine göre veri tabanından kayıt getirme, tablodaki belirli bir kaydın özelliklerini id sine göre güncelleme, yine id sine göre kayıt silme ya da tabloya verilen entity nin özellikleri aracılığıyla yeni bir kayıt gönderme işlemlerinin hepsini barındırmaktadır. Bu işlemler ADO.NET kullanılarak SQL komutları aracılığıyla yapılmaktadır.

Her bir veri erişim sınıfının bir de Interface i bulunmaktadır. Bu interface ler sayesinde yeni bir soyutlama katmanı eklenerek projenin buradaki veri erişim sınıflarına olan bağımlılığını azaltmak hedeflenmiştir(Loosely Coupled). Örneğin ilerleyen zamanlarda ADO.NET yerine Entity Framework kullanarak verilere erişmek istendiğinde bu teknoloji kolaylıkla entegre edilebilir.

<br>

## İş Katmanı (Business Layer)
Bu katmanda tüm mantık kodları bulunmaktadır. Örneğin veri tabanına eklenmek istenen bir ürün eklenmeden önce fiyatının 0 dan yüksek olması kontrolü, veri tabanından çekilen bir ürünün ise fotoğraf dosya ismi boş (null) olması halinde yerine varsayılan bir fotoğraf isminin verilmesi gibi işlemler burada yapılmaktadır. 

Buradaki sınıflar gerekli entity ismi ve manager eki ile isimlendirilmiştir. (ProductManager, CustomerManager vb.) Her sınıf singleton tasarım desenine uygun olarak tasarlanmıştır. Çünkü buradaki sınıflar kendi içerisinde veri barındırmıyor ve kullanıcı ara yüzü katmanındaki birçok sınıf tarafından kullanılıyor. Her nesne için belirli bir işi yerine getirdiği ve bu iş her kullanıcı için aynı olduğundan singleton tasarım deseni buradaki sınıflar için uygun görülmüştür.

Bu katmandaki sınıflar veri tabanıyla iletişimi veri erişim sınıfları aracılığıyla sağlarlar. Her MANAGERa gerekli DAL sınıfı constructor injection yöntemiyle verilmiştir.  Veri erişim sınıflarını yalnızca bu katmandaki sınıflar kullanır başka hiçbir sınıfın doğrudan veri tabanına erişimi yoktur. Böylelikle iş katmanındaki kontroller yapılmadan veri tabanında değişiklik yapılmasının önüne geçilmiştir.

<br>

## Utilities Katmanı
Bu katmanda Results ve Validation olmak üzere 2 kısım bulunmaktadır. 

Results klasörünün altında temelde Result ve DataResult isminde 2 tane sınıf oluşturulmuştur. Result sınıfıyla bir fonksiyondan hem istenen işlemin başarılı olup olmadığı (boolean) bilgisi hem de başarısız olmuşsa nedenini (string) bir mesaj olarak döndürmek amaçlanmıştır. DataResult sınıfıyla ise bu bilgilerin yanında fonksiyonun bir de veri döndürmesi gerekiyorsa bu veriyi de jenerik bir şekilde döndürebilmesi amaçlanmıştır. 

Validation klasörünün altında ise ara yüzden girilen bilgilerin istenen formata uygun olup olmadığı kontrol edilmektedir. Örneğin e-posta alanı boş bırakılmış mı ve girilen bilgi doğru bir e-posta adresi mi gibi kontroller yapılarak veri bütünlüğünün korunması amaçlanmıştır. Bu sınıfta ihtiyaca göre bazen customer gibi bütün bir entity i doğrularken bazen de yalnızca e-posta ve şifre alanları doğrulaması yapılmaktadır. Buradaki Validation sınıfı ve metotları statik olarak oluşturulmuştur. Çünkü hemen hemen her katmanda sıklıkla kullanılmaktadırlar.

<br>

## Kullanıcı Arayüzü Katmanı (DashboardUI)
Bu katman Login, Register, AdminPanel Dashboard olmak üzere 4 adet formdan ve ProductDesign, ShoppingCartItemDesign ve OvalPictureBox olmak üzere 3 adet de UserControl den oluşmaktadır. 

### Login Formu
Bu formda kullanıcıdan e-posta adresi ve şifre istenmektedir. Eğer “Login” butonuna basılırsa CustomerManager sınıfı aracılığıyla müşteriler tablosuna bakılarak girilen bilgilerin doğruluğu kontrol edilir. Bilgilerde hata varsa ya da boş bırakılmış bir alan varsa butonların altındaki bir label aracılığıyla kullanıcı yönlendirilir. Eğer “Login as Admin” butonuna basılırsa AdminManager sınıfı aracılığıyla adminlerin bulunduğu tabloya bakılarak girilen bilgilerin doğruluğu kontrol edilir. 
Giriş başarılı olduğu takdirde “currentUser” ismiyle statik bir alan oluşturulur ve daha sonra bu kullanıcıyla ilgili gerekli bilgiler diğer sınıflardan erişilmek istendiğinde bu alan kullanılır. Ardından kullanıcı, eğer müşteri girişi yapılmışsa Dashboard formuna admin girişi yapmışsa AdminPanel formuna yönlendirilir. 

Login formunun alt kısmında ise “Do you have an account?” yazan bir buton vardır ve bu buton kullanıcıyı kayıt olma ekranına yönlendirir.

### Register Formu
Bu ekranda kullanıcıdan isim soy isim, e-posta adresi, telefon numarası, şifre, şifre onay ve adres bilgilerinin tümünü girmesi beklenir. Daha sonra Validation sınıfının ValidateCustomer metodu kullanılarak zorunlu alanların tamamının doldurulması ve girilen alanların beklenen formata uygunluğu kontrol edilir. Örneğin e-posta adresi doğru bir adres mi, telefon numarası sayılardan oluşuyor mu, şifre ve şifre onay alanları birbiriyle uyuşuyor mu gibi kontroller yapıldıktan sonra CustomerManager sınıfı aracılığıyla veri tabanında yeni bir müşteri kaydı oluşturulur.

### AdminPanel Formu
Bu forma yalnızca adminler erişebiliyor ve dolayısıyla sisteme yeni ürün ekleme, sistemden ürün silme veya sistemde bulunan bir ürünün bilgilerini güncelleme gibi işlemler için yalnızca admin tipindeki kullanıcılar yetkili oluyor.

AdminPanel sınıfında ProductManager isimli sınıf kullanılarak ürünler tablosuna erişim sağlanmaktadır. Veri tabanında ürünler tablosuyla müşterilerin sepet bilgilerinin tutulduğu shoppingCarts isimli tablolar arasında ürün id leri üzerinden bir ilişki kurulmuştur. Bu ilişki sayesinde admin panelinden güncellenen bir ürün bilgileri aynı zamanda müşterilerin sepetinde de güncellenmiş oluyor. İki tablo arasındaki ilişkide delete cascade isimli özellik açılarak da ürünler tablosundan kaldırılan bir ürünün aynı zamanda müşterilerin sepetinden de silinmesi sağlanmıştır.

Güncellenen ya da yeni eklenen bir ürünün fotoğrafı eklenmemişse ProductManager sınıfı tarafından kontrol edilir ve varsayılan olarak “null.png” atanır. Veri tabanında yalnızca fotoğrafların dosya adı ve uzantısı tutulur. Görüntülenmek istendiğinde ise projenin içindeki DashboardUI\bin\Debug\Data klasöründen çekilir. Aynı isimde bir dosya bulunamazsa varsayılan değer atanır. Yeni fotoğraf ekleme işleminde OpenFileDialog kullanılarak bir dosya seçilmesi beklenir. Seçilen dosya projenin içindeki Data dosyasına kopyalanır ve dosya ismi de veri tabanına kaydedilir.

### Dashboard Formu
Bu formun sağ üst köşesinde Login sınıfından gelen statik “currentUser” değişkeninin bilgileri kullanılarak giriş yapmış kullanıcının ismi ve profil fotoğrafı gösterilir. Profil resmi projedeki Data klasörünün path bilgisi ve “currentUser” da tutulan dosya ismi aracılığıyla pictureBox a atanır.

Bu sınıfın constructorında ProductManager kullanılarak tüm ürünlerin bilgileri veri tabanından çekilir ve bir ürünler listesinde tutulur. Ürünler sekmesine her tıklandığında bu listedeki bilgiler veri tabanından çekilerek güncellenir. Ürünler sekmesine tıklandığında yeni bir flowLayoutPanel oluşturulur. Listede tutulan ürünler tek bir ürünün ismini, açıklamasını, fotoğrafını ve fiyatını tutmak için tasarlanan ProductDesign isimli user controller kullanılarak flowLayoutPanel e aktarılır. Böylelikle tüm ürünler detaylarıyla birlikte listelenmiş olur. 

Sepete eklenmek istenen ürünün sepete ekleme butonuna basılınca o ürünün bilgileri etkileşime girilen ProductDesign dan alınarak giriş yapmış kullanıcının sepetine eklenir. Sepet simgesinin üzerinde bulunan label sepette kaç ürün bulunduğunu gösterir ve her ürün eklendiğinde dinamik olarak artırılarak kullanıcıya geri dönüş sağlanmış olur.

Sepet sekmesine tıklandığında giriş yapmış kullanıcının sepetinde bulunan ürünler veri tabanındaki ShoppingCarts tablosundan çekilir. Her bir sepet satırı hangi üründen kaç tane alındığı ve ürünün fıyatı bilgilerini barındıran ShoppingCart sınıfı yardımıyla tutulur. Veri tabanından çekilen ShoppingCart listesinde her bir eleman için ShoppingCartItemDesign isimli User Control oluşturularak panelde görüntülenmesi sağlanır. ShoppingCartItemDesign içinde ürün miktarını artırma azaltma ve sepet satırını tamamen silme butonlarını vardır ve dinamik olarak toplam fiyatı hesaplar. Sepet satırı tamamen silindiğinde ShoppingCartManager sınıfı vasıtasıyla giriş yapmış müşterinin o ürünü veri tabanından silinir. Sepetteki üründe miktar güncellemesi yapıldığında önce değişiklikler ara yüze yansır ve miktar değiştirildiğinde ilgili satırda bir tik butonu oluşur. Tik butonuna basılarak yapılan değişiklik onaylandığında güncelleme veri tabanına aktarılır. Aynı zamanda sepetin üzerinde bulunan labelda görüntülenir. Böylelikle veri tabanıyla daha az bağlantı kurularak uygulamanın performansı artırılmıştır.  

Kullanıcı ayarları sekmesinde tıklandığında ise kullanıcının tüm bilgileri karşımıza çıkar. Değiştirilmek istenen alanın yanında bulunan kalem ikonuna sahip butona basıldığında ilgili textbox aktifleşir ve bilgileri güncellemeyi mümkün kılar. Aynı şekilde fotoğraf değiştirme butonuna basıldığında kullanıcıdan yeni bir fotoğraf seçmesi beklenir. Seçilen fotoğraf Data klasörüne kopyalanır ve kullanıcının profil resmi ilgili picturebox larda güncellenir. Kullanıcının resmi aynı ürünlerin resmini tutmada olduğu gibi yalnızca yüklenen fotoğrafın dosya ismiyle tutulur ve görüntülenmek istendiğinde Data klasöründen çekilir. Böylelikle her bilgisayarda resimlerin görüntülenebilmesi sağlanır. Değişiklikleri kaydet butonu bu ekranda değiştirilen her alanı veri tabanına kaydeder.

Bu alanda bir de şifre değiştirme butonu vardır ve basıldığında bir groupBox açılır. Kullanıcının halihazırda kullandığı şifre sorulur ve doğru girildiği takdirde yeni şifre de kurallara uyuyorsa şifre değiştirilir. groupBox ın içinde bir label vasıtasıyla kullanıcı bilgilendirilir. Şifrenin doğruluğu CustomerManager sınıfıyla veri tabanına bakılarak kontrol edilir. Yeni girilen şifrenin doğrulaması da Validation sınıfı kullanılarak yapılır.

Logout butonuna basıldığında ise tekrar Login formu açılır. 
