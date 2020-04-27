using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RootBluePrint : IExtendable, IBuyable
{

    public GameObject gameObject;
    public bool isSelected;
    public float range;
    public int price;

    public int health;
    public int currentHealth;

    public bool isUpgraded;
    public int upgradePrice;

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public int getPrice()
    {
        return price;
    }

    public float getRange()
    {
        return range;
    }

    bool IExtendable.isSelected()
    {
        return isSelected;
    }
}
