# OPTIONAL: Die Weltkarte direkt aus einem Bild lesen 🖼️

Welche ``Konzepte`` der Programmiersprache üben wir hier?
* ``File.ReadAllBytes`` / ``File.WriteAllBytes``: eine Datei als ``byte[]`` (1D) lesen
* Aus einem **1D-Array** (Bytes im File) ein **2D-Array** (Karte) machen – mit Index-Rechnung
* ``verschachtelte for-Schleifen``, ``Mehrfachverzweigung``

Welche ``Denkweisen`` üben wir hier?
* Ein Bild ist auch nur eine lange Reihe von Zahlen. Wo im ``byte[]`` steht das Pixel ``(x, y)``?

Wir verwenden **keine** zusätzliche Bibliothek (kein NuGet-Paket), sondern nur ``File.ReadAllBytes``. Das geht, weil das Format **BMP** (Bitmap) sehr einfach aufgebaut ist.
Eine Lösung findest du in [Loesung.cs](Loesung.cs) – schau sie dir nur an, wenn du gar nicht weiterkommst.

Das Bild [weltkarte.bmp](weltkarte.bmp) ist 32 × 32 Pixel groß (in Paint stark hineinzoomen!). Es zeigt dieselbe Welt wie ``weltkarte.txt`` – nur mit Farben statt Emojis:

| Farbe (Rot, Grün, Blau) | Emoji |
|---|---|
| (0, 0, 255) | 🟦 Wasser |
| (120, 67, 21) | 🟫 Erde |
| (128, 128, 128) | 🗻 Stein |
| alles andere | 💀 |

---

### So ist eine BMP-Datei aufgebaut
```
Index:  0   1   2 ... 10 ... 18 ... 22 ...  start  start+1  start+2  start+3 ...
Byte:  'B' 'M'  ...  [start] [breite] [hoehe] ... | Blau  | Grün   | Rot    | Blau ...
       \______________ Kopf (Header) _________/   \_____ Pixel (0, unterste Zeile) ____/
```
| Index | Inhalt |
|---|---|
| ``10`` | ``start``: ab welchem Byte die Pixel beginnen (bei uns 54) |
| ``18`` | ``breite`` in Pixel |
| ``22`` | ``hoehe`` in Pixel |
| ab ``start`` | pro Pixel **3 Bytes** in der Reihenfolge **Blau, Grün, Rot** |

Zwei Besonderheiten:
1. Die Zeilen stehen **von unten nach oben** im File. Die erste Pixelzeile im File ist die **unterste** Zeile des Bildes.
2. Jede Zeile wird mit 0-Bytes auf ein Vielfaches von 4 aufgefüllt: ``bytesProZeile = (breite * 3 + 3) / 4 * 4``. (Bei 32 Pixel Breite sind es genau 96 – es wird nichts aufgefüllt.)

Damit liegt das Pixel ``(x, y)`` hier:
```csharp
int zeileImFile = hoehe - 1 - y;
int position = start + zeileImFile * bytesProZeile + x * 3;
// daten[position] = Blau, daten[position + 1] = Grün, daten[position + 2] = Rot
```

---

### Teil 1 - level: 🙂 - Hilfsfunktion verstehen
``int LeseZahl(byte[] daten, int position)`` ist vorgegeben. Ein ``byte`` kann nur 0–255 speichern – größere Zahlen wie die Breite stehen deshalb in **4 Bytes** hintereinander.

Rechne am Zettel: Welche Zahl ergeben die Bytes ``32 0 0 0``? Und ``54 1 0 0``?

### Teil 2 - level: 🙂 - Farbe in Emoji umwandeln
Implementiere ``string FarbeZuSymbol(int rot, int gruen, int blau)`` laut Tabelle oben.

### Teil 3 - level: 🤔 - Bild einlesen
Implementiere ``string[,] LadeKarteAusBild(string pfad)``:
1. Lies das File mit ``File.ReadAllBytes(pfad)`` in ein ``byte[] daten``.
2. Lies ``start``, ``breite`` und ``hoehe`` mit ``LeseZahl``.
3. Lege ``string[,] karte = new string[hoehe, breite];`` an.
4. Durchlaufe mit zwei verschachtelten ``for``-Schleifen alle ``(x, y)``, berechne ``position``, lies Blau, Grün und Rot und speichere ``FarbeZuSymbol(...)`` in ``karte[y, x]``.

### Teil 4 - level: 🙂 - Hauptprogramm
1. Guard ❌: Existiert ``weltkarte.bmp`` nicht → Meldung und ``return;``.
2. Lade die Karte, gib Höhe und Breite aus und zeichne sie mit ``ZeichneKarte``.
3. Vergleiche mit ``weltkarte.txt`` aus Aufgabe01 – es muss dieselbe Welt sein. Steht irgendwo ``💀``, ist eine Farbe oder eine Position falsch. Steht die Welt auf dem Kopf? Dann hast du Besonderheit 1 vergessen.

### 😵‍💫 Bonus: Bild speichern
Schreibe ``void SpeichereKarteAlsBild(string[,] karte, string pfad)``, die eine Karte (z.B. mit Bäumen aus Aufgabe01) wieder als BMP speichert.
- Lege ``byte[] daten = new byte[54 + bytesProZeile * hoehe];`` an.
- Schreibe den Kopf: ``daten[0] = (byte)'B'; daten[1] = (byte)'M';``, an Index ``2`` die Dateigröße, an ``10`` den Wert ``54``, an ``14`` den Wert ``40``, an ``18`` die Breite, an ``22`` die Höhe, ``daten[26] = 1;``, ``daten[28] = 24;``. Dafür brauchst du das Gegenstück zu ``LeseZahl``: ``void SchreibeZahl(byte[] daten, int position, int wert)`` (Tipp: ``/ 256`` und ``% 256``).
- Schreibe die Pixel genau umgekehrt wie beim Lesen und speichere mit ``File.WriteAllBytes``.
