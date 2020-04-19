using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint : IBuyable
{
    public GameObject gameObject;

    public int price;

    public int getPrice()
    {
        return price;
    }
}
