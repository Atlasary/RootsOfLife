using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootUI : MonoBehaviour
{
    private Root target;

    public GameObject ui;

    public void SetTarget(Root root)
    {
        target = root;

        transform.position = target.GetRootPosition();

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }
}
