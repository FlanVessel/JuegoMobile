using UnityEngine;
using System.Collections.Generic;
using System;

[Serializable]
public class PlayerSave
{
    // Puntos guardados como texto (para BigInteger)
    public string points = "0";

    public bool autoClickBought = false;

    public bool tienda2Bought = false;

    public bool tienda3Bought = false;

    public bool tienda4Bought = false;

    public bool tienda5Bought = false;

    public bool tienda6Bought = false;

    public int granjaNivel = 0;
}
