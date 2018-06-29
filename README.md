# Exponate in der IT-Sammlung - Museumsführer HoloMu

## Motivation

Wollen sich Museumsbesucher über die ausgestellten Exponate informieren, bleibt ihnen neben dem Lesen von Beschreibungstafeln nur die Möglichkeit, eine Führung oder einen Audioguide zu buchen. Allerdings sind diese Angebote mit erheblichen Nachteilen verbunden, da sie zum einen sehr unflexibel sind und zum anderen dem Besucher nicht die Wahl lassen, über welches Exponat er beziehungsweise sie mehr oder weniger Informationen erhalten will. Um dem Informationsbedürfnis des Museumsbesuchers flexibler gerecht werden zu können und den Museumsbesuch interessanter und interaktiver zu gestalten, entwickeln wir die Augmented Reality Anwendung **HoloMu**. Unter Verwendung der Microsoft HoloLens und einem Bilderkennungsalgorithmus können Exponate automatisch erkannt und dem Nutzer somit aufbereitete Informationen präsentiert werden. Dadurch kann der Nutzer selbst entscheiden, wann er welche und wie viele Informationen erhalten möchte. Neben eingeblendeten Texttafeln, wären auch eingebettete Videos oder Audiodateien denkbar, was einen eindeutigen Fortschritt zu bisherigen Texttafeln oder Führungen jeder Art darstellt.  
Um eine solch neuartige Weise der Museumsführung umzusetzen, bietet sich die IT-Sammlung der Universität Regensburg natürlich an. Dadurch kann der Besucher die Geschichte der IT direkt miterleben, indem er oder sie Gegenstände aus der Vergangenheit durch Benutzung der neusten Technologien kennen lernt.
Durch einen modularen Aufbau von **HoloMu** sind Erweiterungen ohne weiteres möglich. Neben den objektspezifischen Informationen, könnten auch museumsbezogene Informationen, wie zum Beispiel die Öffnungszeiten, der Ort des Ausganges und die Anzahl der bereits besuchten und aller Exponate angezeigt werden. Neben einem Recommender-System, das den Nutzer auf die für ihn besonders interessanten Ausstellungsstücke hinweist, ist auch eine 3D-Darstellung der Objekte denkbar, damit der Nutzer das Exponat frei aus jedem Winkel betrachten kann. Eine Navigationsfunktion, eventuell mit planbaren Touren, wäre auch eine nützliche Erweiterung für unser System.  
Wie aufgezeigt gibt es einige sinnvolle Einsatzmöglichkeiten für eine zukunftsweisende Technologie, welche andere Führungsarten fast überflüssig macht. Dies ist vor allem für kleine Museen, welche sich die Personalkosten für einen Museumsführer nicht leisten können, durchaus vorstellbar.

## Related Work

Viele Forscher und Entwickler haben sich bereits mit den Vorteilen und Anwendungsgebieten der Mixed-Reality Technologie vertraut gemacht. Auch im Museumsbereich finden sich einige interessante Quellen, Versuche und Anwendungen. Pollalis et al. (2018) präsentieren zum Beispiel eine Augmented-Reality-Anwendung für die Microsoft HoloLens, die es Besuchern im Museum ermöglicht mit den Objekten zu interagieren und mehr über die Artefakte zu erfahren. Die Intention von Pollalis et al. (2018) ist es, das Lernverhalten und die Aufmerksamkeit im Museum zu verbessern, indem sich auf das ursprüngliche Objekt konzentrieren wird, ohne eine Ablenkung zu verspüren. Diese Anwendung wird ARtLens genannt. Sie bietet Kontextinformationen für ein Objekt durch Bereitstellung von akustischen und visuellen Informationen und hilft Besucher das originale Objekt genauer zu erforschen. **Es besteht zudem die Möglichkeit, die Artefakte direkt zu manipulieren durch die Verwendung von gestenbasierten Interaktionen mit den holografischen Darstellungen dieser oder ähnlichen Objekten neben dem Original in der Galerie. ** Es soll untersucht werden, wie sich ARtLens auf objektbasiertes Lernen der Museumsbesucher auswirkt. Erste Versuche wurden mit dieser Prototypanwendung in einem afrikanischem Kunstmuseum durchgeführt. Zudem soll mehr über die Besucher und deren soziale Akzeptanz erlernt werden, um eine effektive Gestaltung von Mixed-Reality Exponaten zu erzielen. Der aktuelle Prototyp ist das Ergebnis eines iterativen benutzerzentrierten Designprozesses. Mittels mehrerer Testreihen wurden verschiedene Aspekte der Anwendung untersucht. Dazu gehören unter anderem das Interaktionsdesign, sowie auch positionsabhängige Informationen darzustellen. Getestet wurden zunächst drei Personen, die vier afrikanische Masken erkunden durften. Eine vorläufige Bewertung ergab, dass die Benutzer sich durch den Galerieraum navigieren lassen konnten und für ausgewählten Objekte zusätzliche Informationen ohne erhebliche Probleme mittels der Anwendung zu Verfügung gestellt wurden. Laut Pollalis et al. (2018) konnte durch Beobachtung festgestellt werden, dass es teils Probleme gab laut und deutlich mit der HoloLens zu sprechen und die HoloLens spezifischen Gesten auszuführen, wenn sie benötigt wurden. Dieses Problem, die Gesten richtig auszuführen, soll gemäß den Autoren mit einem kurzen HoloLens-Training zukünftig vermieden werden. Die Wirksamkeit eines solchen Trainings ist durchaus nachvollziehbar und eine denkbare Möglichkeit dieses Problem zu vermeiden.
Doch warum treten Probleme bezüglich der Sprachinteraktion mit der HoloLens auf, oder wie kann man solche vermeiden?  
Eine mögliche Ursache dafür liefern Kalantari & Rauschnabel (2018). Sie untersuchten in dem Paper "Exploring the Early Adopters of Augmented Reality Smart Glasses" wie Verbraucher auf tragbare Technologien, insbesondere die Microsoft HoloLens, reagieren und entwickelten ein Modell dazu. Um einen gewissen Überblick über die Technologieakzeptanz zu erhalten, entwarfen Kalantari & Rauschnabel (2018) eine Online-Umfrage, die mit 116 Studenten an einer nordamerikanischen Universität durchgeführt wurde. Diese Studie, bestehend aus einem zweiminütigem Video, in dem die HoloLens vorgestellt wurde, einem Fragebogen bezüglich verschiedener Akzeptanz- und Interessensfragen und dem demografischen Fragen, wurde soweit wie möglich mittels siebenstufiger Likertskalen durchgeführt. Als Ergebnis lässt sich festhalten, dass die Befragten die Vorteile einer HoloLens wesentlich höher einschätzen, als die Risiken und die HoloLens durchaus leicht zu bedienen ist. Zu bemerken ist, dass das Image einer HoloLens basierend auf den Fragebögen und ausgehend von der ermittelten hohen Standardabweichung stark polarisiert. Während bei einigen die HoloLens einen sehr positiven Ruf erfährt, assoziieren andere mit ihr einen sehr schlechten. Kalantari & Rauschnabel (2018) konnten anhand der Messungen für hedonische Motivation oder privates Risiko keine signifikanten Effekte feststellen. Zusammenfassend merken die Autoren an, dass die bisherige Forschung der Risikofaktoren noch nicht intensiv untersucht worden sei und Technologierisiken im Bereich von Augmented Reality Smart Glasses noch weiter untersucht werden müssen, um diese zu reduzieren. Zudem sei es wichtig sich der Nützlichkeit dieser Anwendungen bewusst zu werden und die Forschung weiter voranzutreiben, um die Möglichkeiten einer solchen Technologie besser auszuschöpfen.  
Weitere Erkenntnisse liefern Evans, Miller, Pena, MacAllister und Winer (2017). Sie untersuchen und evaluieren die Microsoft HoloLens anhand einer Montageanwendung. Sie verweisen auf die Vorteile solcher Geräte, da die HoloLens genau wie andere Head Mounted Displays (HMDs) Augmented Reality Instruktionen anzeigen kann und somit beide Hände für sicherere und schnellere Montagevorgänge zur Verfügung stehen. In dem von Evans et al. (2017) beschriebenen Paper, stellen sie eine Anwendung dar, die AR-Anweisungen für eine Tischbaugruppe enthält. Es handelt sich um eine Proof-of-Concept Anwendung die den Einsatz einer einfachen und intuitiven Benutzeroberfläche mit integrierten 3D Modellen und räumlich registrierte Objektpositionierung demonstrieren soll. Ein Hauptaspekt ist die bereits erwähnte einfach strukturierte Benutzeroberfläche, da im Fall eines Montagetechnikers die Umgebung oftmals sehr laut ist und auch hier eine Sprachinteraktion nicht immer gewährleistet ist. Daher ist es stets wichtig ein klar strukturiertes und übersichtliches Design zu wählen. Evans et al. (2017) empfehlen aufgrund fehlender best practices Lösungen, das sie sich auch von dem Senior Holographic Desinger von Microsoft bestätigen haben lassen, eine hybride Kombination aus 3D-Schnittstellen und 2D GUIs. Dies könne dazu beitragen die Navigationsstrukturen einfacher zu gestalten und vertraute UI-Elemente mit einer neuen Technologie zu vereinen um Frustration oder Gefahren aufgrund von unüberlegtem Handeln oder Erschrecken zu vermeiden.  
Evans et al. (2017) konzentrierten sich in ihrem Anwendungsfall bei der Entwicklung also auf nur wenige wesentliche Elemente um den Nutzer nicht zusätzlich zu belasten. Während auf die Sprachinteraktion vollkommen verzichtet wurde, sind nur Elemente wie Beschreibung des aktuellen Montageschritts, eine geführte Animation der aktuellen Aufgabe und deren Überprüfung, sowie das wechseln zum vorherigen oder nächsten Schritts umgesetzt worden.
Ein besonderes Augenmerk wurde auch auf die Textgröße und die Farbwahl gelegt. Evans et al. (2017) legten die Schriftgröße auf 20pt mit einer serifenlosen Schrift (Arial) fest um die Lesbarkeit der Anwendung zu gewährleisten, da Serifenschriftarten ihrer Meinung nach auf Bildschirmen nicht gut dargestellt werden um somit einer Augenbelastung vorzubeugen.  
Schwieriger gestaltet sich die Farbauswahl da diese immer von der Umgebung und den jeweiligen Hintergründen abhängt. Die Autoren verweisen darauf, die Farbe Weiß zu vermeiden, da es zu hell erscheint. Auch Schwarz sollte nicht verwendet werden, da es oftmals als "transparent" wahrgenommen wird. Vorgeschlagen werden von Evans et al. (2017) helle Farben, die ein Gefühl von Präsenz bieten und beruhigend wirken.
Zudem merken die Verfasser an, wie wichtig es sei den Nutzern ein Feedback zu übermitteln. Sei es, wenn eine Aktion stattgefunden hat oder noch im Gange ist, um sicherzustellen, dass der Nutzer immer weiß was gerade passiert und Verwirrung vermieden wird.  
Eine weitere sehr interessante Anwendung ist HoloMuse. In dem Paper "Enhancing engagement with Archaeological Artifacts through Gesture-Based Interaction with Holograms" stellen Pollalis, Fahnbulleh, Tynes und Shaer (2017) eine Anwendung vor, die es Nutzern erlaubt mit den archäologischen Artefakten aktiv zu interagieren, wie es anders nicht möglich wäre. HoloMuse ermöglicht den Benutzern das Aufnehmen, Drehen, Skalieren und auch Ändern des Hologramms eines originalen archäologischen Gegenstandes mittels Gesten. Nutzer können auch ihre eigenen Exponate organisieren und verwalten, aber auch ein Vorhandenes aus einer virtuellen Galerie auswählen und innerhalb der physischen Welt platzieren um sie mit dem Gerät sichtbar zu machen. Die Absicht ist, die Wirkung der Anwendung auf das Lernen zu untersuchen. Laut Pollalis et al. (2017) experimentieren viele Museen mit der Verwendung von Augmented Reality um die Besucherzahlen und somit die Kundenbindung zu optimieren, da es auf diese Weise möglich ist, Exponate "zum Leben" zu erwecken und sich intensiver mit diesen auseinanderzusetzen. Pollalis et al. (2017) verweist auf einige AR-Anwendungen, die bereits von Museen eingesetzt werden. So zum Beispiel die "Haut und Knochen"-Anwendung im Nationalmuseum für Naturgeschichte oder die "Ultimate Dinosaurs" Ausstellung im Cincannati Museum Center. Allerdings verweisen die Autoren darauf, dass AR-Anwendungen die auf Tablets oder Smartphones laufen, die Besucher oft von den originalen Objekten ablenken, da sie auf dem Bildschirm präsentiert werden und deshalb nur begrenze Wechselwirkungen mit den ursprünglichen Artefakten stattfinden können. Mit der HoloLens hingegen ist es möglich mit diesen direkt zu interagieren oder sogar Objekte zu einer Ausstellung hinzuzufügen. Zusätzlich können auf Anfrage zu den jeweiligen Objekten weitere Informationen wie Text oder Sprache eingeblendet oder zugeschaltet werden, um mehr zu dem originalen Objekt, das zeitgleich als Hologramm manipuliert werden kann, erfahren zu können.

## Konzept

Aufgrund des prototypischen Charakters der Umsetzung des Projekts, beschränkt sich **HoloMu** auf die wesentlichen und notwendigen Features. Aus ausgewählten Exponaten der IT-Sammlung wird ein Katalog aus Trainingsdaten für den Bilderkennungsalgorithmus und strukturieren Informationen erstellt. Möchte ein Nutzer mehr über ein Exponat erfahren, kann er über den mit der HoloLens mitgelieferten Klicker den Bilderkennungsalgorithmus starten. Der Klicker wird im Laufe der Entwicklung durch die Klick-Geste bzw. ein automatisches Starten der Bilderkennung durch längeres Fokussieren eines Objekts ersetzt. Erkennt **HoloMu** ein Exponant im aktuellen Bildausschnitt, wird dem Nutzer zunächst ein kurzer Überblick über das gewählte Exponat in Form einer eingeblendeten Texttafel, welche die wichtigsten Informationen enthält, gegeben. Will der Nutzer mehr über das Exponat erfahren, kann er weitere, in Kategorien aufgeteilte, Informationen per Klick auf entsprechende Buttons erhalten. Verlässt der Nutzer den Bereich des Exponats, wird die Infotafel ausgeblendet. Allerdings bleibt an dieser Stelle eine Markierung zurück, so dass der Nutzer auf einen Blick erkennen kann, welche Exponate er schon besichtigt hat. Bewegt er sich wieder in den Bereich, werden die Informationen sofort wieder angezeigt, ohne dass das Programm die Bilderkennung erneut ausführen muss. Dadurch soll dem Nutzer die Orientierung in einem potenziell verwirrend aufgebauten Museum erleichtert werden.  
Auf eine Sprachsteuerung soll hingegen verzichtet werden. Laut Pollalis et al. (2018) funktioniert die Spracherkennung nur bei einer lauten und deutlichen Sprechweise zufriedenstellend, ist aber sonst eher unzuverlässig. Im Museumskontext ist dies höchst unpraktikabel, da sich zum einen durch lautes gleichzeitiges Sprechen von mehreren Museumsbesuchern andere Besucher gestört fühlen könnten und zum anderen eine zuverlässige Spracherkennung bei den daraus folgenden Störgeräuschen nicht mehr gewährleistet werden kann. Außerdem kann man aus der Arbeit von Pollalis et al. (2018) folgern, dass eine Sprachsteuerung im öffentlichem Raum als eher unangenehm empfunden wird und somit von vor allem technik-unaffinen Menschen eher abgelehnt wird.  
Auf eine 3D-Darstellung der Exponate soll ebenfalls verzichtet werden. Aus Evans et al. (2017) lässt sich folgern, dass vor allem zu viele und zu große 3D-Objekte die Wahrnehmung der Realität verzerren und somit eventuell negativ beeinflussen. Kann der Nutzer die Größenverhältnisse und Entfernungen nicht mehr richtig einschätzen, könnte dies zu ungewollten Bewegungen führen, die vor allem in kleinen bzw. engen Museen schnell zu Unfällen führen können. Außerdem ist eine eventuelle Überforderung der Museumsbesucher unbedingt zu vermeiden, um den Museumsbesuch nicht unangenehm werden zu lassen.
Um den Museumsbesuch interaktiver zu gestalten und um auf die individuellen Interessen jedes Besuchers eingehen zu können, wird ein Recommender-System implementiert. Durch Einteilung des Katalogs in Kategorien kann anhand der Betrachtungszeit und -anzahl von Exponaten aus entsprechenden Kategorien auf das tendenzielle Interesse des Nutzers geschlossen werden. Somit kann das System den Nutzer auf weitere Exponate aus der entsprechenden Kategorie hinweisen.

## Literatur

Pollalis, C., Gilvin, A., Westendorf, L., Virgilio, I., Hsiao, D., Shaer, O. (2018). ARtLens: Enhancing Museum Visitors' Engagement with African Art. DIS'18 Companion, HongKong.

Kalantari, M., Rauschnabel, P. (2018). Exploring the Early Adopters of Augmented Reality Smart Glasses: The Case of Microsoft HoloLens. In: Jung T., tom Dieck M. (eds) Augmented Reality and Virtual Reality. Progress in IS. Springer, Cham.

Evans, G., Miller, J., Pena, M. I., MacAllister, A., Winer, E. (2017). Evaluating the Microsoft HoloLens through an augmented reality assembly application. Mechanical Enginnering Conference Presentations, Papers and Proceedings. 179. Iowa.

Pollalis, C., Fahnbulleh, W., Tynes, J., Shaer, O. (2017). HoloMuse: Enhancing Engagement with Archaeological Artifacts through Gesture-Based Interaction with Holograms. 565-570. 10.1145/3024969.3025094.
