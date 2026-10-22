# ParkWise Pro — Smart Parking Slot Management System

**Complete ASP.NET Core MVC college project (.NET 8)** with responsive administration UI and **no database server, NuGet packages, MySQL, XAMPP, EF Core, migrations, or API keys**.

## Run in Visual Studio 2022

1. Install **.NET 8 SDK** and Visual Studio 2022 (ASP.NET and web development workload).
2. Extract `SmartParkingPro.zip` to a writable folder such as `Documents/SmartParkingPro`.
3. Open `SmartParkingPro.csproj` in Visual Studio.
4. Press **Ctrl + F5**. The launch profile uses `http://localhost:5055`.
5. Explore the seeded demo records (36 slots, 8 sample customers and vehicles, active sessions, receipts, reservations).

Alternatively, run in PowerShell in the extracted project folder:

```powershell
dotnet restore
dotnet run
```

> If port 5055 is busy, run `dotnet run --urls http://localhost:5077` and visit the new address.

## Working modules

1. **Dashboard:** live occupancy, today’s income, weekly revenue bars, recent check-ins, activity, zone availability.
2. **Parking slots:** 36 seeded parking spaces (car/bike/EV), add/edit/delete unused slots, assign maintenance, type/zone/status filters.
3. **Customers:** add, update, search, delete customers not linked to a vehicle.
4. **Vehicles:** register/edit owners and plates; search by plate/owner/type; prevent duplicate plates.
5. **Reservations:** add time-window booking, prevent overlapping bookings per vehicle/slot; cancel or check in.
6. **Live parking:** assign compatible available slot; prevent concurrent duplicate check-ins; see duration; checkout with cash/UPI/card.
7. **Payment receipt:** calculation per started hour with configurable grace time/minimum, printable paid receipt.
8. **Parking history:** completed sessions, payment details, searchable records and receipts.
9. **Financial reports:** filter by exit date, income summary, payment method distribution, CSV export.
10. **Settings:** rename facility, edit hourly rates and minimum/grace periods.
11. **Activity log:** most recent 250 operator actions with category filter.
12. **Responsive UI:** no CDN or JavaScript libraries, mobile navigation and offline-capable static assets.

## Default demo details

- 16 car bays in Zone A, 12 bike bays in Zone B, 8 EV bays in EV Zone.
- 8 **fictional demonstration customers** and their vehicles; 3 demo vehicles currently on site.
- Example completed sessions and 2 future bookings so every page has useful data immediately.
- Rates: Car ₹30/h, Bike ₹15/h, EV ₹40/h; minimum 1 hour; 10-minute grace before hourly rounding (minimum charge still applies).

## How information is saved

The project automatically creates `App_Data/parkingpro.json` on first launch and saves all updates to it. **Back up this file** to preserve your records. To reset to initial demo data, stop the app, delete `App_Data/parkingpro.json`, and restart. If the JSON is malformed, a `.invalid-YYYY...` backup is made and fresh demo data is generated.

## Architecture

- `Controllers/`: MVC requests and validated, anti-forgery-protected POST actions.
- `Models/ParkingModels.cs`: app entities and forms.
- `Services/ParkingStore.cs`: locked read/writes, rules, calculations, JSON persistence and demo seeding.
- `Views/`: 25+ MVC Razor views and shared layout.
- `wwwroot/`: all local styling and optional client-side slot filtering.

## Recommended demonstration sequence

1. Dashboard overview → slots map → customers.
2. Add a customer → register a vehicle (match owner).
3. Create a reservation (matching vehicle and parking slot types), then check in from reservations.
4. Visit **Live parking** and check out (choose Cash, UPI, or Card).
5. Print receipt → visit Parking history and Reports → export CSV.
6. Adjust hourly rates in Settings and review Activity log.

## Limitations (read before real use)

- Designed for **local college demo/single-machine use**, not a public parking business.
- No accounts/authentication, role-based access, real payment gateway, SMS/email, production audit security, database transactions, or multi-server support.
- 'UPI'/'Card' record the **payment method selected by an operator**, not real online transfers.
- Rates are applied at time of checkout; active sessions do not lock a historical rate.
- A booking may be placed while a space is currently occupied, assuming that space will be vacated by the reservation start. Actual check-in requires an empty space.
- JSON local disk writes require the app folder to be writable; save files are not suited to multiple running app instances.

## Troubleshooting

- **SDK not found:** install .NET 8 SDK (not only .NET runtime), restart Visual Studio.
- **Address in use:** run with a different `--urls` value.
- **File permission denied:** move the folder out of Program Files/OneDrive protected paths to a writable Documents folder.
- **Demo data already changed:** backup/delete the data JSON as explained above to reseed.
