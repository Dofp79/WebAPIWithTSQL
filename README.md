🔷 WebForAPI — Minimal UI for WebAPIWithTSQL

Ein leichtgewichtiges HTML/Bootstrap/jQuery‑Frontend, das zwei typische Flows bereitstellt:

Start.html – Tabellenansicht: Nutzer abrufen, anzeigen, bearbeiten, löschen

Registration.html – Formular: Nutzer anlegen oder bearbeiten

Ziel: Schnelles manuelles Testen der REST‑Endpoints aus dem Repo WebAPIWithTSQL – ganz ohne Framework‑Ballast. 
GitHub

✨ Features

Read → Start.html: Lädt die Nutzerliste über View() und rendert eine Bootstrap‑Tabelle

Create/Update → Registration.html: SaveUser() per POST/PUT; PainUser(id) (Prefill beim Edit)

Navigation: GoToFormCreate() springt von der Liste zum Formular

Helpers: $.urlParam() extrahiert Query‑Parameter (z. B. ?id=...) 
GitHub

🧱 Projektstruktur
WebForAPI/
├─ Start.html          # Liste (View, Edit, Delete, Create)
├─ Registration.html   # Formular (Create/Update)
└─ README.md

🚀 Schnellstart

Voraussetzung: Deine Backend‑API (WebAPIWithTSQL) läuft lokal oder remote und erlaubt CORS.

Clone/Download

git clone https://github.com/Dofp79/WebForAPI.git
cd WebForAPI


API‑Basis‑URL setzen
Öffne Start.html und Registration.html und prüfe die Variable/Zeile, in der die API‑URL gesetzt wird (z. B. const API_BASE = "http://localhost:5050/api";). Passe sie an dein Backend an.

Start im Browser
Doppelklick auf Start.html oder kurz einen lokalen Server nutzen:

# Python 3
python -m http.server 8080
# dann http://localhost:8080/Start.html öffnen


Tipp: Einige Browser blocken file://‑XHR. Ein Mini‑Webserver vermeidet CORS/Origin‑Stolpersteine.

🔌 Erwartete API‑Endpoints (Beispiel)

Diese UI wurde gebaut, um gegen die REST‑Routen deines WebAPIWithTSQL zu testen. Passe Pfade/Methoden an deine API an.

Aktion	Methode	Pfad	Body (JSON)
Nutzer lesen (Liste)	GET	/api/users	—
Nutzer lesen (einz.)	GET	/api/users/{id}	—
Nutzer anlegen	POST	/api/users	{ "name": "...", "email": "..." }
Nutzer aktualisieren	PUT	/api/users/{id}	{ "name": "...", "email": "..." }
Nutzer löschen	DELETE	/api/users/{id}	—

Fetch‑Snippet (Beispiel Create):

async function SaveUser() {
  const payload = {
    name: document.getElementById('name').value,
    email: document.getElementById('email').value
  };
  const id = $.urlParam('id');
  const method = id ? 'PUT' : 'POST';
  const url = id ? `${API_BASE}/users/${id}` : `${API_BASE}/users`;

  const res = await fetch(url, {
    method,
    headers: {'Content-Type':'application/json'},
    body: JSON.stringify(payload)
  });

  if (!res.ok) {
    const msg = await res.text();
    alert(`Fehler ${res.status}: ${msg}`);
    return;
  }
  window.location.href = 'Start.html';
}

🧭 User Flow

Start.html

Klick auf Create → Registration.html (ohne id)

Klick auf Edit → Registration.html?id={id} (Formular wird per PainUser(id) befüllt)

Klick auf Delete → DELETE‑Call → Liste aktualisieren

Registration.html

Save → POST (neu) oder PUT (Update) → Redirect zurück zur Liste

GitHub

🛡️ CORS & Troubleshooting

CORS Fehler: Backend muss Access-Control-Allow-Origin: * (oder deine Domain) senden.

405/415: Prüfe HTTP‑Methode & Content-Type: application/json.

404: Pfad stimmt nicht mit deiner API überein → Base‑URL/Route anpassen.

file:// XHR blockiert: Lokalen Webserver verwenden (siehe Schnellstart).

🧪 Manuelle Tests (Checkliste)

 Liste lädt Nutzerdaten (HTTP 200)

 Create erzeugt neuen Datensatz (HTTP 201/200)

 Edit lädt Datensatz in Formular (GET by id) & speichert korrekt (PUT)

 Delete entfernt Datensatz & UI aktualisiert Tabelle

 Fehlerfälle (400/500) werden dem User angezeigt

🔮 Roadmap (Optional)

Form‑Validierung (HTML5 + Client‑Checks)

Toast‑Benachrichtigungen statt alert()

Paginierung/Filter in der Liste

Environment‑Switch (DEV/TEST/PROD) via config.js

TypeScript‑Refactor / ES Modules

📫 Kontakt

Fragen oder Feedback?
Doniman F. Peña Parra

🔗 LinkedIn: https://www.linkedin.com/in/doniman-francisco-pe%C3%B1a-parra-609263232/

✉️ E‑Mail: dofp79@hotmail.com
