# ParkWise Pro — XAMPP MySQL Edition

## Requirements
- Visual Studio 2022 with ASP.NET workload, .NET 8 SDK
- XAMPP with MySQL/MariaDB running
- Internet access once for NuGet restore (MySqlConnector 2.3.7)

## Setup
1. Start **MySQL** in XAMPP Control Panel (Apache optional; only needed for phpMyAdmin).
2. In phpMyAdmin, open SQL and execute `database_setup.sql` (or use Import).
3. Open `appsettings.json`; match **Port** (normally 3306, sometimes 3307), **User ID** and **Password** to your XAMPP installation. The default `root` with blank password is only appropriate for a local development machine.
4. Open `SmartParkingPro.csproj` in Visual Studio, restore NuGet packages and run.
5. On first launch, the application creates tables if needed and seeds sample parking data in MySQL. Register an account at `/Account/Register`, then log in.

## Storage
- Users live in MySQL `app_users`; passwords are salted and PBKDF2-SHA256 hashed (not stored as plaintext).
- All parking operations, customers, vehicles, bookings, payments, settings and activity records are serialized to MySQL `parking_state` (one JSON snapshot row). This preserves the existing application workflow without rewriting every controller. It is suitable for a single-instance college demo, not concurrent multi-server production use.
- Previous JSON file data is **not** automatically imported. This edition seeds its own sample data when the database is empty.
- Back up the database with phpMyAdmin Export. Deleting the database deletes accounts and records.

## Troubleshooting
- `Unable to connect` / `Connection refused`: start XAMPP MySQL and verify port in `appsettings.json`.
- `Access denied`: correct the MySQL username/password.
- `Unknown database`: import `database_setup.sql`.
- NuGet restore failed: check Internet access and NuGet package sources.

Security note: public user registration is enabled for a demo; restrict registration and add roles before deploying publicly. Do not expose a passwordless root database account on a public network.
