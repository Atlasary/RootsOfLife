using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class YggdrasilBlueprint : IExtendable {

    public GameObject gameObject;
    public bool isSelected;
    public float range;

    public bool isUpgraded;
    public int upgradePrice;

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
