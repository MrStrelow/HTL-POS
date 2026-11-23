**Zettelübung: hat-Beziehungen und Multiplizitäten im Klassendiagramm 📐** (10 Minuten)

**Name:** 
Musterlösung 
**Datum:** 
_ _ _ _ _ _ _ _ _ _ _ _ 

## Übung 1: Was bedeutet die Multiplizität?

| am Pfeilende | bedeutet | im Code z. B. |
| :--- | :--- | :--- |
| ``1:1`` | **genau ein** Objekt | ein ``Feld``: ``Schloss _schloss`` |
| ``0:1`` | **keines oder eines** (höchstens eines) | ein ``Feld``, das auch leer sein darf: ``Kunde _ausgeliehenVon`` |
| ``0:n`` | **beliebig viele** (auch keines) | ein Array: ``Hamster[] _hamsters`` |
| ``1:n`` | **mindestens eines**, nach oben offen | ein Array mit mindestens einem Element: ``Fahrrad[] _fahrraeder`` |
| ``2:2`` | **genau zwei** Objekte | ein Array mit Länge 2: ``Kunde[] _notfall`` |

>Tipp: Wir schreiben **Minimum:Maximum**. Links vom ``:`` steht das **Minimum**, rechts das **Maximum**. ``n`` heißt „beliebig viele“.

## Übung 2: Ergänze das Klassendiagramm

```plantuml {align="center"}
@startuml
!theme crt-amber
skinparam backgroundColor transparent

class Verleih {
  + _fahrraeder : Fahrrad[]
}
class Fahrrad {
  + _schloss : Schloss
  + _ausgeliehenVon : Kunde
}
class Schloss {
  + _code : int
}
class Kunde {
  + _name : string
  + _notfall : Kunde[]
}

Verleih --> "1:n" Fahrrad : "  _fahrraeder"
Fahrrad --> "1:1" Schloss : "  _schloss"
Fahrrad --> "0:1" Kunde : "  _ausgeliehenVon"
Kunde --> "2:2" Kunde : "  _notfall"
@enduml
```

| von | nach | ``Feld`` | Multiplizität |
| :--- | :--- | :--- | :--- |
| ``Verleih`` | ``Fahrrad`` | ``_fahrraeder`` | ``1:n`` |
| ``Fahrrad`` | ``Schloss`` | ``_schloss`` | ``1:1`` |
| ``Fahrrad`` | ``Kunde`` | ``_ausgeliehenVon`` | ``0:1`` |
| ``Kunde`` | ``Kunde`` | ``_notfall`` | ``2:2`` |

## Übung 3: Kurz gefragt

#### 1. - Richtung
**Unidirektional.** Nur ``Fahrrad`` hat ein ``Feld`` vom ``Typ`` ``Kunde`` (``_ausgeliehenVon``). ``Kunde`` hat kein ``Feld`` vom ``Typ`` ``Fahrrad``. Im Klassendiagramm gibt es nur **einen** Pfeil mit **einer** Spitze: von ``Fahrrad`` zu ``Kunde``.

#### 2. - rekursiv
``_notfall`` in ``Kunde``: Der ``Typ`` des ``Feldes`` ist ``Kunde`` – die eigene ``Klasse``. Der Pfeil zeigt von ``Kunde`` zurück zu ``Kunde``. Gemeint sind trotzdem **andere** Kunden-Objekte.

#### 3. - bidirektional machen
```
Klasse: Kunde   Feld: _faehrt : Fahrrad   Multiplizität: 0:1
```
Jetzt gibt es Pfeile in **beide** Richtungen zwischen ``Fahrrad`` und ``Kunde`` → **bidirektional**.
