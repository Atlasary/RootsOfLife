using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spot : MonoBehaviour
{
    private SpotBluerint spot;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
        spot = new SpotBluerint();
        spot.gameObject = gameObject;
    }

    private void OnMouseDown()
    {
        buildManager.extendable = spot;
    }

}
