using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RootBluePrint : IExtendable {

    public GameObject gameObject;
    public bool isSelected;
    public float range;

    public int health;

    public GameObject GetGameObject()
    {
        return gameObject;
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
