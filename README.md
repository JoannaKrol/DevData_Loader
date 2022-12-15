# DevData_Loader

Program do wyciągania danych z tabel systemowych. Program pobiera parametry wszystkich kolumny o typie int dla wszystkich tabel znajdujących się na serwerze w bazie danych określonej w pliku json. 

Domyślnie plik json zawiera dane ServerName = "Express" oraz DataBaseName = "DevData".

Program wymaga autoryzacji użytkownika na serwerze bazodanowych poprzed logowanie za pomocą loginu i hasła.

# Wersja .NET

- .NET 5.0

# Zainstalowane paczki
- Newtonsoft.Json 13.0.2
- System.Data.SqlClient 4.8.5