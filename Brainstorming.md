# Exponate in der IT-Sammlung - Museumsführer HoloMu

### Motivation
- Museumsführer, der dem klassischen Museumsbesucher (Museum im IT-Bereich) mit neuer Technologie Objekte aus der IT-Geschichte präsentiert.
- Verwendet wird die Microsoft HoloLens, mittels der die Objekte per Bilderkennung identifiziert und erklärt werden
- Museumsbesuch interaktiver und interessanter gestalten
- Die Objektbeschreibung mittels Hololens bietet mehr Möglichkeiten dem Benutzer Informationen zu liefern als bisherige Informationstafeln
- Benutzer können aufgrund der Hololens selbst bestimmen, welche und wie viel Informationen sie erhalten wollen. Zudem ist es mögliche Informationen über den akustischen als auch visuellen Kanal zu empfangen. 
- Möglichkeit die Objekte dreidimensional nachzubilden und sie zumindest virtuell neben dem echten Objekt anzufassen und von allen Seiten aus zu inspizieren
- Besucher können durch das Museum geführt werden durch eine integrierte Navigation
- Es besteht die Möglichkeit auf nicht objektspezifische Fragen eine Antwort zu finden. 
Zum Beispiel: 
1. Wie lange das Museum noch geöffnet hat 
2. Wo der Ausgang ist 
3. Wie viele Objekte noch vorhanden sind, wie viel man von dem Museum schon gesehen hat
4. Welches noch die interessantesten Objekte sind die man noch ansehen sollte wenn man schon hier ist

### Bedarfsanalyse für die Interaktion mit einem virtuellen Agenten
- Museumsbesucher können mit Objekten interagieren, bzw etwas darüber erfahren
- Es besteht aufgrund der Verwendung der HoloLens die Möglichkeit audiovisuelle Informationen zu erhalten
- Lens erkennt welches Objekt den Besucher interessiert und liefert passende Informationen dazu
- Zahl der Museumsbesucher nimmt zunehmend ab, weshalb man mit neuer Technologie mehr Besucher anlocken kann
- Interaktion mit Objekten und Beschreibungen als Hologramme sind spannender als klassische didaktische Objektbeschreibung durch Informationstafeln
- Geld- und Zeitersparnis: Man benötigt kein entsprechendes Fachpersonal mehr um durch das Museum zu führen(vor allem für kleinere Museen) und Fragen beantwortet zu bekommen. Bisherige Sprachguides sind nicht interaktiv genug dafür. Man muss nicht immer auf die ganze Gruppe warten um durch das Museum geführt zu werden, da jeder seinen eigenen Führer hat.

### Vergleich mit Literatur
Pollalis et al. (2018) präsentieren eine Augmented-Reality-Anwendung für die Microsoft HoloLens, die es Besuchern im Museum ermöglicht mit den Objekten zu interagieren und mehr über die Artefakte zu erfahren. Die Intention von Pollalis et al. (2018) ist es, das Lernverhalten und die Aufmerksamkeit im Museum zu verbessern, indem man sich dennoch auf das urspüngliche Objekt konzentrieren kann ohne eine Ablenkung zu verspüren. Diese Anwendung wird ARtLens genannt. Sie bietet Kontextinformationen für ein Objekt durch Bereitstellung von akustischen und visuellen Informationen und hilft Besucher das originale Objekt genauer zu erforschen. Es besteht zudem die Möglichkeit die Artefakte direkt zu manipulieren durch die Verwendung von gestenbasierten Interaktionen mit den holografischen Darstellungen dieser oder ähnlichen Objekten neben dem Original in der Galerie. Die Absicht ist es zu untersuchen, wie sich ARtLens auf objektbasiertes Lernen der Museumsbesucher auswirkt. Erste Versuche wurden mit dieser Prototypanwendung in einem afrikanischem Kunstmuseum gemacht. Zudem erhofft man sich mehr über die Besucher und deren soziele Akzeptanz zu lernen um eine effektive Gestaltung von Mixed-Reality Exponate zu erzielen. Der aktuelle Prototyp ist das Ergebnis eines iterativen benutzerzentrieten Designprozesses. Mittels mehrerer Testreihen wurden verschiedene Aspekte der Anwendung untersucht. Dazu gehören unter anderem das Interaktionsdesign, sowie auch positionsabhängige Informationen darzustellen. Getestet wurden zunächst drei Personen, die vier afrikanische Masken erkunden durften. Eine vorläufige Bewertung ergab, dass die Benutzer sich durch den Galerieraum navigieren lassen konnten und für ausgewählten Objekte zusätzliche Informationen ohne erhebliche Probleme mittels der Anwendung zu Verfügung gestellt wurden. Laut Pollalis et al. (2018) konnte durch Beobachtung festgestellt werden, dass es teils Probleme gab laut und deutlich mit der HoloLens zu sprechen und die HoloLens spezifischen Gesten auszuführen wenn sie benötigt wurden. Dieses Problem die Gesten richtig auszuführen soll mit einem kurzen HoloLens-Training zukünftig vermieden werden. 

### Erläuterung was (neu) gemacht wird
- Keine Sprachinteraktion beim HoloMu, da laut Pollalis et al. (2018) Sprachinteraktion oft zu leise war und die Erkennung deshalb nicht einwandfrei funktioinierte. Folgerung: Nicht praxistauglich, da viele Museumsbesucher durch laute/deutliche Sprachinteraktion mit der Hololens in einem Museum als sehr störend empfunden werden können
- Soweit die Daten es zulassen, achten wir auf möglichst interaktive und srukturierte Darstellung der Informationen, um den Besuchern einen besseren Überblick über die vorhandenen Informationen zu gewährleisten und joy of use.
- Erkennen welche Objekte schon betrachtet wurden; Bilderkennungsprozess muss nicht erneut gestartet werden, HoloLens erkennt, dass der Nutzer schon hier war -> Nutzer bekommt zusätzlich die Info, dass er das Objekt bereits betrachtet hat...Möglichkeit besteht noch mehr Informationen dazu erhalten => nützlich für Recommendersystem (Objekte mehrmals betrachtet werden als interessanter eingestuft)
- Objekterkennung mittels "Clicker", Fingertap oder längeres Fixieren (Feedback, dass gerade gescannt wird und das Objekt ermittelt wird). Fingertap soll CLicker ersetzen
- Recommendersystem: Objektvorschläge zu bereits gesehenen Objektkategorien

### Literatur
Pollalis, C., Gilvin, A., Westendorf, L., Virgilio, I., Hsiao, D., Shaer, O. (2018). ARtLens: Enhancing Museum Visitors' Engagement with African Art. DIS'18 Companion, HongKong.

Evans, G., Miller, J., Pena, M. I., MacAllister, A., Winer, E. (2017). Evaluating the Microsoft HoloLens through an augmented reality assembly application. Mechanical Enginnering Conference Presentations, Papers and Proceedings. 179. Iowa.