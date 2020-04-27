using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpotUI : MonoBehaviour
{
    private Spot target;

    public GameObject ui;

    public Text extendCost;

    public RootBluePrint rootPrefab;

    public void SetTarget(Spot spot)
    {
        target = spot;

        transform.position = target.spot.gameObject.transform.position + new Vector3(0, 20f, 0);

        updateExtend();

        ui.SetActive(true);
    }

    public void Hide()
    {
         ui.SetActive(false);
    }

    public void updateExtend()
    {
        extendCost.text = rootPrefab.price.ToString();
    }

    public void Extend()
    {
        target.Extend();
    }

}
