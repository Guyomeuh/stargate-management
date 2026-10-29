# Stargate Management

A Windows desktop application for managing the missions of the **Stargate project**: off-world expeditions sent to study alien species, recruit informants, capture enemies and negotiate for *DataBaz*, a rare ore found only on a handful of planets.

Built with **C# / WinForms** on **.NET Framework 4.7.2**, backed by a local **SQLite** database.

> **Note:** the user interface is in French.

---

## Table of contents

- [Features](#features)
- [Tech stack](#tech-stack)
- [Requirements](#requirements)
- [Getting started](#getting-started)
- [Usage](#usage)
- [Database](#database)
- [Project structure](#project-structure)
- [Context](#context)
- [Authors and license](#authors-and-license)

---

## Features

### Mission dashboard
- Overview of every mission as summary cards, loaded into a shared local `DataSet`.
- Filters by **planet** and **status** (*En cours* / *Terminée* — ongoing / completed), plus A → Z / Z → A sorting.
- Click a mission to open its full details.

### Mission details and logbook
- Departure and expected return dates, roadmap, capture objectives.
- Initial budget and remaining balance after expenses.
- Crew members (soldiers and civilians) and mission leader.
- Logbook events browsed **one at a time** with first / previous / next / last navigation (data binding).
- Expenses, informant contacts and captures shown in tables.
- Add new **events, expenses, informant contacts and captures** directly from the form.
- **PDF report export** (QuestPDF), saved to `Downloads/rapport-<mission>.pdf`.

### Mission creation (admin only)
- Login form checking a **BCrypt-hashed password** stored in the database.
- Step 1: planet, departure / return dates, required crew size, budget, roadmap and mission leader (chosen among available soldiers).
- Step 2: crew selection and capture objectives, saved inside an **SQLite transaction** — if anything fails, nothing is recorded.

### Species and planets
- Browse every known species, with separate views for **allies** (first contact, benevolence, musical instrument) and **enemies** (weapon type, aggressiveness).
- Search species by name, color or planet.
- Planet cards showing temperature, gravity, DataBaz availability and the species living there.

### Statistics
- Missions with more than 10 crew members: initial vs. remaining budget.
- Number of missions per planet (including planets never visited).
- Highest expense of each mission.
- Members who served on the same missions.
- Least-paid informant for each mission.

### Interface
- Custom purple color palette with a **light / dark theme toggle**.

## Tech stack

| Component | Technology |
|---|---|
| Language / UI | C#, Windows Forms |
| Framework | .NET Framework 4.7.2 |
| Database | SQLite via `System.Data.SQLite.Core` 1.0.119 |
| PDF generation | QuestPDF 2026.5 (Community license) |
| Password hashing | BCrypt.Net-Core 1.6 |

## Requirements

- **Windows** (WinForms and .NET Framework are Windows-only).
- **Visual Studio 2022** (17.10 or newer, to open the `.slnx` solution format) with the *.NET desktop development* workload.
- .NET Framework **4.7.2** Developer Pack.

## Getting started

```bash
git clone https://github.com/Guyomeuh/stargate-management.git
```

1. Open `src/SAE24.slnx` in Visual Studio.
2. Restore the NuGet packages (*right-click the solution → Restore NuGet Packages*, or simply build — Visual Studio restores them automatically).
3. Build and run with **F5**.

The executable is produced as `SAE24.exe` in `src/bin/Debug/` (or `Release/`).

> **Database location:** the connection string in `Connexion.cs` is relative to the executable:
> `Data Source = ..\..\DataBase\Stargate.db`
> It works out of the box when launching from `bin/Debug` or `bin/Release`. To distribute the app elsewhere, copy `Stargate.db` next to the executable and switch to the commented-out alternative (`Data Source = Stargate.db`).

## Usage

1. The app opens on the **dashboard** (*Tableau de bord*). Use the side buttons to switch between missions, species (*Découverte des races*), planets (*Infos des planètes*) and statistics (*Statistiques*).
2. Click a mission card to open its details and logbook (*Journal de bord*). Pick an entry type (contact, expense, event or capture) to add data, or generate the PDF report.
3. To create a mission, click **Nouvelle Mission** and log in with an administrator account from the `Admin` table.

> Administrator passwords are stored as BCrypt hashes. To add an account, insert a login and a BCrypt hash (e.g. generated with `BCrypt.Net.BCrypt.HashPassword("...")`) into the `Admin` table.

## Database

The SQLite database `src/DataBase/Stargate.db` ships with sample data (17 planets, 35 species, 61 members, 7 missions…).

| Domain | Tables |
|---|---|
| Galaxy | `Planete`, `Espece`, `Habiter` (species population per planet), `Allie`, `Ennemi` |
| Personnel | `Membre`, `Militaire`, `Civil`, `Admin` |
| Missions | `Mission`, `Composer` (crew), `ObjectifCapture`, `Capturer`, `JournalDeBord` |
| Finances & intel | `Depense`, `TypeDepense`, `Contact`, `Informateur`, `Negocier` (DataBaz trades) |

A mission is identified by its planet and a sequence number (e.g. `Sckxyss` + `1`), and its leader must be a soldier.

## Project structure

```
src/
├── Program.cs                         # Entry point (opens the dashboard)
├── Connexion.cs                       # Singleton SQLite connection
├── mesDatas.cs                        # Shared global DataSet
├── Couleur.cs                         # Color palette and theme switching
├── FormulaireTableauDeBord.cs         # Dashboard, species, planets, statistics
├── FormulaireJournalDeBord.cs         # Mission details, logbook, PDF export
├── FormConnexion.cs                   # Admin login (BCrypt)
├── FormCreationMission.cs             # Two-step mission creation
├── UserControl/                       # Mission, crew member, planet and species cards
├── UserControlMessageErreur.cs        # Error display control
├── Images/                            # Logo, planets, species, members, temperature icons
├── DataBase/Stargate.db               # SQLite database
├── LittlePlanete.csproj
└── SAE24.slnx
sujet.pdf                              # Original project brief (French)
```

## Context

University project (**SAÉ 2.4**, 2026) at IUT Robert Schuman. The full brief is available in [`sujet.pdf`](sujet.pdf) (in French).

## Authors and license

Made by **Guillaume Niederlaender**, **Eliott Wanner** and **Ethan Soobrayen**.

Released under the [MIT](LICENSE) license.
