# PrimeEngineering
## Przegląd
Aplikacja jest zaprojektowana do zarządzania zadaniami w organizacji. Wszystkie zapytania do API sa autoryzowane co gwarantuje, że menedżer nie ma dostepu do endpointów przeznaczonych dla pracowników i odwrotnie. Przy tworzeniu bazy zasosowlem podejście code first, przy uruchomieniu aplikacji, jesli baza danych nie istnieje, zostanie automatycznie utworzona i wypełniona danymi początkowymi, w tym dwoma pracownikami oraz menedżerem. Domyślnie aplikacja jest skonfigurowana by odpalic API oraz clienda w trybie dubug przez visual studio. W innym wypadku nalezy zmienić url w pliku: PrimeEnginieringWinFormClient/Common/Static/PrimeEnvironment.cs


## Dane do logowania
Poniższe dane logowania mogą być użyte do uzyskania dostępu do aplikacji:

1. **Manager:**
   - Login: `Manager1`
   - Email: `Manager@123.pl`
2. **Pracownik 1:**
   - Login: `Employee1`
   - Email: `Employee1@123.pl`
3. **Pracownik 2:**
   - Login: `Employee2`
   - Email: `Employee2@123.pl`

**Hasło dla wszystkich użytkowników:** `Test.123`

## Funkcjonalności

### Widok Menedżera
Po zalogowaniu się jako menedżer, zostaniesz przeniesiony do widoku menedżera. Menedżer posiada następujące możliwości:
- Rejestrowanie nowych pracowników
- Podgląd listy zadań dla każdego pracownika
- Przeglądanie statystyk z podziałem na miesiące

### Widok Pracownika
Po zalogowaniu się jako pracownik, zostaniesz przeniesiony do widoku pracownika. Pracownik posiada następujące możliwości:
- Tworzenie nowych zadań
- Przeglądanie zadań, w których jest kontrybutorem
- Edytowanie zadań, oznaczanie zadań jako skończone oraz dodawanie kontrybutorów do zadań, w których uczestniczy

## Struktura rozwiązania
Rozwiązanie jest podzielone na trzy projekty: API, Klient oraz Testy.

### API (ASP.NET)
- **Baza danych:** SQLServer zarządzany za pomocą EntityFramework.
- **Wzorce projektowe pomagające w obsłudze bazy:** Unit Of Work oraz Repository.
- **Autentykacja i autoryzacja:** Token JWT Bearer.
- **Wzorzec Mediator:** Zaimplementowany przy użyciu biblioteki MediatR.
- **Logowanie:** Serilog do logowania błędów i informacji, wyświetlający informacje do konsoli oraz zapisujący je do pliku.
- **Obsługa błędów:** Middleware do automatycznego przechwytywania i obsługi błędów.
- **Walidacja zapytań:** Middleware do automatycznej walidacji zapytań.

### Klient (WinForms)
- Aplikacja kliencka została zbudowana przy użyciu WinForms.

### Testy
- **Testy jednostkowe:** Wykorzystując biblioteki XUnit i Moq.
- **Testy integracyjne:** Dodatkowo wykorzystując bibliotekę MVC.Testing.
