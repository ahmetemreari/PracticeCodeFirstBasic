# PracticeCodeFirstBasic

Bu proje, Entity Framework Core kullanarak temel CRUD işlemlerini gerçekleştiren basit bir ASP.NET Core Web API uygulamasıdır. Proje, oyunlar ve filmler için veri modelleri ve ilgili API denetleyicilerini içerir.

## Kurulum

1. Bu projeyi yerel makinenize klonlayın:
    ```sh
    git clone https://github.com/kullaniciadi/PracticeCodeFirstBasic.git
    cd PracticeCodeFirstBasic
    ```

2. Gerekli bağımlılıkları yükleyin:
    ```sh
    dotnet restore
    ```

3. Veritabanı bağlantı dizesini `appsettings.json` dosyasında yapılandırın.

4. Veritabanı migrasyonlarını uygulayın:
    ```sh
    dotnet ef database update
    ```

## Çalıştırma

Projeyi aşağıdaki komutla çalıştırabilirsiniz:
```sh
dotnet run
```

## API Kullanımı

### Oyunlar

- **GET** `/api/Games` - Tüm oyunları getirir.
- **GET** `/api/Games/{id}` - Belirli bir oyunu getirir.
- **POST** `/api/Games` - Yeni bir oyun ekler.
- **PUT** `/api/Games/{id}` - Belirli bir oyunu günceller.
- **DELETE** `/api/Games/{id}` - Belirli bir oyunu siler.

### Filmler

- **GET** `/api/Movie` - Tüm filmleri getirir.
- **GET** `/api/Movie/{id}` - Belirli bir filmi getirir.
- **POST** `/api/Movie` - Yeni bir film ekler.
- **PUT** `/api/Movie/{id}` - Belirli bir filmi günceller.
- **DELETE** `/api/Movie/{id}` - Belirli bir filmi siler.

## Modeller

### GameDto

```csharp
namespace EmrePracticeDbOne.Models
{
    public class GameDto
    {
        public string Name { get; set; }
        public string Platform { get; set; }
        public decimal Rating { get; set; }
    }
}
```

### MovieDto

```csharp
namespace EmrePracticeDbOne.Models
{
    public class MovieDto
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
    }
}
```

## Katkıda Bulunma

Katkıda bulunmak isterseniz, lütfen bir pull request gönderin veya bir issue açın.

## Lisans

Bu proje MIT Lisansı ile lisanslanmıştır.
```
