🔷 WebForAPI — Minimal UI for WebAPIWithTSQL 🔷

Ein leichtgewichtiges HTML/Bootstrap/jQuery‑Frontend, das zwei typische Flows bereitstellt:

Start.html – Tabellenansicht: Nutzer abrufen, anzeigen, bearbeiten, löschen

Registration.html – Formular: Nutzer anlegen oder bearbeiten

Ziel: Schnelles manuelles Testen der REST‑Endpoints aus dem Repo WebAPIWithTSQL – ganz ohne Framework‑Ballast. 
GitHub

🔷 Features 🔷

Read → Start.html: Lädt die Nutzerliste über View() und rendert eine Bootstrap‑Tabelle

Create/Update → Registration.html: SaveUser() per POST/PUT; PainUser(id) (Prefill beim Edit)

Navigation: GoToFormCreate() springt von der Liste zum Formular

Helpers: $.urlParam() extrahiert Query‑Parameter (z. B. ?id=...) 
GitHub

🔷 Projektstruktur 🔷

WebForAPI/
├─ Start.html          # Liste (View, Edit, Delete, Create)
├─ Registration.html   # Formular (Create/Update)
└─ README.md


📫 Kontakt

Fragen oder Feedback?
Doniman F. Peña Parra

🔗 LinkedIn: https://www.linkedin.com/in/doniman-francisco-pe%C3%B1a-parra-609263232/

✉️ E‑Mail: dofp79@hotmail.com
