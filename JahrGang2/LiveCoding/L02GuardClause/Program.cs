int age = 24;
bool geldReichtAus = true;
bool hatFuehrerschein = true;


// ######### Verschachtelung #########
// Zustaendigkeit: Prüfe ob Kunde einen Vertrag abschließen darf.
if (age >= 18)
{
    if (geldReichtAus)
    {
        if (hatFuehrerschein)
        {
            // gewünschter Zustand: ☑️
        }
        else
        {
            // ungewünschten Zustand: ❌ (3)
        }
    }
    else
    {
        // ungewünschten Zustand: ❌ (2)
    }
}
else
{
    // ungewünschten Zustand: ❌ (1)
}

//######### Guard Clause #########
if (age < 18) // !(age >= 18)
{
    // ungewünschten Zustand: ❌ (1)
    return;
}

if (!geldReichtAus)
{
    // ungewünschten Zustand: ❌ (2)
    return;
}


if (!hatFuehrerschein)
{
    // ungewünschten Zustand: ❌ (2)
    return;
}


// gewünschter Zustand: ✅

