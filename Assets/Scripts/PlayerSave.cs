using UnityEngine;
using System.Collections.Generic;
using System;

[Serializable]
public class PlayerSave
{
    public string points = "0";

    [Serializable]
    public class UpgradeState
    {
        public string id;   // identificador del upgrade
        public int level;   // cuántas veces se ha comprado
    }

    public List<UpgradeState> upgrades = new();
}
