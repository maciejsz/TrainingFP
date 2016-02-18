# Projekt treningowy do warsztatu z usług poziomu Platform as a Service na Microsoft Azure

## Instrukcja

### Zadanie 1 - uruchomienie aplikacji lokalnie

- Pobierz to repozytorium lokalnie. Polecenie git clone uri_do_repozytorium.
- Przełącz się na branch 01-start. Polecenie: git checkout 01-start
- Uruchom aplikację. Baza danych powinna stworzyć się automatycznie na lokalnej instancji SQL Server.

### Zadanie 2 - wdrożenie aplikacji na usługi Microsoft Azure

Część pierwsza

- Zaloguj się do portalu Azure [https://portal.azure.com](https://portal.azure.com)
- Stwórz dwie usługi: Azure Web App oraz Azure SQL Database.

Część druga

- Pobierz „publish profile” dla usługi Web App. Znajdziesz go na zakładce usługi (blade) w portalu „Get publish profile”
- Na zakładce stworzonej bazy danych znajdź jej „connection string” i uzupełnij o brakujące hasło.
- W Visual Studio użyj opcji „publish” w menu kontekstowym aplikacji webowej i opublikuj projekt wykorzystując przygotowane publish profile i connection string.


- Skonfiguruj Web App, aby korzystała ze stworzonej SQL Database (nadpisz connection string w ustawieniach Web App).


### Zadanie 3 - storage

- Załóż usługę Storage Account.
- Uzupełnij implantację klasy FilesStorageService, tak aby zapisywała ona pliki w Azure Storage i zwracała adres nowego bloba. Skozystaj z instrukcji w [dokumentacji](https://azure.microsoft.com/en-us/documentation/articles/storage-dotnet-how-to-use-blobs#_programmatically-access-blob-storage) - sekcja Programmatically access Blob storage.
- Po implementacji powinieneś móc dodać nowy wpis ze zdjęciem do dziennika projektu oraz wyświetlić to zdjęcie na liście wpisów.
- Zaimplementuj zmiany lokalnie, nie musisz publikować ich na Chmurę. 

Gotowe rozwiązanie można znaleźć na kolejnym branchu:

``` git 
git checkout 02-storage 

```

### Zadanie 4 - diagnostyka

- Wykorzystaj opcję "Add Application Insights Telemetry" w menu kontekstowym aplikacji webowej w Visual Studio, aby skonfigurować wysyłanie danych diagnostycznych do usługi Application Insights.
- Możesz wykorzystać instancję, która została stworzona automatycznie przy zakładaniu usługi Web App
- Uruchom stronę (lokalnie). Dodaj nowe wpisy, otwórz kilka stron, aby wygenerować ruch.
- Otwórz panel usługi Application Insights w portalu i przeanalizuj przesłane dane.

### Zadanie 5 - skalowanie

Wstęp: Zrób deploy aplikacji na usługę Web App wykorzystując opcje z ustawień usługi

- Skonfiguruj: Continuous Deployment/Local Git repository 
- Ustaw poświadczenia repozytorium: Deployment credentials
- Dodaj nowy 'remote' do repozytorium na twojej maszynie: git remote add azure url_repozytorium_azure
- Git push azure: git push -u azure 03-app-insights:master

Ćwiczenie

- Skonfiguruj opcje skalowania aplikacji, aby działała ona na wielu instancjach. Zaobserwuj czy konfiguracja działa ("Rendered at instance" w stopce aplikacji).
- Zadanie domowe: skonfiguruj automatyczne skalowanie i doprowadź do obciążenia systemu, które spowoduje dodanie nowych instancji. 

### Zadanie 5 - przetwarzanie w tle

Przełącz się na branch:

``` git 
git checkout 04-web-jobs

```

- Stwórz usługę Service Bus Namespace (w Azure Classic Portal: https://manage.windowsazure.com/)
- Uzupełnij brakujące wartości w konfiguracji aplikacji, tak, aby aplikacja Web i PictureOptimizer skomunikowały się wykorzystując Service Bus
- Przetestuj aplikacje lokalnie - dobrze działająca aplikacja powinna zmniejszać zapisane zdjęcia, i na widoku listy prezentować miniatury. 
- Wdróż system na chmurę.
- Korzystając Web Job Dashboard upewnij się, że aplikacja wdrożona aplikacja poprawnie przetwarza zdjęcia.

## IaaS - Ćwiczenia

### Ćwiczenie 6 - maszyny wirtualne

- Stwórz marzynę wirtalną (Windows Serwer 2012 lub Ubuntu Server)
- Wybierz Deployment model: Resource Manager
- Połącz sie z maszyną (Zdalny pulpit dla Windows, SSH dla Ubuntu)
- Uruchom lekki serwer http na maszynie.
    - Windows: pobierz [nginx](http://nginx.org/download/nginx-1.8.1.zip) i zmień konfigurację firewalla aby udostępnić port 80.
    - Ubuntu: apt-get nginx
- Zweryfikuj czy można dostać się do stworzonej maszyny.

### Ćwiczenie 7 - sieci wirtualne

- Stwórz usługę Virtual Network, w kreatorze wybrać opcję "Configure a Point-to-Site VPN) oraz dodać Gateway Subnet
- Na ostatniej zakładce wybierz "add gateway subnet"
- Stwórz gateway w sieci, używając opcji "Add Gateway" w stopce panelu zarządzania siecą.
- Powyższa akcja potrwa około 30min - trzeba w takim razie zająć się czymś innym.
- Wygeneruj self-signed Root Certificate oraz jego Client Certificate. 
- Wgraj Root Certificate do konfiguracji sieci. 
- Pobierz instalator interfejsu VPN i połącz się z siecią.
- Stwórz maszynę wirtualną (w modelu classic) dodając ją do stworzonej sieci. Skonfiguruj tak, aby dało się do niej podłączyć tylko przez sieć wirtualną.  


## Azure Active Directory

### Zadanie 8* - Azure Active Directory

- Stwórz nowe Azure Active Directory (Classic Azure Portal) (or use Training Future Processing)
- W Visual Studio użyj opcji „Configure Azure AD Authentication” w menu kontekstowym aplikacji webowej.
- Postępuj zgodnie z kreatorem, wybierając stworzone konto AD.
- Rozwiąż kilka problemów:
    - Na moment tworzenia tego szkolenia, występuje problem z wersją Microsoft.Data.Edm. Aby go rozwiązać, należy wykonać polecenie "Update-Package Microsoft.Data.Edm" w Package Manager Console
    - Usuń z kodu HTML kod (4 wystąpienia): @Html.AntiForgeryToken()
- Aby zapewnić możliwość wylogowania, umieść fragment kodu w głównym dokumencie HTML aplikacji. @Html.Partial("_LoginPartial")  // "<ul class="nav navbar-nav">"

Pełne rozwiązanie znajduje się na branchu

``` git 
git checkout 05-azure-active-directory

```