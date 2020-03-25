using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpotBluerint : IExtendable
{

    public GameObject gameObject;
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
}
