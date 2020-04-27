using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotUI : MonoBehaviour
{
    private Spot target;

    public GameObject ui;

    public void SetTarget(Spot spot)
    {
        target = spot;

        transform.position = target.spot.gameObject.transform.position;

        ui.SetActive(true);
    }

    public void Hide()
    {
         ui.SetActive(false);
    }

}
