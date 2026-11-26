# Lehrernotizen: Schulnetzwerk als LiveCoding 🌐 (50 min)
>Ursprüngliche LiveCoding-Fassung (nur ``Geraet`` + ``Program.cs``, ohne ``Netzwerk``-Klasse). Die Schüler-Aufgabe dazu: [Angabe.md](Angabe.md).

Liste (CRUD) → Interfaces ``IComparable<T>`` / ``IComparer<T>`` → Dictionary (CRUD).
Folien dazu: [L03.1_ListVsDictionary.html](../Skripten/L03.1_ListVsDictionary.html)

**Technischer Bezug:** Ein Rechner, der ein Gerät im LAN erreichen will, braucht dessen **MAC-Adresse**. Er schlägt sie in seiner **ARP-Tabelle** nach – das ist genau ein Dictionary (in echt: IP → MAC). Schaut euch die eigene an: ``arp -a`` in der Konsole.
* **Ping-Warteschlange** → ``List<Geraet>``: Reihenfolge zählt, wichtige Geräte (Router) kommen nach vorne.
* **ARP-Tabelle** → ``Dictionary<string, Geraet>``: Nachschlagen über die MAC-Adresse – ohne alle Geräte durchzugehen.
* **MAC** als Key: eindeutig und ändert sich nie. **Ping** ändert sich ständig → nie als Key.

| Zeit | Teil | Live tippen | Frage an die Klasse |
|---|---|---|---|
| 0–8 | ``Geraet`` | ``Mac`` (nur ``get``), ``Name``, ``PingMs`` (``get; set``), Konstruktor, ``ToString`` | Welches Feld darf sich ändern, welches nie? |
| 8–20 | **List CRUD** | ``Add``, ``Insert(0, …)``, ``[0]``, ``Count``, ``foreach``, Suche mit ``foreach``, ``[1].PingMs += 10``, ``Remove``, ``RemoveAt`` | Warum liefert ``Remove(new Geraet("B2:02", …))`` ``False``? |
| 20–32 | **IComparable / IComparer** | zuerst ``Sort()`` **ohne** Interface → 💥 ``InvalidOperationException``. Dann ``: IComparable<Geraet>`` + ``CompareTo``. Danach ``NachName : IComparer<Geraet>`` | Was bedeutet < 0 / 0 / > 0? Warum zwei Interfaces? |
| 32–45 | **Dictionary CRUD** | ``Add`` in der Schleife, ``TryAdd`` doppelt, ``arp["C3:33"]``, ``TryGetValue``, ``arp["C3:33"].PingMs -= 20``, ``Remove``, ``ContainsKey``, ``foreach ((mac, g) in arp)`` | Warum ist die MAC ein guter Key, der Ping nicht? |
| 45–50 | **Abschluss** | ``new List<Geraet>(arp.Values)`` + ``Sort()`` | Wann Liste, wann Dictionary? |

## Die drei „Aha“-Momente
1. **Identität (Min. ~18):** ``warteschlange.Remove(new Geraet("B2:02", "Laptop", 95))`` → ``False``. Gleiche Werte, aber ein **anderes Objekt**. ``Remove`` vergleicht mit ``Equals`` – bei einer Klasse ohne Override ist das die **Identität**.
2. **Sort ohne Interface (Min. ~21):** ``Sort()`` weiß nicht, wie man Geräte vergleicht → Exception. Das Interface ist ein **Versprechen**, auf das ``Sort`` sich verlässt.
3. **Referenzen im Dictionary (Min. ~40):** ``arp["C3:33"].PingMs -= 20`` ändert auch ``gesucht`` aus Teil 1: Liste und Dictionary speichern **Referenzen** auf dieselben Objekte.

## Key: string, class oder record? (Daumenregeln, Folie im Tab „Was darf ein Key sein?“)
* **Key** ist ``string Mac`` → ein einfacher, unveränderlicher Wert: **1. Wahl**.
* **Value** ``Geraet`` bleibt eine **class**: ein Ding mit **Identität**, dessen ``PingMs`` sich ändert. Ein ``record Geraet`` würde über **alle** Werte vergleichen – ein Geraet mit anderem ``PingMs`` wäre plötzlich ein „anderes“ Objekt, und als Key würde es im Dictionary „verrutschen“.
* **Puffer-Aufgabe** ``Equals``/``GetHashCode``: **nur** über ``Mac`` überschreiben – nie über ``PingMs``:
```csharp
public override bool Equals(object? o) => o is Geraet x && x.Mac == Mac;
public override int GetHashCode() => Mac.GetHashCode();
```
* Wer einen eigenen Key-Typ will: ``record MacNummer(string Wert);`` – Wertsemantik und unveränderlich, ohne eine Zeile Equals.

## Erwarteter Output
```
--- 1) Ping-Warteschlange: List<Geraet> ---
Erstes:  🖥️ Router    00:01  110 ms
Anzahl:  4
  🖥️ Router    00:01  110 ms
  🖥️ Drucker   A1:17  120 ms
  🖥️ Laptop    B2:02   95 ms
  🖥️ Beamer    C3:33  140 ms
Gesucht: 🖥️ Beamer    C3:33  140 ms
Update:  🖥️ Drucker   A1:17  130 ms
Remove(neuer Laptop): False
Nach RemoveAt(2): 3 Geräte
--- 2) Sortieren ---
nach Ping:
  🖥️ Switch    D4:08   95 ms
  🖥️ Router    00:01  110 ms
  🖥️ Drucker   A1:17  130 ms
  🖥️ Beamer    C3:33  140 ms
nach Name:
  🖥️ Beamer    C3:33  140 ms
  🖥️ Drucker   A1:17  130 ms
  🖥️ Router    00:01  110 ms
  🖥️ Switch    D4:08   95 ms
Langsamstes: 🖥️ Beamer    C3:33  140 ms
--- 3) ARP-Tabelle: Dictionary<string, Geraet> ---
TryAdd doppelt: False
arp["C3:33"]: 🖥️ Beamer    C3:33  140 ms
FF:99 ist nicht im Netz
gesucht aus 1): 🖥️ Beamer    C3:33  120 ms
Router noch da? False
  C3:33 -> Beamer
  A1:17 -> Drucker
  D4:08 -> Switch
--- 4) Bericht ---
  🖥️ Switch    D4:08   95 ms
  🖥️ Beamer    C3:33  120 ms
  🖥️ Drucker   A1:17  130 ms
```

## Puffer
* **Zeit übrig:** ``Equals``/``GetHashCode`` über ``Mac`` überschreiben → ``Remove(new Geraet("B2:02", …))`` liefert ``True``. Oder ``SortedDictionary`` → ARP-Tabelle sortiert nach MAC.
* **Zeit knapp:** ``NachName`` weglassen, Teil 4 nur mündlich.
