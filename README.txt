Car-dealer: 

1. Pakiety nuget: 

- BCrypt.Net-Next 4.0.3
- Microsoft.AspNetCore.Authentication.JwtBearer 6.0.20
- Microsoft.EntityFrameworkCore 7.0.9
- Microsoft.EntityFrameworkCore.Sqlite 7.0.9
- Microsoft.EntityFrameworkCore.Tools 7.0.9
- Swashbuckle.AspNetCore 6.2.3

2. Aplikacje używane do tworzenia projektu: 

- VS2022
- VSCODE
- DBeaver
- Postman

3. Baza jest wbudowana w projekcie używając SQLite, łącząc się do pliku application.db 
W projekcie są dwie bazy co za tym idzie należy się połączyć do obu plików z każdego solution.

4. Aplikacja jest podzielona na dwa różne rozwiązania Car-dealer Users oraz Cars. W Aplikacji Users
mamy możliwość zalogowania się oraz rejestracji, usuwania i wyszukiwania użytkowników 
oczywiście jeśli dostaniemy token i będziemy mieć odpowiednie uprawnienia. 

Aplikacja Cars ma za zadanie tworzenie samochodów do odpowiednich typów, a następnie 
tworzenie zamówień, tworzenie płatności, wyszukiwanie nieopłaconych zleceń oraz 
"płacenie" w postacji omarkowania badania w Payment.IsPaid jako true. 
Mikroserwisy łączą się po http w widoku PaymentDetails jako pobieranie użytkownika z Aplikacji Users.

Aplikacja front-endowa ma możliwość logowania, rejestracji, oraz tworzenia nowych samochodów
i tworzenia zamówień i płatności, a także podglądu nieopłaconych zamówień/rezerwacji. 


Ogólnie mówiąc jest to aplikacja do wypożyczania samochodów różnego typu, w której
należy utworzyć sobie konto, aby móc zarezerwować samochód. 

5. Użytkownicy: 

[Administrator]
L: Admin@admin
H: admin 

[Użytkownik]
L: User@user
H: user

