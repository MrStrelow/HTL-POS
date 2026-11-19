**Zettelübung: Default- und Named Parameter 🎛️** (ca. 10 min)
**Name:** _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ 
**Datum:** _ _ _ _ _ _ _ _ _ _ _ _ 

Gegeben ist folgende ``Funktion``:
```csharp
string Rahmen(string text, char zeichen = '*', int breite = 20, bool gross = false)
```

**Übung 1: Wer bekommt welchen Wert?**

Trage für jeden Aufruf ein, welchen Wert jeder ``Parameter`` bekommt. Markiere mit **P** (positional), **N** (named) oder **D** (Default).

| Aufruf | ``text`` | ``zeichen`` | ``breite`` | ``gross`` |
| :--- | :--- | :--- | :--- | :--- |
| ``Rahmen("Hallo")`` | | | | |
| ``Rahmen("Hallo", '#')`` | | | | |
| ``Rahmen("Hallo", breite: 30)`` | | | | |
| ``Rahmen(gross: true, text: "Hallo")`` | | | | |

**Übung 2: Erlaubt oder Compilerfehler?**

Kreuze an und begründe in einem Satz.

| Aufruf / Signatur | ✔ | ✘ | Begründung |
| :--- | :---: | :---: | :--- |
| ``Rahmen()`` | | | |
| ``Rahmen("Hallo", '-', gross: true)`` | | | |
| ``Rahmen(breite: 10, "Hallo")`` | | | |
| ``string Rahmen(char zeichen = '*', string text)`` | | | |
