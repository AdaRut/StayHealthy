# stayhealthy
Aplikacja backendowa pozwalająca na zarządzanie swoimi posiłkami, poprzez zarządzanie dietami.
Aplikacja umożliwia zalogowanym użytkownikom na tworzenie, usuwanie, modyfikowanie oraz przeglądanie diet, które składają się z różnych posiłków. 

# 1.Instrukcja uruchomienia od strony deweloperskiej
1. Pobrać i zainstalować wymagane oprogramowanie:
* SQL Server https://www.microsoft.com/pl-pl/sql-server/sql-server-downloads
* IDE umożliwiające pisanie aplikacji webowych w ASP.NET Core, zalecane Visual Studio 2019 i nowsze https://visualstudio.microsoft.com/pl/vs/
2. Pobrać źródła projektu z zdalnego repozytorium
3. Otworzyć projekt dwukrotnym kliknięciem na StayHealthy.sln.
4.  Za pomocą NuGet Package Manager zainstalować wszystkie zależności (projekt ->Manage Nuget Packages)
5. Dla projektu stayHealthy.Api:
* Microsoft.EntityFrameworkCore.Design v. 5.0.14
* Nlog.Web.AspNetCore v. 4.14.0
* Swashbuckle.AspNetCore v 5.6.3
6. Dla projektu stayHealthy.DataAccess
* Microsoft.EntityFrameworkCore v. 5.0.14
* Microsoft.EntityFrameworkCore.Design v. 5.0.14
* Microsoft.EntityFrameworkCore.SqlServer v. 5.0.14
* Microsoft.EntityFrameworkCore.Tools v. 5.0.14
7. Dla projektu stayHealthy.Services
* AutoMapper v. 10.1.1
* BCrypt.Net-Next v 4.0.2
* FluentValidation.AspNetCore v. 10.3.4
* Microsoft.AspNetCore.Authentication.JwtBearer v 5.0.12
* Microsoft.AspNetCore.Mvc.NewtonSoftJson v.5.0.12
* Microsoft.EntityFrameworkCore v. 5.0.14
* Microsoft.EntityFrameworkCore.SqlServer v. 5.0.14
* Microsoft.EntityFrameworkCore.Tools v. 5.0.14
8. Utworzyć bazę danych wpisując w Package Manager Consoler komendę update-database
9. Ustawic stayHealthy.Api jako projekt startowy
10. Za pomocą SQL Server Management Studio edytować tabelę DietCategories dodając tam parę rekordów.
11. Uruchomić serwer (Debug/StartDebugging)

# 2. Instrukcja od strony użytkownika
1. Po uruchomieniu serwera aplikacji uzytkownik powinien korzystać z dostępnego API poprzez projekt https://github.com/AdaRut/StayHealthyFront. Możliwe jest także komunikowanie się z API poprzez Swaggera lub dodatkowe programy takie jak PostmanApi

# 3. Dostępne API apikacji
Aplikacja posiada 4 kontrolery pozwalajace komunikować się z serwerem:\
**1. AuthController**
* POST /api/auth/login\
 Umożliwia logowanie, zwraca token\
 Przykładowe body wysłane do zapytania:\
 {\
  "username": "username",\
  "password": "password"\
}
* PATCH /api/auth/password/by-user\
 Zmiana hasła przez użytkownika\
 Przykładowe body wysłane przez zalogowanego użytkownika:\
 {\
  "currentPassword": "password",\
  "newPassword": "newPassword"\
}
* PATCH /api/auth/password/by-admin\
 Zmiana hasła przed administratora\
 Przykładowe body wysłane przez administratora w celu zmiany czyjegoś hasła:\
 {\
  "userId": 3,\
  "newPassword": "XDD"\
}

**2. CategoryController**
* GET /api/category\
 Pobranie wszystkich kategorii diet
 
 **3. DietController**
 * POST /api/diet\
 Dodanie nowej diety\
 Przykładowy body zapytania:\
 {\
  "name": "Dieta Warzywna",\
  "maxCalories": 2500,\
  "dietCategoryId": 1,\
  "meals": [
    {\
      "name": "pomidor to nie warzywo",\
      "calories": 100\
    },
    {\
        "name": "sałata",\
      "calories": 200\
    }
  ]
}
* GET api/diet\
 Pobiera wszystkie istniejące diety
* GET api/diet/user\
Pobiera wszystkie diety danego uzytkownika
* GET api/diet/{id}\
Pobiera szczegóły diety o podanym id
* PUT api/diet\
Modyfikuje dietę o podanym id, body podobne jak w przypadku dodawania diety + id
* DELETE api/diet/{id}\
Usuwa dietę o podanym id

**4. UserController**
* POST api/user\
Dodaje użytkownika do systemu
Przykładowe zapytanie: \
{\
  "username": "life",\
  "password": "life",\
  "email": "life@gmail.com",\
  "firstName": "life",\
  "lastName": "isLife",\
  "role": 0\
}
* PUT api/user\
Modyfikuje dane uzytkownika
* GET api/user/{userId}
Zwraca dane dotyczące uzytkownika o podanym userId
* DELETE api/user/userId\
Usuwa uzytkownika o podanym userId
* GET api/user\
Pobiera dane o wszystkich użytkownikach
