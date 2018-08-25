# Object Recognition

## Benutzung
- Es existiert ein Ordner "images" in denen die Trainingsbilder enthalten sind untergliedert in Ordner mit den Entsprechenden Objektnamen
    - images -> Commodore -> Bild1-x.jpg
                Compaq -> Bild1-x.jpg
                iMac -> Bild1-x.jpg
                usw.
    - Pfad zu diesem Ordner muss einmalig angepasst werden: --image_dir=/mnt/k/Users/Tobias/Documents/HoloMu/Object_Recognition/images"

- Es existiert ein Ordner "test_images" dort wird das Testbild hinterlegt

- Zum Ausführen des Scripts: python train-and-test.py

- Das Script trainiert beim Ausführen automatisch, falls noch kein model erstellt wurde.
- Falls ein model existiert, testet das Script automatisch das im Ordner "test_images" befindliche Bild.