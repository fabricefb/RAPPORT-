# La Divine — Prototype

Repository scaffold minimal pour l'application 'La Divine' (Razor Pages + API + EF Core).

Quickstart:
1. Ouvrir le dossier `src/LaDivine`.
2. Modifier la connection string dans `appsettings.json` (par défaut utilise LocalDB pour dev).
3. `dotnet restore` puis `dotnet ef migrations add Initial` et `dotnet ef database update`.
4. `dotnet run` pour démarrer l'application.

Options:
- Change DB provider to PostgreSQL si tu préfères (installer Npgsql.EntityFrameworkCore.PostgreSQL).
- Le controller `SyncController` contient un squelette pour `/api/sync-rapport/batch`.

Prochaines étapes:
- Compléter les DTOs de sync et la logique d'idempotence.
- Ajouter auth (Identity + JWT / cookie) et policies.
- Implémenter UI de rapport du jour et syncQueue côté client (IndexedDB).