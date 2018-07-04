# Anforderungen, technische Details, Umsetzung

## HoloLens und Unity3D

- Verwaltet Nutzereingaben (Klick, Geste, Anschauen)
- Zeigt Info zum erkannten Gegenstand (Mit Zusatzinfos, welche über Buttons zugänglich sind)
- Infos sind im Raum durch Nutzer frei plazierbar, aber Ursprungpunkt ist relativ zur Nutzerposition, -blickrichtung, Verhalten analog zu Windows
- Verwaltet API Requests
- Zeigt bereits betrachtete Objekte an den entsprechenden Positionen => Infofeld öffnet sich bei erneutem Betreten des näheren Umfelds, wenn Nutzer in die Richtung des Objekts blickt => Selber Spawn wie bei Erkennung

## Server bzw. REST Api

### Datenaufbereitung

- Datensatz als XML
- Siehe testdaten.xml
- Pro Item 100 (?) Fotos
- Datensatz und Trainingsbilder liegen auf dem Server
- Uniserver (?) oder Uberspace
- Zwei Kategorien, sonst macht Recommender keinen Sinn

### Bilderkennung

- Bis auf weiteres TensorFlow
- Server startet Training bei Serverstart
- Bei Bildupload wird Bild klassifiziert und entsprechender Abschnitt aus xml zurückgeschickt, inkl. eventuelle Empfehlung
- Wenn nichts erkannt wird, wird entweder Meldung oder NULL zurückgegeben (abhängig von Erkennungsgüte)
- Bild wird danach gelöscht (interessant wäre Aufnahme des Bildes in Trainingskorpus, wenn Bild korrekt erkannt)

### Recommender

- Läuft serverseitig
- Zunächst für jeden Nutzer einzeln, evtl. auch unter Berücksichtigung aller Nutzerdaten
- Empfehlungen auf Basis von Wahrscheinlichkeiten
- Evtl. gewichteter Durchschnittswert (bzgl. Betrachtungsreihenfolger bzw. eher Betrachtungsdauer)
- Empfehlung wird nach x Bilderkennungen mitgeschickt
