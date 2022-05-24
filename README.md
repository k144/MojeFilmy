# MojeFilmy - zadanie rekrutacyjne

MojeFilmy składa się z aplikacji webowej (Vue.js) umożliwiającej edytowanie treści bazy danych (SQLite) z listą filmów poprzez komunikację z API (C# .NET).

## Instalacja i uruchamianie

### Serwer API

W katalogu `api` wykonaj  polecenia:

`dotnet restore`

`dotnet run`

Uwaga: prawidłowe działanie API wymaga [odpowiedniej konfiguracji certyfikatów](https://docs.microsoft.com/pl-pl/dotnet/core/additional-tools/self-signed-certificates-guide).

### Aplikacja webowa

W katalogu `web` wykonaj polecenia:

`npm install`

`npm run serve`

Aplikacja powinna być dostępna pod adresem `http://localhost:8080`.

Baza danych jest bezserwerowa i nie wymaga uruchamiania.
