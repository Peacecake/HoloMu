# HoloMu Backend REST Api

## Benutzung

- Wenn noch keine Virtual Environment erstellt wurde (venv Ordner exisitert?):
  - python3 -m venv venv
  - pip install flask
- Virtual Environment starten: . venv/bin/activate
- Server starten:

```
export FLASK_APP=flaskapp
export FLASK_ENV=development
flask run
```

Wenn Server nicht nur lokal, sondern auch für alle Geräte im Netzwerk erreicht werden soll:

```
flask run --host:0.0.0.0
```

Der Server lässt sich dann über die IP-Adresse (herauszufinden über `ifconfig`) : PORT erreichen.

Datenbank-Initialisierung:
Server stoppen, dann:

```
flask init-db
```
