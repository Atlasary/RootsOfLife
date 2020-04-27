using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YggdrasilUI : MonoBehaviour
{
    private Yggdrasil target;

    public GameObject ui;

    public void SetTarget(Yggdrasil yggdrasil)
    {
        target = yggdrasil;

        transform.position = target.GetYggdrasilPosition();

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }
}
