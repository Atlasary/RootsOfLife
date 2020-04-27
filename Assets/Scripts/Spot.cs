using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spot : MonoBehaviour
{
    public SpotBluerint spot;
    public Root parent;

    BuildManager buildManager;

    private void Start()
    {
        parent = transform.parent.GetComponent<Root>();

        buildManager = BuildManager.instance;
        spot = new SpotBluerint();
        spot.parent = parent;
        spot.gameObject = gameObject;
    }

    private void OnMouseDown()
    {
        buildManager.SelectSpot(this);
    }

    internal void Extend()
    {
        Ground.extendable = true;
    }
}
