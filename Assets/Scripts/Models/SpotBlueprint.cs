using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpotBluerint : IExtendable
{

    public GameObject gameObject;

    public Root parent;

    public bool isSelected;

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public float getRange()
    {
        return 0;
    }

    bool IExtendable.isSelected()
    {
        return isSelected;
    }

    public Root getRoot()
    {
        return parent;
    }
}
