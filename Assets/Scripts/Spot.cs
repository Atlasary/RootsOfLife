using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spot : MonoBehaviour
{
    private SpotBluerint spot;
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
        buildManager.extendable = spot;
    }

}
