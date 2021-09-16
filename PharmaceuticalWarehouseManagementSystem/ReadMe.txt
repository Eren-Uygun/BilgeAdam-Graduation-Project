PharmaceuticalWarehouseManagementSystem

Proje .Net Core Mvc plaformunda yazılmıştır.Projemde mümkün olduğu kadar N-Tier Architecture'a uyulmaya çalışılmıştır.Repository Pattern, Dependency Injection gibi yapılar kullanılmaya çalışılmıştır.Orm aracı olarak EntityFrameworkCore kullanılmıştır.Proje başlangıcında dataseed mevcuttur yani proje çalıştırıldığında veri tabanında kayıt mevcut değil ise user ve admin rollerinde 2 ayrı kullanıcı oluşturulur.

Projeyi Çalıştırmak için,

1-PharmaceuticalWarehouseManagementSystem.UI bölümünde appsettings.json dosyası açılır ve ConnectionStrings'deki veri tabanı ve giriş bilgileri düzenlenir.
2-Update-Database yapılır.
3-Proje çalıştırıldığında dataseed işlemi yapıldığı için Email:admin@mail.com Password:123 Role:Admin / Email:User@mail.com Password:123 Role:User giriş bilgileri ile giriş yapılabilir.


