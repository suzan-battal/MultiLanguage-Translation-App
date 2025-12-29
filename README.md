# Çoklu Dil Çeviri Uygulaması

Multi-Language Translation Application

Bu proje, **C# WinForms** ve **DevExpress** kullanarak geliştirilmiş basit bir çoklu dil çeviri uygulamasıdır. Sözlük tabanlı çeviri sistemi kullanır ve **temiz katmanlı OOP mimarisi** ile yapılandırılmıştır.

## 🌍 Desteklenen Diller

- English (İngilizce)
- Turkish (Türkçe)
- Arabic (Arapça)

## ✨ Özellikler

- Bir dilden diğerine metin çevirisi
- Kaynak ve hedef dil seçimi
- Sözlük tabanlı çeviri sistemi
- Kelime kelime cümle çevirisi
- Bilinmeyen kelimeleri olduğu gibi bırakma
- Tam ayrılmış mantık (Model → Service → UI)

## 🧩 Mimari Genel Bakış

Uygulama üç katmana ayrılmıştır:

1. **Model Katmanı** (Model Layer)
2. **Servis Katmanı** (Service Layer)
3. **UI Katmanı** (Presentation Layer)

### 1️⃣ Model Katmanı

**WordPair (Model)**

Üç dilde tek bir kelimeyi temsil eder:

```csharp
public class WordPair
{
    public string English { get; set; }
    public string Turkish { get; set; }
    public string Arabic  { get; set; }
}
```

Bu sınıf, dahili sözlükte bir giriş olarak kullanılır.

### 2️⃣ Servis Katmanı

Çeviri mantığı bu katmanda uygulanır. İki bileşen içerir:

**ITranslationService (Interface)**

Çeviri davranışını tanımlar:

```csharp
public interface ITranslationService
{
    string Translate(string input, string fromLang, string toLang);
}
```

**TranslationService (Implementation)**

Sözlük tabanlı çeviri uygular:

- Önceden tanımlanmış kelimeleri `WordPair` listesi olarak saklar
- Cümleleri kelimelere böler
- Her kelimeyi ayrı ayrı çevirir
- Sözlükte bulunamayan kelimeleri değiştirmeden bırakır
- Tamamen çevrilmiş cümleyi döndürür

**Çeviri Mantığı (Adım adım)**

1. Girdiyi doğrula
2. Metni tek tek kelimelere böl
3. Her kelime için:
   - Kaynak dile göre ara
   - Bulunursa → hedef dildeki eşdeğerini döndür
   - Bulunamazsa → kelimeyi olduğu gibi bırak
4. Çevrilmiş kelimeleri bir çıktı cümlesinde birleştir

### 3️⃣ UI Katmanı (Sunum)

**WinForms + DevExpress** kontrolleri kullanılarak oluşturulmuştur.

**UI Bileşenleri**

- `txtInput` — giriş metni
- `cmbFrom` — kaynak dil açılır menüsü
- `cmbTo` — hedef dil açılır menüsü
- `btnTranslate` — çeviriyi tetikler
- `txtOutput` — çevrilmiş cümleyi görüntüler

**Başlatma (Form1_Load)**

```csharp
cmbFrom.Items.AddRange(new[] { "English", "Turkish", "Arabic" });
cmbTo.Items.AddRange(new[] { "English", "Turkish", "Arabic" });

cmbFrom.SelectedIndex = 0; // English
cmbTo.SelectedIndex = 1;   // Turkish
```

**Buton Tıklama Olayı**

```csharp
private void btnTranslate_Click(object sender, EventArgs e)
{
    string input = txtInput.Text;
    string from  = cmbFrom.SelectedItem.ToString();
    string to    = cmbTo.SelectedItem.ToString();

    txtOutput.Text = _translationService.Translate(input, from, to);
}
```

UI herhangi bir iş mantığı içermez — basitçe `TranslationService` ile etkileşime girer.

## 🔧 Kullanılan Teknolojiler

- C#
- Windows Forms
- DevExpress
- OOP (Models, Services, Interfaces)

## 📁 Proje Yapısı

```
ntp/
├── Models/
│   └── WordPair.cs              # Model katmanı
├── Services/
│   ├── ITranslationService.cs   # Servis arayüzü
│   └── TranslationService.cs    # Servis implementasyonu
├── UI/
│   └── Form1.cs                 # UI katmanı (WinForms)
├── Program.cs                   # Giriş noktası (Console demo)
└── README.md                    # Bu dosya
```

## 🚀 Nasıl Çalıştırılır

### Console Demo
`Program.cs` dosyası bir console demo içerir. Çalıştırmak için:

```bash
dotnet run
```

veya Visual Studio'da F5 tuşuna basın.

### WinForms Uygulaması
DevExpress form tasarımcısını kullanarak `Form1` için bir UI tasarlayın ve aşağıdaki kontrolleri ekleyin:
- `txtInput` (TextBox veya MemoEdit)
- `cmbFrom` (ComboBox veya LookUpEdit)
- `cmbTo` (ComboBox veya LookUpEdit)
- `btnTranslate` (Button veya SimpleButton)
- `txtOutput` (TextBox veya MemoEdit)

## 🎯 Öğrenme Çıktıları

- Katmanlı mimariyi anlama
- Arayüzler ve servis sınıfları kullanma
- String işlemleri yönetme
- Çok dilli uygulama tasarlama
- UI ve mantık arasında temiz ayrım

## 📌 Notlar

- Sözlüğü sadece daha fazla `WordPair` girişi ekleyerek genişletebilirsiniz.
- Yeni diller, model ve servis mantığını genişleterek eklenebilir.
- Bilinmeyen kelimeler değişmeden kalır, bu da esneklik sağlar.

## 📝 Örnek Kullanım

```csharp
ITranslationService service = new TranslationService();

// İngilizce'den Türkçe'ye
string result1 = service.Translate("hello world", "English", "Turkish");
// Çıktı: "merhaba dünya"

// Türkçe'den Arapça'ya
string result2 = service.Translate("iyi öğretmen", "Turkish", "Arabic");
// Çıktı: "جيد muallim"
```
