using UnityEngine;
using System.Collections.Generic;
using System;

[Serializable]
public class PlayerSave
{
    // Puntos guardados como texto (para BigInteger)
    public string points = "0";

    // Compra única del primer ítem de tienda (el gato auto-click)
    public bool autoClickBought = false;

    public bool tienda2Bought = false;
}
