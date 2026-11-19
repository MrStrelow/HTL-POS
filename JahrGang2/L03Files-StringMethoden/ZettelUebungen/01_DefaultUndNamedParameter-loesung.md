**Zettelübung: Default- und Named Parameter 🎛️** (ca. 10 min)

**Name:** 
Musterlösung 
**Datum:** 
_ _ _ _ _ _ _ _ _ _ _ _ 

```csharp
string Rahmen(string text, char zeichen = '*', int breite = 20, bool gross = false)
```

**Übung 1: Wer bekommt welchen Wert?**

| Aufruf | ``text`` | ``zeichen`` | ``breite`` | ``gross`` |
| :--- | :--- | :--- | :--- | :--- |
| ``Rahmen("Hallo")`` | ``"Hallo"`` P | ``'*'`` D | ``20`` D | ``false`` D |
| ``Rahmen("Hallo", '#')`` | ``"Hallo"`` P | ``'#'`` P | ``20`` D | ``false`` D |
| ``Rahmen("Hallo", breite: 30)`` | ``"Hallo"`` P | ``'*'`` D | ``30`` N | ``false`` D |
| ``Rahmen(gross: true, text: "Hallo")`` | ``"Hallo"`` N | ``'*'`` D | ``20`` D | ``true`` N |

Argumente ohne Namen werden **der Reihe nach** verteilt. Mit Namen ist die Reihenfolge egal. Was fehlt, kommt aus dem Default.

**Übung 2: Erlaubt oder Compilerfehler?**

| Aufruf / Signatur | ✔ | ✘ | Begründung |
| :--- | :---: | :---: | :--- |
| ``Rahmen()`` | | ✘ | ``text`` hat keinen Default – ein Pflicht-Parameter fehlt. |
| ``Rahmen("Hallo", '-', gross: true)`` | ✔ | | Erst positional, dann benannt. ``breite`` bleibt ``20``. |
| ``Rahmen(breite: 10, "Hallo")`` | | ✘ | Das benannte Argument steht an der falschen Stelle, danach kommt ein Argument ohne Namen. |
| ``string Rahmen(char zeichen = '*', string text)`` | | ✘ | Default-Parameter müssen **am Ende** stehen. |
